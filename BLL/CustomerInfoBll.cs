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

