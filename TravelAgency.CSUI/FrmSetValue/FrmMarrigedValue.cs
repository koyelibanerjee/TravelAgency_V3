using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

namespace TravelAgency.CSUI.FrmSetValue
{
    public partial class FrmMarrigedValue : Form
    {
        private string[] infos = { "未婚", "已婚", "离婚", "丧偶" };
        private RadioButton[] _rtbns;
        private string _outInfo;
        public string Result { get; set; }
        public FrmMarrigedValue()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        public FrmMarrigedValue(string info)
            : this()
        {
            _rtbns = new RadioButton[infos.Length];
            _outInfo = info; //外部传入的信息
        }

        private void FrmMarrigedValue_Load(object sender, EventArgs e)
        {
            InitControls();
        }


        private void InitControls()
        {
            //string[] curInfoArr = new string[0];

            //if (!string.IsNullOrEmpty(_curInfo))
            //    curInfoArr = _curInfo.Split('、');

            for (int i = 0; i < infos.Length; i++)
            {
                RadioButton rbtn = new RadioButton();
                rbtn.Text = infos[i];
                rbtn.Name = "rbtn" + i;
                //chk1.Size = new Size(120,20);//一定要指定大小
                rbtn.AutoSize = true;
                rbtn.Font = new Font("微软雅黑", 12.0f, FontStyle.Bold);
                //if (i <= infos.Length / 2 - 1)
                rbtn.Location = new Point(2, 25 * i + 2);
                if (!string.IsNullOrEmpty(_outInfo) && infos[i] == _outInfo)
                    rbtn.Checked = true;
                _rtbns[i] = rbtn;
                this.panelMain.Controls.Add(rbtn);
            }

            

            ButtonX btnOK = new ButtonX();
            btnOK.Text = "确定";
            btnOK.Click += BtnOK_Click;
            btnOK.Font = new Font("微软雅黑", 12.0f, FontStyle.Bold);
            btnOK.AutoSize = true;
            btnOK.Location = new Point(2, (25 * infos.Length / 2 - 1) + 30 + 25);

            ButtonX btnCancel = new ButtonX();
            btnCancel.Text = "取消";
            btnCancel.Click += BtnCancel_Click;
            btnCancel.Font = new Font("微软雅黑", 12.0f, FontStyle.Bold);
            btnCancel.AutoSize = true;
            btnCancel.Location = new Point(50, (25 * infos.Length / 2 - 1) + 30 + 25);



            this.panelMain.Controls.Add(btnOK);
            this.panelMain.Controls.Add(btnCancel);
            this.panelMain.AutoSize = true;
            this.AcceptButton = btnOK;
            this.AutoSize = true;

            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _rtbns.Length; i++)
            {
                if (_rtbns[i].Checked)
                {
                    Result = _rtbns[i].Text;
                    break;
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
