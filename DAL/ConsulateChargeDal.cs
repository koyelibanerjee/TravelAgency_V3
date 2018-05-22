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

        /// <summary>
        /// 按照entrytime,groupNo,outstate排序，给签证录入界面用的//20180109修改为只按照录入时间排序
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetDataByPageOrderByCountry(int start, int end, string where)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * from(SELECT *,ROW_NUMBER() OVER(ORDER BY id) as num from ConsulateCharge");
            if (!string.IsNullOrEmpty(where))
            {
                sb.Append(" where ");
                sb.Append(where);
            }
            sb.Append(")");
            sb.Append(" as t WHERE t.num>=@Start AND t.num<=@End order by Country asc");
            string sql = sb.ToString();
            SqlParameter[] pams = new SqlParameter[]{
                new SqlParameter("@Start",SqlDbType.Int){Value=start},
                new SqlParameter("@End",SqlDbType.Int){Value=end}
            };
            return DbHelperSQL.Query(sql, pams);
        }





    }
}

