using System;
using System.Diagnostics;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.BLL;
using TravelAgency.Common;
using TravelAgency.Common.PictureHandler;

namespace TravelAgency.OrdersManagement
{
    public partial class FrmAddMessage : Form
    {
        private readonly BLL.Message _bllMessage = new BLL.Message();
        private readonly BLL.OrderExcel _bllOrderExcel = new BLL.OrderExcel();
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托
        private readonly int _curPage; //主界面更新数据库需要一个当前页
        private readonly bool _is4Modify = false;
        private readonly TravelAgency.Model.Message _model = null;

        public FrmAddMessage(Action<int> updateDel, int curPage, bool is4Modify = false, TravelAgency.Model.Message model = null)
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



        private void FrmAddMessage_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            InitComboBoxs();


            if (_is4Modify)
            {
                //把选中的加载到这里面
                txtOrderNo.Text = _model.OrderNo;
                txtMsgContent.Text = _model.MsgContent;
                txtMsgType.Text = _model.MsgType;
                txtMsgState.Text = _model.MsgState;
                txtToUser.Text = _model.ToUser;

                if (_model.ToUser != GlobalUtils.LoginUser.UserName) //只能自己接收的信息才能修改状态
                {
                    txtMsgState.Enabled = false;
                }


                //_model.FromUser = GlobalUtils.LoginUser.UserName;
                //_model.EntryTime = DateTime.Now;
                //_model.IsUrgent
                //_model.ReplyId
                this.Text = "修改消息";
            }
            else
            {
                txtMsgState.Text = "未读";
                txtMsgState.Enabled = false;
            }
        }

        #region 窗体初始化
        private void InitCtrlsByMessageModel()
        {
            //txtCorporation.Text = _MessageModel.Corporation;
            //txtProject.Text = _MessageModel.Project;
            //txtSupplier.Text = _MessageModel.Supplier;

        }

        private void InitComboBoxs()
        {
            //string tablename = "Message";

            txtMsgState.DropDownStyle = ComboBoxStyle.DropDownList;
            txtToUser.DropDownStyle = ComboBoxStyle.DropDownList;
            txtMsgType.DropDownStyle = ComboBoxStyle.DropDownList;

            txtMsgState.Items.Add("未读");
            txtMsgState.Items.Add("已读");
            txtMsgState.SelectedIndex = 0;


            txtMsgType.Items.Add("普通");
            txtMsgType.Items.Add("退款申请");
            txtMsgType.SelectedIndex = 0;

            var list = CommonBll.GetFieldList("AuthUser", "UserName");
            if (list != null)
                foreach (var item in list)
                    txtToUser.Items.Add(item);
            txtToUser.SelectedIndex = 0;

            //var list = Common.Enums.Message_OrderType.valueKeyMap.Keys;
            //if (list != null)
            //    foreach (var item in list)
            //        txtToUser.Items.Add(item);

            //list = Common.Enums.Message_MessageState.valueKeyMap.Keys;
            //if (list != null)
            //    foreach (var item in list)
            //        txtMsgState.Items.Add(item);

            //list = Common.Enums.Message_PaymentPlatform.valueKeyMap.Keys;
            //if (list != null)
            //    foreach (var item in list)
            //        txtMsgType.Items.Add(item);

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
                    _model.MsgContent = CtrlParser.Parse2String(txtMsgContent);
                    _model.MsgType = CtrlParser.Parse2String(txtMsgType);
                    _model.MsgState = CtrlParser.Parse2String(txtMsgState);
                    _model.ToUser = CtrlParser.Parse2String(txtToUser);
                    //_model.FromUser = GlobalUtils.LoginUser.UserName;
                    //_model.EntryTime = DateTime.Now;
                    //_model.IsUrgent
                    //_model.ReplyId

                    //下面的字段暂时不进行修改
                    //_model.EntryTime = DateTime.Now;
                    //_model.SerialNo = SerialNoGenerator.GetSerialNo(SerialNoGenerator.Type.Type03Receipt);
                    //_model.OperatorId = GlobalUtils.LoginUser.Id;
                    if (!_bllMessage.Update(_model))
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
                TravelAgency.Model.Message model = new TravelAgency.Model.Message();
                try
                {
                    //_model.Corporation = txtCorporation.Text;
                    if (string.IsNullOrEmpty(txtOrderNo.Text))
                    {
                        MessageBoxEx.Show("必须填写订单编号!");
                        return;
                    }

                    model.OrderNo = CtrlParser.Parse2String(txtOrderNo);
                    model.MsgContent = CtrlParser.Parse2String(txtMsgContent);
                    model.MsgType = CtrlParser.Parse2String(txtMsgType);
                    model.MsgState = CtrlParser.Parse2String(txtMsgState);
                    model.ToUser = CtrlParser.Parse2String(txtToUser);
                    model.FromUser = GlobalUtils.LoginUser.UserName;
                    model.EntryTime = DateTime.Now;

                    if (_bllMessage.Add(model) <= 0)
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
