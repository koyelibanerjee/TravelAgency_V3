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

namespace TravelAgency.CSUI.FrmSub
{
    public partial class FrmIdentificationValue : Form
    {

        public string[] identiStuffs = new[] { "身份证", "全家户口本", "在职证明", "营业执照", "学生证", "出生证", "结婚证", "退休证" };
        private CheckBoxX[] _chks;
        private string _curInfo;
        public string IdentifyString { get; set; }
        public FrmIdentificationValue(string curInfo)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            _chks = new CheckBoxX[identiStuffs.Length];
            _curInfo = curInfo;
        }
        private void FrmIdentificationValue_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        private void InitControls()
        {
            string[] curInfoArr = new string[0];

            if (!string.IsNullOrEmpty(_curInfo))
                curInfoArr = _curInfo.Split('、');

            for (int i = 0; i < identiStuffs.Length; i++)
            {
                CheckBoxX chkBox = new CheckBoxX();
                chkBox.Text = identiStuffs[i];
                chkBox.Name = "chk" + i;
                //chk1.Size = new Size(120,20);//一定要指定大小
                chkBox.AutoSize = true;
                chkBox.Font = new Font("微软雅黑", 12.0f, FontStyle.Bold);
                if (i <= identiStuffs.Length / 2 - 1)
                    chkBox.Location = new Point(2, 25 * i + 2);
                else
                    chkBox.Location = new Point(120, 25 * (i - identiStuffs.Length / 2) + 2);

                if (curInfoArr.Length == 0 || (curInfoArr.Length >= 1 && curInfoArr.Contains(identiStuffs[i])))
                    chkBox.Checked = true;

                _chks[i] = chkBox;
                this.panelEx1.Controls.Add(chkBox);
            }

            ButtonX btnAllSel = new ButtonX();
            btnAllSel.Text = "全选";
            btnAllSel.Click += BtnAllSel_Click;
            btnAllSel.Font = new Font("微软雅黑", 12.0f, FontStyle.Bold);
            btnAllSel.AutoSize = true;
            btnAllSel.Location = new Point(2, (25 * identiStuffs.Length / 2 - 1) + 10);

            ButtonX btnAllNotSel = new ButtonX();
            btnAllNotSel.Text = "全不选";
            btnAllNotSel.Click += BtnAllNotSel_Click;
            btnAllNotSel.Font = new Font("微软雅黑", 12.0f, FontStyle.Bold);
            btnAllNotSel.AutoSize = true;
            btnAllNotSel.Location = new Point(50, (25 * identiStuffs.Length / 2 - 1) + 10);

            ButtonX btnOK = new ButtonX();
            btnOK.Text = "确定";
            btnOK.Click += BtnOK_Click;
            btnOK.Font = new Font("微软雅黑", 12.0f, FontStyle.Bold);
            btnOK.AutoSize = true;
            btnOK.Location = new Point(2, (25 * identiStuffs.Length / 2 - 1) + 30 + 10);

            ButtonX btnCancel = new ButtonX();
            btnCancel.Text = "取消";
            btnCancel.Click += BtnCancel_Click;
            btnCancel.Font = new Font("微软雅黑", 12.0f, FontStyle.Bold);
            btnCancel.AutoSize = true;
            btnCancel.Location = new Point(50, (25 * identiStuffs.Length / 2 - 1) + 30 + 10);


            this.panelEx1.Controls.Add(btnAllSel);
            this.panelEx1.Controls.Add(btnAllNotSel);
            this.panelEx1.Controls.Add(btnOK);
            this.panelEx1.Controls.Add(btnCancel);
            this.panelEx1.AutoSize = true;
            this.AcceptButton = btnOK;
            this.AutoSize = true;

            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle= FormBorderStyle.FixedSingle;

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append()
            for (int i = 0; i < _chks.Length; i++)
            {
                if (_chks[i].Checked)
                    sb.Append(_chks[i].Text + "、");
            }
            string res = sb.ToString();
            if (res.EndsWith("、"))
                res = res.TrimEnd('、');
            IdentifyString = res;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnAllNotSel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < identiStuffs.Length; i++)
            {
                _chks[i].Checked = false;
            }
        }

        private void BtnAllSel_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            for (int i = 0; i < identiStuffs.Length; i++)
            {
                _chks[i].Checked = true;
            }
        }
    }
}
