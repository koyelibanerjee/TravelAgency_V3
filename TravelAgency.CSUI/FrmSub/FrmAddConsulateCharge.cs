using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency;
using TravelAgency.BLL;

namespace TravelAgency.CSUI.FrmSub
{
    public partial class FrmAddConsulateCharge : Form
    {
        private BLL.ConsulateCharge _bllCharge = new ConsulateCharge();
        private BLL.Visa _bllVisa = new BLL.Visa();
        private bool _inited = false;
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托
        private readonly int _curPage; //主界面更新数据库需要一个当前页
        public FrmAddConsulateCharge(Action<int> updatedel,int curpage)
        {
            _updateDel = updatedel;
            _curPage = curpage;
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
        }

        private void FrmConsulateCharge_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            //查询数据库加载目前有的数据
            InitCBsByData();
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

            list = _bllCharge.GetConsulateCostList();
            if (list != null && list.Count > 0)
                foreach (var item in list)
                {
                    cbConsulationCost.Items.Add(item);
                }

            list = _bllCharge.GetVisaPersonCostList();
            if (list != null && list.Count > 0)
                foreach (var item in list)
                {
                    cbVisaPersonCost.Items.Add(item);
                }

            list = _bllCharge.GetInvitationCostList();
            if (list != null && list.Count > 0)
                foreach (var item in list)
                {
                    cbInvitationCost.Items.Add(item);
                }

            cbDepartureType.Text = "";
            cbType.Text = "";
            cbCountry.Text = "";
            cbInvitationCost.Text = "";
            cbVisaPersonCost.Text = "";
            cbConsulationCost.Text = "";
        }




        private void btnOK_Click(object sender, EventArgs e)
        {
            Model.ConsulateCharge model = new Model.ConsulateCharge();
            try
            {
                model.Country = cbCountry.Text;
                model.DepartureType = cbDepartureType.Text;
                model.Types = cbType.Text;
                model.ConsulateCost = decimal.Parse(cbConsulationCost.Text);
                model.InvitationCost = decimal.Parse(cbInvitationCost.Text);
                model.VisaPersonCost = decimal.Parse(cbVisaPersonCost.Text);
            }
            catch (Exception)
            {
                MessageBoxEx.Show("请确保输入格式正确,若没有请输入0");
                return;
            }
            if (_bllCharge.Add(model)<=0)
            {
                MessageBoxEx.Show("添加失败，请重试!");
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
