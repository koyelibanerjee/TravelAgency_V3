using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.BLL;
using TravelAgency.Common;

namespace TravelAgency.CSUI.Financial.FrmSub
{
    public partial class FrmSetCharge : Form
    {

        private List<Model.Visa> _list;
        private BLL.ConsulateCharge _bllConsulateCharge = new ConsulateCharge();
        private BLL.ClientCharge _bllClientCharge = new ClientCharge();
        private BLL.Visa _bllVisa = new BLL.Visa();
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托
        private readonly int _curPage; //主界面更新数据库需要一个当前页


        private FrmSetCharge()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            FrmsManager.FormSetCharge = this;
            InitializeComponent();
        }

        public FrmSetCharge(List<Model.Visa> list, Action<int> updateDel, int curPage)
        : this()
        {
            //_list = list.ToObjectCopy(); //直接复制list有问题，换成单个复制
            _list = new List<Model.Visa>();
            foreach (var visa in list)
            {
                _list.Add(visa.ToObjectCopy());
            }

            _updateDel = updateDel;
            _curPage = curPage;
        }

        private void FrmSetCharge_Load(object sender, EventArgs e)
        {

            dataGridView1.AutoGenerateColumns = false; //不显示指定之外的列
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; //列宽自适应,一定不能用AllCells
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders; //这里也一定不能AllCell自适应!
            dataGridView1.Columns["GroupNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.ReadOnly = false;
            for (int i = 0; i <= 27; ++i)
            {
                if (i < 17)
                    dataGridView1.Columns[i].ReadOnly = true;
                //else dataGridView1.Columns[i].ReadOnly = false; //这些列可编辑
            }
            dataGridView1.RowsAdded += DataGridView1_RowsAdded;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            
            dataGridView1.DefaultCellStyle.Font = new Font("微软雅黑", 9.0f, FontStyle.Bold);
            dataGridView1.DataSource = _list;


            this.Closing += FrmSetCharge_Closing;

        }

        private void FrmSetCharge_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (FrmsManager.FormSetCharge != null)
                FrmsManager.FormSetCharge = null;
        }

        public void AddVisa(List<Model.Visa> visaList)
        {
            var list = dataGridView1.DataSource as List<Model.Visa>;
            list.AddRange(visaList);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
            _list = list;
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateMoneyCount();
        }

        private void UpdateMoneyCount()
        {
            decimal num = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                object value = dataGridView1.Rows[i].Cells["ConsulateCost"].Value;
                num += value == null ? 0 : decimal.Parse(value.ToString());
                 value = dataGridView1.Rows[i].Cells["VisaPersonCost"].Value;
                num += value == null ? 0 : decimal.Parse(value.ToString());
                //value = dataGridView1.Rows[i].Cells["InvitationCost"].Value;
                //num += value == null ? 0 : decimal.Parse(value.ToString());
                //value = dataGridView1.Rows[i].Cells["Receipt"].Value;
                //num += value == null ? 0 : decimal.Parse(value.ToString());

            }
            lbMoneyCount.Text = "共" + num + "元.";
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Client" || colName == "Receipt")
            {
                var list = GetClientCharges(e.RowIndex);
                if (list.Count <= 0)
                {
                    MessageBoxEx.Show("未找到相关记录，请手动录入!");
                    return;
                }
                FrmSelClientCharge frm = new FrmSelClientCharge(list);
                if (frm.ShowDialog() == DialogResult.Cancel)
                    return;
                string country = GetCellValue(e.RowIndex, "Country");
                string type = GetCellValue(e.RowIndex, "Types");
                string depatureType = GetCellValue(e.RowIndex, "DepartureType");
                string client = GetCellValue(e.RowIndex, "Client");
                if (frm.ChangeAllAlike)//全部一起修改
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (GetCellValue(i, "Country") == country && GetCellValue(i, "Types") == type &&
                            GetCellValue(i, "DepartureType") == depatureType && GetCellValue(i, "client") == client)
                        {
                            dataGridView1.Rows[i].Cells["Receipt"].Value = list[frm.SelIdx].Charge;
                        }
                    }
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells["Receipt"].Value = list[frm.SelIdx].Charge;
                }
            }
            else
            {
                var list = GetConsulateCharges(e.RowIndex);
                if (list.Count <= 0)
                {
                    MessageBoxEx.Show("未找到相关记录，请手动录入!");
                    return;
                }


                FrmSelConsulateCharge frm = new FrmSelConsulateCharge(list);
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                string country = GetCellValue(e.RowIndex, "Country");
                string type = GetCellValue(e.RowIndex, "Types");
                string depatureType = GetCellValue(e.RowIndex, "DepartureType");

                if (frm.ChangeAllAlike)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (GetCellValue(i, "Country") == country && GetCellValue(i, "Types") == type &&
                            GetCellValue(i, "DepartureType") == depatureType)
                        {
                            dataGridView1.Rows[i].Cells["ConsulateCost"].Value = list[frm.SelIdx].ConsulateCost;
                            dataGridView1.Rows[i].Cells["InvitationCost"].Value = list[frm.SelIdx].InvitationCost;
                            //dataGridView1.Rows[i].Cells["VisaPersonCost"].Value = list[frm.SelIdx].VisaPersonCost;
                        }
                    }
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells["ConsulateCost"].Value = list[frm.SelIdx].ConsulateCost;
                    dataGridView1.Rows[e.RowIndex].Cells["InvitationCost"].Value = list[frm.SelIdx].InvitationCost;
                    //dataGridView1.Rows[e.RowIndex].Cells["VisaPersonCost"].Value = list[frm.SelIdx].VisaPersonCost;

                }
            }
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

                    var list = GetConsulateCharges(i);
                    var list1 = GetClientCharges(i);
                    if (list.Count > 0)
                    {
                        dataGridView1.Rows[i].Cells["ConsulateCost"].Value = list[0].ConsulateCost;
                        //dataGridView1.Rows[i].Cells["InvitationCost"].Value = list[0].InvitationCost;
                        dataGridView1.Rows[i].Cells["VisaPersonCost"].Value = list[0].VisaPersonCost;
                    }

                    if (list1.Count > 0)
                    {
                        //dataGridView1.Rows[i].Cells["Receipt"].Value = list1[0].Charge;
                    }

                }
                //执行绑定数据
            }
        }

        private string GetCellValue(int rowidx, string colname)
        {
            if (dataGridView1.Rows[rowidx].Cells[colname].Value != null)
                return dataGridView1.Rows[rowidx].Cells[colname].Value.ToString();
            else
                return null;
        }

        /// <summary>
        /// 查询指定行的配置条目
        /// </summary>
        /// <returns></returns>
        private List<Model.ConsulateCharge> GetConsulateCharges(int rowidx)
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

        /// <summary>
        /// 查询指定行的配置条目
        /// </summary>
        /// <returns></returns>
        private List<Model.ClientCharge> GetClientCharges(int rowidx)
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

            str = GetCellValue(rowidx, "Client");

            if (!string.IsNullOrEmpty(str))
            {
                conditions.Add(" (Client like  '%" + str + "%') ");
                //sb.Append(" Types='" + cbType.Text + "'");
            }

            string[] arr = conditions.ToArray();
            string where = string.Join(" and ", arr);

            var list = _bllClientCharge.GetModelList(where);
            return list;
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("是否提交?", "提醒", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            int res = _bllVisa.UpdateList(dataGridView1.DataSource as List<Model.Visa>);
            GlobalUtils.MessageBoxWithRecordNum("更新", res, _list.Count);

            ////再把没有加入的加入记录之中
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    if (GetClientCharges(i,true).Count == 0)
            //    {
            //        //执行加入
            //    }
            //}


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
