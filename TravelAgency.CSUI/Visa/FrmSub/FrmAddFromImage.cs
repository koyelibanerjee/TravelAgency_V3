using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgency.Common;

namespace TravelAgency.CSUI.Visa.FrmSub
{
    public partial class FrmAddFromImage : Form
    {

        private Point start; //画框的起始点
        private Point end;//画框的结束点<br>bool blnDraw;//判断是否绘制<br>Rectangel rect;
        private bool blnDraw = false;
        private Rectangle rect;
        private bool _bSetRoiIng = false;

        public FrmAddFromImage()
        {
            InitializeComponent();
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            string filename = GlobalUtils.ShowOpenFileDlg("图片|*.jpg;*.png;*.gif;*.jpeg;*.bmp");
            if (string.IsNullOrEmpty(filename))
                return;
            proPictureBoxWithRoi1.Image = GlobalUtils.LoadImageFromFileNoBlock(filename);
        }

        private void FrmAddFromImage_Load(object sender, EventArgs e)
        {
            proPictureBoxWithRoi1.SizeMode = PictureBoxSizeMode.Zoom;
            //proPictureBox1.MouseDown += ProPictureBox1_MouseDown;
            //proPictureBox1.MouseUp += ProPictureBox1_MouseUp;
            //proPictureBox1.MouseMove += ProPictureBox1_MouseMove;
            //proPictureBox1.Paint += ProPictureBox1_Paint;
        }

        private void btnGetRoi_Click(object sender, EventArgs e)
        {
            
            proPictureBoxWithRoi1.StartSetRoi();
        }


        //private void ProPictureBox1_MouseDown(object sender, MouseEventArgs e)
        //{

        //}




    }
}
