﻿using System;
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
    public partial class FrmProgress : Form
    {
        private string _context = null;
        private int _max;
        private Form _parent;
        //public int CurValue { get; set; }
        private ProgObject _progObj;
        public class ProgObject
        {
            public int CurValue { get; set; }
        }




        public FrmProgress(int max, ProgObject progObj, Form parent, string caption = "处理进度", string context = "正在处理")
        {
            //this.Text = caption;
            //_context = context;
            //_max = max;
            ////CurValue = cur;
            //_progObj = progObj;
            //this.ControlBox = false;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;

            //this._parent = parent;
            //parent.Enabled = false;
            InitializeComponent();
        }

        private void FrmProgress_Load(object sender, EventArgs e)
        {
            //this.progressBarX1.Maximum = _max;
            //this.progressBarX1.Value = _progObj.CurValue;
            
        }


        private void UpdateProgressbarThread()
        {
            while (true)
            {
                Thread.Sleep(30);
            }
            while (_progObj.CurValue < _max)
            {
                this.BeginInvoke(new Action(() =>
                {
                    this.progressBarX1.Value = _progObj.CurValue;
                    this.lbProgress.Text = string.Format("{0}   {1}/{2}", _context, _progObj.CurValue, _max);

                }));
                Thread.Sleep(30);
            }

            this.BeginInvoke(new Action(() =>
            {
                this.lbProgress.Text = "处理完成";
                Thread.Sleep(500);
                //this.Close();
                _parent.Enabled = true;
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(UpdateProgressbarThread) { IsBackground = true }.Start();
        }
    }
}