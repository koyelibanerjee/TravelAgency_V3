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
using DevComponents.DotNetBar;
using TravelAgency.Common;

namespace TravelAgency.CSUI.Visa.FrmSub
{
    public partial class FrmAddFromImage : Form
    {
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
            proPictureBoxWithRoi1.AddUpdateDel(SetRoiImage);
        }

        private void btnGetRoi_Click(object sender, EventArgs e)
        {
            if (proPictureBoxWithRoi1.Image == null)
            {
                MessageBoxEx.Show("请先打开图像!");
                return;
            }
            if (btnGetRoi.Text == "设置ROI")
            {
                btnGetRoi.Text = "结束";
                proPictureBoxWithRoi1.StartSetRoi();
            }
            else
            {
                btnGetRoi.Text = "设置ROI";
                proPictureBoxWithRoi1.EndSetRoi();
            }

        }

        private void SetRoiImage()
        {
            this.proPictureBox1.Image = proPictureBoxWithRoi1.RoiImage;
        }

        private void btnDoRecog_Click(object sender, EventArgs e)
        {
            if (proPictureBox1.Image == null)
            {
                MessageBoxEx.Show("请先选中图片中要识别的区域!");
                return;
            }

            proPictureBox1.Image.Save("roi.jpg");

            string ret = new CmdHandler().RunCmd("tesseract.exe roi.jpg result -l eng");

            string res = File.ReadAllText("result.txt");

            txtPassNo.Text = res;
        }
    }
}
