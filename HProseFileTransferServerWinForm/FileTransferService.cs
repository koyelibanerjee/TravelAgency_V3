using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HProseFileTransferServer;

namespace HProseFileTransferServerWinForm
{
    class FileTransferService
    {
        public string printHello(int i)
        {
            return $"hello:{i}";
        }

        //Client类稍微比TcpClient类麻烦一点
        public void RcvFile(byte[] filedata, string filename)
        {
            if (!Directory.Exists(Path.GetDirectoryName(filename)))
                Directory.CreateDirectory(Path.GetDirectoryName(filename)); //C# 支持直接递归创建
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                fs.Write(filedata, 0, filedata.Length);
                //Console.WriteLine("Received File,Saved To:{0}", filename);
                GlobalUtils.MainFrm.AddLvItem(DateTime.Now.ToString(),"上传文件",filename,"成功");
                LogService.Logger.DebugFormat("Received File,Saved To:{0}", filename);
                fs.Close();
            }
        }

        public byte[] SndFile(string filename)
        {
            //Console.WriteLine("SndFile :{0}", filename);
            LogService.Logger.DebugFormat("SndFile :{0}", filename);
            GlobalUtils.MainFrm.AddLvItem(DateTime.Now.ToString(), "下载文件", filename, "成功");
            return File.ReadAllBytes(filename);
        }

        public List<string> GetDirList(string path)
        {
            //Console.WriteLine("GetDirList of:{0}", path);
            GlobalUtils.MainFrm.AddLvItem(DateTime.Now.ToString(), "取文件列表", path, "成功");
            LogService.Logger.DebugFormat("GetDirList of:{0}", path);
            if (!Directory.Exists(path))
                return null;
            var arr = Directory.GetFiles(path);
            if (arr.Length == 0)
                return null;
            return arr.ToList();
        }
    }
}
