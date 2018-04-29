using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TravelAgency.Common;
using TravelAgency.Common.PictureHandler;
using TravelAgency.CSUI.Properties;

namespace TravelAgency.CSUI.FrmSub
{
    public partial class FrmScanCtrlImported : Form
    {
        private Model.VisaInfo_Tmp _model; //当前对应的所有编辑框对应的model
        //private List<Model.VisaInfo> _list; //当前dgv对应的list
        private readonly BLL.VisaInfo _bllVisaInfo = new BLL.VisaInfo();
        private string _tmpname = "_tmp.jpg";
        private FrmScanCtrlImported()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
        }

        public FrmScanCtrlImported(Model.VisaInfo_Tmp model)
            : this()
        {
            //_list = list;
            _model = model;
        }

        #region 拍照窗口按钮事件
        ///// <summary>
        ///// 开始预览
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    axScanCtrl1.StartPreview();
        //}

        ///// <summary>
        ///// 关闭视频
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    axScanCtrl1.StopPreview();
        //}

        /// <summary>
        /// 属性按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            axScanCtrl1.Property();
        }


        /// <summary>
        /// 放大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            axScanCtrl1.SetZoomIn();
        }

        /// <summary>
        /// 缩小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            axScanCtrl1.SetZoomOut();
        }

        /// <summary>
        /// 拍照按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "拍照")
            {
                //_tmpname = Path.GetTempFileName();
                axScanCtrl1.Scan(_tmpname); //传的参数就是存储路径
                proPictureBox1.Image = GlobalUtils.LoadImageFromFileNoBlock(_tmpname);
                proPictureBox1.BringToFront();
                button6.Text = "重新拍照";
                btnSave.Enabled = true;
            }
            else
            {
                axScanCtrl1.BringToFront();
                button6.Text = "拍照";
                btnSave.Enabled = false;
            }

        }

        #endregion

        #region combobox等事件
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            axScanCtrl1.SetVideoColor((short)comboBox5.SelectedIndex);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            axScanCtrl1.SetVideoRotate((short)comboBox4.SelectedIndex);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            axScanCtrl1.SetScanSize((short)comboBox3.SelectedIndex);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            axScanCtrl1.SetResolution((short)comboBox2.SelectedIndex);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            axScanCtrl1.SetCurDev((short)comboBox1.SelectedIndex);

            short i;

            comboBox2.Items.Clear();
            int iResCount = axScanCtrl1.GetResolutionCount();
            for (i = 0; i < iResCount; ++i)
            {
                short s1 = axScanCtrl1.GetResolutionWidth(i);
                short s2 = axScanCtrl1.GetResolutionHeight(i);
                string s = s1.ToString() + " * " + s2.ToString();
                comboBox2.Items.Add(s);
            }
            comboBox2.SelectedIndex = 0;

            comboBox3.Items.Clear();
            int iSize = axScanCtrl1.GetScanSizeCount();
            comboBox3.Items.Add("All");
            if (iSize > 1)
            {
                if (iSize == 8)
                {
                    comboBox3.Items.Add("A3");
                }
                comboBox3.Items.Add("A4");
                comboBox3.Items.Add("A5");
                comboBox3.Items.Add("A6");
                comboBox3.Items.Add("A7");
                comboBox3.Items.Add("名片");
                comboBox3.Items.Add("身份证");
            }
            comboBox3.Items.Add("自定义");
            comboBox3.SelectedIndex = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            axScanCtrl1.SetRotateCrop(checkBox1.Checked);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            axScanCtrl1.DelBackColor(checkBox2.Checked);
        }
        #endregion

        private void LoadWindow(object sender, EventArgs e)
        {
            #region 初始化控件
            short i;

            comboBox1.Items.Clear();
            int iDevCount = axScanCtrl1.GetDeviceCount();
            for (i = 0; i < iDevCount; ++i)
            {
                string s = axScanCtrl1.GetDevName(i);
                comboBox1.Items.Add(s);
            }
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            comboBox2.Items.Clear();
            int iResCount = axScanCtrl1.GetResolutionCount();
            for (i = 0; i < iResCount; ++i)
            {
                short s1 = axScanCtrl1.GetResolutionWidth(i);
                short s2 = axScanCtrl1.GetResolutionHeight(i);
                string s = s1.ToString() + " * " + s2.ToString();
                comboBox2.Items.Add(s);
            }
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;

            comboBox3.Items.Clear();
            int iSize = axScanCtrl1.GetScanSizeCount();
            comboBox3.Items.Add("All");
            if (iSize > 1)
            {
                if (iSize == 8)
                {
                    comboBox3.Items.Add("A3");
                }
                comboBox3.Items.Add("A4");
                comboBox3.Items.Add("A5");
                comboBox3.Items.Add("A6");
                comboBox3.Items.Add("A7");
                comboBox3.Items.Add("名片");
                comboBox3.Items.Add("身份证");
            }
            comboBox3.Items.Add("自定义");
            if (comboBox3.Items.Count > 0)
                comboBox3.SelectedIndex = 0;

            comboBox4.Items.Clear();
            comboBox4.Items.Add("0度");
            comboBox4.Items.Add("90度");
            comboBox4.Items.Add("180度");
            comboBox4.Items.Add("270度");
            comboBox4.SelectedIndex = 0;

            comboBox5.Items.Clear();
            comboBox5.Items.Add("彩色");
            comboBox5.Items.Add("灰度");
            comboBox5.Items.Add("黑白");
            comboBox5.SelectedIndex = 0;
            #endregion
            //初始化控件
            txtPicPath.Text = GlobalUtils.LocalPassportPicPath;
            txtPicPath.Enabled = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            btnSave.Enabled = false;

            axScanCtrl1.StartPreview();

        }
        //private void LoadImageFromModel(Model.VisaInfo model)
        //{
        //    if (proPictureBox1.Image != null)
        //        proPictureBox1.Image.Dispose();

        //    if (_list[_curIdx] == null)
        //    {
        //        proPictureBox1.Image = Resources.PassportPictureNotFound;
        //        return;
        //    }

        //    //if (!PassportPicHandler.CheckAndDownloadIfNotExist(model.PassportNo, PassportPicHandler.PicType.Type01Normal))
        //    //{
        //    //    proPictureBox1.Image = Resources.PassportPictureNotFound;
        //    //    return;
        //    //}
        //    //proPictureBox1.Image = GlobalUtils.LoadImageFromFileNoBlock(GlobalUtils.PassportPicPath + "\\" + model.PassportNo + ".jpg");
        //    if (File.Exists(txtPicPath.Text + "\\" + _list[_curIdx].Name + "_" + _list[_curIdx].PassportNo + ".jpg"))
        //        proPictureBox1.Image = Image.FromFile(txtPicPath.Text + "\\" + _list[_curIdx].Name + "_" + _list[_curIdx].PassportNo + ".jpg");
        //    else
        //        proPictureBox1.Image = Resources.PassportPictureNotFound;
        //}

        private void FrmScanCtrl_FormClosing(object sender, FormClosingEventArgs e)
        {
            axScanCtrl1.StopPreview();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PassportPicHandler.CopyToPassportPic(_tmpname,_model.PassportNo,PassportPicHandler.PicType.Type01Normal);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
