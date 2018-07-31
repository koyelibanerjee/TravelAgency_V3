using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hprose.Client;
using Hprose.Common;

namespace HProseFileTransferUIClient
{
    public interface IStub
    {
        [SimpleMode(true)]
        Task<string> printHello(string name);
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            string filename = TravelAgency.Common.GlobalUtils.ShowOpenFileDlg();
            txtFilePath.Text = filename;
        }
        //static HproseHttpClient client = new HproseHttpClient("http://182.150.20.247:50002/");
        static HproseHttpClient client = new HproseHttpClient("http://127.0.0.1:50002/");
        private void btnSendFile_Click(object sender, EventArgs e)
        {
            client.KeepAlive = true;

            using (FileStream fs = new FileStream(txtFilePath.Text, FileMode.Open))
            {
                byte[] picturedata = new byte[fs.Length];
                fs.Read(picturedata, 0, picturedata.Length);
                client.Invoke("RecvImage", new object[] { fs, Path.GetFileName(txtFilePath.Text) });
                fs.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //client.KeepAlive = true;
            var ret = client.Invoke<string>("printHello", new object[] {1});
            MessageBox.Show(ret);
        }
    }
}
