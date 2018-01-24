using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;

namespace TravelAgency.DAL
{
    public class CommonDal
    {
        public static List<string> GetFieldList(string tableName, string filedName)
        {
            string sql = "select distinct " + filedName + " from " + tableName;
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
            else
            {
                return null;
            }
        }
    }
}