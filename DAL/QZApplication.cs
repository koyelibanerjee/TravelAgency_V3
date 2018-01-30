using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
	/// <summary>
	/// 数据访问类:QZApplication
	/// </summary>
	public partial class QZApplication
	{
		public QZApplication()
		{}
		#region  BasicMethod



		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(TravelAgency.Model.QZApplication model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update QZApplication set ");
			strSql.Append("QZApp_id=@QZApp_id,");
			strSql.Append("Visa_id=@Visa_id,");
			strSql.Append("SubName=@SubName,");
			strSql.Append("DepartmentId=@DepartmentId,");
			strSql.Append("GroupNo=@GroupNo,");
			strSql.Append("SendTime=@SendTime,");
			strSql.Append("FinishTime=@FinishTime,");
			strSql.Append("Person=@Person,");
			strSql.Append("Number=@Number,");
			strSql.Append("Tips=@Tips,");
			strSql.Append("Price=@Price,");
			strSql.Append("Receipt=@Receipt,");
			strSql.Append("Quidco=@Quidco,");
			strSql.Append("ConsulateCost=@ConsulateCost,");
			strSql.Append("VisaPersonCost=@VisaPersonCost,");
			strSql.Append("MailCost=@MailCost,");
			strSql.Append("PictureCost=@PictureCost,");
			strSql.Append("Sales=@Sales,");
			strSql.Append("WorkId=@WorkId,");
			strSql.Append("EntryTime=@EntryTime,");
			strSql.Append("App_id=@App_id,");
			strSql.Append("Flag=@Flag,");
			strSql.Append("Country=@Country,");
			strSql.Append("Name=@Name,");
			strSql.Append("InvitationCost=@InvitationCost,");
			strSql.Append("cost=@cost");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@QZApp_id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@Visa_id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@SubName", SqlDbType.VarChar,50),
					new SqlParameter("@DepartmentId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@GroupNo", SqlDbType.VarChar,255),
					new SqlParameter("@SendTime", SqlDbType.DateTime,3),
					new SqlParameter("@FinishTime", SqlDbType.DateTime,3),
					new SqlParameter("@Person", SqlDbType.NChar,10),
					new SqlParameter("@Number", SqlDbType.Int,4),
					new SqlParameter("@Tips", SqlDbType.VarChar,50),
					new SqlParameter("@Price", SqlDbType.Float,8),
					new SqlParameter("@Receipt", SqlDbType.Float,8),
					new SqlParameter("@Quidco", SqlDbType.Float,8),
					new SqlParameter("@ConsulateCost", SqlDbType.Float,8),
					new SqlParameter("@VisaPersonCost", SqlDbType.Float,8),
					new SqlParameter("@MailCost", SqlDbType.Float,8),
					new SqlParameter("@PictureCost", SqlDbType.Float,8),
					new SqlParameter("@Sales", SqlDbType.VarChar,50),
					new SqlParameter("@WorkId", SqlDbType.VarChar,50),
					new SqlParameter("@EntryTime", SqlDbType.DateTime),
					new SqlParameter("@App_id", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@Flag", SqlDbType.Int,4),
					new SqlParameter("@Country", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.VarChar,150),
					new SqlParameter("@InvitationCost", SqlDbType.Float,8),
					new SqlParameter("@cost", SqlDbType.Float,8)};
			parameters[0].Value = model.QZApp_id;
			parameters[1].Value = model.Visa_id;
			parameters[2].Value = model.SubName;
			parameters[3].Value = model.DepartmentId;
			parameters[4].Value = model.GroupNo;
			parameters[5].Value = model.SendTime;
			parameters[6].Value = model.FinishTime;
			parameters[7].Value = model.Person;
			parameters[8].Value = model.Number;
			parameters[9].Value = model.Tips;
			parameters[10].Value = model.Price;
			parameters[11].Value = model.Receipt;
			parameters[12].Value = model.Quidco;
			parameters[13].Value = model.ConsulateCost;
			parameters[14].Value = model.VisaPersonCost;
			parameters[15].Value = model.MailCost;
			parameters[16].Value = model.PictureCost;
			parameters[17].Value = model.Sales;
			parameters[18].Value = model.WorkId;
			parameters[19].Value = model.EntryTime;
			parameters[20].Value = model.App_id;
			parameters[21].Value = model.Flag;
			parameters[22].Value = model.Country;
			parameters[23].Value = model.Name;
			parameters[24].Value = model.InvitationCost;
			parameters[25].Value = model.cost;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from QZApplication ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public TravelAgency.Model.QZApplication GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 QZApp_id,Visa_id,SubName,DepartmentId,GroupNo,SendTime,FinishTime,Person,Number,Tips,Price,Receipt,Quidco,ConsulateCost,VisaPersonCost,MailCost,PictureCost,Sales,WorkId,EntryTime,App_id,Flag,Country,Name,InvitationCost,cost from QZApplication ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			TravelAgency.Model.QZApplication model=new TravelAgency.Model.QZApplication();
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
		public TravelAgency.Model.QZApplication DataRowToModel(DataRow row)
		{
			TravelAgency.Model.QZApplication model=new TravelAgency.Model.QZApplication();
			if (row != null)
			{
				if(row["QZApp_id"]!=null && row["QZApp_id"].ToString()!="")
				{
					model.QZApp_id= new Guid(row["QZApp_id"].ToString());
				}
				if(row["Visa_id"]!=null && row["Visa_id"].ToString()!="")
				{
					model.Visa_id= new Guid(row["Visa_id"].ToString());
				}
				if(row["SubName"]!=null)
				{
					model.SubName=row["SubName"].ToString();
				}
				if(row["DepartmentId"]!=null && row["DepartmentId"].ToString()!="")
				{
					model.DepartmentId= new Guid(row["DepartmentId"].ToString());
				}
				if(row["GroupNo"]!=null)
				{
					model.GroupNo=row["GroupNo"].ToString();
				}
				if(row["SendTime"]!=null && row["SendTime"].ToString()!="")
				{
					model.SendTime=DateTime.Parse(row["SendTime"].ToString());
				}
				if(row["FinishTime"]!=null && row["FinishTime"].ToString()!="")
				{
					model.FinishTime=DateTime.Parse(row["FinishTime"].ToString());
				}
				if(row["Person"]!=null)
				{
					model.Person=row["Person"].ToString();
				}
				if(row["Number"]!=null && row["Number"].ToString()!="")
				{
					model.Number=int.Parse(row["Number"].ToString());
				}
				if(row["Tips"]!=null)
				{
					model.Tips=row["Tips"].ToString();
				}
				if(row["Price"]!=null && row["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(row["Price"].ToString());
				}
				if(row["Receipt"]!=null && row["Receipt"].ToString()!="")
				{
					model.Receipt=decimal.Parse(row["Receipt"].ToString());
				}
				if(row["Quidco"]!=null && row["Quidco"].ToString()!="")
				{
					model.Quidco=decimal.Parse(row["Quidco"].ToString());
				}
				if(row["ConsulateCost"]!=null && row["ConsulateCost"].ToString()!="")
				{
					model.ConsulateCost=decimal.Parse(row["ConsulateCost"].ToString());
				}
				if(row["VisaPersonCost"]!=null && row["VisaPersonCost"].ToString()!="")
				{
					model.VisaPersonCost=decimal.Parse(row["VisaPersonCost"].ToString());
				}
				if(row["MailCost"]!=null && row["MailCost"].ToString()!="")
				{
					model.MailCost=decimal.Parse(row["MailCost"].ToString());
				}
				if(row["PictureCost"]!=null && row["PictureCost"].ToString()!="")
				{
					model.PictureCost=decimal.Parse(row["PictureCost"].ToString());
				}
				if(row["Sales"]!=null)
				{
					model.Sales=row["Sales"].ToString();
				}
				if(row["WorkId"]!=null)
				{
					model.WorkId=row["WorkId"].ToString();
				}
				if(row["EntryTime"]!=null && row["EntryTime"].ToString()!="")
				{
					model.EntryTime=DateTime.Parse(row["EntryTime"].ToString());
				}
				if(row["App_id"]!=null && row["App_id"].ToString()!="")
				{
					model.App_id= new Guid(row["App_id"].ToString());
				}
				if(row["Flag"]!=null && row["Flag"].ToString()!="")
				{
					model.Flag=int.Parse(row["Flag"].ToString());
				}
				if(row["Country"]!=null)
				{
					model.Country=row["Country"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["InvitationCost"]!=null && row["InvitationCost"].ToString()!="")
				{
					model.InvitationCost=decimal.Parse(row["InvitationCost"].ToString());
				}
				if(row["cost"]!=null && row["cost"].ToString()!="")
				{
					model.cost=decimal.Parse(row["cost"].ToString());
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
			strSql.Append("select QZApp_id,Visa_id,SubName,DepartmentId,GroupNo,SendTime,FinishTime,Person,Number,Tips,Price,Receipt,Quidco,ConsulateCost,VisaPersonCost,MailCost,PictureCost,Sales,WorkId,EntryTime,App_id,Flag,Country,Name,InvitationCost,cost ");
			strSql.Append(" FROM QZApplication ");
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
			strSql.Append(" QZApp_id,Visa_id,SubName,DepartmentId,GroupNo,SendTime,FinishTime,Person,Number,Tips,Price,Receipt,Quidco,ConsulateCost,VisaPersonCost,MailCost,PictureCost,Sales,WorkId,EntryTime,App_id,Flag,Country,Name,InvitationCost,cost ");
			strSql.Append(" FROM QZApplication ");
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
			strSql.Append("select count(1) FROM QZApplication ");
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
			strSql.Append(")AS Row, T.*  from QZApplication T ");
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
			parameters[0].Value = "QZApplication";
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

