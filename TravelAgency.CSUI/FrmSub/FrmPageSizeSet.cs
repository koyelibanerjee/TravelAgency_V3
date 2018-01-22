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
    public partial class FrmPageSizeSet : Form
    {
        private FrmQRCode frmQrCode;
        public FrmPageSizeSet(FrmQRCode frm)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.frmQrCode = frm;
            InitializeComponent();
        }

        private void FrmPageSizeSet_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            frmQrCode.PageWidth = int.Parse(textBoxX2.Text);
            frmQrCode.PageHeight = int.Parse(textBoxX1.Text);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
