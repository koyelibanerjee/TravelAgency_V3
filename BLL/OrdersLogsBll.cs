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
        //public int AddLog(string username, int acttype, int orderid)
        //{
        //    Model.OrdersLogs ordersLogs = new Model.OrdersLogs();
        //    ordersLogs.UserName = username;
        //    ordersLogs.OrdersId = orderid;
        //    ordersLogs.EntryTime = DateTime.Now;
        //    ordersLogs.ActType = acttype;
        //    return Add(ordersLogs);
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

