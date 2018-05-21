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
            for (int i = 0; i <= 27; ++i)
            {
                if (i < 17)
                    dataGridView1.Columns[i].ReadOnly = true;
                //else dataGridView1.Columns[i].ReadOnly = false; //这些列可编辑
            }
            dataGridView1.RowsAdded += DataGridView1_RowsAdded;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
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


        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateMoneyCount();
        }

        private void UpdateMoneyCount()
        {
            decimal num = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                object value = dataGridView1.Rows[i].Cells["ConsulateCost"].Value;
                num += value == null ? 0 : decimal.Parse(value.ToString());
                value = dataGridView1.Rows[i].Cells["VisaPersonCost"].Value;
                num += value == null ? 0 : decimal.Parse(value.ToString());
                value = dataGridView1.Rows[i].Cells["InvitationCost"].Value;
                num += value == null ? 0 : decimal.Parse(value.ToString());
                value = dataGridView1.Rows[i].Cells["Receipt"].Value;
                num += value == null ? 0 : decimal.Parse(value.ToString());

            }
            lbClientBalance.Text = "共" + num + "元.";
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

        /// <summary>
        /// 查询指定行的配置条目
        /// </summary>
        /// <returns></returns>
        private List<Model.ConsulateCharge> GetConsulateCharges(int rowidx)
        {
            List<string> conditions = new List<string>();
            string str = GetCellValue(rowidx, "DepartureType");
            if (!string.IsNullOrEmpty(str))
            {
                //sb.Append(" DepartureType='" + cbDepartureType.Text + "'");

                conditions.Add(" (DepartureType like  '%" + str + "%') ");
            }
            str = GetCellValue(rowidx, "Country");

            if (!string.IsNullOrEmpty(str))
            {
                //sb.Append(" Country='" + cbCountry.Text + "'");
                conditions.Add(" (Country like  '%" + str + "%') ");

            }
            str = GetCellValue(rowidx, "Types");

            if (!string.IsNullOrEmpty(str))
            {
                conditions.Add(" (Types like  '%" + str + "%') ");
                //sb.Append(" Types='" + cbType.Text + "'");
            }

            string[] arr = conditions.ToArray();
            string where = string.Join(" and ", arr);

            var list = _bllConsulateCharge.GetModelList(where);
            return list;
        }

        /// <summary>
        /// 查询指定行的配置条目
        /// </summary>
        /// <returns></returns>
        private List<Model.ClientCharge> GetClientCharges(int rowidx, bool full = false)
        {
            List<string> conditions = new List<string>();
            string str = GetCellValue(rowidx, "DepartureType");
            if (!string.IsNullOrEmpty(str))
            {
                //sb.Append(" DepartureType='" + cbDepartureType.Text + "'");

                conditions.Add(" (DepartureType like  '%" + str + "%') ");
            }
            str = GetCellValue(rowidx, "Country");

            if (!string.IsNullOrEmpty(str))
            {
                //sb.Append(" Country='" + cbCountry.Text + "'");
                conditions.Add(" (Country like  '%" + str + "%') ");
            }
            str = GetCellValue(rowidx, "Types");

            if (!string.IsNullOrEmpty(str))
            {
                conditions.Add(" (Types like  '%" + str + "%') ");
                //sb.Append(" Types='" + cbType.Text + "'");
            }

            str = GetCellValue(rowidx, "Client");

            if (!string.IsNullOrEmpty(str))
            {
                conditions.Add(" (Client like  '%" + str + "%') ");
                //sb.Append(" Types='" + cbType.Text + "'");
            }

            if (full)
            {
                str = GetCellValue(rowidx, "Receipt");

                if (!string.IsNullOrEmpty(str))
                {
                    conditions.Add(" (Receipt like  '%" + str + "%') ");
                    //sb.Append(" Types='" + cbType.Text + "'");
                }
            }
            string[] arr = conditions.ToArray();
            string where = string.Join(" and ", arr);

            var list = _bllClientCharge.GetModelList(where);
            return list;
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("是否提交?", "提醒", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            var list = dataGridView1.DataSource as List<Model.Visa>;
            //执行计算
            if(!ClaimMoney(list, _balanceList))
                return;

            //int res = _bllVisa.UpdateList(dataGridView1.DataSource as List<Model.Visa>);
            //GlobalUtils.MessageBoxWithRecordNum("更新", res, _list.Count);
            //this.DialogResult = DialogResult.OK;
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

            //MessageBoxEx.Show(string.Format("{0}/{1},{2}/{3},{4}/{5}", sucVisa, visaList.Count, sucBalance, balanceList
            //    .Count, sucClaim, newClaims.Count));

            return true;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
