using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.BLL;
using TravelAgency.BLL.Excel;
using TravelAgency.Common;
using TravelAgency.Common.FrmSetValues;

namespace TravelAgency.CSUI.Financial.FrmSub
{
    public partial class FrmSetClaim : Form
    {
        //当前页面list
        private List<Model.Visa> _list;

        //bll相关
        private readonly BLL.ClientCharge _bllClientCharge = new ClientCharge();
        private readonly BLL.Visa _bllVisa = new BLL.Visa();
        private readonly BLL.ActivityOrder _bllActivityOrder = new BLL.ActivityOrder();
        private readonly BLL.CustomerBalance _bllBalance = new CustomerBalance();
        private readonly BLL.ClaimMoney _bllClaimMoney = new ClaimMoney();

        //主界面的刷新操作
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托
        private readonly int _curPage; //主界面更新数据库需要一个当前页


        //认账相关
        private List<Model.CustomerBalance> _normalBalanceList;
        private List<Model.CustomerBalance> _activityBalanceList;
        private string _clientName = null;
        private decimal _clientNormalBalance = 0;
        private decimal _clientActivityBalance = 0;

        private readonly Dictionary<string, int> _curActivityOrderCnt = new Dictionary<string, int>();
        //activityNo对应一共扣了多少本

        private readonly Dictionary<string, int> _origActivityOrderCnt = new Dictionary<string, int>();
        //进入这个窗口的时候activityNo每个已经扣了多少本

        private readonly Dictionary<string, string> _visaidOrderDict = new Dictionary<string, string>(); //visa对应的每一个订单号

        private string _activityName = "20180913活动";

        private FrmSetClaim()
        {
            if (this.Modal)
                this.StartPosition = FormStartPosition.CenterParent;
            else
                this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            FrmsManager.FormSetClaim = this;
            InitializeComponent();
        }

        public FrmSetClaim(List<Model.Visa> list, Action<int> updateDel, int curPage)
            : this()
        {
            _list = list;
            _updateDel = updateDel;
            _curPage = curPage;
            _clientName = UtilsBll.getClientNameNoHR(list[0].client);
        }

        private void FrmSetClaim_Load(object sender, EventArgs e)
        {
            this.Closing += FrmSetClaim_Closing;

            dataGridView1.AutoGenerateColumns = false; //不显示指定之外的列
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; //列宽自适应,一定不能用AllCells
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            //这里也一定不能AllCell自适应!
            dataGridView1.Columns["GroupNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.ReadOnly = false;

            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            dataGridView1.CellMouseUp += dataGridView1_CellMouseUp;
            dataGridView1.RowsAdded += DataGridView1_RowsAdded;
            dataGridView1.DefaultCellStyle.Font = new Font("微软雅黑", 9.0f, FontStyle.Bold);
            dataGridView1.DataSource = _list;

            DataGridView1_SelectionChanged(null, null);

            //dataGridView1.ReadOnly = true;
            dataGridView1.Columns["Price"].ReadOnly = false;
            dataGridView1.Columns["ActuallyAmount"].ReadOnly = false;

            UpdateClientBalanceInfo();

            //记住原有的orderCnt
            foreach (var visa in _list)
                if (!string.IsNullOrEmpty(visa.ActivityOrderNo))
                    if (!_origActivityOrderCnt.ContainsKey(visa.ActivityOrderNo))
                        _origActivityOrderCnt.Add(visa.ActivityOrderNo, visa.Number.Value);
                    else
                        _origActivityOrderCnt[visa.ActivityOrderNo] += visa.Number.Value;

        }

        private void UpdateClientBalanceInfo()
        {
            //查询客户余额
            _normalBalanceList = _bllBalance.GetClientBalanceListOrderByBalanceAsc(_clientName, ""); //查询非活动可用余额
            if (_normalBalanceList.Count < 1)
            {
                MessageBoxEx.Show("未找到客户可用余额信息!!!");
                lbCount.Text = "无客户可用余额信息!(无常规余额的情况下，活动余额也不会参与计算)";
                return;
            }

            _activityBalanceList = _bllBalance.GetClientBalanceListOrderByBalanceAsc(_clientName, _activityName);
            //查询客户可用活动余额

            _clientNormalBalance = 0;
            for (int i = 0; i < _normalBalanceList.Count; ++i)
                _clientNormalBalance += _normalBalanceList[i].BalanceAmount;

            _clientActivityBalance = 0;
            for (int i = 0; i < _activityBalanceList.Count; ++i)
                _clientActivityBalance += _activityBalanceList[i].BalanceAmount;

            lbCount.Text = $"客户可用余额:{_clientNormalBalance}元,活动定金可用余额为:{_clientActivityBalance}.";
        }

        private void FrmSetClaim_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (FrmsManager.FormSetClaim != null)
                FrmsManager.FormSetClaim = null;
        }

        #region dgv events

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["Tips2"].Value != null &&
                    !string.IsNullOrEmpty(dataGridView1.Rows[i].Cells["Tips2"].Value.ToString()))
                    dataGridView1.Rows[i].Cells["Tips2"].Style.BackColor = Color.Chocolate;
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;
            decimal totalNormalMoney = 0;
            decimal totalActivityMoney = 0;
            int totalPerson = 0;
            for (int i = 0; i < dataGridView1.SelectedRows.Count; ++i)
            {
                var model = DgvDataSourceToList()[dataGridView1.SelectedRows[i].Index];
                decimal[] visaMoney = GetVisaNormalAndActivityMoney(model);
                totalNormalMoney += visaMoney[0];
                totalActivityMoney += visaMoney[1];
            }
            lbCount.Text = string.Format("客户\"{0}\"常规余额:{1},选中项合计:{2},扣除后剩余:{3} 活动余额:{4},选中项合计:{5},扣除后剩余:{6}",
                _clientName,
                _clientNormalBalance, totalNormalMoney, _clientNormalBalance - totalNormalMoney, _clientActivityBalance,
                totalActivityMoney, _clientActivityBalance - totalActivityMoney);
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name != "Price")
                return;
            var list = GetClientCharges(e.RowIndex);
            if (list.Count <= 0)
            {
                MessageBoxEx.Show("未找到相关记录，请手动录入!");
                return;
            }
            FrmSelClientCharge frm = new FrmSelClientCharge(list);
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;
            string country = GetCellValue(e.RowIndex, "Country");
            string type = GetCellValue(e.RowIndex, "Types");
            string depatureType = GetCellValue(e.RowIndex, "DepartureType");
            string client = GetCellValue(e.RowIndex, "Client");



            if (frm.ChangeAllAlike) //全部一起修改
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (GetCellValue(i, "Country") == country && GetCellValue(i, "Types") == type &&
                        GetCellValue(i, "DepartureType") == depatureType && GetCellValue(i, "client") == client)
                    {
                        dataGridView1.Rows[i].Cells["Price"].Value = list[frm.SelIdx].Charge;
                        var visa = DgvDataSourceToList()[i];
                        if (!string.IsNullOrEmpty(visa.ActivityOrderNo) && //更新和活动订单相关的变量
                            _curActivityOrderCnt.ContainsKey(visa.ActivityOrderNo)) //原来是设置的活动订单的价格，现在是套的普通的价格，就要执行恢复
                        {
                            _curActivityOrderCnt[visa.ActivityOrderNo] -= visa.Number.Value;
                            _visaidOrderDict.Remove(visa.Visa_id.ToString());
                        }
                    }
                }
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].Cells["Price"].Value = list[frm.SelIdx].Charge;
                var visa = GetSelectedModelList()[0];
                if (!string.IsNullOrEmpty(visa.ActivityOrderNo) &&
                    _curActivityOrderCnt.ContainsKey(visa.ActivityOrderNo)) //同上，只是是一条
                {
                    _curActivityOrderCnt[visa.ActivityOrderNo] -= visa.Number.Value;
                    _visaidOrderDict.Remove(visa.Visa_id.ToString());
                }

            }
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
                            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[0];
                    }
                    //弹出操作菜单
                    cmsDgv.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        #endregion


        /// <summary>
        /// 主界面执行添加的时候调用此函数添加到此界面
        /// </summary>
        /// <param name="visaList"></param>
        public void AddVisa(List<Model.Visa> visaList)
        {
            foreach (var visa in visaList)
            {
                if (UtilsBll.getClientNameNoHR(visa.client) != UtilsBll.getClientNameNoHR(_list[0].client))
                {
                    MessageBoxEx.Show("不同客户不能同时认账!!!");
                    return;
                }
            }
            var list = dataGridView1.DataSource as List<Model.Visa>;

            HashSet<Guid> set = new HashSet<Guid>();
            foreach (var visa_old in list)
                set.Add(visa_old.Visa_id);

            foreach (var visa_new in visaList)
            {
                if (set.Contains(visa_new.Visa_id))
                    continue;
                list.Add(visa_new);
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
            _list = list;
        }

        #region DgvUtils

        private void UpdateDgvList()
        {
            var list = DgvDataSourceToList();
            dataGridView1.DataSource = null;
            if (list != null && list.Count > 0)
                dataGridView1.DataSource = list;
        }

        private List<Model.Visa> DgvDataSourceToList()
        {
            return dataGridView1.DataSource as List<Model.Visa>;
        }

        private string GetCellValue(int rowidx, string colname)
        {
            return dataGridView1.Rows[rowidx].Cells[colname].Value.ToString();
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

        #endregion

        #region 按钮事件

        private void btnGenPayList_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("生成账单后，会提交所做修改到数据库，是否继续?", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            var list = DgvDataSourceToList();

            if (!checkGreaterThanCost(list))
            {
                if (MessageBoxEx.Show("选中项中有收款小于成本的，是否继续?", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;
            }

            FrmSetStringValue frm = new FrmSetStringValue("设置账单编号");
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;
            string paymentNo = frm.RetValue;
            XlsGenerator.GetPaymentList(list, paymentNo);

            //更新Visa的list
            foreach (var visa in list) //每个的活动订单号在套用活动价格的时候就设置了
            {
                visa.ClaimedFlag = "已生成账单";
                visa.PaymentNo = paymentNo;
            }
            _bllVisa.UpdateList(list);


            UpdateActivityOrders();

            //foreach (var pair in _curActivityOrderCnt)
            //{
            //    var activityOrderModel = _bllActivityOrder.GetModel(pair.Key);
            //    activityOrderModel.BalanceBooks -= pair.Value;
            //    _bllActivityOrder.Update(activityOrderModel);
            //}
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("是否对列表中团号进行认账?", "提醒", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            var list = DgvDataSourceToList();
            //执行计算
            if (!ClaimMoney(list, _normalBalanceList, _activityBalanceList))
                return;
            this.Close();
            _updateDel(_curPage);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region 认账相关

        /// <summary>
        /// 查询指定行的配置条目
        /// </summary>
        /// <returns></returns>
        private List<Model.ClientCharge> GetClientCharges(int rowidx)
        {
            List<string> conditions = new List<string>();
            string str = GetCellValue(rowidx, "DepartureType");
            if (!string.IsNullOrEmpty(str))
                conditions.Add(" (DepartureType like  '%" + str + "%') ");
            str = GetCellValue(rowidx, "Country");

            if (!string.IsNullOrEmpty(str))
                conditions.Add(" (Country like  '%" + str + "%') ");
            str = GetCellValue(rowidx, "Types");

            if (!string.IsNullOrEmpty(str))
                conditions.Add(" (Types like  '%" + str + "%') ");

            str = GetCellValue(rowidx, "Client");

            if (!string.IsNullOrEmpty(str))
                conditions.Add(" (Client like  '%" + str + "%') ");

            string[] arr = conditions.ToArray();
            string where = string.Join(" and ", arr);
            var list = _bllClientCharge.GetModelList(where);
            return list;
        }

        decimal[] GetVisaNormalAndActivityMoney(Model.Visa visa)
        {
            if (!visa.ActuallyAmount.HasValue || visa.ActuallyAmount == 0)
                return new decimal[] { 0, 0 };
            decimal[] retMoney = new decimal[2];
            if (!string.IsNullOrEmpty(visa.ActivityOrderNo))
            {
                Model.ActivityOrder order = _bllActivityOrder.GetModel(visa.ActivityOrderNo);
                retMoney[1] = order.AmountPaid.Value / order.Books_Sum.Value * visa.Number.Value;
                retMoney[0] = visa.ActuallyAmount.Value - retMoney[1];
            }
            else
            {
                retMoney[0] = visa.ActuallyAmount.HasValue ? visa.ActuallyAmount.Value : 0;
                retMoney[1] = 0;
            }
            return retMoney;
        }

        private bool ClaimMoney(List<Model.Visa> visaList, List<Model.CustomerBalance> normalBalanceList,
            List<Model.CustomerBalance> activityBalanceList)
        {

            //同一个客户在进来就限制了
            decimal totalNormalMoney = 0;
            decimal totalActivityMoney = 0;
            Dictionary<Guid, decimal[]> visaActivityMoney = new Dictionary<Guid, decimal[]>();
            foreach (Model.Visa visa in visaList)
            {
                if (!visa.ActuallyAmount.HasValue || visa.ActuallyAmount.Value == 0)
                {
                    MessageBoxEx.Show("还有团号未设置收款金额!!!");
                    return false;
                }

                decimal[] visaMoney = GetVisaNormalAndActivityMoney(visa);
                visaActivityMoney.Add(visa.Visa_id, visaMoney);
                totalNormalMoney += visaMoney[0];
                totalActivityMoney += visaMoney[1];
            }

            if (totalNormalMoney > _clientNormalBalance)
            {
                MessageBoxEx.Show("常规余额不足!!!");
                return false;
            }

            if (totalActivityMoney > _clientActivityBalance)
            {
                MessageBoxEx.Show("活动订单余额不足!!!");
                return false;
            }


            List<Model.CustomerBalance> newBalances = new List<Model.CustomerBalance>();
            List<Model.ClaimMoney> newClaims = new List<Model.ClaimMoney>();


            //选择是手动还是自动认账
            FrmAutoOrManual frmAutoOrManual = new FrmAutoOrManual();
            if (frmAutoOrManual.ShowDialog() == DialogResult.Cancel)
                return false;

            if (frmAutoOrManual.RetValue == FrmAutoOrManual.ClaimType.Type02_Manual) //手动
            {
                FrmCustomerBalance frmBalance = new FrmCustomerBalance(UtilsBll.getClientNameNoHR(_clientName),
                    totalNormalMoney, activityName: "");
                if (frmBalance.ShowDialog() == DialogResult.Cancel)
                    return false;
                var guid = frmBalance.RetBalanceId;
                var model = _bllBalance.GetModel(guid);
                ClaimNormalMoneyManual(visaList, model, visaActivityMoney, newBalances, newClaims); //
                if (totalActivityMoney > 0)
                {
                    //TODO:认领活动金额

                }
            }
            else
            {
                List<Model.Visa> visaCopyed1 = new List<Model.Visa>();
                foreach (var visa in visaList)
                    visaCopyed1.Add(visa.ToObjectCopy());
                List<Model.Visa> visaCopyed2 = new List<Model.Visa>();
                foreach (var visa in visaList)
                    visaCopyed2.Add(visa.ToObjectCopy());
                ClaimNormalMoneyAuto(visaCopyed1, normalBalanceList, visaActivityMoney, newBalances, newClaims);
                if (totalActivityMoney > 0)
                    ClaimActivityMoneyAuto(visaCopyed2, activityBalanceList, visaActivityMoney, newBalances, newClaims);
            }








            //执行所有的更新
            UpdateActivityOrders(); //更新活动订单

            int sucClaim = 0, sucVisa = 0, sucBalance = 0;
            for (int i = 0; i < newClaims.Count; ++i)
                sucClaim += _bllClaimMoney.Add(newClaims[i]) == Guid.Empty ? 1 : 0;

            for (int i = 0; i < newBalances.Count; i++)
                sucBalance += _bllBalance.Update(newBalances[i]) ? 1 : 0;

            for (int i = 0; i < visaList.Count; i++)
            {
                visaList[i].ClaimedFlag = "是";
                //实收和收款和活动单号是在model里面自己就带了的,
                sucVisa += _bllVisa.Update(visaList[i]) ? 1 : 0;
            }

            //更新活动订单的剩余数量
            foreach (var pair in _curActivityOrderCnt)
            {
                var activityOrderModel = _bllActivityOrder.GetModel(pair.Key);
                activityOrderModel.BalanceBooks -= pair.Value;
                _bllActivityOrder.Update(activityOrderModel);
            }
            return true;
        }

        private void ClaimActivityMoneyAuto(List<Model.Visa> visaList, List<Model.CustomerBalance> activityBalanceList,
            Dictionary<Guid, decimal[]> visaActivityMoney, List<Model.CustomerBalance> newBalances,
            List<Model.ClaimMoney> newClaims)
        {
            while (visaList.Count > 0)
            {
                var visa = visaList[0];
                var balance = activityBalanceList[0];
                Model.ClaimMoney claimMoney = new Model.ClaimMoney(); //每次都会生成一条新的claimMoney
                decimal activityPay = visaActivityMoney[visa.Visa_id][1];
                if (activityPay == 0)
                {
                    visaList.RemoveAt(0);
                    continue;
                }
                if (balance.BalanceAmount == activityPay)
                {
                    claimMoney.Amount = activityPay;
                    visaList.RemoveAt(0);
                    activityBalanceList.RemoveAt(0);
                    balance.BalanceAmount -= activityPay;
                    newBalances.Add(balance);
                }
                else if (activityPay < balance.BalanceAmount)
                {
                    claimMoney.Amount = activityPay;
                    visaList.RemoveAt(0);
                    balance.BalanceAmount -= activityPay;
                    //后者不移出
                }
                else //actuallyPay > activityBalanceList[0].Amount
                {
                    claimMoney.Amount = balance.BalanceAmount;
                    visaActivityMoney[visa.Visa_id][1] -= balance.BalanceAmount;
                    balance.BalanceAmount = 0;
                    newBalances.Add(balance);
                    activityBalanceList.RemoveAt(0);
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
                claimMoney.ActivityOrderNo = visa.ActivityOrderNo;

                if (_visaidOrderDict.ContainsKey(visa.Visa_id.ToString()))
                    claimMoney.ActivityOrderNo = _visaidOrderDict[visa.Visa_id.ToString()];

                if (UtilsBll.getClientNameNoHR(_clientName) != UtilsBll.getClientNameNoHR(visa.client))
                    claimMoney.Guests = $"{_clientName} 帮 {visa.client} 认领 {claimMoney.Amount} 元.";

                newClaims.Add(claimMoney);
            }

            //完了过后，balance如果没用完的话，需要把第一条加进来更新余额
            if (activityBalanceList.Count > 0)
                newBalances.Add(activityBalanceList[0]); //这里倒不用判断，反正始终更新一下应该是不会出错的
        }


        private void ClaimNormalMoneyAuto(List<Model.Visa> visaList, List<Model.CustomerBalance> normalBalanceList,
            Dictionary<Guid, decimal[]> visaActivityMoney, List<Model.CustomerBalance> newBalances,
            List<Model.ClaimMoney> newClaims)
        {
            while (visaList.Count > 0)
            {
                var visa = visaList[0];
                var balance = normalBalanceList[0];
                Model.ClaimMoney claimMoney = new Model.ClaimMoney(); //每次都会生成一条新的claimMoney
                decimal actuallyPay = visaActivityMoney[visa.Visa_id][0];
                if (balance.BalanceAmount == actuallyPay)
                {
                    claimMoney.Amount = actuallyPay;
                    visaList.RemoveAt(0);
                    normalBalanceList.RemoveAt(0);
                    balance.BalanceAmount -= actuallyPay;
                    newBalances.Add(balance);
                }
                else if (actuallyPay < balance.BalanceAmount)
                {
                    claimMoney.Amount = actuallyPay;
                    visaList.RemoveAt(0);
                    balance.BalanceAmount -= actuallyPay;
                    //后者不移出
                }
                else //actuallyPay > normalBalanceList[0].Amount
                {
                    claimMoney.Amount = balance.BalanceAmount;
                    visaActivityMoney[visa.Visa_id][0] -= balance.BalanceAmount;
                    balance.BalanceAmount = 0;
                    newBalances.Add(balance);
                    normalBalanceList.RemoveAt(0);
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
                claimMoney.ActivityOrderNo = visa.ActivityOrderNo;

                if (UtilsBll.getClientNameNoHR(_clientName) != UtilsBll.getClientNameNoHR(visa.client))
                    claimMoney.Guests = $"{_clientName} 帮 {visa.client} 认领 {claimMoney.Amount} 元.";

                newClaims.Add(claimMoney);
            }

            //完了过后，balance如果没用完的话，需要把第一条加进来更新余额
            if (normalBalanceList.Count > 0)
                newBalances.Add(normalBalanceList[0]); //这里倒不用判断，反正始终更新一下应该是不会出错的

        }

        private void ClaimNormalMoneyManual(List<Model.Visa> visaList, Model.CustomerBalance balance,
            Dictionary<Guid, decimal[]> visaActivityMoney, List<Model.CustomerBalance> newBalances,
            List<Model.ClaimMoney> newClaims)
        {
            decimal total = 0;
            foreach (var visa in visaList)
            {
                Model.ClaimMoney claimMoney = new Model.ClaimMoney(); //每次都会生成一条新的claimMoney
                decimal actuallyPay = visaActivityMoney[visa.Visa_id][0];

                claimMoney.Amount = actuallyPay;
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
                claimMoney.ActivityOrderNo = visa.ActivityOrderNo;

                if (UtilsBll.getClientNameNoHR(_clientName) != UtilsBll.getClientNameNoHR(visa.client))
                    claimMoney.Guests = $"{_clientName} 帮 {visa.client} 认领 {claimMoney.Amount} 元.";

                newClaims.Add(claimMoney);
                total += actuallyPay;
            }
                
            

            balance.BalanceAmount -= total;
            newBalances.Add(balance);
        }


        #endregion

        #region 右键菜单响应

        private void 签证认账ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("是否对选中团号进行认账?", "提醒", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            var list = GetSelectedModelList();

            if (!checkGreaterThanCost(list))
            {
                if (MessageBoxEx.Show("选中项中有收款小于成本的，是否继续?", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;
            }

            //执行计算
            if (!ClaimMoney(list, _normalBalanceList, _activityBalanceList))
                return;
            this.Close();
            _updateDel(_curPage);
        }

        private void 自动更新实收ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = GetSelectedModelList();
            foreach (var visa in list)
            {
                visa.ActuallyAmount = visa.Price * (visa.Number ?? 1);
            }
            UpdateDgvList();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var list = GetSelectedModelList();
            if (list.Count < 1)
                return;

            int selPeopleCnt = 0;
            HashSet<string> custNameSet = new HashSet<string>();
            foreach (var visa in list)
            {
                selPeopleCnt += visa.Number ?? 0;
                custNameSet.Add(UtilsBll.getClientNameNoHR(visa.client));
            }

            if (custNameSet.Count > 1)
            {
                MessageBoxEx.Show("不同客户不能同时选择!");
                return;
            }

            string custName = UtilsBll.getClientNameNoHR(list[0].client);


            FrmActivityOrder frm = new FrmActivityOrder(custName, selPeopleCnt, _curActivityOrderCnt);
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;

            //变更订单的先扣除原来的计数器
            foreach (var visa in list)
            {
                if (_visaidOrderDict.ContainsKey(visa.Visa_id.ToString()))
                    _curActivityOrderCnt[_visaidOrderDict[visa.Visa_id.ToString()]] -= visa.Number.Value;
            }

            if (!_curActivityOrderCnt.ContainsKey(frm.RetOrderNo))
                _curActivityOrderCnt.Add(frm.RetOrderNo, selPeopleCnt); //记录下来,后面带进去，好防止出现多次选择出错
            else
                _curActivityOrderCnt[frm.RetOrderNo] += selPeopleCnt;

            foreach (var visa in list)
            {
                if (!_visaidOrderDict.ContainsKey(visa.Visa_id.ToString()))
                    _visaidOrderDict.Add(visa.Visa_id.ToString(), frm.RetOrderNo);
                else
                    _visaidOrderDict[visa.Visa_id.ToString()] = frm.RetOrderNo;

                //visa设置活动订单号
                visa.ActivityOrderNo = frm.RetOrderNo;
            }

            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                dataGridView1.SelectedRows[i].Cells["Price"].Value = frm.RetActivityPrice;
        }
        #endregion
        private bool checkGreaterThanCost(List<Model.Visa> list)
        {
            BLL.QZApplication qzApplication = new QZApplication();
            foreach (var visa in list)
            {
                var qzappList = qzApplication.GetModelList($" visa_id = '{visa.Visa_id}'");
                if (qzappList.Count > 0) //TODO:对应关系???,多条or?
                {
                    if (qzappList[0].Price * qzappList[0].Number > visa.ActuallyAmount)
                        return false;
                }
            }
            return true;
        }

        private void UpdateActivityOrders()
        {
            //余额是一定够的，单用户情况下，(在选择活动订单的界面就限制了数量)

            //更新活动订单的剩余数量
            //根据原有的，看有没有移除掉的
            foreach (var item in _origActivityOrderCnt)
            {
                var model = _bllActivityOrder.GetModel(item.Key);
                //原来有，现在没有   或数量不一致
                if (!_curActivityOrderCnt.ContainsKey(item.Key))
                    model.BalanceBooks += item.Value; //原来的补回去
                else if (_curActivityOrderCnt[item.Key] > item.Value)
                    model.BalanceBooks -= _curActivityOrderCnt[item.Key] - item.Value;
                else if (_curActivityOrderCnt[item.Key] < item.Value)
                    model.BalanceBooks += _curActivityOrderCnt[item.Key] - item.Value;
            }

            //原来没有的，现在有
            foreach (var item in _curActivityOrderCnt)
            {
                if (!_origActivityOrderCnt.ContainsKey(item.Key))
                {
                    var model = _bllActivityOrder.GetModel(item.Key);
                    model.BalanceBooks -= item.Value; //现在的剪掉
                    _bllActivityOrder.Update(model);
                }
            }
        }

        //TODO:更换客户被取消了
        private void lbClientBalance_DoubleClick(object sender, EventArgs e)
        {
            FrmSelectClient frm = new FrmSelectClient();
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;
            _clientName = frm.RetClient;
            UpdateClientBalanceInfo();
        }
    }

}
