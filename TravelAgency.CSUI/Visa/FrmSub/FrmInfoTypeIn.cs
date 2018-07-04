using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Telerik.WinControls.UI;
using TravelAgency.BLL;
using TravelAgency.BLL.FTPFileHandler;
using TravelAgency.Common;
using TravelAgency.Common.Enums;
using TravelAgency.CSUI.Properties;
using ActionRecords = TravelAgency.Model.ActionRecords;

namespace TravelAgency.CSUI.FrmSub
{
    public partial class FrmInfoTypeIn : Form
    {
        private readonly List<Model.VisaInfo> _list;
        private int _idx;
        //private readonly Model.VisaInfo _model; //readonly本身是修饰的这个引用，只要后面(构造函数之外)不再重新new来指向另外的对象即可
        private readonly BLL.VisaInfo bll = new BLL.VisaInfo();
        private readonly BLL.ActionRecords _bllActionRecords = new BLL.ActionRecords();
        private readonly Action<int> _updateDel; //副界面传来更新数据库的委托
        private readonly int _curPage; //主界面更新数据库需要一个当前页
        private readonly bool _readonly = true; //用于设置团号界面查看资料用

        private List<Model.ActionRecords> _actionRecordses;

        public FrmInfoTypeIn()
        {
            this.StartPosition = FormStartPosition.CenterScreen; //不能写在form_load里面，是已经加载完成了
            InitializeComponent();
        }

        public FrmInfoTypeIn(List<Model.VisaInfo> list, int idx, Action<int> updateDel, int page, bool __readonly = false)
            : this()
        {

            //this._model = model;
            _list = list;
            _updateDel = updateDel;
            _curPage = page;
            _idx = idx;
            _readonly = __readonly;
        }

        public FrmInfoTypeIn(List<Model.VisaInfo> list, int idx, bool __readonly = true)
            : this()
        {
            //this._model = model;
            _list = list;
            _idx = idx;
            _readonly = __readonly;
        }


        private void FrmInfoTypeIn_Load(object sender, EventArgs e)
        {
            this.btnShowStatus.Visible = false;
            this.MinimumSize = this.Size;
            this.proPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.dgvStatus.AutoGenerateColumns = false;
            dgvStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; //列宽自适应,一定不能用AllCells
            dgvStatus.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders; //这里也一定不能AllCell自适应!
            this.dgvStatus.ReadOnly = true;
            //this.pictureBox1.MouseWheel += pictureBox1_MouseWheel;
            this.txtGroupNo.Enabled = false;
            cbTypes.Enabled = false;


            radGridView1.AutoGenerateColumns = false;
            radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.None;

            foreach (string countryName in CountryCode.CountryNameArr)
            {
                cbCountry.Items.Add(countryName);
            }

            UpdateState();

            if (_readonly) //只读情况
                btnConfirm.Enabled = false;

            ////ModelToCtrls(this._model);
            //ModelToCtrls(_list[_idx]);
            //_actionRecordses = _bllActionRecords.GetVisaInfoStatusList(_list[_idx]);
            //this.dgvStatus.DataSource = _actionRecordses;
            //this.radGridView1.DataSource = _actionRecordses;
            //radGridView1.AutoGenerateColumns = false;
            ////radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            //radGridView1.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.None;
            //LoadImageFromModel(_list[_idx]);
            //SetLabelStates();
        }

        #region 状态更新函数
        private void ModelToCtrls(Model.VisaInfo model)
        {
            if (model == null)
                return;

            txtName.Text = model.Name;
            txtEnglishName.Text = model.EnglishName;
            txtSex.Text = model.Sex;
            txtIssuePlace.Text = model.IssuePlace;
            txtResidence.Text = model.Residence;
            txtBirthday.Text = DateTimeFormator.DateTimeToString(model.Birthday);
            txtOccupation.Text = model.Occupation;
            txtMarrige.Text = model.Marriaged;
            txtIdentification.Text = model.Identification;
            txtFinancialCapacity.Text = model.FinancialCapacity;
            txtPassportNo.Text = model.PassportNo;
            txtLicenseTime.Text = DateTimeFormator.DateTimeToString(model.LicenceTime);
            txtExpireDate.Text = DateTimeFormator.DateTimeToString(model.ExpiryDate);
            txtBirthPlace.Text = model.Birthplace;
            txtGroupNo.Text = model.GroupNo;
            txtDepartureRecord.Text = model.DepartureRecord;

            txtPhone.Text = model.Phone;
            txtClient.Text = model.Client;
            txtSalesPerson.Text = model.Salesperson;

            cbTypes.Text = model.Types;
            txtReturnTime.Text = DateTimeFormator.DateTimeToString(model.ReturnTime);
            cbCountry.Text = model.Country;
            txtBirthPlaceEnglish.Text = model.BirthPlaceEnglish;
            txtIssuePlaceEnglish.Text = model.IssuePlaceEnglish;
        }

        /// <summary>
        /// 这里不让修改团号
        /// </summary>
        private void CtrlsToModel(Model.VisaInfo model)
        {
            if (model == null)
                return;
            try
            {
                //会出错的放到前面
                if (txtPhone.Text.Length > 11)
                {
                    MessageBoxEx.Show("手机号码不能多于11位!");
                    return;
                }
                model.Phone = txtPhone.Text;

                model.Birthday = DateTime.Parse(txtBirthday.Text);
                model.LicenceTime = DateTime.Parse(txtLicenseTime.Text);
                model.ExpiryDate = DateTime.Parse(txtExpireDate.Text);
                model.Name = txtName.Text;
                model.EnglishName = txtEnglishName.Text;
                model.Sex = txtSex.Text;
                model.IssuePlace = txtIssuePlace.Text;
                model.Residence = txtResidence.Text;
                model.Occupation = txtOccupation.Text;
                model.Identification = txtIdentification.Text;
                model.Marriaged = txtMarrige.Text;
                model.FinancialCapacity = txtFinancialCapacity.Text;
                model.PassportNo = txtPassportNo.Text;
                model.Birthplace = txtBirthPlace.Text;
                model.GroupNo = txtGroupNo.Text;
                model.DepartureRecord = txtDepartureRecord.Text; //这里应该做校验,以及给用户做成comboBox那种

                model.Country = cbCountry.Text;
                model.ReturnTime = DateTime.Parse(txtReturnTime.Text);
                model.BirthPlaceEnglish = txtBirthPlaceEnglish.Text;
                model.IssuePlaceEnglish = txtIssuePlaceEnglish.Text;
            }
            catch (Exception)
            {
                MessageBoxEx.Show("请确保日期输入信息正确!");
                return;
            }

        }

        private void LoadImageFromModel(Model.VisaInfo model)
        {
            if (model == null)
            {
                proPictureBox1.Image = Resources.PassportPictureNotFound;
                return;
            }
            //if (proPictureBox1.Image != null)
            //{
            //    proPictureBox1.Image.Dispose();
            //    proPictureBox1.Image = null;
            //}

            if (!PassportPicHandler.CheckAndDownloadIfNotExist(model.PassportNo, PassportPicHandler.PicType.Type01Normal))
            {
                proPictureBox1.Image = Resources.PassportPictureNotFound;
                return;
            }
            proPictureBox1.Image = GlobalUtils.LoadImageFromFileNoBlock(GlobalUtils.LocalPassportPicPath + "\\" + model.PassportNo + ".jpg");
        }


        /// <summary>
        /// 设置时间轴的标签信息
        /// </summary>
        private void SetLabelStates()
        {

        }


        #endregion


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBoxEx.Show("确认提交修改?", "确认", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Cancel)
                return;
            CtrlsToModel(_list[_idx]);

            if (!bll.Update(_list[_idx]))
            {
                MessageBoxEx.Show("更新失败，请重试!");
                return;
            }

            //添加修改的记录
            //TravelAgency.Model.ActionRecords log = new ActionRecords();
            //log.ActType = Common.Enums.ActType._03Modify;
            //log.WorkId = Common.GlobalUtils.LoginUser.WorkId;
            //log.UserName = Common.GlobalUtils.LoginUser.UserName;
            //log.VisaInfo_id = _list[_idx].VisaInfo_id;
            ////log.Visa_id = _model.Visa_id;
            //log.Type = _list[_idx].Types;
            //log.EntryTime = DateTime.Now;
            //_bllActionRecords.Add(log);

            _bllActionRecords.AddRecord(Model.Enums.ActType._03Modify, Common.GlobalUtils.LoginUser,
    _list[_idx], null);

            if (!_readonly)
                _updateDel(_curPage);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnShowStatus_Click(object sender, EventArgs e)
        {
            FrmVisaInfoStatus frm = new FrmVisaInfoStatus(_list[_idx]);
            frm.Show();
        }

        private void dgvStatus_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //var list = dgvStatus.DataSource as List<Model.ActionRecords>;
            //for (int i = 0; i < dgvStatus.Rows.Count; i++)
            //{
            //    DataGridViewRow row = dgvStatus.Rows[i];
            //    row.HeaderCell.Value = (i + 1).ToString();
            //    row.Cells["EntryTime"].Value = list[i].EntryTime + "  (" +
            //   DateTimeFormator.DateStringFromNow((DateTime)_actionRecordses[i].EntryTime) + ")";
            //}
        }

        private void radGridView1_DataBindingComplete(object sender, GridViewBindingCompleteEventArgs e)
        {
            var list = radGridView1.DataSource as List<Model.ActionRecords>;
            for (int i = 0; i < radGridView1.Rows.Count; i++)
            {
                GridViewRowInfo row = radGridView1.Rows[i];
                //row.HeaderCell.Value = (i + 1).ToString();

                row.Cells["EntryTime"].Value = list[i].EntryTime + "  (" +
               DateTimeFormator.DateStringFromNow((DateTime)_actionRecordses[i].EntryTime) + ")";
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            --_idx;
            UpdateState();
        }


        /// <summary>
        /// 根据_idx更新相应的控件
        /// </summary>
        private void UpdateState()
        {

            btnPre.Enabled = true;
            btnNext.Enabled = true;

            if (_idx == _list.Count - 1)
                btnNext.Enabled = false;

            if (_idx == 0)
                btnPre.Enabled = false;

            //ModelToCtrls(this._model);
            ModelToCtrls(_list[_idx]);
            _actionRecordses = _bllActionRecords.GetListByModelOrderByEntryTime(_list[_idx]);

            this.dgvStatus.DataSource = _actionRecordses;
            this.radGridView1.DataSource = _actionRecordses;
            LoadImageFromModel(_list[_idx]);
            SetLabelStates();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ++_idx;
            UpdateState();
        }

    }
}
