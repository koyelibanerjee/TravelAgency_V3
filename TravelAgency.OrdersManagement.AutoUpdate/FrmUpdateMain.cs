using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.OrdersManagement.AutoUpdate.BLL;
using TravelAgency.OrdersManagement.AutoUpdate.Common;
using TravelAgency.OrdersManagement.AutoUpdate.DBUtility;
using TravelAgency.OrdersManagement.AutoUpdate.Model;


namespace TravelAgency.OrdersManagement.AutoUpdate
{
    public partial class FrmUpdateMain : Form
    {
        class UpdateAction
        {
            public enum ActType
            {
                Type01AddOrModify,
                Type02DeleteFile,
                Type04DeleteDirectory
            }
            public string file { get; set; }
            public ActType type { get; set; }
            public string version { get; set; }
        }

        ProgramUpdateBll _bll = new ProgramUpdateBll();
        ProgramUpdateModel _latestModel = new ProgramUpdateModel();
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
            _latestModel = _bll.GetLatestModel();
            if (_latestModel == null)
            {
                MessageBoxEx.Show("检查更新失败，程序将退出");
                Application.Exit();
                return;
            }
            //执行检查更新操作
            if (NeedUpdate(_latestModel.Version))
            {
                Thread.Sleep(2000); //延时两秒，防止进程没有退出
                                    //MessageBoxEx.Show("发现新版本，即将开始更新");
                                   
                string localVersion = XmlHandler.GetPropramVersion();
                var updateVersionList = _bll.GetUpdateModelList(localVersion); //获取更新版本的列表
                var updateActionList = GetUpdateActions(updateVersionList);

                //显示更新描述
                this.Invoke(new Action(() =>
                {
                    txtUpdateDetails.Text = "";

                    for (int i = 0; i != updateVersionList.Count; ++i)
                    {
                        if (i == 0)
                        {
                            txtUpdateDetails.Text += "V" + _localVersion + " -> V" + updateVersionList[i].Version + "\r\n";
                        }
                        else
                        {
                            txtUpdateDetails.Text += "V" + updateVersionList[i - 1].Version + " -> V" + updateVersionList[i].Version + "\r\n";
                        }
                        txtUpdateDetails.Text += updateVersionList[i].UpdateDetails + "\r\n\r\n";
                    }
                    lbVersion.Text = "V" + _localVersion + " -> V" + _latestModel.Version;
                }));

                //执行更新
                if (!DoUpdate(updateActionList))
                {
                    MessageBoxEx.Show("更新失败，请联系技术人员!");
                    //Application.Exit();
                    return;
                }
                XmlHandler.SetPropramVersion(_latestModel.Version);
                ConfigurationManager.AppSettings["Version"] = _latestModel.Version.ToString();
                MessageBoxEx.Show("更新完成.");
            }
            else
            {
                btnStart_Click(null, null);
            }
        }

        private bool NeedUpdate(string remoteVersion)
        {
            string localVersion = XmlHandler.GetPropramVersion();
            return string.Compare(localVersion, remoteVersion) < 0;
        }

        private List<UpdateAction> GetUpdateActions(List<Model.ProgramUpdateModel> updateModelList)
        {
            List<UpdateAction> res = new List<UpdateAction>();
            for (int i = 0; i != updateModelList.Count; ++i) //所有需要更新的版本
            {
                string[] files = updateModelList[i].UpdateFiles.Split('|');
                for (int j = 0; j != files.Length; ++j) //每次更新版本需要更新的文件
                {
                    string[] fileAndOpt = files[j].Split('@'); //用@作分割
                    UpdateAction updateActionModel = new UpdateAction();
                    updateActionModel.file = fileAndOpt[0];
                    updateActionModel.version = updateModelList[i].Version;
                    if (fileAndOpt.Length == 1 || fileAndOpt[1] == "01")
                    {
                        updateActionModel.type = UpdateAction.ActType.Type01AddOrModify;
                    }
                    else if (fileAndOpt[1] == "02")
                    {
                        updateActionModel.type = UpdateAction.ActType.Type02DeleteFile;
                    }
                    else if (fileAndOpt[1] == "04") //删除目录
                    {
                        updateActionModel.type = UpdateAction.ActType.Type04DeleteDirectory;
                    }
                    AjustUpdateList(res, updateActionModel);
                }
            }
            return res;
        }

        /// <summary>
        /// 如果有现有的更新的同一个文件，那么就不添加，只更新最新版本的文件
        /// </summary>
        /// <param name="list"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private void AjustUpdateList(List<UpdateAction> list, UpdateAction action)
        {
            if (list.Count == 0) //为空直接添加
            {
                list.Add(action);
                return;
            }
            foreach (var model in list)
            {
                if (model.file == action.file &&  //文件相同
                    string.Compare(model.version, action.version) < 0) //新来的版本更新
                {
                    model.version = action.version;
                    return;
                }
            }
            list.Add(action); //没找到，就直接添加
        }

        private bool DoUpdate(List<UpdateAction> list)
        {
            //切换到根目录下面
            FtpHandler.ChangeFtpUri(XmlHandler.GetPropramPath());
            int res = 0;
            bool updateSuccess = true;
            for (int i = 0; i < list.Count; i++)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem = new ListViewItem(list[i].file);
                ListViewItem.ListViewSubItem subItem;
                Font font = listViewItem.Font;

                if (list[i].type == UpdateAction.ActType.Type01AddOrModify) //兼容旧版本操作,如果没有指明操作,就是默认的替换或者新增
                {
                    FtpHandler.ChangeFtpUri(XmlHandler.GetPropramPath() + "/ProgramUpdates/" + list[i].version);
                    if (FtpHandler.Download(GlobalUtils.AppPath, list[i].file))
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
                else if (list[i].type == UpdateAction.ActType.Type02DeleteFile) //删除文件
                {
                    string filename = GlobalUtils.AppPath + "\\" + list[i].file;
                    if (File.Exists(filename))
                        File.Delete(filename);
                    subItem = new ListViewItem.ListViewSubItem(listViewItem, "删除文件成功", Color.DarkGreen, Color.White, font);
                    ++res;
                }

                else if (list[i].type == UpdateAction.ActType.Type04DeleteDirectory) //删除目录
                {
                    string pathName = GlobalUtils.AppPath + "\\" + list[i].file;
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
            return res == list.Count;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Process.Start(GlobalUtils.AppPath + "\\TravelAgency.OrdersManagement.exe");
            Application.Exit();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            new Thread(CheckAndDoUpdate) { IsBackground = true }.Start();
        }
    }
}
