using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency.CSUI.Visa.FrmSub
{
    public partial class FrmShowStringValue : Form
    {
        public FrmShowStringValue()
        {
            if(this.Modal)
                this.StartPosition = FormStartPosition.CenterParent;
            else this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
        }

        public FrmShowStringValue(string value):this()
        {
            txtString.Text = value;
        }

        private void FrmShowStringValue_Load(object sender, EventArgs e)
        {

        }
    }
}
