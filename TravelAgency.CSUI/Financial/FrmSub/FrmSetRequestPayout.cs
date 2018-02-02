using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.Common;

namespace TravelAgency.CSUI.Financial.FrmSub
{
    public partial class FrmSetRequestPayout : Form
    {
        private List<Model.Visa> _list;
        private BLL.Visa _bllVisa = new BLL.Visa();
        private Action<int> _updateDel;
        private int _curpage;

        public FrmSetRequestPayout()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            InitializeComponent();
        }

        public FrmSetRequestPayout(List<Model.Visa> modelList, Action<int> updateDel, int curpage)
            : this()
        {
            _list = modelList;
            _updateDel = updateDel;
            _curpage = curpage;
        }

        private bool CtrlsToModel(Model.Visa model)
        {
            //TODO:这样其实是不对的，如果失败了，对象的数据还是被改变了，就是C++中的异常安全性其实，后面再改把，现在头有点晕被搞得
            try
            {
                if (!string.IsNullOrEmpty(txtRealTime.Text))
                    model.RealTime = DateTime.Parse(txtRealTime.Text);
                if (!string.IsNullOrEmpty(txtFinishTime.Text))
                    model.FinishTime = DateTime.Parse(txtFinishTime.Text);
                //if (!string.IsNullOrEmpty(txtReceipt.Text))
                //    model.Receipt = decimal.Parse(txtReceipt.Text);
                if (!string.IsNullOrEmpty(txtQuidco.Text))
                    model.Quidco = decimal.Parse(txtQuidco.Text);
                if (!string.IsNullOrEmpty(txtConsulateCost.Text))
                    model.ConsulateCost = decimal.Parse(txtConsulateCost.Text);
                if (!string.IsNullOrEmpty(txtVisaPersonCost.Text))
                    model.VisaPersonCost = decimal.Parse(txtVisaPersonCost.Text);
                if (!string.IsNullOrEmpty(txtMailCost.Text))
                    model.MailCost = decimal.Parse(txtMailCost.Text);
                if (!string.IsNullOrEmpty(txtPicture.Text))
                    model.Picture = decimal.Parse(txtPicture.Text);
                if (!string.IsNullOrEmpty(txtInvitationCost.Text))
                    model.InvitationCost = decimal.Parse(txtInvitationCost.Text);
                if (!string.IsNullOrEmpty(txtPrice.Text))
                    model.Price = decimal.Parse(txtPrice.Text);
                //操作人员还没设置
            }
            catch (Exception)
            {
                MessageBoxEx.Show("请检查输入格式是否正确!");
                return false;
            }
            return true;
        }

        private void InitCtrls()
        {
            if (_list.Count > 1)
                return;
            txtRealTime.Text = DateTimeFormator.DateTimeToString(_list[0].RealTime);
            txtFinishTime.Text = DateTimeFormator.DateTimeToString(_list[0].FinishTime);
            txtQuidco.Text = _list[0].Quidco.ToString();
            txtConsulateCost.Text = _list[0].ConsulateCost.ToString();
            txtVisaPersonCost.Text = _list[0].VisaPersonCost.ToString();
            txtMailCost.Text = _list[0].MailCost.ToString();
            txtPicture.Text = _list[0].Picture.ToString();
            txtInvitationCost.Text = _list[0].InvitationCost.ToString();
            txtPrice.Text = _list[0].Price.ToString();
        }

        private void FrmSetRequestPayout_Load(object sender, EventArgs e)
        {
            txtDoPerson.Enabled = false;
            txtDoPerson.Text = GlobalUtils.LoginUser.UserName;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; //列宽自适应,一定不能用AllCells
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders; //这里也一定不能AllCell自适应!
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.DataSource = _list;
            dataGridView1.ReadOnly = false;

            InitCtrls();

        }



        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Receipt")
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || dataGridView1.Rows[e.RowIndex].Cells["Client"].Value == null)
                    return;
                string Receipt = dataGridView1.Rows[e.RowIndex].Cells["Receipt"].Value.ToString();
                string client = dataGridView1.Rows[e.RowIndex].Cells["Client"].Value.ToString();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["Client"].Value.ToString() == client) //客户相同
                        dataGridView1.Rows[i].Cells[e.ColumnIndex].Value = Receipt;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("是否提交修改?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;
            for (int i = 0; i != _list.Count; ++i)
            {
                var model = _list[i];
                if (!CtrlsToModel(model))
                {
                    return;
                }
            }

            int succeed = _bllVisa.UpdateList(_list);
            GlobalUtils.MessageBoxWithRecordNum("更新", succeed, _list.Count);
            this.DialogResult = DialogResult.OK;
            _updateDel(_curpage);
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
