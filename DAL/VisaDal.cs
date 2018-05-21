using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maticsoft.DBUtility;

namespace TravelAgency.DAL
{
    public partial class Visa
    {
        
        public DataSet GetDataByPage(int start, int end, string where)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * from(SELECT *,ROW_NUMBER() OVER(ORDER BY EntryTime desc) as num from Visa");

            if (!string.IsNullOrEmpty(where))
            {
                sb.Append(" where ");
                sb.Append(where);
            }
            sb.Append(")");

            sb.Append(" as t WHERE t.num>=@Start AND t.num<=@End order by EntryTime desc");
            string sql = sb.ToString();
            SqlParameter[] pams = new SqlParameter[]{
                new SqlParameter("@Start",SqlDbType.Int){Value=start},
                new SqlParameter("@End",SqlDbType.Int){Value=end}
            };
            return DbHelperSQL.Query(sql, pams);
        }

        public DataSet GetLastRecord(string type)
        {
            string sql = "select top 1 * from visa";
            if (!string.IsNullOrEmpty(type))
            {
                sql += " where types='" + type + "'";
            }
            sql += "order by entryTime desc";

            return DbHelperSQL.Query(sql);
        }

        public DataSet GetLastRecordOfTheDay(DateTime date)
        {
            string sql = "select top 1 * from visa";

            sql += " where entrytime between'" + date.ToString("yyyy-MM-dd") + " 0:0:0' and '" + date.ToString("yyyy-MM-dd") + " 23:59:59' ";
            sql += "order by entryTime desc";

            return DbHelperSQL.Query(sql);
        }
    }
}
