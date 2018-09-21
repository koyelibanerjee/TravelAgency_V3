using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.Common.FrmSetValues;

namespace TravelAgency.CSUI.Financial.FrmSub
{
    public partial class FrmCustomerBalance : Form
    {
        private readonly BLL.Joint.CustomerBalance_AuthUser _bllCustomerBalanceAuthUser = new BLL.Joint.CustomerBalance_AuthUser();
        private string _clientName;
        private decimal _needBalanceCount;
        private bool _forSelectBalance = false;
        public Guid RetBalanceId = Guid.Empty;

        public FrmCustomerBalance(string clientName = "", decimal needBalanceCount = 0)
        {
            if (this.Modal)
                this.StartPosition = FormStartPosition.CenterParent;
            else
                this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            _clientName = clientName;
            _needBalanceCount = needBalanceCount;
            if (!string.IsNullOrEmpty(_clientName))
                _forSelectBalance = true;
        }

        private void FrmSelUser_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            LoadDataToDgv();
            dataGridView1.CellMouseUp += dataGridView1_CellMouseUp;
            dataGridView1.RowsAdded += DataGridView1_RowsAdded;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!_forSelectBalance)
                return;

            var list = dataGridView1.DataSource as List<Model.CustomerBalance_AuthUser>;
            var customerBalanceAuthUser = list[dataGridView1.SelectedRows[0].Index];

            if (customerBalanceAuthUser.BalanceAmount < _needBalanceCount)
            {
                MessageBoxEx.Show($"选中项余额不足{_needBalanceCount},请重新选择!");
                return;
            }

            RetBalanceId = customerBalanceAuthUser.BalanceId;

            if (MessageBoxEx.Show("提示", "确认选择", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;
        }

        private void LoadDataToDgv()
        {
            string where = "";
            if (!string.IsNullOrEmpty(_clientName))
                where = $" CustomerName = '{_clientName}'";
            var list = _bllCustomerBalanceAuthUser.GetModelList(where);

            if (list == null || list.Count == 0)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

            dataGridView1.DataSource = list;
            DataGridView1_RowsAdded(null, null);



        }

        private void FrmSelUser_DoubleClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// dgv右键响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {

                    //若行已是选中状态就不再进行设置
                    //如果没选中当前活动行则选中这一行
                    if (dataGridView1.Rows[e.RowIndex].Selected == false)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dataGridView1.SelectedRows.Count == 1)
                    {
                        if (e.ColumnIndex != -1) //选中表头了
                            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        else
                            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[0];
                    }
                    //弹出操作菜单
                    cmsDgv.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void 分配给选中用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDataToDgv();
        }





    }
}
