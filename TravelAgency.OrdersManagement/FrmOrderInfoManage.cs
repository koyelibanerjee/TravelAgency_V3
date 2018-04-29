using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.Common;
using TravelAgency.CSUI.FrmSub;
using TravelAgency.Model;

namespace TravelAgency.OrdersManagement
{
    public partial class FrmOrderInfoManage : Form
    {
        private readonly TravelAgency.BLL.OrderInfo _bllOrderInfo = new TravelAgency.BLL.OrderInfo();

        private int _curPage = 1;
        private int _pageCount = 0;
        private int _pageSize;
        private int _recordCount = 0;
        private string _where = string.Empty;
        private bool _showDetail = false;
        private string _orderNo = "";

        public FrmOrderInfoManage()
        {
            InitializeComponent();
        }

        public FrmOrderInfoManage(string orderNo)
        {
            InitializeComponent();
            _showDetail = true;
            _orderNo = orderNo;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _recordCount = _bllOrderInfo.GetRecordCount(_where);
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
            this.FormClosed += FrmOrderInfoManage_FormClosed;

            dataGridView1.DoubleClick += DataGridView1_DoubleClick;
            StyleControler.SetDgvStyle(dataGridView1);

            bgWorkerLoadData.WorkerReportsProgress = true;

            progressLoading.Visible = false;

            if (!string.IsNullOrEmpty(_orderNo))
            {
                this.txtOrderNo.Text = _orderNo;
            }

            LoadDataToDgvAsyn();
        }

        private void FrmOrderInfoManage_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void InitComboboxs()
        {

            cbOrderType.Items.Add("全部");
            cbOrderInfoState.Items.Add("全部");
            cbPaymentPlatform.Items.Add("全部");

            cbOrderInfoState.SelectedIndex = 0;
            cbOrderType.SelectedIndex = 0;
            cbPaymentPlatform.SelectedIndex = 0;

            cbOrderInfoState.DropDownStyle = ComboBoxStyle.DropDownList;
            cbOrderType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPaymentPlatform.DropDownStyle = ComboBoxStyle.DropDownList;

            var list = Common.Enums.OrderInfo_OrderType.valueKeyMap.Keys;
            if (list != null)
                foreach (var item in list)
                    cbOrderType.Items.Add(item);

            list = Common.Enums.OrderInfo_OrderInfoState.valueKeyMap.Keys;
            if (list != null)
                foreach (var item in list)
                    cbOrderInfoState.Items.Add(item);

            list = Common.Enums.OrderInfo_PaymentPlatform.valueKeyMap.Keys;
            if (list != null)
                foreach (var item in list)
                    cbPaymentPlatform.Items.Add(item);

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

        #region model与control
        //private void ModelToCtrls(TravelAgency.Model.VisaInfo model)
        //{
        //    //添加多线程情况的时候的判断
        //    if (this.InvokeRequired)
        //    {
        //        this.Invoke(new Action(() =>
        //        {
        //            //model.Types = "个签";
        //            model.EntryTime = DateTime.Now;
        //            model.outState = OutState.Type01NoRecord;
        //            txtName.Text = model.Name;
        //            txtEnglishName.Text = model.EnglishName;
        //            txtSex.Text = model.Sex;
        //            txtBirthday.Text = model.Birthday.ToString();
        //            txtPassNo.Text = model.PassportNo;
        //            txtLicenseTime.Text = model.LicenceTime.ToString();
        //            txtExpireDate.Text = model.ExpiryDate.ToString();
        //            txtBirthPlace.Text = model.Birthplace;
        //            txtIssuePlace.Text = model.IssuePlace;
        //        }));
        //        return;
        //    }
        //    //model.Types = "个签";
        //    model.EntryTime = DateTime.Now;
        //    model.outState = OutState.Type01NoRecord;
        //    txtName.Text = model.Name;
        //    txtEnglishName.Text = model.EnglishName;
        //    txtSex.Text = model.Sex;
        //    txtBirthday.Text = model.Birthday.ToString();
        //    txtPassNo.Text = model.PassportNo;
        //    txtLicenseTime.Text = model.LicenceTime.ToString();
        //    txtExpireDate.Text = model.ExpiryDate.ToString();
        //    txtBirthPlace.Text = model.Birthplace;
        //    txtIssuePlace.Text = model.IssuePlace;
        //}

        //private VisaInfo CtrlsToModel()
        //{
        //    VisaInfo model = new VisaInfo();
        //    //model.Types = "个签";
        //    model.EntryTime = DateTime.Now;
        //    model.outState = OutState.Type01NoRecord;
        //    try
        //    {
        //        model.Name = txtName.Text;
        //        model.EnglishName = txtEnglishName.Text;
        //        model.Sex = txtSex.Text;
        //        model.Birthday = DateTime.Parse(txtBirthday.Text);
        //        model.PassportNo = txtPassNo.Text;
        //        model.LicenceTime = DateTime.Parse(txtLicenseTime.Text);
        //        model.ExpiryDate = DateTime.Parse(txtExpireDate.Text);
        //        model.Birthplace = txtBirthPlace.Text;
        //        model.IssuePlace = txtIssuePlace.Text;
        //    }
        //    catch (Exception)
        //    {
        //        MessageBoxEx.Show(Resources.PleaseCheckDateTimeFormat);
        //        return null;
        //    }
        //    return model;
        //}
        #endregion

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
            dataGridView1.DataSource = _bllOrderInfo.GetListByPageOrderById(_where, _curPage, _pageSize);
            if (curSelectedRow != -1 && dataGridView1.Rows.Count > curSelectedRow)
                dataGridView1.CurrentCell = dataGridView1.Rows[curSelectedRow].Cells[0];
            dataGridView1.Update();
        }

        private void UpdateState()
        {
            _recordCount = _bllOrderInfo.GetRecordCount(_where);
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


            if (cbOrderType.Text == "全部")
            {
            }
            else
            {
                conditions.Add(" (OrderType = " + Common.Enums.OrderInfo_OrderType.ValueToKey(cbOrderType.Text) + ") ");
            }

            if (cbOrderInfoState.Text == "全部")
            {
            }
            else
            {
                conditions.Add(" (OrderInfoState = '" + Common.Enums.OrderInfo_OrderInfoState.ValueToKey(cbOrderInfoState.Text) + "') ");
            }

            if (cbPaymentPlatform.Text == "全部")
            {
            }
            else
            {
                conditions.Add(" (PaymentPlatform = '" + Common.Enums.OrderInfo_PaymentPlatform.ValueToKey(cbPaymentPlatform.Text) + "') ");
            }



            if (!string.IsNullOrEmpty(txtSchEntryTimeFrom.Text.Trim()) && !string.IsNullOrEmpty(txtSchEntryTimeTo.Text.Trim()))
            {
                conditions.Add(" (OrderTime between '" + txtSchEntryTimeFrom.Text + "' and " + " '" + txtSchEntryTimeTo.Text +
                               "') ");
            }

            if (!string.IsNullOrEmpty(txtOrderNo.Text.Trim()))
            {
                conditions.Add(" (OrderNo like '%" + txtOrderNo.Text.Trim() + "%' ) ");
            }


            string[] arr = conditions.ToArray();
            string where = string.Join(" and ", arr);
            return where;
        }


        private void btnClearSchConditions_Click(object sender, EventArgs e)
        {
            //txtClient.Text = "";
            cbOrderType.Text = "全部";
            cbOrderInfoState.Text = "全部";
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
            //if (dataGridView1.Columns[e.ColumnIndex].Name == "outState")
            //{
            //    Color c = Color.Empty;
            //    //string state = e.Value.ToString();
            //    string state = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //    if (state == OutState.Type01NoRecord)
            //        c = Color.AliceBlue;
            //    else if (state == OutState.Type01Delay)
            //        c = Color.DarkOrange;
            //    else if (state == OutState.Type02In)
            //        c = Color.Yellow;
            //    else if (state == OutState.Type03NormalOut)
            //        c = Color.Green;
            //    else if (state == OutState.TYPE04AbnormalOut)
            //        c = Color.Red;
            //    else
            //        c = Color.Black;
            //    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = c;
            //}
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
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                row.HeaderCell.Value = (i + 1).ToString();

                //在这里控制单元格的显示

                for (int j = 0; j != dataGridView1.ColumnCount; ++j)
                {
                    var value = dataGridView1.Rows[i].Cells[j].Value;
                    if (dataGridView1.Rows[i].Cells[j].ValueType == typeof(decimal?) && value != null)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = DecimalHandler.DecimalToString((decimal?)value);
                    }
                }

                row.Cells["OrderType"].Value = Common.Enums.OrderInfo_OrderType.KeyToValue(list[i].OrderType);
                row.Cells["OrderInfoState"].Value = Common.Enums.OrderInfo_OrderInfoState.KeyToValue(list[i].OrderInfoState);

                if (row.Cells["OrderInfoState"].Value.ToString() == "未校验")
                {
                    row.Cells["OrderInfoState"].Style.BackColor = Color.White;
                }
                else
                {
                    row.Cells["OrderInfoState"].Style.BackColor = Color.LimeGreen;
                }

                row.Cells["PaymentPlatform"].Value = Common.Enums.OrderInfo_PaymentPlatform.KeyToValue(list[i].PaymentPlatform);
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
            string filename = GlobalUtils.ShowOpenFileDlg("Excel文件|*.xls;*.xlsx");
            if (string.IsNullOrEmpty(filename))
                return;
            FrmPlatformSet frm = new FrmPlatformSet();
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;
            int res = 0;
            FrmOrderInfoExcelParser frm1;
            switch (frm.RetValue)
            {
                case "大众点评":
                    //res = Common.Excel.OrderInfoExcelParser.ParseExcel(filename, Common.Excel.OrderInfoExcelParser.ExcelType.Type01_DaZhong);
                    frm1 = new FrmOrderInfoExcelParser(filename, FrmOrderInfoExcelParser.ExcelType.Type01_DaZhong);
                    break;
                case "飞猪支付宝":
                    frm1 = new FrmOrderInfoExcelParser(filename, FrmOrderInfoExcelParser.ExcelType.Type02_FeiZhu);
                    break;
                case "蚂蜂窝":
                    frm1 = new FrmOrderInfoExcelParser(filename, FrmOrderInfoExcelParser.ExcelType.Type03_MaYi);
                    break;
                case "携程":
                    frm1 = new FrmOrderInfoExcelParser(filename, FrmOrderInfoExcelParser.ExcelType.Type04_XieCheng);
                    break;
                default:
                    frm1 = null;
                    break;
            }

            frm1.ShowDialog();
            res = frm1.RetValue;
            MessageBoxEx.Show("导入" + res + "条数据成功！");
            LoadDataToDgvAsyn();
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

            FrmAddOrderInfo frm = new FrmAddOrderInfo(LoadDataToDataGridView, _curPage);
            if (DialogResult.Cancel == frm.ShowDialog())
                return;
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
        private List<Model.OrderInfo> DgvDataSourceToList()
        {
            return dataGridView1.DataSource as List<Model.OrderInfo>;
        }

        /// <summary>
        /// 返回当前选择的行的visaModel的List
        /// </summary>
        /// <returns></returns>
        private List<Model.OrderInfo> GetSelectedModelList()
        {
            var visaList = dataGridView1.DataSource as List<Model.OrderInfo>;
            List<Model.OrderInfo> res = new List<OrderInfo>();
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
            int res = _bllOrderInfo.DeleteList(modelList);

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
            FrmAddOrderInfo frm = new FrmAddOrderInfo(LoadDataToDataGridView, _curPage, true, list[0]);
            frm.ShowDialog();
        }



        #endregion

        private void 校验状态修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = GetSelectedModelList();

            FrmCheckState frm = new FrmCheckState();
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;

            int orderInfoState = 0;

            orderInfoState = Common.Enums.OrderInfo_OrderInfoState.ValueToKey(frm.RetValue);
            int suc = 0;
            for (int i = 0; i < list.Count; ++i)
            {
                list[i].OrderInfoState = orderInfoState;
                suc += _bllOrderInfo.Update(list[i]) ? 1 : 0;
            }
            GlobalUtils.MessageBoxWithRecordNum("更新订单状态", suc, list.Count);
            LoadDataToDgvAsyn();

        }
    }
}
