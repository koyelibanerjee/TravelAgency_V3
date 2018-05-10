using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.Common;
using TravelAgency.CSUI.FrmSub;
using TravelAgency.Model;

namespace TravelAgency.OrdersManagement
{
    public partial class FrmMessageManage : Form
    {
        private readonly TravelAgency.BLL.Message _bllMessage = new TravelAgency.BLL.Message();

        private int _curPage = 1;
        private int _pageCount = 0;
        private int _pageSize;
        private int _recordCount = 0;
        private string _where = string.Empty;

        public FrmMessageManage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _recordCount = _bllMessage.GetRecordCount(_where);
            _pageCount = (int)Math.Ceiling(_recordCount / (double)_pageSize);


            InitComboboxs();

            //初始化一些控件
            //txtPicPath.Text = GlobalInfo.AppPath;
            cbPageSize.Items.Add("30");
            cbPageSize.Items.Add("50");
            cbPageSize.Items.Add("100");
            cbPageSize.Items.Add("300");
            cbPageSize.Items.Add("500");
            cbPageSize.Items.Add("1000");
            cbPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPageSize.SelectedIndex = 2;

            _pageSize = int.Parse(cbPageSize.Text);
            cbPageSize.TextChanged += CbPageSize_TextChanged;
            this.FormClosed += FrmMessageManage_FormClosed;

            dataGridView1.DoubleClick += DataGridView1_DoubleClick;
            StyleControler.SetDgvStyle(dataGridView1);

            bgWorkerLoadData.WorkerReportsProgress = true;

            progressLoading.Visible = false;
            LoadDataToDgvAsyn();
        }

        private void FrmMessageManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void InitComboboxs()
        {
            string tablename = "Message";

            cbMsgType.Items.Add("全部");

            cbMsgState.Items.Add("全部");

            cbMsgState.SelectedIndex = 0;
            cbMsgType.SelectedIndex = 0;

            cbMsgState.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMsgType.DropDownStyle = ComboBoxStyle.DropDownList;


            //var list = Common.Enums.OrderInfo_PaymentPlatform.valueKeyMap.Keys;
            //if (list != null)
            //    foreach (var item in list)
            //        cbToUser.Items.Add(item);

            //var list1 = Common.Enums.ReplyResult.valList;
            //if (list1 != null)
            //    foreach (var item in list1)
            //        cbMsgState.Items.Add(item);

        }

        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            修改ToolStripMenuItem_Click(null, null);
        }

        private void CbPageSize_TextChanged(object sender, EventArgs e)
        {
            _pageSize = int.Parse(cbPageSize.Text);
            LoadDataToDgvAsyn();
        }



        #region dgv用到的相关方法

        /// <summary>
        /// 显示进度条
        /// </summary>
        public void ShowProgress()
        {
            progressLoading.Visible = true;
            progressLoading.IsRunning = true;
        }

        public void LoadDataToDataGridView(int page) //刷新后保持选中
        {
            _where = GetWhereCondition();
            int curSelectedRow = -1;
            if (dataGridView1.SelectedRows.Count > 0)
                curSelectedRow = dataGridView1.SelectedRows[0].Index;
            dataGridView1.DataSource = _bllMessage.GetListByPageOrderById(_where, _curPage, _pageSize);
            if (curSelectedRow != -1 && dataGridView1.Rows.Count > curSelectedRow)
                dataGridView1.CurrentCell = dataGridView1.Rows[curSelectedRow].Cells[0];
            dataGridView1.Update();
        }

        private void UpdateState()
        {
            _recordCount = _bllMessage.GetRecordCount(_where);
            _pageCount = (int)Math.Ceiling((double)_recordCount / (double)_pageSize);
            if (_curPage == 1)
                btnPagePre.Enabled = false;
            else
                btnPagePre.Enabled = true;
            if (_curPage == _pageCount)
                btnPageNext.Enabled = false;
            else
                btnPageNext.Enabled = true;

            lbRecordCount.Text = "共有记录:" + _recordCount + "条";
            lbCurPage.Text = "当前为第" + _curPage + "页";
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _where = GetWhereCondition();
            _curPage = 1;
            LoadDataToDgvAsyn();
        }

        private string GetWhereCondition()
        {
            List<string> conditions = new List<string>();

            if (!string.IsNullOrEmpty(txtSchEntryTimeFrom.Text.Trim()) && !string.IsNullOrEmpty(txtSchEntryTimeTo.Text.Trim()))
            {
                conditions.Add(" (EntryTime between '" + txtSchEntryTimeFrom.Text + "' and " + " '" + txtSchEntryTimeTo.Text +
                               "') ");
            }

            if (!string.IsNullOrEmpty(txtOrderNo.Text.Trim()))
            {
                conditions.Add(" (OrderNo like '%" + txtOrderNo.Text + "%') ");
            }

            if (cbMsgType.Text != "全部")
                conditions.Add(" MsgType = '" + cbMsgType.Text + "' ");

            if (cbMsgState.Text != "全部")
                conditions.Add(" MsgState = '" + cbMsgState.Text + "' ");

            if (!string.IsNullOrEmpty(txtMsgContent.Text.Trim()))
                conditions.Add(" (MsgContent like '%" + txtMsgContent.Text + "%') ");

            if (!string.IsNullOrEmpty(txtToUser.Text.Trim()))
                conditions.Add(" (ToUser like '%" + txtToUser.Text + "%') ");

            conditions.Add(string.Format(" (ToUser = '{0}' or FromUser = '{1}') ",
                GlobalUtils.LoginUser.UserName, GlobalUtils.LoginUser.UserName));

            string[] arr = conditions.ToArray();
            string where = string.Join(" and ", arr);
            return where;
        }


        private void btnClearSchConditions_Click(object sender, EventArgs e)
        {
            //txtClient.Text = "";
            cbMsgType.Text = "全部";
            cbMsgState.Text = "全部";
            txtToUser.Text = "全部";
            //cbMessageState.Text = "全部";
            //cbDepatureType.Text = "";
            txtSchEntryTimeFrom.Text = "";
            txtSchEntryTimeTo.Text = "";
            txtOrderNo.Text = "";
        }


        #endregion
        #region dgv消息相应
        /// <summary>
        /// 根据送签状态设置单元格颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        /// <summary>
        /// dgv设置行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //int digit = GlobalUtils.DecimalDigits;
            var list = DgvDataSourceToList();
            //int hasTypedInGuestInfoCount = 0;
            //int sucNum = 0, proNum = 0, refuseNum = 0, notHandleNum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                row.HeaderCell.Value = (i + 1).ToString();

                //在这里控制单元格的显示
                //if (list[i].GuestInfoTypedIn) ++hasTypedInGuestInfoCount;
                //if (list[i].ReplyResult == "成功")
                //    ++sucNum;
                //if (list[i].ReplyResult == "处理中")
                //    ++proNum;
                //if (list[i].ReplyResult == "拒绝")
                //    ++refuseNum;
                //if (list[i].ReplyResult == "未处理")
                //    ++notHandleNum;
                //SetRowColorByReserveTime(row);
                //SetRowColorByGuestInfoTypedIn(row);

                for (int j = 0; j != dataGridView1.ColumnCount; ++j)
                {
                    var value = dataGridView1.Rows[i].Cells[j].Value;
                    if (dataGridView1.Rows[i].Cells[j].ValueType == typeof(decimal?) && value != null)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = DecimalHandler.DecimalToString((decimal?)value);
                    }
                }

                //row.Cells["OrderType"].Value = Common.Enums.Message_OrderType.KeyToValue(list[i].OrderType);
                //row.Cells["MessageState"].Value = Common.Enums.Message_MessageState.KeyToValue(list[i].MessageState);
                //row.Cells["PaymentPlatform"].Value = Common.Enums.OrderInfo_PaymentPlatform.KeyToValue(list[i].PaymentPlatform);
            }

            //lbGuestInfoTypedInCount.Text = string.Format("客人信息已录入: {0}/{1}", hasTypedInGuestInfoCount, dataGridView1.Rows.Count);
            //StringBuilder sb = new StringBuilder();
            //sb.Append(" 回复结果统计:");
            //if (sucNum > 0)
            //    sb.AppendFormat("成功:{0} ", sucNum);
            //if (proNum > 0)
            //    sb.AppendFormat("处理中:{0} ", proNum);
            //if (refuseNum > 0)
            //    sb.AppendFormat("拒绝:{0} ", refuseNum);
            //if (notHandleNum > 0)
            //    sb.AppendFormat("未处理:{0} ", notHandleNum);
            //lbReplyResultCount.Text = sb.ToString();
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
                        {
                            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[0];
                        }

                    }
                    //弹出操作菜单
                    cmsDgvRb.Show(MousePosition.X, MousePosition.Y);

                }
            }
        }

        #endregion

        #region dgv右键菜单相应
        /// <summary>
        /// 刷新dgv数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsItemRefreshState_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView(_curPage);
        }

        #endregion


        #region backgroundworker load data to datagridview

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

        private void bgWorkerLoadData_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            //this.progressLoading.Visible = true;
            //this.progressLoading.IsRunning = true;
        }

        private void bgWorkerLoadData_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.progressLoading.Visible = false;
            this.progressLoading.IsRunning = false;
        }
        #endregion


        #region 按钮事件
        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            //ExcelGenerator.GetStatisticPersonalTable(dataGridView1.DataSource as List<Model.PersonalStat>);
        }

        private void btnAddFromExcel_Click(object sender, EventArgs e)
        {
            //string filename = GlobalUtils.ShowOpenFileDlg("Excel文件|*.xls;*.xlsx");
            //if (string.IsNullOrEmpty(filename))
            //    return;
            //int res = Common.Excel.MessageExcelParser.ParseExcel(filename, Common.Excel.MessageExcelParser.ExcelType.Type01_DaZhong);
            //MessageBoxEx.Show("导入" + res + "条数据成功！");
            //LoadDataToDgvAsyn();
        }






        private void btnTimeSpanChoose_Click(object sender, EventArgs e)
        {
            FrmTimeSpanChoose frm = new FrmTimeSpanChoose();
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;
            txtSchEntryTimeFrom.Text = DateTimeFormator.DateTimeToString(frm.TimeSpanFrom, DateTimeFormator.TimeFormat.Type14LongTime1);
            txtSchEntryTimeTo.Text = DateTimeFormator.DateTimeToString(frm.TimeSpanTo, DateTimeFormator.TimeFormat.Type14LongTime1);
        }

        #endregion

        #region Utils
        private List<Model.Message> DgvDataSourceToList()
        {
            return dataGridView1.DataSource as List<Model.Message>;
        }

        /// <summary>
        /// 返回当前选择的行的visaModel的List
        /// </summary>
        /// <returns></returns>
        private List<Model.Message> GetSelectedModelList()
        {
            var visaList = dataGridView1.DataSource as List<Model.Message>;
            List<Model.Message> res = new List<Model.Message>();
            for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
                res.Add(DgvDataSourceToList()[dataGridView1.SelectedRows[i].Index]);
            return res.Count > 0 ? res : null;
        }
        #endregion
        #region 右键菜单响应
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (GlobalUtils.LoginUser.UserLevel == Common.Enums.UserLevel.Checker)
            //{
            //    MessageBoxEx.Show("权限不足!");
            //    return;
            //}

            int count = this.dataGridView1.SelectedRows.Count;
            if (MessageBoxEx.Show("确认删除" + count + "条记录?", "提醒", MessageBoxButtons.OKCancel)
                == DialogResult.Cancel)
                return;
            var modelList = GetSelectedModelList();
            int res = _bllMessage.DeleteList(modelList);

            GlobalUtils.MessageBoxWithRecordNum("删除", res, count);
            LoadDataToDataGridView(_curPage);
            UpdateState();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //if (GlobalUtils.LoginUser.UserLevel == Common.Enums.UserLevel.Checker)
            //{
            //    MessageBoxEx.Show("权限不足!");
            //    return;
            //}
            var list = GetSelectedModelList();

            if (list.Count > 1)
            {
                MessageBoxEx.Show("请选中一条进行修改!");
                return;
            }
            FrmAddMessage frm = new FrmAddMessage(LoadDataToDataGridView, _curPage, true, list[0]);
            frm.ShowDialog();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if (GlobalUtils.LoginUser.UserLevel == Common.Enums.UserLevel.Checker)
            //{
            //    MessageBoxEx.Show("权限不足!");
            //    return;
            //}


            //new Thread(Proc) { IsBackground = true }.Start();

            //FrmProgressBar frm = new FrmProgressBar();
            //frm.Show();

            FrmAddMessage frm = new FrmAddMessage(LoadDataToDataGridView, _curPage);
            if (DialogResult.Cancel == frm.ShowDialog())
                return;
        }



        #endregion
    }
}
