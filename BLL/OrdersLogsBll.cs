using System;
using System.Data;
using System.Collections.Generic;
using TravelAgency.Model;
namespace TravelAgency.BLL
{
    /// <summary>
    /// OrdersLogs
    /// </summary>
    public partial class OrdersLogs
    {
        //public List<Model.OrdersLogs> GetListByPageOrderById(string strWhere, int pageNo, int pageSize)
        //{
        //    int start = (pageNo - 1) * pageSize + 1;
        //    int end = pageNo * pageSize;
        //    var ds = GetListByPage(strWhere, " id desc ", start, end);
        //    return DataTableToList(ds.Tables[0]);
        //}

        //public List<Model.OrdersLogs> GetListOfPage(string strWhere, string orderby, int pageNo, int pageSize)
        //{
        //    int start = (pageNo - 1) * pageSize + 1;
        //    int end = pageNo * pageSize;
        //    var ds = GetListByPage(strWhere, orderby, start, end);
        //    return DataTableToList(ds.Tables[0]);
        //}

        //public int DeleteList(List<Model.OrdersLogs> list)
        //{
        //    int res = 0;
        //    foreach (var item in list)
        //    {
        //        res += Delete(item.id) ? 1 : 0;
        //    }
        //    return res;
        //}

        public int AddLog(Model.AuthUser user, int acttype, Model.Orders order)
        {
            Model.OrdersLogs ordersLogs = new Model.OrdersLogs();
            ordersLogs.UserName = user.UserName;
            ordersLogs.WorkId = user.WorkId;
            ordersLogs.OrdersId = order.Id;
            ordersLogs.OrderNo = order.OrderNo;
            ordersLogs.EntryTime = DateTime.Now;
            ordersLogs.ActType = acttype;
            return Add(ordersLogs);
        }

    }
}

