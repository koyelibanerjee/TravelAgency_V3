﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TravelAgency.CSUI.Financial.FrmSub
{
    public partial class FrmSelClientCharge : Form
    {
        private List<Model.ClientCharge> _list;
        public int SelIdx { get; set; }
        public bool ChangeAllAlike { get; set; }

        public FrmSelClientCharge(List<Model.ClientCharge> list)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            _list = list;
            InitializeComponent();
        }

        private void FrmSelConsulateCharge_Load(object sender, EventArgs e)
        {
            comboBoxEx1.DropDownStyle = ComboBoxStyle.DropDownList;
            //把list加载到combobox里面
            foreach (var consulateCharge in _list)
            {
                comboBoxEx1.Items.Add(consulateCharge.Client+consulateCharge.Country + consulateCharge.Types + consulateCharge.DepartureType + consulateCharge.Remark);
            }
            comboBoxEx1.SelectedIndexChanged += ComboBoxEx1_SelectedIndexChanged;


            comboBoxEx1.SelectedIndex = 0;
            chkAllChange.Checked = true;

            this.lbConfig.Text = "共有" + _list.Count + "套配置。";
        }

        private void ComboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            lbReceipt.Text = _list[comboBoxEx1.SelectedIndex].Charge.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.SelIdx = comboBoxEx1.SelectedIndex;
            this.ChangeAllAlike = chkAllChange.Checked;
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
