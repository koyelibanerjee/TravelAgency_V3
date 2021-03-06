﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.BLL;
using TravelAgency.BLL.Excel;
using TravelAgency.BLL.Joint;
using TravelAgency.Common;
using TravelAgency.Common.Enums;
using TravelAgency.Common.FrmSetValues;
using TravelAgency.Common.QRCode;
using TravelAgency.Common.Word;
using TravelAgency.CSUI.Financial.FrmSub;
using TravelAgency.CSUI.FrmMain;
using TravelAgency.CSUI.FrmSub;
using TravelAgency.CSUI.Properties;
using TravelAgency.CSUI.Visa.FrmSub;
using TravelAgency.CSUI.Visa.FrmSub.FrmSetValue;
using TravelAgency.Model.Enums;
using FrmTimeSpanChoose = TravelAgency.CSUI.Visa.FrmSub.FrmSetValue.FrmTimeSpanChoose;
using VisaInfo = TravelAgency.Model.VisaInfo;

namespace TravelAgency.CSUI.Visa.FrmMain
{
    public partial class FrmVisaSubmitManage : Form
    {
        enum Inputmode
        {
            Single,
            Batch
        }

        private readonly TravelAgency.BLL.Visa _bllVisa = new TravelAgency.BLL.Visa();
        private readonly TravelAgency.BLL.VisaInfo _bllVisaInfo = new TravelAgency.BLL.VisaInfo();
        private readonly TravelAgency.BLL.ActionRecords _bllActionRecords = new ActionRecords();
        private readonly TravelAgency.BLL.VisaActTypeCountBll _visaActTypeCountBll = new VisaActTypeCountBll();

        private string _preTxt = string.Empty;
        private string _outState = OutState.Type02In; //Single模式下的状态设置
        private Inputmode _inputMode = Inputmode.Batch;
        private readonly MyQRCode _qrCode = new MyQRCode();

        private int _curPage = 1;
        private int _pageCount = 0;
        private int _pageSize = 50;
        private int _recordCount = 0;
        private bool _init = false;
        private string _where = string.Empty;
        private bool _forAddToGroup = false; //为没有添加团号的用户添加到团号的时候选择团号而设计
        private List<Model.VisaInfo> _listToAddToGroup;
        //private bool _hasFormated = false; //标志，用于防止重复触发rows_added事件(现在不用了，触发两次其实效率也没啥影响，并且如果只是第二次才进行操作的话会出问题)
        private List<Model.VisaInfo> _duplicateVisaInfos = new List<VisaInfo>();

        private DateTime? _finishTime = null;
        private DateTime? _realTime = null;

        public FrmVisaSubmitManage()
        {
            InitializeComponent();
        }

        public FrmVisaSubmitManage(bool forAddToGroup, List<Model.VisaInfo> list)
        {
            _forAddToGroup = forAddToGroup;
            _listToAddToGroup = list;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "请选择需要添加到的团号";
            InitializeComponent();
        }

        private void FrmVisaManage_Load(object sender, EventArgs e)
        {
            #region 送签部分初始化
            rbtnBatch.Select();
            txtInput.TextChanged += txtInput_TextChanged;
            //btnShowInQR.Click += BtnShowInQR_Click;
            //btnShowAbnormalOutQR.Click += BtnShowAbnormalOutQR_Click;
            //btnShowNormalOutQR.Click += BtnShowNormalOutQR_Click;
            btnClearInput.Click += BtnClearInput_Click;
            btnParseBatchInput.Click += BtnParseBatchInput_Click;

            rbtnSingle.CheckedChanged += RbtnSingle_CheckedChanged;
            rbtnBatch.CheckedChanged += RbtnBatch_CheckedChanged;

            cbSchTimeType.Items.Add("录入时间");
            cbSchTimeType.Items.Add("进签时间");
            cbSchTimeType.Items.Add("出签时间");
            cbSchTimeType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSchTimeType.SelectedIndex = 0;

            #endregion
            #region 窗体部分初始化
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

            //地区列表框初始化
            cbDistrict.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDistrict.Items.Add("全部");
            foreach (string dis in Model.Enums.District.DistrictList)
                cbDistrict.Items.Add(dis);
            cbDistrict.Text = District.key2Value(GlobalUtils.LoginUser.District.Value);
            if (GlobalUtils.LoginUser.District != 0)
            {
                cbCountry.Text = "日本";
                cbCountry.Enabled = false;
            }

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

            OtherDistrictInit();

            dataGridView1.AutoGenerateColumns = false; //不显示指定之外的列
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; //列宽自适应,一定不能用AllCells
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders; //这里也一定不能AllCell自适应!
            dataGridView1.Columns["GroupNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.DefaultCellStyle.Font = new Font("微软雅黑", 9.0f, FontStyle.Bold);
            bgWorkerLoadData.WorkerReportsProgress = true;
            progressLoading.Visible = false;
            LoadDataToDgvAsyn();

            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            _init = true;
            #endregion
        }

        private void OtherDistrictInit()
        {
            if (GlobalUtils.LoginUser.District != 0)
                Client.Visible = false;
        }

        #region 解析签证送签部分
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            dataGridView1_CellDoubleClick(null, null);
        }
        #region 按钮
        //private void BtnShowInQR_Click(object sender, EventArgs e)
        //{
        //    FrmQRCode frm = new FrmQRCode(OutStateString.Type02In);
        //    //frm.ShowDialog();
        //    frm.Show();
        //}

        //private void BtnShowAbnormalOutQR_Click(object sender, EventArgs e)
        //{
        //    FrmQRCode frm = new FrmQRCode(OutStateString.Type04AbnormalOut);
        //    //frm.ShowDialog();
        //    frm.Show();
        //}

        //private void BtnShowNormalOutQR_Click(object sender, EventArgs e)
        //{
        //    FrmQRCode frm = new FrmQRCode(OutStateString.Type03NormalOut);
        //    //frm.ShowDialog();
        //    frm.Show();
        //}


        private void BtnClearInput_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            txtInput.Focus();
        }

        private void BtnParseBatchInput_Click(object sender, EventArgs e)
        {
            string txt = txtInput.Text;
            if (txt == string.Empty
                )
            {
                MessageBoxEx.Show(Resources.InputNoStateInfo);
                return;
            }
            int count = UpdateByLines(txt, _inputMode);
            if (count > 0)
            {
                if (_finishTime != null && _realTime != null)
                    MessageBoxEx.Show("成功解析" + count / 2 + "条记录.");
                else
                    MessageBoxEx.Show("成功解析" + count + "条记录.");
            }
        }



        private void RbtnSingle_CheckedChanged(object sender, EventArgs e)
        {
            _inputMode = Inputmode.Single;
            btnParseBatchInput.Enabled = false;
            panelOutState.Enabled = true;
        }

        private void RbtnBatch_CheckedChanged(object sender, EventArgs e)
        {
            _inputMode = Inputmode.Batch;
            btnParseBatchInput.Enabled = true;
            panelOutState.Enabled = false;
        }

        #endregion

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            if (_inputMode == Inputmode.Single)
            {
                if ($"{_preTxt}\r\n" != txtInput.Text)
                {
                    _preTxt = txtInput.Text;
                    return;
                }
                _preTxt = txtInput.Text;
                UpdateByLines(txtInput.Text, _inputMode);
            }

            //Console.WriteLine(visainfoModel.EntryTime.ToString());
        }

        private int UpdateByLines(string txt, Inputmode inputMode)
        {

            if (_realTime == null && _finishTime == null)
            {
                MessageBoxEx.Show("请先设置进签及出签时间(可二者选一)!");
                return 0;
            }

            int count = 0; //成功记录数
            string str = txtInput.Text.TrimEnd(); //去掉最后的\r\n
            string[] lines = str.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            if (inputMode == Inputmode.Single)
            {
                VisaInfo model = GetModelByLine(lines[lines.Length - 1]);//取最后一行
                if (model == null)
                {
                    MessageBoxEx.Show(Resources.FindModelFailedPleaseCheckInfoCorrect);
                    return count;
                }
                if (_realTime != null)
                    if (!UpdateModelState(model, OutState.Type02In))
                        return 0;

                if (_finishTime != null)
                    if (!UpdateModelState(model, OutState.Type03NormalOut))
                        return 0;

                LoadDataToDataGridView(_curPage);
            }
            else if (inputMode == Inputmode.Batch)
            {
                for (int i = 0; i != lines.Length; ++i)
                {
                    VisaInfo model = GetModelByLine(lines[i]);
                    if (model == null)
                    {
                        MessageBoxEx.Show(Resources.FindModelFailedPleaseCheckInfoCorrect);
                        return count;
                    }

                    if (_realTime != null)
                        if (!UpdateModelState(model, OutState.Type02In))
                        {
                            if (
                                MessageBoxEx.Show("\"" + model.Name + "\"的状态更新失败，是否继续?", "提示", MessageBoxButtons.YesNo) ==
                                DialogResult.No)
                                return count;
                        }
                        else
                            ++count;

                    if (_finishTime != null)
                        if (!UpdateModelState(model, OutState.Type03NormalOut))
                        {
                            if (
                                MessageBoxEx.Show("\"" + model.Name + "\"的状态更新失败，是否继续?", "提示", MessageBoxButtons.YesNo) ==
                                DialogResult.No)
                                return count;
                        }
                        else
                            ++count;

                }
            }
            LoadDataToDataGridView(_curPage);
            return count;
        }


        private bool UpdateModelState(VisaInfo visainfoModel, string outState_)
        {
            //判断逻辑:
            //(1)每次更新的时候检查一个团里面是否全部进签或出签完成，是的话更新团的状态。
            //(2)检查是否团里面有人还没进签就出签了，报错
            //(3)检查


            if (string.IsNullOrEmpty(visainfoModel.Visa_id)) //没有加入团的签证不让送
            {
                MessageBoxEx.Show("没有加入团的签证不允许送签!");
                return false;
            }
            Model.Visa visaModel = null;
            visaModel = _bllVisa.GetModel(Guid.Parse(visainfoModel.Visa_id));
            if (visaModel == null)
            {
                MessageBoxEx.Show("指定签证没有找到所在团，请检查后再试!");
                return false;
            }


            visainfoModel.outState = outState_;
            string acttype;
            if (outState_ == OutState.Type02In)
            {
                visainfoModel.InTime = _realTime;
                acttype = ActType._05SubmitIn;
            }
            else if (outState_ == OutState.Type03NormalOut)
            {
                visainfoModel.OutTime = _finishTime;
                acttype = ActType._05SubmitOut;
            }
            //else if (outState_ == OutState.TYPE04AbnormalOut)
            //{
            //    visainfoModel.AbnormalOutTime = DateTime.Now;
            //    acttype = ActType._05SubmitAbOut;
            //}
            else
            {
                MessageBoxEx.Show(Resources.OutStateLengthEqualZero);
                return false;
            }

            //if (outState_ == OutState.TYPE04AbnormalOut ||
            //    outState_ == OutState.Type03NormalOut)
            //{
            //    //出签的情况下，先检查进签人数是否进签完成，否则报错
            //    if (_bllActionRecords.GetVisaSubmitStateNum(visaModel, ActType._05SubmitIn) < visaModel.Number)
            //    {
            //        MessageBoxEx.Show("所在团号中还有签证未进签，无法完成出签动作!");
            //        return false;
            //    }
            //}

            if (!_bllVisaInfo.Update(visainfoModel))
            {
                MessageBoxEx.Show(Resources.FailedUpdateVisaInfoState);
                return false;
            }

            //添加操作记录(后面考虑使用缓存结构，不用每次都查询数据库)
            _bllActionRecords.AddRecord(acttype, GlobalUtils.LoginUser, visainfoModel, visaModel);
            if (acttype == ActType._05SubmitIn) //检查团是否进签完成了
            {
                if (_bllActionRecords.GetVisaSubmitStateNum(visaModel, acttype) >= visaModel.Number) //全部进签了
                {
                    visaModel.RealTime = visainfoModel.InTime;

                    if (!_bllVisa.Update(visaModel))
                    {
                        MessageBoxEx.Show("更新团信息失败!");
                        return false;
                    }
                    //FrmSetSubmitTime frm = new FrmSetSubmitTime(visaModel);
                    //frm.ShowDialog();
                }
            }
            //出签
            if (acttype == ActType._05SubmitOut) //检查团是否进签完成了
            {
                if (_bllActionRecords.GetVisaSubmitStateNum(visaModel, acttype) >= visaModel.Number) //全部出签了
                {
                    visaModel.FinishTime = visainfoModel.OutTime;

                    if (!_bllVisa.Update(visaModel))
                    {
                        MessageBoxEx.Show("更新团信息失败!");
                        return false;
                    }
                }
            }
            return true;
        }

        private VisaInfo GetModelByLine(string line)
        {
            if (!line.Contains('|'))
            {
                MessageBoxEx.Show(Resources.LineNotContainDelimeter);
                return null;
            }

            Model.VisaInfo model;
            try
            {
                model = _bllVisaInfo.GetLatestModelByPassportNo(line.Split('|')[0]);
                return model;
            }
            catch (Exception)
            {
                MessageBoxEx.Show(Resources.LineNotContainDelimeter);
                return null;
            }
        }
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
            //Console.WriteLine("加载一次");
            _where = GetWhereCondition();
            var selRows = SelectionKeeper.GetSelectedGuids(dataGridView1, "Visa_id");
            int rowsCnt, rowIdx, colIdx;
            SelectionKeeper.GetSelectedPos(dataGridView1, out rowsCnt, out rowIdx, out colIdx);


            var list = _bllVisa.GetListByPage(page, _pageSize, _where);

            //这里单独来区分已做和没做，很蛋疼，先这样解决，因为之前的where里面就是只用了visainfo的条件，现在得联合查询才行。
            if (cbState.Text == "未做") //删掉已做的
            {
                list = _bllActionRecords.CheckStatesAndRemove(list, ActType._02TypeInData, 1); //
            }
            if (cbState.Text == "已做") //删掉未做的
            {
                list = _bllActionRecords.CheckStatesAndRemove(list, ActType._02TypeInData, 4); //
            }
            if (cbState.Text == "未做完")
            {
                list = _bllActionRecords.CheckStatesAndRemove(list, ActType._02TypeInData, 2); //
            }

            //_hasFormated = false; //每次加载后，设置为还没有格式化(设置其他的显示，比如未做已做的状态等)
            dataGridView1.DataSource = list;
            SelectionKeeper.RestoreSelection(selRows, dataGridView1, "Visa_id");
            SelectionKeeper.RestoreSelectedPos(dataGridView1, rowsCnt, rowIdx, colIdx);

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
            if (_recordCount == 0)
                lbPeopleCount.Text = "进签:0/0人,出签:0/0人.";
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
            SearchCondition.GetVisaTypesCondition(conditions, cbDisplayType.Text);
            SearchCondition.GetFuzzyQueryCondition(conditions, "GroupNo", txtSchGroupNo.Text);
            SearchCondition.GetFuzzyQueryCondition(conditions, "SalesPerson", txtSalesPerson.Text);
            SearchCondition.GetFuzzyQueryCondition(conditions, "Client", txtClient.Text);
            SearchCondition.GetFuzzyQueryCondition(conditions, "SubmitTempNo", txtTempNo.Text);
            SearchCondition.GetPreciseQueryCondition(conditions, "Country", cbCountry.Text, "全部");
            SearchCondition.GetPreciseQueryCondition(conditions, "DepartureType", cbDepatureType.Text, "全部");

            if (cbSchTimeType.Text == "录入时间")
                SearchCondition.GetSpanQueryCondition(conditions, "EntryTime", txtSchTimeFrom.Text, txtSchTimeTo.Text);
            else
            {
                string timeType;
                if (cbSchTimeType.Text == "进签时间")
                    timeType = "RealTime";
                else
                    timeType = "FinishTime";
                if (!string.IsNullOrEmpty(txtSchTimeFrom.Text) && !string.IsNullOrEmpty(txtSchTimeTo.Text))
                    SearchCondition.GetSpanQueryCondition(conditions, timeType, DateTime.Parse(txtSchTimeFrom.Text).Date.ToShortDateString() + " 00:00:00 ", DateTime.Parse(txtSchTimeTo.Text).Date.ToShortDateString() + " 23:59:59 ");
            }

            if (cbIsUrgent.Text == "全部")
            {
            }
            else if (cbIsUrgent.Text == "是")
                conditions.Add(" (isurgent = 1) ");
            else if (cbIsUrgent.Text == "否")
                conditions.Add(" (isurgent = 0 or isurgent is null) ");

            if (cbDistrict.Text != "全部")
                conditions.Add($" (district  = {District.value2Key(cbDistrict.Text)} or OutDeliveryPlace = '{cbDistrict.Text}') ");

            conditions.Add(" (ForRequestGroupNo = 0 or ForRequestGroupNo is null)");
            return SearchCondition.GetSearchConditon(conditions);
        }

        private void btnClearSchConditions_Click(object sender, EventArgs e)
        {
            txtSchTimeFrom.Text = string.Empty;
            txtSchTimeTo.Text = string.Empty;
            txtSchGroupNo.Text = string.Empty;
            txtSalesPerson.Text = string.Empty;
            txtClient.Text = string.Empty;
            txtTempNo.Text = string.Empty;
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
                txtSchTimeFrom.Text = DateTimeFormator.DateTimeToString(_modelYestodayLast.EntryTime.Value.AddMinutes(1.0), DateTimeFormator.TimeFormat.Type06LongTime);
            else
                txtSchTimeFrom.Text = DateTimeFormator.DateTimeToString(DateTime.Today) + " 00:00";
            if (_modelTodayLast != null)
                txtSchTimeTo.Text = DateTimeFormator.DateTimeToString(_modelTodayLast.EntryTime.Value.AddMinutes(1.0), DateTimeFormator.TimeFormat.Type06LongTime);
            else
                txtSchTimeTo.Text = DateTimeFormator.DateTimeToString(DateTime.Today) + " 16:00";

            btnSearch_Click(null, null);
        }

        private void btnAddVisa_Click(object sender, EventArgs e)
        {
            FrmAddVisa frm = new FrmAddVisa(LoadDataToDataGridView, _curPage);
            frm.Show();
        }

        private void btnGetTodayExcel_Click(object sender, EventArgs e)
        {
            FrmTimeSpanChoose frmSpanChooseWithVisaRecord = new FrmTimeSpanChoose();
            if (frmSpanChooseWithVisaRecord.ShowDialog() == DialogResult.Cancel)
                return;
            DateTime from = frmSpanChooseWithVisaRecord.TimeSpanFrom;
            DateTime to = frmSpanChooseWithVisaRecord.TimeSpanTo;

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
            visaList = _bllActionRecords.CheckStatesAndRemove(visaList, ActType._02TypeInData, 4); //只保留已经做完了的

            //这里确认一下
            if (visaList.Count <= 0)
            {
                MessageBoxEx.Show("所选时间段没有报表需要生成!");
                return;
            }

            //按照出境类型(按照Excel报表中来)，人数排序(从小到大)
            visaList.Sort((model1, model2) =>
            {
                if (!Model.Enums.DepartureType.Dict.ContainsKey(model1.DepartureType))
                    return 1;

                if (!Model.Enums.DepartureType.Dict.ContainsKey(model2.DepartureType))
                    return -1;

                if (Model.Enums.DepartureType.Dict[model1.DepartureType] < Model.Enums.DepartureType.Dict[model2.DepartureType])
                    return -1;
                else if (Model.Enums.DepartureType.Dict[model1.DepartureType] ==
                         Model.Enums.DepartureType.Dict[model2.DepartureType])
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
                    if (list[j].outState == OutState.Type01Delay)
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


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
                return;
            var visaModel = GetSelectedVisaModel();
            var list = _bllVisaInfo.GetModelListByVisaIdOrderByPosition(visaModel.Visa_id);
            FrmVisaInfoSubmitDetails frm = new FrmVisaInfoSubmitDetails(list, LoadDataToDataGridView, _curPage);
            frm.Show();
        }
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
            BLL.Joint.Visa_QZApplication bllVisaQzApplication = new Visa_QZApplication();
            Font font = new Font(new FontFamily("Consolas"), 13.0f, FontStyle.Bold);
            int peopleCount = 0;
            int hasIn = 0;
            int hasOut = 0;
            var dictIn = _visaActTypeCountBll.GetVisaOutStateCountDict(visas, OutState.Type02In);
            var dictOut = _visaActTypeCountBll.GetVisaOutStateCountDict(visas, OutState.Type03NormalOut);
            var dictAbOut = _visaActTypeCountBll.GetVisaOutStateCountDict(visas, OutState.Type04AbnormalOut);
            var dictSnded = _visaActTypeCountBll.GetVisaOutStateCountDict(visas, OutState.Type10Exported);
            var hasSendRequestPayout = bllVisaQzApplication.CheckVisaSendPayoutRequest(visas);
            Color defaultColor = StyleControler.CellDefaultBackColor;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();

                //没有进行请款的设置为红色背景色
                if (hasSendRequestPayout.Contains(dataGridView1.Rows[i].Cells["visa_id"].Value.ToString()))
                {
                    dataGridView1.Rows[i].Cells["Country"].Style.BackColor = defaultColor;
                }
                else
                {
                    dataGridView1.Rows[i].Cells["Country"].Style.BackColor = Color.Red;

                }

                if (dataGridView1.Rows[i].Cells["Country"].Value != null)
                {
                    string countryName = dataGridView1.Rows[i].Cells["Country"].Value.ToString();
                    dataGridView1.Rows[i].Cells["CountryImage"].Value =
                       TravelAgency.Common.CountryPicHandler.LoadImageByCountryName(countryName);
                }
                if (visas[i].IsUrgent ?? false)
                {
                    dataGridView1.Rows[i].Cells["IsUrgent"].Value = "急件";
                    dataGridView1.Rows[i].Cells["IsUrgent"].Style.BackColor = Color.Red;
                }
                else
                    dataGridView1.Rows[i].Cells["IsUrgent"].Value = "非急件";

                if (dataGridView1.Rows[i].Cells["Number"].Value != null)
                    peopleCount += int.Parse(dataGridView1.Rows[i].Cells["Number"].Value.ToString());


                ////这一段性能会好一些了
                //int numIn = _bllActionRecords.GetVisaSubmitStateNum(visas[i], ActType._05SubmitIn);
                Guid visaid = Guid.Parse(dataGridView1.Rows[i].Cells["Visa_id"].Value.ToString());
                int numIn = 0;
                if (!dictIn.ContainsKey(visaid) || !dictOut.ContainsKey(visaid) || !dictAbOut.ContainsKey(visaid))
                    continue;

                numIn += dictIn[visaid];
                numIn += dictOut[visaid]; //进签的还要加上出签的人数
                numIn += dictAbOut[visaid];
                numIn += dictSnded[visaid];
                hasIn += numIn;

                dataGridView1.Rows[i].Cells["SubmitInStatus"].Style.Font = font;
                dataGridView1.Rows[i].Cells["SubmitInStatus"].Value = numIn + "/" + visas[i].Number;

                //这一段性能会好一些了
                //int numOut = _bllActionRecords.GetVisaSubmitStateNum(visas[i], ActType._05SubmitOut);
                int numOut = dictOut[visaid];
                numOut += dictSnded[visaid];
                hasOut += numOut;
                int abOutNum = dictAbOut[visaid];

                if (numIn >= visas[i].Number)
                    dataGridView1.Rows[i].Cells["SubmitInStatus"].Style.BackColor = Color.SeaGreen;
                else
                    dataGridView1.Rows[i].Cells["SubmitInStatus"].Style.BackColor = Color.Peru;

                if (abOutNum > 0)
                {
                    Font font1 = new Font(new FontFamily("微软雅黑"), 10.0f);
                    dataGridView1.Rows[i].Cells["SubmitOutStatus"].Style.Font = font1;
                    dataGridView1.Rows[i].Cells["SubmitOutStatus"].Style.BackColor = Color.Red;
                    dataGridView1.Rows[i].Cells["SubmitOutStatus"].Value = "异常出签";
                    continue;
                }

                dataGridView1.Rows[i].Cells["SubmitOutStatus"].Style.Font = font;
                dataGridView1.Rows[i].Cells["SubmitOutStatus"].Value = numOut + "/" + visas[i].Number;

                if (numOut >= visas[i].Number)
                    dataGridView1.Rows[i].Cells["SubmitOutStatus"].Style.BackColor = Color.SeaGreen;
                else
                    dataGridView1.Rows[i].Cells["SubmitOutStatus"].Style.BackColor = Color.Peru;
            }

            lbPeopleCount.Text = "进签:" + hasIn + "/" + peopleCount.ToString() + ",出签:" + hasOut + "/" + peopleCount.ToString();

            new Thread(CheckDuplicate) { IsBackground = true }.Start();

            //_hasFormated = true;
        }

        private void CheckDuplicate()
        {
            lock ("abc")
            {
                Dictionary<string, bool> addedMap = new Dictionary<string, bool>();
                Dictionary<string, Model.VisaInfo> nameModelMap = new Dictionary<string, Model.VisaInfo>();
                StringBuilder sb = new StringBuilder();

                _duplicateVisaInfos.Clear();

                var visaList = DgvDataSourceToList();
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    var visainfoList =
                        _bllVisaInfo.GetModelListByVisaIdOrderByPosition(visaList[i].Visa_id);
                    foreach (var visaInfo in visainfoList)
                    {
                        if (nameModelMap.ContainsKey(visaInfo.Name))
                        {
                            if (addedMap[visaInfo.Name] == false)
                                _duplicateVisaInfos.Add(nameModelMap[visaInfo.Name]);
                            _duplicateVisaInfos.Add(visaInfo);
                            addedMap[visaInfo.Name] = true;
                        }
                        else
                        {
                            nameModelMap.Add(visaInfo.Name, visaInfo);
                            addedMap.Add(visaInfo.Name, false);
                        }
                    }
                }
                if (_duplicateVisaInfos.Count > 0)
                {
                    lbDuplicate.Text = "发现重复";
                    lbDuplicate.ForeColor = Color.OrangeRed;
                }
                else
                {
                    lbDuplicate.ForeColor = Color.ForestGreen;
                    lbDuplicate.Text = "无重复";
                }
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
            //if (dataGridView1.SelectedRows.Count < 1)
            //    return;
            //if (this.dataGridView1.SelectedRows.Count > 1)
            //{
            //    MessageBoxEx.Show(Resources.SelectShowMoreThanOne);
            //    return;
            //}
            //if (!_forAddToGroup)
            //{
            //    Model.Visa model = _bllVisa.GetModel((Guid)dataGridView1.SelectedRows[0].Cells["Visa_id"].Value);
            //    if (model == null)
            //    {
            //        MessageBoxEx.Show(Resources.FindModelFailedPleaseCheckInfoCorrect);
            //        return;
            //    }

            //    if (model.Types == Common.Enums.Types.Individual || model.Types == Common.Enums.Types.Team2Individual)
            //    {
            //        FrmSetGroup frm = new FrmSetGroup(model, LoadDataToDataGridView, _curPage);
            //        //frm.ShowDialog();
            //        frm.Show();
            //    }
            //    else if (model.Types == Common.Enums.Types.Team)
            //    {
            //        FrmSetTeamVisaGroup frm = new FrmSetTeamVisaGroup(model, LoadDataToDataGridView, _curPage);
            //        //frm.ShowDialog();
            //        frm.Show();
            //    }
            //}
            //else //添加用户的情况
            //{
            //    //执行添加到此团号的逻辑
            //    AddToSelectGroup();
            //}
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

        /// <summary>
        /// 右键删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                _listToAddToGroup[i].Client = visaModel.client; //其他与当前团有关的信息也一起带过来
                _listToAddToGroup[i].Salesperson = visaModel.SalesPerson;
                _listToAddToGroup[i].Country = visaModel.Country;
                _listToAddToGroup[i].Position = visaModel.Number + i + 1;
            }



            //更新团号的人数
            if (visaModel.Number == null)
                visaModel.Number = _listToAddToGroup.Count;
            else visaModel.Number += _listToAddToGroup.Count;
            DialogResult res = DialogResult.No;
            if (visaModel.Types == Model.Enums.Types.Individual)
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
                _bllActionRecords.AddRecord(ActType._01AddToExist, Common.GlobalUtils.LoginUser,
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
                if (visaModel.Types == Model.Enums.Types.Individual)
                {
                    FrmSetGroup frm = new FrmSetGroup(visaModel, this.LoadDataToDataGridView, _curPage);
                    //frm.ShowDialog();
                    frm.Show();
                }
                else if (visaModel.Types == Model.Enums.Types.Team)
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



        private void 修改做资料状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count != 1)
            //{
            //    return;
            //}
            //var model = GetSelectedVisaModel();
            //if (model.Country == "日本")
            //{
            //    MessageBoxEx.Show("日本不允许修改状态!");
            //    return;
            //}

            //string status = dataGridView1.SelectedRows[0].Cells["Status"].Value.ToString();
            //int num1 = int.Parse(status.Split('/')[0]);
            //int num2 = int.Parse(status.Split('/')[1]);
            //if (num1 < num2)
            //{
            //    status = "未做";
            //}
            //else status = "已做";

            //FrmSetTypeInStatus frm = new FrmSetTypeInStatus(model, status, LoadDataToDataGridView, _curPage);
            //frm.ShowDialog();

        }

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
        #endregion


        private void 复制二维码信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = GetSelectedVisaInfoList();
            if (list.Count < 1)
                return;
            StringBuilder sb = new StringBuilder();
            foreach (var visaInfo in list)
            {
                sb.Append(MyQRCode.GenQrInfo(visaInfo) + "\r\n");
            }
            Clipboard.SetText(sb.ToString());
        }


        #endregion

        private void 更改送签状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = GetSelectedVisaList();
            FrmSetSubmitStatus frm = new FrmSetSubmitStatus(
   list, LoadDataToDataGridView, _curPage);
            frm.ShowDialog();
        }

        private void btnSetSubmitTime_Click(object sender, EventArgs e)
        {
            FrmSetSubmitTime frm = new FrmSetSubmitTime();
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;
            _finishTime = frm.RetFinishTime;
            _realTime = frm.RetRealTime;

            lbRealTime.Text = "送签时间: " + DateTimeFormator.DateTimeToString(_realTime);
            lbFinishTime.Text = "出签时间: " + DateTimeFormator.DateTimeToString(_finishTime);
        }

        private void 修改进出签时间ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var list = GetSelectedVisaList();
            if (list.Count == 0)
                return;

            bool modelHasValue = false;
            foreach (var visa in list)
            {
                if (visa.RealTime != null && visa.FinishTime != null)
                {
                    modelHasValue = true;
                    break;
                }
            }


            if (modelHasValue && 
                GlobalUtils.LoginUserLevel != RigthLevel.Manager)
            {
                MessageBoxEx.Show("权限不足!!!");
                return;
            }


            if (GlobalUtils.LoginUserLevel != RigthLevel.Manager)
            {
                foreach (var visa in list)
                {
                    if (visa.RealTime != null || visa.FinishTime != null)
                    {
                        MessageBoxEx.Show($"团号:{visa.GroupNo}进出签时间不为空，需管理员才能重新设置!");
                        return;
                    }
                }
            }

            FrmSetSubmitTime frm = new FrmSetSubmitTime(list[0].RealTime.ToString(),
                list[0].FinishTime.ToString());
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;


            List<VisaInfo> visainfoList = new List<VisaInfo>();
            foreach (var visa in list)
            {
                visa.RealTime = frm.RetRealTime;
                visa.FinishTime = frm.RetFinishTime;

                var tmpList = _bllVisaInfo.GetModelListByVisaIdOrderByPosition(visa.Visa_id);
                foreach (var visainfo in tmpList)
                {
                    visainfo.InTime = visa.RealTime;
                    visainfo.OutTime = visa.FinishTime;
                    if (visainfo.OutTime != null)
                        visainfo.outState = OutState.Type03NormalOut;
                    else if (visainfo.InTime != null)
                        visainfo.outState = OutState.Type02In;
                    if (visa.InTime != null)
                        _bllActionRecords.AddRecord(ActType._05SubmitIn, GlobalUtils.LoginUser, visainfo, visa);
                    if (visa.OutTime != null)
                        _bllActionRecords.AddRecord(ActType._05SubmitOut, GlobalUtils.LoginUser, visainfo, visa);
                }
                visainfoList.AddRange(tmpList);
            }

            _bllVisa.UpdateList(list);
            _bllVisaInfo.UpdateByList(visainfoList);

            LoadDataToDgvAsyn();
        }

        private void 导出日本每日送签报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //这里干脆就不判断entrytime了，直接找记录算了
            var visaList = GetSelectedVisaList();

            //这里确认一下
            if (visaList.Count <= 0)
            {
                MessageBoxEx.Show("所选时间段没有报表需要生成!");
                return;
            }

            //按照出境类型(按照Excel报表中来)，人数排序(从小到大)
            visaList.Sort((model1, model2) =>
            {
                if (model1.DepartureType == null && model2.DepartureType != null)
                    return 1;

                if (model2.DepartureType == null && model1.DepartureType != null)
                    return -1;

                if (model2.DepartureType == null && model1.DepartureType == null)
                    return -1;

                if (!Model.Enums.DepartureType.Dict.ContainsKey(model1.DepartureType))
                    return 1;

                if (!Model.Enums.DepartureType.Dict.ContainsKey(model2.DepartureType))
                    return -1;

                if (Model.Enums.DepartureType.Dict[model1.DepartureType] < Model.Enums.DepartureType.Dict[model2.DepartureType])
                    return -1;
                else if (Model.Enums.DepartureType.Dict[model1.DepartureType] ==
                         Model.Enums.DepartureType.Dict[model2.DepartureType])
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
                    if (list[j].outState == OutState.Type01Delay)
                    {
                        list.Remove(list[j]);
                    }
                }
                if (list.Count != 0)
                    visaInfoList.Insert(0, list);
                else
                    visaList.Remove(visaList[i]); //如果这个团所有人都被移出去了，那么就直接把这个团也删除掉
            }

            FrmTodaySubmit frm = new FrmTodaySubmit(visaList, visaInfoList);
            //frm.From = ;
            //frm.To = to;
            frm.Show();
        }

        private void 导出日本送签时间表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;
            List<Model.Visa> list = GetSelectedVisaList();
            ExcelGenerator.GetAllCountExcel(list);
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

        private void 设置销售客户备注ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = GetSelectedVisaList();
            if (list.Count > 1)
            {
                MessageBoxEx.Show("请选择一条记录进行操作!");
                return;
            }

            FrmSetMultiStringValue frm = new FrmSetMultiStringValue("设置", list[0].client, list[0].SalesPerson,
                list[0].Operator, list[0].Tips2);
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;

            foreach (var visa in list)
            {
                visa.SalesPerson = frm.RetSalesPerson;
                visa.client = frm.RetClient;
                visa.Tips2 = frm.RetTips2;
                visa.Operator = frm.RetOperator;
            }
            _bllVisa.UpdateList(list);
            LoadDataToDgvAsyn();
        }

        private void lbDuplicate_Click(object sender, EventArgs e)
        {
            if (_duplicateVisaInfos.Count > 0)
            {
                FrmShowVisaInfos frm = new FrmShowVisaInfos(_duplicateVisaInfos);
                frm.Show();
            }
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
                set.Add(list[i].client);
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

        private void 和Excel进行对比ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = GlobalUtils.ShowOpenFileDlg("Excel文件|*.xls;*.xlsx");
            if (string.IsNullOrEmpty(filename))
                return;

            List<string> excelList = ExcelParser.ParseExcelGetGroupNos(filename);
            List<string> dgvList = new List<string>();

            var list = GetSelectedVisaList();
            for (int i = 0; i < list.Count; i++)
                dgvList.Add(list[i].GroupNo);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (var item in excelList)
                dict.Add(item, 1);
            foreach (var item in dgvList)
            {
                if (dict.ContainsKey(item))
                    ++dict[item];
                else
                    dict.Add(item, 1);
            }
            ExcelGenerator.GetCompareTable(excelList, dgvList, dict);
        }

        private void 设置流水编号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = GetSelectedVisaList();
            if (list == null || list.Count < 1)
                return;

            FrmSetStringValue frm = new FrmSetStringValue("设置流水编号", DateTime.Now.ToString("yyyyMMddHHmmss"));
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;

            foreach (var visa in list)
                visa.SubmitTempNo = frm.RetValue;
            int n = _bllVisa.UpdateList(list);
            GlobalUtils.MessageBoxWithRecordNum("更新", n, list.Count);
            LoadDataToDgvAsyn();
        }
    }
}
