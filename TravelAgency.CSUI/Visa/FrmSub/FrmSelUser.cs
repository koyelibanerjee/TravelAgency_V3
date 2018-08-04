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
using TravelAgency.Common;

namespace TravelAgency.CSUI.Visa.FrmSub
{
    public partial class FrmSelUser : Form
    {
        private readonly BLL.JobAssignment _bllJobAssignment = new BLL.JobAssignment();
        private readonly BLL.AuthUser _bllAuthUser = new BLL.AuthUser();
        public string SelWorkId { get; set; }

        public FrmSelUser()
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
        }

        private void LoadDataToDgv()
        {
            var list = _bllAuthUser.GetModelList(" departmentid = 'A86ED375-76DB-45DF-A4E9-D0BB8815D49C' and " +
                                                 $"district = {GlobalUtils.LoginUser.District} ");
            dataGridView1.DataSource = list;
        }

        private void FrmSelUser_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
                SelWorkId = dataGridView1.CurrentRow.Cells["WorkId"].Value.ToString();
            else return;
            //
            this.DialogResult = DialogResult.OK;
            this.Close();
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
            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBoxEx.Show("请选中一位用户!");
                return;
            }

            if (dataGridView1.CurrentRow != null)
                SelWorkId = dataGridView1.CurrentRow.Cells["WorkId"].Value.ToString();
            else return;
            //
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
