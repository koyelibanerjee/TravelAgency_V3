using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelrikGridViewDemo
{
    public partial class Form1 : Form
    {

        TravelAgency.BLL.VisaInfo visainfoBll = new TravelAgency.BLL.VisaInfo();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radGridView1.DataSource = visainfoBll.GetModelList(string.Empty);


        }
    }
}
