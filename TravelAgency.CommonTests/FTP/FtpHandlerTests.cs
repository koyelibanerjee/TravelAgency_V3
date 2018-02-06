using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Common.FTP;

namespace TravelAgency.Common.FTP.Tests
{
    [TestClass()]
    public class FtpHandlerTests
    {
        [TestMethod()]
        public void UploadTest()
        {
            FtpHandler.ChangeFtpUri(ConfigurationManager.AppSettings["PassportPicPath"]);
            string filename = GlobalUtils.ShowOpenFileDlg();
            FtpHandler.Upload(filename, "abc.jpg");
        }

        [TestMethod()]
        public void UploadTest1()
        {
            string filename = GlobalUtils.ShowOpenFileDlg();
            FtpHandler.Upload(filename);
        }
    }
}

namespace TravelAgency.Common.FTP.Testss
{
    [TestClass()]
    public class FtpHandlerTests
    {
        [TestMethod()]
        public void GetFileListTest()
        {

            //初始化FTP参数
            string ftpServer = ConfigurationManager.AppSettings["FTPServer"];
            string ftpUserId = ConfigurationManager.AppSettings["FtpUserID"];
            string ftpPassword = ConfigurationManager.AppSettings["FtpPassword"];
            string passportPics = ConfigurationManager.AppSettings["PassportPicPath"];
            FtpHandler.SetParams(ftpServer, passportPics, ftpUserId, ftpPassword);
            FtpHandler.ChangeFtpUri("E:/东瀛假日签证识别管理系统/高拍仪图像保存路径");
            List<string> lists = FtpHandler.GetFileList("*.*");
            FtpHandler.ChangeFtpUri("E:/东瀛假日签证识别管理系统/高拍仪图像保存路径" + "/" + lists[0]);
            lists = FtpHandler.GetFileList("*.*");



        }

        [TestMethod()]
        public void GetFilesDetailListTest()
        {
            //初始化FTP参数
            string ftpServer = ConfigurationManager.AppSettings["FTPServer"];
            string ftpUserId = ConfigurationManager.AppSettings["FtpUserID"];
            string ftpPassword = ConfigurationManager.AppSettings["FtpPassword"];
            string passportPics = ConfigurationManager.AppSettings["PassportPicPath"];
            FtpHandler.SetParams(ftpServer, passportPics, ftpUserId, ftpPassword);
            FtpHandler.ChangeFtpUri("E:/Program Files");
            //string[] lists = FtpHandler.GetFileList("*.*");
            FtpHandler.ChangeFtpUri("E:/东瀛假日签证识别管理系统/高拍仪图像保存路径");
            List<string> lists = FtpHandler.GetDirectoryList();
        }
    }
}
