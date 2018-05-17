using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
	/// <summary>
	/// 数据访问类:CustomerBalance
	/// </summary>
	public partial class CustomerBalance
	{
		public CustomerBalance()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid BalanceId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CustomerBalance");
			strSql.Append(" where BalanceId=@BalanceId ");
			SqlParameter[] parameters = {
					new SqlParameter("@BalanceId", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = BalanceId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(TravelAgency.Model.CustomerBalance model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CustomerBalance(");
			strSql.Append("BalanceId,Money_id,CustomeID,CustomerName,Mobile,Amount,BalanceAmount,BalanceFlag,WorkId,EntryTime,MoneyType)");
			strSql.Append(" values (");
			strSql.Append("@BalanceId,@Money_id,@CustomeID,@CustomerName,@Mobile,@Amount,@BalanceAmount,@BalanceFlag,@WorkId,@EntryTime,@MoneyType)");
			SqlParameter[] parameters = {
					new SqlParameter("@BalanceId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@Money_id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CustomeID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CustomerName", SqlDbType.VarChar,150),
					new SqlParameter("@Mobile", SqlDbType.VarChar,150),
					new SqlParameter("@Amount", SqlDbType.Float,8),
					new SqlParameter("@BalanceAmount", SqlDbType.Float,8),
					new SqlParameter("@BalanceFlag", SqlDbType.Int,4),
					new SqlParameter("@WorkId", SqlDbType.VarChar,150),
					new SqlParameter("@EntryTime", SqlDbType.DateTime),
					new SqlParameter("@MoneyType", SqlDbType.VarChar,50)};
			parameters[0].Value = Guid.NewGuid();
			parameters[1].Value = Guid.NewGuid();
			parameters[2].Value = Guid.NewGuid();
			parameters[3].Value = model.CustomerName;
			parameters[4].Value = model.Mobile;
			parameters[5].Value = model.Amount;
			parameters[6].Value = model.BalanceAmount;
			parameters[7].Value = model.BalanceFlag;
			parameters[8].Value = model.WorkId;
			parameters[9].Value = model.EntryTime;
			parameters[10].Value = model.MoneyType;

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
		public bool Update(TravelAgency.Model.CustomerBalance model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CustomerBalance set ");
			strSql.Append("Money_id=@Money_id,");
			strSql.Append("CustomeID=@CustomeID,");
			strSql.Append("CustomerName=@CustomerName,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("Amount=@Amount,");
			strSql.Append("BalanceAmount=@BalanceAmount,");
			strSql.Append("BalanceFlag=@BalanceFlag,");
			strSql.Append("WorkId=@WorkId,");
			strSql.Append("EntryTime=@EntryTime,");
			strSql.Append("MoneyType=@MoneyType");
			strSql.Append(" where BalanceId=@BalanceId ");
			SqlParameter[] parameters = {
					new SqlParameter("@Money_id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CustomeID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CustomerName", SqlDbType.VarChar,150),
					new SqlParameter("@Mobile", SqlDbType.VarChar,150),
					new SqlParameter("@Amount", SqlDbType.Float,8),
					new SqlParameter("@BalanceAmount", SqlDbType.Float,8),
					new SqlParameter("@BalanceFlag", SqlDbType.Int,4),
					new SqlParameter("@WorkId", SqlDbType.VarChar,150),
					new SqlParameter("@EntryTime", SqlDbType.DateTime),
					new SqlParameter("@MoneyType", SqlDbType.VarChar,50),
					new SqlParameter("@BalanceId", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.Money_id;
			parameters[1].Value = model.CustomeID;
			parameters[2].Value = model.CustomerName;
			parameters[3].Value = model.Mobile;
			parameters[4].Value = model.Amount;
			parameters[5].Value = model.BalanceAmount;
			parameters[6].Value = model.BalanceFlag;
			parameters[7].Value = model.WorkId;
			parameters[8].Value = model.EntryTime;
			parameters[9].Value = model.MoneyType;
			parameters[10].Value = model.BalanceId;

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
		public bool Delete(Guid BalanceId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CustomerBalance ");
			strSql.Append(" where BalanceId=@BalanceId ");
			SqlParameter[] parameters = {
					new SqlParameter("@BalanceId", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = BalanceId;

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
		public bool DeleteList(string BalanceIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CustomerBalance ");
			strSql.Append(" where BalanceId in ("+BalanceIdlist + ")  ");
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
		public TravelAgency.Model.CustomerBalance GetModel(Guid BalanceId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 BalanceId,Money_id,CustomeID,CustomerName,Mobile,Amount,BalanceAmount,BalanceFlag,WorkId,EntryTime,MoneyType from CustomerBalance ");
			strSql.Append(" where BalanceId=@BalanceId ");
			SqlParameter[] parameters = {
					new SqlParameter("@BalanceId", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = BalanceId;

			TravelAgency.Model.CustomerBalance model=new TravelAgency.Model.CustomerBalance();
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
		public TravelAgency.Model.CustomerBalance DataRowToModel(DataRow row)
		{
			TravelAgency.Model.CustomerBalance model=new TravelAgency.Model.CustomerBalance();
			if (row != null)
			{
				if(row["BalanceId"]!=null && row["BalanceId"].ToString()!="")
				{
					model.BalanceId= new Guid(row["BalanceId"].ToString());
				}
				if(row["Money_id"]!=null && row["Money_id"].ToString()!="")
				{
					model.Money_id= new Guid(row["Money_id"].ToString());
				}
				if(row["CustomeID"]!=null && row["CustomeID"].ToString()!="")
				{
					model.CustomeID= new Guid(row["CustomeID"].ToString());
				}
				if(row["CustomerName"]!=null)
				{
					model.CustomerName=row["CustomerName"].ToString();
				}
				if(row["Mobile"]!=null)
				{
					model.Mobile=row["Mobile"].ToString();
				}
				if(row["Amount"]!=null && row["Amount"].ToString()!="")
				{
					model.Amount=decimal.Parse(row["Amount"].ToString());
				}
				if(row["BalanceAmount"]!=null && row["BalanceAmount"].ToString()!="")
				{
					model.BalanceAmount=decimal.Parse(row["BalanceAmount"].ToString());
				}
				if(row["BalanceFlag"]!=null && row["BalanceFlag"].ToString()!="")
				{
					model.BalanceFlag=int.Parse(row["BalanceFlag"].ToString());
				}
				if(row["WorkId"]!=null)
				{
					model.WorkId=row["WorkId"].ToString();
				}
				if(row["EntryTime"]!=null && row["EntryTime"].ToString()!="")
				{
					model.EntryTime=DateTime.Parse(row["EntryTime"].ToString());
				}
				if(row["MoneyType"]!=null)
				{
					model.MoneyType=row["MoneyType"].ToString();
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
			strSql.Append("select BalanceId,Money_id,CustomeID,CustomerName,Mobile,Amount,BalanceAmount,BalanceFlag,WorkId,EntryTime,MoneyType ");
			strSql.Append(" FROM CustomerBalance ");
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
			strSql.Append(" BalanceId,Money_id,CustomeID,CustomerName,Mobile,Amount,BalanceAmount,BalanceFlag,WorkId,EntryTime,MoneyType ");
			strSql.Append(" FROM CustomerBalance ");
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
			strSql.Append("select count(1) FROM CustomerBalance ");
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
				strSql.Append("order by T.BalanceId desc");
			}
			strSql.Append(")AS Row, T.*  from CustomerBalance T ");
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
			parameters[0].Value = "CustomerBalance";
			parameters[1].Value = "BalanceId";
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

