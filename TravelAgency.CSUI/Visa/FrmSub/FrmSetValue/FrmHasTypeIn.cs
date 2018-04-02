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

namespace TravelAgency.CSUI.FrmSetValue
{
    public partial class FrmHasTypeIn : Form
    {
        public string RetValue = "否";

        /// <summary>
        /// 从visamodel初始化，修改团的类型
        /// </summary>
        /// <param name="visamodel"></param>
        /// <param name="del"></param>
        /// <param name="page"></param>
        public FrmHasTypeIn()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbtnNotDone.Checked)
            {
                RetValue = "否";
            }
            else if (rBtnDone.Checked)
            {
                RetValue = "是";
            }
            else if (rbtnDelay.Checked)
            {
                RetValue = "延";
            }
            else
            {
                RetValue = "取";
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
            rbtnNotDone.Checked = true;
        }
    }
}
