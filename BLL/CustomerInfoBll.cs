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
        public static List<string> GetCustomerList()
        {
            return DAL.CustomerInfo.GetCustomerList();
        }

        public static List<string> GetOpeartorByCustName(string cust_name)
        {
            return DAL.CustomerInfo.GetOpeartorByCustName(cust_name);

        }

        public static List<string> GetSalesPersonByCustName(string cust_name)
        {
            return DAL.CustomerInfo.GetSalesPersonByCustName(cust_name);
        }
    }
}

