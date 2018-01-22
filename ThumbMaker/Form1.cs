using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThumbMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pathName = TravelAgency.Common.GlobalUtils.ShowBrowseFolderDlg();
            if (!string.IsNullOrEmpty(pathName))
            {
                txtPath.Text = pathName;
                progressBar1.Value = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Thread(GenThumbs) { IsBackground = true }.Start();
        }

        private void GenThumbs()
        {
            string[] fileList = Directory.GetFiles(txtPath.Text);
            int filenum = 0;
            foreach (var file in fileList)
            {
                if (!file.Contains("thumb"))
                {
                    filenum += 1;
                }
            }
            this.Invoke(new Action(() =>
            {
                progressBar1.Value = 0;
                progressBar1.Maximum = filenum;
            }));

            foreach (var file in fileList)
            {
                if (!file.Contains("thumb"))
                {
                    string dstName = "thumb_" + Path.GetFileName(file);
                    string path = Path.GetDirectoryName(file);
                    TravelAgency.Common.PicHandler.MakeThumbnail(file, Path.Combine(path, dstName), double.Parse(txtRatio.Text));
                    this.Invoke(new Action(() =>
                    {
                        progressBar1.Value += 1;
                    }));
                }
            }
            MessageBox.Show("生成完成");
        }

    }
}
