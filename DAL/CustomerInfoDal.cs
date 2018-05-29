using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using System.Collections.Generic;

namespace TravelAgency.DAL
{
	/// <summary>
	/// 数据访问类:CustomerInfo
	/// </summary>
	public partial class CustomerInfo
	{
        public static List<string> GetCustomerList()
        {
        string sql = "select distinct customername from CustomerInfo where Operator is not null and CustomerName is not null and LEN(CustomerName)>0 and DataType = '销售录入'";
            DataSet ds = DbHelperSQL.Query(sql);
            List<string> res = new List<string>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["customername"] != null && row["customername"].ToString() != "")
                    {
                        res.Add(row["customername"].ToString());
                    }
                }
                return res;
            }
            else
            {
                return null;
            }
        }

        public static List<string> GetOpeartorByCustName(string cust_name)
        {
            string sql = string.Format("select operator from CustomerInfo where CustomerName='{0}'  and DataType = '销售录入'", cust_name);
            DataSet ds = DbHelperSQL.Query(sql);
            List<string> res = new List<string>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["operator"] != null && row["operator"].ToString() != "")
                    {
                        res.Add(row["operator"].ToString());
                    }
                }
                return res;
            }
            else
            {
                return null;
            }
        }

        public static List<string> GetSalesPersonByCustName(string cust_name)
        {
            string sql = string.Format("select UserName from AuthUser where WorkId in (select WorkId from CustomerInfo where CustomerName='{0}' and DataType = '销售录入')", cust_name);
            DataSet ds = DbHelperSQL.Query(sql);
            List<string> res = new List<string>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["UserName"] != null && row["UserName"].ToString() != "")
                    {
                        res.Add(row["UserName"].ToString());
                    }
                }
                return res;
            }
            else
            {
                return null;
            }
        }
    }
}

