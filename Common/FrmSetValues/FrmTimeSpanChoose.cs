﻿using System;
using System.Windows.Forms;

namespace TravelAgency.Common.FrmSetValues
{
    public partial class FrmTimeSpanChoose : Form
    {
        public DateTime TimeSpanFrom { get; set; }
        public DateTime TimeSpanTo { get; set; }
        private Model.Visa _modelYestodayLast;
        private Model.Visa _modelTodayLast;
        public FrmTimeSpanChoose()
        {
            StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
        }

        private void FrmTimeSpanChoose_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //初始化为今天
            txtFrom.Text = DateTimeFormator.DateTimeToString(DateTime.Now, DateTimeFormator.TimeFormat.Type07DayStart);
            txtTo.Text = DateTimeFormator.DateTimeToString(DateTime.Now, DateTimeFormator.TimeFormat.Type08DayEnd);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            TimeSpanFrom = DateTime.Parse(txtFrom.Text);
            TimeSpanTo = DateTime.Parse(txtTo.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {

            txtFrom.Text = DateTimeFormator.DateTimeToString(DateTime.Now, DateTimeFormator.TimeFormat.Type07DayStart);
            txtTo.Text = DateTimeFormator.DateTimeToString(DateTime.Now, DateTimeFormator.TimeFormat.Type08DayEnd);

        }

        private void btnYestoday_Click(object sender, EventArgs e)
        {
            txtFrom.Text = DateTimeFormator.DateTimeToString(DateTime.Now.AddDays(-1.0), DateTimeFormator.TimeFormat.Type07DayStart);
            txtTo.Text = DateTimeFormator.DateTimeToString(DateTime.Now, DateTimeFormator.TimeFormat.Type08DayEnd);
        }

        private void btnPre2Day_Click(object sender, EventArgs e)
        {
            txtFrom.Text = DateTimeFormator.DateTimeToString(DateTime.Now.AddDays(-2.0), DateTimeFormator.TimeFormat.Type07DayStart);
            txtTo.Text = DateTimeFormator.DateTimeToString(DateTime.Now, DateTimeFormator.TimeFormat.Type08DayEnd);
        }

        private void btnPre7Days_Click(object sender, EventArgs e)
        {
            txtFrom.Text = DateTimeFormator.DateTimeToString(DateTime.Now.AddDays(-7.0), DateTimeFormator.TimeFormat.Type07DayStart);
            txtTo.Text = DateTimeFormator.DateTimeToString(DateTime.Now, DateTimeFormator.TimeFormat.Type08DayEnd);
        }

        private void btnPre2Week_Click(object sender, EventArgs e)
        {
            txtFrom.Text = DateTimeFormator.DateTimeToString(DateTime.Now.AddDays(-14.0), DateTimeFormator.TimeFormat.Type07DayStart);
            txtTo.Text = DateTimeFormator.DateTimeToString(DateTime.Now, DateTimeFormator.TimeFormat.Type08DayEnd);
        }

        private void btnPreAMonth_Click(object sender, EventArgs e)
        {
            txtFrom.Text = DateTimeFormator.DateTimeToString(DateTime.Now.AddMonths(-1), DateTimeFormator.TimeFormat.Type07DayStart);
            txtTo.Text = DateTimeFormator.DateTimeToString(DateTime.Now, DateTimeFormator.TimeFormat.Type08DayEnd);
        }

                private void btnCurWeek_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            int pre = 0;
            if (date.DayOfWeek == DayOfWeek.Sunday)
                pre = 6;
            else
                pre = DateTime.Now.DayOfWeek - DayOfWeek.Monday;
            txtFrom.Text = DateTime.Now.Date.AddDays(pre * -1).ToString("yyyy/MM/dd") + " 00:00:00";
            txtTo.Text = DateTime.Now.Date.ToString("yyyy/MM/dd") + " 23:59:00";
        }

        private void btnCurMonth_Click(object sender, EventArgs e)
        {
            txtFrom.Text = DateTime.Now.Year + "/" + DateTime.Now.Month + "/01 00:00:00";
            txtTo.Text = DateTime.Now.Date.ToString("yyyy/MM/dd") + " 23:59:00";
        }

        private void btnCurYear_Click(object sender, EventArgs e)
        {
            txtFrom.Text = DateTime.Now.Year + "/01/01 00:00:00";
            txtTo.Text = DateTime.Now.Date.ToString("yyyy/MM/dd") + " 23:59:00";
        }



    }
}
