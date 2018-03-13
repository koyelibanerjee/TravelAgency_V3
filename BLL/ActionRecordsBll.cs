using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.BLL
{
    public partial class ActionRecords
    {

        public List<Model.ActionRecords> GetVisaInfoStatusList(Model.VisaInfo model)
        {
            return dal.GetVisaInfoStatusList(model);
        }

        public List<Model.ActionRecords> GetListByModelOrderByEntryTime(Model.VisaInfo model)
        {
            return DataTableToList(dal.GetList(-1, " visainfo_id = '" + model.VisaInfo_id + "' ", " entrytime asc").Tables[0]); //-1表示全部
        }

        /// <summary>
        /// 检查指定visa是否已经录入了，现在就是做资料了
        /// </summary>
        /// <param name="visaModel"></param>
        /// <returns></returns>
        public bool HasVisaBeenTypedIn(Model.Visa visaModel)
        {
            List<Model.ActionRecords> list = GetModelList(" visa_id = '" + visaModel.Visa_id + "' and ActType='" + "02录入做资料" + "'");
            return list.Count > 0;
        }


        /// <summary>
        /// 检查如果没有（或有）这个状态记录的话就删除
        /// </summary>
        /// <param name="list"></param>
        /// <param name="type"></param>
        /// <param name="keepOption">1是保留还未做的,2保留还未做完的,4保留已经做完的</param>
        public List<Model.Visa> CheckStatesAndRemove(List<Model.Visa> list, string type, int keepOption)
        {
            List<Model.Visa> listRes = new List<Model.Visa>();
            for (int i = 0; i <= list.Count - 1; ++i)
            {
                int total = (int)list[i].Number;
                int num = GetVisaHasTypedInNum(list[i].Visa_id);
                switch (keepOption)
                {
                    case 1:
                        if (num == 0)
                            listRes.Add(list[i]);
                        break;
                    case 2:
                        if (num > 0 && num < total)
                            listRes.Add(list[i]);
                        break;
                    case 4:
                        if (num == total)
                            listRes.Add(list[i]);
                        break;
                    default:
                        break;
                }
            }
            return listRes;
        }


        public int GetVisaHasTypedInNum(Guid visaGuid)
        {
            return dal.GetVisaHasTypedInNum(visaGuid);
        }

        ///// <summary>
        ///// 检查指定visaInfo是否已经录入了，现在就是做资料了
        ///// </summary>
        ///// <param name="visaModel"></param>
        ///// <returns></returns>
        //public bool HasVisaInfoBeenTypedIn(Model.VisaInfo model)
        //{
        //    List<Model.ActionRecords> list = GetModelList(" visainfo_id = '" + model.VisaInfo_id + "' and ActType='" + "02录入做资料" + "'");
        //    return list.Count > 0;
        //}

        /// <summary>
        /// 检查指定visaInfo是否已经录入了，现在就是做资料了（并且是限制到指定团）
        /// </summary>
        /// <param name="visaModel"></param>
        /// <returns></returns>
        public bool HasVisaInfoBeenTypedIn(Model.VisaInfo model, Model.Visa visaModel)
        {
            List<Model.ActionRecords> list = GetModelList(" visainfo_id = '" + model.VisaInfo_id + "' and ActType='" + "02录入做资料" + "' and Visa_id = '" + visaModel.Visa_id + "'");
            return list.Count > 0;
        }

        public List<Model.ActionRecords> GetDataByPageOrderByEntryTime(int pageIndex, int pageSize, string where)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;

            DataSet ds = dal.GetDataByPageOrderByEntryTime(start, end, where);
            DataTable dt = ds.Tables[0];
            return DataTableToList(dt);
        }

        public bool AddRecord(string acttype, Model.AuthUser user, Model.VisaInfo visainfo, Model.Visa visa)
        {
            Model.ActionRecords model = new Model.ActionRecords();
            model.ActType = acttype;
            model.WorkId = user.WorkId;
            model.UserName = user.UserName;
            if (visainfo != null)
                model.VisaInfo_id = visainfo.VisaInfo_id;
            if (visa != null)
            {
                model.Visa_id = visa.Visa_id;
                model.Type = visa.Types;
            }
            model.EntryTime = DateTime.Now;
            if (!string.IsNullOrEmpty(visainfo?.Country))
                model.Country = visainfo.Country;
            return Add(model) > 0;
        }

        public int GetVisaSubmitStateNum(Model.Visa model, string acttype)
        {
            return dal.GetVisaSubmitStateNum(model, acttype);
        }

        public int DeleteVisaInfoSubmitStateRecord(Model.VisaInfo model, string acttype)
        {
            return dal.DeleteVisaInfoSubmitStateRecord(model, acttype);
        }

    }
}
