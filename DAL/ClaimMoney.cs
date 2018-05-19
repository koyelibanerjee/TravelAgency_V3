using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
	/// <summary>
	/// 数据访问类:ClaimMoney
	/// </summary>
	public partial class ClaimMoney
	{
		public ClaimMoney()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid Claim_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ClaimMoney");
			strSql.Append(" where Claim_id=@Claim_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Claim_id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Claim_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}



		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(TravelAgency.Model.ClaimMoney model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ClaimMoney set ");
			strSql.Append("Money_id=@Money_id,");
			strSql.Append("DepartmentId=@DepartmentId,");
			strSql.Append("Name_Claim=@Name_Claim,");
			strSql.Append("GroupNo=@GroupNo,");
			strSql.Append("Salesperson=@Salesperson,");
			strSql.Append("Guests=@Guests,");
			strSql.Append("Methods=@Methods,");
			strSql.Append("Amount=@Amount,");
			strSql.Append("WorkId=@WorkId,");
			strSql.Append("ClaimTime=@ClaimTime,");
			strSql.Append("username=@username,");
			strSql.Append("OrderNo=@OrderNo,");
			strSql.Append("EntryTime=@EntryTime,");
			strSql.Append("MoneyType=@MoneyType,");
			strSql.Append("Claim_Confirm=@Claim_Confirm");
			strSql.Append(" where Claim_id=@Claim_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Money_id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@DepartmentId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@Name_Claim", SqlDbType.VarChar,50),
					new SqlParameter("@GroupNo", SqlDbType.VarChar,900),
					new SqlParameter("@Salesperson", SqlDbType.VarChar,50),
					new SqlParameter("@Guests", SqlDbType.VarChar,50),
					new SqlParameter("@Methods", SqlDbType.VarChar,255),
					new SqlParameter("@Amount", SqlDbType.Float,8),
					new SqlParameter("@WorkId", SqlDbType.VarChar,50),
					new SqlParameter("@ClaimTime", SqlDbType.DateTime),
					new SqlParameter("@username", SqlDbType.VarChar,50),
					new SqlParameter("@OrderNo", SqlDbType.VarChar,255),
					new SqlParameter("@EntryTime", SqlDbType.DateTime),
					new SqlParameter("@MoneyType", SqlDbType.VarChar,50),
					new SqlParameter("@Claim_Confirm", SqlDbType.VarChar,50),
					new SqlParameter("@Claim_id", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.Money_id;
			parameters[1].Value = model.DepartmentId;
			parameters[2].Value = model.Name_Claim;
			parameters[3].Value = model.GroupNo;
			parameters[4].Value = model.Salesperson;
			parameters[5].Value = model.Guests;
			parameters[6].Value = model.Methods;
			parameters[7].Value = model.Amount;
			parameters[8].Value = model.WorkId;
			parameters[9].Value = model.ClaimTime;
			parameters[10].Value = model.username;
			parameters[11].Value = model.OrderNo;
			parameters[12].Value = model.EntryTime;
			parameters[13].Value = model.MoneyType;
			parameters[14].Value = model.Claim_Confirm;
			parameters[15].Value = model.Claim_id;

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
		public bool Delete(Guid Claim_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ClaimMoney ");
			strSql.Append(" where Claim_id=@Claim_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Claim_id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Claim_id;

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
		public bool DeleteList(string Claim_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ClaimMoney ");
			strSql.Append(" where Claim_id in ("+Claim_idlist + ")  ");
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
		public TravelAgency.Model.ClaimMoney GetModel(Guid Claim_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Claim_id,Money_id,DepartmentId,Name_Claim,GroupNo,Salesperson,Guests,Methods,Amount,WorkId,ClaimTime,username,OrderNo,EntryTime,MoneyType,Claim_Confirm from ClaimMoney ");
			strSql.Append(" where Claim_id=@Claim_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Claim_id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Claim_id;

			TravelAgency.Model.ClaimMoney model=new TravelAgency.Model.ClaimMoney();
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
		public TravelAgency.Model.ClaimMoney DataRowToModel(DataRow row)
		{
			TravelAgency.Model.ClaimMoney model=new TravelAgency.Model.ClaimMoney();
			if (row != null)
			{
				if(row["Claim_id"]!=null && row["Claim_id"].ToString()!="")
				{
					model.Claim_id= new Guid(row["Claim_id"].ToString());
				}
				if(row["Money_id"]!=null && row["Money_id"].ToString()!="")
				{
					model.Money_id= new Guid(row["Money_id"].ToString());
				}
				if(row["DepartmentId"]!=null && row["DepartmentId"].ToString()!="")
				{
					model.DepartmentId= new Guid(row["DepartmentId"].ToString());
				}
				if(row["Name_Claim"]!=null)
				{
					model.Name_Claim=row["Name_Claim"].ToString();
				}
				if(row["GroupNo"]!=null)
				{
					model.GroupNo=row["GroupNo"].ToString();
				}
				if(row["Salesperson"]!=null)
				{
					model.Salesperson=row["Salesperson"].ToString();
				}
				if(row["Guests"]!=null)
				{
					model.Guests=row["Guests"].ToString();
				}
				if(row["Methods"]!=null)
				{
					model.Methods=row["Methods"].ToString();
				}
				if(row["Amount"]!=null && row["Amount"].ToString()!="")
				{
					model.Amount=decimal.Parse(row["Amount"].ToString());
				}
				if(row["WorkId"]!=null)
				{
					model.WorkId=row["WorkId"].ToString();
				}
				if(row["ClaimTime"]!=null && row["ClaimTime"].ToString()!="")
				{
					model.ClaimTime=DateTime.Parse(row["ClaimTime"].ToString());
				}
				if(row["username"]!=null)
				{
					model.username=row["username"].ToString();
				}
				if(row["OrderNo"]!=null)
				{
					model.OrderNo=row["OrderNo"].ToString();
				}
				if(row["EntryTime"]!=null && row["EntryTime"].ToString()!="")
				{
					model.EntryTime=DateTime.Parse(row["EntryTime"].ToString());
				}
				if(row["MoneyType"]!=null)
				{
					model.MoneyType=row["MoneyType"].ToString();
				}
				if(row["Claim_Confirm"]!=null)
				{
					model.Claim_Confirm=row["Claim_Confirm"].ToString();
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
			strSql.Append("select Claim_id,Money_id,DepartmentId,Name_Claim,GroupNo,Salesperson,Guests,Methods,Amount,WorkId,ClaimTime,username,OrderNo,EntryTime,MoneyType,Claim_Confirm ");
			strSql.Append(" FROM ClaimMoney ");
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
			strSql.Append(" Claim_id,Money_id,DepartmentId,Name_Claim,GroupNo,Salesperson,Guests,Methods,Amount,WorkId,ClaimTime,username,OrderNo,EntryTime,MoneyType,Claim_Confirm ");
			strSql.Append(" FROM ClaimMoney ");
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
			strSql.Append("select count(1) FROM ClaimMoney ");
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
				strSql.Append("order by T.Claim_id desc");
			}
			strSql.Append(")AS Row, T.*  from ClaimMoney T ");
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
			parameters[0].Value = "ClaimMoney";
			parameters[1].Value = "Claim_id";
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

