using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.BLL;
using TravelAgency.Common;
using TravelAgency.CSUI.Properties;
using TravelAgency.Model.Enums;
using VisaInfo = TravelAgency.Model.VisaInfo;

namespace TravelAgency.CSUI.Visa.FrmMain
{
    public partial class FrmDeniedVisaInfoManage : Form
    {
        private readonly TravelAgency.BLL.DeniedVisaInfo _bllDeniedVisaInfo = new TravelAgency.BLL.DeniedVisaInfo();
        private int _curPage = 1;
        private int _pageCount = 0;
        private int _pageSize = 0;
        private int _recordCount = 0;
        private bool _init = false;
        private string _where = string.Empty;

        public FrmDeniedVisaInfoManage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void FrmDeniedVisaInfoManage_Load(object sender, EventArgs e)
        {
            //初始化一些控件
            ControlInitializer.InitCombo(cbPageSize, PageSize.ValueList, ComboBoxStyle.DropDownList, 2);
            _pageSize = int.Parse(cbPageSize.Text);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; //列宽自适应,一定不能用AllCells
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders; //这里也一定不能AllCell自适应!
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridView1.DefaultCellStyle.Font = new Font("微软雅黑", 9.0f, FontStyle.Bold);
            bgWorkerLoadData.WorkerReportsProgress = true;
            progressLoading.Visible = false;

            LoadDataToDgvAsyn();
            _init = true;
        }

        #region 自己的按钮

        private void btnShowToday_Click(object sender, EventArgs e)
        {
            txtSchEntryTimeFrom.Text = DateTimeFormator.DateTimeToString(DateTime.Today) + " 00:00";
            txtSchEntryTimeTo.Text = DateTimeFormator.DateTimeToString(DateTime.Today) + " 16:00";
            btnSearch_Click(null, null);
        }

        #endregion

        #region dgv用到的相关方法

        /// <summary>
        /// 获取选中项的list
        /// </summary>
        /// <returns></returns>
        private List<Model.DeniedVisaInfo> GetDgvSelList()
        {
            int count = this.dataGridView1.SelectedRows.Count;
            List<Model.DeniedVisaInfo> list = new List<Model.DeniedVisaInfo>();
            for (int i = count - 1; i >= 0; --i)
            {
                Model.DeniedVisaInfo model = (dataGridView1.DataSource as List<Model.DeniedVisaInfo>)[dataGridView1.SelectedRows[i].Index];
                if (model != null)
                    list.Add(model);
            }
            return list;
        }

        

        public void LoadDataToDataGridView(int page) //刷新后保持选中
        {
            _where = GetWhereCondition();
            var selRows = SelectionKeeper.GetSelectedGuids(dataGridView1, "Id");
            int rowsCnt, rowIdx, colIdx;
            SelectionKeeper.GetSelectedPos(dataGridView1, out rowsCnt, out rowIdx, out colIdx);

            dataGridView1.DataSource = _bllDeniedVisaInfo.GetListByPageOrderByPK(page, _pageSize, _where);
            SelectionKeeper.RestoreSelection(selRows, dataGridView1, "Id");
            SelectionKeeper.RestoreSelectedPos(dataGridView1, rowsCnt, rowIdx, colIdx);
            dataGridView1.Update();
            
        }

        private void UpdateState()
        {
            _where = GetWhereCondition();
            _recordCount = _bllDeniedVisaInfo.GetRecordCount(_where);
            _pageCount = (int)Math.Ceiling((double)_recordCount / (double)_pageSize);
            if (_curPage == 1)
                btnPagePre.Enabled = false;
            else
                btnPagePre.Enabled = true;
            if (_curPage == _pageCount)
                btnPageNext.Enabled = false;
            else
                btnPageNext.Enabled = true;
        }
        #endregion

        #region dgv的bar栏和搜索栏

        private void btnPageNext_Click(object sender, EventArgs e)
        {
            ++_curPage;
            LoadDataToDgvAsyn();
        }

        private void btnPagePre_Click(object sender, EventArgs e)
        {
            --_curPage;
            LoadDataToDgvAsyn();
        }

        private void btnPageFirst_Click(object sender, EventArgs e)
        {
            _curPage = 1;
            LoadDataToDgvAsyn();
        }

        private void btnPageLast_Click(object sender, EventArgs e)
        {
            _curPage = _pageCount;
            LoadDataToDgvAsyn();
        }


        private void cbPageSize_TextChanged(object sender, EventArgs e)
        {
            if (!_init) //因为窗口初始化的时候也会调用，所以禁止多次调用
                return;

            _pageSize = int.Parse(cbPageSize.Text);
            LoadDataToDgvAsyn();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            _where = GetWhereCondition();
            LoadDataToDgvAsyn();
            //搜索的时候，返回到第一页，这个还是合理的
            _curPage = 1;
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            btnClearSchConditions_Click(null, null);
            _where = string.Empty;
            LoadDataToDgvAsyn();
        }

        private string GetWhereCondition()
        {
            List<string> conditions = new List<string>();
            SearchCondition.GetFuzzyQueryCondition(conditions, "PassportNo", txtSchPassportNo.Text);
            SearchCondition.GetFuzzyQueryCondition(conditions, "Name", txtSchName.Text);
            SearchCondition.GetSpanQueryCondition(conditions, "EntryTime", txtSchEntryTimeFrom.Text, txtSchEntryTimeTo.Text);
            return SearchCondition.GetSearchConditon(conditions);
        }

        private void btnClearSchConditions_Click(object sender, EventArgs e)
        {
            txtSchPassportNo.Text = string.Empty;
            txtSchEntryTimeFrom.Text = string.Empty;
            txtSchEntryTimeTo.Text = string.Empty;
            txtSchName.Text = string.Empty;
            txtSchPassportNo.Text = string.Empty;
        }
        #endregion
        #region dgv消息相应

        /// <summary>
        /// 实现ctrl+c 复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridView1.CurrentCell.Value != null && e.Control && e.KeyCode == Keys.C)
                复制ToolStripMenuItem_Click(null, null);
        }

        /// <summary>
        /// dgv设置行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var total = dataGridView1.Rows.Count;
            //设置行号
            for (int i = 0; i < total; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                row.HeaderCell.Value = (i + 1).ToString();
            }
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
                    cmsDgvRb.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }


        #endregion

        #region dgv右键菜单响应

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBoxEx.Show("请选中一条记录复制!");
                return;
            }

            if (dataGridView1.CurrentCell.Value != null)
                Clipboard.SetText(dataGridView1.CurrentCell.Value.ToString());
        }

        /// <summary>
        /// 刷新dgv数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsItemRefreshState_Click(object sender, EventArgs e)
        {
            LoadDataToDgvAsyn();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsItemDelete_Click(object sender, EventArgs e)
        {
            if (GlobalUtils.LoginUserLevel != RigthLevel.Manager)
            {
                MessageBoxEx.Show("权限不足!");
                return;
            }

            int count = this.dataGridView1.SelectedRows.Count;
            if (MessageBoxEx.Show("确认删除" + count + "条记录?", Resources.Confirm, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            bool b = _bllDeniedVisaInfo.DeleteList(GetDgvSelList());
            GlobalUtils.MessageBoxWithRecordNum("删除", b ? count : 0, count);
            LoadDataToDgvAsyn();
        }
        #endregion


        #region backgroundworker load data to datagridview

        /// <summary>
        /// 显示进度条
        /// </summary>
        public void ShowProgress()
        {
            progressLoading.Visible = true;
            progressLoading.IsRunning = true;
        }

        private void LoadDataToDgvAsyn()
        {
            while (bgWorkerLoadData.IsBusy)
            {
                ;
            }
            ShowProgress();
            bgWorkerLoadData.RunWorkerAsync();
        }

        private void bgWorkerLoadData_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    LoadDataToDataGridView(_curPage);
                    UpdateState();
                }));
            }
            else
            {
                LoadDataToDataGridView(_curPage);
                UpdateState();
            }
        }

        private void bgWorkerLoadData_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.progressLoading.Visible = false;
            this.progressLoading.IsRunning = false;
        }
        #endregion



    }
}
