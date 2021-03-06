﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
    /// <summary>
    /// 数据访问类:AppAll
    /// </summary>
    public partial class AppAll
    {
        public int GetMaxTemp()
        {
            string sql = "select max(temp) from AppAll";
            var res = DbHelperSQL.GetSingle(sql);
            return (int)res;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public Guid Add(TravelAgency.Model.AppAll model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AppAll(");
            strSql.Append("App_id,UserName,WorkId,DepartmentId,Amount,GroupNo,Details,PayWay,AppTime,Account,Bank_To,Bank,Person,Bank_From,Amount_Spend,Img,EntryTime,Flag,AppNo,PrintState)");
            strSql.Append(" values (");
            strSql.Append("@App_id,@UserName,@WorkId,@DepartmentId,@Amount,@GroupNo,@Details,@PayWay,@AppTime,@Account,@Bank_To,@Bank,@Person,@Bank_From,@Amount_Spend,@Img,@EntryTime,@Flag,@AppNo,@PrintState)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@App_id", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@UserName", SqlDbType.VarChar,50),
                    new SqlParameter("@WorkId", SqlDbType.VarChar,50),
                    new SqlParameter("@DepartmentId", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@Amount", SqlDbType.Float,8),
                    new SqlParameter("@GroupNo", SqlDbType.VarChar,255),
                    new SqlParameter("@Details", SqlDbType.VarChar,-1),
                    new SqlParameter("@PayWay", SqlDbType.VarChar,50),
                    new SqlParameter("@AppTime", SqlDbType.DateTime),
                    new SqlParameter("@Account", SqlDbType.VarChar,50),
                    new SqlParameter("@Bank_To", SqlDbType.VarChar,50),
                    new SqlParameter("@Bank", SqlDbType.VarChar,50),
                    new SqlParameter("@Person", SqlDbType.VarChar,50),
                    new SqlParameter("@Bank_From", SqlDbType.VarChar,50),
                    new SqlParameter("@Amount_Spend", SqlDbType.Float,8),
                    new SqlParameter("@Img", SqlDbType.VarChar,50),
                    new SqlParameter("@EntryTime", SqlDbType.DateTime),
                    new SqlParameter("@Flag", SqlDbType.Int,4),
                    new SqlParameter("@AppNo", SqlDbType.VarChar,12),
                    new SqlParameter("@PrintState", SqlDbType.VarChar,50)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.WorkId;
            parameters[3].Value = model.DepartmentId;
            parameters[4].Value = model.Amount;
            parameters[5].Value = model.GroupNo;
            parameters[6].Value = model.Details;
            parameters[7].Value = model.PayWay;
            parameters[8].Value = model.AppTime;
            parameters[9].Value = model.Account;
            parameters[10].Value = model.Bank_To;
            parameters[11].Value = model.Bank;
            parameters[12].Value = model.Person;
            parameters[13].Value = model.Bank_From;
            parameters[14].Value = model.Amount_Spend;
            parameters[15].Value = model.Img;
            parameters[16].Value = model.EntryTime;
            parameters[17].Value = model.Flag;
            parameters[18].Value = model.AppNo;
            parameters[19].Value = model.PrintState;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return Guid.Empty;
            }
            else
            {
                return (Guid)parameters[0].Value;//返回对应的Guid
            }
        }


        /// <summary>
        /// 按照entrytime倒序排序
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetDataByPageOrderByEntryTime(int start, int end, string where)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * from(SELECT *,ROW_NUMBER() OVER(ORDER BY EntryTime desc) as num from AppAll");
            if (!string.IsNullOrEmpty(where))
            {
                sb.Append(" where ");
                sb.Append(where);
            }
            sb.Append(")");
            //sb.Append(" as t WHERE t.num>=@Start AND t.num<=@End order by EntryTime desc,GroupNo desc,OutState desc");
            sb.Append(" as t WHERE t.num>=@Start AND t.num<=@End");
            string sql = sb.ToString();
            SqlParameter[] pams = new SqlParameter[]{
                new SqlParameter("@Start",SqlDbType.Int){Value=start},
                new SqlParameter("@End",SqlDbType.Int){Value=end}
            };
            return DbHelperSQL.Query(sql, pams);
        }

        public DataSet GetNotCheckedDataByPageOrderByEntryTime(int start, int end, string where)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * from(SELECT *,ROW_NUMBER() OVER(ORDER BY EntryTime desc) as num from AppAll");
            sb.Append(" where app_id in ( select distinct app_id from appstatus where statusFlag<2 ) ");
            sb.Append(" and (Flag in (1,2))");
            if (!string.IsNullOrEmpty(where))
            {
                //sb.Append(" where ");
                sb.Append(" and (" + where + ")");
            }
            sb.Append(")");
            //sb.Append(" as t WHERE t.num>=@Start AND t.num<=@End order by EntryTime desc,GroupNo desc,OutState desc");
            sb.Append(" as t WHERE t.num>=@Start AND t.num<=@End");
            string sql = sb.ToString();
            SqlParameter[] pams = new SqlParameter[]{
                new SqlParameter("@Start",SqlDbType.Int){Value=start},
                new SqlParameter("@End",SqlDbType.Int){Value=end}
            };
            return DbHelperSQL.Query(sql, pams);
        }

        public int GetNotCheckedCount()
        {
            string sql =
                "select COUNT(1) from(select * from AppAll where App_id in (select distinct app_id from AppStatus where StatusFlag<2)  and (Flag in (1,2))) as dual ";
            return (int)DbHelperSQL.GetSingle(sql);
        }


    }
}

