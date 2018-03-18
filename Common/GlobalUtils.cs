using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web.SessionState;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Excel;
using log4net;
using TravelAgency.Common.FTP;
using TravelAgency.Common.Word;
using Application = System.Windows.Forms.Application;

namespace TravelAgency.Common
{

    public enum RigthLevel

    {
        Manager,
        Normal
    }
    public static class GlobalUtils
    {
        public static Model.AuthUser LoginUser;
        public static readonly DocDocxGenerator DocDocxGenerator;
        public static RigthLevel LoginUserLevel;
        public static ILog Logger = log4net.LogManager.GetLogger("DemoWriter");
        static GlobalUtils()
        {
            InitFtp();
            DocDocxGenerator = new DocDocxGenerator();

            //从配置文件读取log4net的配置，然后进行一个初始化工作。
            log4net.Config.XmlConfigurator.Configure();

        }

        private static void InitFtp()
        {
            //初始化FTP参数
            string ftpServer = ConfigurationManager.AppSettings["FTPServer"];
            string ftpUserId = ConfigurationManager.AppSettings["FtpUserID"];
            string ftpPassword = ConfigurationManager.AppSettings["FtpPassword"];
            string passportPics = ConfigurationManager.AppSettings["PassportPicPath"];
            FtpHandler.SetParams(ftpServer, passportPics, ftpUserId, ftpPassword);
        }

        public static string AppPath
        {
            get
            {
                return Application.StartupPath;
            }
        }

        /// <summary>
        /// 本地护照图像保存路径，暂时写死
        /// </summary>
        public static string LocalPassportPicPath
        {
            get
            {
                string res = Application.StartupPath + "\\" + "护照图像保存路径";
                if (!Directory.Exists(res))
                {
                    Directory.CreateDirectory(res);
                }
                return res;
            }
        }
        /// <summary>
        /// 本地高拍仪图像保存路径，暂时写死
        /// </summary>
        public static string LocalGaoPaiPicPath
        {
            get
            {
                string res = Application.StartupPath + "\\" + "高拍仪图像保存路径";
                if (!Directory.Exists(res))
                {
                    Directory.CreateDirectory(res);
                }
                return res;
            }
        }

        /// <summary>
        /// 缩略图比例
        /// </summary>
        public static double ThumbNailRatio
        {
            get { return 10.0; }
        }


        /// <summary>
        /// 返回openfileDialog的文件名
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="Filter"></param>
        /// <returns></returns>
        public static string ShowSaveFileDlg(string filename, string Filter = "图像文件|*.jpg")
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = Filter;
            saveFileDialog1.Title = "Save";
            if (!string.IsNullOrEmpty(filename))
                saveFileDialog1.FileName = filename;

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return null;

            if (!string.IsNullOrEmpty(saveFileDialog1.FileName))
                return saveFileDialog1.FileName;

            return null;
        }

        /// <summary>
        /// 返回openfileDialog的文件名
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="Filter"></param>
        /// <returns></returns>
        public static string ShowOpenFileDlg(string Filter = "图像文件|*.jpg")
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = Filter;
            openFileDialog.Title = "Open";

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return null;

            if (!string.IsNullOrEmpty(openFileDialog.FileName))
                return openFileDialog.FileName; //这里的FileName都是全路径

            return null;
        }

        public static string ShowBrowseFolderDlg()
        {
            //选择保存路径
            FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return null;
            return fbd.SelectedPath;
        }

        //加载后防止文件继续占用
        public static byte[] LoadFileToMemory(string filename)
        {
            FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            int byteLength = (int)fileStream.Length;
            byte[] fileBytes = new byte[byteLength];
            fileStream.Read(fileBytes, 0, byteLength);
            //文件流关闭,文件解除锁定
            fileStream.Close();
            return fileBytes;
        }

        /// <summary>
        /// 从stream加载图像
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static Image LoadImageFromStream(byte[] buffer)
        {
            return Image.FromStream(new MemoryStream(buffer));
        }

        /// <summary>
        /// 从stream加载图像
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static Image LoadImageFromFile(string filename)
        {
            return Image.FromFile(filename);
        }

        /// <summary>
        /// 从文件加载图像但是不占用文件
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Image LoadImageFromFileNoBlock(string filename)
        {
            return LoadImageFromStream(LoadFileToMemory(filename));
        }


        /// <summary>
        /// 检查数据库连接
        /// </summary>
        public static bool CheckDatabaseConnect()
        {
            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["mssql"].ConnectionString;
                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                con.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 弹出对话框提示x条成功x条失败。
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="succeded"></param>
        /// <param name="total"></param>
        public static void MessageBoxWithRecordNum(string operation, int succeded, int total)
        {
            if ((total - succeded) > 0)
                MessageBoxEx.Show(string.Format("{0}条记录{1}成功,{2}条记录{1}失败.", succeded, operation, total - succeded));
            else
                MessageBoxEx.Show(string.Format("{0}条记录{1}成功.", succeded, operation));
        }
    }
}