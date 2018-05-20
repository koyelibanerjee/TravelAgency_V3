using System;
using System.Diagnostics;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.Common;
using TravelAgency.Common.PictureHandler;

namespace TravelAgency.OrdersManagement
{
    public partial class FrmAddOrderGuest : Form
    {
        private readonly BLL.Orders _bllOrders = new BLL.Orders();
        private readonly BLL.OrderExcel _bllOrderExcel = new BLL.OrderExcel();
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托
        private readonly int _curPage; //主界面更新数据库需要一个当前页
        private readonly bool _is4Modify = false;
        private readonly TravelAgency.Model.Orders _model = null;

        public FrmAddOrderGuest(Action<int> updateDel, int curPage, bool is4Modify = false, TravelAgency.Model.Orders model = null)
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

            txtGuestSex.DropDownStyle = ComboBoxStyle.DropDown;
            txtGuestCountry.DropDownStyle = ComboBoxStyle.DropDown;
            txtGuestType.DropDownStyle = ComboBoxStyle.DropDown;

            txtGuestSex.Items.Add("男");
            txtGuestSex.Items.Add("女");
            txtGuestSex.Items.Add("保密");

            foreach (string countryName in CountryCode.CountryNameArr)
            {
                txtGuestCountry.Items.Add(countryName);
            }

            txtGuestType.Items.Add("成人");
            txtGuestType.Items.Add("儿童");




        }
        #endregion



        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_is4Modify)
            {
                try
                {
                                    

                    //if (!string.IsNullOrEmpty(_model.GuestId) &&
                    //    !string.IsNullOrEmpty(_model.GuestPhone) &&
                    //    !string.IsNullOrEmpty(_model.GuestName))
                    //{
                    //    _model.GuestInfoTypedIn = true;
                    //}
                    //else
                        _model.GuestInfoTypedIn = false;

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
