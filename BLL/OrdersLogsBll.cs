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
        public int AddLog(string username, int acttype, int orderid)
        {
            Model.OrdersLogs ordersLogs = new Model.OrdersLogs();
            ordersLogs.UserName = username;
            ordersLogs.OrdersId = orderid;
            ordersLogs.EntryTime = DateTime.Now;
            ordersLogs.ActType = acttype;
            return Add(ordersLogs);
        }
    }
}

