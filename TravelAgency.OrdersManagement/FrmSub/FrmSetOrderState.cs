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
    public partial class FrmSetOrderState : Form
    {
        public string RetValue = "普通";


        /// <summary>
        ///         /// </summary>
        /// <param name="visamodel"></param>
        /// <param name="del"></param>
        /// <param name="page"></param>
        public FrmSetOrderState()
        {
            InitializeComponent();
            rbtnNormal.Checked = true;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbtnNormal.Checked)
            {
                RetValue = "普通";
            }
            else if (rbtn已出单.Checked)
            {
                RetValue = "已出单";
            }
            else if (rbtn未退款.Checked)
            {
                RetValue = "未退款";
            }
            else if (rbtn待退款.Checked)
            {
                RetValue = "待退款";
            }
            else
            {
                RetValue = "已退款";
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
            rbtnNormal.Checked = true;
        }
    }
}
