using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
	/// <summary>
	/// 数据访问类:CustomerInfo
	/// </summary>
	public partial class CustomerInfo
	{
		public CustomerInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid CustomeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CustomerInfo");
			strSql.Append(" where CustomeID=@CustomeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomeID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = CustomeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(TravelAgency.Model.CustomerInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CustomerInfo(");
			strSql.Append("CustomeID,CustomerName,Company,UniformCode,Department,Principal,Mobile,ToBear,ToBearMobile,Address,ContractNo,ContractDate,ContractExpiration,ContractPeriod,Phone,WeChat,QQ,Fax,Type,WorkId,DepartmentId,Tips,DataType,ParentId,EntryTime,Lng,Lat,Operator,ImgPath)");
			strSql.Append(" values (");
			strSql.Append("@CustomeID,@CustomerName,@Company,@UniformCode,@Department,@Principal,@Mobile,@ToBear,@ToBearMobile,@Address,@ContractNo,@ContractDate,@ContractExpiration,@ContractPeriod,@Phone,@WeChat,@QQ,@Fax,@Type,@WorkId,@DepartmentId,@Tips,@DataType,@ParentId,@EntryTime,@Lng,@Lat,@Operator,@ImgPath)");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomeID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@CustomerName", SqlDbType.VarChar,50),
					new SqlParameter("@Company", SqlDbType.VarChar,500),
					new SqlParameter("@UniformCode", SqlDbType.VarChar,500),
					new SqlParameter("@Department", SqlDbType.VarChar,50),
					new SqlParameter("@Principal", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@ToBear", SqlDbType.VarChar,50),
					new SqlParameter("@ToBearMobile", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,255),
					new SqlParameter("@ContractNo", SqlDbType.VarChar,255),
					new SqlParameter("@ContractDate", SqlDbType.VarChar,255),
					new SqlParameter("@ContractExpiration", SqlDbType.VarChar,255),
					new SqlParameter("@ContractPeriod", SqlDbType.VarChar,255),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@WeChat", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,50),
					new SqlParameter("@Fax", SqlDbType.VarChar,50),
					new SqlParameter("@Type", SqlDbType.VarChar,50),
					new SqlParameter("@WorkId", SqlDbType.VarChar,50),
					new SqlParameter("@DepartmentId", SqlDbType.VarChar,255),
					new SqlParameter("@Tips", SqlDbType.VarChar,255),
					new SqlParameter("@DataType", SqlDbType.VarChar,255),
					new SqlParameter("@ParentId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EntryTime", SqlDbType.DateTime),
					new SqlParameter("@Lng", SqlDbType.VarChar,255),
					new SqlParameter("@Lat", SqlDbType.VarChar,255),
					new SqlParameter("@Operator", SqlDbType.VarChar,255),
					new SqlParameter("@ImgPath", SqlDbType.VarChar,255)};
			parameters[0].Value = Guid.NewGuid();
			parameters[1].Value = model.CustomerName;
			parameters[2].Value = model.Company;
			parameters[3].Value = model.UniformCode;
			parameters[4].Value = model.Department;
			parameters[5].Value = model.Principal;
			parameters[6].Value = model.Mobile;
			parameters[7].Value = model.ToBear;
			parameters[8].Value = model.ToBearMobile;
			parameters[9].Value = model.Address;
			parameters[10].Value = model.ContractNo;
			parameters[11].Value = model.ContractDate;
			parameters[12].Value = model.ContractExpiration;
			parameters[13].Value = model.ContractPeriod;
			parameters[14].Value = model.Phone;
			parameters[15].Value = model.WeChat;
			parameters[16].Value = model.QQ;
			parameters[17].Value = model.Fax;
			parameters[18].Value = model.Type;
			parameters[19].Value = model.WorkId;
			parameters[20].Value = model.DepartmentId;
			parameters[21].Value = model.Tips;
			parameters[22].Value = model.DataType;
			parameters[23].Value = Guid.NewGuid();
			parameters[24].Value = model.EntryTime;
			parameters[25].Value = model.Lng;
			parameters[26].Value = model.Lat;
			parameters[27].Value = model.Operator;
			parameters[28].Value = model.ImgPath;

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
		public bool Update(TravelAgency.Model.CustomerInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CustomerInfo set ");
			strSql.Append("CustomerName=@CustomerName,");
			strSql.Append("Company=@Company,");
			strSql.Append("UniformCode=@UniformCode,");
			strSql.Append("Department=@Department,");
			strSql.Append("Principal=@Principal,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("ToBear=@ToBear,");
			strSql.Append("ToBearMobile=@ToBearMobile,");
			strSql.Append("Address=@Address,");
			strSql.Append("ContractNo=@ContractNo,");
			strSql.Append("ContractDate=@ContractDate,");
			strSql.Append("ContractExpiration=@ContractExpiration,");
			strSql.Append("ContractPeriod=@ContractPeriod,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("WeChat=@WeChat,");
			strSql.Append("QQ=@QQ,");
			strSql.Append("Fax=@Fax,");
			strSql.Append("Type=@Type,");
			strSql.Append("WorkId=@WorkId,");
			strSql.Append("DepartmentId=@DepartmentId,");
			strSql.Append("Tips=@Tips,");
			strSql.Append("DataType=@DataType,");
			strSql.Append("ParentId=@ParentId,");
			strSql.Append("EntryTime=@EntryTime,");
			strSql.Append("Lng=@Lng,");
			strSql.Append("Lat=@Lat,");
			strSql.Append("Operator=@Operator,");
			strSql.Append("ImgPath=@ImgPath");
			strSql.Append(" where CustomeID=@CustomeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomerName", SqlDbType.VarChar,50),
					new SqlParameter("@Company", SqlDbType.VarChar,500),
					new SqlParameter("@UniformCode", SqlDbType.VarChar,500),
					new SqlParameter("@Department", SqlDbType.VarChar,50),
					new SqlParameter("@Principal", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@ToBear", SqlDbType.VarChar,50),
					new SqlParameter("@ToBearMobile", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.VarChar,255),
					new SqlParameter("@ContractNo", SqlDbType.VarChar,255),
					new SqlParameter("@ContractDate", SqlDbType.VarChar,255),
					new SqlParameter("@ContractExpiration", SqlDbType.VarChar,255),
					new SqlParameter("@ContractPeriod", SqlDbType.VarChar,255),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@WeChat", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,50),
					new SqlParameter("@Fax", SqlDbType.VarChar,50),
					new SqlParameter("@Type", SqlDbType.VarChar,50),
					new SqlParameter("@WorkId", SqlDbType.VarChar,50),
					new SqlParameter("@DepartmentId", SqlDbType.VarChar,255),
					new SqlParameter("@Tips", SqlDbType.VarChar,255),
					new SqlParameter("@DataType", SqlDbType.VarChar,255),
					new SqlParameter("@ParentId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@EntryTime", SqlDbType.DateTime),
					new SqlParameter("@Lng", SqlDbType.VarChar,255),
					new SqlParameter("@Lat", SqlDbType.VarChar,255),
					new SqlParameter("@Operator", SqlDbType.VarChar,255),
					new SqlParameter("@ImgPath", SqlDbType.VarChar,255),
					new SqlParameter("@CustomeID", SqlDbType.UniqueIdentifier,16)};
			parameters[0].Value = model.CustomerName;
			parameters[1].Value = model.Company;
			parameters[2].Value = model.UniformCode;
			parameters[3].Value = model.Department;
			parameters[4].Value = model.Principal;
			parameters[5].Value = model.Mobile;
			parameters[6].Value = model.ToBear;
			parameters[7].Value = model.ToBearMobile;
			parameters[8].Value = model.Address;
			parameters[9].Value = model.ContractNo;
			parameters[10].Value = model.ContractDate;
			parameters[11].Value = model.ContractExpiration;
			parameters[12].Value = model.ContractPeriod;
			parameters[13].Value = model.Phone;
			parameters[14].Value = model.WeChat;
			parameters[15].Value = model.QQ;
			parameters[16].Value = model.Fax;
			parameters[17].Value = model.Type;
			parameters[18].Value = model.WorkId;
			parameters[19].Value = model.DepartmentId;
			parameters[20].Value = model.Tips;
			parameters[21].Value = model.DataType;
			parameters[22].Value = model.ParentId;
			parameters[23].Value = model.EntryTime;
			parameters[24].Value = model.Lng;
			parameters[25].Value = model.Lat;
			parameters[26].Value = model.Operator;
			parameters[27].Value = model.ImgPath;
			parameters[28].Value = model.CustomeID;

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
		public bool Delete(Guid CustomeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CustomerInfo ");
			strSql.Append(" where CustomeID=@CustomeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomeID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = CustomeID;

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
		public bool DeleteList(string CustomeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CustomerInfo ");
			strSql.Append(" where CustomeID in ("+CustomeIDlist + ")  ");
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
		public TravelAgency.Model.CustomerInfo GetModel(Guid CustomeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CustomeID,CustomerName,Company,UniformCode,Department,Principal,Mobile,ToBear,ToBearMobile,Address,ContractNo,ContractDate,ContractExpiration,ContractPeriod,Phone,WeChat,QQ,Fax,Type,WorkId,DepartmentId,Tips,DataType,ParentId,EntryTime,Lng,Lat,Operator,ImgPath from CustomerInfo ");
			strSql.Append(" where CustomeID=@CustomeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CustomeID", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = CustomeID;

			TravelAgency.Model.CustomerInfo model=new TravelAgency.Model.CustomerInfo();
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
		public TravelAgency.Model.CustomerInfo DataRowToModel(DataRow row)
		{
			TravelAgency.Model.CustomerInfo model=new TravelAgency.Model.CustomerInfo();
			if (row != null)
			{
				if(row["CustomeID"]!=null && row["CustomeID"].ToString()!="")
				{
					model.CustomeID= new Guid(row["CustomeID"].ToString());
				}
				if(row["CustomerName"]!=null)
				{
					model.CustomerName=row["CustomerName"].ToString();
				}
				if(row["Company"]!=null)
				{
					model.Company=row["Company"].ToString();
				}
				if(row["UniformCode"]!=null)
				{
					model.UniformCode=row["UniformCode"].ToString();
				}
				if(row["Department"]!=null)
				{
					model.Department=row["Department"].ToString();
				}
				if(row["Principal"]!=null)
				{
					model.Principal=row["Principal"].ToString();
				}
				if(row["Mobile"]!=null)
				{
					model.Mobile=row["Mobile"].ToString();
				}
				if(row["ToBear"]!=null)
				{
					model.ToBear=row["ToBear"].ToString();
				}
				if(row["ToBearMobile"]!=null)
				{
					model.ToBearMobile=row["ToBearMobile"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["ContractNo"]!=null)
				{
					model.ContractNo=row["ContractNo"].ToString();
				}
				if(row["ContractDate"]!=null)
				{
					model.ContractDate=row["ContractDate"].ToString();
				}
				if(row["ContractExpiration"]!=null)
				{
					model.ContractExpiration=row["ContractExpiration"].ToString();
				}
				if(row["ContractPeriod"]!=null)
				{
					model.ContractPeriod=row["ContractPeriod"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["WeChat"]!=null)
				{
					model.WeChat=row["WeChat"].ToString();
				}
				if(row["QQ"]!=null)
				{
					model.QQ=row["QQ"].ToString();
				}
				if(row["Fax"]!=null)
				{
					model.Fax=row["Fax"].ToString();
				}
				if(row["Type"]!=null)
				{
					model.Type=row["Type"].ToString();
				}
				if(row["WorkId"]!=null)
				{
					model.WorkId=row["WorkId"].ToString();
				}
				if(row["DepartmentId"]!=null)
				{
					model.DepartmentId=row["DepartmentId"].ToString();
				}
				if(row["Tips"]!=null)
				{
					model.Tips=row["Tips"].ToString();
				}
				if(row["DataType"]!=null)
				{
					model.DataType=row["DataType"].ToString();
				}
				if(row["ParentId"]!=null && row["ParentId"].ToString()!="")
				{
					model.ParentId= new Guid(row["ParentId"].ToString());
				}
				if(row["EntryTime"]!=null && row["EntryTime"].ToString()!="")
				{
					model.EntryTime=DateTime.Parse(row["EntryTime"].ToString());
				}
				if(row["Lng"]!=null)
				{
					model.Lng=row["Lng"].ToString();
				}
				if(row["Lat"]!=null)
				{
					model.Lat=row["Lat"].ToString();
				}
				if(row["Operator"]!=null)
				{
					model.Operator=row["Operator"].ToString();
				}
				if(row["ImgPath"]!=null)
				{
					model.ImgPath=row["ImgPath"].ToString();
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
			strSql.Append("select CustomeID,CustomerName,Company,UniformCode,Department,Principal,Mobile,ToBear,ToBearMobile,Address,ContractNo,ContractDate,ContractExpiration,ContractPeriod,Phone,WeChat,QQ,Fax,Type,WorkId,DepartmentId,Tips,DataType,ParentId,EntryTime,Lng,Lat,Operator,ImgPath ");
			strSql.Append(" FROM CustomerInfo ");
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
			strSql.Append(" CustomeID,CustomerName,Company,UniformCode,Department,Principal,Mobile,ToBear,ToBearMobile,Address,ContractNo,ContractDate,ContractExpiration,ContractPeriod,Phone,WeChat,QQ,Fax,Type,WorkId,DepartmentId,Tips,DataType,ParentId,EntryTime,Lng,Lat,Operator,ImgPath ");
			strSql.Append(" FROM CustomerInfo ");
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
			strSql.Append("select count(1) FROM CustomerInfo ");
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
				strSql.Append("order by T.CustomeID desc");
			}
			strSql.Append(")AS Row, T.*  from CustomerInfo T ");
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
			parameters[0].Value = "CustomerInfo";
			parameters[1].Value = "CustomeID";
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

