using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.BLL
{
    public partial class Visa
    {
        public string TableName { get { return "Visa"; } }


        public List<string> GetClientList()
        {
            return CommonBll.GetFieldList(TableName, "Client");
        }

        public List<string> GetCountryList()
        {
            return CommonBll.GetFieldList(TableName, "Country");
        }

        public List<string> GetTypeList()
        {
            return CommonBll.GetFieldList(TableName, "Types");
        }

        public List<string> GetDepartureTypeList()
        {
            return CommonBll.GetFieldList(TableName, "DepartureType");
        }

        ///// <summary>
        ///// 返回成功数量
        ///// </summary>
        ///// <param name="list"></param>
        ///// <returns></returns>
        //public int UpdateList(List<Model.Visa> list)
        //{
        //    int res = 0;
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        res += Update(list[i]) ? 1 : 0;
        //    }
        //    return res;
        //}

        public List<Model.Visa> GetListByPage(int pageIndex, int pageSize, string where)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;

            DataSet ds = dal.GetDataByPage(start, end, where);
            //DataSet ds = dal.GetListByPage(where,)
            DataTable dt = ds.Tables[0];
            return DataTableToList(dt);
        }

        public bool DeleteVisaAndModifyVisaInfos(Model.Visa model)
        {
            //1.更新对应visainfo
            BLL.VisaInfo bllVisaInfo = new VisaInfo();
            List<Model.VisaInfo> list = bllVisaInfo.GetModelListByVisaIdOrderByPosition(model.Visa_id);

            //修改对应项
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Country = null;
                list[i].Visa_id = null;
                list[i].GroupNo = null;
                //TODO:资料录入情况怎么处理
                //TODO:销售人员和客户怎么处理?
                list[i].Salesperson = null;
                list[i].Client = null;
                //TODO:Types怎么处理
                list[i].Types = null;
                if (!bllVisaInfo.Update(list[i]))
                {
                    return false;
                }
            }
            //2.删除自身
            return Delete(model.Visa_id);
        }




        /// <summary>
        /// 查询指定类型的最新一条记录
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Model.Visa GetLastRecord(string type,string typeinperson,string country)
        {
            var ds = dal.GetLastRecord(type, typeinperson,country);
            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0] != null)
                return dal.DataRowToModel(ds.Tables[0].Rows[0]);
            return null;
        }

        /// <summary>
        /// 取得没一个visainfo对应的visa,所以可能会出现重复的，用于8人报表里面
        /// </summary>
        /// <param name="visaInfoList"></param>
        /// <returns></returns>
        public List<Model.Visa> GetVisaListViaVisaInfoList(List<Model.VisaInfo> visaInfoList)
        {
            List<Model.Visa> list = new List<Model.Visa>();
            for (int i = 0; i < visaInfoList.Count; i++)
            {
                Guid guid;
                if (Guid.TryParse(visaInfoList[i].Visa_id, out guid))
                {
                    var visaModel = GetModel(guid);
                    //if(visaModel!=null)
                    list.Add(visaModel); //就算是null也直接添加进去 ，没有影响
                }
                else
                {
                    list.Add(null);
                }
            }
            return list;
        }

        public Model.Visa GetLastRecordOfTheDay(DateTime date)
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
