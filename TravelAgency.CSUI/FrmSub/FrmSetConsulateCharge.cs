﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.BLL;
using TravelAgency.Common;

namespace TravelAgency.CSUI.FrmSub
{
    public partial class FrmSetConsulateCharge : Form
    {

        private List<Model.Visa> _list;
        private BLL.ConsulateCharge _bllConsulateCharge = new ConsulateCharge();
        private BLL.Visa _bllVisa = new Visa();
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托
        private readonly int _curPage; //主界面更新数据库需要一个当前页


        private FrmSetConsulateCharge()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            InitializeComponent();
        }

        public FrmSetConsulateCharge(List<Model.Visa> list, Action<int> updateDel, int curPage)
        : this()
        {
            _list = list;
            _updateDel = updateDel;
            _curPage = curPage;
        }

        private void FrmSetConsulateCharge_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false; //不显示指定之外的列
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; //列宽自适应
            dataGridView1.Columns["GroupNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.ReadOnly = false;
            for (int i = 0; i <= 27; ++i)
            {
                if (i < 17)
                    dataGridView1.Columns[i].ReadOnly = true;
                //else dataGridView1.Columns[i].ReadOnly = false; //这些列可编辑
            }
            dataGridView1.RowsAdded += DataGridView1_RowsAdded;
            dataGridView1.DefaultCellStyle.Font = new Font("微软雅黑", 9.0f, FontStyle.Bold);
            dataGridView1.DataSource = _list;
        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                if (dataGridView1.Rows[i].Cells["Country"].Value != null)
                {
                    string countryName = dataGridView1.Rows[i].Cells["Country"].Value.ToString();
                    dataGridView1.Rows[i].Cells["CountryImage"].Value =
                       TravelAgency.Common.CountryPicHandler.LoadImageByCountryName(countryName);

                    var list = GetThePays(i);
                    if (list.Count > 0)
                    {
                        dataGridView1.Rows[i].Cells["ConsulateCost"].Value = list[0].ConsulateCost;
                        dataGridView1.Rows[i].Cells["InvitationCost"].Value = list[0].InvitationCost;
                        dataGridView1.Rows[i].Cells["VisaPersonCost"].Value = list[0].VisaPersonCost;
                    }
                }
                //执行绑定数据
            }
        }

        private string GetCellValue(int rowidx, string colname)
        {
            return dataGridView1.Rows[rowidx].Cells[colname].Value.ToString();
        }

        /// <summary>
        /// 根据Combobox选中项查询数据库
        /// </summary>
        /// <returns></returns>
        private List<Model.ConsulateCharge> GetThePays(int rowidx)
        {
            List<string> conditions = new List<string>();
            string str = GetCellValue(rowidx, "DepartureType");
            if (!string.IsNullOrEmpty(str))
            {
                //sb.Append(" DepartureType='" + cbDepartureType.Text + "'");

                conditions.Add(" (DepartureType like  '%" + str + "%') ");
            }
            str = GetCellValue(rowidx, "Country");

            if (!string.IsNullOrEmpty(str))
            {
                //sb.Append(" Country='" + cbCountry.Text + "'");
                conditions.Add(" (Country like  '%" + str + "%') ");

            }
            str = GetCellValue(rowidx, "Types");

            if (!string.IsNullOrEmpty(str))
            {
                conditions.Add(" (Types like  '%" + str + "%') ");
                //sb.Append(" Types='" + cbType.Text + "'");
            }

            string[] arr = conditions.ToArray();
            string where = string.Join(" and ", arr);

            var list = _bllConsulateCharge.GetModelList(where);
            return list;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("是否提交?", "提醒", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            int res = _bllVisa.UpdateList(dataGridView1.DataSource as List<Model.Visa>);
            GlobalUtils.MessageBoxWithRecordNum("更新", res, _list.Count);
            this.DialogResult = DialogResult.OK;
            this.Close();
            _updateDel(_curPage);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
