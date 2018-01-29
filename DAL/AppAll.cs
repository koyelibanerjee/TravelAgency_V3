using System;
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
		public AppAll()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid App_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AppAll");
			strSql.Append(" where App_id=@App_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@App_id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = App_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TravelAgency.Model.AppAll model)
		{
			StringBuilder strSql=new StringBuilder();
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
			parameters[3].Value = Guid.NewGuid();
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
		public bool Update(TravelAgency.Model.AppAll model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AppAll set ");
			strSql.Append("UserName=@UserName,");
			strSql.Append("WorkId=@WorkId,");
			strSql.Append("DepartmentId=@DepartmentId,");
			strSql.Append("Amount=@Amount,");
			strSql.Append("GroupNo=@GroupNo,");
			strSql.Append("Details=@Details,");
			strSql.Append("PayWay=@PayWay,");
			strSql.Append("AppTime=@AppTime,");
			strSql.Append("Account=@Account,");
			strSql.Append("Bank_To=@Bank_To,");
			strSql.Append("Bank=@Bank,");
			strSql.Append("Person=@Person,");
			strSql.Append("Bank_From=@Bank_From,");
			strSql.Append("Amount_Spend=@Amount_Spend,");
			strSql.Append("Img=@Img,");
			strSql.Append("EntryTime=@EntryTime,");
			strSql.Append("Flag=@Flag,");
			strSql.Append("AppNo=@AppNo,");
			strSql.Append("PrintState=@PrintState");
			strSql.Append(" where temp=@temp");
			SqlParameter[] parameters = {
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
					new SqlParameter("@PrintState", SqlDbType.VarChar,50),
					new SqlParameter("@App_id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@temp", SqlDbType.Int,4)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.WorkId;
			parameters[2].Value = model.DepartmentId;
			parameters[3].Value = model.Amount;
			parameters[4].Value = model.GroupNo;
			parameters[5].Value = model.Details;
			parameters[6].Value = model.PayWay;
			parameters[7].Value = model.AppTime;
			parameters[8].Value = model.Account;
			parameters[9].Value = model.Bank_To;
			parameters[10].Value = model.Bank;
			parameters[11].Value = model.Person;
			parameters[12].Value = model.Bank_From;
			parameters[13].Value = model.Amount_Spend;
			parameters[14].Value = model.Img;
			parameters[15].Value = model.EntryTime;
			parameters[16].Value = model.Flag;
			parameters[17].Value = model.AppNo;
			parameters[18].Value = model.PrintState;
			parameters[19].Value = model.App_id;
			parameters[20].Value = model.temp;

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
		public bool Delete(int temp)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AppAll ");
			strSql.Append(" where temp=@temp");
			SqlParameter[] parameters = {
					new SqlParameter("@temp", SqlDbType.Int,4)
			};
			parameters[0].Value = temp;

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
		public bool Delete(Guid App_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AppAll ");
			strSql.Append(" where App_id=@App_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@App_id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = App_id;

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
		public bool DeleteList(string templist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AppAll ");
			strSql.Append(" where temp in ("+templist + ")  ");
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
		public TravelAgency.Model.AppAll GetModel(int temp)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 App_id,UserName,WorkId,DepartmentId,Amount,GroupNo,Details,PayWay,AppTime,Account,Bank_To,Bank,Person,Bank_From,Amount_Spend,Img,EntryTime,Flag,temp,AppNo,PrintState from AppAll ");
			strSql.Append(" where temp=@temp");
			SqlParameter[] parameters = {
					new SqlParameter("@temp", SqlDbType.Int,4)
			};
			parameters[0].Value = temp;

			TravelAgency.Model.AppAll model=new TravelAgency.Model.AppAll();
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
		public TravelAgency.Model.AppAll DataRowToModel(DataRow row)
		{
			TravelAgency.Model.AppAll model=new TravelAgency.Model.AppAll();
			if (row != null)
			{
				if(row["App_id"]!=null && row["App_id"].ToString()!="")
				{
					model.App_id= new Guid(row["App_id"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["WorkId"]!=null)
				{
					model.WorkId=row["WorkId"].ToString();
				}
				if(row["DepartmentId"]!=null && row["DepartmentId"].ToString()!="")
				{
					model.DepartmentId= new Guid(row["DepartmentId"].ToString());
				}
				if(row["Amount"]!=null && row["Amount"].ToString()!="")
				{
					model.Amount=decimal.Parse(row["Amount"].ToString());
				}
				if(row["GroupNo"]!=null)
				{
					model.GroupNo=row["GroupNo"].ToString();
				}
				if(row["Details"]!=null)
				{
					model.Details=row["Details"].ToString();
				}
				if(row["PayWay"]!=null)
				{
					model.PayWay=row["PayWay"].ToString();
				}
				if(row["AppTime"]!=null && row["AppTime"].ToString()!="")
				{
					model.AppTime=DateTime.Parse(row["AppTime"].ToString());
				}
				if(row["Account"]!=null)
				{
					model.Account=row["Account"].ToString();
				}
				if(row["Bank_To"]!=null)
				{
					model.Bank_To=row["Bank_To"].ToString();
				}
				if(row["Bank"]!=null)
				{
					model.Bank=row["Bank"].ToString();
				}
				if(row["Person"]!=null)
				{
					model.Person=row["Person"].ToString();
				}
				if(row["Bank_From"]!=null)
				{
					model.Bank_From=row["Bank_From"].ToString();
				}
				if(row["Amount_Spend"]!=null && row["Amount_Spend"].ToString()!="")
				{
					model.Amount_Spend=decimal.Parse(row["Amount_Spend"].ToString());
				}
				if(row["Img"]!=null)
				{
					model.Img=row["Img"].ToString();
				}
				if(row["EntryTime"]!=null && row["EntryTime"].ToString()!="")
				{
					model.EntryTime=DateTime.Parse(row["EntryTime"].ToString());
				}
				if(row["Flag"]!=null && row["Flag"].ToString()!="")
				{
					model.Flag=int.Parse(row["Flag"].ToString());
				}
				if(row["temp"]!=null && row["temp"].ToString()!="")
				{
					model.temp=int.Parse(row["temp"].ToString());
				}
				if(row["AppNo"]!=null)
				{
					model.AppNo=row["AppNo"].ToString();
				}
				if(row["PrintState"]!=null)
				{
					model.PrintState=row["PrintState"].ToString();
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
			strSql.Append("select App_id,UserName,WorkId,DepartmentId,Amount,GroupNo,Details,PayWay,AppTime,Account,Bank_To,Bank,Person,Bank_From,Amount_Spend,Img,EntryTime,Flag,temp,AppNo,PrintState ");
			strSql.Append(" FROM AppAll ");
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
			strSql.Append(" App_id,UserName,WorkId,DepartmentId,Amount,GroupNo,Details,PayWay,AppTime,Account,Bank_To,Bank,Person,Bank_From,Amount_Spend,Img,EntryTime,Flag,temp,AppNo,PrintState ");
			strSql.Append(" FROM AppAll ");
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
			strSql.Append("select count(1) FROM AppAll ");
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
				strSql.Append("order by T.temp desc");
			}
			strSql.Append(")AS Row, T.*  from AppAll T ");
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
			parameters[0].Value = "AppAll";
			parameters[1].Value = "temp";
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

