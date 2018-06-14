using System;
using System.Diagnostics;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.Common;
using TravelAgency.Common.PictureHandler;

namespace TravelAgency.OrdersManagement
{
    public partial class FrmSetGuestInfo : Form
    {
        private readonly BLL.Orders _bllOrders = new BLL.Orders();
        private readonly BLL.OrderExcel _bllOrderExcel = new BLL.OrderExcel();
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托
        private readonly int _curPage; //主界面更新数据库需要一个当前页
        private readonly bool _is4Modify = false;
        private readonly TravelAgency.Model.Orders _model = null;

        public FrmSetGuestInfo(Action<int> updateDel, int curPage, bool is4Modify = false, TravelAgency.Model.Orders model = null)
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

            if (_is4Modify)
            {
                //基本信息


                //补充信息
                txtReserveTime.Text = _model.ReserveTime.ToString();
                txtDiningTime.Text = _model.DiningTime.ToString();
                txtDiningShop.Text = _model.DiningShop;
                txtCheckMoneyTime.Text = _model.CheckMoneyTime.ToString();
                txtRefundAmout.Text = DecimalHandler.DecimalToString(_model.RefundAmout);
                txtGuestRefundApplyTime.Text = _model.GuestRefundApplyTime.ToString();

                txtIsPraise.Text = _model.IsPraise;
                txtRefundReason.Text = _model.RefundReason;
                //txtWaitorRemark.Text = _model.WaitorRemark;

                //txtOperRemark.Text = _model.OperRemark;
                //txtOperRemark.ReadOnly = true;

                if (GlobalUtils.LoginUserLevel== RigthLevel.Waitor && 
                    _model.ReplyResult != "未处理")
                {
                    txtOrderNo.Enabled = false;
                    txtReserveTime.Enabled = false;
                    txtDiningTime.Enabled = false;
                    txtDiningShop.Enabled = false;
                    txtIsPraise.Enabled = false;
                    txtCheckMoneyTime.Enabled = false;
                }

                txtOrderNo.Text = _model.OrderNo;
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

            txtIsPraise.DropDownStyle = ComboBoxStyle.DropDown;

            txtIsPraise.Items.Add("是");
            txtIsPraise.Items.Add("否");
        }
        #endregion



        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_is4Modify)
            {
                try
                {

                    //_model.GuestUseTime = CtrlParser.Parse2Datetime(txtGuestUseTime);
                    _model.ReserveTime = CtrlParser.Parse2Datetime(txtReserveTime);
                    _model.DiningTime = CtrlParser.Parse2Datetime(txtDiningTime);
                    _model.DiningShop = CtrlParser.Parse2String(txtDiningShop);
                    _model.CheckMoneyTime = CtrlParser.Parse2Datetime(txtCheckMoneyTime);
                    _model.RefundAmout = CtrlParser.Parse2Decimal(txtRefundAmout);
                    _model.GuestRefundApplyTime = CtrlParser.Parse2Datetime(txtGuestRefundApplyTime);

                    _model.IsPraise = CtrlParser.Parse2String(txtIsPraise);
                    _model.RefundReason = CtrlParser.Parse2String(txtRefundReason);
                    //_model.WaitorRemark = CtrlParser.Parse2String(txtWaitorRemark);

                    //if (!string.IsNullOrEmpty(_model.GuestId) &&
                    //    !string.IsNullOrEmpty(_model.GuestPhone) &&
                    //    !string.IsNullOrEmpty(_model.GuestName))
                    //{
                    //    _model.GuestInfoTypedIn = true;
                    //}
                    //else

                    //TODO:这里怎么判定?
                    _model.GuestInfoTypedIn = false;


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
