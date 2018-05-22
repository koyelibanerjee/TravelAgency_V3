﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.BLL;
using TravelAgency.Common;
using TravelAgency.Common.Excel;
using TravelAgency.Common.Word;
using TravelAgency.CSUI.Financial.FrmSub;
using TravelAgency.CSUI.FrmSub;
using TravelAgency.CSUI.Properties;
using Visa = TravelAgency.Model.Visa;
using VisaInfo = TravelAgency.Model.VisaInfo;

namespace TravelAgency.CSUI.Financial.FrmMain
{
    public partial class FrmVisaClaimManage : Form
    {
        private readonly TravelAgency.BLL.Visa _bllVisa = new TravelAgency.BLL.Visa();
        private readonly TravelAgency.BLL.VisaInfo _bllVisaInfo = new TravelAgency.BLL.VisaInfo();
        private readonly TravelAgency.BLL.ActionRecords _bllActionRecords = new ActionRecords();
        private readonly TravelAgency.BLL.HasExported8Report _bllHasExported8Report = new HasExported8Report();
        private int _curPage = 1;
        private int _pageCount = 0;
        private int _pageSize = 30;
        private int _recordCount = 0;
        private bool _init = false;
        private string _where = string.Empty;

        private decimal? _numBackup = null;
        private bool _needDoUpdateEvent = false;

        private List<Model.Visa> _visaListBackUp;

        public FrmVisaClaimManage()
        {
            InitializeComponent();
        }

        private void FrmVisaManage_Load(object sender, EventArgs e)
        {
            _recordCount = _bllVisa.GetRecordCount(string.Empty);
            _pageCount = (int)Math.Ceiling((double)_recordCount / _pageSize);
            cbPageSize.Items.Add("30");
            cbPageSize.Items.Add("50");
            cbPageSize.Items.Add("100");
            cbPageSize.Items.Add("300");
            cbPageSize.Items.Add("500");
            cbPageSize.Items.Add("1000");
            cbPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPageSize.SelectedIndex = 1;

            cbDisplayType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDisplayType.Items.Add("全部");
            cbDisplayType.Items.Add("未记录");
            cbDisplayType.Items.Add("个签");
            cbDisplayType.Items.Add("团签");
            cbDisplayType.Items.Add("团做个");
            cbDisplayType.Items.Add("个签&&团做个");
            cbDisplayType.SelectedIndex = 0;

            cbSubmitState.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSubmitState.Items.Add("全部");
            cbSubmitState.Items.Add("未提交");
            cbSubmitState.Items.Add("已提交");
            cbSubmitState.SelectedIndex = 1;


            //国家选择框加入
            //cbCountry.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCountry.Items.Add("全部");
            foreach (string countryName in CountryCode.CountryNameArr)
            {
                cbCountry.Items.Add(countryName);
            }
            cbCountry.SelectedIndex = 0;


            cbDepatureType.Items.Add("全部");
            cbDepatureType.Items.Add("单次");
            cbDepatureType.Items.Add("单次加急");
            cbDepatureType.Items.Add("三年多往");
            cbDepatureType.Items.Add("五年");
            cbDepatureType.Items.Add("五年多往");
            cbDepatureType.Items.Add("五年加急");
            cbDepatureType.Items.Add("十年");
            cbDepatureType.Items.Add("十年多往");
            cbDepatureType.Items.Add("十年加急");
            cbDepatureType.Items.Add("其他");
            cbDepatureType.SelectedIndex = 0;

            dataGridView1.AutoGenerateColumns = false; //不显示指定之外的列
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; //列宽自适应,一定不能用AllCells
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders; //这里也一定不能AllCell自适应!


            dataGridView1.CellMouseUp += dataGridView1_CellMouseUp;
            //dataGridView1.CellBeginEdit += DataGridView1_CellBeginEdit;
            //dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
            //dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;

            dataGridView1.DefaultCellStyle.Font = new Font("微软雅黑", 9.0f, FontStyle.Bold);
            bgWorkerLoadData.WorkerReportsProgress = true;
            progressLoading.Visible = false;

            dataGridView1.ReadOnly = true;

            //dataGridView1.Columns["Receipt"].ReadOnly = false;

            LoadDataToDgvAsyn();
            _init = true;
        }

        //private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    //单元格值发生变化的时候，变成橙色
        //    if (!_needDoUpdateEvent || e.RowIndex < 0 || e.ColumnIndex < 0)
        //        return;

        //    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.DarkOrange;
        //    Font f = new Font("微软雅黑", 12.0f, FontStyle.Bold);
        //    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = f;
        //    dataGridView1.UpdateCellValue(e.ColumnIndex, e.RowIndex);

        //    //updateMoney();
        //}

        //private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex < 0 || e.ColumnIndex < 0)
        //        return;
        //    string name = dataGridView1.Columns[e.ColumnIndex].Name;
        //    if ( name == "Receipt" ||
        //        name == "Price")
        //    {
        //        //判断是否发生了变化

        //        if ((_numBackup == null && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) ||//原来是空，现在有值了
        //            (_numBackup != null && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) ||//原来有值，现在是空
        //            (_numBackup != null && _numBackup != (decimal)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)//都有值但是变化了
        //            )
        //        {
        //            _needDoUpdateEvent = true;
        //            DataGridView1_CellValueChanged(null, e); //手动触发一次事件
        //        }
        //    }
        //}

        //private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        //{

        //    string name = dataGridView1.Columns[e.ColumnIndex].Name;
        //    if ( name == "Receipt" ||
        //         name == "Price")
        //    {
        //        if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
        //        {
        //            _numBackup = (decimal)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        //        }
        //        else
        //            _numBackup = null;
        //    }

        //}

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
            _needDoUpdateEvent = false;
            //Console.WriteLine("加载一次");
            int curSelectedRow = -1;
            if (dataGridView1.SelectedRows.Count > 0)
                curSelectedRow = dataGridView1.SelectedRows[0].Index;

            var list = _bllVisa.GetListByPage(page, _pageSize, _where);
            dataGridView1.DataSource = list;
            _visaListBackUp = new List<Model.Visa>(); //每次加载到dgv的时候也同时刷新备份部分
            foreach (var visa in list)
            {
                _visaListBackUp.Add(visa.ToObjectCopy());
            }

            if (curSelectedRow != -1 && dataGridView1.Rows.Count > curSelectedRow)
                dataGridView1.CurrentCell = dataGridView1.Rows[curSelectedRow].Cells[0];

            GlobalStat.UpdateStatistics();
            _needDoUpdateEvent = true;
        }

        public void UpdateState()
        {
            _recordCount = _bllVisa.GetRecordCount(_where);
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


        #region dgv的bar栏按钮
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
            _curPage = 1;
            LoadDataToDgvAsyn();

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            btnClearSchConditions_Click(null, null);
            _where = string.Empty;
            //cbState.Text = "全部";
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
                conditions.Add(" Types = '团做个' or Types = '个签'");
            }

            if (!string.IsNullOrEmpty(txtSchGroupNo.Text.Trim()))
            {
                conditions.Add(" (GroupNo like '%" + txtSchGroupNo.Text + "%') ");
            }

            if (!string.IsNullOrEmpty(txtSchRealTimeFrom.Text.Trim()) && !string.IsNullOrEmpty(txtSchRealTimeTo.Text.Trim()))
            {
                conditions.Add(" (RealTime between '" + txtSchRealTimeFrom.Text + "' and " + " '" + txtSchRealTimeTo.Text +
                               "') ");
            }

            if (!string.IsNullOrEmpty(txtSchFinishTimeFrom.Text.Trim()) && !string.IsNullOrEmpty(txtSchFinishTimeTo.Text.Trim()))
            {
                conditions.Add(" (FinishTime between '" + txtSchFinishTimeFrom.Text + "' and " + " '" + txtSchFinishTimeTo.Text +
                               "') ");
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

            if (cbDepatureType.Text == "全部")
            {

            }
            else
            {
                conditions.Add(" DepartureType = '" + cbDepatureType.Text + "' ");
            }

            if (cbSubmitState.Text == "全部")
            {

            }
            else if (cbSubmitState.Text == "未提交")
            {
                conditions.Add(" (submitflag =" + 0 + " or submitflag is null)"); //0是未提交，所以这里处理一下
            }
            else
            {
                conditions.Add(" (submitflag =" + 1 + ")"); //0是未提交，所以这里处理一下
            }


            string[] arr = conditions.ToArray();
            string where = string.Join(" and ", arr);
            return where;
        }

        private void btnClearSchConditions_Click(object sender, EventArgs e)
        {

            txtSchRealTimeFrom.Text = string.Empty;
            txtSchRealTimeTo.Text = string.Empty;
            txtSchGroupNo.Text = string.Empty;
            txtSalesPerson.Text = string.Empty;
            txtClient.Text = string.Empty;

            cbDepatureType.Text = "全部";
            cbDisplayType.Text = "全部";
            cbCountry.Text = "全部";
        }


        private void btnShowToday_Click(object sender, EventArgs e)
        {

            var _modelYestodayLast = _bllVisa.GetLastRecordOfTheDay(DateTime.Now.AddDays(-1.0));
            var _modelTodayLast = _bllVisa.GetLastRecordOfTheDay(DateTime.Now);
            if (_modelYestodayLast != null)
                txtSchRealTimeFrom.Text = DateTimeFormator.DateTimeToString(_modelYestodayLast.EntryTime.Value.AddMinutes(1.0), DateTimeFormator.TimeFormat.Type06LongTime);
            else
                txtSchRealTimeFrom.Text = DateTimeFormator.DateTimeToString(DateTime.Today) + " 00:00";
            if (_modelTodayLast != null)
                txtSchRealTimeTo.Text = DateTimeFormator.DateTimeToString(_modelTodayLast.EntryTime.Value.AddMinutes(1.0), DateTimeFormator.TimeFormat.Type06LongTime);
            else
                txtSchRealTimeTo.Text = DateTimeFormator.DateTimeToString(DateTime.Today) + " 16:00";

            btnSearch_Click(null, null);
        }

        private void btnAddVisa_Click(object sender, EventArgs e)
        {
            //FrmAddVisa frm = new FrmAddVisa(LoadDataToDataGridView, _curPage);
            //frm.Show();
        }

        private void btnGetTodayExcel_Click(object sender, EventArgs e)
        {
            FrmTimeSpanChoose frmSpanChoose = new FrmTimeSpanChoose();
            if (frmSpanChoose.ShowDialog() == DialogResult.Cancel)
                return;
            DateTime from = frmSpanChoose.TimeSpanFrom;
            DateTime to = frmSpanChoose.TimeSpanTo;

            //List<Visa> visaList =
            //    _bllVisa.GetModelList(" (EntryTime between '" + DateTimeFormator.DateTimeToString(from) + " 00:00:0.000' and " + " '" +
            //                         DateTimeFormator.DateTimeToString(to) +
            //                          " 23:59:59.999') and (Types='个签' or Types='团做个')");

            List<Model.Visa> visaList =
    _bllVisa.GetModelList(" (EntryTime between '" +
                                    DateTimeFormator.DateTimeToString(from, DateTimeFormator.TimeFormat.Type06LongTime) + "' and '" +
                                    DateTimeFormator.DateTimeToString(to, DateTimeFormator.TimeFormat.Type06LongTime) +
                         "') and (Types='个签' or Types='团做个') and (country = '日本') order by entrytime asc");

            //这里干脆就不判断entrytime了，直接找记录算了
            visaList = _bllActionRecords.CheckStatesAndRemove(visaList, Common.Enums.ActType._02TypeInData, 4); //只保留已经做完了的

            //这里确认一下
            if (visaList.Count <= 0)
            {
                MessageBoxEx.Show("所选时间段没有报表需要生成!");
                return;
            }

            //按照出境类型(按照Excel报表中来)，人数排序(从小到大)
            visaList.Sort((model1, model2) =>
            {
                if (!Common.DepartureType.Dict.ContainsKey(model1.DepartureType))
                    return 1;

                if (!Common.DepartureType.Dict.ContainsKey(model2.DepartureType))
                    return -1;

                if (Common.DepartureType.Dict[model1.DepartureType] < Common.DepartureType.Dict[model2.DepartureType])
                    return -1;
                else if (Common.DepartureType.Dict[model1.DepartureType] ==
                         Common.DepartureType.Dict[model2.DepartureType])
                {
                    return model1.Number < model2.Number ? -1 : 1;
                }
                else
                    return 1;
            });

            List<List<VisaInfo>> visaInfoList = new List<List<VisaInfo>>();

            for (int i = visaList.Count - 1; i >= 0; --i)
            {
                //List<VisaInfo> list = _bllVisaInfo.GetModelList(" visa_id = '" + visaList[i].Visa_id.ToString() + "' ");
                List<VisaInfo> list = _bllVisaInfo.GetModelListByVisaIdOrderByPosition(visaList[i].Visa_id);

                //去除掉添加了延后操作的
                for (int j = list.Count - 1; j >= 0; j--)
                {
                    if (list[j].outState == Common.Enums.OutState.Type01Delay)
                    {
                        list.Remove(list[j]);
                    }
                }
                if (list.Count != 0)
                    visaInfoList.Insert(0, list);
                else
                    visaList.Remove(visaList[i]); //如果这个团所有人都被移出去了，那么就直接把这个团也删除掉
            }

            ////再去除已经导出8人报表的
            //_bllHasExported8Report.CheckExistAndRemove(visaList, visaInfoList);
            FrmTodaySubmit frm = new FrmTodaySubmit(visaList, visaInfoList);
            frm.From = from;
            frm.To = to;
            //frm.ShowDialog();
            frm.Show();
            //ExcelGenerator.GetEverydayExcel(visaList, visaInfoList);
        }

        #endregion


        #region dgv消息响应

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridView1.CurrentCell.Value != null && e.Control && e.KeyCode == Keys.C)
            {
                复制ToolStripMenuItem_Click(null, null);
            }
        }

        /// <summary>
        /// dgv设置行号以及国家图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var visas = dataGridView1.DataSource as List<Model.Visa>;

            //经过测试发现，不做判断反而是最快的。。。大概是反正不做判断的话，也就只有一行的原因吧？
            //Console.WriteLine(dataGridView1.Rows.Count);
            //if (dataGridView1.Rows.Count != _pageSize || _hasFormated)
            //    return;
            //if (dataGridView1.Rows.Count != _pageSize  )
            //    return;


            Font font = new Font(new FontFamily("Consolas"), 13.0f, FontStyle.Bold);
            //int peopleCount = 0;
            //int hasDo = 0;
            decimal moneycount = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                if (dataGridView1.Rows[i].Cells["Country"].Value != null)
                {
                    string countryName = dataGridView1.Rows[i].Cells["Country"].Value.ToString();
                    dataGridView1.Rows[i].Cells["CountryImage"].Value =
                       TravelAgency.Common.CountryPicHandler.LoadImageByCountryName(countryName);
                }
                if (dataGridView1.Rows[i].Cells["Cost"].Value != null)
                    moneycount += decimal.Parse(dataGridView1.Rows[i].Cells["Cost"].Value.ToString());


            }

            lbMonneyCount.Text = "共:" + moneycount + "元.";
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

        }

        private void bgWorkerLoadData_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.progressLoading.Visible = false;
            this.progressLoading.IsRunning = false;
        }
        #endregion
        #region dgv右键响应
        #region Utils
        private List<Model.Visa> DgvDataSourceToList()
        {
            return dataGridView1.DataSource as List<Model.Visa>;
        }

        /// <summary>
        /// 返回当前选择的行的visaModel（函数不校验到底是选中的一个还是多个）
        /// </summary>
        /// <returns></returns>
        private Model.Visa GetSelectedVisaModel()
        {
            Model.Visa visaModel = DgvDataSourceToList()[dataGridView1.SelectedRows[0].Index];
            return visaModel;
        }

        /// <summary>
        /// 返回当前选择的行的visaModel的List
        /// </summary>
        /// <returns></returns>
        private List<Model.Visa> GetSelectedVisaList()
        {
            var visaList = dataGridView1.DataSource as List<Model.Visa>;
            List<Model.Visa> res = new List<Model.Visa>();
            for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
                res.Add(DgvDataSourceToList()[dataGridView1.SelectedRows[i].Index]);
            return res.Count > 0 ? res : null;
        }

        /// <summary>
        /// 返回当前选中团号对应的visainfo所有的list,若没有找到则返回null
        /// </summary>
        /// <returns></returns>
        private List<Model.VisaInfo> GetSelectedVisaInfoList()
        {
            var visaList = DgvDataSourceToList();
            List<Model.VisaInfo> res = new List<VisaInfo>();
            for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
                res.AddRange(_bllVisaInfo.GetModelListByVisaIdOrderByPosition(visaList[dataGridView1.SelectedRows[i].Index].Visa_id));
            return res.Count > 0 ? res : null;
        }

        /// <summary>
        /// 返回当前选中团号对应的visainfo所有的list,按照所在团号分类,若没有找到则返回null
        /// </summary>
        /// <returns></returns>
        private List<List<Model.VisaInfo>> GetSelectedVisaInfoListList()
        {
            var visaList = DgvDataSourceToList();
            List<List<Model.VisaInfo>> res = new List<List<VisaInfo>>();
            for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
                //res.Add(_bllVisaInfo.GetModelList(" Visa_id = '" + visaList[dataGridView1.SelectedRows[i].Index].Visa_id + "'"));
                res.Add(_bllVisaInfo.GetModelListByVisaIdOrderByPosition(visaList[dataGridView1.SelectedRows[i].Index].Visa_id));
            return res.Count > 0 ? res : null;
        }
        #endregion



        #region 功能性

        /// <summary>
        /// 查看选中团号，可以移出团号里的人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsItemShowGroupNo_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 1)
            {
                MessageBoxEx.Show(Resources.SelectShowMoreThanOne);
                return;
            }

            Model.Visa model = GetSelectedVisaModel();
            if (model == null)
            {
                MessageBoxEx.Show(Resources.FindModelFailedPleaseCheckInfoCorrect);
                return;
            }

            if (model.Types == Common.Enums.Types.Individual || model.Types == Common.Enums.Types.Team2Individual)
            {
                FrmSetGroup frm = new FrmSetGroup(model, LoadDataToDataGridView, _curPage);
                //frm.ShowDialog();
                frm.Show();
            }
            else if (model.Types == Common.Enums.Types.Team)
            {
                FrmSetTeamVisaGroup frm = new FrmSetTeamVisaGroup(model, LoadDataToDataGridView, _curPage);
                //frm.ShowDialog();
                frm.Show();
            }
        }

        private void cmsItemRefreshDatabase_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView(_curPage);
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
            if ((name == "EntryTime" || name == "PredictTime")
                && dataGridView1.CurrentCell.Value != null) //归国时间的列,是datetime类型,单独判断
            {
                Clipboard.SetText(DateTimeFormator.DateTimeToString((DateTime)dataGridView1.CurrentCell.Value));
                return;
            }

            if (!string.IsNullOrEmpty((string)dataGridView1.CurrentCell.Value.ToString()))
                Clipboard.SetText(dataGridView1.CurrentCell.Value.ToString());
        }























        #endregion

        #endregion

        private void 签证认账ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = GetSelectedVisaList();
            HashSet<string> set = new HashSet<string>();
            bool claimed = false;
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i].ClaimedFlag == "是")
                {
                    claimed = true;
                }
                set.Add(list[i].client);
            }
            if (set.Count > 1)
            {
                MessageBoxEx.Show("不同客户的团号不能一起认账!!!");
                return;
            }


            if (claimed && 
                MessageBoxEx.Show("选中项中已经有认过账的团号，是否继续?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            FrmSetClaim frm = new FrmSetClaim(list, LoadDataToDataGridView, _curPage);
            frm.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var list = dataGridView1.DataSource as List<Model.Visa>;

            for (int i = 0; i != list.Count; ++i)
            {
                if (!InfoChecker.CheckVisaSame(list[i], _visaListBackUp[i]))
                {
                    if (!_bllVisa.Update(list[i])) //不同就更新
                    {
                        MessageBoxEx.Show("团号:" + list[i].GroupNo + "更新失败!");
                        return;
                    }
                }
            }
            MessageBoxEx.Show("更新成功!");
            LoadDataToDgvAsyn();
        }
    }
}
