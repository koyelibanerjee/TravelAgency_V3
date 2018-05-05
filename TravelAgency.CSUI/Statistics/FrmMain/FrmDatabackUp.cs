using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.Common;
using TravelAgency.Common.Enums;
using TravelAgency.Common.Excel;
using TravelAgency.Common.PictureHandler;
using TravelAgency.Common.QRCode;
using TravelAgency.Common.Word;
using TravelAgency.CSUI.FrmSub;
using TravelAgency.CSUI.Properties;
using TravelAgency.Model;

namespace TravelAgency.CSUI.FrmMain
{
    public partial class FrmDataBackUp : Form
    {
        private readonly TravelAgency.BLL.VisaInfo _bllVisaInfo = new TravelAgency.BLL.VisaInfo();
        private readonly TravelAgency.BLL.Visa _bllVisa = new TravelAgency.BLL.Visa();
        //private readonly TravelAgency.BLL.UserQueue _bllUserQueue = new TravelAgency.BLL.UserQueue();
        private readonly TravelAgency.BLL.WorkerQueue _bllWorkerQueue = new TravelAgency.BLL.WorkerQueue();
        private readonly TravelAgency.BLL.JobAssignment _bllJobAssignment = new TravelAgency.BLL.JobAssignment();
        private int _curPage = 1;
        private int _pageCount = 0;
        private int _pageSize = 0;
        private int _recordCount = 0;
        //private readonly IDCard _idCard = new IDCard();
        //private bool _autoRead = false;
        //private bool _autoReadThreadRun = false;
        //private readonly Timer _t = new Timer();
        private readonly MyQRCode _qrCode = new MyQRCode(); //只用于批量生成二维码
        //private readonly Thread _thLoadDataToDgvAndUpdateState;
        private bool _init = false;
        private string _where = string.Empty;
        private bool _isWorker = false;

        public List<Model.VisaInfo> List4AddToExport;
        private bool _b4AddToExport = false;

        public FrmDataBackUp(bool b4Add = false)
        {
            _b4AddToExport = b4Add; //指明用于添加到导出界面的
            InitializeComponent();
            //_t.Tick += AutoClassAndRecognize;
            //_t.Interval = 200;
            //_thLoadDataToDgvAndUpdateState = new Thread(LoadAndUpdate);

            //_thLoadDataToDgvAndUpdateState.IsBackground = true;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _recordCount = _bllVisaInfo.GetRecordCount(_where);
            _pageCount = (int)Math.Ceiling(_recordCount / (double)_pageSize);

            var list = _bllWorkerQueue.GetModelList(string.Format(" workid = '{0}'", GlobalUtils.LoginUser.WorkId));
            if (list.Count <= 0)
            {
                _isWorker = false; //没有在工作用户里面的，不用管这些，是领导
                btnCanAcceptNewWork.Visible = false;
                btnOnlyShowMe.Visible = false;
            }
            else
            {
                _isWorker = true;
                this.btnCanAcceptNewWork.Value = list[0].CanAccept;
            }

            //初始化一些控件
            //txtPicPath.Text = GlobalInfo.AppPath;
            cbPageSize.Items.Add("1000");
            cbPageSize.Items.Add("3000");
            cbPageSize.Items.Add("5000");
            cbPageSize.Items.Add("10000");
            cbPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPageSize.SelectedIndex = 2;
            _pageSize = int.Parse(cbPageSize.Text);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; //列宽自适应,一定不能用AllCells
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders; //这里也一定不能AllCell自适应!
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns["GroupNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;

            dataGridView1.DefaultCellStyle.Font = new Font("微软雅黑", 9.0f, FontStyle.Bold);

            cbDisplayType.Items.Add("全部");
            cbDisplayType.Items.Add("未记录");
            cbDisplayType.Items.Add("个签");
            cbDisplayType.Items.Add("团签");
            cbDisplayType.Items.Add("团做个");
            cbDisplayType.Items.Add("个签&&团做个");
            cbDisplayType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDisplayType.SelectedIndex = 0;
            //checkShowConfirm.Checked = true;
            //checkRegSucShowDlg.Checked = true;

            cbOutState.DropDownStyle = ComboBoxStyle.DropDownList;
            cbOutState.Items.Add("全部");
            cbOutState.Items.Add("01延后");
            cbOutState.Items.Add("01未记录");
            cbOutState.Items.Add("02进签");
            cbOutState.Items.Add("03出签");
            cbOutState.Items.Add("04未正常出签");
            cbOutState.Items.Add("10已导出");
            cbOutState.SelectedIndex = 0;


            //国家选择框加入
            cbCountry.Items.Add("全部");
            foreach (string countryName in CountryCode.CountryNameArr)
            {
                cbCountry.Items.Add(countryName);
            }
            cbCountry.SelectedIndex = 0;




            //设置可跨线程访问窗体
            //TODO:这里可能需要修改
            //Control.CheckForIllegalCrossThreadCalls = false;

            //加载数据

            //
            bgWorkerLoadData.WorkerReportsProgress = true;

            //使用异步加载
            //_thLoadDataToDgvAndUpdateState.Start();
            //LoadDataToDataGridView(_curPage);
            //UpdateState();
            progressLoading.Visible = false;

            LoadDataToDgvAsyn();
            _init = true;
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

        #region 自己的按钮



        //private void ConfirmAddToDataBase(VisaInfo model, bool showConfirm = true)
        //{
        //    if (showConfirm)
        //    {
        //        if (MessageBoxEx.Show(Resources.WhetherAddToDatabase, Resources.Confirm, MessageBoxButtons.OKCancel) == DialogResult.OK)
        //        {
        //            if (_bll.Add(model))
        //            {
        //                //LoadDataToDataGridView(_curPage);
        //                //UpdateState();
        //                LoadDataToDgvAsyn();
        //            }
        //            else
        //                MessageBoxEx.Show(Resources.FailedAddToDatabase);
        //        }
        //    }
        //    else
        //    {
        //        if (_bll.Add(model))
        //        {
        //            LoadDataToDgvAsyn();
        //        }
        //        else
        //            MessageBoxEx.Show(Resources.FailedAddToDatabase);
        //    }

        //}




        private void btnShowToday_Click(object sender, EventArgs e)
        {
            var _modelYestodayLast = _bllVisaInfo.GetLastRecordOfTheDay(DateTime.Now.AddDays(-1.0));
            var _modelTodayLast = _bllVisaInfo.GetLastRecordOfTheDay(DateTime.Now);
            if (_modelYestodayLast != null)
                txtSchEntryTimeFrom.Text = DateTimeFormator.DateTimeToString(_modelYestodayLast.EntryTime.Value.AddMinutes(1.0), DateTimeFormator.TimeFormat.Type06LongTime);
            else
                txtSchEntryTimeFrom.Text = DateTimeFormator.DateTimeToString(DateTime.Today) + " 00:00";
            if (_modelTodayLast != null)
                txtSchEntryTimeTo.Text = DateTimeFormator.DateTimeToString(_modelTodayLast.EntryTime.Value.AddMinutes(1.0), DateTimeFormator.TimeFormat.Type06LongTime);
            else
                txtSchEntryTimeTo.Text = DateTimeFormator.DateTimeToString(DateTime.Today) + " 16:00";

            btnSearch_Click(null, null);

        }

        #endregion




        #region dgv用到的相关方法

        //        //用于异步加载
        //        public void LoadAndUpdate()
        //        {
        //            this.Invoke(new Action(() =>
        //            {
        //LoadDataToDgvAsyn();
        //            }));
        //            _init = true;
        //        }

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
            dataGridView1.DataSource = _bllVisaInfo.GetListByPageOrderByGroupNo(page, _pageSize, _where);
            if (curSelectedRow != -1 && dataGridView1.Rows.Count > curSelectedRow)
                dataGridView1.CurrentCell = dataGridView1.Rows[curSelectedRow].Cells[0];
            dataGridView1.Update();
            GlobalStat.UpdateStatistics();
        }

        private void UpdateState()
        {
            _recordCount = _bllVisaInfo.GetRecordCount(_where);
            _pageCount = (int)Math.Ceiling((double)_recordCount / (double)_pageSize);
            if (_curPage == 1)
                btnPagePre.Enabled = false;
            else
                btnPagePre.Enabled = true;
            if (_curPage == _pageCount)
                btnPageNext.Enabled = false;
            else
                btnPageNext.Enabled = true;
            //lbRecordCount.Text = "当前为第:" + Convert.ToInt32(_curPage)
            //                + "页,共" + Convert.ToInt32(_pageCount) + "页,每页共" + _pageSize + "条.";
            lbRecordCount.Text = "共有记录:" + _recordCount + "条";
            lbCurPage.Text = "当前为第" + _curPage + "页";
            if (_recordCount == 0)
                lbPeopleCount.Text = "已做:0/0人.";
        }
        #endregion

        #region dgv的bar栏和搜索栏

        private void btnOnlyShowNotDone_ValueChanged(object sender, EventArgs e)
        {
            LoadDataToDgvAsyn();
        }

        private void btnOnlyShowMe_ValueChanged(object sender, EventArgs e)
        {
            LoadDataToDgvAsyn();
        }

        private void UpdateUserState()
        {
            bool finished = _bllJobAssignment.UserWorkFinished(GlobalUtils.LoginUser.WorkId);
            if (!_bllWorkerQueue.ChangeUserBusyState(GlobalUtils.LoginUser.WorkId, !finished))
                MessageBoxEx.Show("修改用户IsBusy状态失败，请联系管理员!");
        }

        private void btnCanAcceptNewWork_ValueChanged(object sender, EventArgs e)
        {
            if (!_init || !_isWorker)
                return;
            //_bllUserQueue.ChangeUserCanAcceptState(GlobalUtils.LoginUser.WorkId, btnCanAcceptNewWork.Value);
            var model = _bllWorkerQueue.GetModelList(string.Format(" workid = '{0}'", GlobalUtils.LoginUser.WorkId))[0];
            if (model.CanAccept == btnCanAcceptNewWork.Value)
                return;
            model.CanAccept = btnCanAcceptNewWork.Value;
            if (!_bllWorkerQueue.Update(model))
            {
                MessageBoxEx.Show("更新状态失败，请联系管理员!");
                return;
            }
            //触发一下分配工作逻辑
            _bllJobAssignment.AssignmentJob();
            //刷新用户状态
            UpdateUserState();
            LoadDataToDgvAsyn();
        }


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

        private void cbPageSize_Click(object sender, EventArgs e)
        {
            //_pageSize = int.Parse(cbPageSize.Text);
            //LoadDataToDataGridView(_curPage);
            //UpdateState();
        }
        private void cbPageSize_TextChanged(object sender, EventArgs e)
        {
            if (!_init) //因为窗口初始化的时候也会调用，所以禁止多次调用
                return;

            _pageSize = int.Parse(cbPageSize.Text);
            LoadDataToDgvAsyn();
        }


        //private void cbDisplayType_TextChanged(object sender, EventArgs e)
        //{
        //    if (!_init) //因为窗口初始化的时候也会调用，所以禁止多次调用
        //        return;
        //    LoadDataToDataGridView(_curPage);
        //    UpdateState();
        //}

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
            if (cbDisplayType.Text == "全部")
            {
            }
            else if (cbDisplayType.Text == "未记录")
            {
                conditions.Add(" Types is null or Types='' ");
            }
            else if (cbDisplayType.Text == "个签")
            {
                conditions.Add(" Types = '个签' ");
            }
            else if (cbDisplayType.Text == "团签")
            {
                conditions.Add(" Types = '团签' ");
            }
            else if (cbDisplayType.Text == "团做个")
            {
                conditions.Add(" Types = '团做个' ");
            }
            else if (cbDisplayType.Text == "个签&&团做个")
            {
                conditions.Add(" Types = '团做个' or Types = '个签' ");
            }

            if (!string.IsNullOrEmpty(txtSchPassportNo.Text.Trim()))
            {
                conditions.Add(" (PassportNo like '%" + txtSchPassportNo.Text + "%') ");
            }

            if (!string.IsNullOrEmpty(txtSchName.Text.Trim()))
            {
                conditions.Add(" (Name like  '%" + txtSchName.Text + "%') ");
            }

            if (!string.IsNullOrEmpty(txtSchGroupNo.Text.Trim()))
            {
                conditions.Add(" (GroupNo like '%" + txtSchGroupNo.Text + "%') ");
            }

            if (!string.IsNullOrEmpty(txtSchEntryTimeFrom.Text.Trim()) && !string.IsNullOrEmpty(txtSchEntryTimeTo.Text.Trim()))
            {
                conditions.Add(" (EntryTime between '" + txtSchEntryTimeFrom.Text + "' and " + " '" + txtSchEntryTimeTo.Text +
                               "') ");
            }

            if (!string.IsNullOrEmpty(txtCall.Text.Trim()))
            {
                conditions.Add(" (Phone like '%" + txtCall.Text + "%') ");
            }

            if (cbCountry.Text == "全部")
            {

            }
            else
            {
                conditions.Add(" Country = '" + cbCountry.Text + "' ");
            }

            if (!string.IsNullOrEmpty(txtSalesPerson.Text.Trim()))
            {
                conditions.Add(" (Salesperson like '%" + txtSalesPerson.Text + "%') ");
            }

            if (!string.IsNullOrEmpty(txtClient.Text.Trim()))
            {
                conditions.Add(" (Client like '%" + txtClient.Text + "%') ");
            }

            if (cbOutState.Text == "全部")
            {

            }
            else
            {
                conditions.Add(" outState = '" + cbOutState.Text + "' ");
            }

            if (btnOnlyShowMe.Value == true)
            {
                conditions.Add(" AssignmentToWorkId = '" + GlobalUtils.LoginUser.WorkId + "' ");
                //conditions.Add(" Country = '" + "日本" + "' ");
            }

            if (btnOnlyShowNotDone.Value == true)
            {
                conditions.Add(" HasTypeIn = '否' ");
            }


            string[] arr = conditions.ToArray();
            string where = string.Join(" and ", arr);
            return where;
        }

        private void btnClearSchConditions_Click(object sender, EventArgs e)
        {

            txtSchPassportNo.Text = string.Empty;
            txtSchEntryTimeFrom.Text = string.Empty;
            txtSchEntryTimeTo.Text = string.Empty;
            txtSchGroupNo.Text = string.Empty;
            txtSchName.Text = string.Empty;
            txtCall.Text = string.Empty;
            txtClient.Text = string.Empty;
            txtSalesPerson.Text = string.Empty;
            txtSchPassportNo.Text = string.Empty;

            cbDisplayType.Text = "全部";
            cbCountry.Text = "全部";
            cbOutState.Text = "全部";
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
            {
                复制ToolStripMenuItem_Click(null, null);
            }
        }

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
            int peopleCount = 0, delayCount = 0;
            var total = dataGridView1.Rows.Count;
            for (int i = 0; i < total; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                row.HeaderCell.Value = (i + 1).ToString();

                //if (!string.IsNullOrEmpty((string)row.Cells["EnglishName"].Value) && !string.IsNullOrEmpty((string)row.Cells["PassportNo"].Value))
                //{
                //    dataGridView1.Rows[i].Cells["QRCodeImage"].Value = _qrCode.EncodeToImage(row.Cells["EnglishName"].Value + "|" + row.Cells["PassportNo"].Value,
                //        QRCodeSaveSize.Size165X165);
                //}


                if (dataGridView1.Rows[i].Cells["Country"].Value != null)
                {
                    string countryName = dataGridView1.Rows[i].Cells["Country"].Value.ToString();
                    dataGridView1.Rows[i].Cells["CountryImage"].Value =
                       TravelAgency.Common.CountryPicHandler.LoadImageByCountryName(countryName);
                }
                // 根据送签状态设置单元格颜色
                if (dataGridView1.Rows[i].Cells["outState"].Value != null)
                {
                    Color c = Color.Empty;
                    //string state = e.Value.ToString();
                    string state = dataGridView1.Rows[i].Cells["outState"].Value.ToString();
                    if (state == OutState.Type01NoRecord)
                        c = Color.AliceBlue;
                    else if (state == OutState.Type01Delay)
                        c = Color.DarkOrange;
                    else if (state == OutState.Type02In)
                        c = Color.Yellow;
                    else if (state == OutState.Type03NormalOut)
                        c = Color.Green;
                    else if (state == OutState.TYPE04AbnormalOut)
                        c = Color.Red;
                    else if (state == OutState.TYPE10Exported)
                        c = Color.DarkGreen;
                    else
                        c = Color.Black;
                    dataGridView1.Rows[i].Cells["outState"].Style.BackColor = c;
                }
                if (dataGridView1.Rows[i].Cells["Visa_id"].Value != null &&
                    !string.IsNullOrEmpty(dataGridView1.Rows[i].Cells["Visa_id"].Value.ToString()))
                    peopleCount += 1;

                if (dataGridView1.Rows[i].Cells["outState"].Value != null &&
                    dataGridView1.Rows[i].Cells["outState"].Value.ToString() == Common.Enums.OutState.Type01Delay)
                    ++delayCount;
            }

            if (peopleCount != total)
                lbPeopleCount.ForeColor = Color.OrangeRed;
            else
                lbPeopleCount.ForeColor = Color.Green;

            if (cbCountry.Text != "全部")
                lbPeopleCount.Text = cbCountry.Text + "已做:" + peopleCount + "/" + total + "人.";
            else
                lbPeopleCount.Text = "已做:" + peopleCount + "/" + total + "人."; //具体国家具体显示

            if (delayCount != 0)
            {
                lbDelayCount.Visible = true;
                lbDelayCount.Text = "延后" + delayCount + "人.";
            }
            else
            {
                lbDelayCount.Visible = false;
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
                    if (!_b4AddToExport)
                        cmsDgvRb.Show(MousePosition.X, MousePosition.Y);
                    else
                        cms4AddToExport.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var row = dataGridView1.CurrentRow;
                //if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["QRCodeImage"].Index)
                //{
                //    if (!string.IsNullOrEmpty((string)row.Cells["EnglishName"].Value) && !string.IsNullOrEmpty((string)row.Cells["PassportNo"].Value))
                //    {
                //        FrmQRCode frm = new FrmQRCode((dataGridView1.DataSource as List<VisaInfo>)[dataGridView1.SelectedRows[0].Index]);
                //        //frm.ShowDialog();
                //        frm.Show();
                //    }
                //}
                //else
                //{
                VisaInfo model = GetDgvSelList()[0];
                if (model == null)
                {
                    MessageBoxEx.Show(Resources.FindModelFailedPleaseCheckInfoCorrect);
                    return;
                }
                FrmInfoTypeIn frm = new FrmInfoTypeIn(dataGridView1.DataSource as List<Model.VisaInfo>, dataGridView1.CurrentRow.Index, LoadDataToDataGridView, _curPage);
                frm.Show();
                //frm.ShowDialog();
                //}

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

        /// <summary>
        /// 查看单个二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showQRCode_Click(object sender, EventArgs e)
        {

            if (this.dataGridView1.SelectedRows.Count > 1)
            {
                MessageBoxEx.Show(Resources.SelectShowMoreThanOne);
                return;
            }

            //string passportNo = dataGridView1.SelectedRows[0].Cells["PassportNo"].Value.ToString();
            //string name = dataGridView1.SelectedRows[0].Cells["EnglishName"].Value.ToString();

            FrmQRCode dlg = new FrmQRCode((dataGridView1.DataSource as List<VisaInfo>)[dataGridView1.SelectedRows[0].Index]);
            //dlg.ShowDialog();
            dlg.Show();
        }

        /// <summary>
        /// 批量生成二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsItemQRCodeBatchGenerate_Click(object sender, EventArgs e)
        {

            int count = this.dataGridView1.SelectedRows.Count;

            ////选择保存路径
            //string path;
            //FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            //if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            //    return;
            //path = fbd.SelectedPath;
            string path = GlobalUtils.ShowBrowseFolderDlg();
            if (string.IsNullOrEmpty(path))
                return;

            for (int i = 0; i != count; ++i)
            {
                string passportNo = dataGridView1.SelectedRows[i].Cells["PassportNo"].Value.ToString();
                string name = dataGridView1.SelectedRows[i].Cells["EnglishName"].Value.ToString();
                _qrCode.EncodeToPng(passportNo + "|" + name, path + "\\" + passportNo + ".jpg", QRCodeSaveSize.Size660X660);
            }

            MessageBoxEx.Show("成功保存" + count + "条记录二维码.");

        }

        /// <summary>
        /// 录入资料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsItemTypeInInfo_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 1)
            {
                MessageBoxEx.Show(Resources.SelectEditMoreThanOne);
                return;
            }

            string visainfoid = dataGridView1.SelectedRows[0].Cells["VisaInfo_id"].Value.ToString();
            Model.VisaInfo model = _bllVisaInfo.GetModel(new Guid(visainfoid));
            if (model == null)
            {
                MessageBoxEx.Show(Resources.FindModelFailedPleaseCheckInfoCorrect);
                return;
            }

            Action<int> updateDel = new Action<int>(LoadDataToDataGridView);
            //FrmInfoTypeIn dlg = new FrmInfoTypeIn(model, updateDel, _curPage);
            FrmInfoTypeIn dlg = new FrmInfoTypeIn(dataGridView1.DataSource as List<Model.VisaInfo>, dataGridView1.SelectedRows[0].Index, updateDel, _curPage);
            //dlg.ShowDialog();
            dlg.Show();
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
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i != count; ++i)
            {
                if (!string.IsNullOrEmpty((string)dataGridView1.SelectedRows[i].Cells["Visa_id"].Value))
                {
                    MessageBoxEx.Show("选中用户已经在团号中，若需删除请先将其移出团号!");
                    return;
                }
                sb.Append("'");
                sb.Append(dataGridView1.SelectedRows[i].Cells["Visainfo_id"].Value);
                sb.Append("'");
                if (i == count - 1)
                    break;
                sb.Append(",");
            }

            int n = _bllVisaInfo.DeleteList(sb.ToString());
            GlobalUtils.MessageBoxWithRecordNum("删除", n, count);
            LoadDataToDataGridView(_curPage);
            UpdateState();
        }

        /// <summary>
        /// 设置团号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsItemSetGroup_Click(object sender, EventArgs e)
        {
            int count = this.dataGridView1.SelectedRows.Count;
            var list = GetDgvSelNotSetGroupList();
            if (list == null)
                return;


            bool canDo = false; bool hasJapan = false;
            foreach (var visainfo in list)
            {
                if (visainfo.Country == "日本"
                    && (visainfo.Types == "个签" || visainfo.Types == "团做个" || visainfo.Types == "商务"))
                {
                    if (visainfo.AssignmentToWorkId == GlobalUtils.LoginUser.WorkId)
                        canDo = true;
                    hasJapan = true;
                }
            }

            if (hasJapan && !canDo)
            {
                MessageBoxEx.Show("日本非团签只能做分配到自己的任务!");
                return;
            }

            FrmGroupOrIndividual frmGroupOrIndividual = new FrmGroupOrIndividual(list, LoadDataToDataGridView, _curPage);
            if (frmGroupOrIndividual.ShowDialog() == DialogResult.Cancel)
                return;
            //激活设置窗口
            FrmsManager.OpenedForms[FrmsManager.OpenedForms.Count - 1].Activate();
        }

        /// <summary>
        /// 获取没有设置过团号的list,若有设置过的会报错
        /// </summary>
        /// <returns></returns>
        private List<Model.VisaInfo> GetDgvSelNotSetGroupList()
        {
            List<Model.VisaInfo> list = new List<VisaInfo>();
            int count = this.dataGridView1.SelectedRows.Count;
            var dgvList = dataGridView1.DataSource as List<Model.VisaInfo>;

            for (int i = count - 1; i >= 0; i--)
            {
                var model = dgvList[dataGridView1.SelectedRows[i].Index];
                if (!string.IsNullOrEmpty(model.Visa_id))
                {
                    MessageBoxEx.Show("选中项中有已经设置过团号的签证!");
                    return null;
                }
                list.Add(model);
            }
            return list;
        }

        /// <summary>
        /// 获取选中项的list
        /// </summary>
        /// <returns></returns>
        private List<Model.VisaInfo> GetDgvSelList()
        {
            int count = this.dataGridView1.SelectedRows.Count;
            List<Model.VisaInfo> list = new List<VisaInfo>();
            for (int i = count - 1; i >= 0; --i)
            {
                Model.VisaInfo model = (dataGridView1.DataSource as List<VisaInfo>)[dataGridView1.SelectedRows[i].Index];
                if (model != null)
                    list.Add(model);
            }
            return list;
        }





        private void 添加到团号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = GetDgvSelNotSetGroupList();
            if (list == null)
                return;
            FrmVisaManage frm = new FrmVisaManage(true, list);
            frm.ShowDialog();
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

        #region dgv右键菜单响应
        //TODO:增加进度条显示
        private void 外领担保函ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DocComGenerator docComGenerator = new DocComGenerator(DocComGenerator.DocType.Type02WaiLingDanBaohan);
            GlobalUtils.DocDocxGenerator.SetDocType(DocDocxGenerator.DocType.Type02WaiLingDanBaohan);
            var visainfos = GetDgvSelList();

            if (this.dataGridView1.SelectedRows.Count > 1)
            {
                //多余一条的时候生成二维list用于打印
                List<List<string>> stringinfos = new List<List<string>>();
                for (int i = 0; i < visainfos.Count; i++)
                {
                    List<string> list = new List<string>();
                    list.Add(visainfos[i].Name);
                    list.Add(visainfos[i].PassportNo);
                    list.Add(visainfos[i].IssuePlace);
                    list.Add(DateTimeFormator.DateTimeToString(DateTime.Today, DateTimeFormator.TimeFormat.Type04Chinese));
                    stringinfos.Add(list);
                }
                //多余1条的时候选择保存文件夹
                string path = GlobalUtils.ShowBrowseFolderDlg();
                if (string.IsNullOrEmpty(path))
                    return;
                GlobalUtils.DocDocxGenerator.GenerateBatch(stringinfos, path);
            }
            else //一条单独的时候就直接获取就行
            {
                //生成需要替换的list
                List<string> list = new List<string>();
                list.Add(visainfos[0].Name);
                list.Add(visainfos[0].PassportNo);
                list.Add(visainfos[0].IssuePlace);
                list.Add(DateTimeFormator.DateTimeToString(DateTime.Today, DateTimeFormator.TimeFormat.Type04Chinese));
                GlobalUtils.DocDocxGenerator.Generate(list);
            }
        }


        private void 金桥担保函ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DocComGenerator docComGenerator = new DocComGenerator(DocComGenerator.DocType.Type02WaiLingDanBaohan);
            GlobalUtils.DocDocxGenerator.SetDocType(DocDocxGenerator.DocType.Type02JinQiaoDanBaoHan);
            var visainfos = GetDgvSelList();
            if (visainfos.Count > 1)
            {
                MessageBoxEx.Show("只能导出一个!");
                return;
            }

            List<string> list = new List<string>();
            list.Add(visainfos[0].Name);
            list.Add(visainfos[0].PassportNo);
            list.Add(visainfos[0].IssuePlace);
            list.Add(DateTime.Now.Year.ToString());
            list.Add(DateTime.Now.Month.ToString());
            list.Add(DateTime.Now.Day.ToString());
            GlobalUtils.DocDocxGenerator.Generate(list);
        }

        private void 人申请表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var visainfos = GetDgvSelList();
            XlsGenerator.GetGuolvJinGunMingDan(visainfos, _bllVisa.GetVisaListViaVisaInfoList(visainfos));
        }

        private void 机票报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DocComGenerator docComGenerator = new DocComGenerator(DocComGenerator.DocType.Type03JiPiao);
            GlobalUtils.DocDocxGenerator.SetDocType(DocDocxGenerator.DocType.Type03JiPiao);

            var visainfos = GetDgvSelList();
            List<string> list = new List<string>();
            list.Add(RngWord.GetRandomWord());
            for (int i = 0; i != 16; ++i) //占位符2-17
            {
                if (i < visainfos.Count)
                {
                    //由于这里可能出现多个空格，采用正则表达式进行替换
                    string pattern = @"([a-zA-Z]+)(\s+)([a-zA-Z]+)";
                    string englishName = visainfos[i].EnglishName;
                    Match m = Regex.Match(englishName, pattern);
                    list.Add(Regex.Replace(englishName, pattern, "${1}" + @"/" + "${3}")); //替换为指定格式
                }
            }
            list.Add("");
            list.Add("");
            GlobalUtils.DocDocxGenerator.Generate(list);
        }

        private void 打印报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var visainfos = GetDgvSelList();
            if (visainfos.Count == 0)
                return;
            ExcelGenerator.GetPrintTable(visainfos);
        }


        private void DownloadSelectedPics(PassportPicHandler.PicType type)
        {
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                string passportNo = dataGridView1.SelectedRows[0].Cells["PassportNo"].Value.ToString();
                string fileName = PassportPicHandler.GetFileName(passportNo, type);
                string dstName =
                    GlobalUtils.ShowSaveFileDlg(fileName);
                if (string.IsNullOrEmpty(dstName))
                    return;

                PassportPicHandler.DownloadPic(passportNo, type, dstName);
                return;
            }

            List<string> passList = new List<string>();
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                passList.Add(dataGridView1.SelectedRows[i].Cells["PassportNo"].Value.ToString());
            }

            string path = GlobalUtils.ShowBrowseFolderDlg();
            if (string.IsNullOrEmpty(path))
                return;

            int res = PassportPicHandler.DownloadPicBatch(passList.ToArray(), type, path, false);
            if (res > 0)
            {
                if (MessageBoxEx.Show("保存成功，是否打开所在文件夹?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Process.Start(path);
            }
            else
                MessageBoxEx.Show("保存失败");
        }

        private void 护照图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DownloadSelectedPics(PassportPicHandler.PicType.Type01Normal);
        }

        private void 头像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DownloadSelectedPics(PassportPicHandler.PicType.Type02Head);
        }

        private void 护照红外图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DownloadSelectedPics(PassportPicHandler.PicType.Type03IR);
        }

        private void 全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = String.Empty;
            if (this.dataGridView1.SelectedRows.Count == 1)
            {
                string passportNo = dataGridView1.SelectedRows[0].Cells["PassportNo"].Value.ToString();
                path = GlobalUtils.ShowBrowseFolderDlg();
                if (string.IsNullOrEmpty(path))
                    return;

                int res1 = PassportPicHandler.DownloadSelectedTypes(passportNo, path,
                    PassportPicHandler.PicType.Type01Normal | PassportPicHandler.PicType.Type02Head); //传默认值就是全部类型，考虑到他们不需要红外图像，就去掉吧
                if (res1 > 0)
                {
                    if (MessageBoxEx.Show("保存成功，是否打开所在文件夹?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        Process.Start(path);
                }
                else
                    MessageBoxEx.Show("保存失败");
                return;
            }

            List<string> passList = new List<string>();
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                passList.Add(dataGridView1.SelectedRows[i].Cells["PassportNo"].Value.ToString());
            }

            path = GlobalUtils.ShowBrowseFolderDlg();
            if (string.IsNullOrEmpty(path))
                return;

            int res = PassportPicHandler.DownloadSelectedTypesBatch(passList.ToArray(), path,
                PassportPicHandler.PicType.Type01Normal | PassportPicHandler.PicType.Type02Head);
            if (res > 0)
            {
                if (MessageBoxEx.Show("保存成功，是否打开所在文件夹?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Process.Start(path);
            }
            else
                MessageBoxEx.Show("保存失败");
        }

        private void cmsItemQRCodePrint_Click(object sender, EventArgs e)
        {

        }




        private void 添加到送签统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = GetDgvSelList();
            foreach (var visaInfo in list)
            {
                if (string.IsNullOrEmpty(visaInfo.Visa_id))
                {
                    MessageBoxEx.Show("选项中还有未设置团号的签证!\r\n必须是已做资料的才能进行导出!");
                    return;
                }
            }
            List4AddToExport = list;
            this.DialogResult = DialogResult.OK;
            Close();
        }


        private void 韩国担保函ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var visaList = GetSelectedVisaList();
            var visaInfoList = GetDgvSelList();
            if (visaInfoList.Count > 5)
            {
                MessageBoxEx.Show("超出5人限制!");
                return;
            }
            GlobalUtils.DocDocxGenerator.SetDocType(DocDocxGenerator.DocType.Type06HanguoDanBaoHan);
            string[] table = { "一", "二", "三", "四", "五" };
            List<string> list = new List<string>();
            list.Add(visaInfoList[0].Name);
            list.Add(visaInfoList[0].PassportNo);
            list.Add(table[visaInfoList.Count - 1]);
            list.Add(visaInfoList[0].EntryTime.Value.Date.Year.ToString());
            list.Add(visaInfoList[0].EntryTime.Value.Date.Month.ToString());

            //if (visaList[0].DepartureType == "单次加急")
            //list.Add((visaList[0].EntryTime.Value.AddDays(3.0).Date.Day).ToString());
            //else
            //{
            list.Add((visaInfoList[0].EntryTime.Value.AddDays(10.0).Date.Day).ToString());
            //}
            //if (visaList[0].DepartureType == "五年多往" || visaList[0].DepartureType == "五年多往" ||
            //    visaList[0].DepartureType == "五年多次")
            //{
            //    list.Add("五年多往");
            //}
            //else 
            list.Add(string.Empty);
            for (int i = 0; i < 5; i++)
            {
                if (i >= visaInfoList.Count)
                    list.Add(string.Empty);
                else
                    list.Add(visaInfoList[i].Name);
            }

            list.Add(visaInfoList[0].EntryTime.Value.Date.Year.ToString());
            list.Add(visaInfoList[0].EntryTime.Value.Date.Month.ToString());
            list.Add(visaInfoList[0].EntryTime.Value.Date.Day.ToString());
            GlobalUtils.DocDocxGenerator.Generate(list);
        }

        private void 韩国加急申请书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var visaList = GetSelectedVisaList();
            var visaInfoList = GetDgvSelList();
            //if (visaInfoList.Count > 5)
            //{
            //    MessageBoxEx.Show("超出5人限制!");
            //    return;
            //}
            GlobalUtils.DocDocxGenerator.SetDocType(DocDocxGenerator.DocType.Type07HanguoJiaji);
            //string[] table = { "一", "二", "三", "四", "五" };
            List<string> list = new List<string>();
            list.Add(visaInfoList[0].Name);
            list.Add(visaInfoList[0].PassportNo);
            list.Add(visaInfoList.Count.ToString());
            list.Add(visaInfoList[0].EntryTime.Value.Date.Year.ToString());
            list.Add(visaInfoList[0].EntryTime.Value.Date.Month.ToString());
            list.Add((visaInfoList[0].EntryTime.Value.AddDays(3.0).Date.Day).ToString());

            list.Add(visaInfoList[0].EntryTime.Value.Date.Year.ToString());
            list.Add(visaInfoList[0].EntryTime.Value.Date.Month.ToString());
            list.Add(visaInfoList[0].EntryTime.Value.Date.Day.ToString());
            GlobalUtils.DocDocxGenerator.Generate(list);

        }
        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBoxEx.Show("请选中一条记录复制!");
                return;
            }
            string name = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name;
            if (name == "CountryImage")
            {
                return;
            }
            if ((name == "EntryTime" || name == "BirthDay" || name == "LicenceTime" || name == "ExpiryDate")
                && dataGridView1.CurrentCell.Value != null) //归国时间的列,是datetime类型,单独判断
            {
                Clipboard.SetText(DateTimeFormator.DateTimeToString((DateTime)dataGridView1.CurrentCell.Value));
                return;
            }

            if (!string.IsNullOrEmpty((string)dataGridView1.CurrentCell.Value.ToString()))
                Clipboard.SetText(dataGridView1.CurrentCell.Value.ToString());
        }

        private void 删除护照图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = GetDgvSelList();
            if (list.Count > 1)
            {
                MessageBoxEx.Show("请选择一条数据进行删除!");
                return;
            }
            if (MessageBoxEx.Show("是否删除本地图像?", "提示", MessageBoxButtons.YesNo)
                == DialogResult.No)
                return;

            //删除本地图像
            if (PassportPicHandler.CheckLocalExist(list[0].PassportNo, PassportPicHandler.PicType.Type01Normal))
            {
                PassportPicHandler.DeleteLocalPassportPic(list[0].PassportNo, PassportPicHandler.PicType.Type01Normal);
            }

            if (GlobalUtils.LoginUserLevel == RigthLevel.Normal)
            {
                MessageBoxEx.Show("权限不足!");
                return;
            }

            if (MessageBoxEx.Show("是否删除远程图像?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (PassportPicHandler.DeleteRemotePassportPic(list[0].PassportNo, PassportPicHandler.PicType.Type01Normal))
            {
                MessageBoxEx.Show("删除成功!");
            }
            else
            {
                MessageBoxEx.Show("删除失败!");
            }
        }


        private void 上传护照图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = GetDgvSelList();
            if (list.Count > 1)
            {
                MessageBoxEx.Show("请选择一条数据进行删除!");
                return;
            }
            if (PassportPicHandler.CheckRemoteExist(list[0].PassportNo, PassportPicHandler.PicType.Type01Normal))
            {
                if (MessageBoxEx.Show("指定护照号在服务器已经存在图像，是否替换?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                //远程已经存在的情况下先检查权限
                if (GlobalUtils.LoginUserLevel == RigthLevel.Normal)
                {
                    MessageBoxEx.Show("权限不足!");
                    return;
                }
            }
            string filename = GlobalUtils.ShowOpenFileDlg();
            if (string.IsNullOrEmpty(filename))
                return;
            PassportPicHandler.UploadPassportPic(filename, list[0].PassportNo);
            MessageBoxEx.Show("上传成功!");
        }




        #endregion


    }
}
