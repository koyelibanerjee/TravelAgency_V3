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
using TravelAgency.CSUI.Properties;
using TravelAgency.CSUI.Statistics.FrmSub;
using CommisionMoney = TravelAgency.Model.CommisionMoney;

namespace TravelAgency.CSUI.Statistics.FrmMain
{
    public partial class FrmCommisionMoneyManage : Form
    {
        private readonly TravelAgency.BLL.CommisionMoney _bllCommisionMoney = new TravelAgency.BLL.CommisionMoney();
        private int _curPage = 1;
        private int _pageCount = 0;
        private int _pageSize;
        private int _recordCount = 0;
        private string _where = string.Empty;

        public List<Model.VisaInfo> List4AddToExport;
        private bool _b4AddToExport = false;

        public FrmCommisionMoneyManage(bool b4Add = false)
        {
            _b4AddToExport = b4Add; //指明用于添加到导出界面的
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _recordCount = _bllCommisionMoney.GetRecordCount(_where);
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

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; //千万不能开allcells，特别卡
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.DefaultCellStyle.Font = new Font("微软雅黑", 9.0f, FontStyle.Bold);
            dataGridView1.CellMouseUp += DataGridView1_CellMouseUp;
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
            if (dataGridView1.SelectedRows.Count > 0)
                curSelectedRow = dataGridView1.SelectedRows[0].Index;
            dataGridView1.DataSource = _bllCommisionMoney.GetListByPageOrderById(_curPage, _pageSize, string.Empty);
            if (curSelectedRow != -1 && dataGridView1.Rows.Count > curSelectedRow)
                dataGridView1.CurrentCell = dataGridView1.Rows[curSelectedRow].Cells[0];
            dataGridView1.Update();
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
            //_where = GetWhereCondition();
            _curPage = 1;
            LoadDataToDgvAsyn();

        }

        private void btnClearSchConditions_Click(object sender, EventArgs e)
        {
            txtSchEntryTimeFrom.Text = string.Empty;
            txtSchEntryTimeTo.Text = string.Empty;
        }


        #endregion
        #region dgv消息相应
        /// <summary>
        /// dgv设置行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                row.HeaderCell.Value = (i + 1).ToString();
            }
        }
        private void DataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
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

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddCommisionMoney frm = new FrmAddCommisionMoney(LoadDataToDataGridView,_curPage);
            if(frm.ShowDialog()==DialogResult.OK)
                CommisionMoneyCounter.UpdateCommisionConfig();

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalUtils.LoginUserLevel != RigthLevel.Manager)
            {
                MessageBoxEx.Show("权限不足!");
                return;
            }
            int count = this.dataGridView1.SelectedRows.Count;
            if (MessageBoxEx.Show("确认删除" + count + "条记录?",
                Resources.Confirm, MessageBoxButtons.OKCancel)
                == DialogResult.Cancel)
                return;
            int n = 0;
            var visaList = GetSelectedList();
            for (int i = 0; i != visaList.Count; ++i)
            {
                if (!_bllCommisionMoney.Delete(visaList[i].id))
                    MessageBoxEx.Show("删除失败!");
                ++n;
            }
            GlobalUtils.MessageBoxWithRecordNum("删除", n, count);
            LoadDataToDataGridView(_curPage);
            UpdateState();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = GetSelectedList();

            if (list.Count > 1)
            {
                MessageBoxEx.Show("请选中一条进行修改!");
                return;

            }
            FrmAddCommisionMoney frm = new FrmAddCommisionMoney(LoadDataToDataGridView, _curPage, true, list[0]);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CommisionMoneyCounter.UpdateCommisionConfig();
            }
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


        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            ExcelGenerator.GetStatisticPersonalTable(dataGridView1.DataSource as List<Model.PersonalStat>);
        }

        private void btnTimeSpanChoose_Click(object sender, EventArgs e)
        {
            FrmTimeSpanChoose frm = new FrmTimeSpanChoose();
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;
            txtSchEntryTimeFrom.Text = DateTimeFormator.DateTimeToString(frm.TimeSpanFrom, DateTimeFormator.TimeFormat.Type14LongTime1);
            txtSchEntryTimeTo.Text = DateTimeFormator.DateTimeToString(frm.TimeSpanTo, DateTimeFormator.TimeFormat.Type14LongTime1);
        }

        #region Utils

        private List<Model.CommisionMoney> DgvDataSourceToList()
        {
            return dataGridView1.DataSource as List<Model.CommisionMoney>;
        }

        /// <summary>
        /// 返回当前选择的行的visaModel（函数不校验到底是选中的一个还是多个）
        /// </summary>
        /// <returns></returns>
        private Model.CommisionMoney GetSelectedModel()
        {
            Model.CommisionMoney visaModel = DgvDataSourceToList()[dataGridView1.SelectedRows[0].Index];
            return visaModel;
        }

        /// <summary>
        /// 返回当前选择的行的visaModel的List
        /// </summary>
        /// <returns></returns>
        private List<Model.CommisionMoney> GetSelectedList()
        {
            List<Model.CommisionMoney> res = new List<CommisionMoney>();
            for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
                res.Add(DgvDataSourceToList()[dataGridView1.SelectedRows[i].Index]);
            return res.Count > 0 ? res : null;
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            新增ToolStripMenuItem_Click(null, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            删除ToolStripMenuItem_Click(null,null);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            修改ToolStripMenuItem_Click(null,null);
        }
    }
}
