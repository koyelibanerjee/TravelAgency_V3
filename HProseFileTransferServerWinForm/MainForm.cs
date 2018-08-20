using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Hprose.Server;
using HProseFileTransferServer;

namespace HProseFileTransferServerWinForm
{


    public partial class MainForm : Form
    {
        private long _rcvFileCnt = 0;
        private long _sndFileCnt = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        public void AddLvItem(string datetime, string operation, string detail, string state)
        {
            ListViewItem lvi = new ListViewItem(new string[]
            {
                (_rcvFileCnt+_sndFileCnt+1).ToString(),datetime,operation,detail,state
            });
            if (operation == "下载文件")
                ++_sndFileCnt;
            if (operation == "上传文件")
                ++_rcvFileCnt;
           
            this.Invoke(new Action(() =>
            {
                lvLogs.Items.Add(lvi);
                UpdateLable();
            }));
        }

        private void UpdateLable()
        {
            this.lbCount.Text = $"上传文件:{_rcvFileCnt}项，下载文件{_sndFileCnt}项。";
        }

        private void checkUnique()
        {
            Process[] ps = Process.GetProcessesByName("HProseFileTransferServerWinForm");
            if (ps.Length > 1)
            {
                //发现重复进程
                MessageBoxEx.Show("服务已经在运行中，请勿重复运行!");
                Application.Exit();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            checkUnique();
            this.notifyIcon1.Visible = false;
            GlobalUtils.MainFrm = this;
            InitHProseService();
            UpdateLable();
        }

        private static void InitHProseService()
        {
            //HproseHttpListenerServer server = new HproseHttpListenerServer("http://127.0.0.1:50002/");
            HproseHttpListenerServer server = new HproseHttpListenerServer("http://0.0.0.0:50002/");
            FileTransferService ts = new FileTransferService();
            server.Add("RcvFile", ts);
            server.Add("SndFile", ts);
            server.Add("GetDirList", ts);
            server.Add("printHello", ts);
            server.Start();
            LogService.Logger.DebugFormat("Server Started At:{0}", DateTime.Now);
        }

        #region 托盘相关
        //  只有Form_Closing事件中 e.Cancel可以用。
        //  你的是Form_Closed事件。 Form_Closed事件时窗口已关了 ，Cancel没用了；
        //  Form_Closing是窗口即将关闭时询问你是不是真的关闭才有Cancel事件

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 注意判断关闭事件reason来源于窗体按钮，否则用菜单退出时无法退出!
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //取消"关闭窗口"事件
                e.Cancel = true; // 取消关闭窗体 

                //使关闭时窗口向右下角缩小的效果
                HideMainForm();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible)
                HideMainForm();
            else
                ShowMainForm();
        }

        private void 显示主窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.Visible)
                ShowMainForm();
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogService.Logger.DebugFormat("Server Ended At:{0}", DateTime.Now);
            Application.Exit();
        }

        private void HideMainForm()
        {
            this.WindowState = FormWindowState.Minimized;
            this.notifyIcon1.Visible = true;
            this.Hide();
        }
        private void ShowMainForm()
        {
            notifyIcon1.Visible = false;
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }
        #endregion


    }



}
