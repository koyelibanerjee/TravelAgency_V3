using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.BLL;
using TravelAgency.BLL.Excel;
using TravelAgency.Common;
using TravelAgency.Common.FrmSetValues;
using TravelAgency.Common.Word;
using TravelAgency.CSUI.Financial.FrmSub;
using TravelAgency.CSUI.FrmSub;
using TravelAgency.CSUI.Properties;
using TravelAgency.Model.Enums;
using FrmTimeSpanChoose = TravelAgency.CSUI.Visa.FrmSub.FrmSetValue.FrmTimeSpanChoose;
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
        public bool NeedDoUpdateEvent = false;

        private List<Model.Visa> _visaListBackUp;

        public FrmVisaClaimManage()
        {
            this.StartPosition = !this.Modal ? FormStartPosition.CenterScreen : FormStartPosition.CenterParent;

            InitializeComponent();
        }

        private void FrmVisaManage_Load(object sender, EventArgs e)
        {
            _where = GetWhereCondition();
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

            ControlInitializer.InitCombo(cbDisplayType, Model.Enums.Types.List, ComboBoxStyle.DropDownList, 0);

            cbClaimedFlag.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClaimedFlag.Items.Add("全部");
            cbClaimedFlag.Items.Add("是");
            cbClaimedFlag.Items.Add("已生成账单");
            cbClaimedFlag.Items.Add("否");
            cbClaimedFlag.SelectedIndex = 0;

            cbSchTimeType.Items.Add("录入时间");
            cbSchTimeType.Items.Add("进签时间");
            cbSchTimeType.Items.Add("出签时间");
            cbSchTimeType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSchTimeType.SelectedIndex = 0;

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
            dataGridView1.Columns["GroupNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.CellMouseUp += dataGridView1_CellMouseUp;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
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

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;
            int total = 0;

            for (int i = 0; i < dataGridView1.SelectedRows.Count; ++i)
            {
                var model = DgvDataSourceToList()[dataGridView1.SelectedRows[i].Index];
                total += model.Number ?? 0;
            }

            lbCount.Text = string.Format("选中{0}项 共:{1}人", dataGridView1.SelectedRows.Count, total);
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
            NeedDoUpdateEvent = false;
            //Console.WriteLine("加载一次");
            var selRows = SelectionKeeper.GetSelectedGuids(dataGridView1, "Visa_id");
            int rowsCnt, rowIdx, colIdx;
            SelectionKeeper.GetSelectedPos(dataGridView1, out rowsCnt, out rowIdx, out colIdx);

            var list = _bllVisa.GetListByPage(page, _pageSize, _where);
            dataGridView1.DataSource = list;
            _visaListBackUp = new List<Model.Visa>(); //每次加载到dgv的时候也同时刷新备份部分
            foreach (var visa in list)
            {
                _visaListBackUp.Add(visa.ToObjectCopy());
            }

            SelectionKeeper.RestoreSelection(selRows, dataGridView1, "Visa_id");
            SelectionKeeper.RestoreSelectedPos(dataGridView1, rowsCnt, rowIdx, colIdx);
            GlobalStat.UpdateStatistics();
            NeedDoUpdateEvent = true;
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

            if (!string.IsNullOrEmpty(txtSchGroupNo.Text.Trim()))
            {
                conditions.Add(" (GroupNo like '%" + txtSchGroupNo.Text + "%') ");
            }

            SearchCondition.GetVisaTypesCondition(conditions, cbDisplayType.Text);
            SearchCondition.GetVisaPaymentNoCondion(conditions, txtPaymentNo.Text);
            string timeType;
            if (cbSchTimeType.Text == "录入时间")
            {
                timeType = "EntryTime";
                if (!string.IsNullOrEmpty(txtSchTimeFrom.Text.Trim()) &&
                    !string.IsNullOrEmpty(txtSchTimeTo.Text.Trim()))
                {
                    conditions.Add(" (" + timeType + " between '" + txtSchTimeFrom.Text + "' and " + " '" +
                                   txtSchTimeTo.Text +
                                   "') ");
                }
            }

            else
            {
                if (cbSchTimeType.Text == "进签时间")
                    timeType = "RealTime";
                else
                    timeType = "FinishTime";
                if (!string.IsNullOrEmpty(txtSchTimeFrom.Text.Trim()) &&
                    !string.IsNullOrEmpty(txtSchTimeTo.Text.Trim()))
                {
                    conditions.Add(" (" + timeType + " between '" + txtSchTimeFrom.Text + " 00:00' and " + " '" +
                                   txtSchTimeTo.Text +
                                   " 23:59:59') ");
                }
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

            if (cbClaimedFlag.Text == "全部")
            {

            }
            else
            {
                conditions.Add(" (ClaimedFlag ='" + cbClaimedFlag.Text + "')"); //
            }

            conditions.Add(" (ForRequestGroupNo = 0) ");
            string[] arr = conditions.ToArray();
            string where = string.Join(" and ", arr);
            return where;
        }

        private void btnClearSchConditions_Click(object sender, EventArgs e)
        {

            txtSchTimeFrom.Text = string.Empty;
            txtSchTimeTo.Text = string.Empty;
            txtSchGroupNo.Text = string.Empty;
            txtSalesPerson.Text = string.Empty;
            txtClient.Text = string.Empty;
            txtPaymentNo.Text = string.Empty;

            cbDepatureType.Text = "全部";
            cbDisplayType.Text = "全部";
            cbCountry.Text = "全部";
        }


        private void btnShowToday_Click(object sender, EventArgs e)
        {

            var _modelYestodayLast = _bllVisa.GetLastRecordOfTheDay(DateTime.Now.AddDays(-1.0));
            var _modelTodayLast = _bllVisa.GetLastRecordOfTheDay(DateTime.Now);
            if (_modelYestodayLast != null)
                txtSchTimeFrom.Text = DateTimeFormator.DateTimeToString(_modelYestodayLast.EntryTime.Value.AddMinutes(1.0), DateTimeFormator.TimeFormat.Type06LongTime);
            else
                txtSchTimeFrom.Text = DateTimeFormator.DateTimeToString(DateTime.Today) + " 00:00";
            if (_modelTodayLast != null)
                txtSchTimeTo.Text = DateTimeFormator.DateTimeToString(_modelTodayLast.EntryTime.Value.AddMinutes(1.0), DateTimeFormator.TimeFormat.Type06LongTime);
            else
                txtSchTimeTo.Text = DateTimeFormator.DateTimeToString(DateTime.Today) + " 16:00";

            btnSearch_Click(null, null);
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


                for (int j = 0; j != dataGridView1.ColumnCount; ++j)
                {
                    var value = dataGridView1.Rows[i].Cells[j].Value;
                    if (dataGridView1.Rows[i].Cells[j].ValueType == typeof(decimal?) && value != null)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = DecimalHandler.DecimalToString((decimal?)value);
                    }
                }


                if (dataGridView1.Rows[i].Cells["Country"].Value != null)
                {
                    string countryName = dataGridView1.Rows[i].Cells["Country"].Value.ToString();
                    dataGridView1.Rows[i].Cells["CountryImage"].Value =
                       TravelAgency.Common.CountryPicHandler.LoadImageByCountryName(countryName);
                }
                if (dataGridView1.Rows[i].Cells["ActuallyAmount"].Value != null)
                    moneycount += decimal.Parse(dataGridView1.Rows[i].Cells["ActuallyAmount"].Value.ToString());


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

            if (model.Types == Model.Enums.Types.Individual || model.Types == Model.Enums.Types.Team2Individual)
            {
                FrmSetGroup frm = new FrmSetGroup(model, LoadDataToDataGridView, _curPage);
                //frm.ShowDialog();
                frm.Show();
            }
            else if (model.Types == Model.Enums.Types.Team)
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
                    claimed = true;
                string custName = list[i].client;
                
                set.Add(UtilsBll.getClientNameNoHR(custName));
            }
            if (set.Count > 1)
            {
                MessageBoxEx.Show("不同客户的团号不能一起认账!!!");
                return;
            }

            if (claimed && MessageBoxEx.Show("选中项中已经有认过账的团号，是否继续?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            if (FrmsManager.FormSetClaim == null)
            {
                FrmSetClaim frm = new FrmSetClaim(list, LoadDataToDataGridView, _curPage);
                frm.Show();
            }
            else
            {
                MessageBoxEx.Show("请不要重复打开设置认账界面!!!");
                return;
            }
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

        private void 生成账单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (MessageBoxEx.Show("生成账单后，会提交所做修改到数据库，是否继续?", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            //    return;
            //FrmSetStringValue frm = new FrmSetStringValue("设置账单编号");
            //frm.ShowDialog();
            //string paymentNo = frm.RetValue;
            //var list = GetSelectedVisaList();
            //if (!BLL.VisaClaimChecker.checkGreaterThanCost(list))
            //{
            //    if (MessageBoxEx.Show("选中项中有收款小于成本的，是否继续?", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            //        return;
            //}
            //XlsGenerator.GetPaymentList(list, paymentNo);

            var list = GetSelectedVisaList();
            HashSet<string> set = new HashSet<string>();
            bool claimed = false;
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i].ClaimedFlag == "是")
                {
                    claimed = true;
                }
                set.Add(UtilsBll.getClientNameNoHR( list[i].client));
            }
            if (set.Count > 1)
            {
                MessageBoxEx.Show("不同客户的团号不能一起认账!!!");
                return;
            }


            if (claimed && MessageBoxEx.Show("选中项中已经有认过账的团号，是否继续?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            if (FrmsManager.FormSetClaim == null)
            {
                FrmSetClaim frm = new FrmSetClaim(list, LoadDataToDataGridView, _curPage);
                frm.Show();
            }
            else
            {
                MessageBoxEx.Show("请不要重复打开设置认账界面!!!");
                return;
            }

        }

        private void cbSchTimeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSchTimeType.Text == "录入时间")
            {
                txtSchTimeFrom.CustomFormat = "yyyy/MM/dd HH:mm";
                txtSchTimeTo.CustomFormat = "yyyy/MM/dd HH:mm";
            }
            else
            {
                txtSchTimeFrom.CustomFormat = "yyyy/MM/dd";
                txtSchTimeTo.CustomFormat = "yyyy/MM/dd";
            }
        }

        private void 添加到设置请款费用列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = GetSelectedVisaList();
            if (list.Count < 0)
                return;
            if (FrmsManager.FormSetClaim != null)
            {
                FrmsManager.FormSetClaim.AddVisa(list);
                FrmsManager.FormSetClaim.Focus();
            }
            else
            {
                MessageBoxEx.Show("没有打开设置请款费用窗口!!!");
                return;
            }
        }

        private void lbShowCustomerBalance_Click(object sender, EventArgs e)
        {
            FrmCustomerBalance frm = new FrmCustomerBalance();
            frm.Show();
        }


    }
}
