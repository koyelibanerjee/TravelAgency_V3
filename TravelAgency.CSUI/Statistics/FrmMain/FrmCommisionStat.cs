using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.BLL;
using TravelAgency.BLL.Excel;
using TravelAgency.Common;
using TravelAgency.Common.Excel;
using TravelAgency.Common.FrmSetValues;
using TravelAgency.CSUI.FrmSub;
using FrmTimeSpanChoose = TravelAgency.CSUI.Visa.FrmSub.FrmSetValue.FrmTimeSpanChoose;

namespace TravelAgency.CSUI.Statistics.FrmMain
{
    public partial class FrmCommisionStat : Form
    {
        private readonly BLL.Commision _bllCommision = new BLL.Commision();
        private readonly BLL.Commision_Sale _bllCommisionSale = new BLL.Commision_Sale();
        private readonly BLL.Visa _bllVisa = new BLL.Visa();
        private int _curPage = 1;
        private int _pageCount = 0;
        private int _pageSize;
        private int _recordCount = 0;
        private string _commisontype;
        private string _username;

        public List<Model.VisaInfo> List4AddToExport;
        private bool _b4AddToExport = false;

        public FrmCommisionStat(bool b4Add = false)
        {
            _b4AddToExport = b4Add; //指明用于添加到导出界面的
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _recordCount = 0;
            _pageCount = (int)Math.Ceiling(_recordCount / (double)_pageSize);

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

            dgvOperCommision.AutoGenerateColumns = false;
            dgvOperCommision.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; //列宽自适应,一定不能用AllCells
            dgvOperCommision.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders; //这里也一定不能AllCell自适应!
            dgvOperCommision.DefaultCellStyle.Font = new Font("微软雅黑", 9.0f, FontStyle.Bold);

            dgvSaleCommision.AutoGenerateColumns = false;
            dgvSaleCommision.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; //列宽自适应,一定不能用AllCells
            dgvSaleCommision.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders; //这里也一定不能AllCell自适应!
            dgvSaleCommision.DefaultCellStyle.Font = new Font("微软雅黑", 9.0f, FontStyle.Bold);

            dgvOperCommision.RowsAdded += dgvOperCommision_RowsAdded;
            dgvSaleCommision.RowsAdded += DgvSaleCommision_RowsAdded;

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

            //LoadDataToDgvAsyn();
            InitComboboxs();

        }

        private void DgvSaleCommision_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            decimal total = 0;
            for (int i = 0; i < dgvSaleCommision.Rows.Count; i++)
            {
                DataGridViewRow row = dgvSaleCommision.Rows[i];
                row.HeaderCell.Value = (i + 1).ToString();
                for (int j = 0; j != dgvSaleCommision.ColumnCount; ++j)
                {
                    var value = dgvSaleCommision.Rows[i].Cells[j].Value;
                    if (dgvSaleCommision.Rows[i].Cells[j].ValueType == typeof(decimal) && value != null)
                        dgvSaleCommision.Rows[i].Cells[j].Value = DecimalHandler.DecimalToString((decimal?)value);
                }
                total += DecimalHandler.Parse(dgvSaleCommision.Rows[i].Cells["Sale_CommisionTotal"].Value.ToString());
            }

            lbSaleCommisionCount.Text = $"提成总计:{total} 元.";
        }

        private void InitComboboxs()
        {
            //txtClient.DropDownStyle = ComboBoxStyle.DropDown;
            //txtSalesPerson.DropDownStyle = ComboBoxStyle.DropDown;
            txtOperator.DropDownStyle = ComboBoxStyle.DropDown;
            txtTypeInPerson.DropDownStyle = ComboBoxStyle.DropDown;

            var list = _bllVisa.GetOperatorList();
            if (list != null && list.Count > 0)
                foreach (var item in list)
                {
                    txtOperator.Items.Add(item);
                }

            list = _bllVisa.GetTypeInPersonList();
            if (list != null && list.Count > 0)
                foreach (var item in list)
                {
                    txtTypeInPerson.Items.Add(item);
                }

        }


        private void dgvOperCommision_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            decimal total = 0;
            for (int i = 0; i < dgvOperCommision.Rows.Count; i++)
            {
                DataGridViewRow row = dgvOperCommision.Rows[i];
                row.HeaderCell.Value = (i + 1).ToString();
                for (int j = 0; j != dgvOperCommision.ColumnCount; ++j)
                {
                    var value = dgvOperCommision.Rows[i].Cells[j].Value;
                    if (dgvOperCommision.Rows[i].Cells[j].ValueType == typeof(decimal) && value != null)
                        dgvOperCommision.Rows[i].Cells[j].Value = DecimalHandler.DecimalToString((decimal?)value);
                }
                total += DecimalHandler.Parse(dgvOperCommision.Rows[i].Cells["CommisionTotal"].Value.ToString());
            }

            lbCommisionMoneyCount.Text = $"提成总计:{total} 元.";

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
            int curSelectedRow = -1;
            if (dgvOperCommision.SelectedRows.Count > 0)
                curSelectedRow = dgvOperCommision.SelectedRows[0].Index;
            dgvOperCommision.DataSource = _bllCommision.GetTStatList(txtSchEntryTimeFrom.Text, txtSchEntryTimeTo.Text,
                _commisontype, _username);
            if (curSelectedRow != -1 && dgvOperCommision.Rows.Count > curSelectedRow)
                dgvOperCommision.CurrentCell = dgvOperCommision.Rows[curSelectedRow].Cells[0];
            dgvOperCommision.Update();
            GlobalStat.UpdateStatistics();
        }

        public void LoadDataToSaleDataGridView(int page) //刷新后保持选中
        {
            int curSelectedRow = -1;
            if (dgvSaleCommision.SelectedRows.Count > 0)
                curSelectedRow = dgvSaleCommision.SelectedRows[0].Index;
            dgvSaleCommision.DataSource = _bllCommisionSale.GetTStatList(txtSchEntryTimeFrom.Text, txtSchEntryTimeTo.Text,
              _username);
            if (curSelectedRow != -1 && dgvSaleCommision.Rows.Count > curSelectedRow)
                dgvSaleCommision.CurrentCell = dgvSaleCommision.Rows[curSelectedRow].Cells[0];
            dgvSaleCommision.Update();
            GlobalStat.UpdateStatistics();
        }

        private void UpdateState()
        {
            //_recordCount = _bllStatisticsBll.GetRecordCount(_where);
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
            lbRecordCount.Text = "共有记录:---" + /*_recordCount +*/ "条";
            lbCurPage.Text = "当前为第" + _curPage + "页";
        }
        #endregion

        #region dgv的bar栏和搜索栏

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
            for (int i = 0; i < dgvOperCommision.Rows.Count; i++)
            {
                DataGridViewRow row = dgvOperCommision.Rows[i];
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
                    if (dgvOperCommision.Rows[e.RowIndex].Selected == false)
                    {
                        dgvOperCommision.ClearSelection();
                        dgvOperCommision.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dgvOperCommision.SelectedRows.Count == 1)
                    {
                        if (e.ColumnIndex != -1) //选中表头了
                            dgvOperCommision.CurrentCell = dgvOperCommision.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        else
                        {
                            dgvOperCommision.CurrentCell = dgvOperCommision.Rows[e.RowIndex].Cells[0];
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




        private void btnTimeSpanChoose_Click(object sender, EventArgs e)
        {
            FrmTimeSpanChoose frm = new FrmTimeSpanChoose();
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;
            txtSchEntryTimeFrom.Text = DateTimeFormator.DateTimeToString(frm.TimeSpanFrom, DateTimeFormator.TimeFormat.Type14LongTime1);
            txtSchEntryTimeTo.Text = DateTimeFormator.DateTimeToString(frm.TimeSpanTo, DateTimeFormator.TimeFormat.Type14LongTime1);
        }

        private void btnShowOperatorCommision_Click(object sender, EventArgs e)
        {
            if (txtSchEntryTimeTo.Text == "" || txtSchEntryTimeFrom.Text == "")
            {
                MessageBoxEx.Show("请先选择时间区间!");
                return;

            }

            if (string.IsNullOrEmpty(txtOperator.Text))
            {
                MessageBoxEx.Show("请先填写操作!");
                return;
            }
            _commisontype = "Operator";
            _username = txtOperator.Text;
            LoadDataToDgvAsyn();
        }

        private void btnShowTypeInPersonCommison_Click(object sender, EventArgs e)
        {
            if (txtSchEntryTimeTo.Text == "" || txtSchEntryTimeFrom.Text == "")
            {
                MessageBoxEx.Show("请先选择时间区间!");
                return;

            }

            if (string.IsNullOrEmpty(txtTypeInPerson.Text))
            {
                MessageBoxEx.Show("请先填写资料员!");
                return;
            }

            _commisontype = "TypeInPerson";
            _username = txtTypeInPerson.Text;
            LoadDataToDgvAsyn();
        }

        private void btnShowSalesPersonCommision_Click(object sender, EventArgs e)
        {
            if (txtSchEntryTimeTo.Text == "" || txtSchEntryTimeFrom.Text == "")
            {
                MessageBoxEx.Show("请先选择时间区间!");
                return;

            }

            if (string.IsNullOrEmpty(txtSalesPerson.Text))
            {
                MessageBoxEx.Show("请先填写销售!");
                return;
            }
            _username = txtSalesPerson.Text;
            LoadDataToSaleDataGridView(_curPage);

        }
    }
}
