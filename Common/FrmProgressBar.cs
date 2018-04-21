using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency.Common
{
    public partial class FrmProgressBar : Form
    {
        public FrmProgressBar()
        {
            InitializeComponent();
        }

        private void UpdateProgressbarThread()
        {
            while (true)
            {
                Thread.Sleep(30);
            }
            //while (_progObj.CurValue < _max)
            //{
            //    this.BeginInvoke(new Action(() =>
            //    {
            //        this.progressBarX1.Value = _progObj.CurValue;
            //        this.lbProgress.Text = string.Format("{0}   {1}/{2}", _context, _progObj.CurValue, _max);

            //    }));
            //    Thread.Sleep(30);
            //}

            //this.BeginInvoke(new Action(() =>
            //{
            //    this.lbProgress.Text = "处理完成";
            //    Thread.Sleep(500);
            //    //this.Close();
            //    _parent.Enabled = true;
            //}));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(UpdateProgressbarThread) { IsBackground = true }.Start();
        }
    }
}
