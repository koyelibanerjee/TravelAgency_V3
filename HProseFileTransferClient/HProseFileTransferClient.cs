using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hprose.Client;
using Hprose.Common;


namespace HProseFileTransferClient
{

    class HProseFileTransferClient
    {

        static void Main(string[] args)
        {
            HproseHttpClient client;
            client = new HproseHttpClient(" http://localhost:50002/");
            //client = new HproseHttpClient("http://182.150.20.247:50002/");

            //client = new HproseHttpClient("http://0.0.0.0:50002");
            client.KeepAlive = true;

            FileStream fs = new FileStream(@"I:\My Documents\My Pictures\unsplash\christopher-burns-497236-unsplash.jpg", FileMode.Open);
            byte[] picturedata = new byte[fs.Length];
            fs.Read(picturedata, 0, picturedata.Length);

            client.Invoke("RcvFile", new object[] { picturedata, @"C:\rcvImages\abcdef.jpg" });
            //client.Invoke("printHello", new object[] { 1});

        }
    }
}
