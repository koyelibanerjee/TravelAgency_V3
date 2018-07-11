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
        private string _tableName => "AppAll";
        private string _where => " DepartmentId = 'A86ED375-76DB-45DF-A4E9-D0BB8815D49C'";

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
            var list = CommonBll.GetFieldList(_tableName, "Bank_To", _where);
            list.AddRange(CommonBll.GetFieldList(_tableName, "Bank_From", _where));
            return list;
        }

        public List<string> GetBankList()
        {
            var list = CommonBll.GetFieldList(_tableName, "Bank", _where);
            return list;
        }

        public List<string> GetPersonList()
        {
            var list = CommonBll.GetFieldList(_tableName, "Person", _where);
            return list;
        }

        public List<string> GetAccountList()
        {
            var list = CommonBll.GetFieldList(_tableName, "Account", _where);
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

        //public List<Model.AppAll> GetNotCheckedAppAllOrderByEntryTime(int pageIndex, int pageSize, string where)
        //{
        //    int start = (pageIndex - 1) * pageSize + 1;
        //    int end = pageIndex * pageSize;

        //    DataSet ds = dal.GetDataByPageOrderByEntryTime(start, end, where);
        //    DataTable dt = ds.Tables[0];
        //    var list = DataTableToList(dt);
        //    BLL.AppStatus bllAppStatus = new AppStatus();
        //    for (int i = list.Count - 1; i >= 0; --i)
        //    {
        //        if (list[i].Flag != 2 && list[i].Flag != 1)
        //        {
        //            list.Remove(list[i]);
        //            continue;
        //        }

        //        var statusList = bllAppStatus.GetModelList(" app_id = '" + list[i].App_id + "' ");
        //        if (statusList.Count > 0)
        //        {
        //            foreach (var stats in statusList)
        //            {
        //                if (stats.StatusFlag > 1) //有大于1的状态就移除
        //                {
        //                    list.Remove(list[i]);
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    return list;

        //}

        public List<Model.AppAll> GetNotCheckedAppAllOrderByEntryTime(int pageIndex, int pageSize, string where)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;

            DataSet ds = dal.GetNotCheckedDataByPageOrderByEntryTime(start, end, where);
            DataTable dt = ds.Tables[0];
            var list = DataTableToList(dt);
            return list;
        }

        public int GetNotCheckedCount()
        {
            return dal.GetNotCheckedCount();
        }

    }
}