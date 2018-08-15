using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Hprose.Server;
using log4net;
using TravelAgency.Common;

namespace HProseFileTransferServer
{

    class TestService
    {
        public static ILog Logger = log4net.LogManager.GetLogger("HProseFileTransferServerLogger");
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
                Console.WriteLine("Received File,Saved To:{0}", filename);
                Logger.DebugFormat("Received File,Saved To:{0}", filename);
                fs.Close();
            }
        }

        public byte[] SndFile(string filename)
        {
            Console.WriteLine("SndFile :{0}", filename);
            Logger.DebugFormat("SndFile :{0}", filename);
            return File.ReadAllBytes(filename);
        }

        public List<string> GetDirList(string path)
        {
            Console.WriteLine("GetDirList of:{0}", path);
            Logger.DebugFormat("GetDirList of:{0}", path);
            if (!Directory.Exists(path))
                return null;
            var arr = Directory.GetFiles(path);
            if (arr.Length == 0)
                return null;
            return arr.ToList();
        }


    }

    class HProseFileTransferServer
    {
        public static ILog Logger = log4net.LogManager.GetLogger("HProseFileTransferServerLogger");
        static void Main(string[] args)
        {
            HproseHttpListenerServer server = new HproseHttpListenerServer("http://127.0.0.1:50002/");
            //HproseHttpListenerServer server = new HproseHttpListenerServer("http://0.0.0.0:50002/");

            TestService ts = new TestService();

            server.Add("RcvFile", ts);
            server.Add("SndFile", ts);
            server.Add("GetDirList", ts);
            server.Add("printHello", ts);
            server.Start();
            Logger.DebugFormat("Server Started At:{0}", DateTime.Now);
            Console.WriteLine("Server started.");
            Console.ReadLine();
            Logger.DebugFormat("Server Ended At:{0}", DateTime.Now);
            Console.WriteLine("Server stopped.");
        }
    }
}
