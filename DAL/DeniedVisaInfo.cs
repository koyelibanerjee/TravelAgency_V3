using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace TravelAgency.DAL
{
    //DeniedVisaInfo
    public partial class DeniedVisaInfo
    {

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DeniedVisaInfo");
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
        public int Add(TravelAgency.Model.DeniedVisaInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DeniedVisaInfo(");
            strSql.Append("EntryTime,Name,PassportNo,DenyReason,Remark,OperatorName,OperatorWorkId");
            strSql.Append(") values (");
            strSql.Append("@EntryTime,@Name,@PassportNo,@DenyReason,@Remark,@OperatorName,@OperatorWorkId");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@EntryTime", SqlDbType.DateTime) ,
                        new SqlParameter("@Name", SqlDbType.VarChar,50) ,
                        new SqlParameter("@PassportNo", SqlDbType.VarChar,50) ,
                        new SqlParameter("@DenyReason", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Remark", SqlDbType.VarChar,100) ,
                        new SqlParameter("@OperatorName", SqlDbType.VarChar,50) ,
                        new SqlParameter("@OperatorWorkId", SqlDbType.VarChar,50)

            };

            parameters[0].Value = model.EntryTime;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.PassportNo;
            parameters[3].Value = model.DenyReason;
            parameters[4].Value = model.Remark;
            parameters[5].Value = model.OperatorName;
            parameters[6].Value = model.OperatorWorkId;

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
        public bool Update(TravelAgency.Model.DeniedVisaInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DeniedVisaInfo set ");

            strSql.Append(" EntryTime = @EntryTime , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" PassportNo = @PassportNo , ");
            strSql.Append(" DenyReason = @DenyReason , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" OperatorName = @OperatorName , ");
            strSql.Append(" OperatorWorkId = @OperatorWorkId  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
                        new SqlParameter("@Id", SqlDbType.Int,4) ,
                        new SqlParameter("@EntryTime", SqlDbType.DateTime) ,
                        new SqlParameter("@Name", SqlDbType.VarChar,50) ,
                        new SqlParameter("@PassportNo", SqlDbType.VarChar,50) ,
                        new SqlParameter("@DenyReason", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Remark", SqlDbType.VarChar,100) ,
                        new SqlParameter("@OperatorName", SqlDbType.VarChar,50) ,
                        new SqlParameter("@OperatorWorkId", SqlDbType.VarChar,50)

            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.EntryTime;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.PassportNo;
            parameters[4].Value = model.DenyReason;
            parameters[5].Value = model.Remark;
            parameters[6].Value = model.OperatorName;
            parameters[7].Value = model.OperatorWorkId;
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
            strSql.Append("delete from DeniedVisaInfo ");
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
            strSql.Append("delete from DeniedVisaInfo ");
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
        public TravelAgency.Model.DeniedVisaInfo GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, EntryTime, Name, PassportNo, DenyReason, Remark, OperatorName, OperatorWorkId  ");
            strSql.Append("  from DeniedVisaInfo ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;


            TravelAgency.Model.DeniedVisaInfo model = new TravelAgency.Model.DeniedVisaInfo();
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
        public TravelAgency.Model.DeniedVisaInfo DataRowToModel(DataRow row)
        {
            TravelAgency.Model.DeniedVisaInfo model = new TravelAgency.Model.DeniedVisaInfo();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["EntryTime"] != null && row["EntryTime"].ToString() != "")
                {
                    model.EntryTime = DateTime.Parse(row["EntryTime"].ToString());
                }
                if (row["Name"] != null && row["Name"].ToString() != "")
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["PassportNo"] != null && row["PassportNo"].ToString() != "")
                {
                    model.PassportNo = row["PassportNo"].ToString();
                }
                if (row["DenyReason"] != null && row["DenyReason"].ToString() != "")
                {
                    model.DenyReason = row["DenyReason"].ToString();
                }
                if (row["Remark"] != null && row["Remark"].ToString() != "")
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["OperatorName"] != null && row["OperatorName"].ToString() != "")
                {
                    model.OperatorName = row["OperatorName"].ToString();
                }
                if (row["OperatorWorkId"] != null && row["OperatorWorkId"].ToString() != "")
                {
                    model.OperatorWorkId = row["OperatorWorkId"].ToString();
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
            strSql.Append(" Id, EntryTime, Name, PassportNo, DenyReason, Remark, OperatorName, OperatorWorkId  ");
            strSql.Append(" FROM DeniedVisaInfo ");
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
            strSql.Append("select count(1) FROM DeniedVisaInfo ");
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
            strSql.Append("select Id, EntryTime, Name, PassportNo, DenyReason, Remark, OperatorName, OperatorWorkId  ");

            strSql.Append(" FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            strSql.Append(")AS Row, T.*  from DeniedVisaInfo T ");
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

