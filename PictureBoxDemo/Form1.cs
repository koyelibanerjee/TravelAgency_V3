using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureBoxDemo
{
    public partial class Form1 : Form
    {
        private float scale_factor = 1.0f;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBox1.Image = Image.FromFile("G54278156.jpg");
            this.pbox_zoom1.Image =  new Bitmap("G54278156.jpg");
            this.proPictureBox1.Image = new Bitmap("G54278156.jpg");
            //proPictureBox1.SetFitScale();
            pictureBox1.MouseWheel += PictureBox1_OnMouseWheel;
        }

        private void PictureBox1_OnMouseWheel(object sender, MouseEventArgs e)
        {
            
        }
    }
}
