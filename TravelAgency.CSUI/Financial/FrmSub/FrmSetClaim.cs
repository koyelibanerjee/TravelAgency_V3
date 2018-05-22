using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.BLL;
using TravelAgency.Common;

namespace TravelAgency.CSUI.Financial.FrmSub
{
    public partial class FrmSetClaim : Form
    {

        private List<Model.Visa> _list;
        private BLL.ConsulateCharge _bllConsulateCharge = new ConsulateCharge();
        private BLL.ClientCharge _bllClientCharge = new ClientCharge();
        private BLL.Visa _bllVisa = new BLL.Visa();
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托
        private readonly int _curPage; //主界面更新数据库需要一个当前页
        private readonly BLL.CustomerBalance _bllBalance = new CustomerBalance();
        private readonly BLL.ClaimMoney _bllClaimMoney = new ClaimMoney();
        private List<Model.CustomerBalance> _balanceList;

        private decimal _clientBalance = 0;

        private FrmSetClaim()
        {
            if (this.Modal)
                this.StartPosition = FormStartPosition.CenterScreen;
            else
                this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            InitializeComponent();
        }

        public FrmSetClaim(List<Model.Visa> list, Action<int> updateDel, int curPage)
        : this()
        {
            _list = list;
            _updateDel = updateDel;
            _curPage = curPage;
        }

        private void FrmSetClaim_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false; //不显示指定之外的列
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; //列宽自适应,一定不能用AllCells
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders; //这里也一定不能AllCell自适应!
            dataGridView1.Columns["GroupNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.ReadOnly = false;

            dataGridView1.RowsAdded += DataGridView1_RowsAdded;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            dataGridView1.CellMouseUp += dataGridView1_CellMouseUp;
            dataGridView1.DefaultCellStyle.Font = new Font("微软雅黑", 9.0f, FontStyle.Bold);
            dataGridView1.DataSource = _list;

            //查询客户余额
            _balanceList = _bllBalance.GetModelList(" CustomerName = '" + _list[0].client + "' and BalanceAmount > 0");
            _balanceList.Sort((Model.CustomerBalance b1, Model.CustomerBalance b2) => b1.BalanceAmount - b2.BalanceAmount < 0 ? -1 : 1);
            if (_balanceList.Count < 1)
            {
                MessageBoxEx.Show("未找到客户可用余额信息!!!");
                lbClientBalance.Text = "客户可用余额不足!!!";
                return;
            }

            for (int i = 0; i < _balanceList.Count; ++i)
            {
                _clientBalance += _balanceList[i].BalanceAmount;
            }

            lbClientBalance.Text = "客户可用余额:" + _clientBalance + "元.";

            DataGridView1_SelectionChanged(null, null);

        }

        private List<Model.Visa> DgvDataSourceToList()
        {
            return dataGridView1.DataSource as List<Model.Visa>;
        }

        /// <summary>
        /// 返回当前选择的行的visaModel的List
        /// </summary>
        /// <returns></returns>
        private List<Model.Visa> GetSelectedModelList()
        {
            var visaList = dataGridView1.DataSource as List<Model.Visa>;
            List<Model.Visa> res = new List<Model.Visa>();
            for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
                res.Add(DgvDataSourceToList()[dataGridView1.SelectedRows[i].Index]);
            return res.Count > 0 ? res : null;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;
            decimal total = 0;

            for (int i = 0; i < dataGridView1.SelectedRows.Count; ++i)
            {
                var model = DgvDataSourceToList()[dataGridView1.SelectedRows[i].Index];
                total += DecimalHandler.Parse(model.Receipt.ToString());
            }


            lbClientBalance.Text = string.Format("客户\"{3}\"余额:{0},选中项合计:{1},扣除后剩余:{2}", _clientBalance, total,
                _clientBalance - total, _list[0].client);
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }

        private string GetCellValue(int rowidx, string colname)
        {
            return dataGridView1.Rows[rowidx].Cells[colname].Value.ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("是否对选中团号进行认账?", "提醒", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            var list = GetSelectedModelList();
            //执行计算
            if (!ClaimMoney(list, _balanceList))
                return;
            this.Close();
            _updateDel(_curPage);
        }


        private bool ClaimMoney(List<Model.Visa> visaList, List<Model.CustomerBalance> balanceList)
        {
            //同一个客户在进来就限制了
            decimal totalMoney = 0;

            for (int i = 0; i < visaList.Count; i++)
            {
                if (!visaList[i].Receipt.HasValue || visaList[i].Receipt.Value == 0)
                {
                    MessageBoxEx.Show("还有团号未设置收款金额!!!");
                    return false;
                }
                totalMoney += visaList[i].Receipt.Value;
            }

            if (totalMoney > _clientBalance)
            {
                MessageBoxEx.Show("余额不足!!!");
                return false;
            }

            List<Model.CustomerBalance> newBalances = new List<Model.CustomerBalance>();
            List<Model.ClaimMoney> newClaims = new List<Model.ClaimMoney>();
            List<Model.Visa> visaBackup = new List<Model.Visa>();
            foreach (var visa in visaList)
                visaBackup.Add(visa.ToObjectCopy());

            while (visaList.Count > 0)
            {
                var visa = visaList[0];
                var balance = balanceList[0];
                Model.ClaimMoney claimMoney = new Model.ClaimMoney(); //每次都会生成一条新的claimMoney
                if (visa.Receipt == balance.BalanceAmount)
                {
                    claimMoney.Amount = visa.Receipt;
                    visaList.RemoveAt(0);
                    balanceList.RemoveAt(0);
                    balance.BalanceAmount -= visa.Receipt.Value;
                    newBalances.Add(balance);
                }
                else if (visa.Receipt < balance.BalanceAmount)
                {
                    claimMoney.Amount = visa.Receipt;
                    visaList.RemoveAt(0);
                    balance.BalanceAmount -= visa.Receipt.Value;
                    //后者不移出
                }
                else //visaList[0].Receipt > balanceList[0].Amount
                {
                    claimMoney.Amount = balance.BalanceAmount;
                    visa.Receipt -= balance.BalanceAmount;
                    balance.BalanceAmount = 0;
                    newBalances.Add(balance);
                    balanceList.RemoveAt(0);
                    //前者不移出
                }

                claimMoney.Money_id = balance.Money_id;
                claimMoney.DepartmentId = GlobalUtils.LoginUser.DepartmentId;
                claimMoney.Name_Claim = GlobalUtils.LoginUser.UserName;
                claimMoney.GroupNo = visa.GroupNo;
                claimMoney.Salesperson = visa.SalesPerson;
                claimMoney.Methods = "签证系统认领";
                claimMoney.WorkId = GlobalUtils.LoginUser.WorkId;
                claimMoney.ClaimTime = DateTime.Now;
                claimMoney.username = GlobalUtils.LoginUser.UserName;
                claimMoney.EntryTime = DateTime.Now;
                claimMoney.MoneyType = balance.MoneyType;
                claimMoney.Claim_Confirm = "1";

                newClaims.Add(claimMoney);
            }

            //完了过后，balance如果没用完的话，需要把第一条加进来更新余额
            if (balanceList.Count > 0)
                newBalances.Add(balanceList[0]); //这里倒不用判断，反正始终更新一下应该是不会出错的

            //执行所有的更新
            int sucClaim = 0, sucVisa = 0, sucBalance = 0;
            for (int i = 0; i < newClaims.Count; ++i)
                sucClaim += _bllClaimMoney.Add(newClaims[i]) ? 1 : 0;

            for (int i = 0; i < newBalances.Count; i++)
                sucBalance += _bllBalance.Update(newBalances[i]) ? 1 : 0;

            for (int i = 0; i < visaBackup.Count; i++)
            {
                visaBackup[i].ClaimedFlag = "是";
                sucVisa += _bllVisa.Update(visaBackup[i]) ? 1 : 0;
            }
            return true;
        }

        /// <summary>
        /// dgv右键响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    //如果没选中当前活动行则选中这一行
                    if (dataGridView1.Rows[e.RowIndex].Selected == false)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dataGridView1.SelectedRows.Count == 1)
                    {
                        if (e.ColumnIndex != -1) //选中表头了
                            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        else
                        {
                            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[0];
                        }

                    }
                    //弹出操作菜单
                    cmsDgv.Show(MousePosition.X, MousePosition.Y);

                }
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void 签证认账ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCancel_Click(null, null);
        }
    }
}
