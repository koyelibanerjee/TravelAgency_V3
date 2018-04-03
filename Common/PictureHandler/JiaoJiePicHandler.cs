﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Threading;
using NPOI.SS.Formula.Functions;
using TravelAgency.Common.FTP;

namespace TravelAgency.Common.PictureHandler
{
    public static class JiaoJiePicHandler
    {
        public static string RemoteRootPath
        {
            get
            {
                string path = AppSettingHandler.ReadConfig("JiaoJiePicPath");
                if (string.IsNullOrEmpty(path)) //如果没读到就返回默认值
                {
                    AppSettingHandler.AddConfig("JiaoJiePicPath", "E:/东瀛假日签证识别管理系统/交接图像保存路径");
                    return "E:/东瀛假日签证识别管理系统/交接图像保存路径";
                }
                return path;
            }
        }


        public static List<string> GetFolderList()
        {
            FtpHandler.ChangeFtpUri(RemoteRootPath);
            var list = FtpHandler.GetDirectoryList();
            return list;
        }



        /// <summary>
        /// 获取指定年
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static List<string> GetFolderList(int year)
        {
            var list = GetFolderList();
            string strYear = year.ToString();
            if (strYear.Length < 4 && strYear.Length == 2)
                strYear = "20" + strYear;

            for (int i = list.Count - 1; i >= 0; --i)
            {
                if (list[i].Substring(0, 4) != year.ToString())
                {
                    list.Remove(list[i]);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取指定年指定月
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static List<string> GetFolderList(int year, int month)
        {
            var list = GetFolderList(year);
            string strMonth = month.ToString("D2");
            for (int i = list.Count - 1; i >= 0; --i)
            {
                if (list[i].Substring(4, 2) != strMonth)
                {
                    list.Remove(list[i]);
                }
            }
            return list;
        }

        /// <summary>
        /// 获取指定某一天的所有文件列表（不包含缩略图）
        /// </summary>
        /// <param name="date"></param>
        public static List<string> GetFileListByDate(DateTime date)
        {
            //初始化FTP参数(在Common的静态构造函数中做了)
            FtpHandler.ChangeFtpUri(RemoteRootPath + "/" + date.ToString("yyyyMMdd"));
            List<string> list = FtpHandler.GetFileList("*.*");
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i].Contains("thumb"))
                    list.RemoveAt(i);
            }
            return list;
        }



        /// <summary>
        /// 返回当前根目录下所有文件夹，按照月份分组
        /// </summary>
        /// <returns></returns>
        public static List<List<string>> GetFolderListGroupByMonth()
        {
            var list = GetFolderList();
            return GroupListByMonth(list);
        }

        /// <summary>
        /// 把传入的list按照年份月份分组
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<List<string>> GroupListByMonth(List<string> list)
        {
            if (list == null || list.Count == 0)
                return null;
            SortedSet<string> set = new SortedSet<string>();
            foreach (var str in list)
            {
                set.Add(str.Substring(0, 6));
            }

            List<List<string>> res = new List<List<string>>();
            foreach (string yyyymm in set)
            {
                List<string> yyyymmGroup = new List<string>();
                foreach (var str in list)
                {
                    if (str.Substring(0, 6).Equals(yyyymm))
                    {
                        yyyymmGroup.Add(str);
                    }
                }
                res.Add(yyyymmGroup);
            }
            return res;
        }

        /// <summary>
        /// 传入文件名格式: 20171228/xxxx.jpg
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Image GetJiaoJieImage(string filename)
        {
            //string path = Path.GetDirectoryName(filename);
            //FtpHandler.Download()\
            FtpHandler.ChangeFtpUri(RemoteRootPath);
            if (!CheckLocalExist(filename))
            {
                if (!FtpHandler.Download(GlobalUtils.LocalJiaojiePicPath, filename)) //就不检查存在与否了，直接看下载成功没有
                    return null;
            }
            return GlobalUtils.LoadImageFromFileNoBlock(GlobalUtils.LocalJiaojiePicPath + "\\" + filename);
        }

        /// <summary>
        /// 传入文件名格式: 20171228/xxxx.jpg
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static void DownloadJiaoJieImage(string filename, string savefilename)
        {
            GetJiaoJieImage(filename).Save(savefilename);
        }

        /// <summary>
        /// 传入文件名格式: 20171228/xxxx.jpg
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static void DownloadJiaoJieImageBatch(List<string> filenames, string savePath)
        {
            if (string.IsNullOrEmpty(savePath))
                return;
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            for (int i = 0; i < filenames.Count; i++)
            {
                GetJiaoJieImage(filenames[i]).Save(savePath + "\\" + Path.GetFileName(filenames[i]));
            }
        }

        /// <summary>
        /// 有路径和没路径的都支持
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string GetThumbName(string filename)
        {
            string dstName = "thumb_" + Path.GetFileName(filename);
            string path = Path.GetDirectoryName(filename);
            if (filename.Contains("\\"))
            {
                return path + "\\" + dstName;
            }
            if (filename.Contains("/"))
            {

                return path + "/" + dstName;
            }
            return dstName;
        }


        /// <summary>
        /// 检查本地是否存在，
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool CheckLocalExist(string filename)
        {
            string picName = GlobalUtils.LocalJiaojiePicPath + "\\" + filename;
            return File.Exists(picName);
        }

        public static void UploadJiaoJieImageAsync(string filename)
        {
            new Thread(UploadJiaoJieImage) { IsBackground = true }.Start(filename);
        }

        public static void UploadJiaoJieImage(object filename)
        {
            UploadJiaoJieImage((string)filename);
        }


        public static void UploadJiaoJieImage(string filename)
        {
            string savePrefix = "";
            if (filename.Contains("thumb_"))
            {
                savePrefix = Path.GetFileName(filename).Substring(6, 8);
            }
            else
            {
                savePrefix = Path.GetFileName(filename).Substring(0, 8);
            }
            FtpHandler.ChangeFtpUri(RemoteRootPath);
            if (!FtpHandler.DirectoryExist(savePrefix))
            {
                FtpHandler.MakeDir(savePrefix);
            }
            FtpHandler.ChangeFtpUri(RemoteRootPath + "/" + savePrefix);
            FtpHandler.Upload(filename);
        }

        //public static bool CheckAndDownloadIfNotExist(string passportNo, PassportPicHandler.PicType type)
        //{
        //    FtpHandler.ChangeFtpUri(ConfigurationManager.AppSettings["PassportPicPath"]);
        //    string fileName = GetFileName(passportNo, type);
        //    if (CheckLocalExist(passportNo, type)) //先检查本地是否存在
        //        return true;

        //    if (FtpHandler.FileExist(fileName))
        //        if (FtpHandler.Download(GlobalUtils.LocalPassportPicPath, fileName))
        //        {
        //            return true;
        //        }
        //    return false;
        //}


    }
}