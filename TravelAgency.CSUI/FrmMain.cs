using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ScanCtrlTest;
using TravelAgency.Common;
using TravelAgency.CSUI.Financial.FrmMain;
using TravelAgency.CSUI.Financial.FrmSub;
using TravelAgency.CSUI.FrmSub;
using TravelAgency.CSUI.Statistics.FrmMain;
using TravelAgency.CSUI.Visa.FrmMain;

namespace TravelAgency.CSUI.FrmMain
{
    public partial class FrmMain : Form
    {
        private BLL.WorkerQueue _bllWorkerQueue = new BLL.WorkerQueue();
        public FrmMain()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }


        #region ribbon control上点击按钮
        private void btnVisaTypeIn_Click(object sender, EventArgs e)
        {
            FrmVisaTypeIn frm = new FrmVisaTypeIn();
            OpenTab(frm, frm.Name);
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            FrmVisaSubmitManage frm = new FrmVisaSubmitManage();
            OpenTab(frm, frm.Name);
        }

        private void btnVisaQuery_Click(object sender, EventArgs e)
        {
            FrmVisaManage frm = new FrmVisaManage();
            OpenTab(frm, frm.Name);
        }

        private void btnVisaInfoManage_Click(object sender, EventArgs e)
        {
            FrmVisaInfoManage frm = new FrmVisaInfoManage();
            OpenTab(frm, frm.Name);
        }
        #endregion

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
            GlobalStat.UpdateStatistics();
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

        private void btnScanFrm_Click(object sender, EventArgs e)
        {
            FrmTackePicture frm = new FrmTackePicture();
            OpenTab(frm, frm.Name);
        }

        private void btnGPManage_Click(object sender, EventArgs e)
        {
            FrmGaoPaiManage frm = new FrmGaoPaiManage();
            OpenTab(frm, frm.Name);
        }


        private void btntActionRecordsCount_Click(object sender, EventArgs e)
        {
            FrmActionRecordsManage frm = new FrmActionRecordsManage();
            OpenTab(frm, frm.Name);
        }

        private void btnPersonalCount_Click(object sender, EventArgs e)
        {
            FrmPersonalWorkCount frm = new FrmPersonalWorkCount();
            OpenTab(frm, frm.Name);
        }

        private void buttonItem1_Click_1(object sender, EventArgs e)
        {
            FrmVisaRequestPayoutManage frm = new FrmVisaRequestPayoutManage();
            OpenTab(frm, frm.Name);
        }

        private void btnClientManage_Click(object sender, EventArgs e)
        {
            FrmClientChargeManage frm = new FrmClientChargeManage();
            OpenTab(frm, frm.Name);
        }

        private void btnConsulateManage_Click(object sender, EventArgs e)
        {
            FrmConsulateChargeManage frm = new FrmConsulateChargeManage();
            OpenTab(frm, frm.Name);
        }

        public void SetLbVisaInfoCount(string str)
        {
            lbVisaInfoCount.Text = str;
        }

        private void btnCommisionMoneyManage_Click(object sender, EventArgs e)
        {
            FrmCommisionMoneyManage frm = new FrmCommisionMoneyManage();
            OpenTab(frm, frm.Name);
        }

        private void btnAppAllManage_Click(object sender, EventArgs e)
        {
            FrmAppManage frm = new FrmAppManage();
            OpenTab(frm, frm.Name);
        }

        private void btnJobAssignment_Click(object sender, EventArgs e)
        {
            if (GlobalUtils.LoginUserLevel != RigthLevel.Manager)
            {
                MessageBoxEx.Show("权限不足!");
                return;
            }
            FrmJobAssignment frm = new FrmJobAssignment();
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

        private void btnJiaoJiePicManage_Click(object sender, EventArgs e)
        {
            FrmJiaoJieManage frm = new FrmJiaoJieManage();
            OpenTab(frm, frm.Name);
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            FrmDataBackUp frm = new FrmDataBackUp();
            OpenTab(frm, frm.Name);
        }

        private void btnClaimManage_Click(object sender, EventArgs e)
        {
            FrmVisaClaimManage frm = new FrmVisaClaimManage();
            OpenTab(frm,frm.Name);
        }
    }
}
