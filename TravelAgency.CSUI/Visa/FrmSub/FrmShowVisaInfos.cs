﻿using System;
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
    public partial class FrmShowVisaInfos : Form
    {
        public FrmShowVisaInfos()
        {
            if (this.Modal)
                this.StartPosition = FormStartPosition.CenterParent;
            else this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        public FrmShowVisaInfos(List<Model.VisaInfo> visaInfos) : this()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.DataSource = visaInfos;
        }


        private void FrmShowVisaInfos_Load(object sender, EventArgs e)
        {

        }
    }
}
