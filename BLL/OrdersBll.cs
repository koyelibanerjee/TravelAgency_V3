using System;
using System.Data;
using System.Collections.Generic;
using TravelAgency.Model;
namespace TravelAgency.BLL
{
    /// <summary>
    /// Orders
    /// </summary>
    public partial class Orders
    {

        public Dictionary<string, decimal> GetOrderOnlineTotal(List<Model.Orders> ordersList)
        {
            return dal.GetOrderOnlineTotal(ordersList);
        }



    }
}

