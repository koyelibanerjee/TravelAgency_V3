﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TravelAgency.BLL.FTPFileHandler;
using TravelAgency.BLL.RPC;
using TravelAgency.Common;
using TravelAgency.Model;

namespace ScanCtrlTest
{
    public partial class FrmTackePicture : Form
    {
        private GaopaiPicHandler _gaopaiPicHandler = new GaopaiPicHandler(GaopaiPicHandler.PictureType.Type01_Normal);
        private GaopaiPicHandler _jiaojiePicHandler = new GaopaiPicHandler(GaopaiPicHandler.PictureType.Type02_JiaoJie);
        private bool _add2Visa = false;
        private TravelAgency.Model.Visa _visaModel = new Visa();

        string _types = "未分类";
        public FrmTackePicture()
        {
            InitializeComponent();
        }

        public FrmTackePicture(TravelAgency.Model.Visa model) : this()
        {
            _add2Visa = true;
            _visaModel = model;
        }

        #region 按钮事件
        /// <summary>
        /// 开始预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            axScanCtrl1.StartPreview();
        }

        /// <summary>
        /// 关闭视频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button2_Click(object sender, EventArgs e)
        {
            axScanCtrl1.StopPreview();
        }

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
        /// 拍照按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textBox1.Text))
                Directory.CreateDirectory(textBox1.Text);
            string filename = textBox1.Text + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            bool needSyncImage = GlobalUtils.LoginUser.District != 0;
            axScanCtrl1.Scan(filename); //传的参数就是存储路径

            if (_add2Visa)
            {
                _gaopaiPicHandler.UploadGaoPaiImageAsyncForVisa(new List<string> { filename, _visaModel.Visa_id.ToString() });


                new Thread(UpdateLable) { IsBackground = true }.Start(DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg 保存成功.");

                PicHandler.MakeThumbnail(filename, _gaopaiPicHandler.GetThumbName(filename), GlobalUtils.ThumbNailRatio);
                _gaopaiPicHandler.UploadGaoPaiImageAsyncForVisa(new List<string> { _gaopaiPicHandler.GetThumbName(filename), _visaModel.Visa_id.ToString() });
                if (needSyncImage)
                {
                    HproseClient.UploadImage(HproseClient.ImageType.type04GaopaiVisa, filename,
                        _visaModel.Visa_id.ToString());
                    HproseClient.UploadImage(HproseClient.ImageType.type04GaopaiVisa,
                        _gaopaiPicHandler.GetThumbName(filename), _visaModel.Visa_id.ToString());
                }
            }
            else
            {
                string savePrefix = "";
                if (filename.Contains("thumb_"))
                    savePrefix += Path.GetFileName(filename).Substring(6, 8);
                else
                    savePrefix += Path.GetFileName(filename).Substring(0, 8); //日期的文本 20180304
                //再上传到服务器端
                if (rbtnGaoPai.Checked)
                {
                    _gaopaiPicHandler.UploadGaoPaiImageAsync(new List<string> { filename, _types });
                    if (needSyncImage)
                        HproseClient.UploadImage(HproseClient.ImageType.type02Gaopai, filename,
                            savePrefix + (_types == "未分类" ? "" : "/" + _types));
                }
                else
                {
                    _jiaojiePicHandler.UploadGaoPaiImageAsync(new List<string> { filename, _types });
                    if (needSyncImage)
                        HproseClient.UploadImage(HproseClient.ImageType.type03Jiaojie, filename,
                       savePrefix);
                }

                new Thread(UpdateLable) { IsBackground = true }.Start(DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg 保存成功.");
                PicHandler.MakeThumbnail(filename, _gaopaiPicHandler.GetThumbName(filename), GlobalUtils.ThumbNailRatio);

                //再上传缩略图到服务器端
                if (rbtnGaoPai.Checked)
                {
                    _gaopaiPicHandler.UploadGaoPaiImageAsync(new List<string>
                    {
                        _gaopaiPicHandler.GetThumbName(filename),
                        _types
                    });
                    if (needSyncImage)
                        HproseClient.UploadImage(HproseClient.ImageType.type02Gaopai, _gaopaiPicHandler.GetThumbName(filename),
                        savePrefix + (_types == "未分类" ? "" : "/" + _types));
                }
                else
                {
                    _jiaojiePicHandler.UploadGaoPaiImageAsync(new List<string> { _gaopaiPicHandler.GetThumbName(filename), _types });
                    if (needSyncImage)
                        HproseClient.UploadImage(HproseClient.ImageType.type03Jiaojie, _gaopaiPicHandler.GetThumbName(filename),
                       savePrefix);
                }
            }
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
        #endregion

        private void UpdateLable(Object o)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    lbSuccess.Text = o as string;

                }));
            }
            Thread.Sleep(500);

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    lbSuccess.Text = "待机中...";
                }));

            }
        }

        private void LoadWindow(object sender, EventArgs e)
        {
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


            rbtnGaoPai.Checked = true;
            rbtn未分类.Checked = true;

            if (!_add2Visa)
                textBox1.Text = GlobalUtils.LocalGaoPaiPicPath + "\\" + DateTime.Now.ToString("yyyyMMdd");
            else
            {
                panel1.Enabled = false;
                panel2.Enabled = false;
                textBox1.Text = GlobalUtils.LocalGaoPaiPicPath + "\\" + _visaModel.Visa_id.ToString();
            }

        }

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

        private void btnOpenSavePath_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textBox1.Text))
                Directory.CreateDirectory(textBox1.Text);
            Process.Start(textBox1.Text);
        }

        private void btnChoosePath_Click(object sender, EventArgs e)
        {
            string str = GlobalUtils.ShowBrowseFolderDlg();
            if (!string.IsNullOrEmpty(str))
                textBox1.Text = str;
        }

        private void rbtnGaoPai_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = GlobalUtils.LocalGaoPaiPicPath + "\\" + DateTime.Now.ToString("yyyyMMdd");
            panel2.Enabled = true;

        }

        private void rbtnJiaojie_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = GlobalUtils.LocalJiaojiePicPath + "\\" + DateTime.Now.ToString("yyyyMMdd");
            _types = "未分类";
            rbtn未分类.Checked = true;
            panel2.Enabled = false;
        }

        private void rbtn未分类_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = GlobalUtils.LocalGaoPaiPicPath + "\\" + DateTime.Now.ToString("yyyyMMdd");
            _types = "未分类";
        }

        private void rbtn个签_CheckedChanged(object sender, EventArgs e)
        {
            _types = "个签";
            textBox1.Text = GlobalUtils.LocalGaoPaiPicPath + "\\" + DateTime.Now.ToString("yyyyMMdd") + "\\个签";
        }

        private void rbtn团签_CheckedChanged(object sender, EventArgs e)
        {
            _types = "团签";
            textBox1.Text = GlobalUtils.LocalGaoPaiPicPath + "\\" + DateTime.Now.ToString("yyyyMMdd") + "\\团签";
        }

        private void rbtn团做个_CheckedChanged(object sender, EventArgs e)
        {
            _types = "团做个";
            textBox1.Text = GlobalUtils.LocalGaoPaiPicPath + "\\" + DateTime.Now.ToString("yyyyMMdd") + "\\团做个";
        }
    }
}
