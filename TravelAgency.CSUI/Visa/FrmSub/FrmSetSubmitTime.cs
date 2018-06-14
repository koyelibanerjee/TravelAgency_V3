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
        //private readonly Model.Visa _visaModel = null;
        public DateTime? RetFinishTime = null;
        public DateTime? RetRealTime = null;
        private bool _initFromModel = false;
        public FrmSetSubmitTime()
        {
            if (this.Modal)
                this.StartPosition = FormStartPosition.CenterParent;
            else
                this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            InitializeComponent();
        }

        public FrmSetSubmitTime(string realtime, string finishtime)
            : this()
        {
            txtRealTime.Text = realtime;
            txtFinishTime.Text = finishtime;
            rbtnJapan.Enabled = false;
            rbtnKorea.Enabled = false;
            rbtnThailand.Enabled = false;
            _initFromModel = true;
        }


        //public FrmSetSubmitTime(Model.Visa model):this()
        //{
        //    _visaModel = model;
        //}

        private void FrmSetSubmitTime_Load(object sender, EventArgs e)
        {

            if (_initFromModel)
                return;
            //rbtnJapan.Select();
            DateTime finishdate = DateTime.Now;
            DateTime realdate = DateTime.Now;
            realdate.AddDays(1);
            finishdate.AddDays(1);

            txtFinishTime.Text = finishdate.ToString();
            txtRealTime.Text = realdate.ToString();
        }

        //    private void btnNextDay_Click(object sender, EventArgs e)
        //    {
        //        txtFinishTime
        //            .Text = _visaModel.RealTime.Value.Date.AddDays(1).ToString();
        //    }

        //    private void btn5Day_Click(object sender, EventArgs e)
        //    {
        //        txtFinishTime
        //.Text = _visaModel.RealTime.Value.Date.AddDays(5).ToString();
        //    }

        //    private void btn3Day_Click(object sender, EventArgs e)
        //    {
        //        txtFinishTime
        //.Text = _visaModel.RealTime.Value.Date.AddDays(3).ToString();
        //    }

        //private void btnShowDetails_Click(object sender, EventArgs e)
        //{
        //    FrmVisaInfoSubmitDetails frm = new FrmVisaInfoSubmitDetails(new BLL.VisaInfo().GetModelListByVisaIdOrderByPosition(_visaModel.Visa_id), null, 0);
        //    frm.Show();
        //}

        private void btnOk_Click(object sender, EventArgs e)
        {
            //_visaModel.FinishTime = CtrlParser.Parse2Datetime(txtFinishTime);
            //var visainfolist = new BLL.VisaInfo().GetModelListByVisaIdOrderByPosition(_visaModel.Visa_id);
            //foreach (var visaInfo in visainfolist)
            //{
            //    visaInfo.outState = Common.Enums.OutState.Type03NormalOut;
            //    visaInfo.OutTime = CtrlParser.Parse2Datetime(txtFinishTime);
            //}
            //new BLL.VisaInfo().UpdateByList(visainfolist);
            //bool b = new BLL.Visa().Update(_visaModel);
            //if (b)
            //    MessageBoxEx.Show("更新成功!!!");
            //else
            //{
            //    MessageBoxEx.Show("更新失败，请重试!!!");
            //    return;
            //}

            RetRealTime = CtrlParser.Parse2Datetime(txtRealTime);
            RetFinishTime = CtrlParser.Parse2Datetime(txtFinishTime);

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void rbtnJapan_CheckedChanged(object sender, EventArgs e)
        {
            txtFinishTime.Text = DateTime.Now.Date.AddDays(5).ToString();
            txtRealTime.Text = DateTime.Now.Date.AddDays(1).ToString();

        }

        private void rbtnKorea_CheckedChanged(object sender, EventArgs e)
        {
            txtFinishTime.Text = DateTime.Now.Date.AddDays(5).ToString();
            txtRealTime.Text = DateTime.Now.Date.AddDays(1).ToString();
        }

        private void rbtnThailand_CheckedChanged(object sender, EventArgs e)
        {
            txtFinishTime.Text = DateTime.Now.Date.AddDays(3).ToString();
            txtRealTime.Text = DateTime.Now.Date.AddDays(1).ToString();
        }
    }
}
