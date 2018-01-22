using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Maticsoft.DBUtility;

namespace TravelAgency.DAL
{
    public class StatisticsDal
    {
        /// <summary>
        /// 用来查询visainfo和visa的记录条目
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetRecordCount(string tablename, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM " + tablename + " ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }


        /// <summary>
        /// 取操作数目(按照visainfo_id出现次数进行统计)
        /// </summary>
        /// <param name="ActType"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public int GetActRecordCount(string where)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT distinct visainfo_id from ActionRecords");
            if(!string.IsNullOrEmpty(where))
                sb.Append(" where " + where + " ");

            string sql = sb.ToString();
            return DbHelperSQL.Query(sql).Tables[0].Rows.Count;
        }


    }
}