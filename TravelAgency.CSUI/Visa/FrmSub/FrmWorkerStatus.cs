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

namespace TravelAgency.CSUI.Visa.FrmSub
{
    public partial class FrmWorkerStatus : Form
    {
        private readonly BLL.WorkerQueue _bllWorkerQueue = new BLL.WorkerQueue();
        public string SelWorkId { get; set; }

        public FrmWorkerStatus()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
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
        }


        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
                return;

            var list = dataGridView1.DataSource as List<Model.WorkerQueue>;

            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                if (list[i].IsBusy)
                {
                    dataGridView1.Rows[i].Cells["IsBusy"].Value = "忙";
                    dataGridView1.Rows[i].Cells["IsBusy"].Style.BackColor = Color.Orange;
                }
                else
                {
                    dataGridView1.Rows[i].Cells["IsBusy"].Value = "不忙";
                    dataGridView1.Rows[i].Cells["IsBusy"].Style.BackColor = Color.White;
                }

                if (list[i].CanAccept)
                {
                    dataGridView1.Rows[i].Cells["CanAccept"].Value = "能";
                    dataGridView1.Rows[i].Cells["CanAccept"].Style.BackColor = Color.Orange;
                }
                else
                {
                    dataGridView1.Rows[i].Cells["CanAccept"].Value = "不能";
                    dataGridView1.Rows[i].Cells["CanAccept"].Style.BackColor = Color.OrangeRed;
                }

                if (!list[i].IsBusy && list[i].CanAccept)
                {
                    dataGridView1.Rows[i].Cells["CanAccept"].Style.BackColor = Color.ForestGreen;
                    dataGridView1.Rows[i].Cells["IsBusy"].Style.BackColor = Color.ForestGreen;
                }


            }


        }

        private void LoadDataToDgv()
        {
            var list = _bllWorkerQueue.GetModelList("");
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
