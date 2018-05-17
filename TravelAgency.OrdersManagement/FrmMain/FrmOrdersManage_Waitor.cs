using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.Common;
using TravelAgency.Common.PictureHandler;
using TravelAgency.CSUI.FrmSub;
using TravelAgency.Model;
using TravelAgency.OrdersManagement.FrmSub;

namespace TravelAgency.OrdersManagement
{
    public partial class FrmOrdersManage_Waitor : Form
    {
        private readonly TravelAgency.BLL.Orders _bllOrders = new TravelAgency.BLL.Orders();
        private readonly TravelAgency.BLL.OrderFiles _bllOrderFiles = new TravelAgency.BLL.OrderFiles();
        private readonly BLL.OrdersLogs _bllLoger = new BLL.OrdersLogs();
        private int _curPage = 1;
        private int _pageCount = 0;
        private int _pageSize;
        private int _recordCount = 0;
        private string _where = string.Empty;

        public FrmOrdersManage_Waitor()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _recordCount = _bllOrders.GetRecordCount(_where);
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
            this.FormClosed += FrmOrdersManage_FormClosed;

            dataGridView1.DoubleClick += DataGridView1_DoubleClick;
            StyleControler.SetDgvStyle(dataGridView1);

            bgWorkerLoadData.WorkerReportsProgress = true;

            progressLoading.Visible = false;
            LoadDataToDgvAsyn();
        }

        private void FrmOrdersManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void InitComboboxs()
        {
            string tablename = "Orders";


            cbPaymentPlatform.Items.Add("全部");
            cbReplyResult.Items.Add("全部");

            cbReplyResult.SelectedIndex = 0;
            cbPaymentPlatform.SelectedIndex = 0;

            cbReplyResult.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPaymentPlatform.DropDownStyle = ComboBoxStyle.DropDownList;


            var list = Common.Enums.OrderInfo_PaymentPlatform.valueKeyMap.Keys;
            if (list != null)
                foreach (var item in list)
                    cbPaymentPlatform.Items.Add(item);

            var list1 = Common.Enums.ReplyResult.valList;
            if (list1 != null)
                foreach (var item in list1)
                    cbReplyResult.Items.Add(item);

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
            dataGridView1.DataSource = _bllOrders.GetListByPageOrderById(_where, _curPage, _pageSize);
            if (curSelectedRow != -1 && dataGridView1.Rows.Count > curSelectedRow)
                dataGridView1.CurrentCell = dataGridView1.Rows[curSelectedRow].Cells[0];
            dataGridView1.Update();
        }

        private void UpdateState()
        {
            _recordCount = _bllOrders.GetRecordCount(_where);
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
                conditions.Add(" (GuestOrderTime between '" + txtSchEntryTimeFrom.Text + "' and " + " '" + txtSchEntryTimeTo.Text +
                               "') ");
            }

            if (!string.IsNullOrEmpty(txtOrderNo.Text.Trim()))
            {
                conditions.Add(" (OrderNo like '%" + txtOrderNo.Text + "%') ");
            }

            if (cbPaymentPlatform.Text != "全部")
                conditions.Add(" PaymentPlatform = " + Common.Enums.OrderInfo_PaymentPlatform.ValueToKey(cbPaymentPlatform.Text) + " ");

            if (cbReplyResult.Text != "全部")
                conditions.Add(" ReplyResult = '" + cbReplyResult.Text + "' ");

            if (!string.IsNullOrEmpty(txtWaitorName.Text.Trim()))
                conditions.Add(" (WaitorName like '%" + txtWaitorName.Text + "%') ");


            string[] arr = conditions.ToArray();
            string where = string.Join(" and ", arr);
            return where;
        }


        private void btnClearSchConditions_Click(object sender, EventArgs e)
        {
            //txtClient.Text = "";
            //cbOrderType.Text = "全部";
            //cbOrdersState.Text = "全部";
            //cbDepatureType.Text = "";
            txtSchEntryTimeFrom.Text = "";
            txtSchEntryTimeTo.Text = "";
            txtOrderNo.Text = "";
            cbPaymentPlatform.Text = "全部";
            cbReplyResult.Text = "全部";
            txtWaitorName.Text = "";
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
            int hasTypedInGuestInfoCount = 0;
            int sucNum = 0, proNum = 0, refuseNum = 0, notHandleNum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                row.HeaderCell.Value = (i + 1).ToString();

                //在这里控制单元格的显示
                if (list[i].GuestInfoTypedIn) ++hasTypedInGuestInfoCount;
                if (list[i].ReplyResult == "成功")
                    ++sucNum;
                if (list[i].ReplyResult == "处理中")
                    ++proNum;
                if (list[i].ReplyResult == "拒绝")
                    ++refuseNum;
                if (list[i].ReplyResult == "未处理")
                    ++notHandleNum;
                SetRowColorByReserveTime(row);
                SetRowColorByGuestInfoTypedIn(row);

                for (int j = 0; j != dataGridView1.ColumnCount; ++j)
                {
                    var value = dataGridView1.Rows[i].Cells[j].Value;
                    if (dataGridView1.Rows[i].Cells[j].ValueType == typeof(decimal?) && value != null)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = DecimalHandler.DecimalToString((decimal?)value);
                    }
                }

                //row.Cells["OrderType"].Value = Common.Enums.Orders_OrderType.KeyToValue(list[i].OrderType);
                //row.Cells["OrdersState"].Value = Common.Enums.Orders_OrdersState.KeyToValue(list[i].OrdersState);
                row.Cells["PaymentPlatform"].Value = Common.Enums.OrderInfo_PaymentPlatform.KeyToValue(list[i].PaymentPlatform);
            }

            lbGuestInfoTypedInCount.Text = string.Format("客人信息已录入: {0}/{1}", hasTypedInGuestInfoCount, dataGridView1.Rows.Count);
            StringBuilder sb = new StringBuilder();
            sb.Append(" 回复结果统计:");
            if (sucNum > 0)
                sb.AppendFormat("成功:{0} ", sucNum);
            if (proNum > 0)
                sb.AppendFormat("处理中:{0} ", proNum);
            if (refuseNum > 0)
                sb.AppendFormat("拒绝:{0} ", refuseNum);
            if (notHandleNum > 0)
                sb.AppendFormat("未处理:{0} ", notHandleNum);
            lbReplyResultCount.Text = sb.ToString();
        }

        private void SetRowColorByGuestInfoTypedIn(DataGridViewRow row)
        {
            if (DgvDataSourceToList()[row.Index].GuestInfoTypedIn)
            {
                row.Cells["GuestInfoTypedIn"].Value = "已录入";
                row.Cells["GuestInfoTypedIn"].Style.BackColor = row.Index % 2 == 0 ? StyleControler.CellDefaultBackColor
: StyleControler.CellDefaultAlterBackColor; //保持原有样式不变
            }
            else
            {
                row.Cells["GuestInfoTypedIn"].Value = "未录入";
                row.Cells["GuestInfoTypedIn"].Style.BackColor = Color.Orange;
            }
        }


        private void SetRowColorByReserveTime(DataGridViewRow row)
        {
            if (row.Cells["ReplyResult"].Value.ToString() != "未处理" || !DgvDataSourceToList()[row.Index].ReserveTime.HasValue)
            {
                row.Cells["ReplyResult"].Style.BackColor = row.Index % 2 == 0 ? StyleControler.CellDefaultBackColor
                        : StyleControler.CellDefaultAlterBackColor; //保持原有样式不变
                return;
            }

            DateTime reserveTime = DgvDataSourceToList()[row.Index].ReserveTime.Value;
            var span = reserveTime - DateTime.Now;
            var style = row.Cells["ReplyResult"].Style;
            row.Cells["ReplyResult"].Style.ForeColor = Color.Black;
            if (span.TotalHours <= 4)
            {
                style.BackColor = Color.Red;
            }
            else if (span.TotalHours <= 8)
            {
                style.BackColor = Color.Orange;
            }
            else
            {
                style.BackColor = Color.ForestGreen;
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
            //int res = Common.Excel.OrdersExcelParser.ParseExcel(filename, Common.Excel.OrdersExcelParser.ExcelType.Type01_DaZhong);
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
        private List<Model.Orders> DgvDataSourceToList()
        {
            return dataGridView1.DataSource as List<Model.Orders>;
        }

        /// <summary>
        /// 返回当前选择的行的visaModel的List
        /// </summary>
        /// <returns></returns>
        private List<Model.Orders> GetSelectedModelList()
        {
            var visaList = dataGridView1.DataSource as List<Model.Orders>;
            List<Model.Orders> res = new List<Orders>();
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
            int res = _bllOrders.DeleteList(modelList);

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
            FrmAddOrders frm = new FrmAddOrders(LoadDataToDataGridView, _curPage, true, list[0]);
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

            FrmAddOrders frm = new FrmAddOrders(LoadDataToDataGridView, _curPage);
            if (DialogResult.Cancel == frm.ShowDialog())
                return;
        }



        #endregion

        private void 查看录入订单客人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBoxEx.Show("请选中一条数据进行操作!");
                return;
            }
            FrmSetGuestInfo frm = new FrmSetGuestInfo(LoadDataToDataGridView, _curPage, true,
                DgvDataSourceToList()[dataGridView1.SelectedRows[0].Index]);
            frm.Show();
        }

        private void 确认订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = GetSelectedModelList();

            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBoxEx.Show("请选中一条数据进行操作!");
                return;
            }

            //foreach (var item in list)
            //{
            //    if (item.WaitorConfirmTime != null)
            //    {
            //        MessageBoxEx.Show("选中项中存在已经确认过的订单，请不要重复操作!!!");
            //        return;
            //    }
            //}

            if (MessageBoxEx.Show("是否确认提交所选订单?", "确认", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;



            int res = 0;
            foreach (var item in list)
            {
                item.WaitorConfirmTime = DateTime.Now;
                res += _bllOrders.Update(item) ? 1 : 0;
                _bllLoger.AddLog(GlobalUtils.LoginUser, Common.Enums.OrdersActtype.value2Key("客服:确认订单"), item);
            }

            Common.GlobalUtils.MessageBoxWithRecordNum("提交", res, list.Count);
        }

        private void 评价录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = GetSelectedModelList();

            FrmIsPraise frm = new FrmIsPraise();
            if (DialogResult.Cancel == frm.ShowDialog())
                return;

            int res = 0;
            foreach (var item in list)
            {
                item.IsPraise = frm.RetValue;
                res += _bllOrders.Update(item) ? 1 : 0;
            }

            Common.GlobalUtils.MessageBoxWithRecordNum("提交", res, list.Count);
        }

        private void 申请退款ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBoxEx.Show("请选中一条数据进行操作!");
                return;
            }

            var list = GetSelectedModelList();

            if (!list[0].RefundAmout.HasValue || !list[0].GuestRefundApplyTime.HasValue)
            {
                MessageBoxEx.Show("请先填写退款信息(\"金额\"及\"时间\")后再发起退款!");
                return;
            }

            FrmAddMessage frm = new FrmAddMessage(null, 0, list[0], refund: true);
            frm.ShowDialog();


        }

        private void 订单发送消息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBoxEx.Show("请选中一条数据进行操作!");
                return;
            }

            var list = GetSelectedModelList();
            FrmAddMessage frm = new FrmAddMessage(null, 0, list[0], refund: false);
            frm.ShowDialog();
        }

        private void 下载订单附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBoxEx.Show("请选中一条数据进行操作!");
                return;
            }
            var list = GetSelectedModelList();
            new OrderFilesHandler().DownloadOrderFiles(list[0]);
        }

        private void 上传订单附件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBoxEx.Show("请选中一条数据进行操作!");
                return;
            }

            var list = GetSelectedModelList();
            string filename = GlobalUtils.ShowOpenFileDlg("所有文件|*.*");
            if (!string.IsNullOrEmpty(filename))
            {
                new OrderFilesHandler().UploadOrderFile(filename, list[0].Id);
            }
        }

        private void 附件管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBoxEx.Show("请选中一条数据进行操作!");
                return;
            }

            var list = GetSelectedModelList();
            FrmOrderFilesManage frm = new FrmOrderFilesManage(list[0]);
            frm.Show();
        }
    }
}
