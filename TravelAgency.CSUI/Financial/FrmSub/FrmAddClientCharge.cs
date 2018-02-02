using System;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.BLL;

namespace TravelAgency.CSUI.Financial.FrmSub
{
    public partial class FrmAddClientCharge : Form
    {
        private BLL. ClientCharge _bllCharge = new ClientCharge();
        private BLL.Visa _bllVisa = new BLL.Visa();
        private bool _inited = false;
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托
        private readonly int _curPage; //主界面更新数据库需要一个当前页
        private readonly bool _is4Modify = false;
        private readonly Model.ClientCharge _model = null;

        public FrmAddClientCharge(Action<int> updatedel, int curpage, bool is4Modify = false, Model.ClientCharge model = null)
        {
            _updateDel = updatedel;
            _curPage = curpage;
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            _is4Modify = is4Modify;
            _model = model;
        }

        private void FrmConsulateCharge_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //查询数据库加载目前有的数据
            InitCBsByData();
            if (_is4Modify)
            {
                //把选中的加载到这里面
                cbReceipt.Text = _model.Charge.ToString();
                cbCountry.Text = _model.Country.ToString();
                cbType.Text = _model.Types.ToString();
                cbDepartureType.Text = _model.DepartureType.ToString();
                txtRemark.Text = _model.Remark;
                cbClient.Text = _model.Client;
            }

            if(_is4Modify)
                return;
            cbCountry.TextChanged += UpdateRemark;
            cbDepartureType.TextChanged += UpdateRemark;
            cbType.TextChanged += UpdateRemark;

        }

        private void UpdateRemark(object sender, EventArgs e)
        {
            txtRemark.Text = cbClient.Text + cbCountry.Text + cbType.Text + cbDepartureType.Text;
        }

        private void InitCBsByData()
        {

            var list = _bllVisa.GetCountryList();
            if (list != null && list.Count > 0)
                foreach (var item in list)
                {
                    cbCountry.Items.Add(item);
                }

            list = _bllVisa.GetTypeList();
            if (list != null && list.Count > 0)
                foreach (var item in list)
                {
                    cbType.Items.Add(item);
                }

            list = _bllVisa.GetDepartureTypeList();
            if (list != null && list.Count > 0)
                foreach (var item in list)
                {
                    cbDepartureType.Items.Add(item);
                }

            list = _bllVisa.GetClientList(); ;
            if (list != null && list.Count > 0)
                foreach (var item in list)
                {
                    cbClient.Items.Add(item);
                }

            list = _bllCharge.GetClientChargeList(); ;
            if (list != null && list.Count > 0)
                foreach (var item in list)
                {
                    cbReceipt.Items.Add(item);
                }


            cbDepartureType.Text = "";
            cbType.Text = "";
            cbCountry.Text = "";
            cbReceipt.Text = "";
            cbClient.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_is4Modify)
            {
                _model.Country = cbCountry.Text;
                _model.DepartureType = cbDepartureType.Text;
                _model.Types = cbType.Text;
                _model.Charge = decimal.Parse(cbReceipt.Text);
                _model.Client = cbClient.Text;

                if (!string.IsNullOrEmpty(txtRemark.Text))
                    _model.Remark = txtRemark.Text;
                if (!_bllCharge.Update(_model))
                {
                    MessageBoxEx.Show("更新失败，请重试!");
                }
            }
            else
            {
                Model.ClientCharge model = new Model.ClientCharge();
                try
                {
                    model.Country = cbCountry.Text;
                    model.DepartureType = cbDepartureType.Text;
                    model.Types = cbType.Text;
                    model.Charge = decimal.Parse(cbReceipt.Text);
                    model.Client = cbClient.Text;

                    if (!string.IsNullOrEmpty(txtRemark.Text))
                        model.Remark = txtRemark.Text;
                }
                catch (Exception)
                {
                    MessageBoxEx.Show("请确保输入格式正确,若没有请输入0");
                    return;
                }
                if (_bllCharge.Add(model) <= 0)
                {
                    MessageBoxEx.Show("添加失败，请重试!");
                }
            }

            _updateDel(_curPage);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
