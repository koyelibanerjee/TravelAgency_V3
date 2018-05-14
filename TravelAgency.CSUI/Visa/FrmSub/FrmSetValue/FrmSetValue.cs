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
using DevComponents.DotNetBar.Controls;

namespace TravelAgency.CSUI.FrmSetValue
{
    public partial class FrmSetValue : Form
    {
        public string[] identiStuffs = new[] { "身份证", "全家户口本", "在职证明", "营业执照", "学生证", "出生证", "结婚证", "退休证" };
        public FrmSetValue()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
        }

        public FrmSetValue(Model.VisaInfo model)
            : this()
        {
            _model = model;
            InitCtrls();
        }

        private void InitCtrls()
        {
            txtResidence.Text = _model.Residence;
            txtDepartureRecord.Text = _model.DepartureRecord;
            txtMarrige.Text = _model.Marriaged;
            txtIdentification.Text = _model.Identification;
            txtFinancialCapacity.Text = _model.FinancialCapacity;
            lbName.Text = _model.Name;
            txtPhone.Text = _model.Phone;
            txtOccupation.Text = _model.Occupation;
            //初始化原始数据，先不弄了

            //初始化经济能力
            if (string.IsNullOrEmpty(txtFinancialCapacity.Text))
                return;

            string FangchanPattern = "房产证明:（(\\S+?)平方米）?";
            string ChechanPattern = "车产证明:（(\\S+?)牌）?";
            string CunkunaPattern = "存款证明:（(\\S+?)万）";
            string LiuShuiPattern = "流水:（(\\S+?)）";
            string NianXinPattern = "年薪:（(\\S+?)万）";
            string OtherPattern = "其他:（(\\S+?)）";


            //其实一种方式的正则也就够了
            MatchCollection m = Regex.Matches(txtFinancialCapacity.Text, FangchanPattern);
            if (m.Count > 0)
                txtFangchan.Text = m[0].Groups[1].Value;
            Match m1 = Regex.Match(txtFinancialCapacity.Text, ChechanPattern);
            if (m1.Success)
                txtChechan.Text = m1.Groups[1].Value;
            m1 = Regex.Match(txtFinancialCapacity.Text, CunkunaPattern);
            if (m1.Success)
                txtCunkuan.Text = m1.Groups[1].Value;
            m1 = Regex.Match(txtFinancialCapacity.Text, NianXinPattern);
            if (m1.Success)
                txtNianXin.Text = m1.Groups[1].Value;
            m1 = Regex.Match(txtFinancialCapacity.Text, LiuShuiPattern);
            if (m1.Success)
                txtLiuShui.Text = m1.Groups[1].Value;
            m1 = Regex.Match(txtFinancialCapacity.Text, OtherPattern);
            if (m1.Success)
                txtFinacialCapacityOther.Text = m1.Groups[1].Value;

            //初始化出境记录
            if (!string.IsNullOrEmpty(_model.DepartureRecord))
            {
                if (_model.DepartureRecord == "无")
                    rbtnNone.Checked = true;
                if (_model.DepartureRecord == "普通")
                    rbtnNormal.Checked = true;
                if (_model.DepartureRecord == "良好")
                    rbtnGood.Checked = true;
            }

            //初始化婚姻
            if (!string.IsNullOrEmpty(_model.Marriaged))
            {
                if (_model.Marriaged == "未婚")
                    rbtnNotMarriged.Checked = true;
                if (_model.Marriaged == "已婚")
                    rbtnMarriged.Checked = true;
                if (_model.Marriaged == "离婚")
                    rbtnDivorced.Checked = true;
                if (_model.Marriaged == "丧偶")
                    rbtnLosePair.Checked = true;
            }

            //初始化身份确认
            if (!string.IsNullOrEmpty(_model.Identification))
            {
                if (_model.Identification.Contains("身份证"))
                    checkBoxX1.Checked = true;
                if (_model.Identification.Contains("全家户口本"))
                    checkBoxX2.Checked = true;
                if (_model.Identification.Contains("在职证明"))
                    checkBoxX3.Checked = true;
                if (_model.Identification.Contains("营业执照"))
                    checkBoxX4.Checked = true;
                if (_model.Identification.Contains("学生证"))
                    checkBoxX5.Checked = true;
                if (_model.Identification.Contains("出生证"))
                    checkBoxX6.Checked = true;
                if (_model.Identification.Contains("结婚证"))
                    checkBoxX7.Checked = true;
                if (_model.Identification.Contains("退休证"))
                    checkBoxX8.Checked = true;
            }

        }

        private List<CheckBoxX> _chks = new List<CheckBoxX>();
        private Model.VisaInfo _model;

        private void FrmSetValue_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false; 
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            rbtnNone.CheckedChanged += UpdateDepartureRecord;
            rbtnNormal.CheckedChanged += UpdateDepartureRecord;
            rbtnGood.CheckedChanged += UpdateDepartureRecord;

            rbtnNotMarriged.CheckedChanged += UpdateMarrige;
            rbtnMarriged.CheckedChanged += UpdateMarrige;
            rbtnDivorced.CheckedChanged += UpdateMarrige;
            rbtnLosePair.CheckedChanged += UpdateMarrige;

            checkBoxX1.CheckedChanged += UpdateIdentification;
            checkBoxX2.CheckedChanged += UpdateIdentification;
            checkBoxX3.CheckedChanged += UpdateIdentification;
            checkBoxX4.CheckedChanged += UpdateIdentification;
            checkBoxX5.CheckedChanged += UpdateIdentification;
            checkBoxX6.CheckedChanged += UpdateIdentification;
            checkBoxX7.CheckedChanged += UpdateIdentification;
            checkBoxX8.CheckedChanged += UpdateIdentification;

            _chks.Add(checkBoxX1);
            _chks.Add(checkBoxX2);
            _chks.Add(checkBoxX3);
            _chks.Add(checkBoxX4);
            _chks.Add(checkBoxX5);
            _chks.Add(checkBoxX6);
            _chks.Add(checkBoxX7);
            _chks.Add(checkBoxX8);

            txtLiuShui.TextChanged += UpdateFinacial;
            txtFangchan.TextChanged += UpdateFinacial;
            txtCunkuan.TextChanged += UpdateFinacial;
            txtNianXin.TextChanged += UpdateFinacial;
            txtChechan.TextChanged += UpdateFinacial;
            txtFinacialCapacityOther.TextChanged += UpdateFinacial;

            btnAll.Click+=btnAll_Click;
            btnNo.Click+=btnNo_Click;
            btnReverse.Click+=btnReverse_Click;

        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            for (int i = 0; i != _chks.Count; ++i)
                _chks[i].Checked = !_chks[i].Checked;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i != _chks.Count; ++i)
                _chks[i].Checked = false;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i != _chks.Count; ++i)
                _chks[i].Checked = true;
        }

        private void UpdateIdentification(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _chks.Count; i++)
            {
                if (_chks[i].Checked)
                    sb.Append(_chks[i].Text + "、");
            }
            string res = sb.ToString();
            if (res.EndsWith("、"))
                res = res.TrimEnd('、');

            txtIdentification.Text = res;
        }
        private void UpdateDepartureRecord(object sender, EventArgs e)
        {
            txtDepartureRecord.Text = ((RadioButton)sender).Text;
        }

        private void UpdateMarrige(object sender, EventArgs e)
        {
            txtMarrige.Text = ((RadioButton)sender).Text;
        }

        private void UpdateFinacial(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(txtLiuShui.Text.Trim()))
                sb.AppendFormat("流水:（{0}）、", txtLiuShui.Text);

            if (!string.IsNullOrEmpty(txtFangchan.Text.Trim()))
                sb.AppendFormat("房产证明:（{0}平方米）、", txtFangchan.Text);

            if (!string.IsNullOrEmpty(txtCunkuan.Text.Trim()))
                sb.AppendFormat("存款证明:（{0}万）、", txtCunkuan.Text);

            if (!string.IsNullOrEmpty(txtNianXin.Text.Trim()))
                sb.AppendFormat("年薪:（{0}万）、", txtNianXin.Text);

            if (!string.IsNullOrEmpty(txtChechan.Text.Trim()))
                sb.AppendFormat("车产证明:（{0}牌）、", txtChechan.Text);

            if (!string.IsNullOrEmpty(txtFinacialCapacityOther.Text.Trim()))
                sb.AppendFormat("其他:（{0}）、", txtFinacialCapacityOther.Text);


            string res = sb.ToString();
            if (res.EndsWith("、"))
                res = res.TrimEnd('、');
            txtFinancialCapacity.Text = res;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            _model.FinancialCapacity = txtFinancialCapacity.Text;
            _model.Residence = txtResidence.Text;
            _model.DepartureRecord = txtDepartureRecord.Text;
            _model.Marriaged = txtMarrige.Text;
            _model.Identification = txtIdentification.Text;
            _model.FinancialCapacity = txtFinancialCapacity.Text;
            _model.Phone = txtPhone.Text;
            _model.Occupation = txtOccupation.Text;
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
