using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.Common.FrmSetValues;
using TravelAgency.Model;

namespace TravelAgency.CSUI.Financial.FrmSub
{
    public partial class FrmActivityOrder : Form
    {
        private readonly BLL.ActivityOrder _bllActivityOrder = new BLL.ActivityOrder();
        private readonly string _customerName;
        private readonly int _peopleCnt;
        private readonly Dictionary<string, int> _dictCount;

        public string RetOrderNo;
        public decimal RetActivityPrice;


        private FrmActivityOrder()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
        }

        public FrmActivityOrder(string custName, int cnt,Dictionary<string,int> dict) : this()
        {
            this._customerName = custName;
            this._peopleCnt = cnt;
            _dictCount = dict;
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
            dataGridView1.DoubleClick += DataGridView1_DoubleClick;
        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            选择当前项ToolStripMenuItem_Click(null, null);
        }

        private void LoadDataToDgv()
        {
            string where = $" CustomerName = '{_customerName}' and BalanceBooks > 0 ";
            var list = _bllActivityOrder.GetModelList(where);
            foreach (var activityOrder in list)
            {
                if (_dictCount.ContainsKey(activityOrder.ActivityOrderNo))
                    activityOrder.BalanceBooks -= _dictCount[activityOrder.ActivityOrderNo];
            }
            dataGridView1.DataSource = list;
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


        private void 选择当前项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = dataGridView1.DataSource as List<ActivityOrder>;
            var item = list[dataGridView1.SelectedRows[0].Index];

            if (item.BalanceBooks < _peopleCnt)
            {
                MessageBoxEx.Show("剩余量不足，请重新选择!!!");
                return;
            }

            this.RetOrderNo = item.ActivityOrderNo;
            this.RetActivityPrice = item.Price_Active.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
