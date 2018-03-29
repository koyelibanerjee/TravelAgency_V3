using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.BLL;
using TravelAgency.Common;

namespace TravelAgency.CSUI.Financial.FrmSub
{
    public partial class FrmAppAll : Form
    {
        private List<Model.Visa> _list;
        private BLL.AppAll _bllAppAll = new AppAll();
        private BLL.Visa _bllVisa = new BLL.Visa();
        private BLL.QZApplication _bllQzApplication = new QZApplication();
        private BLL.AppStatus _bllAppStatus = new AppStatus();
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
            model.Flag = 1; //代表签证请款
            model.AppNo = DateTime.Today.ToString("yyyyMMdd") + (_bllAppAll.GetMaxTemp() + 1);
            model.EntryTime = DateTime.Now;
            model.AppTime = model.EntryTime;
            return model;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Guid appid = _bllAppAll.Add(CtrlsToModel());
            if (Guid.Empty != appid)
            {
                for (int i = 0; i != _list.Count; ++i)
                {
                    _list[i].SubmitFlag = 1; //已经提交
                    _bllVisa.Update(_list[i]); //更新对应Visa状态
                    //插入QZApplication表数据
                    Model.QZApplication qzApplicationModel = new Model.QZApplication();
                    qzApplicationModel.Visa_id = _list[i].Visa_id;
                    qzApplicationModel.SubName = GlobalUtils.LoginUser.UserName;
                    qzApplicationModel.DepartmentId = GlobalUtils.LoginUser.DepartmentId;
                    qzApplicationModel.GroupNo = _list[i].GroupNo;
                    qzApplicationModel.SendTime = _list[i].RealTime;
                    qzApplicationModel.FinishTime = _list[i].FinishTime;
                    qzApplicationModel.Person = _list[i].Person;
                    qzApplicationModel.Number = _list[i].Number;
                    qzApplicationModel.Tips = _list[i].Tips;
                    qzApplicationModel.Price = _list[i].Price;
                    qzApplicationModel.Receipt = _list[i].Receipt;
                    qzApplicationModel.Quidco = _list[i].Quidco;
                    qzApplicationModel.ConsulateCost = _list[i].ConsulateCost;
                    qzApplicationModel.VisaPersonCost = _list[i].VisaPersonCost;
                    qzApplicationModel.MailCost = _list[i].MailCost;
                    qzApplicationModel.PictureCost = _list[i].Picture;
                    qzApplicationModel.Sales = _list[i].SalesPerson;
                    qzApplicationModel.WorkId = GlobalUtils.LoginUser.WorkId;
                    qzApplicationModel.EntryTime = DateTime.Now;
                    qzApplicationModel.Flag = 0;
                    qzApplicationModel.Country = _list[i].Country;
                    qzApplicationModel.Name = _list[i].client;
                    qzApplicationModel.InvitationCost = _list[i].InvitationCost;
                    qzApplicationModel.cost = _list[i].Cost;
                    qzApplicationModel.App_id = appid;
                    if (!_bllQzApplication.Add(qzApplicationModel))
                    {
                        MessageBoxEx.Show("添加失败，请重试!");
                        return;
                    }
                }

                //插入appstatus表记录
                Model.AppStatus appStatusModel = new Model.AppStatus();
                appStatusModel.App_id = appid;
                appStatusModel.CheckPerson = GlobalUtils.LoginUser.UserName;
                appStatusModel.CheckPersonId = GlobalUtils.LoginUser.WorkId;
                appStatusModel.StatusFlag = 0;
                appStatusModel.Opinions = "已提交请款申请";
                appStatusModel.CheckTime = DateTime.Now;
                appStatusModel.EntryTime = DateTime.Now;

                Model.AppStatus appStatusModel1 = new Model.AppStatus();
                appStatusModel1.App_id = appid;
                appStatusModel1.CheckPerson = GlobalUtils.LoginUser.UserName;
                appStatusModel1.CheckPersonId = GlobalUtils.LoginUser.WorkId;
                appStatusModel1.StatusFlag = 1;
                appStatusModel1.Opinions = "等待部门经理审批";
                appStatusModel1.CheckTime = DateTime.Now;
                appStatusModel1.EntryTime = DateTime.Now;

                if (!_bllAppStatus.Add(appStatusModel) || !_bllAppStatus.Add(appStatusModel1))
                {
                    MessageBoxEx.Show("添加appstatus出错，请联系技术人员!");
                    return;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("添加失败!");
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
