using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgency.Common;

namespace TravelAgency.OrdersManagement
{
    public partial class FrmTimeChoose : Form
    {
        public DateTime RetValue { get; set; }
        

        public FrmTimeChoose()
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
            txtTime.Text = DateTimeFormator.DateTimeToString(DateTime.Now, DateTimeFormator.TimeFormat.Type14LongTime1);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            RetValue = DateTime.Parse(txtTime.Text);
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
