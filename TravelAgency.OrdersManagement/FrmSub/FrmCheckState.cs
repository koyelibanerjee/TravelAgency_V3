using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;

using TravelAgency.Model;

namespace TravelAgency.OrdersManagement
{
    public partial class FrmCheckState : Form
    {
        public string RetValue = "未校验";

        /// <summary>
        ///         /// </summary>
        /// <param name="visamodel"></param>
        /// <param name="del"></param>
        /// <param name="page"></param>
        public FrmCheckState()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbtnNotCheck.Checked)
            {
                RetValue = "未校验";
            }
            else if (rbtnChecked.Checked)
            {
                RetValue = "已校验";
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmGroupOrIndividual_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            rbtnNotCheck.Checked = true;
        }
    }
}
