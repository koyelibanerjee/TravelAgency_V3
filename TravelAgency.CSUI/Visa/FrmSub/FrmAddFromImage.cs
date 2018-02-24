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
            proPictureBoxWithRoi1.StartSetRoi();
        }

        private void SetRoiImage()
        {
            this.proPictureBox1.Image = proPictureBoxWithRoi1.RoiImage;
        }

    }
}
