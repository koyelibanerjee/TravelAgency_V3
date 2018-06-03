using System;
using System.Diagnostics;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.Common;
using TravelAgency.Common.PictureHandler;
using TravelAgency.Model;

namespace TravelAgency.OrdersManagement
{
    public partial class FrmAddOrderGuest : Form
    {
        private readonly BLL.Orders _bllOrders = new BLL.Orders();
        private readonly BLL.OrderExcel _bllOrderExcel = new BLL.OrderExcel();
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托
        private readonly int _curPage; //主界面更新数据库需要一个当前页
        private readonly bool _is4Modify = false;
        private readonly TravelAgency.Model.Orders _ordersModel = null;
        private readonly TravelAgency.Model.OrderGuest _guestModel = null;
        public TravelAgency.Model.OrderGuest RetModel = null;


        private FrmAddOrderGuest()
        {
            if (this.Modal)
                this.StartPosition = FormStartPosition.CenterParent;
            else
                this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        public FrmAddOrderGuest(TravelAgency.Model.Orders ordersModel, bool is4Modify = false, Model.OrderGuest guesstModel = null) : this()
        {
            _is4Modify = is4Modify;
            _ordersModel = ordersModel;
            _guestModel = guesstModel;
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

            if (_ordersModel != null)
                txtOrderNo.Text = _ordersModel.OrderNo;


            if (_is4Modify)
            {
                this.Text = "修改订单客户信息";

                txtGuestId.Text = _guestModel.GuestId;
                txtGuestName.Text = _guestModel.GuestName;
                txtGuestNamePinYin.Text = _guestModel.GuestNamePinYin;
                txtGuestSex.Text = _guestModel.GuestSex;
                txtGuestBirthday.Text = _guestModel.GuestBirthday.ToString();
                txtGuestPhone.Text = _guestModel.GuestPhone;
                txtGuestWeiChat.Text = _guestModel.GuestWeChat;
                txtGuestEMail.Text = _guestModel.GuestEMail;
                txtGuestType.Text = _guestModel.GuestType;
                txtGuestLastNightHotel.Text = _guestModel.GuestLastNightHotel;
                txtGuestPassportNo.Text = _guestModel.GuestPassportNo;
                txtGuestCountry.Text = _guestModel.GuestCountry;
                txtPrice.Text = DecimalHandler.DecimalToString(_guestModel.Price);
            }
        }

        #region 窗体初始化
        private void InitComboBoxs()
        {
            //string tablename = "Orders";

            txtGuestSex.DropDownStyle = ComboBoxStyle.DropDown;
            txtGuestCountry.DropDownStyle = ComboBoxStyle.DropDown;
            txtGuestType.DropDownStyle = ComboBoxStyle.DropDown;

            txtGuestSex.Items.Add("男");
            txtGuestSex.Items.Add("女");
            txtGuestSex.Items.Add("保密");
            txtGuestSex.SelectedIndex = 0;

            foreach (string countryName in CountryCode.CountryNameArr)
            {
                txtGuestCountry.Items.Add(countryName);
            }

            txtGuestType.Items.Add("成人");
            txtGuestType.Items.Add("儿童");
            txtGuestType.Items.Add("其他");
            txtGuestType.SelectedIndex = 0;
        }
        #endregion



        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_is4Modify)
            {
                //_guestModel.OrdersId = _ordersModel.Id;
                _guestModel.GuestId = CtrlParser.Parse2String(txtGuestId);
                _guestModel.GuestName = CtrlParser.Parse2String(txtGuestName);
                _guestModel.GuestNamePinYin = CtrlParser.Parse2String(txtGuestNamePinYin);
                _guestModel.GuestSex = CtrlParser.Parse2String(txtGuestSex);
                _guestModel.GuestBirthday = CtrlParser.Parse2Datetime(txtGuestBirthday);
                _guestModel.GuestPhone = CtrlParser.Parse2String(txtGuestPhone);
                _guestModel.GuestWeChat = CtrlParser.Parse2String(txtGuestWeiChat);
                _guestModel.GuestEMail = CtrlParser.Parse2String(txtGuestEMail);
                _guestModel.GuestType = CtrlParser.Parse2String(txtGuestType);
                _guestModel.GuestPassportNo = CtrlParser.Parse2String(txtGuestPassportNo);
                _guestModel.GuestLastNightHotel = CtrlParser.Parse2String(txtGuestLastNightHotel);
                _guestModel.GuestCountry = CtrlParser.Parse2String(txtGuestCountry);
                _guestModel.Price = CtrlParser.Parse2Decimal(txtPrice);
                RetModel = _guestModel;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                RetModel = new OrderGuest();
                if (_ordersModel != null)
                    RetModel.OrdersId = _ordersModel.Id;
                RetModel.GuestId = CtrlParser.Parse2String(txtGuestId);
                RetModel.GuestName = CtrlParser.Parse2String(txtGuestName);
                RetModel.GuestNamePinYin = CtrlParser.Parse2String(txtGuestNamePinYin);
                RetModel.GuestSex = CtrlParser.Parse2String(txtGuestSex);
                RetModel.GuestBirthday = CtrlParser.Parse2Datetime(txtGuestBirthday);
                RetModel.GuestPhone = CtrlParser.Parse2String(txtGuestPhone);
                RetModel.GuestWeChat = CtrlParser.Parse2String(txtGuestWeiChat);
                RetModel.GuestEMail = CtrlParser.Parse2String(txtGuestEMail);
                RetModel.GuestType = CtrlParser.Parse2String(txtGuestType);
                RetModel.GuestPassportNo = CtrlParser.Parse2String(txtGuestPassportNo);
                RetModel.GuestLastNightHotel = CtrlParser.Parse2String(txtGuestLastNightHotel);
                RetModel.GuestCountry = CtrlParser.Parse2String(txtGuestCountry);
                RetModel.Price = CtrlParser.Parse2Decimal(txtPrice);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


    }
}
