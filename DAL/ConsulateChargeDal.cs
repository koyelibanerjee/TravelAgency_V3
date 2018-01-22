using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
	/// <summary>
	/// 数据访问类:ConsulateCharge
	/// </summary>
	public partial class ConsulateCharge
	{
        public List<string> GetCountryList()
        {
            string sql = "select distinct Country from ConsulateCharge";
            DataSet ds = DbHelperSQL.Query(sql);
            List<string> res = new List<string>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    if (row["Country"] != null && row["Country"].ToString() != "")
                    {
                        res.Add(row["Country"].ToString());
                    }
                }
                return res;
            }
            else
            {
                return null;
            }
        }

        public List<string> GetTypeList()
        {
            string sql = "select distinct Types from ConsulateCharge";
            DataSet ds = DbHelperSQL.Query(sql);
            List<string> res = new List<string>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    if (row["Types"] != null && row["Types"].ToString() != "")
                    {
                        res.Add(row["Types"].ToString());
                    }
                }
                return res;
            }
            else
            {
                return null;
            }
        }

        public List<string> GetDepartureTypeList()
        {
            string sql = "select distinct DepartureType from ConsulateCharge";
            DataSet ds = DbHelperSQL.Query(sql);
            List<string> res = new List<string>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    if (row["DepartureType"] != null && row["DepartureType"].ToString() != "")
                    {
                        res.Add(row["DepartureType"].ToString());
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

