using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using DevComponents.DotNetBar;
using NPOI.SS.Formula.Functions;
using TravelAgency.Common.FTP;

namespace TravelAgency.Common.PictureHandler
{
    public class OrderFilesHandler
    {
        private string _remotePath;
        private BLL.OrderFiles _bllOrderFiles = new BLL.OrderFiles();

        public OrderFilesHandler()
        {
            string path = AppSettingHandler.ReadConfig("OrderFilesPath");
            if (string.IsNullOrEmpty(path)) //如果没读到就返回默认值
            {
                AppSettingHandler.AddConfig("OrderFilesPath", "E:/东瀛假日订单管理系统/订单文件保存路径");
                
                path = "E:/东瀛假日订单管理系统/订单文件保存路径";
            }
            //if (!Directory.Exists(path))
            //    Directory.CreateDirectory(path);
            RemoteRootPath = path;
        }
        public string RemoteRootPath
        {
            get { return _remotePath; }
            private set { _remotePath = value; }
        }

        public Model.OrderFiles UploadOrderFile(string filename,int orderId)
        {
            FtpHandler.ChangeFtpUri(RemoteRootPath);
            Model.OrderFiles model = new Model.OrderFiles();
            model.EntryTime = DateTime.Now;
            model.FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(filename);
            model.OrdersId = orderId;
            model.OrigFileName = Path.GetFileName(filename);
            FtpHandler.Upload(filename, model.FileName);

            model.Id = _bllOrderFiles.Add(model);
            return model;
        }

        public void DownloadOrderFiles(Model.Orders orderModel)
        {
            var fileList = _bllOrderFiles.GetModelList(string.Format(" OrdersId = {0}", orderModel.Id));
            if (fileList.Count < 1)
            {
                MessageBoxEx.Show("未找到对应文件!");
                return;
            }
            string dstPath = GlobalUtils.ShowBrowseFolderDlg();
            if (string.IsNullOrEmpty(dstPath))
                return;

            FtpHandler.ChangeFtpUri(RemoteRootPath);
            for (int i = 0; i < fileList.Count; ++i)
            {
                FtpHandler.Download(dstPath,fileList[i].FileName);
                File.Move(dstPath + "/" + fileList[i].FileName, dstPath + "/" + fileList[i].OrigFileName);
            }

            MessageBoxEx.Show("下载文件成功!");
            Process.Start(dstPath);

        }
    }
}