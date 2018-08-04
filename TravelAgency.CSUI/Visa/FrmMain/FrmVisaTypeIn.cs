using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.Common;
using TravelAgency.Common.FTP;
using TravelAgency.Common.IDCard;
using TravelAgency.Common.PinyinParse;
using TravelAgency.CSUI.FrmSub;
using TravelAgency.CSUI.Properties;
using TravelAgency.Model;
using System.Configuration;
using TravelAgency.BLL.FTPFileHandler;
using TravelAgency.CSUI.Visa.FrmSub;

namespace TravelAgency.CSUI.FrmMain
{
    public partial class FrmVisaTypeIn : Form
    {
        private Model.VisaInfo_Tmp _model; //当前对应的所有编辑框对应的model
        private List<Model.VisaInfo_Tmp> _list; //当前dgv对应的list
        private readonly BLL.VisaInfo_Tmp _bllVisaInfoTmp = new BLL.VisaInfo_Tmp();
        private int _curIdx = 0;
        private int _recordCount = 0;
        private readonly IDCard _idCard = new IDCard();
        private bool _autoReadThreadRun = false;
        //private bool _autoReadThreadPending = false;
        private string _country = string.Empty;
        public FrmVisaTypeIn()
        {
            InitializeComponent();
        }


        private void FrmCheckAutoInputInfo_Load(object sender, EventArgs e)
        {
            //初始化控件
            txtPicPath.Text = GlobalUtils.LocalPassportPicPath;
            checkShowConfirm.Checked = false;
            checkRegSucShowDlg.Checked = false;
            picPassportNo.SizeMode = PictureBoxSizeMode.Zoom;
            btnPre.Enabled = false;
            dgvWait4Check.AutoGenerateColumns = false; //dgv初始化
            dgvWait4Check.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; //列宽自适应,一定不能用AllCells
            dgvWait4Check.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders; //这里也一定不能AllCell自适应!
            dgvWait4Check.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWait4Check.MultiSelect = false;
            txtCheckPerson.Text = GlobalUtils.LoginUser.UserName; //初始化操作员
            txtCheckPerson.Enabled = false;
            txtPicPath.Enabled = false;
            radioNone.Checked = true;
            //debug用
            //txtLicenseTime.Text = DateTimeFormator.DateTimeToString(DateTime.Now);
            //txtBirthday.Text = DateTimeFormator.DateTimeToString(DateTime.Now);
            //txtExpireDate.Text = DateTimeFormator.DateTimeToString(DateTime.Now);

            //加载数据（list和dgv的数据都在这里面）,会加载之前还没有进行校验的那些VisaInfo_Tmp
            LoadDataToList();

            //初始化bar栏及按钮状态及图片控件
            UpdateState();

        }

        #region 状态更新函数
        private void ModelToCtrls(TravelAgency.Model.VisaInfo_Tmp model)
        {
            if (model == null)
            {
                txtName.Text = string.Empty;
                txtEnglishName.Text = string.Empty;
                txtSex.Text = string.Empty;
                txtBirthday.Text = string.Empty;
                txtPassNo.Text = string.Empty;
                txtLicenseTime.Text = string.Empty;
                txtExpireDate.Text = string.Empty;
                txtBirthPlace.Text = string.Empty;
                txtIssuePlace.Text = string.Empty;
                txtIssuePlaceEnglish.Text = string.Empty;
                txtBirthPlaceEnglish.Text = string.Empty;
                radioNone.Checked = true;
                return;
            }
            txtName.Text = model.Name;
            txtEnglishName.Text = model.EnglishName;
            txtSex.Text = model.Sex;
            txtBirthday.Text = model.Birthday.ToString();
            txtPassNo.Text = model.PassportNo;
            txtLicenseTime.Text = model.LicenceTime.ToString();
            txtExpireDate.Text = model.ExpiryDate.ToString();
            txtBirthPlace.Text = model.Birthplace;
            txtIssuePlace.Text = model.IssuePlace;
            txtIssuePlaceEnglish.Text = model.IssuePlaceEnglish;
            txtBirthPlaceEnglish.Text = model.BirthPlaceEnglish;
            if (model.Country == "日本")
                rbtnJapan.Checked = true;
            else if (model.Country == "韩国")
                rbtnKorea.Checked = true;
            else if (model.Country == "泰国")
                rbtnThailand.Checked = true;
            else
                radioNone.Checked = true;
        }

        /// <summary>
        /// 这里一定不能自己去new 一个model然后返回，会丢失掉原有的model里的其他信息!
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool CtrlsToModel(Model.VisaInfo_Tmp model)
        {
            try
            {
                model.Name = txtName.Text;
                model.EnglishName = txtEnglishName.Text;
                model.Sex = txtSex.Text;
                model.Birthday = DateTime.Parse(txtBirthday.Text);
                model.PassportNo = txtPassNo.Text;
                model.LicenceTime = DateTime.Parse(txtLicenseTime.Text);
                model.ExpiryDate = DateTime.Parse(txtExpireDate.Text);
                model.Birthplace = txtBirthPlace.Text;
                model.IssuePlace = txtIssuePlace.Text;
                model.BirthPlaceEnglish = txtBirthPlaceEnglish.Text;
                model.IssuePlaceEnglish = txtIssuePlaceEnglish.Text;
                if (!string.IsNullOrEmpty(_country))
                    model.Country = _country;
                else
                    model.Country = null;
                return true;
            }
            catch (Exception)
            {
                MessageBoxEx.Show(Resources.PleaseCheckDateTimeFormat);
                return false;
            }
        }

        private void LoadImageFromModel(Model.VisaInfo_Tmp model)
        {
            if (picPassportNo.Image != null)
                picPassportNo.Image.Dispose();
            if (model == null)
            {
                picPassportNo.Image = Resources.PassportPictureNotFound;
                return;
            }

            if (!PassportPicHandler.CheckAndDownloadIfNotExist(model.PassportNo, PassportPicHandler.PicType.Type01Normal))
            {
                picPassportNo.Image = Resources.PassportPictureNotFound;
                return;
            }

            picPassportNo.Image = GlobalUtils.LoadImageFromFileNoBlock(GlobalUtils.LocalPassportPicPath + "\\" + model.PassportNo + ".jpg");
        }

        /// <summary>
        /// 更新list以里的数据
        /// </summary>
        public void LoadDataToList() //刷新后保持选中
        {
            _list = _bllVisaInfoTmp.GetModelList(0, $" district = {GlobalUtils.LoginUser.District} ",
                "haschecked asc,entrytime desc"); //里面的DataTableToList保证了不会是null,只可能是空的list
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

            lbRecordCount.Text = "待校验信息:" + _recordCount + "条.";
            if (_recordCount == 0)
                ClearCtrls();

            if (_list.Count > _curIdx)
            {
                _model = _list[_curIdx];
                ModelToCtrls(_model);
                LoadImageFromModel(_model);
            }

            //设置保存图像按钮
            if (_model == null)
            {
                btnSaveAll.Enabled = false;
                btnSaveHeadPic.Enabled = false;
                btnSaveIR.Enabled = false;
                btnSavePic.Enabled = false;
            }
            else
            {
                btnSaveAll.Enabled = true;
                btnSaveHeadPic.Enabled = true;
                btnSaveIR.Enabled = true;
                btnSavePic.Enabled = true;
            }

            //更新dgv显示
            int curSelectedCol = -1; //保持列选中，有点问题还
            if (dgvWait4Check.SelectedCells.Count > 0)
                curSelectedCol = dgvWait4Check.SelectedCells[0].ColumnIndex;

            dgvWait4Check.DataSource = null;
            if (_list != null && _list.Count > 0) //这里必须判断count大于0，不然有bug,参见https://www.cnblogs.com/seasons1987/p/3513135.html
                dgvWait4Check.DataSource = _list;
            if (_recordCount == 0)
                return;
            if (curSelectedCol != -1 && dgvWait4Check.Rows.Count > _curIdx)
                dgvWait4Check.CurrentCell = dgvWait4Check.Rows[_curIdx].Cells[curSelectedCol];
        }

        private void ClearCtrls()
        {
            txtBirthPlace.Text = "";
            txtBirthday.Text = "";
            //txtCheckPerson.Text = "";
            txtEnglishName.Text = "";
            txtExpireDate.Text = "";
            txtIssuePlace.Text = "";
            txtLicenseTime.Text = "";
            txtName.Text = "";
            txtPassNo.Text = "";
            txtBirthPlace.Text = "";
            picPassportNo.Image = null;
            txtSex.Text = "";
            txtIssuePlaceEnglish.Text = "";
            txtBirthPlaceEnglish.Text = "";
        }

        #endregion



        #region 右边校验部分按钮点击事件
        /// <summary>
        /// 用来确认标志校验完毕的按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNoFault_Click(object sender, EventArgs e)
        {
            if (!CtrlsToModel(_model))
                return;
            _model.HasChecked = Model.Enums.HasChecked.Yes;
            _model.CheckPerson = txtCheckPerson.Text;
            if (!_bllVisaInfoTmp.Update(_model))
            {
                MessageBoxEx.Show(Resources.FailedUpdateVisaInfoState);
                return;
            }
            LoadDataToList();
            UpdateState();
        }

        /// <summary>
        /// 保存当前页的所有状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            //bool HasDataNotChecked = false;
            //for (int i = 0; i < _list.Count; i++)
            //{
            //    if (_list[i].HasChecked == Common.Enums.HasChecked.No)
            //    {
            //        HasDataNotChecked = true;
            //        break;
            //    }
            //}

            //if (HasDataNotChecked && MessageBoxEx.Show("还有数据未校验，保存修改将会丢失，是否继续?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            //    return;


            ////保存修改
            //int res = 0;
            //for (int i = 0; i < _list.Count; i++)
            //{
            //    if (_list[i].HasChecked == Common.Enums.HasChecked.Yes)
            //    {
            //        if (_list[i].VisaInfo_id.ToString() == "00000000-0000-0000-0000-000000000000" || string.IsNullOrEmpty(_list[i].VisaInfo_id.ToString()) ) //不存在的数据（新录入的）执行添加
            //            res += _bllVisaInfoTmp.Add(_list[i]) ? 1 : 0;
            //        else 
            //            res += _bllVisaInfoTmp.Update(_list[i]) ? 1 : 0; //以前存在的但是没校验的执行update
            //    }
            //}
            //MessageBoxEx.Show(res + "条记录更新成功.");
            ////重新从数据库加载数据
            //LoadDataToList();
            //_curIdx = 0;
            //UpdateState();

            //直接在数据库那边执行提交操作，从visainfo_tmp移动到visainfo，然后这边重新加载数据库就OK

            List<VisaInfo_Tmp> list = new List<VisaInfo_Tmp>();
            var visaInfoTmps
                = dgvWait4Check.DataSource as List<VisaInfo_Tmp>;
            if (visaInfoTmps != null)
                foreach (var visaInfoTmp in visaInfoTmps)
                {
                    if (visaInfoTmp.HasChecked == "是")
                        list.Add(visaInfoTmp);
                }

            //ExcelGenerator.GetPrintTable(list);


            int res = _bllVisaInfoTmp.MoveCheckedDataToVisaInfo();

            if (res <= 0)
                return;
            MessageBoxEx.Show(res + "条记录更新成功.");
            LoadDataToList();
            _curIdx = 0;
            UpdateState();
        }

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

        private void btnLoadKernel_Click(object sender, EventArgs e)
        {
            _idCard.LoadKernel();
        }

        private void btnFreeKernel_Click(object sender, EventArgs e)
        {
            _idCard.FreeKernel();
        }

        private void btnReadData_Click(object sender, EventArgs e)
        {
            VisaInfo_Tmp model = _idCard.RecogoInfo(txtPicPath.Text, checkRegSucShowDlg.Checked);

            //VisaInfo_Tmp model = new VisaInfo_Tmp(){Name = "杨小鹏",EnglishName = "Yang Xiaopeng",Sex = "男",PassportNo = "E12345678"};

            if (model == null)
                return;

            if (!string.IsNullOrEmpty(_country))
                model.Country = _country;
            else
                model.Country = null;
            model.EntryTime = DateTime.Now;

            //图像上传到服务器
            PassportPicHandler.UploadPassportPic(
                GlobalUtils.LocalPassportPicPath + "\\" + PassportPicHandler.GetFileName(model.PassportNo, PassportPicHandler.PicType.Type01Normal),
                model.PassportNo);

            //执行以下校验(用拼音来进行校验)
            if (!InfoChecker.CheckByPinYin(model.Name, model.EnglishName)) //检查到错误
            {
                ModelToCtrls(model);
                MessageBoxEx.Show("检查到拼音和汉字不符，请校验信息正确后执行手动添加!");
                //_curIdx = 0;
                //UpdateState();
                return;
            }

            //读取成功了
            if (_bllVisaInfoTmp.Add(model) == Guid.Empty)
            {
                MessageBoxEx.Show(Resources.FailedAddToDatabase);
                return;
            }
            LoadDataToList();
            _curIdx = 0;
            UpdateState();
        }

        /// <summary>
        /// 自动识别线程函数
        /// </summary>
        /// <param name="o"></param>
        private void AutoClassAndRecognize(object o)
        {
            while (_autoReadThreadRun)
            {
                Thread.Sleep(200);
                //if (_autoReadThreadPending)
                //    continue;
                Model.VisaInfo_Tmp model = _idCard.AutoClassAndRecognize(this.txtPicPath.Text, checkRegSucShowDlg.Checked);

                if (model != null)
                {
                    if (!string.IsNullOrEmpty(_country))
                        model.Country = _country;
                    else
                        model.Country = null;
                    model.EntryTime = DateTime.Now;

                    //把拍照的图像上传到服务器
                    PassportPicHandler.UploadPassportPic(
                        GlobalUtils.LocalPassportPicPath + "\\" + PassportPicHandler.GetFileName(model.PassportNo, PassportPicHandler.PicType.Type01Normal),
                        model.PassportNo);

                    if (!InfoChecker.CheckByPinYin(model.Name, model.EnglishName)) //检查到错误
                    {
                        ModelToCtrls(model);
                        MessageBoxEx.Show("检查到拼音和汉字不符，请校验信息正确后执行手动添加!");
                        btnAutoReadThreadStart_Click(null, null); //点击停止
                        //_curIdx = 0;
                        //UpdateState(); //这里不能updatestate，信息又会丢失如果列表里面有数据的话
                        continue;
                    }

                    //读取成功了
                    if (_bllVisaInfoTmp.Add(model) == Guid.Empty)
                    {
                        MessageBoxEx.Show(Resources.FailedAddToDatabase);
                        continue;
                    }
                    LoadDataToList();
                    _curIdx = 0;
                    UpdateState();
                }
            }
        }

        /// <summary>
        /// 开启自动识别线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoReadThreadStart_Click(object sender, EventArgs e)
        {
            if (!_idCard.KernelLoaded)
            {
                MessageBoxEx.Show("Please press load kernel button first!");
                return;
            }
            if (!_autoReadThreadRun)
            {
                btnAutoReadThreadStart.Text = "■停止自动读取";
                _autoReadThreadRun = true;
                Thread th = new Thread(AutoClassAndRecognize) { IsBackground = true };
                th.Start();
            }
            else
            {
                btnAutoReadThreadStart.Text = "开始自动读取";
                _autoReadThreadRun = false;
            }
        }

        /// <summary>
        /// 手动添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddToDatabase_Click(object sender, EventArgs e)
        {
            Model.VisaInfo_Tmp model = new VisaInfo_Tmp();
            if (!CtrlsToModel(model))
                return;
            model.EntryTime = DateTime.Now;

            if (!InfoChecker.CheckByPinYin(model.Name, model.EnglishName)) //检查到错误
            {
                if (DialogResult.Cancel ==
                    MessageBoxEx.Show("检查到拼音和汉字不符,是否继续添加?", "提示", MessageBoxButtons.OKCancel))
                {
                    return;
                }
            }

            //读取成功了
            //执行entrytime设置

            if (_bllVisaInfoTmp.Add(model) == Guid.Empty)
            {
                MessageBoxEx.Show(Resources.FailedAddToDatabase);
                return;
            }
            if (!PassportPicHandler.CheckLocalExist(model.PassportNo, PassportPicHandler.PicType.Type01Normal))
            {
                if (MessageBoxEx.Show("未找到对应护照图像，是否导入?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.Yes)
                {
                    if (
                        MessageBoxEx.Show("是否拍照导入?\r\n选择Yes从高拍仪扫描图像，选择No从本地文件导入。", "提示", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FrmScanCtrlImported frm = new FrmScanCtrlImported(model);//这个窗口里面把图像拷贝到了本地自己的目录
                        if (frm.ShowDialog() == DialogResult.Cancel)//点取消的情况没考虑，还得用while循环，太麻烦了
                            return;

                    }
                    else
                    {
                        string filename = GlobalUtils.ShowOpenFileDlg();
                        if (!string.IsNullOrEmpty(filename))
                        {
                            PassportPicHandler.CopyToPassportPic(filename, model.PassportNo, PassportPicHandler.PicType.Type01Normal);
                            //PassportPicHandler.UploadPassportPic(model.PassportNo);
                        }
                        else return;
                    }
                    //把拍照的图像上传到服务器
                    PassportPicHandler.UploadPassportPic(
                        GlobalUtils.LocalPassportPicPath + "\\" + PassportPicHandler.GetFileName(model.PassportNo, PassportPicHandler.PicType.Type01Normal),
                        model.PassportNo);
                }
            }
            LoadDataToList();
            _curIdx = 0;
            UpdateState();
        }

        private void btnAddFromImage_Click(object sender, EventArgs e)
        {

            FrmAddFromImage frm = new FrmAddFromImage();
            frm.Show();

        }


        #endregion
        #region dgv响应

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dgvWait4Check.Rows.Count; i++)
            {
                DataGridViewRow row = dgvWait4Check.Rows[i];
                row.HeaderCell.Value = (i + 1).ToString(); //添加行号显示
            }
        }

        /// <summary>
        /// 单击选中行时，修改对应编辑框等项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _recordCount)
            {
                _curIdx = e.RowIndex;
                UpdateState();
            }
        }

        #endregion

        private void btnSavePic_Click(object sender, EventArgs e)
        {
            if (_model == null)
            {
                return;
            }
            string fileName = PassportPicHandler.GetFileName(_model.PassportNo,
                PassportPicHandler.PicType.Type01Normal);
            string dstName =
                GlobalUtils.ShowSaveFileDlg(fileName);
            if (string.IsNullOrEmpty(dstName))
                return;

            PassportPicHandler.DownloadPic(_model.PassportNo, PassportPicHandler.PicType.Type01Normal, dstName);


        }

        private void btnSaveHeadPic_Click(object sender, EventArgs e)
        {
            if (_model == null)
            {
                return;
            }

            string fileName = PassportPicHandler.GetFileName(_model.PassportNo, PassportPicHandler.PicType.Type02Head);
            string dstName =
                GlobalUtils.ShowSaveFileDlg(fileName);
            if (string.IsNullOrEmpty(dstName))
                return;

            PassportPicHandler.DownloadPic(_model.PassportNo, PassportPicHandler.PicType.Type02Head, dstName);
        }

        private void btnSaveIR_Click(object sender, EventArgs e)
        {
            if (_model == null)
            {
                return;
            }
            string fileName = PassportPicHandler.GetFileName(_model.PassportNo, PassportPicHandler.PicType.Type03IR);
            string dstName =
                GlobalUtils.ShowSaveFileDlg(fileName);
            if (string.IsNullOrEmpty(dstName))
                return;

            PassportPicHandler.DownloadPic(_model.PassportNo, PassportPicHandler.PicType.Type03IR, dstName);
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            if (_model == null)
            {
                return;
            }

            string path = GlobalUtils.ShowBrowseFolderDlg();
            if (string.IsNullOrEmpty(path))
                return;
            int res = PassportPicHandler.DownloadSelectedTypes(_model.PassportNo, path);
            if (res > 0)
            {
                if (MessageBoxEx.Show("保存成功，是否打开所在文件夹?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Process.Start(path);
            }
            else
                MessageBoxEx.Show("保存失败");

        }

        private void btnUpLoadLocal_Click(object sender, EventArgs e)
        {
            //var localFileList = Directory.GetFiles(GlobalUtils.LocalPassportPicPath);
            //FtpHandler.ChangeFtpUri(ConfigurationManager.AppSettings["PassportPicPath"]);
            //int notexist = 0;
            //foreach (var localFile in localFileList)
            //{
            //    if (!FtpHandler.FileExist(Path.GetFileName(localFile)))
            //    {
            //        FtpHandler.Upload(localFile);
            //        notexist += 1;
            //    }
            //}
            //MessageBoxEx.Show("上传" + notexist + "张图像成功!");
            FrmUploadLocalImages frm = new FrmUploadLocalImages();
            frm.ShowDialog();
        }


        private void dgvWait4Check_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    //如果没选中当前活动行则选中这一行
                    if (dgvWait4Check.Rows[e.RowIndex].Selected == false)
                    {
                        dgvWait4Check.ClearSelection();
                        dgvWait4Check.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dgvWait4Check.SelectedRows.Count == 1)
                    {
                        if (e.ColumnIndex != -1) //选中表头了
                            dgvWait4Check.CurrentCell = dgvWait4Check.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        else
                        {
                            dgvWait4Check.CurrentCell = dgvWait4Check.Rows[e.RowIndex].Cells[0];
                        }
                        _curIdx = e.RowIndex;
                        UpdateState();
                    }
                    //弹出操作菜单
                    cmsDgvRb.Show(MousePosition.X, MousePosition.Y);

                }
            }
        }

        private void cmsItemDelete_Click(object sender, EventArgs e)
        {
            if (_model == null || MessageBoxEx.Show("确认删除?", Resources.Confirm, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            if (!_bllVisaInfoTmp.Delete(_model.VisaInfo_id))
            {
                MessageBoxEx.Show("删除失败!");
                return;
            }
            LoadDataToList();
            UpdateState();

        }

        private void rbtnJapan_CheckedChanged(object sender, EventArgs e)
        {
            _country = "日本";
        }

        private void radioNone_CheckedChanged(object sender, EventArgs e)
        {
            _country = string.Empty;
        }

        private void rbtnKorea_CheckedChanged(object sender, EventArgs e)
        {
            _country = "韩国";

        }

        private void rbtnThailand_CheckedChanged(object sender, EventArgs e)
        {
            _country = "泰国";
        }


    }
}
