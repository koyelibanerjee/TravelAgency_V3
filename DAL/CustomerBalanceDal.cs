using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
    /// <summary>
    /// 数据访问类:CustomerBalance
    /// </summary>
    public partial class CustomerBalance
    {
        public List<string> GetValidCleintList()
        {
            string sql = " select distinct CustomerName from customerbalance where BalanceAmount > 0";
            string filedName = "CustomerName";
            DataSet ds = DbHelperSQL.Query(sql);
            List<string> res = new List<string>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row[filedName] != null && row[filedName].ToString() != "")
                    {
                        res.Add(row[filedName].ToString());
                    }
                }
                return res;
            }
            return null;
        }
    }
}

