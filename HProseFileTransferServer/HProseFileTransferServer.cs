using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hprose.IO;
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
        public void RecvImage(byte[] imageData, string imageName)
        {
            string dstPath = @"C:\rcvImages\";
            if (!Directory.Exists(dstPath))
                Directory.CreateDirectory(dstPath);
            string dstName = dstPath + imageName;
            using (FileStream fs = new FileStream(dstName, FileMode.OpenOrCreate))
            {
                fs.Write(imageData, 0, imageData.Length);
                Console.WriteLine("Received File:{0},Saved To:{1}", imageName, dstName);
                fs.Close();
            }
        }
    }

    class HProseFileTransferServer
    {
        static void Main(string[] args)
        {
            HproseHttpListenerServer server = new HproseHttpListenerServer("http://127.0.0.1:50002/");
            server.IsCrossDomainEnabled = true;
            
            TestService ts = new TestService();
            server.Add("RecvImage", ts);
            server.Add("printHello", ts);
            server.IsCrossDomainEnabled = true;
            //server.CrossDomainXmlFile = "crossdomain.xml";
            server.Start();
            Console.WriteLine("Server started.");
            Console.ReadLine();
            Console.WriteLine("Server stopped.");
        }
    }



}
