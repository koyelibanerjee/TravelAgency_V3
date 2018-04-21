using System;
using System.Diagnostics;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.Common;
using TravelAgency.Common.PictureHandler;

namespace TravelAgency.OrdersManagement
{
    public partial class FrmAddGuest : Form
    {
        private readonly BLL.Orders _bllOrders = new BLL.Orders();
        private readonly BLL.OrderExcel _bllOrderExcel = new BLL.OrderExcel();
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托
        private readonly int _curPage; //主界面更新数据库需要一个当前页
        private readonly bool _is4Modify = false;
        private readonly TravelAgency.Model.Orders _model = null;

        public FrmAddGuest(Action<int> updateDel, int curPage, bool is4Modify = false, TravelAgency.Model.Orders model = null)
        {
            this.StartPosition = FormStartPosition.CenterParent;
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


            if (_is4Modify)
            {
                //基本信息
                txtGuestId.Text = _model.GuestId.ToString();
                txtGuestName.Text = _model.GuestName;
                txtGuestNamePinYin.Text = _model.GuestNamePinYin;
                txtGuestSex.Text = _model.GuestSex;
                txtGuestBirthday.Text = _model.GuestBirthday.ToString();
                txtGuestUseTime.Text = _model.GuestUseTime.ToString();
                txtGuestPhone.Text = _model.GuestPhone;
                txtGuestWeiChat.Text = _model.GuestWeiChat;
                txtGuestEMail.Text = _model.GuestEMail;

                //补充信息
                txtReserveTime.Text = _model.ReserveTime.ToString();
                txtDiningTime.Text = _model.DiningTime.ToString();
                txtDiningShop.Text = _model.DiningShop;
                txtCheckMoneyTime.Text = _model.CheckMoneyTime.ToString();
                txtRefundAmout.Text = DecimalHandler.DecimalToString(_model.RefundAmout);
                txtGuestRefundApplyTime.Text = _model.GuestRefundApplyTime.ToString();
                txtGuestPassportNo.Text = _model.GuestPassportNo;
                txtGuestLastNightHotel.Text = _model.GuestLastNightHotel;
                txtGuestCountry.Text = _model.GuestCountry;
                txtIsPraise.Text = _model.IsPraise;
                txtRefundReason.Text = _model.RefundReason;
                txtWaitorRemark.Text = _model.WaitorRemark;
                this.Text = "修改订单客户信息";
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
            //string tablename = "Orders";

            //txtOrdersState.DropDownStyle = ComboBoxStyle.DropDownList;
            //txtReplyResult.DropDownStyle = ComboBoxStyle.DropDownList;
            //txtPaymentPlatform.DropDownStyle = ComboBoxStyle.DropDownList;

            //var list = Common.Enums.Orders_OrderType.valueKeyMap.Keys;
            //if (list != null)
            //    foreach (var item in list)
            //        txtReplyResult.Items.Add(item);

            //list = Common.Enums.Orders_OrdersState.valueKeyMap.Keys;
            //if (list != null)
            //    foreach (var item in list)
            //        txtOrdersState.Items.Add(item);

            //list = Common.Enums.Orders_PaymentPlatform.valueKeyMap.Keys;
            //if (list != null)
            //    foreach (var item in list)
            //        txtPaymentPlatform.Items.Add(item);

        }
        #endregion



        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_is4Modify)
            {
                try
                {
                    _model.GuestId = CtrlParser.Parse2Int(txtGuestId);
                    _model.GuestName = CtrlParser.Parse2String(txtGuestName);
                    _model.GuestNamePinYin = CtrlParser.Parse2String(txtGuestNamePinYin);
                    _model.GuestSex = CtrlParser.Parse2String(txtGuestSex);
                    _model.GuestBirthday = CtrlParser.Parse2Datetime(txtGuestBirthday);
                    _model.GuestUseTime = CtrlParser.Parse2Int(txtGuestUseTime);
                    _model.GuestPhone = CtrlParser.Parse2String(txtGuestPhone);
                    _model.GuestWeiChat = CtrlParser.Parse2String(txtGuestWeiChat);
                    _model.GuestEMail = CtrlParser.Parse2String(txtGuestEMail);


                    _model.ReserveTime = CtrlParser.Parse2Int(txtReserveTime);
                    _model.DiningTime = CtrlParser.Parse2Datetime(txtDiningTime);
                    _model.DiningShop = CtrlParser.Parse2String(txtDiningShop);
                    _model.CheckMoneyTime = CtrlParser.Parse2Datetime(txtCheckMoneyTime);
                    _model.RefundAmout = CtrlParser.Parse2Decimal(txtRefundAmout);
                    _model.GuestRefundApplyTime = CtrlParser.Parse2Datetime(txtGuestRefundApplyTime);
                    _model.GuestPassportNo = CtrlParser.Parse2String(txtGuestPassportNo);
                    _model.GuestLastNightHotel = CtrlParser.Parse2String(txtGuestLastNightHotel);
                    _model.GuestCountry = CtrlParser.Parse2String(txtGuestCountry);
                    _model.IsPraise = CtrlParser.Parse2String(txtIsPraise);
                    _model.RefundReason = CtrlParser.Parse2String(txtRefundReason);
                    _model.WaitorRemark = CtrlParser.Parse2String(txtWaitorRemark);



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
                catch (Exception ex)
                {
                    MessageBoxEx.Show("请检查输入是否有误，价格为0请填入0!");
                    //throw;
                }
            }
            else
            {
                return;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


    }
}
