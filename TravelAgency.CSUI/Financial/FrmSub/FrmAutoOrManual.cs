using System;
using System.Windows.Forms;

namespace TravelAgency.CSUI.Financial.FrmSub
{
    public partial class FrmAutoOrManual : Form
    {
        private bool _forActivity;
        public enum ClaimType
        {
            Type01_Auto,
            Type02_Manual
        }
        public ClaimType RetValue;
        public FrmAutoOrManual(bool forActivity)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            _forActivity = forActivity;
            if (!forActivity)
            {
                labelX2.Text = "请选择\"常规\"金额认账方式:";
            }
            else
            {
                labelX2.Text = "请选择\"活动\"金额认账方式:";
            }
        }

        private void FrmAutoOrManual_Load(object sender, EventArgs e)
        {
            //rbtnDone.Checked = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_forActivity)
            {
                MessageBox.Show("已经选择了常规金额认领的情况下，活动金额必须选取一种方式!");
                return;
            }
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
