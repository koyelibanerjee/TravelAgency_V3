using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency.CSUI.Visa.FrmSub.FrmSetValue
{
    public partial class FrmSetStringValueComboBox : Form
    {
        public string RetValue { get; set; }
        private FrmSetStringValueComboBox()
        {
            if(this.Modal)
                this.StartPosition = FormStartPosition.CenterParent;
            else 
                this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }


        public FrmSetStringValueComboBox(string headertext,List<string> list,string value=""):this()
        {
            this.Text = headertext;
            comboBoxEx1.Text = value;
            foreach (var item in list)
            {
                comboBoxEx1.Items.Add(item);
            }
        }

        private void FrmSetStringValueComboBox_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            RetValue = comboBoxEx1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
