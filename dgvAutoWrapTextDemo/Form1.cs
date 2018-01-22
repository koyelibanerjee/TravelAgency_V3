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

namespace dgvAutoWrapTextDemo
{
    public partial class Form1 : Form
    {
        private TravelAgency.BLL.Visa _bllVisa = new Visa();
        private TravelAgency.BLL.VisaInfo _bllVisaInfo = new VisaInfo();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var list = _bllVisaInfo.GetModelList("visa_id ='" + "804B6812-055F-4CB0-A545-749592536704"+"'");
            var list = _bllVisaInfo.GetModelListByVisaIdOrderByPosition( "804B6812-055F-4CB0-A545-749592536704");

            dataGridView1.DataSource = list;
            dataGridViewX1.DataSource = list;
            radGridView1.DataSource = list;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;

            dataGridViewX1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewX1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;

            //radGridView
        }
    }
}
