using System;
using System.IO;
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
                Logger.InfoFormat("Received File,Saved To:{0}", filename);
                fs.Close();
            }
        }

        public byte[] SndFile(string filename)
        {
            return File.ReadAllBytes(filename);
        }
    }

    class HProseFileTransferServer
    {
        public static ILog Logger = log4net.LogManager.GetLogger("HProseFileTransferServerLogger");
        static void Main(string[] args)
        {
            //HproseHttpListenerServer server = new HproseHttpListenerServer("http://127.0.0.1:50002/");
            HproseHttpListenerServer server = new HproseHttpListenerServer("http://0.0.0.0:50002/");

            TestService ts = new TestService();

            server.Add("RcvFile", ts);
            server.Add("SndFile", ts);
            server.Add("printHello", ts);
            server.Start();
            Logger.InfoFormat("Server Started At:{0}", DateTime.Now);
            Console.WriteLine("Server started.");
            Console.ReadLine();
            Logger.InfoFormat("Server Ended At:{0}", DateTime.Now);
            Console.WriteLine("Server stopped.");
        }
    }
}
