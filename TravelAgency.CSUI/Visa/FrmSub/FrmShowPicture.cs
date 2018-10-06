using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;
using DevComponents.DotNetBar;
using TravelAgency.BLL.FTPFileHandler;
using TravelAgency.BLL.RPC;
using TravelAgency.Common;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace TravelAgency.CSUI.FrmSub
{
    public partial class FrmShowPicture : Form
    {
        /// <summary>
        /// 其实这个窗体里面大多数消息都没用，图片框控件里面实现了已经
        /// </summary>
        private GaopaiPicHandler _gaopaiPicHandler;

        private readonly List<string> _imageList; //每张图片的名字

        private readonly string _prefix; //20171227

        private int _idx = 0; //当前位置

        private bool _isOtherDistrict = false;

        public FrmShowPicture()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        public FrmShowPicture(List<string> imageList, string date, int idx, GaopaiPicHandler.PictureType type)
            : this()
        {
            _imageList = imageList;
            _prefix = date; //_prefix如:20180810 或 20180810/个签
            _idx = idx;
            _gaopaiPicHandler = new GaopaiPicHandler(type);
        }

        public FrmShowPicture(List<string> imageList, string visaid, int idx, bool isOtherDis = false)
    : this()
        {
            _imageList = imageList;
            _prefix = visaid;
            _idx = idx;
            _gaopaiPicHandler = new GaopaiPicHandler(GaopaiPicHandler.PictureType.Type01_Normal);
            _isOtherDistrict = isOtherDis;
        }

        #region 窗体事件
        private void FrmShowPicture_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            UpdateState();
            FormClosing += FrmShowPicture_FormClosing;
            if (GlobalUtils.LoginUserLevel != RigthLevel.Manager && GlobalUtils.LoginUser.WorkId != "10313")
                this.btnDeletePicture.Enabled = false;

        }

        private void FrmShowPicture_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.picBox1.Image?.Dispose();
            //this.Dispose();
        }

        private void UpdateState()
        {
            btnPre.Enabled = true;
            btnNext.Enabled = true;
            if (_idx == 0)
                btnPre.Enabled = false;
            if (_idx == _imageList.Count - 1)
                btnNext.Enabled = false;
            this.Text = "图片查看:  " + _imageList[_idx];


            if (!_isOtherDistrict)
                this.picBox1.Image = _gaopaiPicHandler.GetGaoPaiImage(_prefix + "/" + _imageList[_idx]);

            else
            {
                this.picBox1.Image = HproseClient.GetGaopaiImageOfVisa(_prefix + "/" + _imageList[_idx]);
                this.picBox1.FileName = GlobalUtils.LocalGaoPaiPicPath + "/" + _prefix + "/" + _imageList[_idx];
            }

            lbPageIdx.Text = (_idx + 1) + "/" + _imageList.Count;

        }

        #endregion



        #region 按钮事件
        private void btnDeletePicture_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("是否删除图像?", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            if (!_gaopaiPicHandler.DeleteGaopaiImage(_prefix + "/" + _imageList[_idx]))
            {
                MessageBoxEx.Show("删除图像失败，请联系技术人员!");
                return;
            }

            _imageList.RemoveAt(_idx);
            if (_imageList.Count == 0)
            {
                MessageBoxEx.Show("没有其他图像了，将退出图像查看!");
                this.Close();
                return;
            }
            if (_idx < _imageList.Count) //如果还是有图像，且有下一张(现在的_idx就是原来的下一张)，则直接显示
                UpdateState();
            else //原来删除的就是最后一张
            {
                --_idx; //去上一张
                UpdateState();
            }

        }
        private void btnPre_Click(object sender, EventArgs e)
        {
            --_idx;
            UpdateState();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ++_idx;
            UpdateState();
        }

        //下面的按钮和右键菜单响应都没用了，只是没删掉而已
        private void btnLeft90_Click(object sender, EventArgs e)
        {
            picBox1.Image = Common.PicHandler.KiRotate90(new Bitmap(picBox1.Image), 270);
        }
        private void btnRight90_Click(object sender, EventArgs e)
        {
            picBox1.Image = Common.PicHandler.KiRotate90(new Bitmap(picBox1.Image), 90);
        }
        private void btnFlipVertical_Click(object sender, EventArgs e)
        {
            picBox1.Image = Common.PicHandler.KiRotate90(new Bitmap(picBox1.Image), -180);
        }
        private void btnFlipHorizontal_Click(object sender, EventArgs e)
        {
            picBox1.Image = Common.PicHandler.KiRotate90(new Bitmap(picBox1.Image), 180);
        }
        #endregion
        #region 右键菜单响应
        private void picBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //    cmsPicBox.Show(MousePosition);
        }

        private void 左旋90度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLeft90_Click(null, null);
        }

        private void 右旋90度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRight90_Click(null, null);
        }

        private void 垂直翻转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnFlipVertical_Click(null, null);
        }

        private void 水平翻转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnFlipHorizontal_Click(null, null);
        }
        private void 保存图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = GlobalUtils.ShowSaveFileDlg(string.Empty);
            if (!string.IsNullOrEmpty(filename))
                picBox1.Image.Save(filename);
        }














        #endregion


    }
}
