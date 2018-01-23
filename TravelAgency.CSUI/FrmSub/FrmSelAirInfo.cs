using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency.CSUI.FrmSub
{
    public partial class FrmSelAirInfo : Form
    {
        public int SelIdx { get; set; }
        public FrmSelAirInfo()
        {
            InitializeComponent();
        }

        private void FrmSelAirInfo_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                SelIdx = 0;
            if (radioButton2.Checked)
                SelIdx = 1;
            if (radioButton3.Checked)
                SelIdx = 2;
            if (radioButton4.Checked)
                SelIdx = 3;
            if (radioButton5.Checked)
                SelIdx = 4;
            if (radioButton6.Checked)
                SelIdx = 5;
            if (radioButton7.Checked)
                SelIdx = 6;
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
