using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgency.Common;
using TravelAgency.Common.FTP;

namespace TravelAgency.CSUI.Visa.FrmSub
{
    public partial class FrmUploadLocalImages : Form
    {
        public FrmUploadLocalImages()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
        }

        private void FrmUploadLocalImages_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

        }
        private void UploadThread()
        {
            this.Invoke(new Action(() =>
            {
                var localFileList = Directory.GetFiles(GlobalUtils.LocalPassportPicPath);

                progressBarX1.Value = 0;
                progressBarX1.Maximum = localFileList.Length;
                int notexist = 0;
                FtpHandler.ChangeFtpUri(ConfigurationManager.AppSettings["PassportPicPath"]);
                //var modellist = bllVisaInfo.GetModelList(string.Empty);
                for (int i = 0; i < localFileList.Length; i++)
                {
                    if (!FtpHandler.FileExist(Path.GetFileName(localFileList[i])))
                    {
                        FtpHandler.Upload(localFileList[i]);
                        notexist += 1;
                    }
                    //Thread.Sleep(30);
                    lbSuccess.Text = "已扫描" + (i + 1) + "张图像,找到并上传" + notexist + "张服务器不存在图像.";
                    progressBarX1.Value++;
                }
                MessageBoxEx.Show("上传" + notexist + "张图像成功!");
                this.Close();
            }));


        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            new Thread(UploadThread) { IsBackground = true }.Start();
        }
    }
}
