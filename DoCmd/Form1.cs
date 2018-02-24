using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgency.Common;

namespace DoCmd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string res = new CmdHandler().RunCmd(textBox1.Text);
            textBox2.Text = res;
            textBox3.Text = File.ReadAllText("result.txt");
        }
    }
}
