using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace TravelAgency.DAL
{
    //OrdersLogs
    public partial class OrdersLogs
    {

        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OrdersLogs");
            strSql.Append(" where ");
            strSql.Append(" id = @id  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据,如果需要获取除了自增长类型外的主键返回值，请自己改写方法，返回parameters[0].Value
        /// </summary>
        public int Add(TravelAgency.Model.OrdersLogs model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrdersLogs(");
            strSql.Append("ActType,UserName,OrdersId,EntryTime,WorkId,OrderNo");
            strSql.Append(") values (");
            strSql.Append("@ActType,@UserName,@OrdersId,@EntryTime,@WorkId,@OrderNo");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@ActType", SqlDbType.TinyInt,1) ,
                        new SqlParameter("@UserName", SqlDbType.VarChar,100) ,
                        new SqlParameter("@OrdersId", SqlDbType.Int,4) ,
                        new SqlParameter("@EntryTime", SqlDbType.DateTime) ,
                        new SqlParameter("@WorkId", SqlDbType.VarChar,10) ,
                        new SqlParameter("@OrderNo", SqlDbType.VarChar,50)

            };

            parameters[0].Value = model.ActType;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.OrdersId;
            parameters[3].Value = model.EntryTime;
            parameters[4].Value = model.WorkId;
            parameters[5].Value = model.OrderNo;

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
        public bool Update(TravelAgency.Model.OrdersLogs model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrdersLogs set ");

            strSql.Append(" ActType = @ActType , ");
            strSql.Append(" UserName = @UserName , ");
            strSql.Append(" OrdersId = @OrdersId , ");
            strSql.Append(" EntryTime = @EntryTime , ");
            strSql.Append(" WorkId = @WorkId , ");
            strSql.Append(" OrderNo = @OrderNo  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
                        new SqlParameter("@id", SqlDbType.Int,4) ,
                        new SqlParameter("@ActType", SqlDbType.TinyInt,1) ,
                        new SqlParameter("@UserName", SqlDbType.VarChar,100) ,
                        new SqlParameter("@OrdersId", SqlDbType.Int,4) ,
                        new SqlParameter("@EntryTime", SqlDbType.DateTime) ,
                        new SqlParameter("@WorkId", SqlDbType.VarChar,10) ,
                        new SqlParameter("@OrderNo", SqlDbType.VarChar,50)

            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.ActType;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.OrdersId;
            parameters[4].Value = model.EntryTime;
            parameters[5].Value = model.WorkId;
            parameters[6].Value = model.OrderNo;
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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrdersLogs ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;


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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrdersLogs ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public TravelAgency.Model.OrdersLogs GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, ActType, UserName, OrdersId, EntryTime, WorkId, OrderNo  ");
            strSql.Append("  from OrdersLogs ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;


            TravelAgency.Model.OrdersLogs model = new TravelAgency.Model.OrdersLogs();
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
        public TravelAgency.Model.OrdersLogs DataRowToModel(DataRow row)
        {
            TravelAgency.Model.OrdersLogs model = new TravelAgency.Model.OrdersLogs();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["ActType"] != null && row["ActType"].ToString() != "")
                {
                    model.ActType = int.Parse(row["ActType"].ToString());
                }
                if (row["UserName"] != null && row["UserName"].ToString() != "")
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["OrdersId"] != null && row["OrdersId"].ToString() != "")
                {
                    model.OrdersId = int.Parse(row["OrdersId"].ToString());
                }
                if (row["EntryTime"] != null && row["EntryTime"].ToString() != "")
                {
                    model.EntryTime = DateTime.Parse(row["EntryTime"].ToString());
                }
                if (row["WorkId"] != null && row["WorkId"].ToString() != "")
                {
                    model.WorkId = row["WorkId"].ToString();
                }
                if (row["OrderNo"] != null && row["OrderNo"].ToString() != "")
                {
                    model.OrderNo = row["OrderNo"].ToString();
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
            strSql.Append(" id, ActType, UserName, OrdersId, EntryTime, WorkId, OrderNo  ");
            strSql.Append(" FROM OrdersLogs ");
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
            strSql.Append("select count(1) FROM OrdersLogs ");
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
        /// 分页获取数据列表,orderby 必须传
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, ActType, UserName, OrdersId, EntryTime, WorkId, OrderNo  ");

            strSql.Append(" FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            strSql.Append(")AS Row, T.*  from OrdersLogs T ");
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

