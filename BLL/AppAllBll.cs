using System;
using System.Data;
using System.Collections.Generic;
using System.Net.Sockets;
using TravelAgency.Model;

namespace TravelAgency.BLL
{
    /// <summary>
    /// AppAll
    /// </summary>
    public partial class AppAll
    {
        public string TableName { get { return "AppAll"; } }

        public int GetMaxTemp()
        {
            return dal.GetMaxTemp();
        }
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public Guid Add(TravelAgency.Model.AppAll model)
        {
            return dal.Add(model);
        }

        public List<string> GetBankFromToList()
        {
            var list = CommonBll.GetFieldList(TableName, "Bank_To");
            list.AddRange(CommonBll.GetFieldList(TableName, "Bank_From"));
            return list;
        }

        public List<string> GetBankList()
        {
            var list = CommonBll.GetFieldList(TableName, "Bank");
            return list;
        }

        public List<string> GetPersonList()
        {
            var list = CommonBll.GetFieldList(TableName, "Person");
            return list;
        }

        public List<Model.AppAll> GetDataByPageOrderByEntryTime(int pageIndex, int pageSize, string where)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;

            DataSet ds = dal.GetDataByPageOrderByEntryTime(start, end, where);
            DataTable dt = ds.Tables[0];
            return DataTableToList(dt);
        }

        public List<Model.AppAll> GetNotCheckedAppAllOrderByEntryTime(int pageIndex, int pageSize, string where)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;

            DataSet ds = dal.GetDataByPageOrderByEntryTime(start, end, where);
            DataTable dt = ds.Tables[0];
            var list = DataTableToList(dt);
            BLL.AppStatus bllAppStatus = new AppStatus();
            for (int i = list.Count - 1; i >= 0; --i)
            {
                if (list[i].Flag != 2 && list[i].Flag != 1)
                {
                    list.Remove(list[i]);
                    continue;
                }

                var statusList = bllAppStatus.GetModelList(" app_id = '" + list[i].App_id + "' ");
                if (statusList.Count > 0)
                {
                    foreach (var stats in statusList)
                    {
                        if (stats.StatusFlag > 1) //有大于1的状态就移除
                        {
                            list.Remove(list[i]);
                            break;
                        }
                    }
                }
            }
            return list;

        }


    }
}