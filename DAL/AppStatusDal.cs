using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Maticsoft.DBUtility;

namespace TravelAgency.DAL
{
    public partial class AppStatus
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TravelAgency.Model.AppStatus model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AppStatus(");
            strSql.Append("AppStatus_id,App_id,CheckPersonId,CheckPerson,StatusFlag,Opinions,Tips,CheckTime,EntryTime)");
            strSql.Append(" values (");
            strSql.Append("@AppStatus_id,@App_id,@CheckPersonId,@CheckPerson,@StatusFlag,@Opinions,@Tips,@CheckTime,@EntryTime)");
            SqlParameter[] parameters = {
                    new SqlParameter("@AppStatus_id", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@App_id", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@CheckPersonId", SqlDbType.VarChar,50),
                    new SqlParameter("@CheckPerson", SqlDbType.VarChar,50),
                    new SqlParameter("@StatusFlag", SqlDbType.Int,4),
                    new SqlParameter("@Opinions", SqlDbType.VarChar,50),
                    new SqlParameter("@Tips", SqlDbType.VarChar,-1),
                    new SqlParameter("@CheckTime", SqlDbType.DateTime),
                    new SqlParameter("@EntryTime", SqlDbType.DateTime)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.App_id; //这里使用指定的ID
            parameters[2].Value = model.CheckPersonId;
            parameters[3].Value = model.CheckPerson;
            parameters[4].Value = model.StatusFlag;
            parameters[5].Value = model.Opinions;
            parameters[6].Value = model.Tips;
            parameters[7].Value = model.CheckTime;
            parameters[8].Value = model.EntryTime;

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