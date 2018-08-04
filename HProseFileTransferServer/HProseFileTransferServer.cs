using System;
using System.IO;
using Hprose.Server;

namespace HProseFileTransferServer
{

    class TestService
    {
        public string printHello(int i)
        {
            return $"hello:{i}";
        }

        //Client类稍微比TcpClient类麻烦一点
        public void RcvFile(byte[] filedata, string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                fs.Write(filedata, 0, filedata.Length);
                Console.WriteLine("Received File:{0},Saved To:{1}", filename, filename);
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
        static void Main(string[] args)
        {
            //HproseHttpListenerServer server = new HproseHttpListenerServer("http://127.0.0.1:50002/");
            HproseHttpListenerServer server = new HproseHttpListenerServer("http://0.0.0.0:50002/");

            TestService ts = new TestService();
            server.Add("RcvFile", ts);
            server.Add("SndFile", ts);
            server.Add("printHello", ts);
            server.Start();
            Console.WriteLine("Server started.");
            Console.ReadLine();
            Console.WriteLine("Server stopped.");
        }
    }
}
