using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.Common;
using TravelAgency.Model;
using AuthUser = TravelAgency.BLL.AuthUser;
using ProgramVersion = TravelAgency.BLL.ProgramVersion;

namespace TravelAgency.CSUI.FrmMain
{
    public partial class FrmLogin : Form
    {
        private BLL.AuthUser _bllUser = new AuthUser();
        BLL.ProgramVersion _bll = new ProgramVersion();
        Model.ProgramVersion _model = new Model.ProgramVersion();
        private List<User> _users = new List<User>();
        private string _userDataFile = "UserData.bin";

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = this.txtUserName.Text.Trim();
            string password = this.txtPswd.Text.Trim();

            User user = new User();
            FileStream fs = new FileStream(_userDataFile, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            user.Username = username;
            if (this.chkRememberPswd.Checked)       //  如果单击了记住密码的功能
            {   //  在文件中保存密码
                user.Password = password;
            }
            else
            {   //  不在文件中保存密码
                user.Password = "";
            }

            //  选在集合中是否存在用户名 
            for (int i = _users.Count - 1; i >= 0; i--)
            {
                if (_users[i].Username == user.Username)
                    _users.Remove(_users[i]);
            }

            _users.Add(user);
            //要先将User类先设为可以序列化(即在类的前面加[Serializable])
            bf.Serialize(fs, _users);
            //user.Password = this.PassWord.Text;
            fs.Close();

            ///////
            ///////  这里填写登录的处理逻辑代码
            ///////


            //登录
            if (txtPswd.Text == "" || txtUserName.Text == "")
            {
                MessageBoxEx.Show("请输入登录口令!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var list = _bllUser.GetModelList(string.Format(" Account ='{0}' and Password = '{1}' ", txtUserName.Text, txtPswd.Text));
            if (list.Count < 1)
            {
                MessageBoxEx.Show("未找到指定用户!");
                return;
            }
            Common.GlobalUtils.LoginUser = list[0];
            if (list[0].WorkId == "10000" || list[0].WorkId == "10301" || list[0].WorkId == "10302")
            {
                GlobalUtils.LoginUserLevel = RigthLevel.Manager;
            }
            else
            {
                GlobalUtils.LoginUserLevel = RigthLevel.Normal;

            }
            FrmMain frm = new FrmMain();
            frm.Show();
            this.Visible = false;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //chkRememberPswd.CheckValueChanged+=chkRememberPswd_CheckValueChanged;
            txtUserName.SelectedValueChanged += txtUserName_SelectedValueChanged;

            //  读取配置文件寻找记住的用户名和密码
            FileStream fs = new FileStream(_userDataFile, FileMode.OpenOrCreate);
            if (fs.Length > 0)
            {
                BinaryFormatter bf = new BinaryFormatter();
                _users = bf.Deserialize(fs) as List<User>;
                if(_users==null)
                    return;
                
                foreach (User user in _users)
                {
                    this.txtUserName.Items.Add(user.Username);
                }

                for (int i = 0; i < _users.Count; i++)
                {
                    if (this.txtUserName.Text != "")
                    {
                        foreach (var user in _users)
                        {
                            if (user.Username == this.txtUserName.Text.Trim())
                            {
                                this.txtPswd.Text = user.Password;
                                this.chkRememberPswd.Checked = true; //这里虽然默认选中了，但是后面其实会触发user_name selectedvaluechanged事件就无所谓了
                            }
                        }
                    }
                }
            }
            fs.Close();
            //  用户名默认选中第一个
            if (this.txtUserName.Items.Count > 0)
            {
                this.txtUserName.SelectedIndex = this.txtUserName.Items.Count - 1;
            }
            //item = (List<User>)bUser.GetAll();
            //item = 
            //this.UserName.DataSource = item;
            //this.UserName.DisplayMember = "Username";

            if (!GlobalUtils.CheckDatabaseConnect())
            {
                MessageBoxEx.Show("连接到数据库服务器失败，请联系技术人员!");
                Application.Exit();
                return;
            }
            _model = _bll.GetModel(_bll.GetMaxId() - 1); //取出来是错的，加了1，这里如果数据库里没有数据，返回的是1，所以还不好判断，就假设数据库一致都有数据吧
            if (_model == null)
            {
                MessageBoxEx.Show("检查更新失败，程序将退出");
                Application.Exit();
                return;
            }
            //执行检查更新操作
            if (NeedUpdate())
            {
                //获取更新文件列表
                string[] list = _model.update_files.Split('|');

                //显示更新描述
                labelX1.Text = _model.udapte_details;

                //执行更新
                MessageBoxEx.Show("发现新版本，即将开始升级");
                Process.Start(GlobalUtils.AppPath + "\\" + "TravelAgency.AutoUpdate.exe");
                Application.Exit();
                return;
            }

        }

        private bool NeedUpdate()
        {
            float localVersion = XmlHandler.GetPropramVersion();
            return localVersion < (float)_model.version;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Application.Exit();
                    return true;
                case Keys.Enter:
                    btnLogin_Click(null, null);
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void txtUserName_SelectedValueChanged(object sender, EventArgs e)
        {
            //  首先读取记住密码的配置文件
            using (FileStream fs = new FileStream(_userDataFile, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    _users = bf.Deserialize(fs) as List<User>;

                    if (this.txtUserName.Text == "")
                        return;
                    this.txtPswd.Text = "";
                    this.chkRememberPswd.Checked = false;
                    for (int i = 0; i < _users.Count; i++)
                    {
                        if (_users[i].Username == txtUserName.Text && !string.IsNullOrEmpty(_users[i].Password))
                        {
                            this.txtPswd.Text = _users[i].Password;
                            this.chkRememberPswd.Checked = true;
                        }
                    }
                }

                fs.Close();
            }


        }
    }
}
