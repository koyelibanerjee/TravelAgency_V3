using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgency.BLL;

namespace TravelAgency.CSUI.Financial.FrmSub
{
    public partial class FrmSelectClient : Form
    {

        private BLL.CustomerBalance _bllCustomerBalance = new BLL.CustomerBalance();
        public string RetClient;
        public FrmSelectClient()
        {
            if (this.Modal)
                this.StartPosition = FormStartPosition.CenterScreen;
            else
                this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            InitializeComponent();
        }

        private void FrmSelectClient_Load(object sender, EventArgs e)
        {
            loadClientList();
        }

        private void loadClientList()
        {
            var list = _bllCustomerBalance.GetValidClientList();
            if (list != null && list.Count > 0)
                foreach (var item in list)
                {
                    cbClient.Items.Add(item);
                }

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.DialogResult
                 = DialogResult.OK;
            this.RetClient = cbClient.Text;
            this.Close();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
