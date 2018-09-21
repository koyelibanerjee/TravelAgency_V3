using System;
using System.Windows.Forms;

namespace TravelAgency.CSUI.Financial.FrmSub
{
    public partial class FrmAutoOrManual : Form
    {
        public enum ClaimType
        {
            Type01_Auto,
            Type02_Manual
        }
        public ClaimType RetValue;
        public FrmAutoOrManual()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
        }

        private void FrmAutoOrManual_Load(object sender, EventArgs e)
        {
            //rbtnDone.Checked = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbtnAuto.Checked)
                RetValue = ClaimType.Type01_Auto;
            else
                RetValue = ClaimType.Type02_Manual;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
