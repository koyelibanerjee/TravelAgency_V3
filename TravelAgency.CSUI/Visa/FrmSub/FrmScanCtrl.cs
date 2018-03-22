using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TravelAgency.Common;
using TravelAgency.Common.PictureHandler;
using TravelAgency.CSUI.Properties;

namespace TravelAgency.CSUI.FrmSub
{
    public partial class FrmScanCtrl : Form
    {
        //private Model.VisaInfo _model; //当前对应的所有编辑框对应的model
        private List<Model.VisaInfo> _list; //当前dgv对应的list
        private readonly BLL.VisaInfo _bllVisaInfo = new BLL.VisaInfo();
        private int _curIdx = 0;
        private int _recordCount = 0;
        private FrmScanCtrl()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
        }

        public FrmScanCtrl(List<Model.VisaInfo> list)
            : this()
        {
            _list = list;
            _curIdx = 0;
            _recordCount = _list.Count;
        }

        #region 拍照窗口按钮事件
        /// <summary>
        /// 开始预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            axScanCtrl1.StartPreview();
        }

        /// <summary>
        /// 关闭视频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            axScanCtrl1.StopPreview();
        }

        /// <summary>
        /// 属性按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            axScanCtrl1.Property();
        }


        /// <summary>
        /// 放大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            axScanCtrl1.SetZoomIn();
        }

        /// <summary>
        /// 缩小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            axScanCtrl1.SetZoomOut();
        }

        /// <summary>
        /// 拍照按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            var model = _list[_curIdx];
            axScanCtrl1.Scan(txtPicPath.Text + "\\" + _list[_curIdx].Name + "_" + _list[_curIdx].PassportNo + ".jpg"); //传的参数就是存储路径

            string filename = txtPicPath.Text + "\\" + _list[_curIdx].Name + "_" + _list[_curIdx].PassportNo + ".jpg";
            PicHandler.MakeThumbnail(filename, GaopaiPicHandler.GetThumbName(filename), GlobalUtils.ThumbNailRatio);
            //model.HasTypeIn = Common.Enums.HasTypeIn.Yes;
            if (_curIdx < _recordCount - 1)
                _curIdx += 1;
            UpdateState();
            //updateState (上一条下一条更新，已做的移到底下)

            //处理图片命名逻辑
            //var model = DgvDataToList()[_curIdx];
            //model.HasTypeIn

            //实现一个加载图像的函数
        }

        #endregion

        #region combobox等事件
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            axScanCtrl1.SetVideoColor((short)comboBox5.SelectedIndex);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            axScanCtrl1.SetVideoRotate((short)comboBox4.SelectedIndex);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            axScanCtrl1.SetScanSize((short)comboBox3.SelectedIndex);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            axScanCtrl1.SetResolution((short)comboBox2.SelectedIndex);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            axScanCtrl1.SetCurDev((short)comboBox1.SelectedIndex);

            short i;

            comboBox2.Items.Clear();
            int iResCount = axScanCtrl1.GetResolutionCount();
            for (i = 0; i < iResCount; ++i)
            {
                short s1 = axScanCtrl1.GetResolutionWidth(i);
                short s2 = axScanCtrl1.GetResolutionHeight(i);
                string s = s1.ToString() + " * " + s2.ToString();
                comboBox2.Items.Add(s);
            }
            comboBox2.SelectedIndex = 0;

            comboBox3.Items.Clear();
            int iSize = axScanCtrl1.GetScanSizeCount();
            comboBox3.Items.Add("All");
            if (iSize > 1)
            {
                if (iSize == 8)
                {
                    comboBox3.Items.Add("A3");
                }
                comboBox3.Items.Add("A4");
                comboBox3.Items.Add("A5");
                comboBox3.Items.Add("A6");
                comboBox3.Items.Add("A7");
                comboBox3.Items.Add("名片");
                comboBox3.Items.Add("身份证");
            }
            comboBox3.Items.Add("自定义");
            comboBox3.SelectedIndex = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            axScanCtrl1.SetRotateCrop(checkBox1.Checked);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            axScanCtrl1.DelBackColor(checkBox2.Checked);
        }
        #endregion

        private void LoadWindow(object sender, EventArgs e)
        {
            #region 初始化控件
            short i;

            comboBox1.Items.Clear();
            int iDevCount = axScanCtrl1.GetDeviceCount();
            for (i = 0; i < iDevCount; ++i)
            {
                string s = axScanCtrl1.GetDevName(i);
                comboBox1.Items.Add(s);
            }
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            comboBox2.Items.Clear();
            int iResCount = axScanCtrl1.GetResolutionCount();
            for (i = 0; i < iResCount; ++i)
            {
                short s1 = axScanCtrl1.GetResolutionWidth(i);
                short s2 = axScanCtrl1.GetResolutionHeight(i);
                string s = s1.ToString() + " * " + s2.ToString();
                comboBox2.Items.Add(s);
            }
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;

            comboBox3.Items.Clear();
            int iSize = axScanCtrl1.GetScanSizeCount();
            comboBox3.Items.Add("All");
            if (iSize > 1)
            {
                if (iSize == 8)
                {
                    comboBox3.Items.Add("A3");
                }
                comboBox3.Items.Add("A4");
                comboBox3.Items.Add("A5");
                comboBox3.Items.Add("A6");
                comboBox3.Items.Add("A7");
                comboBox3.Items.Add("名片");
                comboBox3.Items.Add("身份证");
            }
            comboBox3.Items.Add("自定义");
            if (comboBox3.Items.Count > 0)
                comboBox3.SelectedIndex = 0;

            comboBox4.Items.Clear();
            comboBox4.Items.Add("0度");
            comboBox4.Items.Add("90度");
            comboBox4.Items.Add("180度");
            comboBox4.Items.Add("270度");
            comboBox4.SelectedIndex = 0;

            comboBox5.Items.Clear();
            comboBox5.Items.Add("彩色");
            comboBox5.Items.Add("灰度");
            comboBox5.Items.Add("黑白");
            comboBox5.SelectedIndex = 0;
            #endregion
            //初始化控件
            txtPicPath.Text = GlobalUtils.LocalPassportPicPath;
            btnPre.Enabled = false;
            dgvWait4Scan.AutoGenerateColumns = false; //dgv初始化
            dgvWait4Scan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvWait4Scan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWait4Scan.MultiSelect = false;
            txtCheckPerson.Text = GlobalUtils.LoginUser.UserName; //初始化操作员
            txtCheckPerson.Enabled = false;
            txtPicPath.Enabled = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            dgvWait4Scan.DataSource = _list;
            //dgvWait4Scan.RowsAdded += DgvWait4CheckOnRowsAdded;
            dgvWait4Scan.CellClick += DgvWait4CheckOnCellClick;
            ////加载数据（list和dgv的数据都在这里面）,会加载之前还没有进行校验的那些VisaInfo_Tmp
            //LoadDataToList();
            btnPre.Click += btnPre_Click;
            btnNext.Click += btnNext_Click;
            ////初始化bar栏及按钮状态及图片控件
            //UpdateState();
        }


        #region dgv响应
        private void dgvWait4Scan_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dgvWait4Scan.Rows.Count; i++)
            {
                DataGridViewRow row = dgvWait4Scan.Rows[i];
                row.HeaderCell.Value = (i + 1).ToString(); //添加行号显示
            }
        }

        /// <summary>
        /// 单击选中行时，修改对应编辑框等项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvWait4CheckOnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _recordCount)
            {
                _curIdx = e.RowIndex;
                UpdateState();
            }
        }
        #endregion

        #region dgv窗体按钮事件
        private void btnPre_Click(object sender, EventArgs e)
        {
            --_curIdx;
            UpdateState();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ++_curIdx;
            UpdateState();
        }
        #endregion
        #region 公共函数

        private void LoadImageFromModel(Model.VisaInfo model)
        {
            if (proPictureBox1.Image != null)
                proPictureBox1.Image.Dispose();

            if (_list[_curIdx] == null)
            {
                proPictureBox1.Image = Resources.PassportPictureNotFound;
                return;
            }

            //if (!PassportPicHandler.CheckAndDownloadIfNotExist(model.PassportNo, PassportPicHandler.PicType.Type01Normal))
            //{
            //    proPictureBox1.Image = Resources.PassportPictureNotFound;
            //    return;
            //}
            //proPictureBox1.Image = GlobalUtils.LoadImageFromFileNoBlock(GlobalUtils.PassportPicPath + "\\" + model.PassportNo + ".jpg");
            if (File.Exists(txtPicPath.Text + "\\" + _list[_curIdx].Name + "_" + _list[_curIdx].PassportNo + ".jpg"))
                proPictureBox1.Image = Image.FromFile(txtPicPath.Text + "\\" + _list[_curIdx].Name + "_" + _list[_curIdx].PassportNo + ".jpg");
            else
                proPictureBox1.Image = Resources.PassportPictureNotFound;
        }

        List<Model.VisaInfo> DgvDataToList()
        {
            return dgvWait4Scan.DataSource as List<Model.VisaInfo>;
        }

        /// <summary>
        /// 根据curIdx更新标签，待检查数量，_model,picbox,ctrls,dgv显示
        /// </summary>
        public void UpdateState()
        {
            _recordCount = _list.Count;

            if (_curIdx == 0 || _recordCount == 0)
                btnPre.Enabled = false;
            else
                btnPre.Enabled = true;
            if (_curIdx == _recordCount - 1 || _recordCount == 0)
                btnNext.Enabled = false;
            else
                btnNext.Enabled = true;

            lbRecordCount.Text = "待扫描信息:" + _recordCount + "条.";
            //if (_recordCount == 0)
            //ClearCtrls();



            if (_list[_curIdx].HasTypeIn == Common.Enums.HasTypeIn.Yes)
            {
                proPictureBox1.BringToFront();
                button6.Enabled = false;
                if (_list.Count > _curIdx)
                {
                    //_model = _list[_curIdx];
                    //ModelToCtrls(_list[_curIdx];);
                    LoadImageFromModel(_list[_curIdx]);
                }
            }
            else
            {
                axScanCtrl1.BringToFront();
                button6.Enabled = true;
            }

            //更新dgv显示
            int curSelectedCol = -1; //保持列选中，有点问题还
            if (dgvWait4Scan.SelectedCells.Count > 0)
                curSelectedCol = dgvWait4Scan.SelectedCells[0].ColumnIndex;

            dgvWait4Scan.DataSource = null;
            if (_list != null && _list.Count > 0) //这里必须判断count大于0，不然有bug,参见https://www.cnblogs.com/seasons1987/p/3513135.html
                dgvWait4Scan.DataSource = _list;
            //if (_recordCount == 0)
            //    return;
            if (curSelectedCol != -1 && dgvWait4Scan.Rows.Count > _curIdx)
                dgvWait4Scan.CurrentCell = dgvWait4Scan.Rows[_curIdx].Cells[curSelectedCol];
        }
        #endregion

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            _list[_curIdx].HasTypeIn = Common.Enums.HasTypeIn.No;
            UpdateState();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            int res = 0;
            for (int j = 0; j < _list.Count; j++)
            {
                res += _bllVisaInfo.Update(_list[j]) ? 1 : 0; //在这里也可以设置为未录入
            }
            GlobalUtils.MessageBoxWithRecordNum("修改", res, _list.Count);
        }

        private void FrmScanCtrl_FormClosing(object sender, FormClosingEventArgs e)
        {
            button2_Click(null,null);
        }
    }
}
