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
    public partial class FrmPlatformSet : Form
    {
        public string RetValue = "未校验";

        /// <summary>
        ///         /// </summary>
        /// <param name="visamodel"></param>
        /// <param name="del"></param>
        /// <param name="page"></param>
        public FrmPlatformSet()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }



        private void btnOK_Click(object sender, EventArgs e)
        {

            this.RetValue = txtExcelType.Text;
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
            //rbtnNotCheck.Checked = true;
            txtExcelType.Items.Add("大众点评");
            txtExcelType.Items.Add("飞猪支付宝");
            txtExcelType.Items.Add("蚂蜂窝");
            txtExcelType.Items.Add("携程");
            txtExcelType.DropDownStyle = ComboBoxStyle.DropDownList;
            txtExcelType.SelectedIndex = 0;
        }
    }
}
