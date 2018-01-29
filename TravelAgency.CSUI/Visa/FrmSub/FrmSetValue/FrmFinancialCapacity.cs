using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency.CSUI.FrmSetValue
{
    public partial class FrmFinancialCapacity : Form
    {
        public string FinacialCapacity;
        public FrmFinancialCapacity(string finacialString)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            FinacialCapacity = finacialString;
            
        }

        private void InitControls()
        {
            if (string.IsNullOrEmpty(FinacialCapacity))
                return;

            string FangchanPattern = "房产证明:（(\\S+?)平方米）?";
            string ChechanPattern = "车产证明:（(\\S+?)牌）?";
            string CunkunaPattern = "存款证明:（(\\S+?)万）";
            string LiuShuiPattern = "流水:（(\\S+?)）";
            string NianXinPattern = "年薪:（(\\S+?)万）";

            //其实一种方式的正则也就够了
            MatchCollection m = Regex.Matches(FinacialCapacity, FangchanPattern);
            if (m.Count > 0)
                textBoxX1.Text = m[0].Groups[1].Value;

            Match m1 = Regex.Match(FinacialCapacity, ChechanPattern);
            if (m1.Success)
                textBoxX2.Text = m1.Groups[1].Value;
            m1 = Regex.Match(FinacialCapacity, CunkunaPattern);
            if (m1.Success)
                textBoxX3.Text = m1.Groups[1].Value;
            m1 = Regex.Match(FinacialCapacity, NianXinPattern);
            if (m1.Success)
                txtNianXin.Text = m1.Groups[1].Value;
            m1 = Regex.Match(FinacialCapacity, LiuShuiPattern);
            if (m1.Success)
                txtLiuShui.Text = m1.Groups[1].Value;
        }

        private void FrmFinancialCapacity_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnOK;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitControls();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(txtLiuShui.Text.Trim()))
                sb.AppendFormat("流水:（{0}）、", txtLiuShui.Text);

            if (!string.IsNullOrEmpty(textBoxX1.Text.Trim()))
                sb.AppendFormat("房产证明:（{0}平方米）、", textBoxX1.Text);

            if (!string.IsNullOrEmpty(textBoxX3.Text.Trim()))
                sb.AppendFormat("存款证明:（{0}万）、", textBoxX3.Text);

            if (!string.IsNullOrEmpty(txtNianXin.Text.Trim()))
                sb.AppendFormat("年薪:（{0}万）、", txtNianXin.Text);

            if (!string.IsNullOrEmpty(textBoxX2.Text.Trim()))
                sb.AppendFormat("车产证明:（{0}牌）、", textBoxX2.Text);



            FinacialCapacity = sb.ToString();
            if (FinacialCapacity.EndsWith("、"))
                FinacialCapacity = FinacialCapacity.TrimEnd('、');
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
