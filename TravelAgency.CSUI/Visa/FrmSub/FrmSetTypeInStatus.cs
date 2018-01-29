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
using TravelAgency.Model;

namespace TravelAgency.CSUI.FrmSub
{
    public partial class FrmSetTypeInStatus : Form
    {

        private BLL.ActionRecords _bllActionRecords = new BLL.ActionRecords();
        private BLL.Visa _bllVisa = new BLL.Visa();
        private BLL.VisaInfo _bllVisaInfo = new BLL.VisaInfo();
        private bool _hasDone = false; //用于备份判断
        private Model.Visa _visaModel;
        private Action<int> _updateDel;
        private int _curPage;

        public FrmSetTypeInStatus()
        {
            this.StartPosition = FormStartPosition.CenterParent; 
            InitializeComponent();
        }

        public FrmSetTypeInStatus(Model.Visa visamodel, string status,Action<int> updateDel,int curPage):this()
        {
            if (status == "已做")
            {
                rbtnDone.Checked = true;
                _hasDone = true;
            }
            else //未做
            {
                rbntNotDone.Checked = true;
                _hasDone = false;
            }
            _visaModel = visamodel;
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

            if (rbtnDone.Checked && _hasDone == false) //修改为已做
            {
                if (MessageBoxEx.Show("将把修改状态为\"已做\",是否提交?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }


                //添加操作记录
                var list = _bllVisaInfo.GetModelListByVisaIdOrderByPosition(_visaModel.Visa_id);

                for (int i = 0; i < list.Count; i++)
                {
                    //Model.ActionRecords log = new ActionRecords();
                    //log.ActType = Common.Enums.ActType._02TypeInData; //操作记录为录入
                    //log.WorkId = Common.GlobalUtils.LoginUser.WorkId;
                    //log.UserName = Common.GlobalUtils.LoginUser.UserName;
                    //log.VisaInfo_id = list[i].VisaInfo_id;
                    //log.Visa_id = _visaModel.Visa_id;
                    //log.Type = Common.Enums.Types.Individual;
                    //log.EntryTime = DateTime.Now;
                    //_bllActionRecords.Add(log);

                    _bllActionRecords.AddRecord(Common.Enums.ActType._02TypeInData, Common.GlobalUtils.LoginUser,
list[i], _visaModel);

                }
                _updateDel(_curPage);

            }
            else if (rbntNotDone.Checked && _hasDone == true) //修改为未做
            {
                if (MessageBoxEx.Show("将把修改状态为\"未做\",是否提交?", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                MessageBoxEx.Show("暂不支持修改为未做!");
                return;

                //删除之前的操作记录
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
