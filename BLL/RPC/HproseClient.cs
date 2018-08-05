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
            type01Passport
            //type02Gaopai,
            //type03Jiaojie
        }


        public static string RemoteHproseAddr => AppSettingHandler.ReadConfig("HproseServer");

        private static string remotePassportPicPath => AppSettingHandler.ReadConfig("PassportPicPath");

        private static string remoteGaopaiPicPath => AppSettingHandler.ReadConfig("GaopaiPicPath");

        private static string remoteJiaoJiePicPath => AppSettingHandler.ReadConfig("JiaoJiePicPath");

        private static readonly HproseHttpClient _hproseclient = new HproseHttpClient(RemoteHproseAddr);
        private static string _uploadCall = "RcvFile";


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
                    //case ImageType.type02Gaopai:
                    //    dstName = remoteGaopaiPicPath;
                    //    break;
                    //case ImageType.type03Jiaojie:
                    //    dstName = remoteJiaoJiePicPath;
                    //    break;
            }

            _hproseclient.Invoke(_uploadCall, new object[] { data, dstName });
        }
    }
}
