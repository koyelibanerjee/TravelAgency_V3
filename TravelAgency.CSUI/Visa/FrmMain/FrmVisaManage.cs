using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.BLL;
using TravelAgency.Common;
using TravelAgency.Common.Excel;
using TravelAgency.Common.Word;
using TravelAgency.CSUI.FrmSub;
using TravelAgency.CSUI.Properties;
using TravelAgency.Model;
using ActionRecords = TravelAgency.BLL.ActionRecords;
using HasExported8Report = TravelAgency.BLL.HasExported8Report;
using Visa = TravelAgency.Model.Visa;
using VisaInfo = TravelAgency.Model.VisaInfo;

namespace TravelAgency.CSUI.FrmMain
{
    public partial class FrmVisaManage : Form
    {
        private readonly TravelAgency.BLL.Visa _bllVisa = new TravelAgency.BLL.Visa();
        private readonly TravelAgency.BLL.VisaInfo _bllVisaInfo = new TravelAgency.BLL.VisaInfo();
        private readonly TravelAgency.BLL.ActionRecords _bllActionRecords = new ActionRecords();
        private readonly BLL.VisaActTypeCountBll _visaActTypeCountBll = new VisaActTypeCountBll();
        private readonly TravelAgency.BLL.HasExported8Report _bllHasExported8Report = new HasExported8Report();
        private int _curPage = 1;
        private int _pageCount = 0;
        private int _pageSize = 50;
        private int _recordCount = 0;
        private bool _init = false;
        private string _where = string.Empty;
        private bool _forAddToGroup = false; //为没有添加团号的用户添加到团号的时候选择团号而设计
        private List<Model.VisaInfo> _listToAddToGroup;
        //private bool _hasFormated = false; //标志，用于防止重复触发rows_added事件(现在不用了，触发两次其实效率也没啥影响，并且如果只是第二次才进行操作的话会出问题)

        public FrmVisaManage()
        {
            InitializeComponent();
        }

        public FrmVisaManage(bool forAddToGroup, List<Model.VisaInfo> list)
        {
            _forAddToGroup = forAddToGroup;
            _listToAddToGroup = list;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "请选择需要添加到的团号";
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

            cbIsUrgent.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIsUrgent.Items.Add("全部");
            cbIsUrgent.Items.Add("是");
            cbIsUrgent.Items.Add("否");
            cbIsUrgent.SelectedIndex = 0;

            //国家选择框加入
            //cbCountry.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCountry.Items.Add("全部");
            foreach (string countryName in CountryCode.CountryNameArr)
            {
                cbCountry.Items.Add(countryName);
            }
            cbCountry.SelectedIndex = 0;

            cbState.Items.Add("全部");
            cbState.Items.Add("已做");
            cbState.Items.Add("未做");
            cbState.Items.Add("未做完");
            cbState.DropDownStyle = ComboBoxStyle.DropDownList;
            cbState.SelectedIndex = 0;

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
            dataGridView1.DefaultCellStyle.Font = new Font("微软雅黑", 9.0f, FontStyle.Bold);
            bgWorkerLoadData.WorkerReportsProgress = true;
            progressLoading.Visible = false;
            LoadDataToDgvAsyn();
            _init = true;
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
            List<int> selIdxs = new List<int>();
            for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; i--)
                selIdxs.Add(dataGridView1.SelectedRows[i].Index);

            var list = _bllVisa.GetListByPage(page, _pageSize, _where);

            //这里单独来区分已做和没做，很蛋疼，先这样解决，因为之前的where里面就是只用了visainfo的条件，现在得联合查询才行。
            if (cbState.Text == "未做") //删掉已做的
            {
                list = _bllActionRecords.CheckStatesAndRemove(list, Common.Enums.ActType._02TypeInData, 1); //
            }
            if (cbState.Text == "已做") //删掉未做的
            {
                list = _bllActionRecords.CheckStatesAndRemove(list, Common.Enums.ActType._02TypeInData, 4); //
            }
            if (cbState.Text == "未做完")
            {
                list = _bllActionRecords.CheckStatesAndRemove(list, Common.Enums.ActType._02TypeInData, 2); //
            }
            dataGridView1.DataSource = list;
            if (selIdxs.Count > 0) //如果之前有选中现在就恢复之前的
                dataGridView1.ClearSelection();
            if (dataGridView1.Rows.Count >= selIdxs.Count)
                foreach (var idx in selIdxs)
                    dataGridView1.Rows[idx].Selected = true;

            GlobalStat.UpdateStatistics();

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

            if (!string.IsNullOrEmpty(txtSchEntryTimeFrom.Text.Trim()) && !string.IsNullOrEmpty(txtSchEntryTimeTo.Text.Trim()))
            {
                conditions.Add(" (EntryTime between '" + txtSchEntryTimeFrom.Text + "' and " + " '" + txtSchEntryTimeTo.Text +
                               "') ");
            }

            if (cbIsUrgent.Text == "全部")
            {
            }
            else if (cbIsUrgent.Text == "是")
            {
                conditions.Add(" isurgent = 1 ");
            }
            else if (cbIsUrgent.Text == "否")
            {
                conditions.Add(" isurgent = 0 or isurgent is null ");
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


            string[] arr = conditions.ToArray();
            string where = string.Join(" and ", arr);
            return where;
        }

        private void btnClearSchConditions_Click(object sender, EventArgs e)
        {

            txtSchEntryTimeFrom.Text = string.Empty;
            txtSchEntryTimeTo.Text = string.Empty;
            txtSchGroupNo.Text = string.Empty;
            txtSalesPerson.Text = string.Empty;
            txtClient.Text = string.Empty;

            cbState.Text = "全部";
            cbDepatureType.Text = "全部";
            cbIsUrgent.Text = "全部";
            cbDisplayType.Text = "全部";
            cbCountry.Text = "全部";
        }


        private void btnShowToday_Click(object sender, EventArgs e)
        {

            var _modelYestodayLast = _bllVisa.GetLastRecordOfTheDay(DateTime.Now.AddDays(-1.0));
            var _modelTodayLast = _bllVisa.GetLastRecordOfTheDay(DateTime.Now);
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

        private void btnAddVisa_Click(object sender, EventArgs e)
        {
            FrmAddVisa frm = new FrmAddVisa(LoadDataToDataGridView, _curPage);
            frm.Show();
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
            Dictionary<Guid, int> dict = _visaActTypeCountBll.GetVisaActTypeCountDict(DgvDataSourceToList(),
                Common.Enums.ActType._02TypeInData);
            Font font = new Font(new FontFamily("Consolas"), 13.0f, FontStyle.Bold);
            int peopleCount = 0;
            int hasDo = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                if (dataGridView1.Rows[i].Cells["Country"].Value != null)
                {
                    string countryName = dataGridView1.Rows[i].Cells["Country"].Value.ToString();
                    dataGridView1.Rows[i].Cells["CountryImage"].Value =
                       TravelAgency.Common.CountryPicHandler.LoadImageByCountryName(countryName);
                }

                if (visas[i].Number == null || visas[i].Number == 0)
                {
                    dataGridView1.Rows[i].Cells["Status"].Value = "--------";
                    dataGridView1.Rows[i].Cells["Status"].Style.BackColor = Color.Peru;
                    continue;
                }

                if (visas[i].IsUrgent)
                {
                    dataGridView1.Rows[i].Cells["IsUrgent"].Value = "急件";
                    dataGridView1.Rows[i].Cells["IsUrgent"].Style.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[i].Cells["IsUrgent"].Value = "非急件";
                    //dataGridView1.Rows[i].Cells["Status"].Style.BackColor = Color.Red;
                }

                peopleCount += int.Parse(dataGridView1.Rows[i].Cells["Number"].Value.ToString());
                //下面这一部分用来查询状态，先不用，太卡了
                //var visas = dataGridView1.DataSource as List<Model.Visa>;
                //if (visas != null && _bllActionRecords.HasVisaBeenTypedIn(visas[i]))
                //{
                //    dataGridView1.Rows[i].Cells["Status"].Value = "已做";
                //    //dataGridView1.Rows[i].Cells["Status"].Style.BackColor = Color.DarkGreen;
                //}
                //else
                //{
                //    dataGridView1.Rows[i].Cells["Status"].Value = "未做";
                //    dataGridView1.Rows[i].Cells["Status"].Style.BackColor = Color.DarkOrange;
                //}

                //这一段性能会好一些了
                //int num = _bllActionRecords.GetVisaHasTypedInNum(visas[i].Visa_id);

                //2018-02-02 //换成一次查询，再来查hash表
                Guid visaid = Guid.Parse(dataGridView1.Rows[i].Cells["Visa_id"].Value.ToString());
                int num = 0;
                if (dict.ContainsKey(visaid))
                    num = dict[visaid];


                hasDo += num;
                dataGridView1.Rows[i].Cells["Status"].Style.Font = font;
                dataGridView1.Rows[i].Cells["Status"].Value = num + "/" + visas[i].Number;
                if (num >= visas[i].Number)
                    dataGridView1.Rows[i].Cells["Status"].Style.BackColor = Color.SeaGreen;
                else
                    dataGridView1.Rows[i].Cells["Status"].Style.BackColor = Color.Peru;
            }

            lbPeopleCount.Text = "已做:" + hasDo + "/" + peopleCount.ToString() + "人.";

            //_hasFormated = true;
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
                    if (!_forAddToGroup)
                    {
                        cmsDgv.Show(MousePosition.X, MousePosition.Y);
                    }
                    else
                    {
                        cmsAddToGroup.Show(MousePosition.X, MousePosition.Y);
                    }
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;
            if (this.dataGridView1.SelectedRows.Count > 1)
            {
                MessageBoxEx.Show(Resources.SelectShowMoreThanOne);
                return;
            }
            if (!_forAddToGroup)
            {
                Model.Visa model = _bllVisa.GetModel((Guid)dataGridView1.SelectedRows[0].Cells["Visa_id"].Value);
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
            else //添加用户的情况
            {
                //执行添加到此团号的逻辑
                AddToSelectGroup();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dataGridView1.Columns[e.ColumnIndex].Name == "IsUrgent")
            //{
            //    Color c = Color.Empty;
            //    //string state = e.Value.ToString();
            //    bool isUrgent = false;
            //    if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //        isUrgent = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "True";
            //    if (isUrgent)
            //    {
            //        c = Color.Red;
            //        //dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "加急";
            //    }

            //    else
            //    {
            //        c = Color.AntiqueWhite;
            //    }
            //    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = c;
            //}
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

        #region 日本报表

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 1)
            {
                MessageBoxEx.Show(Resources.SelectShowMoreThanOne);
                return;
            }


            //弹出选择机票模板窗口
            FrmSelAirInfo frm = new FrmSelAirInfo();
            if (DialogResult.Cancel == frm.ShowDialog())
                return;

            List<string> airinfoList = AirInfos.AirInfoDict[frm.SelIdx];


            //Model.Visa visaModel = _bllVisa.GetModel((Guid)dataGridView1.SelectedRows[0].Cells["Visa_id"].Value);
            Model.Visa visaModel = GetSelectedVisaModel();

            if (visaModel == null)
            {
                MessageBoxEx.Show(Resources.FindModelFailedPleaseCheckInfoCorrect);
                return;
            }



            var list = GetSelectedVisaInfoList();



            ExcelGenerator.GetYuanShenMuban(list, airinfoList);
        }
        private void 个签意见书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 1)
            {
                MessageBoxEx.Show(Resources.SelectShowMoreThanOne);
                return;
            }
            //Model.Visa visaModel = _bllVisa.GetModel((Guid)dataGridView1.SelectedRows[0].Cells["Visa_id"].Value);
            Model.Visa visaModel = GetSelectedVisaModel();

            if (visaModel == null)
            {
                MessageBoxEx.Show(Resources.FindModelFailedPleaseCheckInfoCorrect);
                return;
            }

            if (visaModel.Types == Common.Enums.Types.Team)
            {
                MessageBoxEx.Show("团签类型不能导出此报表!");
                return;
            }
            var list = GetSelectedVisaInfoList();
            ExcelGenerator.GetIndividualVisaExcel(list, visaModel.Remark, visaModel.GroupNo);
        }
        private void 日本团队综合名单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count < 1)
                return;
            List<Model.Visa> visaList = GetSelectedVisaList();
            List<List<Model.VisaInfo>> visaInfos = GetSelectedVisaInfoListList();
            //执行校验
            if (!ExcelGenerator.CheckGroupNoMatch(visaList) &&
                DialogResult.Cancel == MessageBoxEx.Show("团号不匹配，是否继续?", "提示", MessageBoxButtons.OKCancel))
                return;

            ExcelGenerator.GetTeamVisaExcelOfJapan(visaList, visaInfos);
        }
        private void 金桥大名单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var visainfoList = GetSelectedVisaInfoList();
            if (visainfoList.Count > 31)
            {
                MessageBoxEx.Show("超出模板人数限制(31人)");
                return;
            }
            List<string> list = new List<string>();
            for (int i = 0; i < visainfoList.Count; i++)
                list.Add(visainfoList[i].Name);
            GlobalUtils.DocDocxGenerator.SetDocType(DocDocxGenerator.DocType.Type01JinQiaoList);
            GlobalUtils.DocDocxGenerator.Generate(list);
        }

        private void 日本送签时间表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;
            List<Model.Visa> list = GetSelectedVisaList();
            ExcelGenerator.GetAllCountExcel(list);
        }

        private void 人报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var visainfos = GetSelectedVisaInfoList();
            //if (visainfos.Count > 8)
            //{
            //    MessageBoxEx.Show("超过8人数目限制!");
            //    return;
            //}
            XlsGenerator.GetGuolvJinGunMingDan(visainfos, _bllVisa.GetVisaListViaVisaInfoList(visainfos));
        }
        private void 外领担保函ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DocComGenerator docComGenerator = new DocComGenerator(DocComGenerator.DocType.Type02WaiLingDanBaohan);
            GlobalUtils.DocDocxGenerator.SetDocType(DocDocxGenerator.DocType.Type02WaiLingDanBaohan);
            var visainfos = GetSelectedVisaInfoList();
            if (visainfos.Count > 1)
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

        private void 机票报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetJiPiaoReport(DocDocxGenerator.DocType.Type03JiPiao);
        }

        private void 东阪川航ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetJiPiaoReport(DocDocxGenerator.DocType.Type03JiPiaoDBCH);
        }

        private void 东东川航ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetJiPiaoReport(DocDocxGenerator.DocType.Type03JiPiaoDDCH);

        }

        private void 东东国航ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetJiPiaoReport(DocDocxGenerator.DocType.Type03JiPiaoDDGH);

        }

        private void 东东全日空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetJiPiaoReport(DocDocxGenerator.DocType.Type03JiPiaoDDQRK);

        }

        private void 新北东航ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetJiPiaoReport(DocDocxGenerator.DocType.Type03JiPiaoXBDH);

        }
        private void 阪阪川航ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetJiPiaoReport(DocDocxGenerator.DocType.Type03JiPiaoBBCH);
        }
        /// <summary>
        /// 生成各种日本的机票
        /// </summary>
        /// <param name="type"></param>
        private void GetJiPiaoReport(DocDocxGenerator.DocType type)
        {
            GlobalUtils.DocDocxGenerator.SetDocType(type);
            var visaList = GetSelectedVisaList();
            var visainfos = GetSelectedVisaInfoList();
            if (visainfos.Count > 16)
            {
                MessageBoxEx.Show("超过16人数目限制!");
                return;
            }
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
                else list.Add(string.Empty);
            }
            //出境时间和入境时间

            list.Add(DateTimeFormator.DateTimeToString(visaList[0].InTime, DateTimeFormator.TimeFormat.Type09Jipiao));
            list.Add(DateTimeFormator.DateTimeToString(visaList[0].OutTime, DateTimeFormator.TimeFormat.Type09Jipiao));

            GlobalUtils.DocDocxGenerator.Generate(list);
        }



        private void 信息同意处理书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var visaList = GetSelectedVisaList();
            var visaInfoList = GetSelectedVisaInfoList();

            if (visaInfoList.Count > 37)
            {
                MessageBoxEx.Show("超出37人限制!");
                return;
            }
            GlobalUtils.DocDocxGenerator.SetDocType(DocDocxGenerator.DocType.Type08XXTYCLS);
            List<string> list = new List<string>();
            list.Add(visaList[0].EntryTime.Value.Date.Year.ToString());
            list.Add(visaList[0].EntryTime.Value.Date.Month.ToString());
            list.Add(visaList[0].EntryTime.Value.Date.Day.ToString());

            for (int i = 0; i != 37; ++i)
            {
                if (i < visaInfoList.Count)
                {
                    if (visaInfoList[i].Name.Length == 2)
                        list.Add(visaInfoList[i].Name + "  ");
                    else
                        list.Add(visaInfoList[i].Name);
                }
                else
                    list.Add(string.Empty);
            }

            GlobalUtils.DocDocxGenerator.Generate(list);
        }

        #endregion

        #region 泰国报表
        private void 数据源报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = GetSelectedVisaInfoList();

            XlsGenerator.GetThailandDataSource(list);

        }

        private void 泰签担保函ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalUtils.DocDocxGenerator.SetDocType(DocDocxGenerator.DocType.Type04TaiQianDanBao);
            var visaList = GetSelectedVisaList();
            //var visainfos = GetSelectedVisaInfoList();

            int peopleCount = 0;
            foreach (var visa in visaList)
            {
                peopleCount += (int)visa.Number;
            }

            //if (peopleCount > 4)
            //{
            //    MessageBoxEx.Show("超过占位符数目限制!");
            //    return;
            //}
            List<string> list = new List<string>();
            list.Add(peopleCount.ToString());

            //出境时间和入境时间

            list.Add(DateTimeFormator.DateTimeToString(visaList[0].InTime, DateTimeFormator.TimeFormat.Type01Normal));
            list.Add(DateTimeFormator.DateTimeToString(visaList[0].OutTime, DateTimeFormator.TimeFormat.Type01Normal));
            list.Add(DateTimeFormator.DateTimeToString(DateTime.Now, DateTimeFormator.TimeFormat.Type10Normal2));

            GlobalUtils.DocDocxGenerator.Generate(list);
        }

        private void GetThailandJiPiao(DocDocxGenerator.DocType type)
        {
            GlobalUtils.DocDocxGenerator.SetDocType(type);
            var visaList = GetSelectedVisaList();
            var visainfos = GetSelectedVisaInfoList();

            //int peopleCount = 0;
            //foreach (var visa in visaList)
            //{
            //    peopleCount += (int)visa.Number;
            //}

            //if (peopleCount > 4)
            //{
            //    MessageBoxEx.Show("超过占位符数目限制!");
            //    return;
            //}
            List<string> list = new List<string>();
            list.Add(DateTimeFormator.DateTimeToString(visaList[0].EntryTime, DateTimeFormator.TimeFormat.Type12Tailand3));

            //出境时间和入境时间

            list.Add(DateTimeFormator.DateTimeToString(visaList[0].InTime, DateTimeFormator.TimeFormat.Type13Tailand4));
            list.Add(DateTimeFormator.DateTimeToString(visaList[0].OutTime, DateTimeFormator.TimeFormat.Type13Tailand4));

            GlobalUtils.DocDocxGenerator.Generate2(list, visainfos);
        }
        private void 机票报表ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetThailandJiPiao(DocDocxGenerator.DocType.Type05TaiQianJiPiao);
        }



        private void 东航机票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetThailandJiPiao(DocDocxGenerator.DocType.Type05TaiQianJiPiao_DH);
        }

        private void 川航机票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetThailandJiPiao(DocDocxGenerator.DocType.Type05TaiQianJiPiao_CH);

        }

        private void 泰航机票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetThailandJiPiao(DocDocxGenerator.DocType.Type05TaiQianJiPiao_TH);
        }
        #endregion

        #region 韩国报表
        private void 韩国担保函ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var visaList = GetSelectedVisaList();
            var visaInfoList = GetSelectedVisaInfoList();
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

            DateTime date;
            if (visaList[0].DepartureType == "单次加急")
                date = visaList[0].EntryTime.Value.AddDays(3.0).Date;
            else
                date = visaList[0].EntryTime.Value.AddDays(10.0).Date;

            list.Add(date.Year.ToString());
            list.Add(date.Month.ToString());
            list.Add(date.Day.ToString());
            if (visaList[0].DepartureType == "五年多往" || visaList[0].DepartureType == "五年多往" ||
                visaList[0].DepartureType == "五年多次")
            {
                list.Add("五年多往");
            }
            else list.Add(string.Empty);
            for (int i = 0; i < 5; i++)
            {
                if (i >= visaInfoList.Count)
                    list.Add(string.Empty);
                else
                    list.Add(visaInfoList[i].Name);
            }

            list.Add(visaList[0].EntryTime.Value.Date.Year.ToString());
            list.Add(visaList[0].EntryTime.Value.Date.Month.ToString());
            list.Add(visaList[0].EntryTime.Value.Date.Day.ToString());
            GlobalUtils.DocDocxGenerator.Generate(list);

        }


        private void 韩国加急申请书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var visaList = GetSelectedVisaList();
            var visaInfoList = GetSelectedVisaInfoList();
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
            list.Add(visaList[0].EntryTime.Value.Date.Year.ToString());
            list.Add(visaList[0].EntryTime.Value.Date.Month.ToString());
            list.Add((visaList[0].EntryTime.Value.AddDays(3.0).Date.Day).ToString());

            list.Add(visaList[0].EntryTime.Value.Date.Year.ToString());
            list.Add(visaList[0].EntryTime.Value.Date.Month.ToString());
            list.Add(visaList[0].EntryTime.Value.Date.Day.ToString());
            GlobalUtils.DocDocxGenerator.Generate(list);
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

        /// <summary>
        /// 右键删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            var visaList = GetSelectedVisaList();
            for (int i = 0; i != visaList.Count; ++i)
            {
                if (!_bllVisa.DeleteVisaAndModifyVisaInfos(visaList[i]))
                    MessageBoxEx.Show("删除失败!");
                ++n;
            }
            GlobalUtils.MessageBoxWithRecordNum("删除", n, count);
            LoadDataToDataGridView(_curPage);
            UpdateState();
        }

        private void 添加到团号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddToSelectGroup();
        }

        private void AddToSelectGroup()
        {
            if (MessageBoxEx.Show("是否添加到选中团号?", "确认", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            //执行添加到团号的逻辑
            Model.Visa visaModel = GetSelectedVisaModel();

            for (int i = 0; i != _listToAddToGroup.Count; ++i)
            {
                _listToAddToGroup[i].Visa_id = visaModel.Visa_id.ToString();
                _listToAddToGroup[i].GroupNo = visaModel.GroupNo;
                _listToAddToGroup[i].Types = visaModel.Types;
                _listToAddToGroup[i].Client = visaModel.Client; //其他与当前团有关的信息也一起带过来
                _listToAddToGroup[i].Salesperson = visaModel.SalesPerson;
                _listToAddToGroup[i].Country = visaModel.Country;
                _listToAddToGroup[i].Position = visaModel.Number + i + 1;
            }



            //更新团号的人数
            if (visaModel.Number == null)
                visaModel.Number = _listToAddToGroup.Count;
            else visaModel.Number += _listToAddToGroup.Count;
            DialogResult res = DialogResult.No;
            if (visaModel.Types == Common.Enums.Types.Individual)
            {
                if ((res = MessageBoxEx.Show("是否自动更新团号名称?", "提示", MessageBoxButtons.YesNo))
                    == DialogResult.Yes)
                {
                    visaModel.GroupNo += "、";
                    for (int i = 0; i < _listToAddToGroup.Count; ++i)
                    {
                        visaModel.GroupNo += _listToAddToGroup[i].Name;
                        if (i == _listToAddToGroup.Count - 1)
                            break;
                        visaModel.GroupNo += "、";
                    }

                    for (int i = 0; i < _listToAddToGroup.Count; ++i)
                        _listToAddToGroup[i].GroupNo = visaModel.GroupNo;
                }
            }

            int n = _bllVisaInfo.UpdateByList(_listToAddToGroup);

            //添加操作记录,添加到已有团号
            for (int i = 0; i < _listToAddToGroup.Count; i++)
            {
                //Model.ActionRecords log = new Model.ActionRecords();
                //log.ActType = Common.Enums.ActType._01AddToExist; //操作记录为添加到已有团号
                //log.WorkId = Common.GlobalUtils.LoginUser.WorkId;
                //log.UserName = Common.GlobalUtils.LoginUser.UserName;
                //log.VisaInfo_id = _listToAddToGroup[i].VisaInfo_id;
                //log.Visa_id = visaModel.Visa_id;
                //log.Type = visaModel.Types;
                //log.EntryTime = DateTime.Now;
                //_bllActionRecords.Add(log);
                _bllActionRecords.AddRecord(Common.Enums.ActType._01AddToExist, Common.GlobalUtils.LoginUser,
                    _listToAddToGroup[i], visaModel);

            }

            GlobalUtils.MessageBoxWithRecordNum("更新", n, _listToAddToGroup.Count);

            //再把整个团的所有visainfo的团号名字变一下(主要是为了之前那些已经录入了的的团号跟着一起变)
            if (res == DialogResult.Yes)
                _bllVisaInfo.UpdateVisaInfosGroupNoByVisaModel(visaModel);

            if (!_bllVisa.Update(visaModel))
            {
                MessageBoxEx.Show("更新团号信息失败!");
                return;
            }
            //之后询问用户是否重新设置资料
            if (MessageBoxEx.Show("是否进入资料设置？", "提示", MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                if (visaModel.Types == Common.Enums.Types.Individual)
                {
                    FrmSetGroup frm = new FrmSetGroup(visaModel, this.LoadDataToDataGridView, _curPage);
                    //frm.ShowDialog();
                    frm.Show();
                }
                else if (visaModel.Types == Common.Enums.Types.Team)
                {
                    FrmSetTeamVisaGroup frm = new FrmSetTeamVisaGroup(visaModel, this.LoadDataToDataGridView, _curPage);
                    //frm.ShowDialog();
                    frm.Show();
                }
            }
            this.Close();
        }

        private void 打印报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count < 1)
                return;
            List<Model.VisaInfo> visaInfos = GetSelectedVisaInfoList();
            ExcelGenerator.GetPrintTable(visaInfos);
        }

        private void 修改选中类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 1)
            {
                MessageBoxEx.Show(Resources.SelectShowMoreThanOne);
                return;
            }
            Model.Visa visaModel = GetSelectedVisaModel();
            if (visaModel == null)
            {
                MessageBoxEx.Show(Resources.FindModelFailedPleaseCheckInfoCorrect);
                return;
            }
            FrmGroupOrIndividual frm = new FrmGroupOrIndividual(visaModel, LoadDataToDataGridView, _curPage);
            frm.ShowDialog();
        }

        private void 高拍仪做资料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = GetSelectedVisaInfoList();
            FrmScanCtrl frm = new FrmScanCtrl(list);
            frm.ShowDialog();
        }

        private void 修改做资料状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                return;
            }
            var list = GetSelectedVisaList();
            foreach (var visa in list)
            {
                if (visa.Country == "日本")
                {
                    MessageBoxEx.Show("日本不允许修改状态!");
                    return;
                }
            }

            //string status = dataGridView1.SelectedRows[0].Cells["Status"].Value.ToString();
            //int num1 = int.Parse(status.Split('/')[0]);
            //int num2 = int.Parse(status.Split('/')[1]);
            //if (num1 < num2)
            //{
            //    status = "未做";
            //}
            //else status = "已做";

            FrmSetTypeInStatus frm = new FrmSetTypeInStatus(list, LoadDataToDataGridView, _curPage);
            frm.ShowDialog();

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

        private void 两人保险报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = GetSelectedVisaInfoList();
            var groupname = GetSelectedVisaModel().GroupNo;
            XlsGenerator.GetBaoXianReport(list, groupname);

        }

        #endregion


    }
}
