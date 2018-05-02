using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.Common;
using TravelAgency.Common.PictureHandler;

namespace TravelAgency.OrdersManagement
{
    public partial class FrmSetOperInfo : Form
    {
        private readonly BLL.Orders _bllOrders = new BLL.Orders();
        private readonly BLL.OrderExcel _bllOrderExcel = new BLL.OrderExcel();
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托
        private readonly int _curPage; //主界面更新数据库需要一个当前页
        private readonly bool _is4Modify = false;
        private readonly TravelAgency.Model.Orders _model = null;

        public FrmSetOperInfo(Action<int> updateDel, int curPage, bool is4Modify = false, TravelAgency.Model.Orders model = null)
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


            if (_is4Modify)
            {
                txtJpOrderNo.Text = _model.JpOrderNo;
                txtOrderWay.Text = _model.OrderWay;
                txtOperOrderTime.Text = _model.OperOrderTime.ToString();
                txtJpConfirmTime.Text = _model.JpConfirmTime.ToString();
                txtReplyWaitorConfirmTime.Text = _model.ReplyWaitorConfirmTime.ToString();
                txtReplyResult.Text = _model.ReplyResult;
                txtSettlePrice.Text = DecimalHandler.DecimalToString(_model.SettlePrice);
                txtExchangeRate.Text = DecimalHandler.DecimalToString(_model.ExchangeRate);
                txtOperRemark.Text = _model.OperRemark;
                this.Text = "修改订单操作信息";
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
                    _model.JpOrderNo = CtrlParser.Parse2String(txtJpOrderNo);
                    _model.OrderWay = CtrlParser.Parse2String(txtOrderWay);
                    _model.OperOrderTime = CtrlParser.Parse2Datetime(txtOperOrderTime);
                    _model.JpConfirmTime = CtrlParser.Parse2Datetime(txtJpConfirmTime);
                    _model.ReplyWaitorConfirmTime = CtrlParser.Parse2Datetime(txtReplyWaitorConfirmTime);
                    _model.ReplyResult = CtrlParser.Parse2String(txtReplyResult);
                    _model.SettlePrice = CtrlParser.Parse2Int(txtSettlePrice);
                    _model.ExchangeRate = CtrlParser.Parse2Decimal(txtExchangeRate);
                    _model.OperRemark = CtrlParser.Parse2String(txtOperRemark);
                    _model.OperName = GlobalUtils.LoginUser.UserName;

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
                catch (Exception )
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
