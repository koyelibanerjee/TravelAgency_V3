﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace TravelAgency.AutoUpdate.Common
{
    public static class GlobalUtils
    {
        
        static GlobalUtils()
        {
            InitFtp();
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

        public static string PassportPicPath
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
        /// 返回openfileDialog的文件名
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="Filter"></param>
        /// <returns></returns>
        public static string OpenSaveFileDlg(string filename, string Filter = "图像文件|*.jpg")
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = Filter;
            saveFileDialog1.Title = "Save";
            if (!string.IsNullOrEmpty(filename))
                saveFileDialog1.FileName = filename;

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return null;

            if (saveFileDialog1.FileName != "")
                return saveFileDialog1.FileName;

            return null;
        }

        public static string OpenBrowseFolderDlg()
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


    }
}