using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency.CSUI.Visa.FrmSub.FrmSetValue
{
    public partial class FrmSetMultiStringValue : Form
    {
        public string RetClient { get; set; }
        public string RetSalesPerson { get; set; }
        public string RetTips2 { get; set; }
        private FrmSetMultiStringValue()
        {
            if(this.Modal)
                this.StartPosition = FormStartPosition.CenterParent;
            else 
                this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }


        public FrmSetMultiStringValue(string headertext="设置",string client="",string salesperson="",string tips2=""):this()
        {
            this.Text = headertext;
            txtSalesPerson.Text = salesperson;
            txtTips2.Text = tips2;
            txtClient.Text = client;
        }

        private void FrmSetMultiStringValue_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            RetClient = txtClient.Text;
            RetSalesPerson = txtSalesPerson.Text;
            RetTips2 = txtTips2.Text;
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
