using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.AutoUpdate.Common;
using TravelAgency.AutoUpdate.DBUtility;

namespace TravelAgency.AutoUpdate
{

    //TODO:增加删除功能,配合数据库字段完成.
    public partial class FrmUpdateMain : Form
    {
        ProgramVersionBLL _bll = new ProgramVersionBLL();
        ProgramVersionModel _model = new ProgramVersionModel();
        private float _localVersion = -1.0f;
        public FrmUpdateMain()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void FrmUpdateMain_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            
        }

        void CheckAndDoUpdate()
        {
            _model = _bll.GetModel(_bll.GetMaxId() - 1);
            if (_model == null)
            {
                MessageBoxEx.Show("检查更新失败，程序将退出");
                Application.Exit();
                return;
            }
            //执行检查更新操作
            if (NeedUpdate())
            {
                Thread.Sleep(2000); //延时两秒，防止进程没有退出
                //MessageBoxEx.Show("发现新版本，即将开始更新");
                //获取更新文件列表
                string[] list = _model.update_files.Split('|');

                //显示更新描述
                this.Invoke(new Action(() =>
                {
                    txtUpdateDetails.Text = _model.udapte_details;
                    lbVersion.Text = "V" + _localVersion + " -> V" + _model.version;
                }));

                //执行更新
                if (!DoUpdate(list))
                {
                    MessageBoxEx.Show("更新失败，请联系技术人员!");
                    //Application.Exit();
                    return;
                }
                XmlHandler.SetPropramVersion((float)_model.version);
                ConfigurationManager.AppSettings["Version"] = _model.version.ToString();
                MessageBoxEx.Show("更新完成.");
            }
            else
            {
                btnStart_Click(null, null);
            }
        }

        private bool NeedUpdate()
        {
            _localVersion = XmlHandler.GetPropramVersion();
            return _localVersion < (float)_model.version;
        }

        private bool DoUpdate(string[] list)
        {
            //切换到根目录下面
            FtpHandler.ChangeFtpUri(XmlHandler.GetPropramPath());
            int res = 0;
            bool updateSuccess = true;
            for (int i = 0; i < list.Length; i++)
            {
                string[] fileAndOpt = list[i].Split('@'); //用@作分割
                ListViewItem listViewItem = new ListViewItem();
                listViewItem = new ListViewItem(fileAndOpt[0]);
                ListViewItem.ListViewSubItem subItem;
                Font font = listViewItem.Font;

                if (fileAndOpt.Length == 1 || fileAndOpt[1] == "01") //兼容旧版本操作,如果没有指明操作,就是默认的替换或者新增
                {
                    if (FtpHandler.Download(GlobalUtils.AppPath, fileAndOpt[0]))
                    {
                        subItem = new ListViewItem.ListViewSubItem(listViewItem, "更新成功", Color.DarkGreen, Color.White,
                            font);
                        ++res;
                    }
                    else
                    {
                        subItem = new ListViewItem.ListViewSubItem(listViewItem, "更新失败", Color.DarkRed, Color.White,
                            font);
                        updateSuccess = false;
                    }
                }
                else if (fileAndOpt[1] == "02") //删除文件
                {
                    string filename = GlobalUtils.AppPath + "\\" + fileAndOpt[0];
                    if (File.Exists(filename))
                        File.Delete(filename);
                    subItem = new ListViewItem.ListViewSubItem(listViewItem, "删除文件成功", Color.DarkGreen, Color.White, font);
                    ++res;
                }

                else if (fileAndOpt[1] == "04") //删除目录
                {
                    string pathName = GlobalUtils.AppPath + "\\" + fileAndOpt[0];
                    if (Directory.Exists(pathName))
                        Directory.Delete(pathName, true);
                    subItem = new ListViewItem.ListViewSubItem(listViewItem, "删除目录成功", Color.DarkGreen, Color.White, font);
                    ++res;
                }
                else //默认操作
                {
                    subItem = new ListViewItem.ListViewSubItem(listViewItem, "更新失败,未定义操作", Color.DarkRed, Color.White,
    font);
                    updateSuccess = false;
                }

                listViewItem.SubItems.Add(subItem);
                this.Invoke(new Action(() =>
                {
                    lvUpdateList.Items.Add(listViewItem);
                }));
            }
            if (!updateSuccess)
                this.btnStart.TextColor = Color.DarkRed;
            else
                this.btnStart.TextColor = Color.DarkGreen;
            return res == list.Length;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Process.Start(GlobalUtils.AppPath + "\\TravelAgency.CSUI.exe");
            Application.Exit();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            new Thread(CheckAndDoUpdate) { IsBackground = true }.Start();
        }
    }
}
