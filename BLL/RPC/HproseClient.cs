using System;
using System.Collections.Generic;
using System.Configuration;
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
            type03Jiaojie
        }


        public static string RemoteHproseAddr
        {
            get { return AppSettingHandler.ReadConfig("HproseServer"); }
        }

        private static string remotePassportPicPath
        {
            get { return AppSettingHandler.ReadConfig("PassportPicPath"); }
        }
        private static string remoteGaopaiPicPath
        {
            get { return AppSettingHandler.ReadConfig("GaopaiPicPath"); }
        }

        private static string remoteJiaoJiePicPath
        {
            get { return AppSettingHandler.ReadConfig("JiaoJiePicPath"); }
        }

        public static HproseHttpClient _hproseclient = new HproseHttpClient(RemoteHproseAddr);
        private static string _uploadCall = "RcvFile";


        public static void UploadImage(ImageType type, string filename)
        {
            var data = File.ReadAllBytes(filename);
            string nameNoPath = Path.GetFileName(filename);
            string dstName = "";
            switch (type)
            {
                case ImageType.type01Passport:
                    dstName = remotePassportPicPath;
                    break;
                case ImageType.type02Gaopai:
                    dstName = remoteGaopaiPicPath;
                    break;
                case ImageType.type03Jiaojie:
                    dstName = remoteJiaoJiePicPath;
                    break;
            }
            dstName += "/" + nameNoPath;
            _hproseclient.Invoke(_uploadCall, new object[] { data, dstName });
        }
    }
}
