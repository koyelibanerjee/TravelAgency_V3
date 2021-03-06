﻿using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace TravelAgency.DAL
{
    //WorkerQueue
    public partial class WorkerQueue
    {

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from WorkerQueue");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据,整形自增长返回id,guid返回parameters[0].Value,string返回true or false
        /// </summary>
        public int Add(TravelAgency.Model.WorkerQueue model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WorkerQueue(");
            strSql.Append("WorkId,UserName,IsBusy,CanAccept,Priority,District");
            strSql.Append(") values (");
            strSql.Append("@WorkId,@UserName,@IsBusy,@CanAccept,@Priority,@District");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@WorkId", SqlDbType.VarChar,50) ,
                        new SqlParameter("@UserName", SqlDbType.VarChar,50) ,
                        new SqlParameter("@IsBusy", SqlDbType.Bit,1) ,
                        new SqlParameter("@CanAccept", SqlDbType.Bit,1) ,
                        new SqlParameter("@Priority", SqlDbType.Int,4) ,
                        new SqlParameter("@District", SqlDbType.Int,4)

            };

            parameters[0].Value = model.WorkId;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.IsBusy;
            parameters[3].Value = model.CanAccept;
            parameters[4].Value = model.Priority;
            parameters[5].Value = model.District;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(TravelAgency.Model.WorkerQueue model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WorkerQueue set ");

            strSql.Append(" WorkId = @WorkId , ");
            strSql.Append(" UserName = @UserName , ");
            strSql.Append(" IsBusy = @IsBusy , ");
            strSql.Append(" CanAccept = @CanAccept , ");
            strSql.Append(" Priority = @Priority , ");
            strSql.Append(" District = @District  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
                        new SqlParameter("@Id", SqlDbType.Int,4) ,
                        new SqlParameter("@WorkId", SqlDbType.VarChar,50) ,
                        new SqlParameter("@UserName", SqlDbType.VarChar,50) ,
                        new SqlParameter("@IsBusy", SqlDbType.Bit,1) ,
                        new SqlParameter("@CanAccept", SqlDbType.Bit,1) ,
                        new SqlParameter("@Priority", SqlDbType.Int,4) ,
                        new SqlParameter("@District", SqlDbType.Int,4)

            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.WorkId;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.IsBusy;
            parameters[4].Value = model.CanAccept;
            parameters[5].Value = model.Priority;
            parameters[6].Value = model.District;
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
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WorkerQueue ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;


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
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WorkerQueue ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
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
        public TravelAgency.Model.WorkerQueue GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, WorkId, UserName, IsBusy, CanAccept, Priority, District  ");
            strSql.Append("  from WorkerQueue ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;


            TravelAgency.Model.WorkerQueue model = new TravelAgency.Model.WorkerQueue();
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
        public TravelAgency.Model.WorkerQueue DataRowToModel(DataRow row)
        {
            TravelAgency.Model.WorkerQueue model = new TravelAgency.Model.WorkerQueue();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["WorkId"] != null && row["WorkId"].ToString() != "")
                {
                    model.WorkId = row["WorkId"].ToString();
                }
                if (row["UserName"] != null && row["UserName"].ToString() != "")
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["IsBusy"] != null && row["IsBusy"].ToString() != "")
                {
                    if ((row["IsBusy"].ToString() == "1") || (row["IsBusy"].ToString().ToLower() == "true"))
                    {
                        model.IsBusy = true;
                    }
                    else
                    {
                        model.IsBusy = false;
                    }
                }
                if (row["CanAccept"] != null && row["CanAccept"].ToString() != "")
                {
                    if ((row["CanAccept"].ToString() == "1") || (row["CanAccept"].ToString().ToLower() == "true"))
                    {
                        model.CanAccept = true;
                    }
                    else
                    {
                        model.CanAccept = false;
                    }
                }
                if (row["Priority"] != null && row["Priority"].ToString() != "")
                {
                    model.Priority = int.Parse(row["Priority"].ToString());
                }
                if (row["District"] != null && row["District"].ToString() != "")
                {
                    model.District = int.Parse(row["District"].ToString());
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
            strSql.Append(" Id, WorkId, UserName, IsBusy, CanAccept, Priority, District  ");
            strSql.Append(" FROM WorkerQueue ");
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
            strSql.Append("select count(1) FROM WorkerQueue ");
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
            strSql.Append("select Id, WorkId, UserName, IsBusy, CanAccept, Priority, District  ");

            strSql.Append(" FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            strSql.Append(")AS Row, T.*  from WorkerQueue T ");
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

