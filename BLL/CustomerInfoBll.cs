using System;
using System.Data;
using System.Collections.Generic;
using TravelAgency.Model;
namespace TravelAgency.BLL
{
    /// <summary>
    /// CustomerInfo
    /// </summary>
    public partial class CustomerInfo
    {


        //其实这里可以直接用一个查询(连接)返回对应结构体(所有需要的封装起来)就行了
        public static List<KeyValuePair<Guid, string>> GetCustomerList()
        {
            return DAL.CustomerInfo.GetCustomerList();
        }

        public static List<string> GetOpeartorByCustId(string cust_id)
        {
            return DAL.CustomerInfo.GetOpeartorByCustId(cust_id);
        }

        public static List<string> GetSalesPersonByCustId(string cust_id)
        {
            return DAL.CustomerInfo.GetSalesPersonByCustId(cust_id);
        }
    }
}

