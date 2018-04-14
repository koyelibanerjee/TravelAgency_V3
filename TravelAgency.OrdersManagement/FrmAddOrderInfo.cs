using System;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.Common;

namespace TravelAgency.OrdersManagement
{
    public partial class FrmAddOrderInfo : Form
    {
        private readonly BLL.OrderInfo _bllOrderInfo = new BLL.OrderInfo();
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托
        private readonly int _curPage; //主界面更新数据库需要一个当前页
        private readonly bool _is4Modify = false;
        private readonly TravelAgency.Model.OrderInfo _model = null;

        public FrmAddOrderInfo(Action<int> updateDel, int curPage, bool is4Modify = false, TravelAgency.Model.OrderInfo model = null)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            _updateDel = updateDel;
            _curPage = curPage;
            _is4Modify = is4Modify;
            _model = model;
        }



        private void FrmAddOrderInfo_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            InitComboBoxs();


            if (_is4Modify)
            {
                //把选中的加载到这里面
                txtOrderNo.Text = _model.OrderNo;
                txtAmount.Text = DecimalHandler.DecimalToString(_model.Amount);
                txtOrderTime.Text = _model.OrderTime.ToString();
                txtExtraData.Text = _model.ExtraData;
                txtProductName.Text = _model.ProductName;
                txtOrderType.Text = Common.Enums.OrderInfo_OrderType.KeyToValue(_model.OrderType);
                txtOrderInfoState.Text = Common.Enums.OrderInfo_OrderInfoState.KeyToValue(_model.OrderInfoState);

                this.Text = "修改订单信息";
            }
        }

        #region 窗体初始化
        private void InitCtrlsByOrderInfoModel()
        {
            //txtCorporation.Text = _OrderInfoModel.Corporation;
            //txtProject.Text = _OrderInfoModel.Project;
            //txtSupplier.Text = _OrderInfoModel.Supplier;

        }

        private void InitComboBoxs()
        {
            //string tablename = "OrderInfo";

            txtOrderInfoState.DropDownStyle = ComboBoxStyle.DropDownList;
            txtOrderType.DropDownStyle = ComboBoxStyle.DropDownList;

            var list = Common.Enums.OrderInfo_OrderType.valueKeyMap.Keys; 
            if (list != null)
                foreach (var item in list)
                    txtOrderType.Items.Add(item);

            list = Common.Enums.OrderInfo_OrderInfoState.valueKeyMap.Keys;
            if (list != null)
                foreach (var item in list)
                    txtOrderInfoState.Items.Add(item);

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

                    _model.OrderNo = txtOrderNo.Text;
                    _model.Amount = DecimalHandler.Parse(txtAmount.Text);
                    _model.OrderTime = DateTime.Parse(txtOrderTime.Text);
                    _model.ExtraData = txtExtraData.Text;
                    _model.ProductName = txtProductName.Text;
                    _model.OrderType = Common.Enums.OrderInfo_OrderType.ValueToKey(txtOrderType.Text);
                    _model.OrderInfoState = Common.Enums.OrderInfo_OrderType.ValueToKey(txtOrderInfoState.Text);


                    //下面的字段暂时不进行修改
                    //_model.EntryTime = DateTime.Now;
                    //_model.SerialNo = SerialNoGenerator.GetSerialNo(SerialNoGenerator.Type.Type03Receipt);
                    //_model.OperatorId = GlobalUtils.LoginUser.Id;
                    if (!_bllOrderInfo.Update(_model))
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
                TravelAgency.Model.OrderInfo model = new TravelAgency.Model.OrderInfo();
                try
                {
                    //_model.Corporation = txtCorporation.Text;
                    if (string.IsNullOrEmpty(txtOrderNo.Text))
                    {
                        MessageBoxEx.Show("必须填写订单编号!");
                        return;
                    }


                    model.OrderNo = txtOrderNo.Text;
                    model.Amount = DecimalHandler.Parse(txtAmount.Text);
                    model.OrderTime = DateTime.Parse(txtOrderTime.Text);
                    model.ExtraData = txtExtraData.Text;
                    model.ProductName = txtProductName.Text;
                    model.OrderType = Common.Enums.OrderInfo_OrderType.ValueToKey(txtOrderType.Text);
                    model.OrderInfoState = Common.Enums.OrderInfo_OrderInfoState.ValueToKey(txtOrderInfoState.Text);
                    model.EntryTime = DateTime.Now;
                    model.OperatorWorkId = GlobalUtils.LoginUser.WorkId;
                    model.OperatorName = GlobalUtils.LoginUser.UserName;

                    if (_bllOrderInfo.Add(model) <= 0)
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


    }
}
