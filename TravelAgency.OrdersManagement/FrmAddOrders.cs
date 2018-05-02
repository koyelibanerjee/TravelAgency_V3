﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.Common;
using TravelAgency.Common.PictureHandler;

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

            if (GlobalUtils.LoginUserLevel == RigthLevel.Operator) //操作不能修改基本订单信息和客人信息
            {
                btnOK.Enabled = false;
            }

            if (GlobalUtils.LoginUserLevel == RigthLevel.Waitor) //操作不能查看操作的信息
            {
                btnOperInfo.Enabled = false;
            }

            if (_is4Modify)
            {
                //把选中的加载到这里面
                txtOrderNo.Text = _model.OrderNo;

                txtPaymentPlatform.Text = Common.Enums.OrderInfo_PaymentPlatform.KeyToValue(_model.PaymentPlatform);
                txtGroupNo.Text = _model.GroupNo;
                txtProductName.Text = _model.ProductName;
                txtProductId.Text = _model.ProductId.ToString();
                txtProductType.Text = _model.ProductType;
                txtPurchaseNum.Text = DecimalHandler.DecimalToString(_model.PurchaseNum);
                txtOrderAmount.Text = DecimalHandler.DecimalToString(_model.OrderAmount);
                txtGuestOrderTime.Text = _model.GuestOrderTime.ToString();
                txtWaitorOrderTime.Text = _model.WaitorOrderTime.ToString();
                txtWaitorConfirmTime.Text = _model.WaitorConfirmTime.ToString();
                txtReallyPay.Text = _model.ReallyPay.ToString();
                txtPlatformActivity.Text = _model.PlatformActivity;
                txtReplyResult.Text = _model.ReplyResult;
                this.Text = "修改订单信息";
            }
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
            string tablename = "Orders";

            txtReplyResult.DropDownStyle = ComboBoxStyle.DropDown;
            txtPaymentPlatform.DropDownStyle = ComboBoxStyle.DropDownList;


            var list = Common.Enums.OrderInfo_PaymentPlatform.valueKeyMap.Keys;
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
                    _model.PaymentPlatform = Common.Enums.OrderInfo_PaymentPlatform.ValueToKey(txtPaymentPlatform.Text);
                    _model.GroupNo = CtrlParser.Parse2String(txtGroupNo);
                    _model.ProductName = CtrlParser.Parse2String(txtProductName);
                    _model.ProductId = CtrlParser.Parse2Int(txtProductId);
                    _model.ProductType = CtrlParser.Parse2String(txtProductType);
                    _model.PurchaseNum = CtrlParser.Parse2Int(txtPurchaseNum);
                    _model.OrderAmount = CtrlParser.Parse2Decimal(txtOrderAmount);
                    _model.GuestOrderTime = CtrlParser.Parse2Datetime(txtGuestOrderTime);
                    _model.WaitorOrderTime = CtrlParser.Parse2Datetime(txtWaitorOrderTime);
                    _model.WaitorConfirmTime = CtrlParser.Parse2Datetime(txtWaitorConfirmTime);
                    _model.ReallyPay = CtrlParser.Parse2Decimal(txtReallyPay);
                    _model.PlatformActivity = CtrlParser.Parse2String(txtPlatformActivity);
                    _model.ReplyResult = CtrlParser.Parse2String(txtReplyResult);


                    //下面的字段暂时不进行修改
                    //_model.EntryTime = DateTime.Now;
                    //_model.SerialNo = SerialNoGenerator.GetSerialNo(SerialNoGenerator.Type.Type03Receipt);
                    //_model.OperatorId = GlobalUtils.LoginUser.Id;
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
                    model.PaymentPlatform = Common.Enums.OrderInfo_PaymentPlatform.ValueToKey(txtPaymentPlatform.Text);
                    model.GroupNo = CtrlParser.Parse2String(txtGroupNo);
                    model.ProductName = CtrlParser.Parse2String(txtProductName);
                    model.ProductId = CtrlParser.Parse2Int(txtProductId);
                    model.ProductType = CtrlParser.Parse2String(txtProductType);
                    model.PurchaseNum = CtrlParser.Parse2Int(txtPurchaseNum);
                    model.OrderAmount = CtrlParser.Parse2Decimal(txtOrderAmount);
                    model.GuestOrderTime = CtrlParser.Parse2Datetime(txtGuestOrderTime);
                    model.WaitorOrderTime = CtrlParser.Parse2Datetime(txtWaitorOrderTime);
                    model.WaitorConfirmTime = CtrlParser.Parse2Datetime(txtWaitorConfirmTime);
                    model.ReallyPay = CtrlParser.Parse2Decimal(txtReallyPay);
                    model.PlatformActivity = CtrlParser.Parse2String(txtPlatformActivity);
                    model.ReplyResult = CtrlParser.Parse2String(txtReplyResult);

                    if (_bllOrders.Add(model) <= 0)
                    {
                        MessageBoxEx.Show("添加失败，请稍后重试!");
                        return;
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

            FrmSetGuestInfo frm = new FrmSetGuestInfo(_updateDel, _curPage, true, _model);
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
    }
}
