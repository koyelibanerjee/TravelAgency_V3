using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.Common;
using TravelAgency.Common.FTP;

namespace TravelAgency.OrdersManagement.FrmSub
{
    public partial class FrmOrderFilesManage : Form
    {
        private readonly BLL.OrderFiles _bll = new BLL.OrderFiles();
        private readonly Model.Orders _model;
        public FrmOrderFilesManage(Model.Orders model)
        {
            if (this.Modal)
                this.StartPosition = FormStartPosition.CenterParent;
            else
                this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            _model = model;
        }

        private void FrmSelUser_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Text += " 订单号:" + _model.OrderNo;

            LoadDataToDgv();
            dataGridView1.CellMouseUp += dataGridView1_CellMouseUp;
            dataGridView1.RowsAdded += DataGridView1_RowsAdded;
        }


        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }

        private void LoadDataToDgv()
        {
            var list = _bll.GetModelList(" ordersid = " + _model.Id + " ");
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

        #region Utils
        private List<Model.OrderFiles> DgvDataSourceToList()
        {
            return dataGridView1.DataSource as List<Model.OrderFiles>;
        }

        /// <summary>
        /// 返回当前选择的行的visaModel的List
        /// </summary>
        /// <returns></returns>
        private List<Model.OrderFiles> GetSelectedModelList()
        {
            var modelList = DgvDataSourceToList();
            List<Model.OrderFiles> res = new List<Model.OrderFiles>();
            for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
                res.Add(modelList[dataGridView1.SelectedRows[i].Index]);
            return res.Count > 0 ? res : null;
        }
        #endregion

        private void 下载全部附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Common.PictureHandler.OrderFilesHandler().DownloadOrderFiles(_model);
        }

        private void 上传附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = GlobalUtils.ShowOpenFileDlg("*|*.*");
            if (string.IsNullOrEmpty(filename))
                return;
            new Common.PictureHandler.OrderFilesHandler().UploadOrderFile(filename, _model.Id.Value);
            LoadDataToDgv();
        }

        private void 下载选中附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileList = GetSelectedModelList();
            if (fileList.Count < 1)
                return;

            string dstPath = GlobalUtils.ShowBrowseFolderDlg();
            if (string.IsNullOrEmpty(dstPath))
                return;

            FtpHandler.ChangeFtpUri(new Common.PictureHandler.OrderFilesHandler().RemoteRootPath);
            for (int i = 0; i < fileList.Count; ++i)
            {
                FtpHandler.Download(dstPath, fileList[i].FileName);
                if (File.Exists(dstPath + "/" + fileList[i].OrigFileName))
                    File.Delete(dstPath + "/" + fileList[i].OrigFileName);
                File.Move(dstPath + "/" + fileList[i].FileName, dstPath + "/" + fileList[i].OrigFileName);
            }

            MessageBoxEx.Show("下载文件成功!");
            Process.Start(dstPath);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadDataToDgv();
        }
    }
}
