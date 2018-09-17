using System;
using System.Windows.Forms;

namespace TravelAgency.CSUI.Financial.FrmSub
{
    public partial class FrmSetClaimType : Form
    {
        public enum ClaimType
        {
            Type01_ClientCharge,
            Type02_ActivityOrder
        }
        public ClaimType RetValue;
        public FrmSetClaimType()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
        }

        private void FrmSetClaimType_Load(object sender, EventArgs e)
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
            if (rbtnClientCharge.Checked)
                RetValue = ClaimType.Type01_ClientCharge;
            else
                RetValue = ClaimType.Type02_ActivityOrder;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
