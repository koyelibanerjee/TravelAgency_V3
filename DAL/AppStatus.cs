using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
	/// <summary>
	/// 数据访问类:AppStatus
	/// </summary>
	public partial class AppStatus
	{
		public AppStatus()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid AppStatus_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AppStatus");
			strSql.Append(" where AppStatus_id=@AppStatus_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@AppStatus_id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = AppStatus_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(TravelAgency.Model.AppStatus model)
		{
			StringBuilder strSql=new StringBuilder();
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
			parameters[1].Value = Guid.NewGuid();
			parameters[2].Value = model.CheckPersonId;
			parameters[3].Value = model.CheckPerson;
			parameters[4].Value = model.StatusFlag;
			parameters[5].Value = model.Opinions;
			parameters[6].Value = model.Tips;
			parameters[7].Value = model.CheckTime;
			parameters[8].Value = model.EntryTime;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(TravelAgency.Model.AppStatus model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AppStatus set ");
			strSql.Append("App_id=@App_id,");
			strSql.Append("CheckPersonId=@CheckPersonId,");
			strSql.Append("CheckPerson=@CheckPerson,");
			strSql.Append("StatusFlag=@StatusFlag,");
			strSql.Append("Opinions=@Opinions,");
			strSql.Append("Tips=@Tips,");
			strSql.Append("CheckTime=@CheckTime,");
			strSql.Append("EntryTime=@EntryTime");
			strSql.Append(" where AppStatus_id=@AppStatus_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@App_id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CheckPersonId", SqlDbType.VarChar,50),
					new SqlParameter("@CheckPerson", SqlDbType.VarChar,50),
					new SqlParameter("@StatusFlag", SqlDbType.Int,4),
					new SqlParameter("@Opinions", SqlDbType.VarChar,50),
					new SqlParameter("@Tips", SqlDbType.VarChar,-1),
					new SqlParameter("@CheckTime", SqlDbType.DateTime),
					new SqlParameter("@EntryTime", SqlDbType.DateTime),
					new SqlParameter("@AppStatus_id", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.App_id;
			parameters[1].Value = model.CheckPersonId;
			parameters[2].Value = model.CheckPerson;
			parameters[3].Value = model.StatusFlag;
			parameters[4].Value = model.Opinions;
			parameters[5].Value = model.Tips;
			parameters[6].Value = model.CheckTime;
			parameters[7].Value = model.EntryTime;
			parameters[8].Value = model.AppStatus_id;

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
		public bool Delete(Guid AppStatus_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AppStatus ");
			strSql.Append(" where AppStatus_id=@AppStatus_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@AppStatus_id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = AppStatus_id;

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
		public bool DeleteList(string AppStatus_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AppStatus ");
			strSql.Append(" where AppStatus_id in ("+AppStatus_idlist + ")  ");
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
		public TravelAgency.Model.AppStatus GetModel(Guid AppStatus_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AppStatus_id,App_id,CheckPersonId,CheckPerson,StatusFlag,Opinions,Tips,CheckTime,EntryTime from AppStatus ");
			strSql.Append(" where AppStatus_id=@AppStatus_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@AppStatus_id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = AppStatus_id;

			TravelAgency.Model.AppStatus model=new TravelAgency.Model.AppStatus();
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
		public TravelAgency.Model.AppStatus DataRowToModel(DataRow row)
		{
			TravelAgency.Model.AppStatus model=new TravelAgency.Model.AppStatus();
			if (row != null)
			{
				if(row["AppStatus_id"]!=null && row["AppStatus_id"].ToString()!="")
				{
					model.AppStatus_id= new Guid(row["AppStatus_id"].ToString());
				}
				if(row["App_id"]!=null && row["App_id"].ToString()!="")
				{
					model.App_id= new Guid(row["App_id"].ToString());
				}
				if(row["CheckPersonId"]!=null)
				{
					model.CheckPersonId=row["CheckPersonId"].ToString();
				}
				if(row["CheckPerson"]!=null)
				{
					model.CheckPerson=row["CheckPerson"].ToString();
				}
				if(row["StatusFlag"]!=null && row["StatusFlag"].ToString()!="")
				{
					model.StatusFlag=int.Parse(row["StatusFlag"].ToString());
				}
				if(row["Opinions"]!=null)
				{
					model.Opinions=row["Opinions"].ToString();
				}
				if(row["Tips"]!=null)
				{
					model.Tips=row["Tips"].ToString();
				}
				if(row["CheckTime"]!=null && row["CheckTime"].ToString()!="")
				{
					model.CheckTime=DateTime.Parse(row["CheckTime"].ToString());
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
			strSql.Append("select AppStatus_id,App_id,CheckPersonId,CheckPerson,StatusFlag,Opinions,Tips,CheckTime,EntryTime ");
			strSql.Append(" FROM AppStatus ");
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
			strSql.Append(" AppStatus_id,App_id,CheckPersonId,CheckPerson,StatusFlag,Opinions,Tips,CheckTime,EntryTime ");
			strSql.Append(" FROM AppStatus ");
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
			strSql.Append("select count(1) FROM AppStatus ");
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
				strSql.Append("order by T.AppStatus_id desc");
			}
			strSql.Append(")AS Row, T.*  from AppStatus T ");
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
			parameters[0].Value = "AppStatus";
			parameters[1].Value = "AppStatus_id";
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

