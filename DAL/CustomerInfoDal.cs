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
        public static List<KeyValuePair<Guid, string>> GetCustomerList()
        {
            string sql = "select distinct customername,customeid from CustomerInfo where " +
                        " DepartmentId = 'a86ed375-76db-45df-a4e9-d0bb8815d49c' and " + 
                         " CustomerName is not null and LEN(CustomerName)>0 and " +
                         " DataType = '销售录入' order by customername";

            DataSet ds = DbHelperSQL.Query(sql);
            List<KeyValuePair<Guid, string>> res = new List<KeyValuePair<Guid, string>>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["customeid"] != null && row["customeid"].ToString() != "" &&
                        row["customername"] != null && row["customername"].ToString() != "")
                    {
                        res.Add(new KeyValuePair<Guid, string>
                            (Guid.Parse(row["customeid"].ToString()),
                            row["customername"].ToString()));
                    }
                }
                return res;
            }
            else
            {
                return null;
            }
        }


        public static List<KeyValuePair<string, string>> GetSalesPersonList()
        {
            string sql = "select distinct ci.workid,au.username " +
                         "from customerinfo as ci " +
                         "inner join authuser as au " +
                         "on ci.workid=au.workid " +
                         "where datatype = '销售录入' and " +
                         "customerName is not null and " +
                         "len(customerName)>0 order by au.username";

            DataSet ds = DbHelperSQL.Query(sql);
            List<KeyValuePair<string, string>> res = new List<KeyValuePair<string, string>>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["workid"] != null && row["workid"].ToString() != "" &&
                        row["username"] != null && row["username"].ToString() != "")
                    {
                        res.Add(new KeyValuePair<string, string>
                            (row["workid"].ToString(),
                            row["username"].ToString()));
                    }
                }
                return res;
            }
            else
            {
                return null;
            }
        }

        public static List<KeyValuePair<Guid, string>> GetCustomerListBySalesperson(string workid)
        {
            string sql = string.Format("select distinct customername,customeid from CustomerInfo where " +
                         " CustomerName is not null and LEN(CustomerName)>0 and " +
                         " DataType = '销售录入' and " +
                         "workid = '{0}' order by customername ", workid);

            DataSet ds = DbHelperSQL.Query(sql);
            List<KeyValuePair<Guid, string>> res = new List<KeyValuePair<Guid, string>>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["customeid"] != null && row["customeid"].ToString() != "" &&
                        row["customername"] != null && row["customername"].ToString() != "")
                    {
                        res.Add(new KeyValuePair<Guid, string>
                            (Guid.Parse(row["customeid"].ToString()),
                            row["customername"].ToString()));
                    }
                }
                return res;
            }
            else
            {
                return null;
            }
        }

        public static List<string> GetOpeartorByCustId(string custid)
        {
            string sql = string.Format("select operator from CustomerInfo where CustomeID='{0}'  and DataType = '销售录入' order by operator ", custid);
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

        public static List<string> GetSalesPersonByCustId(string custid)
        {
            string sql = string.Format("select UserName from AuthUser where WorkId in (select WorkId from CustomerInfo where CustomeId='{0}' and DataType = '销售录入') order by username", custid);
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

