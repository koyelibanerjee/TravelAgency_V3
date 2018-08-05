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
using TravelAgency.Common;
using TravelAgency.CSUI.Properties;
using TravelAgency.Model;
using TravelAgency.Model.Enums;

namespace TravelAgency.CSUI.FrmSub
{
    public partial class FrmAddVisa : Form
    {
        private readonly BLL.Visa _bllVisa = new BLL.Visa();
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托
        private readonly int _curPage; //主界面更新数据库需要一个当前页
        private readonly BLL.ActionRecords _bllActionRecords = new BLL.ActionRecords();

        public FrmAddVisa(Action<int> updateDel, int curpage)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            _updateDel = updateDel;
            _curPage = curpage;
        }

        private void FrmAddVisa_Load(object sender, EventArgs e)
        {
            rbtnIndividual.Checked = true;
            //出境类型
            txtDepartureType.Items.Add("单次");
            txtDepartureType.Items.Add("单次30");
            txtDepartureType.Items.Add("冲绳单次");
            txtDepartureType.Items.Add("冲绳三年");
            txtDepartureType.Items.Add("东北1单次");
            txtDepartureType.Items.Add("东北1三年");
            txtDepartureType.Items.Add("东北2A三年");
            txtDepartureType.Items.Add("东北2B三年");
            txtDepartureType.Items.Add("东北2C三年");
            txtDepartureType.Items.Add("东北2D三年");
            txtDepartureType.Items.Add("普通三年");
            txtDepartureType.Items.Add("五年多次");
            txtDepartureType.Items.Add("香港");
            txtDepartureType.SelectedIndex = 0;

            //txtDepartureType.Items.Add("其他");
            //外领送签条件
            txtSubmitCondition.Items.Add("暂住证");
            txtSubmitCondition.Items.Add("居住证明");
            txtSubmitCondition.Items.Add("结婚证");
            txtSubmitCondition.Items.Add("身份证");
            txtSubmitCondition.Items.Add("户口本");
            txtSubmitCondition.Items.Add("其他");
            //客人取签方式
            txtFetchType.Items.Add("回签证部");
            txtFetchType.Items.Add("快递");
            txtFetchType.Items.Add("机场自提");
            txtFetchType.Items.Add("重庆自取");
            txtFetchType.Items.Add("车托到五桂桥");
            txtFetchType.Items.Add("其他");
            txtFetchType.SelectedIndex = 0;
            //送签社担当
            txtPerson.Items.Add("成都金桥");
            txtPerson.Items.Add("四川国旅");
            txtPerson.Items.Add("省中旅");
            txtPerson.Text = "";

            //国家选择框加入
            foreach (string countryName in CountryCode.CountryNameArr)
            {
                cbCountry.Items.Add(countryName);
            }
            cbCountry.DropDownStyle = ComboBoxStyle.DropDown;

            //设置操作员
            txtTypeInPerson.Text = Common.GlobalUtils.LoginUser.UserName;
            txtTypeInPerson.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGroupNo.Text))
            {
                MessageBoxEx.Show("团号不能为空!");
                return;
            }

            if (string.IsNullOrEmpty(txtClient.Text) || string.IsNullOrEmpty(txtSalesPerson.Text))
            {
                MessageBoxEx.Show("销售和客户不能为空!");
                return;
            }

            Model.Visa visaModel = CtrlsToVisaModel();
            if (visaModel == null)
                return;

            //操作员
            visaModel.TypeInPerson = GlobalUtils.LoginUser.UserName;

            if ((visaModel.Visa_id = _bllVisa.Add(visaModel)) == Guid.Empty) //执行更新,返回值是新插入的visamodel的guid
            {
                MessageBoxEx.Show("添加团号到数据库失败，请重试!");
                return;
            }
            //操作记录
            _bllActionRecords.AddRecord(ActType._01CreateGroupNo, GlobalUtils.LoginUser, null, visaModel);

            _updateDel(_curPage);
            this.Close();
        }


        private Model.Visa CtrlsToVisaModel()
        {
            Model.Visa visaModel = new Model.Visa();
            //_visaModel.Visa_id = Guid.NewGuid(); //这里必须要给一个，虽然这里不给也会入库正确，数据库会赋给默认值，但是后面更新对应visainfo就会有错
            //这里代码生成器默认给了一个guid，不能再自己给了
            try
            {
                ////单独处理remark
                //if (!string.IsNullOrEmpty((string)dgvGroupInfo.Rows[0].Cells["Remark"].Value))
                //    _visaModel.Remark = (string)dgvGroupInfo.Rows[0].Cells["Remark"].Value;

                if (!string.IsNullOrEmpty(txtDepartureTime.Text))
                    visaModel.PredictTime = DateTime.Parse(txtDepartureTime.Text);
                if (!string.IsNullOrEmpty(txtSubmitTime.Text))
                    visaModel.SubmitTime = DateTime.Parse(txtSubmitTime.Text);
                if (!string.IsNullOrEmpty(txtInTime.Text))
                    visaModel.InTime = DateTime.Parse(txtInTime.Text);
                if (!string.IsNullOrEmpty(txtOutTime.Text))
                    visaModel.OutTime = DateTime.Parse(txtOutTime.Text);

                visaModel.EntryTime = DateTime.Now;
                visaModel.GroupNo = txtGroupNo.Text;
                visaModel.SalesPerson = txtSalesPerson.Text;
                visaModel.Country = cbCountry.Text;
                if (!string.IsNullOrEmpty(txtNumber.Text))
                    visaModel.Number = int.Parse(txtNumber.Text); //团号的人数

                visaModel.client = txtClient.Text;
                visaModel.Name = txtClient.Text;
                visaModel.DepartureType = txtDepartureType.Text;
                visaModel.SubmitCondition = txtSubmitCondition.Text;
                visaModel.FetchCondition = txtFetchType.Text;
                visaModel.TypeInPerson = txtTypeInPerson.Text;
                //_visaModel.CheckPerson = txtCheckPerson.Text;
                //_visaModel.Types = Common.Enums.Types.Individual; //设置为个签
                if (rbtnIndividual.Checked)
                    visaModel.Types = Types.Individual;//设置为指定类型

                if (rBtnTeam.Checked)
                    visaModel.Types = Types.Team;//设置为指定类型

                if (rbtnTeamToInd.Checked)
                    visaModel.Types = Types.Team2Individual;//设置为指定类型

                visaModel.IsUrgent = chbIsUrgent.Checked;
                visaModel.Person = txtPerson.Text;
                visaModel.District = GlobalUtils.LoginUser.District;
                return visaModel;
            }
            catch (Exception)
            {
                visaModel = null; //一定要这里重新赋值为null
                MessageBoxEx.Show("请检查信息格式是否填写正确!");
                return visaModel;
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
