using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComboBoxDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        struct ComboBoxItem
        {
            public ComboBoxItem(string t, string v)
            {
                text = t;
                value = v;
            }

            public string text { get; }
            public string value { get; }
        }

        

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine(((ComboBoxItem)(comboBoxEx1.SelectedItem)).text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxEx1.Items.Add(new ComboBoxItem("t1", "v1"));

        }
    }
}
