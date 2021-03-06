﻿using System;
using System.Windows.Forms;

namespace TravelAgency.Common.FrmSetValues
{
    public partial class FrmSetStringValue : Form
    {
        public string RetValue { get; set; }
        private FrmSetStringValue()
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


        public FrmSetStringValue(string headertext,string value=""):this()
        {
            this.Text = headertext;
            textBoxX1.Text = value;
        }

        private void FrmSetStringValue_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            RetValue = textBoxX1.Text;
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
