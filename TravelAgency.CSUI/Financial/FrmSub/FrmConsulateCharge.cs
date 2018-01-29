using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.BLL;

namespace TravelAgency.CSUI.Financial.FrmSub
{
    public partial class FrmConsulateCharge : Form
    {
        private BLL.ConsulateCharge _bllCharge = new ConsulateCharge();
        private bool _inited = false;
        public decimal ConsulateCost
        {
            get;
            set;
        }
        public decimal VisaPersonCost
        {
            get;
            set;
        }
        public decimal InvitationCost
        {
            get;
            set;
        }


        public FrmConsulateCharge()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
        }

        public FrmConsulateCharge(string country, string types, string DepartureType)
            : this()
        {
            cbCountry.Text = country;
            cbType.Text = types;
            cbDepartureType.Text = DepartureType;
        }

        private void FrmConsulateCharge_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            //查询数据库加载目前有的数据
            InitCBsByData();

            //更新一次数据
            GetMoney();

            _inited = true;
        }

        private void InitCBsByData()
        {
            cbCountry.TextChanged += cbCountry_TextChanged;
            cbType.TextChanged += cbType_TextChanged;
            cbDepartureType.TextChanged += cbDepartureType_TextChanged;

            var list = _bllCharge.GetCountryList();
            if (list != null && list.Count > 0)
                foreach (var item in list)
                {
                    cbCountry.Items.Add(item);
                }

            list = _bllCharge.GetTypeList();
            if (list != null && list.Count > 0)
                foreach (var item in list)
                {
                    cbType.Items.Add(item);
                }

            list = _bllCharge.GetDepartureTypeList();
            if (list != null && list.Count > 0)
                foreach (var item in list)
                {
                    cbDepartureType.Items.Add(item);
                }

        }

        private void cbDepartureType_TextChanged(object sender, EventArgs e)
        {
            if (_inited)
                GetMoney();
        }

        private void cbType_TextChanged(object sender, EventArgs e)
        {
            if (_inited)
                GetMoney();
        }

        private void cbCountry_TextChanged(object sender, EventArgs e)
        {
            if (_inited)
                GetMoney();
        }

        /// <summary>
        /// 根据Combobox选中项查询数据库
        /// </summary>
        /// <returns></returns>
        private List<Model.ConsulateCharge> GetModelByCBs()
        {
            List<string> conditions = new List<string>();

            if (!string.IsNullOrEmpty(cbDepartureType.Text))
            {
                //sb.Append(" DepartureType='" + cbDepartureType.Text + "'");

                conditions.Add(" (DepartureType like  '%" + cbDepartureType.Text + "%') ");
            }

            if (!string.IsNullOrEmpty(cbCountry.Text))
            {
                //sb.Append(" Country='" + cbCountry.Text + "'");
                conditions.Add(" (Country like  '%" + cbCountry.Text + "%') ");

            }
            if (!string.IsNullOrEmpty(cbType.Text))
            {
                conditions.Add(" (Types like  '%" + cbType.Text + "%') ");
                //sb.Append(" Types='" + cbType.Text + "'");
            }

            string[] arr = conditions.ToArray();
            string where = string.Join(" and ", arr);

            var list = _bllCharge.GetModelList(where);
            return list;
        }

        private void GetMoney(/*out decimal ConsulateCost, out decimal VisaPersonCost, out decimal InvitationCost, out string remark*/)
        {
            var list = GetModelByCBs();
            if (list.Count < 1)
            {
                cbConsulationCost.Text = "";
                cbInvitationCost.Text = "";
                cbVisaPersonCost.Text = "";
                return;
            }
            //throw new Exception("找不到对应项目");

            var ConsulateCost = list[0].ConsulateCost ?? 0;
            var VisaPersonCost = list[0].VisaPersonCost ?? 0;
            var InvitationCost = list[0].InvitationCost ?? 0;
            var remark = list[0].Remark;

            cbConsulationCost.Text = ConsulateCost.ToString();
            cbInvitationCost.Text = InvitationCost.ToString();
            cbVisaPersonCost.Text = VisaPersonCost.ToString();
            txtRemark.Text = remark;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ConsulateCost = decimal.Parse(cbConsulationCost.Text);
                VisaPersonCost = decimal.Parse(cbVisaPersonCost.Text);
                InvitationCost = decimal.Parse(cbInvitationCost.Text);
            }
            catch (Exception)
            {
                MessageBoxEx.Show("请输入有效值,若无请填写0!");
                return;
            }




            var list = GetModelByCBs();
            if (list.Count == 0) //以前没有则增加
            {
                Model.ConsulateCharge model = new Model.ConsulateCharge();
                model.Country = !string.IsNullOrEmpty(cbCountry.Text) ? cbCountry.Text : null;
                model.Types = !string.IsNullOrEmpty(cbType.Text) ? cbType.Text : null;
                model.DepartureType = !string.IsNullOrEmpty(cbDepartureType.Text) ? cbDepartureType.Text : null;
                model.ConsulateCost = ConsulateCost;
                model.VisaPersonCost = VisaPersonCost;
                model.InvitationCost = InvitationCost;
                _bllCharge.Add(model);
            }
            else
            {
                var model = list[0];
                model.Country = !string.IsNullOrEmpty(cbCountry.Text) ? cbCountry.Text : null;
                model.Types = !string.IsNullOrEmpty(cbType.Text) ? cbType.Text : null;
                model.DepartureType = !string.IsNullOrEmpty(cbDepartureType.Text) ? cbDepartureType.Text : null;
                model.ConsulateCost = ConsulateCost;
                model.VisaPersonCost = VisaPersonCost;
                model.InvitationCost = InvitationCost;
                _bllCharge.Update(model);
            }


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
