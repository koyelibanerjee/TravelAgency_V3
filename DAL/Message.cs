using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
	/// <summary>
	/// 数据访问类:Message
	/// </summary>
	public partial class Message
	{
		public Message()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "Message"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Message");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TravelAgency.Model.Message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Message(");
			strSql.Append("FromUser,ToUser,MsgContent,MsgType,MsgState,OrderNo,ReplyId,IsUrgent,EntryTime)");
			strSql.Append(" values (");
			strSql.Append("@FromUser,@ToUser,@MsgContent,@MsgType,@MsgState,@OrderNo,@ReplyId,@IsUrgent,@EntryTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FromUser", SqlDbType.VarChar,50),
					new SqlParameter("@ToUser", SqlDbType.VarChar,50),
					new SqlParameter("@MsgContent", SqlDbType.Text),
					new SqlParameter("@MsgType", SqlDbType.VarChar,10),
					new SqlParameter("@MsgState", SqlDbType.VarChar,10),
					new SqlParameter("@OrderNo", SqlDbType.VarChar,50),
					new SqlParameter("@ReplyId", SqlDbType.Int,4),
					new SqlParameter("@IsUrgent", SqlDbType.Bit,1),
					new SqlParameter("@EntryTime", SqlDbType.DateTime)};
			parameters[0].Value = model.FromUser;
			parameters[1].Value = model.ToUser;
			parameters[2].Value = model.MsgContent;
			parameters[3].Value = model.MsgType;
			parameters[4].Value = model.MsgState;
			parameters[5].Value = model.OrderNo;
			parameters[6].Value = model.ReplyId;
			parameters[7].Value = model.IsUrgent;
			parameters[8].Value = model.EntryTime;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(TravelAgency.Model.Message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Message set ");
			strSql.Append("FromUser=@FromUser,");
			strSql.Append("ToUser=@ToUser,");
			strSql.Append("MsgContent=@MsgContent,");
			strSql.Append("MsgType=@MsgType,");
			strSql.Append("MsgState=@MsgState,");
			strSql.Append("OrderNo=@OrderNo,");
			strSql.Append("ReplyId=@ReplyId,");
			strSql.Append("IsUrgent=@IsUrgent,");
			strSql.Append("EntryTime=@EntryTime");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@FromUser", SqlDbType.VarChar,50),
					new SqlParameter("@ToUser", SqlDbType.VarChar,50),
					new SqlParameter("@MsgContent", SqlDbType.Text),
					new SqlParameter("@MsgType", SqlDbType.VarChar,10),
					new SqlParameter("@MsgState", SqlDbType.VarChar,10),
					new SqlParameter("@OrderNo", SqlDbType.VarChar,50),
					new SqlParameter("@ReplyId", SqlDbType.Int,4),
					new SqlParameter("@IsUrgent", SqlDbType.Bit,1),
					new SqlParameter("@EntryTime", SqlDbType.DateTime),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.FromUser;
			parameters[1].Value = model.ToUser;
			parameters[2].Value = model.MsgContent;
			parameters[3].Value = model.MsgType;
			parameters[4].Value = model.MsgState;
			parameters[5].Value = model.OrderNo;
			parameters[6].Value = model.ReplyId;
			parameters[7].Value = model.IsUrgent;
			parameters[8].Value = model.EntryTime;
			parameters[9].Value = model.Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Message ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Message ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public TravelAgency.Model.Message GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,FromUser,ToUser,MsgContent,MsgType,MsgState,OrderNo,ReplyId,IsUrgent,EntryTime from Message ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			TravelAgency.Model.Message model=new TravelAgency.Model.Message();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TravelAgency.Model.Message DataRowToModel(DataRow row)
		{
			TravelAgency.Model.Message model=new TravelAgency.Model.Message();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["FromUser"]!=null)
				{
					model.FromUser=row["FromUser"].ToString();
				}
				if(row["ToUser"]!=null)
				{
					model.ToUser=row["ToUser"].ToString();
				}
				if(row["MsgContent"]!=null)
				{
					model.MsgContent=row["MsgContent"].ToString();
				}
				if(row["MsgType"]!=null)
				{
					model.MsgType=row["MsgType"].ToString();
				}
				if(row["MsgState"]!=null)
				{
					model.MsgState=row["MsgState"].ToString();
				}
				if(row["OrderNo"]!=null)
				{
					model.OrderNo=row["OrderNo"].ToString();
				}
				if(row["ReplyId"]!=null && row["ReplyId"].ToString()!="")
				{
					model.ReplyId=int.Parse(row["ReplyId"].ToString());
				}
				if(row["IsUrgent"]!=null && row["IsUrgent"].ToString()!="")
				{
					if((row["IsUrgent"].ToString()=="1")||(row["IsUrgent"].ToString().ToLower()=="true"))
					{
						model.IsUrgent=true;
					}
					else
					{
						model.IsUrgent=false;
					}
				}
				if(row["EntryTime"]!=null && row["EntryTime"].ToString()!="")
				{
					model.EntryTime=DateTime.Parse(row["EntryTime"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,FromUser,ToUser,MsgContent,MsgType,MsgState,OrderNo,ReplyId,IsUrgent,EntryTime ");
			strSql.Append(" FROM Message ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Id,FromUser,ToUser,MsgContent,MsgType,MsgState,OrderNo,ReplyId,IsUrgent,EntryTime ");
			strSql.Append(" FROM Message ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Message ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from Message T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Message";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

