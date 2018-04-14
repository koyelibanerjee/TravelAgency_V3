using System;
using System.Data;
using System.Collections.Generic;
using TravelAgency.Model;
namespace TravelAgency.BLL
{
    /// <summary>
    /// OrderInfo
    /// </summary>
    public partial class OrderInfo
    {
        public List<Model.OrderInfo> GetListByPageOrderById(string strWhere, int pageNo, int pageSize)
        {
            int start = (pageNo - 1) * pageSize + 1;
            int end = pageNo * pageSize;
            var ds = GetListByPage(strWhere, " id desc ", start, end);
            return DataTableToList(ds.Tables[0]);
        }

        public int AddList(List<Model.OrderInfo> list)
        {
            int res = 0;
            foreach (var OrderInfo in list)
            {
                res += dal.Add(OrderInfo) == 0 ? 0 : 1; //返回值是id
            }
            return res;
        }

        public int DeleteList(List<Model.OrderInfo> list)
        {
            int res = 0;
            foreach (var OrderInfo in list)
            {
                res += Delete(OrderInfo.Id) ? 1 : 0;
            }
            return res;
        }

    }
}

