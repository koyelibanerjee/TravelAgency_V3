﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ScanCtrlTest;
using TravelAgency.Common;


namespace TravelAgency.OrdersManagement
{
    public partial class FrmMain : Form
    {
        private BLL.WorkerQueue _bllWorkerQueue = new BLL.WorkerQueue();
        public FrmMain()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }


        

        public void OpenTab(Form frm, string Name)
        {
            if (IsOpenTab(Name))
                return;
            
            DevComponents.DotNetBar.TabItem tp = new DevComponents.DotNetBar.TabItem();
            DevComponents.DotNetBar.TabControlPanel tcp = new DevComponents.DotNetBar.TabControlPanel();
            tp.MouseDown += new MouseEventHandler(tp_MouseDown);
            tcp.Dock = System.Windows.Forms.DockStyle.Fill;
            tcp.Location = new System.Drawing.Point(0, 0);

            frm.TopLevel = false;
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            tcp.Controls.Add(frm);
            tp.Text = frm.Text;
            tp.Name = Name;

            if (!IsOpenTab(Name))
            {
                tcp.TabItem = tp;
                tp.AttachedControl = tcp;
                tabMain.Controls.Add(tcp);
                tabMain.Tabs.Add(tp);
                tabMain.SelectedTab = tp;
            }
            tabMain.Refresh();
        }

        private bool IsOpenTab(string tabName)
        {
            bool isOpened = false;

            foreach (TabItem tab in tabMain.Tabs)
            {
                if (tab.Name == tabName.Trim())
                {
                    isOpened = true;
                    tabMain.SelectedTab = tab;
                    break;
                }
            }
            return isOpened;
        }

        private void tp_MouseDown(object sender, MouseEventArgs e)
        {
            tabMain.SelectedTab = (TabItem)sender;
            if (e.Button == MouseButtons.Right && tabMain.SelectedTab != null)
            {
                this.tabMain.Select();
                cms.Show(this.tabMain, e.X, e.Y);
            }
        }

        private void btnMCloseAll_Click(object sender, EventArgs e)
        {
            tabMain.Tabs.Clear();
        }

        private void btnMCloseOther_Click(object sender, EventArgs e)
        {
            do
            {
                if (tabMain.SelectedTab != tabMain.Tabs[0])
                {
                    tabMain.Tabs.RemoveAt(0);
                }
                else
                {
                    tabMain.Tabs.RemoveAt(1);
                }

            } while (tabMain.Tabs.Count != 1);

            tabMain.Refresh();
        }

        private void tabMain_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            TabItem tb = tabMain.SelectedTab;
            tabMain.Tabs.Remove(tb);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = "东瀛假日:签证自动扫描识别系统V" + XmlHandler.GetPropramVersion();
            this.Text = this.Text + "     当前登录用户:" + Common.GlobalUtils.LoginUser.UserName;
            MinimumSize = Size;
            FrmsManager.OpenedForms.Add(this);
           string workId =  GlobalUtils.LoginUser.WorkId;
            if (workId != "10000" && workId != "10301" && workId != "10302")
            {
                btnCommisionMoneyManage.Enabled = false;
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _bllWorkerQueue.ChangeUserAcceptState(GlobalUtils.LoginUser.WorkId, false); //退出的时候关闭开关
            Application.Exit();
        }

        private void btnVisaTypeIn_Click(object sender, EventArgs e)
        {
            FrmOrdersManage_Waitor frm = new FrmOrdersManage_Waitor();
            OpenTab(frm, frm.Name);
        }

        private void btnVisaInfoManage_Click(object sender, EventArgs e)
        {
            FrmOrdersManage_Oper frm = new FrmOrdersManage_Oper();
            OpenTab(frm, frm.Name);
        }
    }
}
