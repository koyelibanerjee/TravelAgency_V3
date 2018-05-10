using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DevComponents.DotNetBar;
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
    public partial class FrmSetTeamVisaGroup : Form
    {
        private List<Model.VisaInfo> _list; //保存所有传进来的visainfo
        private List<Model.VisaInfo> _dgvList = new List<VisaInfo>(); //保存所有进入dgv的visainfo
        private Model.Visa _visaModel;
        private readonly bool _initFromVisaModel;

        private readonly BLL.VisaInfo _bllVisaInfo = new BLL.VisaInfo();
        private readonly BLL.Visa _bllVisa = new BLL.Visa();
        private readonly TravelAgency.BLL.ActionRecords _bllLoger = new TravelAgency.BLL.ActionRecords();

        private string _visaName = "QZC" + DateTime.Now.ToString("yyMMdd") + "|";
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托
        private readonly int _curPage; //主界面更新数据库需要一个当前页
        private Model.Visa _visaModelBackup;
        private bool _init = false;

        private List<Model.VisaInfo> _visainfoListBackUp;

        //private 

        public FrmSetTeamVisaGroup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 从已有list初始化窗口(还未设置团号)
        /// </summary>
        /// <param name="list"></param>
        /// <param name="updateDel"></param>
        /// <param name="curpage"></param>
        public FrmSetTeamVisaGroup(List<Model.VisaInfo> list, Action<int> updateDel, int curpage)
        {
            InitializeComponent();
            _list = list;
            _initFromVisaModel = false;
            _updateDel = updateDel;
            _curPage = curpage;
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
                ListViewItem liv = new ListViewItem(_list[i].Name);
                //ListViewItem.ListViewSubItem livSubItem1 = new ListViewItem.ListViewSubItem(liv, DateTimeFormator.DateTimeToString(_list[i].EntryTime));
                //ListViewItem.ListViewSubItem livSubItem2 = new ListViewItem.ListViewSubItem(liv, _list[i].IssuePlace);
                ListViewItem.ListViewSubItem livSubItem3 = new ListViewItem.ListViewSubItem(liv, _list[i].PassportNo);
                //liv.SubItems.Add(livSubItem1);
                //liv.SubItems.Add(livSubItem2);
                liv.SubItems.Add(livSubItem3);
                liv.Tag = _list[i];
                lvOut.Items.Add(liv);
            }
            //初始化时间选择控件
            //还是不初始化的比较好   

            //从list初始化就不能reset和删除团号
            btnReset.Enabled = false;
            btnDelete.Enabled = false;
            cbCountry.Text = "日本";
            this.Text += "(团签)";
            this.Text += "  当前状态:未做资料";

        }

        /// <summary>
        /// 从已有visaModel设置窗口(已经设置了团号)
        /// </summary>
        /// <param name="model"></param>
        /// <param name="updateDel"></param>
        /// <param name="curpage"></param>
        public FrmSetTeamVisaGroup(Model.Visa model, Action<int> updateDel, int curpage)
        {
            InitializeComponent();
            _visaModel = model;
            _initFromVisaModel = true;
            _updateDel = updateDel;
            _curPage = curpage;
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
            //_list.Sort((model1, model2) => { return model1.Position < model2.Position ? -1 : 1; });


            _visainfoListBackUp = new List<VisaInfo>();
            foreach (var visaInfo in _list) //查看已有团号的时候，备份一份，用来校验到底修改了没有
            {
                _visainfoListBackUp.Add(visaInfo.ToObjectCopy());
            }

            //根据list加载列表
            lvOut.Items.Clear();
            lvIn.Items.Clear();
            for (int i = 0; i < _list.Count; i++)
            {
                ListViewItem liv = new ListViewItem(_list[i].Name);

                //ListViewItem.ListViewSubItem livSubItem1 = new ListViewItem.ListViewSubItem(liv, DateTimeFormator.DateTimeToString(_list[i].EntryTime));
                //ListViewItem.ListViewSubItem livSubItem2 = new ListViewItem.ListViewSubItem(liv, _list[i].IssuePlace);
                ListViewItem.ListViewSubItem livSubItem3 = new ListViewItem.ListViewSubItem(liv, _list[i].PassportNo);
                //liv.SubItems.Add(livSubItem1);
                //liv.SubItems.Add(livSubItem2);
                liv.SubItems.Add(livSubItem3);
                liv.Tag = _list[i];
                lvIn.Items.Add(liv); //这里是默认进入的在里面
            }

            //初始化团号
            txtGroupNo.Text = _visaModel.GroupNo;


            //初始化dgv
            UpdateDgvAndListViaListView();

            ////初始化备注项
            //for (int i = 0; i < dgvGroupInfo.Rows.Count; i++)
            //{
            //    dgvGroupInfo.Rows[i].Cells["Remark"].Value = _visaModel.Remark;
            //}

            //初始数据项
            txtDepartureTime.Text = DateTimeFormator.DateTimeToString(_visaModel.PredictTime);
            cbCountry.Text = _visaModel.Country;
            txtSalesPerson.Text = _visaModel.SalesPerson;
            txtClient.Text = _visaModel.client;
            chbIsUrgent.Checked = _visaModel.IsUrgent;
            txtPerson.Text = _visaModel.Person;
            this.Text += "(" + _visaModel.Types + ")";

            if (_bllLoger.HasVisaBeenTypedIn(_visaModel))
                this.Text += "  当前状态:已做资料";
            else
                this.Text += "  当前状态:未做资料";


        }

        private void FrmSetGroup_Load(object sender, EventArgs e)
        {
            //设置最小尺寸
            this.MinimumSize = this.Size;
            //不允许调整大小
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            dgvGroupInfo.DefaultCellStyle.Font = new Font("微软雅黑", 9.0f, FontStyle.Bold);
            dgvGroupInfo.AutoGenerateColumns = false;
            dgvGroupInfo.Columns["Sex"].Width = 40;
            dgvGroupInfo.Columns["_IssuePlace"].Width = 70;
            dgvGroupInfo.Columns["BirthPlace"].Width = 70;
            dgvGroupInfo.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            //dgvGroupInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; //列宽自适应
            //dgvGroupInfo.Columns["Birthday"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;//某一些列关闭自适应
            //dgvGroupInfo.Columns["SalesPerson"].ReadOnly = true;
            //dgvGroupInfo.Columns["Client"].ReadOnly = true;
            dgvGroupInfo.CellValueChanged += dgvGroupInfo_CellValueChanged;

            cbCountry.DropDownStyle = ComboBoxStyle.DropDown;
            this.btnReset.Enabled = false;
            cbSynClient.Checked = true;
            cbSynSalesPerson.Checked = true;


            //设置列表多选
            lvIn.MultiSelect = true;
            lvOut.MultiSelect = true;

            //设置操作员
            txtTypeInPerson.Text = Common.GlobalUtils.LoginUser.UserName;
            txtTypeInPerson.Enabled = false;

            //国家选择框加入
            foreach (string countryName in CountryCode.CountryNameArr)
            {
                cbCountry.Items.Add(countryName);
            }

            //送签社担当
            txtPerson.Items.Add("成都金桥");
            txtPerson.Items.Add("四川国旅");
            txtPerson.Items.Add("省中旅");
            txtPerson.Text = "";

            //txtDepartureType.SelectedIndex = 0;

            if (_list != null && _visaModel == null && !_initFromVisaModel)
                InitFrmFromList();
            if (_list == null && _visaModel != null && _initFromVisaModel)
                InitFrmFromVisaModel();

            //设置国家图片
            SetCountryPicBox(); //这个要写在后面，init里面写了初始化国家的combobox
            UpdateGroupNo();
            _init = true;
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
        private void UpdateGroupNo()
        {
            //if (txtDepartureTime.Value.ToString() != "0001/1/1 0:00:00")
            //{
            //    _visaName = "QZC" + txtDepartureTime.Value.ToString("yyMMdd");

            //}else
            //    _visaName = "QZC" + DateTime.Now.ToString("yyMMdd");

            //for (int i = 0; i < lvIn.Items.Count; ++i)
            //{
            //    _visaName += ((Model.VisaInfo)lvIn.Items[i].Tag).Name;
            //    if (i == lvIn.Items.Count - 1)
            //        break;
            //    _visaName += "、";
            //}
            //txtGroupNo.Text = _visaName;
            lbCount.Text = "团队人数:" + lvIn.Items.Count + "人";
        }

        private void UpdateDgvAndListViaListView()
        {
            _dgvList.Clear();
            for (int i = 0; i < lvIn.Items.Count; ++i)
            {
                _dgvList.Add((Model.VisaInfo)lvIn.Items[i].Tag);
            }
            dgvGroupInfo.DataSource = null; //必须加，不然报错，不知道为什么
            dgvGroupInfo.DataSource = _dgvList;

            _visainfoListBackUp = new List<VisaInfo>(); //更新backup list
            foreach (var visaInfo in _dgvList) //查看已有团号的时候，备份一份，用来校验到底修改了没有
            {
                _visainfoListBackUp.Add(visaInfo.ToObjectCopy());
            }

            //int n = dgvGroupInfo.RowCount;
            //for (int i = 0; i != n; ++i)
            //{
            //    dgvGroupInfo.Rows[i].Cells["SalesPerson"].Value = txtSalesPerson.Text;
            //    dgvGroupInfo.Rows[i].Cells["Client"].Value = txtClient.Text;
            //}

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
                list[i].Country = cbCountry.Text;
                list[i].Visa_id = _visaModel.Visa_id.ToString(); //修改visainfo对应visa_id
                //list[i].Client = txtClient.Text; //这两项设置为跟着dgv走
                //list[i].Salesperson = txtSalesPerson.Text;
                list[i].Types = Common.Enums.Types.Team;//设置为团签
                list[i].Position = i + 1;
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
            {
                dgvGroupInfo.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        /// <summary>
        /// 备注批量修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvGroupInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex >= 0 && dgvGroupInfo.Columns[e.ColumnIndex].Name == "Remark")
            //{
            //    string remark = dgvGroupInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //    for (int i = 0; i < dgvGroupInfo.Rows.Count; i++)
            //    {
            //        dgvGroupInfo.Rows[i].Cells[e.ColumnIndex].Value = remark;

            //    }
            //}

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
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
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


        private void dgvGroupInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            dgvGroupInfo.EditMode = DataGridViewEditMode.EditOnEnter;
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
            var curCell = dgvGroupInfo.CurrentCell; //失去焦点再获得，立刻刷新显示
            dgvGroupInfo.CurrentCell = null;
            dgvGroupInfo.CurrentCell = curCell;
        }

        /// <summary>  
        /// ESC退出编辑
        /// </summary>  
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                dgvGroupInfo.EditMode = DataGridViewEditMode.EditOnKeystroke;
                var curCell = dgvGroupInfo.CurrentCell; //之后让当前单元格失去焦点一下
                dgvGroupInfo.CurrentCell = null;
                dgvGroupInfo.CurrentCell = curCell;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
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
                lvIn.Items.Add(lvItem);
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
                lvOut.Items.Add(lvItem);
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
            if (cbCountry.Text == "日本")
            {
                ExcelGenerator.GetTeamVisaExcelOfJapan(new List<Model.Visa> { _visaModel }, new List<List<VisaInfo>> { _dgvList });
            }
            else if (cbCountry.Text == "泰国")
            {
                ExcelGenerator.GetTeamVisaExcelOfThailand(_dgvList, txtGroupNo.Text);

            }
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
            DialogResult res = MessageBoxEx.Show("是否提交修改?", "确认", MessageBoxButtons.OKCancel);
            if (res == DialogResult.Cancel)
                return;
            if (!_initFromVisaModel) //从List列表初始化
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
                //2.1更新VisaInfo数据库
                UpdateInListVisaInfo(_dgvList);
                //3.1更新这些人的录入情况到ActionResult里面
                for (int i = 0; i < _dgvList.Count; i++)
                {
                    //Model.ActionRecords log = new ActionRecords();
                    //log.ActType = Common.Enums.ActType._01TypeIn;
                    //log.WorkId = Common.GlobalUtils.LoginUser.WorkId;
                    //log.UserName = Common.GlobalUtils.LoginUser.UserName;
                    //log.VisaInfo_id = _dgvList[i].VisaInfo_id;
                    //log.Visa_id = _visaModel.Visa_id;
                    //log.Type = Common.Enums.Types.Team;
                    //log.EntryTime = DateTime.Now;
                    //_bllLoger.Add(log);
                    _bllLoger.AddRecord(Common.Enums.ActType._01TypeIn, Common.GlobalUtils.LoginUser,
_dgvList[i], _visaModel);

                    if (!CheckTypedInComplete(_dgvList[i])) //如果信息也填写完整了就直接也弄成已经做了
                        continue;
                    //Model.ActionRecords log1 = new ActionRecords();
                    //log1.ActType = Common.Enums.ActType._02TypeInData; //操作记录为做资料
                    //log1.WorkId = Common.GlobalUtils.LoginUser.WorkId;
                    //log1.UserName = Common.GlobalUtils.LoginUser.UserName;
                    //log1.VisaInfo_id = _dgvList[i].VisaInfo_id;
                    //log1.Visa_id = _visaModel.Visa_id;
                    //log1.Type = Common.Enums.Types.Individual;
                    //log1.EntryTime = DateTime.Now;
                    //_bllLoger.Add(log1);

                    _bllLoger.AddRecord(Common.Enums.ActType._02TypeInData, Common.GlobalUtils.LoginUser,
_dgvList[i], _visaModel);

                }

                //添加完成后，删除这几个人
                for (int i = 0; i < lvIn.Items.Count; i++)
                {
                    _list.Remove((Model.VisaInfo)lvIn.Items[i].Tag);
                }

                lvIn.Items.Clear();
                _visaModel = null;
                UpdateDgvAndListViaListView();
                this.txtGroupNo.Text = "";
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
                if (!CtrlsToVisaModel(_visaModel))
                    return;

                if (!_bllVisa.Update(_visaModel)) //执行更新
                {
                    MessageBoxEx.Show("更新团号信息失败!");
                    return;
                }
                //2.更新model,设置资料已录入，团号，国家等
                _dgvList = (List<Model.VisaInfo>)dgvGroupInfo.DataSource;
                //2.1更新还留在团内的人的VisaInfo数据库
                UpdateInListVisaInfo(_dgvList);

                //添加记录
                for (int i = 0; i < _dgvList.Count; i++)
                {
                    //if (!CheckTypedInComplete(_dgvList[i]))
                    //    continue;
                    //Model.ActionRecords log = new ActionRecords();
                    //log.ActType = Common.Enums.ActType._02TypeInData;//类型是做资料
                    //log.WorkId = Common.GlobalUtils.LoginUser.WorkId;
                    //log.UserName = Common.GlobalUtils.LoginUser.UserName;
                    //log.VisaInfo_id = _dgvList[i].VisaInfo_id;
                    //log.Visa_id = _visaModel.Visa_id;
                    //log.Type = Common.Enums.Types.Team;
                    //log.EntryTime = DateTime.Now;
                    //_bllLoger.Add(log);

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
                    //log.WorkId = Common.GlobalUtils.LoginUser.WorkId;
                    //log.UserName = Common.GlobalUtils.LoginUser.UserName;
                    //log.VisaInfo_id = _dgvList[i].VisaInfo_id;
                    //log.Visa_id = _visaModel.Visa_id;
                    //log.Type = Common.Enums.Types.Team;
                    //log.EntryTime = DateTime.Now;
                    //_bllLoger.Add(log);
                    _bllLoger.AddRecord(log.ActType, Common.GlobalUtils.LoginUser,
_dgvList[i], _visaModel);


                }

                //2.2更新移出的人的数据库
                UpdateOutListVisaInfo();
                //关闭窗口
                _updateDel(_curPage);
                Close();
            }
        }

        private bool CheckTypedInComplete(VisaInfo model)
        {
            return !string.IsNullOrEmpty(Name) &&
                   !string.IsNullOrEmpty(model.EnglishName) &&
                   !string.IsNullOrEmpty(model.Sex) &&
                   !string.IsNullOrEmpty(model.IssuePlace) &&
                   !string.IsNullOrEmpty(DateTimeFormator.DateTimeToString(model.Birthday)) &&
                   !string.IsNullOrEmpty(model.PassportNo) &&
                   !string.IsNullOrEmpty(DateTimeFormator.DateTimeToString(model.LicenceTime)) &&
                   !string.IsNullOrEmpty(DateTimeFormator.DateTimeToString(model.ExpiryDate)) &&

                   //下面的是新录入的
                   !string.IsNullOrEmpty(model.Client) &&
                   !string.IsNullOrEmpty(model.Salesperson);

            //除了手机号
        }

        //这种情况是从list初始化，添加新团号
        private bool CtrlsToVisaModel()
        {
            _visaModel = new Model.Visa();
            //_visaModel.Visa_id = Guid.NewGuid(); //这里必须要给一个，虽然这里不给也会入库正确，数据库会赋给默认值，但是后面更新对应visainfo就会有错
            //这里代码生成器默认给了一个guid，不能再自己给了
            try
            {
                if (!string.IsNullOrEmpty(txtDepartureTime.Text))
                    _visaModel.PredictTime = DateTime.Parse(txtDepartureTime.Text);
                _visaModel.EntryTime = DateTime.Now;
                _visaModel.GroupNo = txtGroupNo.Text;
                _visaModel.SalesPerson = txtSalesPerson.Text;
                _visaModel.TypeInPerson = txtTypeInPerson.Text;
                _visaModel.client = txtClient.Text;
                _visaModel.Name = txtClient.Text;
                _visaModel.Country = cbCountry.Text;
                _visaModel.Number = lvIn.Items.Count; //团号的人数
                _visaModel.Types = Common.Enums.Types.Team; //设置为团签
                _visaModel.IsUrgent = chbIsUrgent.Checked;
                _visaModel.Person = txtPerson.Text;
                return true;
            }
            catch (Exception)
            {
                _visaModel = null; //一定要这里重新赋值为null
                MessageBoxEx.Show(Resources.PleaseCheckDateTimeFormat);
                return false;

            }


        }

        private bool CtrlsToVisaModel(Model.Visa model)
        {
            //这里执行备份，这种逻辑是对现有的model进行修改

            _visaModelBackup = model.ToObjectCopy();

            try
            {
                ////单独处理remark
                //if (!string.IsNullOrEmpty((string)dgvGroupInfo.Rows[0].Cells["Remark"].Value))
                //    _visaModel.Remark = (string)dgvGroupInfo.Rows[0].Cells["Remark"].Value;

                //1.保存团号信息修改到数据库,Visa表（sales_person,country,GroupNo,PredictTime）
                if (!string.IsNullOrEmpty(txtDepartureTime.Text))
                    model.PredictTime = DateTime.Parse(txtDepartureTime.Text);
                model.GroupNo = txtGroupNo.Text;
                model.SalesPerson = txtSalesPerson.Text;
                model.TypeInPerson = txtTypeInPerson.Text;
                model.Country = cbCountry.Text;
                model.Number = lvIn.Items.Count;
                model.client = txtClient.Text;
                model.Name = txtClient.Text;
                model.Types = Common.Enums.Types.Team; //设置为团签
                model.IsUrgent = chbIsUrgent.Checked;
                model.Person = txtPerson.Text;

                model.EntryTime = DateTime.Now; //20171217，也跟着操作改变
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
        /// TODO:是否应该备份一份visaModel，不备份的话先提交过修改再reset就没用了,这样做了还是有问题，因为数据库那边已经提交了，所以最终应该备份数据库那边的状态，或者最终关闭窗口的时候才保存修改
        private void btnReset_Click(object sender, EventArgs e)
        {
            _visaModel = _visaModelBackup;//目前来说没有多少用
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

        #endregion

        #region 右键菜单及按键的消息
        private void SendCellToClipboard()
        {
            if (dgvGroupInfo.SelectedCells.Count > 1)
            {
                MessageBoxEx.Show("请选中一条记录复制!");
                return;
            }

            string name = dgvGroupInfo.Columns[dgvGroupInfo.SelectedCells[0].ColumnIndex].Name;
            if ((name == "BirthDay" || name == "ExpiryDate" || name == "LicenceTime")
                && dgvGroupInfo.SelectedCells[0].Value != null) //datetime类型,单独判断
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

        private void 查看资料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInfoTypeIn frm = new FrmInfoTypeIn(_dgvList, dgvGroupInfo.SelectedCells[0].RowIndex, __readonly: true);
            frm.Show();
        }

        #endregion

        #region 编辑框响应事件

        /// <summary>
        /// 根据选中的出发时间设置团号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDepartureTime_TextChanged(object sender, EventArgs e)
        {
            UpdateGroupNo();
        }

        /// <summary>
        /// 联动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtClient_TextChanged(object sender, EventArgs e)
        {
            if (!_init || !cbSynClient.Checked)
                return;
            int n = dgvGroupInfo.RowCount;
            for (int i = 0; i != n; ++i)
            {
                dgvGroupInfo.Rows[i].Cells["Client"].Value = txtClient.Text;
            }
        }

        /// <summary>
        /// 联动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSalesPerson_TextChanged(object sender, EventArgs e)
        {
            if (!_init || !cbSynSalesPerson.Checked)
                return;

            int n = dgvGroupInfo.RowCount;
            for (int i = 0; i != n; ++i)
            {
                dgvGroupInfo.Rows[i].Cells["SalesPerson"].Value = txtSalesPerson.Text;
            }
        }


        private void cbCountry_TextChanged(object sender, EventArgs e)
        {
            SetCountryPicBox();
        }


        private void cbSynClient_CheckedChanged(object sender, EventArgs e)
        {
            txtClient_TextChanged(null, null);
        }

        private void cbSynSalesPerson_CheckedChanged(object sender, EventArgs e)
        {
            txtSalesPerson_TextChanged(null, null);
        }

        #endregion







    }

}
