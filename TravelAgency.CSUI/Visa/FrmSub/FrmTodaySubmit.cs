using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.BLL.Excel;
using TravelAgency.Common;
using TravelAgency.Common.Enums;
using TravelAgency.Common.Word;
using TravelAgency.CSUI.FrmMain;
using TravelAgency.CSUI.Properties;
using TravelAgency.Model;
using TravelAgency.Model.Enums;

namespace TravelAgency.CSUI.FrmSub
{
    public partial class FrmTodaySubmit : Form
    {
        private readonly List<List<VisaInfo>> _listVisaInfo;
        private readonly List<Model.Visa> _listVisa;
        private readonly List<VisaInfo> _listDgv = new List<VisaInfo>();
        private readonly BLL.Visa _bllVisa = new BLL.Visa();
        private readonly BLL.VisaInfo _bllVisaInfo = new BLL.VisaInfo();

        private List<VisaInfo> _listHasExpportedDgv = new List<VisaInfo>();
        private readonly BLL.HasExported8Report _bllHasExported8Report = new BLL.HasExported8Report();

        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public FrmTodaySubmit(List<Model.Visa> listVisa, List<List<VisaInfo>> listVisaInfo)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            InitializeComponent();
            _listVisa = listVisa;
            _listVisaInfo = listVisaInfo;
            UpdateListAndDgv();
        }

        private void FrmTodaySubmit_Load(object sender, EventArgs e)
        {
            rowMergeView1.AutoGenerateColumns = false;
            rowMergeView1.MultiSelect = true;
            rowMergeView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            rowMergeView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            rowMergeView1.DataSource = _listDgv;
            //rowMergeView1.MergeColumnNames.Add("Remark");
            rowMergeView1.MergeColumnNames.Add("GroupNo");

            dgvHasExported.AutoGenerateColumns = false;
            dgvHasExported.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvHasExported.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHasExported.CellMouseUp += dgvHasExported_CellMouseUp;
            dgvHasExported.RowsAdded += dgvHasExported_RowsAdded;


            btnToday.Click += btnToday_Click;
            btnYestoday.Click += btnYestoday_Click;
            btnPre2Day.Click += btnPre2Day_Click;
            btnPre7Days.Click += btnPre7Days_Click;
            btnPre2Week.Click += btnPre2Week_Click;
            btnPreAMonth.Click += btnPreAMonth_Click;


            txtFrom.Text = DateTimeFormator.DateTimeToString(From, DateTimeFormator.TimeFormat.Type06LongTime);
            txtTo.Text = DateTimeFormator.DateTimeToString(To, DateTimeFormator.TimeFormat.Type06LongTime);
            btnSearch_Click(null, null); //默认点击一次

            lbCount.Text = "待导出，共:" + _listDgv.Count + "人";
            lbFrom.Text = "从:" + DateTimeFormator.DateTimeToString(From, DateTimeFormator.TimeFormat.Type06LongTime);
            lbTo.Text = "到:" + DateTimeFormator.DateTimeToString(To, DateTimeFormator.TimeFormat.Type06LongTime);

        }


        #region 按钮事件
        private void buttonGetTodaySubmitExcel_Click(object sender, EventArgs e)
        {
            ExcelGenerator.GetEverydayExcel(_listVisa, _listVisaInfo);
        }
        private void btnGetJinGunMingDan_Click(object sender, EventArgs e)
        {
            var visainfos = _listDgv;
            XlsGenerator.GetGuolvJinGunMingDan(visainfos, _bllVisa.GetVisaListViaVisaInfoList(visainfos));

        }

        private void btnAddVisaInfo_Click(object sender, EventArgs e)
        {
            FrmVisaInfoManage frm = new FrmVisaInfoManage(b4Add: true);
            if (frm.ShowDialog() == DialogResult.Cancel)
                return;
            var listVisaInfo = frm.List4AddToExport;
            for (int i = listVisaInfo.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < _listDgv.Count; j++)
                {
                    if (_listDgv[j].VisaInfo_id.Equals(listVisaInfo[i].VisaInfo_id))
                    {
                        listVisaInfo.Remove(listVisaInfo[i]);
                        break;
                    }
                }
            }
            //获得每一个visainfo所在的visa
            var listVisa = GetVisaListViaVisaInfoList(listVisaInfo);

            //然后往左边加，如果存在对应的visa的话就加入到对应visa，如果不存在的话，就新建visa再加入
            for (int i = 0; i < listVisaInfo.Count; i++)
            {

                bool has = false;
                for (int j = 0; j < _listVisa.Count; j++)
                {
                    if (_listVisa[j].Visa_id == listVisa[i].Visa_id)
                    {
                        _listVisaInfo[j].Add(listVisaInfo[i]);
                        _listVisaInfo[j].Sort((model1, model2) => { return model1.Position < model2.Position ? -1 : 1; }); //按照position排序
                        has = true;
                        break;
                    }
                }

                if (!has)//不存在的话就创建
                {
                    _listVisa.Add(listVisa[i]);
                    List<VisaInfo> list = new List<VisaInfo>();
                    _listVisaInfo.Add(list);
                    _listVisaInfo[_listVisa.Count - 1].Add(listVisaInfo[i]); //最后一个添加
                }

                //都执行删除先
                _listHasExpportedDgv.Remove(listVisaInfo[i]);
            }
            dgvHasExported.DataSource = null;
            dgvHasExported.DataSource = _listHasExpportedDgv;
            UpdateListAndDgv();
            MessageBoxEx.Show("成功添加" + listVisaInfo.Count + "条记录!");
            lbCount.Text = "待导出，共:" + _listDgv.Count + "人";
        }
        #endregion

        #region 公共函数
        /// <summary>
        /// 通过visainfo的list更新listdgv
        /// </summary>
        private void UpdateListAndDgv()
        {
            _listDgv.Clear();
            foreach (List<VisaInfo> t in _listVisaInfo)
            {
                _listDgv.AddRange(t);
            }
            rowMergeView1.DataSource = null;
            rowMergeView1.DataSource = _listDgv;
        }

        /// <summary>
        /// 获取选中项的list
        /// </summary>
        /// <returns></returns>
        private List<Model.VisaInfo> GetDgvSelList()
        {
            int count = this.rowMergeView1.SelectedRows.Count;
            List<Model.VisaInfo> list = new List<VisaInfo>();
            for (int i = count - 1; i >= 0; --i)
            {
                list.Add(_listDgv[rowMergeView1.SelectedRows[i].Index]);
            }
            return list;
        }

        /// <summary>
        /// 获取选中项的list
        /// </summary>
        /// <returns></returns>
        private List<Model.VisaInfo> GetHasExportedDgvSelList()
        {
            if (_listHasExpportedDgv.Count != dgvHasExported.Rows.Count)
                return null;
            int count = this.dgvHasExported.SelectedRows.Count;
            List<Model.VisaInfo> list = new List<VisaInfo>();

            for (int i = count - 1; i >= 0; --i)
            {
                list.Add(_listHasExpportedDgv[dgvHasExported.SelectedRows[i].Index]);
            }
            return list;
        }



        private List<Model.Visa> GetVisaListViaVisaInfoList(List<Model.VisaInfo> visaInfoList)
        {
            List<Model.Visa> list = new List<Model.Visa>();
            for (int i = 0; i < visaInfoList.Count; i++)
            {
                Guid guid;
                if (Guid.TryParse(visaInfoList[i].Visa_id, out guid))
                {
                    var visaModel = _bllVisa.GetModel(guid);
                    //if(visaModel!=null)
                    list.Add(visaModel); //就算是null也直接添加进去 ，没有影响
                }
                else
                {
                    list.Add(null);
                }

            }
            return list;
        }
        #endregion

        #region dgv右键菜单事件
        private void 个签意见书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HashSet<Model.Visa> set = new HashSet<Model.Visa>();
            Model.Visa visaModel = null;
            int idx = 0; //visaModel的下标
            //用set判断选中项是否在多个团
            for (int i = 0; i < rowMergeView1.SelectedRows.Count; i++)
            {
                for (int j = 0; j < _listVisa.Count; j++)
                {
                    if (_listVisaInfo[j].Contains(_listDgv[rowMergeView1.SelectedRows[i].Index]))
                    {
                        if (!set.Contains(_listVisa[j]))
                        {
                            set.Add(_listVisa[j]);
                            visaModel = _listVisa[j];
                            idx = j;
                        }
                    }
                }

            }
            if (set.Count > 1)
            {
                MessageBoxEx.Show("请选择同一个团号的签证进行导出!");
                return;
            }

            if (visaModel == null)
                return;
            ExcelGenerator.GetIndividualVisaExcel(_listVisaInfo[idx], visaModel.Remark, visaModel.GroupNo);
        }

        private void 金桥大名单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var visainfoList = GetDgvSelList();
            List<string> list = new List<string>();
            for (int i = 0; i < visainfoList.Count; i++)
            {
                list.Add(visainfoList[i].Name);
            }
            GlobalUtils.DocDocxGenerator.SetDocType(DocDocxGenerator.DocType.Type01JinQiaoList);
            GlobalUtils.DocDocxGenerator.Generate(list);

        }

        private void 人申请表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var visainfos = GetDgvSelList();
            XlsGenerator.GetGuolvJinGunMingDan(visainfos, _bllVisa.GetVisaListViaVisaInfoList(visainfos));
        }

        private void 移入每日送签统计表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var listVisaInfo = GetHasExportedDgvSelList();

            //获得每一个visainfo所在的visa
            var listVisa = GetVisaListViaVisaInfoList(listVisaInfo);

            //然后往左边加，如果存在对应的visa的话就加入到对应visa，如果不存在的话，就新建visa再加入
            for (int i = 0; i < listVisaInfo.Count; i++)
            {
                bool has = false;
                for (int j = 0; j < _listVisa.Count; j++)
                {
                    if (_listVisa[j].Visa_id == listVisa[i].Visa_id)
                    {
                        _listVisaInfo[j].Add(listVisaInfo[i]);
                        _listVisaInfo[j].Sort((model1, model2) => { return model1.Position < model2.Position ? -1 : 1; }); //按照position排序
                        has = true;
                        break;
                    }
                }

                if (!has)//不存在的话就创建
                {
                    _listVisa.Add(listVisa[i]);
                    List<VisaInfo> list = new List<VisaInfo>();
                    _listVisaInfo.Add(list);
                    _listVisaInfo[_listVisa.Count - 1].Add(listVisaInfo[i]); //最后一个添加
                }

                //都执行删除先
                _listHasExpportedDgv.Remove(listVisaInfo[i]);
            }
            dgvHasExported.DataSource = null;
            dgvHasExported.DataSource = _listHasExpportedDgv;
            UpdateListAndDgv();
            lbCount.Text = "待导出，共:" + _listDgv.Count + "人";
        }

        private void 移到已导出不进行统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selVisaInfoList = GetDgvSelList();
            //获得每一个visainfo所在的visa
            var selVisaList = GetVisaListViaVisaInfoList(selVisaInfoList);
            for (int i = selVisaInfoList.Count - 1; i >= 0; i--)
            {
                for (int j = _listVisa.Count - 1; j >= 0; j--)
                {
                    if (_listVisa[j].Visa_id == selVisaList[i].Visa_id)
                    {
                        _listVisaInfo[j].Remove(selVisaInfoList[i]); //删除对应成员变量里的数据
                        if (_listVisaInfo[j].Count == 0)
                        {
                            _listVisa.Remove(_listVisa[j]);
                            _listVisaInfo.Remove(_listVisaInfo[j]);
                        }
                    }
                }
                //移出这边的报表
                _listDgv.Remove(selVisaInfoList[i]);

            }
            rowMergeView1.DataSource = null;

            rowMergeView1.DataSource = _listDgv;
            lbCount.Text = "待导出，共:" + _listDgv.Count + "人";
        }

        #endregion


        #region dgv响应

        private void dgvHasExported_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dgvHasExported.Rows.Count; i++)
            {
                DataGridViewRow row = dgvHasExported.Rows[i];
                row.HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void rowMergeView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < rowMergeView1.Rows.Count; i++)
            {
                DataGridViewRow row = rowMergeView1.Rows[i];
                row.HeaderCell.Value = (i + 1).ToString();

                for (int j = 0; j < _listVisaInfo.Count; j++)
                {
                    if (_listVisaInfo[j].Contains(_listDgv[i]))
                    {
                        row.Cells["SubmitCondition"].Value = _listVisa[j].SubmitCondition;
                        row.Cells["Remark"].Value = _listVisa[j].Remark;
                        row.Cells["DepartureType"].Value = _listVisa[j].DepartureType;
                    }
                }

                // 根据送签状态设置单元格颜色
                if (rowMergeView1.Rows[i].Cells["outState"].Value != null)
                {
                    Color c = Color.Empty;
                    //string state = e.Value.ToString();
                    string state = rowMergeView1.Rows[i].Cells["outState"].Value.ToString();
                    if (state == OutState.Type10Exported)
                    {
                        c = Color.DarkOrange;
                    }
                    else
                    {
                        c = Color.AliceBlue;
                    }
                    rowMergeView1.Rows[i].Cells["outState"].Style.BackColor = c;
                }

            }
        }

        private void rowMergeView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {

                    //若行已是选中状态就不再进行设置
                    //如果没选中当前活动行则选中这一行
                    if (rowMergeView1.Rows[e.RowIndex].Selected == false)
                    {
                        rowMergeView1.ClearSelection();
                        rowMergeView1.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (rowMergeView1.SelectedRows.Count == 1)
                    {
                        if (e.ColumnIndex != -1) //选中表头了
                            rowMergeView1.CurrentCell = rowMergeView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        else
                            rowMergeView1.CurrentCell = rowMergeView1.Rows[e.RowIndex].Cells[0];
                    }
                    //弹出操作菜单

                    cmsDgv.Show(MousePosition.X, MousePosition.Y);

                }
            }
        }

        private void dgvHasExported_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {

                    //若行已是选中状态就不再进行设置
                    //如果没选中当前活动行则选中这一行
                    if (dgvHasExported.Rows[e.RowIndex].Selected == false)
                    {
                        dgvHasExported.ClearSelection();
                        dgvHasExported.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dgvHasExported.SelectedRows.Count == 1)
                    {
                        if (e.ColumnIndex != -1) //选中表头了
                            dgvHasExported.CurrentCell = dgvHasExported.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        else
                            dgvHasExported.CurrentCell = dgvHasExported.Rows[e.RowIndex].Cells[0];
                    }
                    //弹出操作菜单

                    cmsDgvHasExported.Show(MousePosition.X, MousePosition.Y);

                }
            }
        }
        #endregion



        #region 按钮事件
        private void btnToday_Click(object sender, EventArgs e)
        {

            txtFrom.Text = DateTimeFormator.DateTimeToString(DateTime.Now, DateTimeFormator.TimeFormat.Type07DayStart);
            txtTo.Text = DateTimeFormator.DateTimeToString(DateTime.Now, DateTimeFormator.TimeFormat.Type08DayEnd);

        }

        private void btnYestoday_Click(object sender, EventArgs e)
        {
            txtFrom.Text = DateTimeFormator.DateTimeToString(DateTime.Now.AddDays(-1.0), DateTimeFormator.TimeFormat.Type07DayStart);
            txtTo.Text = DateTimeFormator.DateTimeToString(DateTime.Now, DateTimeFormator.TimeFormat.Type08DayEnd);
        }

        private void btnPre2Day_Click(object sender, EventArgs e)
        {
            txtFrom.Text = DateTimeFormator.DateTimeToString(DateTime.Now.AddDays(-2.0), DateTimeFormator.TimeFormat.Type07DayStart);
            txtTo.Text = DateTimeFormator.DateTimeToString(DateTime.Now, DateTimeFormator.TimeFormat.Type08DayEnd);
        }

        private void btnPre7Days_Click(object sender, EventArgs e)
        {
            txtFrom.Text = DateTimeFormator.DateTimeToString(DateTime.Now.AddDays(-7.0), DateTimeFormator.TimeFormat.Type07DayStart);
            txtTo.Text = DateTimeFormator.DateTimeToString(DateTime.Now, DateTimeFormator.TimeFormat.Type08DayEnd);
        }

        private void btnPre2Week_Click(object sender, EventArgs e)
        {
            txtFrom.Text = DateTimeFormator.DateTimeToString(DateTime.Now.AddDays(-14.0), DateTimeFormator.TimeFormat.Type07DayStart);
            txtTo.Text = DateTimeFormator.DateTimeToString(DateTime.Now, DateTimeFormator.TimeFormat.Type08DayEnd);
        }

        private void btnPreAMonth_Click(object sender, EventArgs e)
        {
            txtFrom.Text = DateTimeFormator.DateTimeToString(DateTime.Now.AddMonths(-1), DateTimeFormator.TimeFormat.Type07DayStart);
            txtTo.Text = DateTimeFormator.DateTimeToString(DateTime.Now, DateTimeFormator.TimeFormat.Type08DayEnd);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            try
            {
                //_listHasExpportedDgv =
                //    _bllHasExported8Report.GetHasExportedVisaInfoOfTimeSpan(DateTime.Parse(txtFrom.Text),
                //        //DateTime.Parse(txtTo.Text));
                _listHasExpportedDgv = _bllVisaInfo.GetDelayList();
                dgvHasExported.DataSource = _listHasExpportedDgv;
            }
            catch (Exception)
            {
                return;
                throw;
            }

        }

        #endregion


    }
}
