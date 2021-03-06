﻿using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace TravelAgency.DAL
{
    //user_copy
    public partial class user_copy
    {

        public bool Exists(string WorkId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from user_copy");
            strSql.Append(" where ");
            strSql.Append(" WorkId = @WorkId  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@WorkId", SqlDbType.VarChar,50)           };
            parameters[0].Value = WorkId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据,整形自增长返回id,guid返回parameters[0].Value,string返回true or false
        /// </summary>
        public bool Add(TravelAgency.Model.user_copy model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into user_copy(");
            strSql.Append("WorkId,Account,UserName,Password,UserMobile,DepartmentId,RID,RoleName");
            strSql.Append(") values (");
            strSql.Append("@WorkId,@Account,@UserName,@Password,@UserMobile,@DepartmentId,@RID,@RoleName");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@WorkId", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Account", SqlDbType.VarChar,20) ,
                        new SqlParameter("@UserName", SqlDbType.VarChar,100) ,
                        new SqlParameter("@Password", SqlDbType.VarChar,100) ,
                        new SqlParameter("@UserMobile", SqlDbType.VarChar,50) ,
                        new SqlParameter("@DepartmentId", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@RID", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@RoleName", SqlDbType.VarChar,50)

            };

            parameters[0].Value = model.WorkId;
            parameters[1].Value = model.Account;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.Password;
            parameters[4].Value = model.UserMobile;
            parameters[5].Value = model.DepartmentId;
            parameters[6].Value = model.RID;
            parameters[7].Value = model.RoleName;
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


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(TravelAgency.Model.user_copy model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update user_copy set ");

            strSql.Append(" WorkId = @WorkId , ");
            strSql.Append(" Account = @Account , ");
            strSql.Append(" UserName = @UserName , ");
            strSql.Append(" Password = @Password , ");
            strSql.Append(" UserMobile = @UserMobile , ");
            strSql.Append(" DepartmentId = @DepartmentId , ");
            strSql.Append(" RID = @RID , ");
            strSql.Append(" RoleName = @RoleName  ");
            strSql.Append(" where WorkId=@WorkId  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@WorkId", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Account", SqlDbType.VarChar,20) ,
                        new SqlParameter("@UserName", SqlDbType.VarChar,100) ,
                        new SqlParameter("@Password", SqlDbType.VarChar,100) ,
                        new SqlParameter("@UserMobile", SqlDbType.VarChar,50) ,
                        new SqlParameter("@DepartmentId", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@RID", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@RoleName", SqlDbType.VarChar,50)

            };

            parameters[0].Value = model.WorkId;
            parameters[1].Value = model.Account;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.Password;
            parameters[4].Value = model.UserMobile;
            parameters[5].Value = model.DepartmentId;
            parameters[6].Value = model.RID;
            parameters[7].Value = model.RoleName;
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


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string WorkId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from user_copy ");
            strSql.Append(" where WorkId=@WorkId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@WorkId", SqlDbType.VarChar,50)           };
            parameters[0].Value = WorkId;


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

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string WorkIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from user_copy ");
            strSql.Append(" where WorkId in (" + WorkIdlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgency.Model.user_copy GetModel(string WorkId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WorkId, Account, UserName, Password, UserMobile, DepartmentId, RID, RoleName  ");
            strSql.Append("  from user_copy ");
            strSql.Append(" where WorkId=@WorkId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@WorkId", SqlDbType.VarChar,50)           };
            parameters[0].Value = WorkId;


            TravelAgency.Model.user_copy model = new TravelAgency.Model.user_copy();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// DataRow to Object Model
        /// </summary>
        public TravelAgency.Model.user_copy DataRowToModel(DataRow row)
        {
            TravelAgency.Model.user_copy model = new TravelAgency.Model.user_copy();
            if (row != null)
            {
                if (row["WorkId"] != null && row["WorkId"].ToString() != "")
                {
                    model.WorkId = row["WorkId"].ToString();
                }
                if (row["Account"] != null && row["Account"].ToString() != "")
                {
                    model.Account = row["Account"].ToString();
                }
                if (row["UserName"] != null && row["UserName"].ToString() != "")
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["Password"] != null && row["Password"].ToString() != "")
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["UserMobile"] != null && row["UserMobile"].ToString() != "")
                {
                    model.UserMobile = row["UserMobile"].ToString();
                }
                if (row["DepartmentId"] != null && row["DepartmentId"].ToString() != "")
                {
                    model.DepartmentId = new Guid(row["DepartmentId"].ToString());
                }
                if (row["RID"] != null && row["RID"].ToString() != "")
                {
                    model.RID = new Guid(row["RID"].ToString());
                }
                if (row["RoleName"] != null && row["RoleName"].ToString() != "")
                {
                    model.RoleName = row["RoleName"].ToString();
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return GetList(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据,top=0则是全部数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" WorkId, Account, UserName, Password, UserMobile, DepartmentId, RID, RoleName  ");
            strSql.Append(" FROM user_copy ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM user_copy ");
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
        /// 分页获取数据列表,orderby 必须传(要自己带desc)
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WorkId, Account, UserName, Password, UserMobile, DepartmentId, RID, RoleName  ");

            strSql.Append(" FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            strSql.Append(")AS Row, T.*  from user_copy T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

