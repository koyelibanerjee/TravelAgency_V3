using System;
using System.Windows.Forms;

namespace TravelAgency.BLL
{
    public partial class FrmGroupOrIndividualValue : Form
    {
        public string TypesValue = "个签";

        /// <summary>
        /// 从visamodel初始化，修改团的类型
        /// </summary>
        /// <param name="visamodel"></param>
        /// <param name="del"></param>
        /// <param name="page"></param>
        public FrmGroupOrIndividualValue()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbtnIndividual.Checked)
            {
                TypesValue ="个签";
            }
            else if (rBtnTeam.Checked)
            {
                TypesValue = "团签";
            }
            else if(rbtnTeamToInd.Checked)
            {
                TypesValue = "团做个";
            }
            else
            {
                TypesValue = "商务";
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
            rbtnIndividual.Checked = true;
        }
    }
}
