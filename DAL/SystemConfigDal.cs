using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maticsoft.DBUtility;

namespace TravelAgency.DAL
{
    public class SystemConfigDal
    {
        public string getConfigValue(string configname)
        {
            string sql = $"select Value from SystemConfig where Config = '{configname}' ";
            var ds = DbHelperSQL.Query(sql);
            if (ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1)
                return null;
            return ds.Tables[0].Rows[0]["Value"].ToString();
        }

        public int setConfigValue(string configname, string value)
        {
            string sql = $"update SystemConfig set Value = '{value}' where Config = '{configname}' ";
            return DbHelperSQL.ExecuteSql(sql);
        }

    }
}
