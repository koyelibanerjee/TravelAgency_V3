using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.BLL;
using TravelAgency.Common;
using TravelAgency.Common.Enums;
using TravelAgency.Common.QRCode;
using TravelAgency.CSUI.FrmSub;
using TravelAgency.CSUI.Properties;
using VisaInfo = TravelAgency.Model.VisaInfo;

namespace TravelAgency.CSUI.FrmMain
{

    public partial class FrmVisaInfoSubmitDetails : Form
    {
        private readonly TravelAgency.BLL.VisaInfo bll = new TravelAgency.BLL.VisaInfo();
        private readonly BLL.ActionRecords _bllActionRecords = new ActionRecords();
        //private int _curPage = 1;
        private int _pageCount = 0;
        private int _pageSize = 30;
        private int _recordCount = 0;
        private string _preTxt = string.Empty;
        private string _outState = string.Empty; //Single模式下的状态设置
        private Inputmode _inputMode = Inputmode.Single;
        private readonly MyQRCode _qrCode = new MyQRCode();
        //private readonly Thread _thLoadDataToDgvAndUpdateState;
        private List<Model.VisaInfo> _list;

        private Action<int> _updateDel;
        private int _curPage;

        public FrmVisaInfoSubmitDetails(List<Model.VisaInfo> list, Action<int> updateDel, int curPage)
        {
            InitializeComponent();
            _list = list;
            //_thLoadDataToDgvAndUpdateState = new Thread(LoadAndUpdate);
            //_thLoadDataToDgvAndUpdateState.IsBackground = true;
            _updateDel = updateDel;
            _curPage = curPage;
        }

        private void FrmVisaSubmit_Load(object sender, EventArgs e)
        {
            _recordCount = bll.GetRecordCount(string.Empty);
            _pageCount = (int)Math.Ceiling((double)_recordCount / _pageSize);
            cbPageSize.Items.Add("30");
            cbPageSize.Items.Add("50");
            cbPageSize.Items.Add("100");
            cbPageSize.SelectedIndex = 0;

            

            dataGridView1.AutoGenerateColumns = false; //不显示指定之外的列
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; //列宽自适应,一定不能用AllCells
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders; //这里也一定不能AllCell自适应!

            dataGridView1.DataSource = _list;
        }

        

        #region dgv用到的相关方法




        public void UpdateState()
        {
            _recordCount = bll.GetRecordCount(string.Empty);
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
            lbRecordCount.Text = "共有记录:" + _recordCount + "条";
            lbCurPage.Text = "当前为第" + _curPage + "页";
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

                if (!string.IsNullOrEmpty((string)row.Cells["EnglishName"].Value) && !string.IsNullOrEmpty((string)row.Cells["PassportNo"].Value))
                {
                    dataGridView1.Rows[i].Cells["QRCodeImage"].Value = _qrCode.EncodeToImage(row.Cells["EnglishName"].Value + "|" + row.Cells["PassportNo"].Value,
                        QRCodeSaveSize.Size165X165);
                }

                // 根据送签状态设置单元格颜色
                if (dataGridView1.Rows[i].Cells["outState"].Value != null)
                {
                    Color c = Color.Empty;
                    //string state = e.Value.ToString();
                    string state = dataGridView1.Rows[i].Cells["outState"].Value.ToString();
                    if (state == OutState.Type01NoRecord || state == OutState.TYPE10Exported)
                        c = Color.AliceBlue;
                    else if (state == OutState.Type01Delay)
                        c = Color.DarkOrange;
                    else if (state == OutState.Type02In)
                        c = Color.Yellow;
                    else if (state == OutState.Type03NormalOut)
                        c = Color.Green;
                    else if (state == OutState.TYPE04AbnormalOut)
                        c = Color.Red;
                    else
                        c = Color.Black;
                    dataGridView1.Rows[i].Cells["outState"].Style.BackColor = c;
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
                if (e.RowIndex >= 0)
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
                    cmsDgvRb.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var row = dataGridView1.CurrentRow;
                if (!string.IsNullOrEmpty((string)row.Cells["EnglishName"].Value) && !string.IsNullOrEmpty((string)row.Cells["PassportNo"].Value))
                {
                    FrmQRCode frm = new FrmQRCode((dataGridView1.DataSource as List<VisaInfo>)[dataGridView1.SelectedRows[0].Index]);
                    //frm.ShowDialog();
                    frm.Show(this);
                }
            }
        }
        #endregion

        #region dgv右键菜单相应


        /// <summary>
        /// 查看单个二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showQRCode_Click(object sender, EventArgs e)
        {

            if (this.dataGridView1.SelectedRows.Count > 1)
            {
                MessageBoxEx.Show(Resources.SelectShowMoreThanOne);
                return;
            }

            string passportNo = dataGridView1.SelectedRows[0].Cells["PassportNo"].Value.ToString();
            string name = dataGridView1.SelectedRows[0].Cells["EnglishName"].Value.ToString();

            FrmQRCode dlg = new FrmQRCode((dataGridView1.DataSource as List<VisaInfo>)[dataGridView1.SelectedRows[0].Index]);
            //dlg.ShowDialog();
            dlg.Show();
        }

        /// <summary>
        /// 批量生成二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmsItemQRCodeBatchGenerate_Click(object sender, EventArgs e)
        {
            int count = this.dataGridView1.SelectedRows.Count;

            //选择保存路径
            string path = GlobalUtils.ShowBrowseFolderDlg();
            if (string.IsNullOrEmpty(path))
                return;
            for (int i = 0; i != count; ++i)
            {
                string passportNo = dataGridView1.SelectedRows[i].Cells["PassportNo"].Value.ToString();
                string name = dataGridView1.SelectedRows[i].Cells["EnglishName"].Value.ToString();
                _qrCode.EncodeToPng(passportNo + "|" + name, path + "\\" + passportNo + ".jpg", QRCodeSaveSize.Size660X660);
                
            }

            MessageBoxEx.Show("成功保存" + count + "条记录二维码.");
        }


        private void 复制二维码信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = dataGridView1.SelectedRows.Count - 1; i >= 0; --i)
            {
                string passportNo = dataGridView1.SelectedRows[i].Cells["PassportNo"].Value.ToString();
                string name = dataGridView1.SelectedRows[i].Cells["EnglishName"].Value.ToString();
                sb.Append(passportNo + "|" + name);
                sb.Append("\r\n");
            }
            Clipboard.SetText(sb.ToString());
        }

        private void 更改送签状态ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 1)
            {
                MessageBoxEx.Show(Resources.SelectShowMoreThanOne);
                return;
            }
            FrmSetSubmitStatus frm = new FrmSetSubmitStatus(
                (dataGridView1.DataSource as List<Model.VisaInfo>)[dataGridView1.SelectedRows[0].Index],
                dataGridView1.SelectedRows[0].Cells["outState"].Value.ToString(),_updateDel,_curPage);
            frm.ShowDialog();
        }

        #endregion


    }
}
