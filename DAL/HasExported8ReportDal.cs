using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
	/// <summary>
	/// 数据访问类:HasExported8Report
	/// </summary>
	public partial class HasExported8Report
	{
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TravelAgency.Model.HasExported8Report model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HasExported8Report(");
            strSql.Append("VisaInfo_id,EntryTime)");
            strSql.Append(" values (");
            strSql.Append("@VisaInfo_id,@EntryTime)");
            SqlParameter[] parameters = {
                    new SqlParameter("@VisaInfo_id", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@EntryTime", SqlDbType.DateTime)};
            parameters[0].Value = model.VisaInfo_id; //这里必须是已有的visainfo_id
            parameters[1].Value = model.EntryTime;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

