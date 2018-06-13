using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using TravelAgency.Common;
using TravelAgency.Common.Enums;
using TravelAgency.Common.Excel;
using TravelAgency.CSUI.FrmSetValue;
using TravelAgency.CSUI.Properties;
using TravelAgency.Model;

namespace TravelAgency.CSUI.FrmSub
{
    /// <summary>
    /// 总的来说，两套逻辑，一套是从签证管理界面进来，选中那些还没设置过团号的人，然后设置团号
    /// 第二套是从团号管理界面进入，可以从当前团移出人以及删除团，以及修改团的信息
    /// 
    /// </summary>
    public partial class FrmSetGroup : Form
    {
        private List<Model.VisaInfo> _list; //保存所有传进来的visainfo
        private List<Model.VisaInfo> _dgvList = new List<VisaInfo>(); //保存所有进入dgv的visainfo
        private Model.Visa _visaModel;
        private readonly bool _initFromVisaModel;

        private readonly BLL.VisaInfo _bllVisaInfo = new BLL.VisaInfo();
        private readonly BLL.Visa _bllVisa = new BLL.Visa();
        private readonly TravelAgency.BLL.ActionRecords _bllLoger = new TravelAgency.BLL.ActionRecords();
        private readonly TravelAgency.BLL.JobAssignment _bllJobAssignment = new TravelAgency.BLL.JobAssignment();
        private readonly TravelAgency.BLL.WorkerQueue _bllWorkerQueue = new TravelAgency.BLL.WorkerQueue();

        private string _visaName = string.Empty;
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托
        private readonly int _curPage; //主界面更新数据库需要一个当前页
        private Model.Visa _recentVisa;
        private readonly string _type; //团做个还是个签

        private List<Model.VisaInfo> _visainfoListBackUp;
        private bool _inited = false;


        public FrmSetGroup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 从已有list初始化窗口(还未设置团号)
        /// </summary>
        /// <param name="list"></param>
        /// <param name="updateDel"></param>
        /// <param name="curpage"></param>
        public FrmSetGroup(List<Model.VisaInfo> list, Action<int> updateDel, int curpage, string types)
            : this()
        {
            _list = list;
            _initFromVisaModel = false;
            _updateDel = updateDel;
            _curPage = curpage;
            _type = types;
        }

        /// <summary>
        /// 从已有visaModel设置窗口(已经设置了团号)
        /// </summary>
        /// <param name="model"></param>
        /// <param name="updateDel"></param>
        /// <param name="curpage"></param>
        public FrmSetGroup(Model.Visa model, Action<int> updateDel, int curpage)
            : this()
        {
            _visaModel = model;
            _initFromVisaModel = true;
            _updateDel = updateDel;
            _curPage = curpage;
            _type = model.Types;
        }

        private void FrmSetGroup_Load(object sender, EventArgs e)
        {
            InitCtrls();

            ////设置操作员
            //txtTypeInPerson.Text = Common.GlobalUtils.LoginUser.UserName;
            //txtTypeInPerson.Enabled = false;
            //设置国家默认值
            //cbCountry.Text = "日本"; //这个默认值应该只是在还没设置的时候默认日本

            if (_list != null && _visaModel == null && !_initFromVisaModel)
                InitFrmFromList();
            if (_list == null && _visaModel != null && _initFromVisaModel)
                InitFrmFromVisaModel();

            UpdateLabels();
            SetCountryPicBox();
            _inited = true;
        }

        private void InitCtrls()
        {
            //设置最小尺寸
            this.MinimumSize = this.Size;

            this.btnReset.Enabled = false; //直接禁用这个功能目前

            InitDgv();

            //设置列表多选
            lvIn.MultiSelect = true;
            lvOut.MultiSelect = true;

            InitComboBoxs();

            //事件绑定
            txtInTime.TextChanged += txtInTime_TextChanged;
            txtDepartureTime.TextChanged += txtDepartureTime_TextChanged;
            txtOutTime.TextChanged += txtOutTime_TextChanged;
            txtSubmitTime.TextChanged += txtSubmitTime_TextChanged;
        }

        private void InitComboBoxs()
        {
            //var list = BLL.CommonBll.GetFieldList("CustomerInfo", "CustomerName");

            //if (GlobalUtils.LoginUserLevel == RigthLevel.Manager)
            //{
            //    txtClient.DropDownStyle = ComboBoxStyle.DropDown;
            //    txtSalesPerson.DropDownStyle = ComboBoxStyle.DropDown;
            //    txtOperator.DropDownStyle = ComboBoxStyle.DropDown;
            //}
            //else
            //{
            //    txtClient.DropDownStyle = ComboBoxStyle.DropDownList;
            //    txtSalesPerson.DropDownStyle = ComboBoxStyle.DropDownList;
            //    txtOperator.DropDownStyle = ComboBoxStyle.DropDownList;
            //}

            txtClient.DropDownStyle = ComboBoxStyle.DropDown;
            txtSalesPerson.DropDownStyle = ComboBoxStyle.DropDown;
            txtOperator.DropDownStyle = ComboBoxStyle.DropDown;

            var list = BLL.CustomerInfo.GetCustomerList();
            if (list != null && list.Count > 0)
                foreach (var item in list)
                {
                    var cbitem = new ComboBoxItem();
                    cbitem.Text = item.Value; //name
                    cbitem.Tag = item.Key; //id
                    txtClient.Items.Add(cbitem);
                }

            chkSaleFirst.Checked = false;

            //txtClient.SelectedIndex = 0;
            //txtClient.SelectedIndexChanged += TxtClient_SelChangeGetSalesPerson;
            txtClient.SelectedIndexChanged += TxtClient_SelChangeGetOperator;
            txtClient.SelectedIndexChanged += TxtClient_SelChangeGetSalesPerson;
            //初始化comboBox的成员
            //出境类型
            txtDepartureType.Items.Add("单次");
            txtDepartureType.Items.Add("单次30");
            txtDepartureType.Items.Add("冲绳单次");
            txtDepartureType.Items.Add("冲绳三年");
            txtDepartureType.Items.Add("东北1单次");
            txtDepartureType.Items.Add("东北1三年");
            txtDepartureType.Items.Add("东北2A三年");
            txtDepartureType.Items.Add("东北2B三年");
            txtDepartureType.Items.Add("东北2C三年");
            txtDepartureType.Items.Add("东北2D三年");
            txtDepartureType.Items.Add("普通三年");
            txtDepartureType.Items.Add("五年多次");
            txtDepartureType.Items.Add("香港");
            txtDepartureType.SelectedIndex = 0;

            //txtDepartureType.Items.Add("其他");
            //外领送签条件
            txtSubmitCondition.Items.Add("暂住证");
            txtSubmitCondition.Items.Add("居住证明");
            txtSubmitCondition.Items.Add("结婚证");
            txtSubmitCondition.Items.Add("身份证");
            txtSubmitCondition.Items.Add("户口本");
            txtSubmitCondition.Items.Add("其他");
            //客人取签方式
            txtFetchType.Items.Add("回签证部");
            txtFetchType.Items.Add("快递");
            txtFetchType.Items.Add("机场自提");
            txtFetchType.Items.Add("重庆自取");
            txtFetchType.Items.Add("车托到五桂桥");
            txtFetchType.Items.Add("其他");
            txtFetchType.SelectedIndex = 0;
            //送签社担当
            txtPerson.Items.Add("成都金桥");
            txtPerson.Items.Add("四川国旅");
            txtPerson.Items.Add("省中旅");
            txtPerson.Items.Add("北京送签");
            txtPerson.Items.Add("上海送签");
            txtPerson.Text = "";

            //国家选择框加入
            foreach (string countryName in CountryCode.CountryNameArr)
            {
                cbCountry.Items.Add(countryName);
            }
            cbCountry.DropDownStyle = ComboBoxStyle.DropDown;


            txtPeiQianYuan.DropDownStyle = ComboBoxStyle.DropDown;
            txtQuQianYuan.DropDownStyle = ComboBoxStyle.DropDown;

            var list1 = BLL.CommonBll.GetFieldList("Visa", "PeiQianYuan");
            if (list1 != null && list1.Count > 0)
                foreach (var item in list1)
                {
                    txtPeiQianYuan.Items.Add(item);
                }
            list1 = BLL.CommonBll.GetFieldList("Visa", "QuQianYuan");
            if (list1 != null && list1.Count > 0)
                foreach (var item in list1)
                {
                    txtQuQianYuan.Items.Add(item);
                }
        }

        private void TxtClient_SelChangeGetSalesPerson(object sender, EventArgs e)
        {
            if (txtClient.Text == "")
                return;

            if (_inited)
                txtSalesPerson.Text = "";
            txtSalesPerson.Items.Clear();
            var comboBoxItem = txtClient.SelectedItem as ComboBoxItem;
            if (comboBoxItem != null)
            {
                var list = BLL.CustomerInfo.GetSalesPersonByCustId(comboBoxItem.Tag.ToString());
                if (list != null && list.Count > 0)
                    foreach (var item in list)
                        txtSalesPerson.Items.Add(item);
            }
        }

        private void TxtClient_SelChangeGetOperator(object sender, EventArgs e)
        {
            if (txtClient.Text == "")
                return;
            if (_inited)
                txtOperator.Text = "";
            txtOperator.Items.Clear();
            var comboBoxItem = txtClient.SelectedItem as ComboBoxItem;
            if (comboBoxItem != null)
            {
                var list = BLL.CustomerInfo.GetOpeartorByCustId(comboBoxItem.Tag.ToString());
                if (list != null && list.Count > 0)
                    foreach (var item in list)
                        txtOperator.Items.Add(item);
            }
        }

        private void InitDgv()
        {
            dgvGroupInfo.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvGroupInfo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvGroupInfo.RowsDefaultCellStyle.Font = new Font("微软雅黑", 9.0f, FontStyle.Bold);
            dgvGroupInfo.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dgvGroupInfo.AutoGenerateColumns = false;
            dgvGroupInfo.Columns["Identification"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvGroupInfo.Columns["FinancialCapacity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvGroupInfo.Columns["Residence"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvGroupInfo.Columns["Sex"].Width = 40;
            dgvGroupInfo.Columns["Marriaged"].Width = 40;
            dgvGroupInfo.Columns["DepartureRecord"].Width = 40;
            dgvGroupInfo.Columns["Occupation"].Width = 60;
            dgvGroupInfo.Columns["Remark"].Width = 50;
            dgvGroupInfo.Columns["dgvGroup_IssuePlace"].Width = 70;
            dgvGroupInfo.Columns["AgencyOpinion"].Width = 50;
        }

        /// <summary>
        /// 从已有list初始化窗口(还未设置团号)
        /// </summary>
        /// 校验是否都是还没分配写在了调用者那边
        private void InitFrmFromList()
        {
            if (_list.Count == 0)
                return;

            //根据list加载列表
            for (int i = 0; i < _list.Count; i++)
            {
                ListViewItem lvitem = new ListViewItem(_list[i].Name);
                ListViewItem.ListViewSubItem lvsitem = new ListViewItem.ListViewSubItem(lvitem, _list[i].PassportNo);
                lvitem.SubItems.Add(lvsitem);
                lvitem.Tag = _list[i];
                lvOut.Items.Add(lvitem);
            }

            //初始化时间选择控件
            //还是不初始化的比较好

            //从list初始化就不能reset和删除团号
            btnReset.Enabled = false;
            btnDelete.Enabled = false;

            //没设置过的默认设置日本
            cbCountry.Text = "日本"; //这个默认值应该只是在还没设置的时候默认日本
            this.Text += "(" + _type + ")";
            this.Text += "  当前状态:未做资料";

            //团做个默认保持上一条记录的团队信息
            //if (_type != Types.Team2Individual)
            //    return;

            _recentVisa = _bllVisa.GetLastRecord(_type, GlobalUtils.LoginUser.UserName, _list[0].Country ?? ""); //如果是个签的话就是null这个值
            if (_recentVisa == null)
                return;
            txtGroupNo.Text = _recentVisa.GroupNo;
            cbCountry.Text = _recentVisa.Country;
            txtDepartureType.Text = _recentVisa.DepartureType;
            txtDepartureTime.Text = DateTimeFormator.DateTimeToString(_recentVisa.PredictTime);
            txtSubmitTime.Text = DateTimeFormator.DateTimeToString(_recentVisa.SubmitTime);
            txtSalesPerson.Text = _recentVisa.SalesPerson;
            txtInTime.Text = DateTimeFormator.DateTimeToString(_recentVisa.InTime);
            txtOutTime.Text = DateTimeFormator.DateTimeToString(_recentVisa.OutTime);
            txtClient.Text = _recentVisa.client;
            txtPerson.Text = _recentVisa.Person;
            txtSubmitCondition.Text = _recentVisa.SubmitCondition;
            txtFetchType.Text = _recentVisa.FetchCondition;
            txtCheckPerson.Text = _recentVisa.CheckPerson;
            chbIsUrgent.Checked = _recentVisa.IsUrgent ?? false;
            txtRealTime.Text = "";

            txtTypeInPerson.Text = GlobalUtils.LoginUser.UserName; //初始没做的时候，typeinperson就是当前人
            txtTypeInPerson.Enabled = false;
        }


        /// <summary>
        /// 从已有visaModel设置窗口(已经设置了团号)
        /// </summary>
        private void InitFrmFromVisaModel()
        {
            if (_visaModel == null)
                return;

            //查询得到所有的属于这个团的用户
            _list = _bllVisaInfo.GetModelListByVisaIdOrderByPosition(_visaModel.Visa_id);
            _visainfoListBackUp = new List<VisaInfo>();
            foreach (var visaInfo in _list) //查看已有团号的时候，备份一份，用来校验到底修改了没有
            {
                _visainfoListBackUp.Add(visaInfo.ToObjectCopy());
            }

            //校验这个团里面是否有延迟的
            bool delay = false;
            foreach (var visaInfo in _list)
            {
                if (visaInfo.outState == Common.Enums.OutState.Type01Delay)
                {
                    delay = true; //有一个的话就把选择框勾上
                    break;
                }
            }

            chkDelay.Checked = delay;

            //按照position顺序进行排序 //放到上面的方法里面直接调整了顺序了
            //_list.Sort((model1, model2) => { return model1.Position < model2.Position ? -1 : 1; });

            //根据list加载列表
            lvOut.Items.Clear();
            lvIn.Items.Clear();
            for (int i = 0; i < _list.Count; i++)
            {
                ListViewItem lvItem = new ListViewItem(_list[i].Name);
                ListViewItem.ListViewSubItem lvSubItem = new ListViewItem.ListViewSubItem(lvItem, _list[i].PassportNo);
                lvItem.SubItems.Add(lvSubItem);
                lvItem.Tag = _list[i];
                lvIn.Items.Add(lvItem); //这里是默认进入的在里面
            }

            //初始化团号
            //UpdateGroupNo(); //从已有加载的时候不去自动更新团号了

            //初始化dgv
            UpdateDgvAndListViaListView();

            //初始化备注项
            for (int i = 0; i < dgvGroupInfo.Rows.Count; i++)
            {
                dgvGroupInfo.Rows[i].Cells["Remark"].Value = _visaModel.Remark;
            }

            //初始数据项
            txtDepartureTime.Text = DateTimeFormator.DateTimeToString(_visaModel.PredictTime);
            cbCountry.Text = _visaModel.Country;
            txtSalesPerson.Text = _visaModel.SalesPerson;
            txtSubmitTime.Text = DateTimeFormator.DateTimeToString(_visaModel.SubmitTime);
            txtInTime.Text = DateTimeFormator.DateTimeToString(_visaModel.InTime);
            txtOutTime.Text = DateTimeFormator.DateTimeToString(_visaModel.OutTime);
            txtClient.Text = _visaModel.client;
            txtDepartureType.Text = _visaModel.DepartureType;
            txtSubmitCondition.Text = _visaModel.SubmitCondition;
            txtFetchType.Text = _visaModel.FetchCondition;
            txtCheckPerson.Text = _visaModel.CheckPerson;
            chbIsUrgent.Checked = _visaModel.IsUrgent ?? false;
            txtPerson.Text = _visaModel.Person;

            txtQuQianYuan.Text = _visaModel.QuQianYuan;
            txtPeiQianYuan.Text = _visaModel.PeiQianYuan;
            txtRealTime.Text = DateTimeFormator.DateTimeToString(_visaModel.RealTime);
            txtGroupNo.Text = _visaModel.GroupNo;

            txtOperator.Text = _visaModel.Operator;

            txtTypeInPerson.Text = _visaModel.TypeInPerson;
            txtTypeInPerson.Enabled = false;

            this.Text += "(" + _visaModel.Types + ")";
            if (_bllLoger.HasVisaBeenTypedIn(_visaModel))
                this.Text += "  当前状态:已做资料";
            else
                this.Text += "  当前状态:未做资料";

        }



        #region 状态更新函数
        private void UpdateLabels()
        {
            int res1 = dgvGroupInfo.Rows.Count; //信息完整度
            int idx = -1;
            for (int i = 0; i < dgvGroupInfo.Rows.Count; i++)
            {
                for (int j = 0; j < dgvGroupInfo.Rows[i].Cells.Count; j++)
                {
                    if ((dgvGroupInfo.Rows[i].Cells[j].Value == null
                        || dgvGroupInfo.Rows[i].Cells[j].Value.ToString() == string.Empty)
                        && dgvGroupInfo.Columns[j].Name != "Phone")
                    {
                        res1 -= 1;
                        idx = i;
                        break; //当前这一个人就判定为不完整
                    }
                }
            }
            if (res1 == dgvGroupInfo.Rows.Count - 1) //只有一人不完整
            {
                if (dgvGroupInfo.Rows[idx].Cells["dgvGroupInfo_Name"].Value != null)
                {
                    lbInfoCompleteStatus.Text = "\"" + dgvGroupInfo.Rows[idx].Cells["dgvGroupInfo_Name"].Value.ToString() +
                                                "\"信息录入不完整.";
                }
                else
                    lbInfoCompleteStatus.Text = "当前有" + (dgvGroupInfo.Rows.Count - res1) +
                                    "人信息录入不完整.";
                lbInfoCompleteStatus.ForeColor = Color.Red;
            }
            else if (res1 < dgvGroupInfo.Rows.Count - 1) //多人不完整
            {
                lbInfoCompleteStatus.Text = "当前有" + (dgvGroupInfo.Rows.Count - res1) +
                                            "人信息录入不完整.";
                lbInfoCompleteStatus.ForeColor = Color.Red;
            }
            else
            {
                lbInfoCompleteStatus.Text = "当前" +
                                            "信息录入完整.";
                lbInfoCompleteStatus.ForeColor = Color.Green;
            }
            res1 = dgvGroupInfo.Rows.Count;
            for (int i = 0; i < dgvGroupInfo.Rows.Count; i++)
            {
                if (dgvGroupInfo.Rows[i].Cells["Phone"].Value == null
                    || !InfoChecker.CheckPhoneValid(dgvGroupInfo.Rows[i].Cells["Phone"].Value.ToString()))
                {
                    res1 -= 1;
                    idx = i;
                }
            }

            if (res1 == dgvGroupInfo.Rows.Count - 1)
            {
                if (dgvGroupInfo.Rows[idx].Cells["dgvGroupInfo_Name"].Value != null)
                {
                    lbPhoneCompleteStatus.Text = "\"" + dgvGroupInfo.Rows[idx].Cells["dgvGroupInfo_Name"].Value.ToString() +
                                                "\"手机号录入错误或未录入.";
                }
                else
                    lbPhoneCompleteStatus.Text = "当前有" + (dgvGroupInfo.Rows.Count - res1) +
                                    "人手机号录入错误或未录入.";

                lbPhoneCompleteStatus.ForeColor = Color.Red;
            }
            else if (res1 < dgvGroupInfo.Rows.Count - 1)
            {
                lbPhoneCompleteStatus.Text = "当前有" + (dgvGroupInfo.Rows.Count - res1) +
                                             "人手机号录入错误或未录入.";
                lbPhoneCompleteStatus.ForeColor = Color.Red;
            }
            else
            {
                lbPhoneCompleteStatus.Text = "当前" +
                            "手机信息录入完整.";
                lbPhoneCompleteStatus.ForeColor = Color.Green;
            }
        }

        private void SetCountryPicBox()
        {
            pictureBox1.Image = CountryPicHandler.LoadImageByCountryName(cbCountry.Text);
        }

        private void UpdateDepartureTypeCombobox()
        {
            txtDepartureType.Items.Clear();
            if (cbCountry.Text == "日本")
            {
                txtDepartureType.Items.Add("单次");
                txtDepartureType.Items.Add("单次30");
                txtDepartureType.Items.Add("冲绳单次");
                txtDepartureType.Items.Add("冲绳三年");
                txtDepartureType.Items.Add("东北1单次");
                txtDepartureType.Items.Add("东北1三年");
                txtDepartureType.Items.Add("东北2A三年");
                txtDepartureType.Items.Add("东北2B三年");
                txtDepartureType.Items.Add("东北2C三年");
                txtDepartureType.Items.Add("东北2D三年");
                txtDepartureType.Items.Add("普通三年");
                txtDepartureType.Items.Add("五年多次");
                txtDepartureType.Items.Add("香港");
            }
            else
            {
                txtDepartureType.Items.Add("单次");
                txtDepartureType.Items.Add("单次加急");
                txtDepartureType.Items.Add("五年担保");
                txtDepartureType.Items.Add("五年多次");
                txtDepartureType.Items.Add("五年多次加急");
                txtDepartureType.Items.Add("十年多次");
                txtDepartureType.Items.Add("十年多次加急");
            }

        }



        private void UpdateGroupNo()
        {
            lbCount.Text = "团队人数:" + lvIn.Items.Count + "人";

            //从团号初始化的情况下不再自动更新团号
            if (_initFromVisaModel)
                return;
            string prefix = string.Empty;
            if (_type == Types.Individual)
            {
                prefix = "QZC"; //个签自动加上前缀
                if (!string.IsNullOrEmpty(cbCountry.Text)
                    && CountryCode.Dict.ContainsKey(cbCountry.Text)
                    && !string.IsNullOrEmpty(CountryCode.Dict[cbCountry.Text]))
                    prefix += CountryCode.Dict[cbCountry.Text];

                if (cbCountry.Text == "泰国" || cbCountry.Text == "韩国")
                {
                    if (txtSubmitTime.Value.ToString() != "0001/1/1 0:00:00")
                        prefix += txtSubmitTime.Value.ToString("yyyyMMdd");
                    else
                        prefix += DateTime.Now.ToString("yyyyMMdd");
                }
                else
                {
                    if (txtDepartureTime.Value.ToString() != "0001/1/1 0:00:00")
                        prefix += txtDepartureTime.Value.ToString("yyyyMMdd");
                    else
                        prefix += DateTime.Now.ToString("yyyyMMdd");
                }
            }

            _visaName = prefix;
            if (_type == Types.Team2Individual && _recentVisa != null) //团做个要去保持上一次的信息(取前缀)
            {
                string pattern = "[a-zA-Z]+\\d+";
                var matched = Regex.Match(_recentVisa.GroupNo, pattern);
                _visaName += matched.Groups[0].Value;
            }

            for (int i = 0; i < lvIn.Items.Count; ++i) //个签和团做个后面都跟上姓名
            {
                _visaName += ((Model.VisaInfo)lvIn.Items[i].Tag).Name;
                if (cbCountry.Text == "泰国" && i == 0)
                    break;
                if (i == lvIn.Items.Count - 1)
                    break;
                _visaName += "、";
            }

            if (!string.IsNullOrEmpty(txtDepartureType.Text) && txtDepartureType.Text != "单次")
                _visaName += "(" + txtDepartureType.Text + ")";
            txtGroupNo.Text = _visaName;
        }

        private void UpdateDgvAndListViaListView()
        {
            _dgvList.Clear();
            for (int i = 0; i < lvIn.Items.Count; ++i)
            {
                _dgvList.Add((Model.VisaInfo)lvIn.Items[i].Tag);
            }

            //也从新更新backuplist
            _visainfoListBackUp = new List<VisaInfo>();
            foreach (var visaInfo in _dgvList) //查看已有团号的时候，备份一份，用来校验到底修改了没有
            {
                _visainfoListBackUp.Add(visaInfo.ToObjectCopy());
            }

            dgvGroupInfo.DataSource = null; //必须加，不然报错，不知道为什么
            dgvGroupInfo.DataSource = _dgvList;
        }

        /// <summary>
        /// 根据输入信息更新LisitViewIn里面的人的visainfo数据库(一些没有在dgv里面的信息)
        /// </summary>
        /// <param name="list"></param>
        private void UpdateInListVisaInfo(List<Model.VisaInfo> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].GroupNo = _visaModel.GroupNo;
                //list[i].HasTypeIn = HasTypeIn.Yes; //修改为已录入状态
                list[i].Country = cbCountry.Text;
                list[i].Visa_id = _visaModel.Visa_id.ToString(); //修改visainfo对应visa_id
                list[i].Client = txtClient.Text;
                list[i].Salesperson = txtSalesPerson.Text;
                list[i].Types = _type;//设置指定类型
                list[i].Position = i + 1; //设置位置
                list[i].outState = chkDelay.Checked ? Common.Enums.OutState.Type01Delay : Common.Enums.OutState.Type01NoRecord;
            }
            int res = _bllVisaInfo.UpdateByList(_dgvList);
            GlobalUtils.MessageBoxWithRecordNum("更新", res, list.Count);
        }

        #endregion

        #region dgv响应
        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvGroupInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dgvGroupInfo.Rows.Count; i++)
                dgvGroupInfo.Rows[i].HeaderCell.Value = (i + 1).ToString();
            if (dgvGroupInfo.Rows.Count == 1 && lvIn.Items.Count == 1)
                dgvGroupInfo.Rows[0].Cells["Remark"].Value = "无";
        }

        /// <summary>
        /// 备注批量修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvGroupInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateLabels();
        }

        /// <summary>
        /// 实现赋值粘贴,Ctrl+C,Ctrl+V响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 现在只能单条记录，多条记录其实也可以
        /// TODO:右键菜单实现这些功能
        private void dgvGroupInfo_KeyDown(object sender, KeyEventArgs e)
        {
            //写在这里和窗口的keydown时间都不行，最后是重写了processcmdkey方法实现的
            //if (e.KeyCode == Keys.Escape)
            //{
            //    dgvGroupInfo.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            //}
            if (dgvGroupInfo.SelectedCells.Count != 0 && e.Control && e.KeyCode == Keys.C)
            {
                SendCellToClipboard();
            }

            if (dgvGroupInfo.SelectedCells.Count != 0 && e.Control && e.KeyCode == Keys.V)
            {
                SetCellsFromClipboard();
            }

            if (dgvGroupInfo.SelectedCells.Count != 0 && e.KeyCode == Keys.Delete)
            {
                ClearCells();
            }



        }

        /// <summary>
        /// 右键菜单弹出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvGroupInfo_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0) //除去表头
                {

                    //如果没选中当前活动行则选中这一行
                    if (dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected == false)
                    {
                        dgvGroupInfo.ClearSelection();
                        dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                    }

                    //只有在选中的单元格上
                    if (dgvGroupInfo.SelectedCells.Contains(dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex]))
                        //弹出操作菜单
                        cmsDgvRb.Show(MousePosition.X, MousePosition.Y);


                }
            }
        }


        /// <summary>
        /// 一个值改变的时候一起改变同一列，这个不能写在cellformating里面，会出现递归
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvGroupInfo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvGroupInfo.Columns[e.ColumnIndex].Name == "Remark")
            {
                if (dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    return;
                string remark = dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                for (int i = 0; i < dgvGroupInfo.Rows.Count; i++)
                {
                    dgvGroupInfo.Rows[i].Cells[e.ColumnIndex].Value = remark;
                }
            }

            if (e.ColumnIndex >= 0 && dgvGroupInfo.Columns[e.ColumnIndex].Name == "ReturnTime")
            {
                if (dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    return;
                string time = dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                for (int i = 0; i < dgvGroupInfo.Rows.Count; i++)
                {
                    dgvGroupInfo.Rows[i].Cells[e.ColumnIndex].Value = time;
                }
            }
        }

        #endregion


        #region 自己的按钮
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAllIn_Click(object sender, EventArgs e)
        {
            for (int i = lvOut.Items.Count - 1; i >= 0; --i)
            {
                ListViewItem lvItem = lvOut.Items[i];
                lvOut.Items.Remove(lvOut.Items[i]);
                lvIn.Items.Insert(0, lvItem);
            }
            UpdateGroupNo();
            UpdateDgvAndListViaListView();
        }

        private void btnAllOut_Click(object sender, EventArgs e)
        {
            for (int i = lvIn.Items.Count - 1; i >= 0; --i)
            {
                ListViewItem lvItem = lvIn.Items[i];
                lvIn.Items.Remove(lvIn.Items[i]);
                lvOut.Items.Insert(0, lvItem);
            }
            UpdateGroupNo();
            UpdateDgvAndListViaListView();

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            for (int i = lvOut.SelectedItems.Count - 1; i >= 0; --i)
            {
                ListViewItem lvItem = lvOut.SelectedItems[i];
                lvOut.Items.Remove(lvOut.SelectedItems[i]);
                lvIn.Items.Insert(0, lvItem);
            }
            UpdateGroupNo();
            UpdateDgvAndListViaListView();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            for (int i = lvIn.SelectedItems.Count - 1; i >= 0; --i)
            {
                ListViewItem lvItem = lvIn.SelectedItems[i];
                lvIn.Items.Remove(lvIn.SelectedItems[i]);
                lvOut.Items.Insert(0, lvItem);
            }
            UpdateGroupNo();
            UpdateDgvAndListViaListView();
        }


        /// <summary>
        /// 生成报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            if (dgvGroupInfo.Rows[0].Cells["Remark"].Value != null)
                ExcelGenerator.GetIndividualVisaExcel(_dgvList, dgvGroupInfo.Rows[0].Cells["Remark"].Value.ToString(), txtGroupNo.Text);
            else
                ExcelGenerator.GetIndividualVisaExcel(_dgvList, string.Empty, txtGroupNo.Text);
        }

        private void UpdateUserBusyState()
        {
            bool finished = _bllJobAssignment.UserWorkFinished(GlobalUtils.LoginUser.WorkId);
            if (!_bllWorkerQueue.ChangeUserBusyState(GlobalUtils.LoginUser.WorkId, !finished))
                MessageBoxEx.Show("修改用户IsBusy状态失败，请联系管理员!");
        }

        /// <summary>
        /// 提交修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// TODO:处理需要修改团号的逻辑
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //检查团号为空?
            if (string.IsNullOrEmpty(txtGroupNo.Text))
            {
                MessageBoxEx.Show("团号不能为空!");
                return;
            }

            if (!CheckGroupNoMatched())
            {
                //检查团号是否匹配
                DialogResult res = MessageBoxEx.Show("检测到团号可能存在错误(\"有旅客姓名未在其中\"或\"出发时间与团号不匹配\"),是否检查后重新提交?", "提示",
                    MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                    return;
            }
            else
            {
                //检查资料是否没填完，如果没填完则直接简单一点提示
                bool complete = true;
                for (int i = 0; i < _dgvList.Count; i++)
                {
                    if (!CheckTypedInComplete(_dgvList[i]))
                    {
                        complete = false;
                        break;
                    }
                }
                if (complete)
                {
                    DialogResult res = MessageBoxEx.Show("是否提交修改?\r\n做出的任何修改都将连同操作员的信息被记录到数据库中!", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (res == DialogResult.Cancel)
                        return;
                }
            }
            if (!_initFromVisaModel) //从List列表初始化进行团号设置
            {
                //1.保存团号信息修改到数据库,Visa表（sales_person,country,GroupNo,PredictTime）
                if (_visaModel != null)
                {
                    MessageBoxEx.Show("内部错误!");
                    return;
                }
                if (!CtrlsToVisaModel())
                    return;

                if ((_visaModel.Visa_id = _bllVisa.Add(_visaModel)) == Guid.Empty) //执行更新,返回值是新插入的visamodel的guid
                {
                    MessageBoxEx.Show("添加团号到数据库失败，请重试!");
                    return;
                }

                //2.更新model,设置资料已录入，团号，国家等
                _dgvList = (List<Model.VisaInfo>)dgvGroupInfo.DataSource;

                //bool hasTypedIn = _bllLoger.HasVisaBeenTypedIn(_visaModel);
                //3.1更新这些人的录入情况到ActionResult里面

                bool hasOneTypedIn = false; //判断是否有做完任何一本，有的话就可以触发一次分配工作的逻辑
                for (int i = 0; i < _dgvList.Count; i++)
                {
                    _bllLoger.AddRecord(Common.Enums.ActType._01TypeIn, Common.GlobalUtils.LoginUser,
                                            _dgvList[i], _visaModel);

                    if (!CheckTypedInComplete(_dgvList[i])) //如果信息也填写完整了就直接也弄成已经做了
                        continue;
                    _dgvList[i].HasTypeIn = "是"; //默认情况下是"否"
                    hasOneTypedIn = true;
                    _bllLoger.AddRecord(Common.Enums.ActType._02TypeInData, Common.GlobalUtils.LoginUser,
                            _dgvList[i], _visaModel);
                }

                //2.1更新VisaInfo数据库
                UpdateInListVisaInfo(_dgvList);


                if (_visaModel.Country == "日本" &&
                            (_visaModel.Types == "个签" ||
                            _visaModel.Types == "团做个" ||
                            _visaModel.Types == "商务"))
                {
                    //触发一次自己的工作状态检查，对IsBusy字段进行更新
                    if (GlobalUtils.LoginUserLevel == RigthLevel.Normal)
                        UpdateUserBusyState();

                    //触发一次分配任务逻辑
                    if (hasOneTypedIn)
                        _bllJobAssignment.AssignmentJob();
                }

                //添加完成后，删除这几个人
                for (int i = 0; i < lvIn.Items.Count; i++)
                    _list.Remove((Model.VisaInfo)lvIn.Items[i].Tag);
                lvIn.Items.Clear();
                _visaModel = null;
                UpdateDgvAndListViaListView();
                if (_list.Count == 0)
                {
                    _updateDel(_curPage);
                    Close();
                }
            }
            else
            {
                //从model初始化的，只考虑信息的修改以及移出人

                //如果所有人都移出了，提示请点击删除
                if (lvIn.Items.Count == 0)
                {
                    MessageBoxEx.Show("若需要将全部成员移出此团号，请点击\"删除团号\"按钮");
                    return;
                }

                //1.保存团号信息修改到数据库,Visa表（sales_person,country,GroupNo,PredictTime）

                int n = _bllLoger.GetVisaHasTypedInNum(_visaModel.Visa_id);
                if (n == _visaModel.Number) //之前就已经录入完毕了，相当于现在可能是修改了
                {
                    if (MessageBoxEx.Show("是否同时更新团号录入时间?\r\n更新录入时间后，统计今日做的团号的时间也会跟着发生变化!", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                        DialogResult.Yes)
                    {
                        _visaModel.EntryTime = DateTime.Now;
                    }
                }

                if (!CtrlsToVisaModel(_visaModel))
                    return;

                if (!_bllVisa.Update(_visaModel)) //执行更新
                {
                    MessageBoxEx.Show("更新团号信息失败!");
                    return;
                }
                //2.更新model,设置资料已录入，团号，国家等
                _dgvList = (List<Model.VisaInfo>)dgvGroupInfo.DataSource;

                bool hasOneTypedIn = false; //判断是否有做完任何一本，有的话就可以触发一次分配工作的逻辑
                for (int i = 0; i < _dgvList.Count; i++)
                {
                    if (!CheckTypedInComplete(_dgvList[i]))
                        continue;
                    //后面都是录入完整了 才会进行的操作
                    Model.ActionRecords log = new ActionRecords();
                    bool hasTypedIn = _bllLoger.HasVisaInfoBeenTypedIn(_dgvList[i], _visaModel);  //检查是否已经有这条记录，如果有的话就是修改了，如果没有就是做资料

                    if (!hasTypedIn) //如果还没录入的话
                    {
                        log.ActType = Common.Enums.ActType._02TypeInData; //操作记录为做资料
                    }
                    //TODO:这里假设的是没有移出并且没有发生位置的改变。。。，后面需要改进
                    else if (hasTypedIn && !InfoChecker.CheckVisaInfoSame(_dgvList[i], _visainfoListBackUp[i]))
                    //如果已经录入了，并且做了修改，那么这条记录就是修改资料
                    {
                        log.ActType = Common.Enums.ActType._03Modify; //操作记录为修改资料
                    }
                    else //已经录入完整了并且没做修改，那么啥都不干
                    {
                        continue;
                    }
                    _bllLoger.AddRecord(log.ActType, Common.GlobalUtils.LoginUser,
                                        _dgvList[i], _visaModel);
                    hasOneTypedIn = true;
                    _dgvList[i].HasTypeIn = "是";
                }
                //2.1更新还留在团内的人的VisaInfo数据库
                UpdateInListVisaInfo(_dgvList);

                if (_visaModel.Country == "日本" &&
                    (_visaModel.Types == "个签" || _visaModel.Types == "团做个" || _visaModel.Types == "商务"))
                {
                    //触发一次自己的工作状态检查，对IsBusy字段进行更新
                    if (GlobalUtils.LoginUserLevel == RigthLevel.Normal)
                        UpdateUserBusyState();

                    if (hasOneTypedIn) //触发一次分配工作的逻辑
                        _bllJobAssignment.AssignmentJob();

                }

                //2.2更新移出的人的数据库
                UpdateOutListVisaInfo();
                _updateDel(_curPage);
                Close();
            }
        }

        /// <summary>
        /// 校验团号名称和实际的人是否匹配，目前是通过是否包含这个人的姓名来判断的，后面再改
        /// </summary>
        /// <returns></returns>
        private bool CheckGroupNoMatched()
        {
            bool res = true;
            for (int i = 0; i < lvIn.Items.Count; i++)
            {
                if (!txtGroupNo.Text.Contains(lvIn.Items[i].Text))
                {
                    res = false;
                    break;
                }
            }

            if (!txtGroupNo.Text.Contains(DateTime.Parse(txtDepartureTime.Text).ToString("yyyyMMdd")))
                return false;
            return res;
        }

        private bool CheckTypedInComplete(VisaInfo model)
        {
            return !string.IsNullOrEmpty(Name) &&
                   !string.IsNullOrEmpty(model.EnglishName) &&
                   !string.IsNullOrEmpty(model.Sex) &&
                   !string.IsNullOrEmpty(model.IssuePlace) &&
                   !string.IsNullOrEmpty(DateTimeFormator.DateTimeToString(model.Birthday)) &&

                   //下面的是新录入的
                   !string.IsNullOrEmpty(model.Residence) && //居住地
                   !string.IsNullOrEmpty(model.Occupation) &&
                   !string.IsNullOrEmpty(model.DepartureRecord) &&
                   !string.IsNullOrEmpty(model.Marriaged) &&
                   !string.IsNullOrEmpty(model.Identification) && //身份确认
                   !string.IsNullOrEmpty(model.FinancialCapacity) &&
                   !string.IsNullOrEmpty(DateTimeFormator.DateTimeToString(model.ReturnTime)) &&
                   !string.IsNullOrEmpty(model.PassportNo) &&
                   !string.IsNullOrEmpty(model.AgencyOpinion);
            //除了手机号
        }

        private bool CtrlsToVisaModel()
        {
            _visaModel = new Model.Visa();
            //_visaModel.Visa_id = Guid.NewGuid(); //这里必须要给一个，虽然这里不给也会入库正确，数据库会赋给默认值，但是后面更新对应visainfo就会有错
            //这里代码生成器默认给了一个guid，不能再自己给了
            try
            {
                //单独处理remark
                if (!string.IsNullOrEmpty((string)dgvGroupInfo.Rows[0].Cells["Remark"].Value))
                    _visaModel.Remark = (string)dgvGroupInfo.Rows[0].Cells["Remark"].Value;

                if (!string.IsNullOrEmpty(txtDepartureTime.Text))
                    _visaModel.PredictTime = CtrlParser.Parse2Datetime(txtDepartureTime);
                if (!string.IsNullOrEmpty(txtSubmitTime.Text))
                    _visaModel.SubmitTime = CtrlParser.Parse2Datetime(txtSubmitTime);
                if (!string.IsNullOrEmpty(txtInTime.Text))
                    _visaModel.InTime = CtrlParser.Parse2Datetime(txtInTime);
                if (!string.IsNullOrEmpty(txtOutTime.Text))
                    _visaModel.OutTime = CtrlParser.Parse2Datetime(txtOutTime);

                _visaModel.EntryTime = DateTime.Now;
                _visaModel.GroupNo = CtrlParser.Parse2String(txtGroupNo);
                _visaModel.SalesPerson = CtrlParser.Parse2String(txtSalesPerson);
                _visaModel.Country = CtrlParser.Parse2String(cbCountry);
                _visaModel.Number = lvIn.Items.Count; //团号的人数
                _visaModel.client = CtrlParser.Parse2String(txtClient);
                _visaModel.Name = CtrlParser.Parse2String(txtClient);
                _visaModel.DepartureType = CtrlParser.Parse2String(txtDepartureType);
                _visaModel.SubmitCondition = CtrlParser.Parse2String(txtSubmitCondition);
                _visaModel.FetchCondition = CtrlParser.Parse2String(txtFetchType);
                _visaModel.TypeInPerson = CtrlParser.Parse2String(txtTypeInPerson);
                _visaModel.CheckPerson = CtrlParser.Parse2String(txtCheckPerson);
                //_visaModel.Types = Common.Enums.Types.Individual; //设置为个签
                _visaModel.Types = _type;//设置为指定类型
                _visaModel.IsUrgent = chbIsUrgent.Checked;
                _visaModel.Person = CtrlParser.Parse2String(txtPerson);
                _visaModel.Operator = CtrlParser.Parse2String(txtOperator);


                //if (chkSaleFirst.Checked)
                //{
                //    if (GlobalUtils.LoginUserLevel != RigthLevel.Manager &&
                //        (!CheckInComboBox(_visaModel.client, txtClient) ||
                //         !CheckInComboBox(_visaModel.SalesPerson, txtSalesPerson)))
                //    {
                //        MessageBoxEx.Show("销售、客户、输入有误(必须是下拉框中选项),请重新输入!!!");
                //        _visaModel = null;
                //        return false;
                //    }
                //}
                //else
                //{
                //    if (GlobalUtils.LoginUserLevel != RigthLevel.Manager &&
                //        (!CheckInComboBox(_visaModel.client, txtClient) ||
                //        !CheckInComboBox(_visaModel.Operator, txtOperator) ||
                //        !CheckInComboBox(_visaModel.SalesPerson, txtSalesPerson)))
                //    {
                //        MessageBoxEx.Show("销售、客户、操作输入有误(必须是下拉框中选项),请重新输入!!!");
                //        _visaModel = null;
                //        return false;
                //    }
                //}


                if (!string.IsNullOrEmpty(txtRealTime.Text))
                    _visaModel.RealTime = DateTime.Parse(txtRealTime.Text);

                if (!string.IsNullOrEmpty(txtPeiQianYuan.Text))
                    _visaModel.PeiQianYuan = txtPeiQianYuan.Text;

                if (!string.IsNullOrEmpty(txtQuQianYuan.Text))
                    _visaModel.QuQianYuan = txtQuQianYuan.Text;

                return true;
            }
            catch (Exception)
            {
                _visaModel = null; //一定要这里重新赋值为null
                MessageBoxEx.Show(Resources.PleaseCheckDateTimeFormat);
                return false;
            }
        }

        private bool CheckInComboBox(string str, ComboBox cb)
        {
            if (cb.Items.Count == 0)
                return true;
            for (int i = 0; i < cb.Items.Count; ++i)
            {
                if (cb.Items[i].ToString() == str)
                {
                    return true;
                }
            }
            return false;
        }




        /// <summary>
        /// 这个是从model初始化进来的
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool CtrlsToVisaModel(Model.Visa model)
        {
            try
            {
                //单独处理remark
                if (!string.IsNullOrEmpty((string)dgvGroupInfo.Rows[0].Cells["Remark"].Value))
                    model.Remark = (string)dgvGroupInfo.Rows[0].Cells["Remark"].Value;

                //1.保存团号信息修改到数据库,Visa表（sales_person,country,GroupNo,PredictTime）
                model.GroupNo = CtrlParser.Parse2String(txtGroupNo);
                model.SalesPerson = txtSalesPerson.Text;
                model.Country = cbCountry.Text;
                model.Number = lvIn.Items.Count;

                if (!string.IsNullOrEmpty(txtDepartureTime.Text))
                    model.PredictTime = DateTime.Parse(txtDepartureTime.Text);
                if (!string.IsNullOrEmpty(txtSubmitTime.Text))
                    model.SubmitTime = DateTime.Parse(txtSubmitTime.Text);
                if (!string.IsNullOrEmpty(txtInTime.Text))
                    model.InTime = DateTime.Parse(txtInTime.Text);
                if (!string.IsNullOrEmpty(txtOutTime.Text))
                    model.OutTime = DateTime.Parse(txtOutTime.Text);

                //_visaModel.SubmitTime = DateTime.Parse(txtSubmitTime.Text);
                //_visaModel.InTime = DateTime.Parse(txtInTime.Text);
                //_visaModel.OutTime = DateTime.Parse(txtOutTime.Text);
                model.client = txtClient.Text;
                model.Name = txtClient.Text;

                model.DepartureType = txtDepartureType.Text;
                model.SubmitCondition = txtSubmitCondition.Text;
                model.FetchCondition = txtFetchType.Text;
                model.TypeInPerson = txtTypeInPerson.Text;
                model.CheckPerson = txtCheckPerson.Text;
                //model.Types = _type; //设置为指定类型 type不去修改
                model.IsUrgent = chbIsUrgent.Checked;
                model.Person = txtPerson.Text;

                model.Operator = CtrlParser.Parse2String(txtOperator);


                //if (chkSaleFirst.Checked)
                //{
                //    if (GlobalUtils.LoginUserLevel != RigthLevel.Manager &&
                //        (!CheckInComboBox(model.client, txtClient) ||
                //         !CheckInComboBox(model.SalesPerson, txtSalesPerson)))
                //    {
                //        MessageBoxEx.Show("销售、客户输入有误(必须是下拉框中选项),请重新输入!!!");
                //        return false;
                //    }
                //}
                //else
                //{
                //    if (GlobalUtils.LoginUserLevel != RigthLevel.Manager &&
                //         (!CheckInComboBox(model.client, txtClient) ||
                //          !CheckInComboBox(model.Operator, txtOperator) ||
                //          !CheckInComboBox(model.SalesPerson, txtSalesPerson)))
                //    {
                //        MessageBoxEx.Show("销售、客户、操作输入有误(必须是下拉框中选项),请重新输入!!!");
                //        return false;
                //    }
                //}


                if (!string.IsNullOrEmpty(txtRealTime.Text))
                    model.RealTime = DateTime.Parse(txtRealTime.Text);

                if (!string.IsNullOrEmpty(txtPeiQianYuan.Text))
                    model.PeiQianYuan = txtPeiQianYuan.Text;

                if (!string.IsNullOrEmpty(txtQuQianYuan.Text))
                    model.QuQianYuan = txtQuQianYuan.Text;

                //model.EntryTime = DateTime.Now; //20171217，也跟着操作改变，20171231 改成询问用户
                return true;
            }
            catch (Exception)
            {
                MessageBoxEx.Show(Resources.PleaseCheckDateTimeFormat);
                return false;
            }
        }

        /// <summary>
        /// 更新移出了的人的数据库
        /// </summary>
        private void UpdateOutListVisaInfo()
        {
            for (int i = 0; i < lvOut.Items.Count; i++)
            {
                Model.VisaInfo model = lvOut.Items[i].Tag as Model.VisaInfo;
                model.Visa_id = null;
                model.GroupNo = null;
                model.Country = null;
                model.Types = null;
                model.Position = null;
                //TODO:资料录入情况怎么处理
                //执行更新
                if (_bllVisaInfo.Update(model) == false)
                {
                    MessageBoxEx.Show(Resources.FailedUpdateVisaInfoState);
                    return;
                }
                MessageBoxEx.Show("成功从当前团移出" + lvOut.Items.Count + "条记录.");
            }

        }


        /// <summary>
        /// 从visaModel初始化有一个恢复功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// TODO:是否应该备份一份visaModel，不备份的话先提交过修改再reset就没用了
        private void btnReset_Click(object sender, EventArgs e)
        {
            InitFrmFromVisaModel();
        }

        /// <summary>
        /// 删除团号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("是否删除该团号?", "警告", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            if (!_bllVisa.DeleteVisaAndModifyVisaInfos(_visaModel))
            {
                MessageBoxEx.Show("删除团号失败!");
                return;
            }
            MessageBoxEx.Show("删除团号成功!");
            _updateDel(_curPage);
            Close();
        }

        /// <summary>
        /// 导出身元模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetShenYuanMuban_Click(object sender, EventArgs e)
        {
            //弹出选择机票模板窗口
            FrmSelAirInfo frm = new FrmSelAirInfo();
            if (DialogResult.Cancel == frm.ShowDialog())
                return;
            List<string> airinfoList = AirInfos.AirInfoDict[frm.SelIdx];
            ExcelGenerator.GetYuanShenMuban(_dgvList, airinfoList);
        }
        #endregion

        #region dgv右键弹出菜单响应

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendCellToClipboard();
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCellsFromClipboard();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCells();
        }

        private void 上移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvGroupInfo.SelectedCells.Count > 1)
            {
                MessageBoxEx.Show(Resources.SelectEditMoreThanOne);
                return;
            }
            int selIdx = dgvGroupInfo.SelectedCells[0].RowIndex;
            int selColIdx = dgvGroupInfo.SelectedCells[0].ColumnIndex;
            if (selIdx == 0)
                return;

            var lvItemTmp = lvIn.Items[selIdx];
            lvIn.Items.Remove(lvItemTmp);
            lvIn.Items.Insert(selIdx - 1, lvItemTmp);

            UpdateDgvAndListViaListView();
            UpdateGroupNo();

            dgvGroupInfo.CurrentCell = dgvGroupInfo.Rows[selIdx - 1].Cells[selColIdx];

        }

        private void 下移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvGroupInfo.SelectedCells.Count > 1)
            {
                MessageBoxEx.Show(Resources.SelectEditMoreThanOne);
                return;
            }
            int selIdx = dgvGroupInfo.SelectedCells[0].RowIndex;
            int selColIdx = dgvGroupInfo.SelectedCells[0].ColumnIndex;

            if (selIdx == lvIn.Items.Count - 1)
                return;

            var lvItemTmp = lvIn.Items[selIdx];
            lvIn.Items.Remove(lvItemTmp);
            lvIn.Items.Insert(selIdx + 1, lvItemTmp);

            UpdateDgvAndListViaListView();
            UpdateGroupNo();

            dgvGroupInfo.CurrentCell = dgvGroupInfo.Rows[selIdx + 1].Cells[selColIdx];

        }

        private void 移到顶部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvGroupInfo.SelectedCells.Count > 1)
            {
                MessageBoxEx.Show(Resources.SelectEditMoreThanOne);
                return;
            }
            int selIdx = dgvGroupInfo.SelectedCells[0].RowIndex;
            int selColIdx = dgvGroupInfo.SelectedCells[0].ColumnIndex;

            if (selIdx == 0)
                return;

            var lvItemTmp = lvIn.Items[selIdx];
            lvIn.Items.Remove(lvItemTmp);
            lvIn.Items.Insert(0, lvItemTmp);
            UpdateDgvAndListViaListView();
            UpdateGroupNo();

            dgvGroupInfo.CurrentCell = dgvGroupInfo.Rows[0].Cells[selColIdx];
        }

        private void 移到底部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvGroupInfo.SelectedRows.Count > 1)
            {
                MessageBoxEx.Show(Resources.SelectEditMoreThanOne);
                return;
            }
            int selIdx = dgvGroupInfo.SelectedCells[0].RowIndex;
            int selColIdx = dgvGroupInfo.SelectedCells[0].ColumnIndex;

            if (selIdx == lvIn.Items.Count - 1)
                return;

            var lvItemTmp = lvIn.Items[selIdx];
            lvIn.Items.Remove(lvItemTmp);
            lvIn.Items.Add(lvItemTmp);
            UpdateDgvAndListViaListView();
            UpdateGroupNo();

            dgvGroupInfo.CurrentCell = dgvGroupInfo.Rows[lvIn.Items.Count - 1].Cells[selColIdx];
        }


        private void SendCellToClipboard()
        {
            if (dgvGroupInfo.SelectedCells.Count > 1)
            {
                MessageBoxEx.Show("请选中一条记录复制!");
                return;
            }
            string name = dgvGroupInfo.Columns[dgvGroupInfo.SelectedCells[0].ColumnIndex].Name;
            if ((name == "BirthDay" || name == "ReturnTime")
                && dgvGroupInfo.SelectedCells[0].Value != null) //归国时间的列,是datetime类型,单独判断
            {
                Clipboard.SetText(DateTimeFormator.DateTimeToString((DateTime)dgvGroupInfo.SelectedCells[0].Value));
                return;
            }

            if (!string.IsNullOrEmpty((string)dgvGroupInfo.SelectedCells[0].Value))
                Clipboard.SetText(dgvGroupInfo.SelectedCells[0].Value.ToString());
        }

        private void SetCellsFromClipboard()
        {
            for (int i = 0; i < dgvGroupInfo.SelectedCells.Count; i++)
            {
                dgvGroupInfo.SelectedCells[i].Value = Clipboard.GetText();
            }
        }

        private void ClearCells()
        {
            for (int i = 0; i < dgvGroupInfo.SelectedCells.Count; i++)
            {
                dgvGroupInfo.SelectedCells[i].Value = null;
            }
        }

        private void 查看资料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInfoTypeIn frm = new FrmInfoTypeIn(_dgvList, dgvGroupInfo.SelectedCells[0].RowIndex, __readonly: true);
            frm.Show();
        }

        #endregion


        #region 编辑框响应事件
        /// <summary>
        /// 根据选中的出发时间设置团号，出发时间和入境时间联动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDepartureTime_TextChanged(object sender, EventArgs e)
        {
            //if (_type == Types.Team2Individual)
            //    return;
            if (!string.IsNullOrEmpty(txtDepartureTime.Text))
                txtInTime.Text = txtDepartureTime.Text;
            UpdateGroupNo();
        }

        /// <summary>
        /// 泰国和韩国会在编辑框发生变化的时候更新团号，UpdateGroupNo内部做了国家判断，这里直接调用就行了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSubmitTime_TextChanged(object sender, EventArgs e)
        {
            UpdateGroupNo();
        }

        private void cbCountry_TextChanged(object sender, EventArgs e)
        {
            UpdateGroupNo();
            SetCountryPicBox();

            UpdateDepartureTypeCombobox();

        }



        /// <summary>
        /// 归国时间和出境时间联动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOutTime_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvGroupInfo.Rows.Count; i++)
                dgvGroupInfo.Rows[i].Cells["ReturnTime"].Value = txtOutTime.Text;
        }

        /// <summary>
        /// 出发时间和入境时间联动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInTime_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInTime.Text))
                txtDepartureTime.Text = txtInTime.Text;
        }
        #endregion

        /// <summary>
        /// 单元格双击响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvGroupInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) //表头部分
                return;
            //双击进入编辑模式
            dgvGroupInfo.EditMode = DataGridViewEditMode.EditOnEnter;

            if (dgvGroupInfo.Columns[e.ColumnIndex].Name == "dgvGroupInfo_Name")
            {
                FrmSetValue.FrmSetValue frm = new FrmSetValue.FrmSetValue((dgvGroupInfo.DataSource as List<Model.VisaInfo>)[dgvGroupInfo.SelectedCells[0].RowIndex]);

                if (DialogResult.Cancel == frm.ShowDialog())
                    return;
                dgvGroupInfo.DataSource = null;
                dgvGroupInfo.DataSource = _dgvList;
            }

            if (dgvGroupInfo.Columns[e.ColumnIndex].Name == "Identification")
            {
                FrmIdentificationValue frm;
                if (dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null
                    && !string.IsNullOrEmpty(dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    frm = new FrmIdentificationValue(dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                else frm = new FrmIdentificationValue(null);
                if (DialogResult.Cancel == frm.ShowDialog())
                    return;
                dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = frm.IdentifyString;
            }

            if (dgvGroupInfo.Columns[e.ColumnIndex].Name == "FinancialCapacity")
            {
                FrmFinancialCapacity frm;
                if (dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null
                    && !string.IsNullOrEmpty(dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    frm = new FrmFinancialCapacity(dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                else frm = new FrmFinancialCapacity(null);
                if (DialogResult.Cancel == frm.ShowDialog())
                    return;
                dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = frm.FinacialCapacity;
            }

            if (dgvGroupInfo.Columns[e.ColumnIndex].Name == "Remark")
            {
                FrmRemarkValue frm;
                if (dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null
                    && !string.IsNullOrEmpty(dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    frm = new FrmRemarkValue(dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                else frm = new FrmRemarkValue(null);
                if (DialogResult.Cancel == frm.ShowDialog())
                    return;
                dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = frm.Result;
            }

            if (dgvGroupInfo.Columns[e.ColumnIndex].Name == "Marriaged")
            {
                FrmMarrigedValue frm;
                if (dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null
                    && !string.IsNullOrEmpty(dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    frm = new FrmMarrigedValue(dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                else frm = new FrmMarrigedValue(null);
                if (DialogResult.Cancel == frm.ShowDialog())
                    return;
                dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = frm.Result;
            }

            if (dgvGroupInfo.Columns[e.ColumnIndex].Name == "Occupation")
            {
                FrmOccupationValue frm;
                if (dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null
                    && !string.IsNullOrEmpty(dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    frm = new FrmOccupationValue(dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                else frm = new FrmOccupationValue(null);
                if (DialogResult.Cancel == frm.ShowDialog())
                    return;
                dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = frm.Result;
            }

            if (dgvGroupInfo.Columns[e.ColumnIndex].Name == "DepartureRecord")
            {
                FrmDepartureRecordValue frm;
                if (dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null
                    && !string.IsNullOrEmpty(dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    frm = new FrmDepartureRecordValue(dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                else frm = new FrmDepartureRecordValue(null);
                if (DialogResult.Cancel == frm.ShowDialog())
                    return;
                dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = frm.Result;
            }

            var curCell = dgvGroupInfo.CurrentCell; //失去焦点再获得，立刻刷新显示
            dgvGroupInfo.CurrentCell = null;
            dgvGroupInfo.CurrentCell = curCell;
        }

        private void lbInfoCompleteStatus_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show("信息录入完整是指\"必填信息(除了手机号以外)\"填写完整");
        }

        private void lbPhoneCompleteStatus_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show("\"手机号\"为7-11位数字组成.");
        }



        //private void FrmSetGroup_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if(e.KeyCode == Keys.Escape)
        //        Console.WriteLine("aaa");
        //    Console.WriteLine(e.KeyCode);
        //}

        /// <summary>  
        /// ESC退出编辑
        /// </summary>  
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                dgvGroupInfo.EditMode = DataGridViewEditMode.EditOnKeystroke;
                var curCell = dgvGroupInfo.CurrentCell;//之后让当前单元格失去焦点一下
                dgvGroupInfo.CurrentCell = null;
                dgvGroupInfo.CurrentCell = curCell;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtDepartureType_TextChanged(object sender, EventArgs e)
        {
            UpdateGroupNo();
        }

        private void chkSaleFirst_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSaleFirst.Checked)
            {
                txtClient.SelectedIndexChanged -= TxtClient_SelChangeGetSalesPerson;
                txtSalesPerson.Items.Clear();
                if (_inited)
                    txtSalesPerson.Text = "";
                var salepersonlist = BLL.CustomerInfo.GetSalesPersonList();
                if (salepersonlist != null && salepersonlist.Count > 0)
                {
                    foreach (var pair in salepersonlist)
                    {
                        var item = new ComboBoxItem();
                        item.Text = pair.Value;
                        item.Tag = pair.Key;
                        txtSalesPerson.Items.Add(item);
                    }
                }
                txtSalesPerson.DropDownStyle = ComboBoxStyle.DropDown;
                txtSalesPerson.SelectedIndexChanged += TxtSalesPerson_SelectedIndexChanged;
            }
            else
            {
                txtClient.SelectedIndexChanged += TxtClient_SelChangeGetSalesPerson;
                txtSalesPerson.SelectedIndexChanged -= TxtSalesPerson_SelectedIndexChanged;
            }
        }

        private void TxtSalesPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBoxItem = txtSalesPerson.SelectedItem as ComboBoxItem;
            if (comboBoxItem != null)
            {
                var workid = comboBoxItem.Tag.ToString();
                txtClient.Items.Clear();
                txtClient.Text = "";
                var clientList = BLL.CustomerInfo.GetCustomerListBySalesperson(workid);
                if (clientList != null && clientList.Count > 0)
                {
                    foreach (var pair in clientList)
                    {
                        var item = new ComboBoxItem();
                        item.Text = pair.Value;
                        item.Tag = pair.Key;
                        txtClient.Items.Add(item);
                    }
                }
                txtClient.DropDownStyle = ComboBoxStyle.DropDown;
            }
        }
    }
}
