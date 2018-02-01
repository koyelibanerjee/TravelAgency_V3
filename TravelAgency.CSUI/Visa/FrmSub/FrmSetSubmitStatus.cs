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
using TravelAgency.Common;
using TravelAgency.Common.Enums;
using TravelAgency.Model;

namespace TravelAgency.CSUI.FrmSub
{
    public partial class FrmSetSubmitStatus : Form
    {

        private BLL.ActionRecords _bllActionRecords = new BLL.ActionRecords();
        private BLL.Visa _bllVisa = new BLL.Visa();
        private BLL.VisaInfo _bllVisaInfo = new BLL.VisaInfo();
        private bool _hasDone = false; //用于备份判断
        private Model.VisaInfo _visaInfoModel;
        //private Action<int> _updateDel;
        //private int _curPage;

        public FrmSetSubmitStatus()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
        }

        public FrmSetSubmitStatus(Model.VisaInfo visaInfomodel, string status, Action<int> updateDel, int curPage) : this()
        {
            if (status == "01未记录" || status=="10已导出")
            {
                rbtnNoRecord.Checked = true;
                //_hasDone = true;
            }
            else if (status == "02进签") //未做
            {
                rbtnIn.Checked = true;
                //_hasDone = false;
            }
            else if (status == "03出签") //未做
            {
                rbtnOut.Checked = true;
                //_hasDone = false;
            }
            else
            {
                rbtnAbOut.Checked = true;
            }

            _visaInfoModel = visaInfomodel;
            //_updateDel = updateDel;
            //_curPage = curPage;
        }


        private void FrmSetTypeInStatus_Load(object sender, EventArgs e)
        {
            //rbtnDone.Checked = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (rbtnNoRecord.Checked) //修改为已做
            {
                if (MessageBoxEx.Show("将把修改状态为\"未记录\",是否提交?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                _visaInfoModel.outState = OutState.Type01NoRecord;
                if (!_bllVisaInfo.Update(_visaInfoModel))
                {
                    MessageBoxEx.Show("更新失败,请重试!");
                    return;
                }
                //删除所有操作记录
                _bllActionRecords.DeleteSubmitStateRecord(_visaInfoModel, ActType._05SubmitIn);
                _bllActionRecords.DeleteSubmitStateRecord(_visaInfoModel, ActType._05SubmitOut);
                _bllActionRecords.DeleteSubmitStateRecord(_visaInfoModel, ActType._05SubmitAbOut);
                //_updateDel(_curPage);

            }
            else if (rbtnIn.Checked) //修改为进签
            {
                if (MessageBoxEx.Show("将把修改状态为\"进签\",是否提交?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                _visaInfoModel.outState = OutState.Type02In;
                if (!_bllVisaInfo.Update(_visaInfoModel))
                {
                    MessageBoxEx.Show("更新失败,请重试!");
                    return;
                }

                //添加进签操作记录
                _bllActionRecords.AddRecord(ActType._05SubmitIn, GlobalUtils.LoginUser, _visaInfoModel,
                    _bllVisa.GetModel(Guid.Parse(_visaInfoModel.Visa_id)));
                //删除出签和非正常出签的操作记录
                _bllActionRecords.DeleteSubmitStateRecord(_visaInfoModel, ActType._05SubmitOut);
                _bllActionRecords.DeleteSubmitStateRecord(_visaInfoModel, ActType._05SubmitAbOut);


            }
            else if (rbtnOut.Checked)
            {
                if (MessageBoxEx.Show("将把修改状态为\"出签\",是否提交?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                _visaInfoModel.outState = OutState.Type03NormalOut;
                if (!_bllVisaInfo.Update(_visaInfoModel))
                {
                    MessageBoxEx.Show("更新失败,请重试!");
                    return;
                }

                //添加出签操作记录
                _bllActionRecords.AddRecord(ActType._05SubmitOut, GlobalUtils.LoginUser, _visaInfoModel,
                    _bllVisa.GetModel(Guid.Parse(_visaInfoModel.Visa_id)));
                //删除非正常出签的操作记录
                _bllActionRecords.DeleteSubmitStateRecord(_visaInfoModel, ActType._05SubmitAbOut);

            }
            else
            {
                if (MessageBoxEx.Show("将把修改状态为\"非正常出签\",是否提交?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                _visaInfoModel.outState = OutState.TYPE04AbnormalOut;
                if (!_bllVisaInfo.Update(_visaInfoModel))
                {
                    MessageBoxEx.Show("更新失败,请重试!");
                    return;
                }

                //添加出签操作记录
                _bllActionRecords.AddRecord(ActType._05SubmitAbOut, GlobalUtils.LoginUser, _visaInfoModel,
                    _bllVisa.GetModel(Guid.Parse(_visaInfoModel.Visa_id)));
                //删除正常出签的操作记录
                _bllActionRecords.DeleteSubmitStateRecord(_visaInfoModel, ActType._05SubmitOut);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
