using System;
using System.Data;
using System.Collections.Generic;
using TravelAgency.Common;
//using Maticsoft.Common;
using TravelAgency.Model;

namespace TravelAgency.BLL
{
    /// <summary>
    /// VisaInfo
    /// </summary>
    public partial class VisaInfo
    {
        public List<Model.VisaInfo> GetListByPageOrderByOutState(int pageIndex, int pageSize,string where)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;

            DataSet ds = dal.GetDataByPageOrderByOutState(start, end,where);
            DataTable dt = ds.Tables[0];
            return DataTableToList(dt);
            
        }

        public List<Model.VisaInfo> GetListByPageOrderByGroupNo(int pageIndex, int pageSize,string where)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;

            DataSet ds = dal.GetDataByPageOrderByGroupNo(start, end,where);
            DataTable dt = ds.Tables[0];
            return DataTableToList(dt);
        }

        public List<Model.VisaInfo> GetListByPageOrderByHasChecked(int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;

            DataSet ds = dal.GetDataByPageOrderByHasChecked(start, end);
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

        public Model.VisaInfo GetModelByPassportNo(string passportNo)
        {
            return dal.GetModelByPassportNo(passportNo);
        }

        public int UpdateByList(List<Model.VisaInfo> list)
        {
            int res = 0;
            for (int i = 0; i < list.Count; i++)
            {
                res += Update(list[i]) ? 1 : 0;
            }
            return res;
        }


        /// <summary>
        /// 获得数据列表,并且按照所在团里面的Position进行排序
        /// </summary>
        public List<TravelAgency.Model.VisaInfo> GetModelListByVisaIdOrderByPosition(Guid visa_id)
        {
            return GetModelListByVisaIdOrderByPosition(visa_id.ToString());
        }

        /// <summary>
        /// 获得数据列表,并且按照所在团里面的Position进行排序
        /// </summary>
        public List<TravelAgency.Model.VisaInfo> GetModelListByVisaIdOrderByPosition(string visa_id)
        {
            DataSet ds = dal.GetList(" visa_id = '" + visa_id + "' ");
            var list = DataTableToList(ds.Tables[0]);
            list.Sort((model1, model2) => { return model1.Position < model2.Position ? -1 : 1; }); //按照position先排序
            return list;
        }

        public void UpdateVisaInfosGroupNoByVisaModel(Model.Visa visaModel)
        {
            var list = GetModelListByVisaIdOrderByPosition(visaModel.Visa_id);
            for (int i = 0; i < list.Count; i++)
            {
                list[i].GroupNo = visaModel.GroupNo;
            }
            UpdateByList(list);
        }

        public List<Model.VisaInfo> GetDelayList()
        {
            DataSet ds = dal.GetList(0, $" outState = '01延后' and district = {GlobalUtils.LoginUser.District} ", " entrytime desc ");
            var list = DataTableToList(ds.Tables[0]);
            return list;
        }


        public Model.VisaInfo GetLastRecordOfTheDay(DateTime date)
        {
            try
            {
                return DataTableToList(dal.GetLastRecordOfTheDay(date).Tables[0])[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}