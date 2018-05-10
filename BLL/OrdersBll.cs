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

        public List<Model.Orders> GetListByPageOrderById(string strWhere, int pageNo, int pageSize)
        {
            int start = (pageNo - 1) * pageSize + 1;
            int end = pageNo * pageSize;
            var ds = GetListByPage(strWhere, " id desc ", start, end);
            return DataTableToList(ds.Tables[0]);
        }

        public int AddList(List<Model.Orders> list)
        {
            int res = 0;
            foreach (var Orders in list)
            {
                res += dal.Add(Orders) == 0 ? 0 : 1; //返回值是id
            }
            return res;
        }

        public int DeleteList(List<Model.Orders> list)
        {
            int res = 0;
            foreach (var Orders in list)
            {
                res += Delete(Orders.Id) ? 1 : 0;
            }
            return res;
        }

    }
}

