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
    public interface IStub
    {
        [SimpleMode(true)]
        Task RecvImage(byte[] imageData, string imageName);
    }
    class HProseFileTransferClient
    {
       
        static void Main(string[] args)
        {
             HproseHttpClient client;
            client = new HproseHttpClient(" http://localhost:2012/");
            client.KeepAlive = true;

            FileStream fs = new FileStream(@"I:\My Documents\My Pictures\unsplash\christopher-burns-497236-unsplash.jpg",FileMode.Open);
            byte[] picturedata = new byte[fs.Length];
            fs.Read(picturedata, 0, picturedata.Length);

            client.Invoke("RecvImage", new object[] {fs, @"C:\rcvImages\abcdef.jpg" });

        }
    }
}
