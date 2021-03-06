﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using NPOI.HSSF.Record.AutoFilter;
using TravelAgency.Common;
using TravelAgency.Model;
using TravelAgency.Model.Enums;

namespace TravelAgency.OrdersManagement
{
    public partial class FrmAddOrders : Form
    {
        private readonly BLL.Orders _bllOrders = new BLL.Orders();
        private readonly BLL.OrderExcel _bllOrderExcel = new BLL.OrderExcel();
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托
        private readonly int _curPage; //主界面更新数据库需要一个当前页
        private readonly bool _is4Modify = false;
        private readonly TravelAgency.Model.Orders _model = null;
        private readonly BLL.OrdersLogs _bllLoger = new BLL.OrdersLogs();
        private readonly BLL.OrderGuest _bllGuest = new BLL.OrderGuest();

        public FrmAddOrders(Action<int> updateDel, int curPage, bool is4Modify = false, TravelAgency.Model.Orders model = null)
        {
            if (this.Modal)
                this.StartPosition = FormStartPosition.CenterParent;
            else
                this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            _updateDel = updateDel;
            _curPage = curPage;
            _is4Modify = is4Modify;
            _model = model;
        }



        private void FrmAddOrders_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            InitComboBoxs();

            StyleControler.SetDgvStyle(dataGridView1);
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            dataGridView1.CellMouseUp += DataGridView1_CellMouseUp;
            dataGridView1.RowsAdded += DataGridView1_RowsAdded;
            dataGridView1.KeyDown += DataGridView1_KeyDown;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.ReadOnly = false;

            txtWaitorConfirmTime.Enabled = false; //客服确认时间默认禁用

            if (GlobalUtils.LoginUserLevel == RigthLevel.Operator) //操作不能修改基本订单信息和客人信息
            {
                btnOK.Enabled = false;
            }

            if (GlobalUtils.LoginUserLevel == RigthLevel.Waitor) //客服不能查看操作的信息
            {
                btnOperInfo.Enabled = false;
                txtReplyResult.Enabled = false;
            }

            txtOperRemark.ReadOnly = true;

            if (_is4Modify)
            {
                //把选中的加载到这里面
                txtOrderNo.Text = _model.OrderNo;

                txtPaymentPlatform.Text = BLL.Enums_OrderInfo_PaymentPlatform.KeyToValue(_model.PaymentPlatform.Value);
                txtGroupNo.Text = _model.GroupNo;
                txtProductName.Text = _model.ProductName;
                txtProductId.Text = _model.ProductId.ToString();
                txtProductType.Text = _model.ProductType;
                txtPurchaseNum.Text = DecimalHandler.DecimalToString(_model.PurchaseNum);
                txtOrderAmount.Text = DecimalHandler.DecimalToString(_model.OrderAmount);
                txtGuestOrderTime.Text = _model.GuestOrderTime.ToString();
                //txtWaitorOrderTime.Text = _model.WaitorOrderTime.ToString(); //客服下单时间
                txtWaitorConfirmTime.Text = _model.WaitorConfirmTime.ToString();
                txtReallyPay.Text = _model.ReallyPay.ToString();
                txtPlatformActivity.Text = _model.PlatformActivity;
                txtReplyResult.Text = _model.ReplyResult;
                txtComboName.Text = _model.ComboName;

                txtOperRemark.Text = _model.OperRemark;
                txtWaitorRemark.Text = _model.WaitorRemark;
                txtDepartureDate.Text = _model.DepartureDate.ToString();
                txtGuestUseTime.Text = _model.GuestUseTime;

                if (GlobalUtils.LoginUserLevel == RigthLevel.Waitor &&
                                _model.ReplyResult != "未处理")
                {
                    btnOK.Enabled = false;
                }

                this.Text = "修改订单信息";
                InitDgvData();
            }



        }

        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridView1.CurrentCell.Value != null && e.Control && e.KeyCode == Keys.C)
            {
                复制选中单元格ToolStripMenuItem_Click(null, null);
            }
        }

        protected internal class GuestCnt
        {
            public string name;
            public int cnt;
        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //int digit = GlobalUtils.DecimalDigits;
            List<GuestCnt> guestTypeCnt = new List<GuestCnt>();
            decimal totalPrice = 0;
            Dictionary<string, int> typeDict = new Dictionary<string, int>();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                row.HeaderCell.Value = (i + 1).ToString();

                if (dataGridView1.Rows[i].Cells["Price"].Value != null)
                {
                    totalPrice += DecimalHandler.Parse(dataGridView1.Rows[i].Cells["Price"].Value.ToString());
                }

                if (dataGridView1.Rows[i].Cells["GuestType"].Value != null)
                {
                    string type = dataGridView1.Rows[i].Cells["GuestType"].Value.ToString();
                    if (!typeDict.ContainsKey(type))
                    {
                        typeDict.Add(type, guestTypeCnt.Count);
                        guestTypeCnt.Add(new GuestCnt { name = type, cnt = 1 });
                    }
                    else
                    {
                        ++guestTypeCnt[typeDict[type]].cnt;
                    }
                }

                for (int j = 0; j != dataGridView1.ColumnCount; ++j)
                {
                    var value = dataGridView1.Rows[i].Cells[j].Value;
                    if (dataGridView1.Rows[i].Cells[j].ValueType == typeof(decimal) && value != null)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = DecimalHandler.DecimalToString((decimal)value);
                    }
                }
            }

            if (guestTypeCnt.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                //sb.Append("")
                int cnt = 0;
                foreach (var guestCnt in guestTypeCnt)
                {
                    cnt += guestCnt.cnt;
                    sb.AppendFormat("{0}:{1}人,", guestCnt.name, guestCnt.cnt);
                }
                string str = sb.ToString();
                str = str.TrimEnd(',');
                str = "共有客人:" + cnt + "人, " + str;
                lbGuestCount.Text = str;
            }
            else
            {
                lbGuestCount.Text = "客人总数:0";
            }

            txtOrderAmount.Text = DecimalHandler.DecimalToString(totalPrice);
            txtReallyPay.Text = DecimalHandler.DecimalToString(totalPrice);
        }

        private void InitDgvData()
        {
            var list = _bllGuest.GetModelList(" OrdersId = " + _model.Id + " ");
            list.Sort((Model.OrderGuest g1, Model.OrderGuest g2) => g1.Position < g2.Position ? -1 : 1);
            if (list.Count != 0)
                dataGridView1.DataSource = list;
        }

        private void DataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    //如果没选中当前活动行则选中这一行
                    if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected == false)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                    }

                    //只有在选中的单元格上
                    if (dataGridView1.SelectedCells.Contains(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]))
                        //弹出操作菜单
                        cmsDgvRb.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        List<Model.OrderGuest> DgvDataSourceToList()
        {
            return dataGridView1.DataSource as List<Model.OrderGuest>;
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) //表头部分
                return;
            var list = DgvDataSourceToList();
            FrmAddOrderGuest frm = new FrmAddOrderGuest(_model, true, list[e.RowIndex]);
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;


            list[e.RowIndex] = frm.RetModel;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
        }

        #region 窗体初始化
        private void InitCtrlsByOrdersModel()
        {
            //txtCorporation.Text = _OrdersModel.Corporation;
            //txtProject.Text = _OrdersModel.Project;
            //txtSupplier.Text = _OrdersModel.Supplier;

        }

        private void InitComboBoxs()
        {
            //string tablename = "Orders";

            txtReplyResult.DropDownStyle = ComboBoxStyle.DropDown;
            txtPaymentPlatform.DropDownStyle = ComboBoxStyle.DropDownList;


            var list = BLL.Enums_OrderInfo_PaymentPlatform.valueKeyMap.Keys;
            if (list != null)
                foreach (var item in list)
                    txtPaymentPlatform.Items.Add(item);

            List<string> strList = new List<string> { "成功", "处理中", "拒绝", "未处理" };
            foreach (var item in strList)
                txtReplyResult.Items.Add(item);
            txtReplyResult.SelectedIndex = 3;
        }
        #endregion



        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_is4Modify)
            {
                try
                {
                    //_model.Corporation = txtCorporation.Text;
                    if (string.IsNullOrEmpty(txtOrderNo.Text))
                    {
                        MessageBoxEx.Show("必须填写订单编号!");
                        return;
                    }

                    _model.OrderNo = CtrlParser.Parse2String(txtOrderNo);
                    _model.WaitorName = GlobalUtils.LoginUser.UserName;
                    _model.PaymentPlatform = BLL.Enums_OrderInfo_PaymentPlatform.ValueToKey(txtPaymentPlatform.Text);
                    _model.GroupNo = CtrlParser.Parse2String(txtGroupNo);
                    _model.ProductName = CtrlParser.Parse2String(txtProductName);
                    _model.ProductId = CtrlParser.Parse2Int(txtProductId);
                    _model.ProductType = CtrlParser.Parse2String(txtProductType);
                    _model.PurchaseNum = CtrlParser.Parse2Int(txtPurchaseNum);
                    _model.OrderAmount = CtrlParser.Parse2Decimal(txtOrderAmount);
                    _model.GuestOrderTime = CtrlParser.Parse2Datetime(txtGuestOrderTime);
                    //_model.WaitorOrderTime = CtrlParser.Parse2Datetime(txtWaitorOrderTime);
                    _model.WaitorConfirmTime = CtrlParser.Parse2Datetime(txtWaitorConfirmTime);
                    _model.ReallyPay = CtrlParser.Parse2Decimal(txtReallyPay);
                    _model.PlatformActivity = CtrlParser.Parse2String(txtPlatformActivity);
                    _model.ReplyResult = CtrlParser.Parse2String(txtReplyResult);
                    _model.ComboName = CtrlParser.Parse2String(txtComboName);

                    _model.WaitorRemark = CtrlParser.Parse2String(txtWaitorRemark);
                    _model.DepartureDate = CtrlParser.Parse2Datetime(txtDepartureDate);
                    _model.GuestUseTime = CtrlParser.Parse2String(txtGuestUseTime);

                    var list1 = DgvDataSourceToList();
                    if (list1 != null && list1.Count > 0
                        && !string.IsNullOrEmpty(list1[0].GuestName) &&
                            !string.IsNullOrEmpty(list1[0].GuestPhone) &&
                            !string.IsNullOrEmpty(list1[0].GuestEMail))
                        _model.GuestInfoTypedIn = true;
                    else
                        _model.GuestInfoTypedIn = false;


                    //下面的字段暂时不进行修改
                    //_model.EntryTime = DateTime.Now;
                    //_model.SerialNo = SerialNoGenerator.GetSerialNo(SerialNoGenerator.Type.Type03Receipt);
                    //_model.OperatorId = GlobalUtils.LoginUser.Id;

                    //先删除原来的客人信息
                    var origList = _bllGuest.GetModelList(" OrdersId = " + _model.Id);
                    if (origList != null && origList.Count > 0)
                        _bllGuest.DeleteList(origList);

                    //添加客人信息
                    var list = DgvDataSourceToList();
                    if (list != null && list.Count > 0)
                    {
                        int i = 0;
                        foreach (var orderGuest in list)
                        {
                            orderGuest.Position = i++;
                        }
                        _bllGuest.AddList(list);

                        if (!string.IsNullOrEmpty(list[0].GuestName) && !string.IsNullOrEmpty(list[0].GuestPhone))
                            _model.GuestInfoTypedIn = true;
                        else
                            _model.GuestInfoTypedIn = false;
                    }
                    if (!_bllOrders.Update(_model))
                    {
                        MessageBoxEx.Show("更新失败，请稍后重试!");
                        return;
                    }
                    MessageBoxEx.Show("更新成功!");
                    _updateDel(_curPage);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBoxEx.Show("请检查输入是否有误，价格为0请填入0!");
                    //throw;
                }
            }
            else
            {
                TravelAgency.Model.Orders model = new TravelAgency.Model.Orders();
                try
                {
                    //_model.Corporation = txtCorporation.Text;
                    if (string.IsNullOrEmpty(txtOrderNo.Text))
                    {
                        MessageBoxEx.Show("必须填写订单编号!");
                        return;
                    }

                    model.OrderNo = CtrlParser.Parse2String(txtOrderNo);
                    model.WaitorName = GlobalUtils.LoginUser.UserName;
                    model.PaymentPlatform =BLL.Enums_OrderInfo_PaymentPlatform.ValueToKey(txtPaymentPlatform.Text);
                    model.GroupNo = CtrlParser.Parse2String(txtGroupNo);
                    model.ProductName = CtrlParser.Parse2String(txtProductName);
                    model.ProductId = CtrlParser.Parse2Int(txtProductId);
                    model.ProductType = CtrlParser.Parse2String(txtProductType);
                    model.PurchaseNum = CtrlParser.Parse2Int(txtPurchaseNum);
                    model.OrderAmount = CtrlParser.Parse2Decimal(txtOrderAmount);
                    model.GuestOrderTime = CtrlParser.Parse2Datetime(txtGuestOrderTime);
                    //model.WaitorOrderTime = CtrlParser.Parse2Datetime(txtWaitorOrderTime);
                    model.WaitorOrderTime = DateTime.Now;
                    model.WaitorConfirmTime = CtrlParser.Parse2Datetime(txtWaitorConfirmTime);
                    model.ReallyPay = CtrlParser.Parse2Decimal(txtReallyPay);
                    model.PlatformActivity = CtrlParser.Parse2String(txtPlatformActivity);
                    model.ReplyResult = CtrlParser.Parse2String(txtReplyResult);
                    model.ComboName = CtrlParser.Parse2String(txtComboName);

                    model.WaitorRemark = CtrlParser.Parse2String(txtWaitorRemark);
                    model.DepartureDate = CtrlParser.Parse2Datetime(txtDepartureDate);
                    model.GuestUseTime = CtrlParser.Parse2String(txtGuestUseTime);

                    var list1 = DgvDataSourceToList();
                    if (list1 != null && list1.Count > 0
                        && !string.IsNullOrEmpty(list1[0].GuestName) &&
                            !string.IsNullOrEmpty(list1[0].GuestPhone) &&
                            !string.IsNullOrEmpty(list1[0].GuestEMail))
                        model.GuestInfoTypedIn = true;
                    else
                        model.GuestInfoTypedIn = false;
                    int id = _bllOrders.Add(model);
                    if (id <= 0)
                    {
                        MessageBoxEx.Show("添加失败，请稍后重试!");
                        return;
                    }
                    model.Id = id;
                    _bllLoger.AddLog(GlobalUtils.LoginUser, OrdersActtype.Value2Key("客服:录入订单"), model);

                    //添加客人信息
                    var list = DgvDataSourceToList();
                    int i = 0;
                    if (list != null && list.Count > 0)
                    {
                        foreach (var orderGuest in list)
                        {
                            orderGuest.OrdersId = id; //新增的时候添加，就直接指定Id
                            orderGuest.Position = i++;
                        }
                        _bllGuest.AddList(list);
                        if (!string.IsNullOrEmpty(list[0].GuestName) && !string.IsNullOrEmpty(list[0].GuestPhone))
                            model.GuestInfoTypedIn = true;
                    }
                    MessageBoxEx.Show("添加成功");
                    _updateDel(_curPage);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBoxEx.Show(ex.Message);
                    MessageBoxEx.Show("请检查输入是否有误!");
                    //throw;
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGuestInfo_Click(object sender, EventArgs e)
        {
            if (_model == null)
            {
                MessageBoxEx.Show("请先添加订单信息后再录入客人信息!!!");
                return;
            }

            FrmSetAdditionalInfo frm = new FrmSetAdditionalInfo(_updateDel, _curPage, true, _model);
            frm.Show();
        }

        private void btnOperInfo_Click(object sender, EventArgs e)
        {
            if (_model == null)
            {
                MessageBoxEx.Show("请先添加订单信息后再录入操作信息!!!");
                return;
            }
            FrmSetOperInfo frm = new FrmSetOperInfo(_updateDel, _curPage, true, _model);
            frm.Show();
        }

        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            //if (_model == null)
            //{
            //    MessageBoxEx.Show("请先添加订单信息后再添加客人信息!!!");
            //    return;
            //}
            FrmAddOrderGuest frm = new FrmAddOrderGuest(_model);
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;


            List<Model.OrderGuest> list = null;
            if (dataGridView1.DataSource == null)
                list = new List<OrderGuest>();
            else
                list = dataGridView1.DataSource as List<Model.OrderGuest>;

            list.Add(frm.RetModel);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count < 1)
                return;
            var list = DgvDataSourceToList();
            for (int i = 0; i < dataGridView1.SelectedCells.Count; ++i)
            {
                list.RemoveAt(dataGridView1.SelectedCells[i].RowIndex);
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
        }

        private void 上移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 1)
            {
                MessageBoxEx.Show("请选择一条记录操作");
                return;
            }
            int selIdx = dataGridView1.SelectedCells[0].RowIndex;
            if (selIdx == 0)
                return;

            var list = DgvDataSourceToList();
            var lvItemTmp = list[selIdx];
            list.Remove(lvItemTmp);
            list.Insert(selIdx - 1, lvItemTmp);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;

            dataGridView1.CurrentCell = dataGridView1.Rows[selIdx - 1].Cells[0];

        }

        private void 下移ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedCells.Count > 1)
            {
                MessageBoxEx.Show("请选择一条记录操作");
                return;
            }
            int selIdx = dataGridView1.SelectedCells[0].RowIndex;
            var list = DgvDataSourceToList();
            if (selIdx == list.Count - 1)
                return;


            var lvItemTmp = list[selIdx];
            list.Remove(lvItemTmp);
            list.Insert(selIdx + 1, lvItemTmp);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;

            dataGridView1.CurrentCell = dataGridView1.Rows[selIdx + 1].Cells[0];

        }

        private void 移到顶部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 1)
            {
                MessageBoxEx.Show("请选择一条记录操作");
                return;
            }
            int selIdx = dataGridView1.SelectedCells[0].RowIndex;
            if (selIdx == 0)
                return;

            var list = DgvDataSourceToList();
            var lvItemTmp = list[selIdx];
            list.Remove(lvItemTmp);
            list.Insert(0, lvItemTmp);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;

            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];


        }

        private void 移到底部ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedCells.Count > 1)
            {
                MessageBoxEx.Show("请选择一条记录操作");
                return;
            }
            int selIdx = dataGridView1.SelectedCells[0].RowIndex;
            var list = DgvDataSourceToList();

            if (selIdx == list.Count - 1)
                return;

            var lvItemTmp = list[selIdx];
            list.Remove(lvItemTmp);
            list.Add(lvItemTmp);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;

            dataGridView1.CurrentCell = dataGridView1.Rows[list.Count - 1].Cells[0];
        }

        private void 复制选中单元格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 1)
            {
                MessageBoxEx.Show("请选择一条记录复制");
                return;
            }
            int selIdx = dataGridView1.SelectedCells[0].RowIndex;
            //string name = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name;
            //if (name == "CountryImage")
            //{
            //    return;
            //}
            //if ((name == "EntryTime" || name == "PredictTime")
            //    && dataGridView1.CurrentCell.Value != null) //归国时间的列,是datetime类型,单独判断
            //{
            //    Clipboard.SetText(DateTimeFormator.DateTimeToString((DateTime)dataGridView1.CurrentCell.Value));
            //    return;
            //}

            if (!string.IsNullOrEmpty((string)dataGridView1.CurrentCell.Value.ToString()))
                Clipboard.SetText(dataGridView1.CurrentCell.Value.ToString());
        }
    }
}
