using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ScanCtrlTest;
using TravelAgency.Common;


namespace TravelAgency.OrdersManagement
{
    public partial class FrmMain : Form
    {
        private BLL.WorkerQueue _bllWorkerQueue = new BLL.WorkerQueue();
        private int _unreadNum = 0;
        private System.Windows.Forms.Timer _lableBlinkTimer = new System.Windows.Forms.Timer();

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

            MinimumSize = Size;
            FrmsManager.OpenedForms.Add(this);
            string workId = GlobalUtils.LoginUser.WorkId;
            string role = "";
            if (GlobalUtils.LoginUserLevel == RigthLevel.Operator)
            {
                btnOrderManagementWaitor.Enabled = false;
                role = "操作";
            }
            else if (GlobalUtils.LoginUserLevel == RigthLevel.Waitor)
            {
                btnOrderManagementOperator.Enabled = false;
                role = "客服";
            }
            else //管理员全部都可以
            {
                role = "管理员";
            }

            this.Text = "EasyGo 销售订单管理系统" + TravelAgency.OrdersManagement.AutoUpdate.Common.XmlHandler.GetPropramVersion();
            this.Text = this.Text + "     当前登录用户:" + Common.GlobalUtils.LoginUser.UserName;
            this.Text += "  身份:(" + role + ")";

            new Thread(ThUpdateUnreadNum) { IsBackground = true }.Start();
            _lableBlinkTimer.Tick += _lableBlinkTimer_Tick;
            _lableBlinkTimer.Interval = 1000;
            _lableBlinkTimer.Start();

        }

        private void _lableBlinkTimer_Tick(object sender, EventArgs e)
        {
            if (_unreadNum != 0)
            {
                lbUnReadNum.Visible = !lbUnReadNum.Visible;
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

        private void btnChangeLoginUser_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("是否切换用户", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                StartExe(Application.ExecutablePath);
                Application.ExitThread();
            }
        }

        private static void StartExe(string appName)
        {
            string path = appName;
            Process ps = new Process();
            ps.StartInfo.FileName = path;
            ps.StartInfo.Arguments = "T";
            ps.StartInfo.CreateNoWindow = true;
            ps.StartInfo.WorkingDirectory = Path.GetDirectoryName(path);
            ps.Start();
        }

        private void btnOrderInfoManage_Click(object sender, EventArgs e)
        {
            FrmOrderInfoManage frm = new FrmOrderInfoManage();
            OpenTab(frm, frm.Name);
        }

        //private void BtnSummary_Click(object sender, EventArgs e)
        //{
        //    FrmOrdersManage_Summary frm = new FrmOrdersManage_Summary();
        //    OpenTab(frm, frm.Name);
        //}

        private void btnOrdersSummary_Click(object sender, EventArgs e)
        {
            FrmOrdersManage_Summary frm = new FrmOrdersManage_Summary();
            OpenTab(frm, frm.Name);
        }

        private void btnMessageManage_Click(object sender, EventArgs e)
        {
            FrmMessageManage frm = new FrmMessageManage();
            OpenTab(frm, frm.Name);
        }
        private void ThUpdateUnreadNum()
        {
            string username = GlobalUtils.LoginUser.UserName;
            BLL.Message bllMessage = new BLL.Message();
            while (true)
            {
                _unreadNum = bllMessage.GetUnReadMsgNum(username);

                lbUnReadNum.Invoke(new Action(() =>
                {
                    if (_unreadNum == 0)
                        lbUnReadNum.Visible = false;
                    else
                    {
                        lbUnReadNum.Visible = true;
                        lbUnReadNum.Text = string.Format("你有{0}条未读消息.", _unreadNum);
                    }
                }));
                Thread.Sleep(10000);
            }

        }

        private void lbUnReadNum_Click(object sender, EventArgs e)
        {
            FrmMessageManage frm = new FrmMessageManage(true);
            OpenTab(frm, frm.Name);
        }
    }
}
