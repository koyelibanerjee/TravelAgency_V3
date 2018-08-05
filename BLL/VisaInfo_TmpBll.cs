using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using TravelAgency.Common;
//using Maticsoft.Common;
using TravelAgency.Model;

namespace TravelAgency.BLL
{
    /// <summary>
    /// VisaInfo_Tmp
    /// </summary>
    public partial class VisaInfo_Tmp
    {
        private BLL.VisaInfo _bllVisaInfo = new BLL.VisaInfo();
        private readonly BLL.ActionRecords _bllActionRecords = new BLL.ActionRecords();
        private readonly BLL.AuthUser _bllAuthUser = new BLL.AuthUser();
        private readonly BLL.JobAssignment _bllJobAssignment = new BLL.JobAssignment();

        public int MoveCheckedDataToVisaInfo()
        {
            int res = 0;
            var list = GetModelList(0, string.Empty, " entrytime desc");

            string types = null;
            DialogResult isfamilyret = DialogResult.None; //其他国家就不会弹出这个对话框，为None
            if (list[0].Country == "日本")
            {
                FrmGroupOrIndividualValue frm = new FrmGroupOrIndividualValue();
                if (DialogResult.OK == frm.ShowDialog())
                    types = frm.TypesValue;
                else
                    return 0;

                if (types != null && types != "团签")
                    isfamilyret = MessageBoxEx.Show("即将提交，是否将待提交签证设置为\"一家人\"?", "提示", MessageBoxButtons.YesNoCancel);
            }


            int retJobId = 0;
            if (isfamilyret == DialogResult.Yes)
            {
                Model.JobAssignment jobAssignment = new Model.JobAssignment();
                jobAssignment.EntryTime = DateTime.Now;
                jobAssignment.District = GlobalUtils.LoginUser.District;
                retJobId = _bllJobAssignment.Add(jobAssignment); //失败返回0
            }


            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].HasChecked == "是")
                {
                    Model.VisaInfo model = new Model.VisaInfo();
                    list[i].CopyToVisaInfo(model);
                    model.HasTypeIn = "否"; //不能依赖于数据库的默认值!!!
                    //model.EntryTime = DateTime.Now;

                    if (_bllVisaInfo.GetModelList(" passportNo ='" + model.PassportNo + "'").Count > 0)
                    {
                        if (MessageBoxEx.Show("检查到护照号为:" + model.PassportNo + ",姓名为:" + model.Name + "的用户已经录入，是否继续录入?", "提示",
                            MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            continue;
                        }
                    }

                    if (retJobId != 0 && isfamilyret != DialogResult.None) //如果返回值不是0，代表用户设置了一家人
                    {
                        model.JobId = retJobId;
                        model.Types = types; //设置类型
                    }
                    else //每本签证单独一个工作编号
                    {
                        if (isfamilyret != DialogResult.None) //None的话代表是其他国家
                        {
                            Model.JobAssignment jobAssignment = new Model.JobAssignment();
                            jobAssignment.EntryTime = DateTime.Now;
                            jobAssignment.District = GlobalUtils.LoginUser.District;
                            int retId = _bllJobAssignment.Add(jobAssignment); //失败返回0 
                            model.JobId = retId;
                            model.Types = types; //设置类型
                        }
                    }

                    if (_bllVisaInfo.Add(model) != Guid.Empty && Delete(list[i].VisaInfo_id)) //从tmp表到数据表
                    {
                        res++;
                        //添加录入的操作记录
                        var listusers = _bllAuthUser.GetModelList(" username ='" + model.CheckPerson + "' ");
                        if (listusers.Count <= 0)
                            continue;
                        if (!_bllActionRecords.AddRecord("00录入(扫描)", listusers[0], model, null))
                        {
                            //写日志
                        }
                    }
                    else continue;
                }
            }

            //触发一次工作分配逻辑
            if (isfamilyret != DialogResult.None)
            {
                _bllJobAssignment.AssignmentJob();
            }

            return res;
        }

        public List<Model.VisaInfo_Tmp> GetModelList(int top, string where, string order)
        {
            DataSet ds = dal.GetList(0, where, order);
            DataTable dt = ds.Tables[0];
            return DataTableToList(dt);
        }


        public bool DeleteList(string VisaInfo_idlist)
        {
            return dal.DeleteList(VisaInfo_idlist);
        }

        public int DeleteListByPassNo(List<string> passNums)
        {
            return dal.DeleteListByPassNo(passNums);
        }

        public Model.VisaInfo_Tmp GetModelByPassportNo(string passportNo)
        {
            return dal.GetModelByPassportNo(passportNo);
        }

        public int UpdateByList(List<Model.VisaInfo_Tmp> list)
        {
            int res = 0;
            for (int i = 0; i < list.Count; i++)
                res += Update(list[i]) ? 1 : 0;
            return res;
        }
    }
}