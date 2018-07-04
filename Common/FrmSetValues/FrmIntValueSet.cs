using System;
using System.Windows.Forms;

namespace TravelAgency.Common.FrmSetValues
{
    public partial class FrmIntValueSet : Form
    {
        public int RetValue { get; set; }

        public FrmIntValueSet(string text, int value)
        {
            StartPosition = this.Modal ? FormStartPosition.CenterParent : FormStartPosition.CenterScreen;
            InitializeComponent();
            this.Text = text;
            this.txtValue.Text = value.ToString();
        }

        private void FrmTimeSpanChoose_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //初始化为今天
            //txtTime.Text = DateTimeFormator.DateTimeToString(DateTime.Now, DateTimeFormator.TimeFormat.Type14LongTime1);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //RetValue = DateTime.Parse(txtTime.Text);
            RetValue = CtrlParser.Parse2Int(txtValue) ?? 0;
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
