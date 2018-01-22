using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
	/// <summary>
	/// 数据访问类:Visa
	/// </summary>
	public partial class VisaWithActRecords
    {
		public VisaWithActRecords()
		{}
		#region  BasicMethod

		




		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TravelAgency.Model.Visa DataRowToModel(DataRow row)
		{
			TravelAgency.Model.Visa model=new TravelAgency.Model.Visa();
			if (row != null)
			{
				if(row["Visa_id"]!=null && row["Visa_id"].ToString()!="")
				{
					model.Visa_id= new Guid(row["Visa_id"].ToString());
				}
				if(row["GroupNo"]!=null)
				{
					model.GroupNo=row["GroupNo"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Types"]!=null)
				{
					model.Types=row["Types"].ToString();
				}
				if(row["Tips"]!=null)
				{
					model.Tips=row["Tips"].ToString();
				}
				if(row["PredictTime"]!=null && row["PredictTime"].ToString()!="")
				{
					model.PredictTime=DateTime.Parse(row["PredictTime"].ToString());
				}
				if(row["RealTime"]!=null && row["RealTime"].ToString()!="")
				{
					model.RealTime=DateTime.Parse(row["RealTime"].ToString());
				}
				if(row["FinishTime"]!=null && row["FinishTime"].ToString()!="")
				{
					model.FinishTime=DateTime.Parse(row["FinishTime"].ToString());
				}
				if(row["Satus"]!=null)
				{
					model.Satus=row["Satus"].ToString();
				}
				if(row["Person"]!=null)
				{
					model.Person=row["Person"].ToString();
				}
				if(row["Number"]!=null && row["Number"].ToString()!="")
				{
					model.Number=int.Parse(row["Number"].ToString());
				}
				if(row["Picture"]!=null && row["Picture"].ToString()!="")
				{
					model.Picture=decimal.Parse(row["Picture"].ToString());
				}
				if(row["ListCount"]!=null && row["ListCount"].ToString()!="")
				{
					model.ListCount=decimal.Parse(row["ListCount"].ToString());
				}
				if(row["List"]!=null)
				{
					model.List=row["List"].ToString();
				}
				if(row["SalesPerson"]!=null)
				{
					model.SalesPerson=row["SalesPerson"].ToString();
				}
				if(row["Receipt"]!=null && row["Receipt"].ToString()!="")
				{
					model.Receipt=decimal.Parse(row["Receipt"].ToString());
				}
				if(row["Quidco"]!=null && row["Quidco"].ToString()!="")
				{
					model.Quidco=decimal.Parse(row["Quidco"].ToString());
				}
				if(row["Cost"]!=null && row["Cost"].ToString()!="")
				{
					model.Cost=decimal.Parse(row["Cost"].ToString());
				}
				if(row["OtherCost"]!=null && row["OtherCost"].ToString()!="")
				{
					model.OtherCost=decimal.Parse(row["OtherCost"].ToString());
				}
				if(row["ExpressNo"]!=null)
				{
					model.ExpressNo=row["ExpressNo"].ToString();
				}
				if(row["Call"]!=null)
				{
					model.Call=row["Call"].ToString();
				}
				if(row["Sale_id"]!=null && row["Sale_id"].ToString()!="")
				{
					model.Sale_id= new Guid(row["Sale_id"].ToString());
				}
				if(row["DepartmentId"]!=null && row["DepartmentId"].ToString()!="")
				{
					model.DepartmentId= new Guid(row["DepartmentId"].ToString());
				}
				if(row["EntryTime"]!=null && row["EntryTime"].ToString()!="")
				{
					model.EntryTime=DateTime.Parse(row["EntryTime"].ToString());
				}
				if(row["Country"]!=null)
				{
					model.Country=row["Country"].ToString();
				}
				if(row["Passengers"]!=null)
				{
					model.Passengers=row["Passengers"].ToString();
				}
				if(row["WorkId"]!=null)
				{
					model.WorkId=row["WorkId"].ToString();
				}
				if(row["Documenter"]!=null)
				{
					model.Documenter=row["Documenter"].ToString();
				}
				if(row["Price"]!=null && row["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(row["Price"].ToString());
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
				if(row["Tips2"]!=null)
				{
					model.Tips2=row["Tips2"].ToString();
				}
				if(row["SubmitFlag"]!=null && row["SubmitFlag"].ToString()!="")
				{
					model.SubmitFlag=int.Parse(row["SubmitFlag"].ToString());
				}
				if(row["GroupPrice"]!=null && row["GroupPrice"].ToString()!="")
				{
					model.GroupPrice=decimal.Parse(row["GroupPrice"].ToString());
				}
				if(row["InvitationCost"]!=null && row["InvitationCost"].ToString()!="")
				{
					model.InvitationCost=decimal.Parse(row["InvitationCost"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["SubmitTime"]!=null && row["SubmitTime"].ToString()!="")
				{
					model.SubmitTime=DateTime.Parse(row["SubmitTime"].ToString());
				}
				if(row["InTime"]!=null && row["InTime"].ToString()!="")
				{
					model.InTime=DateTime.Parse(row["InTime"].ToString());
				}
				if(row["OutTime"]!=null && row["OutTime"].ToString()!="")
				{
					model.OutTime=DateTime.Parse(row["OutTime"].ToString());
				}
				if(row["Client"]!=null)
				{
					model.Client=row["Client"].ToString();
				}
				if(row["DepartureType"]!=null)
				{
					model.DepartureType=row["DepartureType"].ToString();
				}
				if(row["SubmitCondition"]!=null)
				{
					model.SubmitCondition=row["SubmitCondition"].ToString();
				}
				if(row["FetchCondition"]!=null)
				{
					model.FetchCondition=row["FetchCondition"].ToString();
				}
				if(row["TypeInPerson"]!=null)
				{
					model.TypeInPerson=row["TypeInPerson"].ToString();
				}
				if(row["CheckPerson"]!=null)
				{
					model.CheckPerson=row["CheckPerson"].ToString();
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Visa_id,GroupNo,Name,Types,Tips,PredictTime,RealTime,FinishTime,Satus,Person,Number,Picture,ListCount,List,SalesPerson,Receipt,Quidco,Cost,OtherCost,ExpressNo,Call,Sale_id,DepartmentId,EntryTime,Country,Passengers,WorkId,Documenter,Price,ConsulateCost,VisaPersonCost,MailCost,Tips2,SubmitFlag,GroupPrice,InvitationCost,Remark,SubmitTime,InTime,OutTime,Client,DepartureType,SubmitCondition,FetchCondition,TypeInPerson,CheckPerson,IsUrgent,ActType ");
			strSql.Append(" FROM VisaWithActRecords ");
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
			strSql.Append(" Visa_id,GroupNo,Name,Types,Tips,PredictTime,RealTime,FinishTime,Satus,Person,Number,Picture,ListCount,List,SalesPerson,Receipt,Quidco,Cost,OtherCost,ExpressNo,Call,Sale_id,DepartmentId,EntryTime,Country,Passengers,WorkId,Documenter,Price,ConsulateCost,VisaPersonCost,MailCost,Tips2,SubmitFlag,GroupPrice,InvitationCost,Remark,SubmitTime,InTime,OutTime,Client,DepartureType,SubmitCondition,FetchCondition,TypeInPerson,CheckPerson,IsUrgent ");
			strSql.Append(" FROM Visa ");
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
			strSql.Append("select count(1) FROM Visa ");
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
				strSql.Append("order by T.Visa_id desc");
			}
			strSql.Append(")AS Row, T.*  from Visa T ");
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
			parameters[0].Value = "Visa";
			parameters[1].Value = "Visa_id";
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

