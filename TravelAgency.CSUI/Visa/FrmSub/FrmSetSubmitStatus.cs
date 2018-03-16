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
        private List<Model.VisaInfo> _visaInfoList;
        private Action<int> _updateDel;
        private int _curPage;
        private List<Model.Visa> _visaList;


        public FrmSetSubmitStatus()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
        }

        public FrmSetSubmitStatus(List<Model.VisaInfo> visaInfoList,Action<int> updateDel, int curPage) : this()
        {
            rbtnNoRecord.Checked = true;
            _visaInfoList = visaInfoList;
            _updateDel = updateDel;
            _curPage = curPage;
        }

        public FrmSetSubmitStatus(List<Model.Visa> visaList, Action<int> updateDel, int curPage) : this()
        {
            rbtnNoRecord.Checked = true;
            _visaList = visaList;
            _updateDel = updateDel;
            _curPage = curPage;
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
                UpdateVisaInfoOutStates(Common.Enums.OutState.Type01NoRecord);
            }
            else if (rbtnIn.Checked) //修改为进签
            {
                if (MessageBoxEx.Show("将把修改状态为\"进签\",是否提交?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                UpdateVisaInfoOutStates(Common.Enums.OutState.Type02In);
            }
            else if (rbtnOut.Checked)
            {
                if (MessageBoxEx.Show("将把修改状态为\"出签\",是否提交?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                UpdateVisaInfoOutStates(Common.Enums.OutState.Type03NormalOut);


            }
            else
            {
                if (MessageBoxEx.Show("将把修改状态为\"非正常出签\",是否提交?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                UpdateVisaInfoOutStates(Common.Enums.OutState.TYPE04AbnormalOut);
            }
            _updateDel(_curPage);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void UpdateVisaInfoOutStates(string outstate)
        {
            int res = 0, total = 0;
            if (_visaList != null)
            {

                foreach (var visa in _visaList)
                {
                    var visainfoList = _bllVisaInfo.GetModelListByVisaIdOrderByPosition(visa.Visa_id);
                    for (int i = 0; i < visainfoList.Count; i++)
                    {
                        visainfoList[i].outState = outstate;
                    }
                    res += _bllVisaInfo.UpdateByList(visainfoList);
                    total += visainfoList.Count;
                }
            }
            else
            {
               
                for (int i = 0; i < _visaInfoList.Count; i++)
                {
                    _visaInfoList[i].outState = outstate;
                }
                res += _bllVisaInfo.UpdateByList(_visaInfoList);
                total += _visaInfoList.Count;
            }


            GlobalUtils.MessageBoxWithRecordNum("更新",res,total);
        }

    }
}
