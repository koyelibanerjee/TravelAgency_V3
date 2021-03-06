﻿using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using DevComponents.DotNetBar;
using NPOI.SS.Formula.PTG;
using TravelAgency.BLL.RPC;
using TravelAgency.Common;
using TravelAgency.Common.FTP;

namespace TravelAgency.BLL.FTPFileHandler
{
    /// <summary>
    /// 这个类用于导出护照图像
    /// </summary>
    public class PassportPicHandler
    {
        [Flags]
        public enum PicType
        {
            Type01Normal = 0x01,
            Type02Head = 0x02,
            Type03IR = 0x04
        }


        /// <summary>
        /// 复制指定图像到护照存储目录
        /// </summary>
        /// <param name="passportNo"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static void CopyToPassportPic(string srcFileName, string passportNo, PicType type)
        {
            string picfileName = GetFileName(passportNo, type);
            string dstFileName = GlobalUtils.LocalPassportPicPath + "\\" + picfileName;
            File.Copy(srcFileName, dstFileName);
        }

        /// <summary>
        /// 复制指定图像到护照存储目录
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="passportNo"></param>
        /// <returns></returns>
        public static bool UploadPassportPic(string filename, string passportNo)
        {
            FtpHandler.ChangeFtpUri(ConfigurationManager.AppSettings["PassportPicPath"]);
            FtpHandler.Upload(filename, GetFileName(passportNo, PicType.Type01Normal));
            if (!FtpHandler.FileExist(GetFileName(passportNo, PicType.Type01Normal)))
            {
                GlobalUtils.Logger.Error($"护照{passportNo},上传图像失败");
                MessageBoxEx.Show($"护照{passportNo},上传图像失败，请手动上传或请联系技术人员!");
                return false;
            }
            if (GlobalUtils.LoginUser.District != 0)
                RPC.HproseClient.UploadImage(HproseClient.ImageType.type01Passport, filename, passportNo);
            return true;
        }


        /// <summary>
        /// 删除指定护照号文件
        /// </summary>
        /// <param name="passportNo"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static void DeleteLocalPassportPic(string passportNo, PicType type)
        {
            //FtpHandler.ChangeFtpUri(ConfigurationManager.AppSettings["PassportPicPath"]);
            //FtpHandler.Delete();
            string fileName = GetFileName(passportNo, type);
            string picName = GlobalUtils.LocalPassportPicPath + "\\" + fileName;
            File.Delete(picName); //文件不存在是不会报异常的
        }


        /// <summary>
        /// 删除指定护照号文件
        /// </summary>
        /// <param name="passportNo"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool DeleteRemotePassportPic(string passportNo, PicType type)
        {
            FtpHandler.ChangeFtpUri(ConfigurationManager.AppSettings["PassportPicPath"]);
            return FtpHandler.Delete(GetFileName(passportNo, type));
        }


        public static bool CheckLocalExist(string passportNo, PicType type)
        {
            string fileName = GetFileName(passportNo, type);
            string picName = GlobalUtils.LocalPassportPicPath + "\\" + fileName;
            return File.Exists(picName);

        }

        public static bool CheckRemoteExist(string passportNo, PicType type)
        {
            FtpHandler.ChangeFtpUri(ConfigurationManager.AppSettings["PassportPicPath"]);
            return FtpHandler.FileExist(GetFileName(passportNo, type));
        }

        public static bool CheckAndDownloadIfNotExist(string passportNo, PicType type)
        {
            FtpHandler.ChangeFtpUri(ConfigurationManager.AppSettings["PassportPicPath"]);
            string fileName = GetFileName(passportNo, type);
            if (CheckLocalExist(passportNo, type)) //先检查本地是否存在
                return true;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (FtpHandler.FileExist(fileName) &&
                FtpHandler.Download(GlobalUtils.LocalPassportPicPath, fileName))
                return true;
            return false;
        }

        public static string GetFileName(string passportNo, PicType type)
        {
            string fileprefix = passportNo;
            if (type == PicType.Type02Head)
                fileprefix += "Head";
            if (type == PicType.Type03IR)
                fileprefix += "IR";
            return fileprefix + ".jpg";
        }

        /// <summary>
        /// 下载指定护照的指定类型图像
        /// </summary>
        /// <param name="passportNo"></param>
        /// <param name="type"></param>
        /// <param name="dstname"></param>
        /// <returns></returns>
        public static bool DownloadPic(string passportNo, PicType type, string dstname, bool hintWhenNotExist = true)
        {
            if (!CheckAndDownloadIfNotExist(passportNo, type))
            {
                if (hintWhenNotExist)
                    MessageBoxEx.Show("找不到指定图像!");
                return false;
            }
            string fileName = GetFileName(passportNo, type);
            if (string.IsNullOrEmpty(dstname))
                return false;
            if (!File.Exists(dstname))
                File.Copy(GlobalUtils.LocalPassportPicPath + "\\" + fileName, dstname);
            return true;
        }



        /// <summary>
        /// 批量下载护照指定类型图像
        /// </summary>
        /// <param name="passportNo"></param>
        /// <param name="type"></param>
        /// <param name="dstname"></param>
        /// <returns></returns>
        public static int DownloadPicBatch(string[] passportNoList, PicType type, string dstPath, bool hintWhenNotExist = true)
        {
            int res = 0;
            for (int i = 0; i < passportNoList.Length; i++)
            {
                string fileName = GetFileName(passportNoList[i], type);
                if (DownloadPic(passportNoList[i], type, dstPath + "\\" + fileName, hintWhenNotExist))
                    ++res;
            }
            return res;
        }


        /// <summary>
        /// 下载指定护照的全部类型图像
        /// </summary>
        /// <param name="passportNo"></param>
        /// <returns></returns>
        public static int DownloadSelectedTypes(string passportNo, string dstPath, PicType type = PicType.Type01Normal | PicType.Type02Head | PicType.Type03IR)
        {
            int res = 0;
            int expected = 0; //现在没用，先保留，以后用
            if (string.IsNullOrEmpty(dstPath))
                return 0;
            if (type.HasFlag(PicType.Type01Normal))
            {
                if (CheckAndDownloadIfNotExist(passportNo, PicType.Type01Normal))
                {
                    if (DownloadPic(passportNo, PicType.Type01Normal, dstPath + "\\" + GetFileName(passportNo, PicType.Type01Normal)))
                        ++res;
                }
                ++expected;
            }

            if (type.HasFlag(PicType.Type02Head))
            {
                if (CheckAndDownloadIfNotExist(passportNo, PicType.Type02Head))
                {
                    if (DownloadPic(passportNo, PicType.Type02Head, dstPath + "\\" + GetFileName(passportNo, PicType.Type02Head)))
                        ++res;
                }
                ++expected;
            }

            if (type.HasFlag(PicType.Type03IR))
            {
                if (CheckAndDownloadIfNotExist(passportNo, PicType.Type03IR))
                {
                    if (DownloadPic(passportNo, PicType.Type03IR, dstPath + "\\" + GetFileName(passportNo, PicType.Type03IR)))
                        ++res;
                }
                ++expected;
            }

            return res;
            //if (res > 0)
            //{
            //    if (showConfirm)
            //        if (MessageBoxEx.Show("保存成功，是否打开所在文件夹?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //            Process.Start(dstPath);
            //    return res;
            //}
            //if (showConfirm)
            //    MessageBoxEx.Show("保存失败");
            //return 0;
        }


        /// <summary>
        /// 批量下载指定护照的全部类型图像
        /// </summary>
        /// <param name="passportNo"></param>
        /// <returns></returns>
        public static int DownloadSelectedTypesBatch(string[] passportNoList, string dstPath, PicType type = PicType.Type01Normal | PicType.Type02Head | PicType.Type03IR)
        {
            int res = 0;
            for (int i = 0; i < passportNoList.Length; i++)
            {
                res += DownloadSelectedTypes(passportNoList[i], dstPath, type);
            }
            return res;
        }



    }
}