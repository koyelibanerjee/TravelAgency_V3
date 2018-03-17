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
    public partial class FrmSelUser : Form
    {
        private readonly BLL.JobAssignment _bllJobAssignment = new BLL.JobAssignment();
        private readonly BLL.AuthUser _bllAuthUser = new BLL.AuthUser();
        public string SelWorkId { get; set; }

        public FrmSelUser()
        {
            InitializeComponent();
        }

        private void FrmSelUser_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            LoadDataToDgv();
        }

        private void LoadDataToDgv()
        {
            var list = _bllAuthUser.GetModelList(" departmentid = 'A86ED375-76DB-45DF-A4E9-D0BB8815D49C'");
            dataGridView1.DataSource = list;
        }

        private void FrmSelUser_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
                SelWorkId = dataGridView1.CurrentRow.Cells["WorkId"].Value.ToString();
            else return;
            //
            this.DialogResult = DialogResult.OK;
        }



    }
}
