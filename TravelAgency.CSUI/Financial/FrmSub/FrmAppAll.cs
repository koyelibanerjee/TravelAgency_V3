using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TravelAgency.BLL;
using TravelAgency.Common;

namespace TravelAgency.CSUI.Financial.FrmSub
{
    public partial class FrmAppAll : Form
    {
        private List<Model.Visa> _list;
        private BLL.AppAll _bllAppAll = new AppAll();
        private BLL.Visa _bllVisa = new Visa();
        private decimal _amount;
        public FrmAppAll(List<Model.Visa> list)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();

            _list = list;
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            decimal total = 0;
            foreach (var visa in _list)
            {
                total += visa.Cost ?? 0;
            }

            lbAmount.Text = "请款金额:" + total + "元";
            _amount = total;
        }


        private void FrmAppAll_Load(object sender, EventArgs e)
        {
            txtGroupNo.Text = _list[0].GroupNo;

            InitCbs();

        }

        private void InitCbs()
        {
            //cbBankFrom.DropDownStyle = ComboBoxStyle.DropDownList;
            var list = _bllAppAll.GetBankFromToList();
            foreach (var item in list)
            {
                cbBankFrom.Items.Add(item);
            }


            //cbBankTo.DropDownStyle = ComboBoxStyle.DropDownList;
            list = _bllAppAll.GetBankFromToList();
            foreach (var item in list)
            {
                cbBankTo.Items.Add(item);
            }

            //cbBank.DropDownStyle = ComboBoxStyle.DropDownList;
            list = _bllAppAll.GetBankList();
            foreach (var item in list)
            {
                cbBank.Items.Add(item);
            }

            //cbPerson.DropDownStyle = ComboBoxStyle.DropDownList;
            list = _bllAppAll.GetPersonList();
            foreach (var item in list)
            {
                cbPerson.Items.Add(item);
            }
        }


        private Model.AppAll CtrlsToModel()
        {
            Model.AppAll model = new Model.AppAll();
            model.GroupNo = txtGroupNo.Text;
            model.Account = cbAccount.Text;
            model.Amount = _amount;
            model.Bank = cbBank.Text;
            model.Bank_From = cbBankFrom.Text;
            model.Bank_To = cbBankTo.Text;
            model.Person = cbPerson.Text;
            model.Details = txtDetails.Text;
            model.UserName = GlobalUtils.LoginUser.UserName;
            model.WorkId = GlobalUtils.LoginUser.WorkId;
            model.DepartmentId = GlobalUtils.LoginUser.DepartmentId;

            return model;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_bllAppAll.Add(CtrlsToModel()) > 0)
            {
                for (int i = 0; i != _list.Count; ++i)
                {
                    _list[i].SubmitFlag = 1; //已经提交
                    _bllVisa.Update(_list[i]); //更新对应Visa状态
                    //插入QZApplication表数据
                }

                //插入appstatus表记录

                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            this.DialogResult = DialogResult.Cancel;
        }
    }
}
