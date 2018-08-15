using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.BLL.FTPFileHandler;
using TravelAgency.BLL.RPC;
using TravelAgency.Common;
using TravelAgency.Common.FTP;

namespace TravelAgency.CSUI.Visa.FrmSub
{
    public partial class FrmDownloadPics : Form
    {
        private string _dstPath;
        private string _visaid;
        private bool _local = false;
        private GaopaiPicHandler _gaopaiPicHandler;
        private HproseClient _hproseClient;
        private string remoteGaopaiPicPath = AppSettingHandler.ReadConfig("GaopaiPicPath");


        public FrmDownloadPics()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
        }

        public FrmDownloadPics(string dstPath, string visaid, bool local) : this()
        {
            //new GaopaiPicHandler().GetGaoPaiImage()
            _dstPath = dstPath;
            _visaid = visaid;
            _local = local;
        }

        private void FrmDownloadPics_Load(object sender, EventArgs e)
        {
            List<string> list = null;
            if (_local)
            {
                _gaopaiPicHandler = new GaopaiPicHandler(GaopaiPicHandler.PictureType.Type01_Normal);
                list = _gaopaiPicHandler.GetGaopaiImageListOfVisa(_visaid);

            }
            else
            {
               
                list = HproseClient.GetVisaGaopaiList(_visaid);
            }
            if (list == null || list.Count == 0)
                return;
            new Thread(DownloadPicsThread) { IsBackground = true }.Start(list);
        }


        private void DownloadPicsThread(object o)
        {
            List<string> list = o as List<string>;

            this.Invoke(new Action(() =>
            {
                progressBar1.Value = 0;
                progressBar1.Maximum = list.Count;
                this.labelX1.Text = $"正在下载第1/{list.Count}张图像.";
            }));



            if (!Directory.Exists(_dstPath))
                Directory.CreateDirectory(_dstPath);
            for (int i = 0; i < list.Count; i++)
            {
                if (_local)
                {
                    _gaopaiPicHandler.DownloadGaoPaiImage(_visaid + "/" + list[i], _dstPath + "/" + list[i]);
                }
                else
                {
                    HproseClient.DownloadGaopaiImageOfVisa(remoteGaopaiPicPath + "/" + _visaid + "/" + list[i], _dstPath);
                }

                this.Invoke(new Action(() =>
                {
                    progressBar1.Value = i + 1;
                    this.labelX1.Text = $"正在下载第{i + 1}/{list.Count}张图像.";
                }));
            }



            Process.Start(_dstPath);
            this.Invoke(new Action(() =>
            {
                Thread.Sleep(1000);
                this.Close();
            }));
        }
    }
}
