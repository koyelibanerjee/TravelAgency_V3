using System;
using System.IO;
using TravelAgency.Common;
using TravelAgency.Common.FTP;

namespace TravelAgency.BLL.FTPFileHandler
{
    public class OrderExcelHandler
    {
        private string _remotePath;
        private BLL.OrderExcel _bllOrderExcel = new BLL.OrderExcel();

        public OrderExcelHandler()
        {
            string path = AppSettingHandler.ReadConfig("OrderExcelPath");
            if (string.IsNullOrEmpty(path)) //如果没读到就返回默认值
            {
                AppSettingHandler.AddConfig("OrderExcelPath", "E:/东瀛假日订单管理系统/订单Excel保存路径");
                
                path = "E:/东瀛假日订单管理系统/订单Excel保存路径";
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

        public Model.OrderExcel UploadOrderExcel(string filename)
        {
            FtpHandler.ChangeFtpUri(RemoteRootPath);
            Model.OrderExcel model = new Model.OrderExcel();
            model.EntryTime = DateTime.Now;
            model.FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(filename);

            FtpHandler.Upload(filename, model.FileName);

            model.Id = _bllOrderExcel.Add(model);

            return model;
        }

        public void DownloadOrderExcel(string excelName,string dstPath)
        {
            FtpHandler.ChangeFtpUri(RemoteRootPath);
            FtpHandler.Download(dstPath, excelName);
        }
    }
}