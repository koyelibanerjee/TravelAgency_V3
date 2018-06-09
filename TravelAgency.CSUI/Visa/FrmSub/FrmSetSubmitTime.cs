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
using TravelAgency.CSUI.FrmMain;

namespace TravelAgency.CSUI.Visa.FrmSub
{
    public partial class FrmSetSubmitTime : Form
    {
        private readonly Model.Visa _visaModel = null;
        private FrmSetSubmitTime()
        {
            if (this.Modal)
                this.StartPosition = FormStartPosition.CenterParent;
            else
                this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            InitializeComponent();
        }

        public FrmSetSubmitTime(Model.Visa model):this()
        {
            _visaModel = model;
        }

        private void FrmSetSubmitTime_Load(object sender, EventArgs e)
        {
            lbGroupNo.Text = _visaModel.GroupNo;
            lbCountry.Text = _visaModel.Country;
            DateTime date = _visaModel.RealTime.Value.Date;
            if (_visaModel.Country == "日本")
                date = date.AddDays(1);
            else if (_visaModel.Country == "韩国")
                date = date.AddDays(5);
            else if (_visaModel.Country == "泰国")
                date = date.AddDays(3);

            txtFinishTime.Text = date.ToString();
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            txtFinishTime
                .Text = _visaModel.RealTime.Value.Date.AddDays(1).ToString();
        }

        private void btn5Day_Click(object sender, EventArgs e)
        {
            txtFinishTime
    .Text = _visaModel.RealTime.Value.Date.AddDays(5).ToString();
        }

        private void btn3Day_Click(object sender, EventArgs e)
        {
            txtFinishTime
    .Text = _visaModel.RealTime.Value.Date.AddDays(3).ToString();
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            FrmVisaInfoSubmitDetails frm = new FrmVisaInfoSubmitDetails(new BLL.VisaInfo().GetModelListByVisaIdOrderByPosition(_visaModel.Visa_id), null, 0);
            frm.Show();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _visaModel.FinishTime = CtrlParser.Parse2Datetime(txtFinishTime);
            var visainfolist = new BLL.VisaInfo().GetModelListByVisaIdOrderByPosition(_visaModel.Visa_id);
            foreach (var visaInfo in visainfolist)
            {
                visaInfo.outState = Common.Enums.OutState.Type03NormalOut;
                visaInfo.OutTime = CtrlParser.Parse2Datetime(txtFinishTime);
            }
            new BLL.VisaInfo().UpdateByList(visainfolist);
            bool b = new BLL.Visa().Update(_visaModel);
            if (b)
                MessageBoxEx.Show("更新成功!!!");
            else
            {
                MessageBoxEx.Show("更新失败，请重试!!!");
                return;
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
