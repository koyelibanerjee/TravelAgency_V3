using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hprose.Client;
using TravelAgency.Common;

namespace TravelAgency.BLL.RPC
{
    public class HproseClient
    {
        public enum ImageType
        {
            type01Passport,
            type02Gaopai,
            type03Jiaojie,
            type04GaopaiVisa
        }


        public static string RemoteHproseAddr => AppSettingHandler.ReadConfig("HproseServer");

        private static string remotePassportPicPath => AppSettingHandler.ReadConfig("PassportPicPath");

        private static string remoteGaopaiPicPath => AppSettingHandler.ReadConfig("GaopaiPicPath");

        private static string remoteJiaoJiePicPath => AppSettingHandler.ReadConfig("JiaoJiePicPath");

        private static readonly HproseHttpClient _hproseclient = new HproseHttpClient(RemoteHproseAddr);
        private static string _uploadFileCall = "RcvFile";
        private static string _listDirCall = "GetDirList";
        private static string _sndFileCall = "SndFile";


        /// <summary>
        /// 上传图片，type，filename指定本地文件名，args如果type是护照图像，指定护照号
        /// </summary>
        /// <param name="type"></param>
        /// <param name="filename"></param>
        /// <param name="args"></param>
        public static void UploadImage(ImageType type, string filename, object args)
        {
            var data = File.ReadAllBytes(filename);
            //string nameNoPath = Path.GetFileName(filename);
            string dstName = "";
            switch (type)
            {
                case ImageType.type01Passport:
                    dstName = remotePassportPicPath;
                    dstName += "/" + (string)args + ".jpg";
                    break;
                case ImageType.type02Gaopai: //高拍仪图像就是
                    dstName = remoteGaopaiPicPath;
                    dstName += "/" + (string)args + "/" + Path.GetFileName(filename); //args可能是 20180808/团签 这种
                    break;
                case ImageType.type03Jiaojie:
                    dstName = remoteJiaoJiePicPath;
                    dstName += "/" + (string)args + "/" + Path.GetFileName(filename); //可能是 20180808 这种
                    break;

                case ImageType.type04GaopaiVisa:
                    dstName = remoteGaopaiPicPath;
                    dstName += "/" + (string)args + "/" + Path.GetFileName(filename); //可能是 visa_id 这种
                    break;
            }

            _hproseclient.Invoke(_uploadFileCall, new object[] { data, dstName });
        }


        /// <summary>
        /// 返回的是全路径
        /// </summary>
        /// <param name="visaid"></param>
        /// <returns></returns>
        public static List<string> GetVisaGaopaiList(string visaid)
        {
            List<string> list = _hproseclient.Invoke<List<string>>(_listDirCall, new object[] { remoteGaopaiPicPath + "/" + visaid });
            if (list == null || list.Count == 0)
                return null;

            for (int i = list.Count - 1; i >= 0; --i)
            {
                list[i] = Path.GetFileName(list[i]);
                if (list[i].Contains("thumb"))
                    list.RemoveAt(i);
            }
            if (list == null || list.Count == 0)
                return null;
            return list;
        }

        /// <summary>
        /// 传入实例:visa_id/imagename.jpg
        /// </summary>
        /// <param name="prefixAndName"></param>
        /// <returns></returns>
        public static Image GetGaopaiImageOfVisa(string prefixAndName)
        {
            string localname = GlobalUtils.LocalGaoPaiPicPath + "/" + prefixAndName;
            if (File.Exists(localname))
                return Image.FromFile(localname);

            byte[] imagedata =
                _hproseclient.Invoke<byte[]>(_sndFileCall, new object[] { remoteGaopaiPicPath + "/" + prefixAndName });
            if (!Directory.Exists(Path.GetDirectoryName(localname)))
                Directory.CreateDirectory(Path.GetDirectoryName(localname));
            File.WriteAllBytes(localname, imagedata);
            return Image.FromFile(localname);
        }


        /// <summary>
        /// 例子:
        /// </summary>
        /// <param name="prefixAndName">visa_id/imagename.jpg</param>
        /// <param name="dstPath">E:/folder1/</param>
        public static void DownloadGaopaiImageOfVisa(string remotefilename,string dstPath)
        {
            byte[] imagedata =
                _hproseclient.Invoke<byte[]>(_sndFileCall, new object[] { remotefilename });
            if (!Directory.Exists(Path.GetDirectoryName(dstPath)))
                Directory.CreateDirectory(Path.GetDirectoryName(dstPath));
            File.WriteAllBytes(dstPath + "/" + Path.GetFileName(remotefilename), imagedata);
        }

    }
}
