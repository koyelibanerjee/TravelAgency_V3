﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using DevComponents.DotNetBar;
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
            var list = GetModelList(string.Empty);
            DialogResult dlgResult = MessageBoxEx.Show("即将提交，是否将待提交签证设置为\"一家人\"?", "提示", MessageBoxButtons.YesNoCancel);
            if (dlgResult == DialogResult.Cancel)
                return 0;

            int retJobId = 0;
            if (dlgResult == DialogResult.Yes)
            {
                Model.JobAssignment jobAssignment = new Model.JobAssignment();
                jobAssignment.EntryTime = DateTime.Now;
                retJobId = _bllJobAssignment.Add(jobAssignment); //失败返回0
            }


            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].HasChecked == "是")
                {
                    Model.VisaInfo model = new Model.VisaInfo();
                    list[i].CopyToVisaInfo(model);
                    if (_bllVisaInfo.GetModelList(" passportNo ='" + model.PassportNo + "'").Count > 0)
                    {
                        if (MessageBoxEx.Show("检查到护照号为:" + model.PassportNo + ",姓名为:" + model.Name + "的用户已经录入，是否继续录入?", "提示",
                            MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            continue;
                        }
                    }

                    if (retJobId != 0) //如果返回值不是0，代表用户设置了一家人
                        model.JobId = retJobId;
                    else //每本签证单独一个工作编号
                    {
                        Model.JobAssignment jobAssignment = new Model.JobAssignment();
                        jobAssignment.EntryTime = DateTime.Now;
                        int retId = _bllJobAssignment.Add(jobAssignment); //失败返回0 
                        model.JobId = retId;
                    }

                    if (_bllVisaInfo.Add(model) && Delete(list[i].VisaInfo_id)) //从tmp表到数据表
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
            _bllJobAssignment.AssignmentJob();

            return res;
        }

        public List<Model.VisaInfo_Tmp> GetModelList(int top, string where, string order)
        {
            DataSet ds = dal.GetList(0, where, order);
            DataTable dt = ds.Tables[0];
            return DataTableToList(dt);
        }

        public List<Model.VisaInfo_Tmp> GetListByPageOrderByOutState(int pageIndex, int pageSize, string where)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;

            DataSet ds = dal.GetDataByPageOrderByOutState(start, end, where);
            DataTable dt = ds.Tables[0];
            return DataTableToList(dt);

        }

        public List<Model.VisaInfo_Tmp> GetListByPageOrderByGroupNo(int pageIndex, int pageSize, string where)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;

            DataSet ds = dal.GetDataByPageOrderByGroupNo(start, end, where);
            DataTable dt = ds.Tables[0];
            return DataTableToList(dt);
        }

        public List<Model.VisaInfo_Tmp> GetListByPageOrderByHasChecked(int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;

            DataSet ds = dal.GetDataByPageOrderByHasChecked(start, end);
            DataTable dt = ds.Tables[0];
            return DataTableToList(dt);
        }


        public int DeleteList(string VisaInfo_idlist)
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
            {
                res += Update(list[i]) ? 1 : 0;
            }
            return res;
        }


    }
}