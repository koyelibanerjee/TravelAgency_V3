using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
	/// <summary>
	/// 数据访问类:OrderInfo
	/// </summary>
	public partial class OrderInfo
	{
		public OrderInfo()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TravelAgency.Model.OrderInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OrderInfo(");
			strSql.Append("OrderNo,Amount,OrderType,ProductName,OrderTime,EntryTime,ExtraData,OrderExcelId,OrderInfoState,OperatorName,OperatorWorkId)");
			strSql.Append(" values (");
			strSql.Append("@OrderNo,@Amount,@OrderType,@ProductName,@OrderTime,@EntryTime,@ExtraData,@OrderExcelId,@OrderInfoState,@OperatorName,@OperatorWorkId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.VarChar,50),
					new SqlParameter("@Amount", SqlDbType.Money,8),
					new SqlParameter("@OrderType", SqlDbType.TinyInt,1),
					new SqlParameter("@ProductName", SqlDbType.VarChar,200),
					new SqlParameter("@OrderTime", SqlDbType.DateTime),
					new SqlParameter("@EntryTime", SqlDbType.DateTime),
					new SqlParameter("@ExtraData", SqlDbType.Text),
					new SqlParameter("@OrderExcelId", SqlDbType.Int,4),
					new SqlParameter("@OrderInfoState", SqlDbType.TinyInt,1),
					new SqlParameter("@OperatorName", SqlDbType.VarChar,50),
					new SqlParameter("@OperatorWorkId", SqlDbType.VarChar,50)};
			parameters[0].Value = model.OrderNo;
			parameters[1].Value = model.Amount;
			parameters[2].Value = model.OrderType;
			parameters[3].Value = model.ProductName;
			parameters[4].Value = model.OrderTime;
			parameters[5].Value = model.EntryTime;
			parameters[6].Value = model.ExtraData;
			parameters[7].Value = model.OrderExcelId;
			parameters[8].Value = model.OrderInfoState;
			parameters[9].Value = model.OperatorName;
			parameters[10].Value = model.OperatorWorkId;

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
		public bool Update(TravelAgency.Model.OrderInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OrderInfo set ");
			strSql.Append("OrderNo=@OrderNo,");
			strSql.Append("Amount=@Amount,");
			strSql.Append("OrderType=@OrderType,");
			strSql.Append("ProductName=@ProductName,");
			strSql.Append("OrderTime=@OrderTime,");
			strSql.Append("EntryTime=@EntryTime,");
			strSql.Append("ExtraData=@ExtraData,");
			strSql.Append("OrderExcelId=@OrderExcelId,");
			strSql.Append("OrderInfoState=@OrderInfoState,");
			strSql.Append("OperatorName=@OperatorName,");
			strSql.Append("OperatorWorkId=@OperatorWorkId");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.VarChar,50),
					new SqlParameter("@Amount", SqlDbType.Money,8),
					new SqlParameter("@OrderType", SqlDbType.TinyInt,1),
					new SqlParameter("@ProductName", SqlDbType.VarChar,200),
					new SqlParameter("@OrderTime", SqlDbType.DateTime),
					new SqlParameter("@EntryTime", SqlDbType.DateTime),
					new SqlParameter("@ExtraData", SqlDbType.Text),
					new SqlParameter("@OrderExcelId", SqlDbType.Int,4),
					new SqlParameter("@OrderInfoState", SqlDbType.TinyInt,1),
					new SqlParameter("@OperatorName", SqlDbType.VarChar,50),
					new SqlParameter("@OperatorWorkId", SqlDbType.VarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.OrderNo;
			parameters[1].Value = model.Amount;
			parameters[2].Value = model.OrderType;
			parameters[3].Value = model.ProductName;
			parameters[4].Value = model.OrderTime;
			parameters[5].Value = model.EntryTime;
			parameters[6].Value = model.ExtraData;
			parameters[7].Value = model.OrderExcelId;
			parameters[8].Value = model.OrderInfoState;
			parameters[9].Value = model.OperatorName;
			parameters[10].Value = model.OperatorWorkId;
			parameters[11].Value = model.Id;

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
			strSql.Append("delete from OrderInfo ");
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
			strSql.Append("delete from OrderInfo ");
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
		public TravelAgency.Model.OrderInfo GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,OrderNo,Amount,OrderType,ProductName,OrderTime,EntryTime,ExtraData,OrderExcelId,OrderInfoState,OperatorName,OperatorWorkId from OrderInfo ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			TravelAgency.Model.OrderInfo model=new TravelAgency.Model.OrderInfo();
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
		public TravelAgency.Model.OrderInfo DataRowToModel(DataRow row)
		{
			TravelAgency.Model.OrderInfo model=new TravelAgency.Model.OrderInfo();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["OrderNo"]!=null)
				{
					model.OrderNo=row["OrderNo"].ToString();
				}
				if(row["Amount"]!=null && row["Amount"].ToString()!="")
				{
					model.Amount=decimal.Parse(row["Amount"].ToString());
				}
				if(row["OrderType"]!=null && row["OrderType"].ToString()!="")
				{
					model.OrderType=int.Parse(row["OrderType"].ToString());
				}
				if(row["ProductName"]!=null)
				{
					model.ProductName=row["ProductName"].ToString();
				}
				if(row["OrderTime"]!=null && row["OrderTime"].ToString()!="")
				{
					model.OrderTime=DateTime.Parse(row["OrderTime"].ToString());
				}
				if(row["EntryTime"]!=null && row["EntryTime"].ToString()!="")
				{
					model.EntryTime=DateTime.Parse(row["EntryTime"].ToString());
				}
				if(row["ExtraData"]!=null)
				{
					model.ExtraData=row["ExtraData"].ToString();
				}
				if(row["OrderExcelId"]!=null && row["OrderExcelId"].ToString()!="")
				{
					model.OrderExcelId=int.Parse(row["OrderExcelId"].ToString());
				}
				if(row["OrderInfoState"]!=null && row["OrderInfoState"].ToString()!="")
				{
					model.OrderInfoState=int.Parse(row["OrderInfoState"].ToString());
				}
				if(row["OperatorName"]!=null)
				{
					model.OperatorName=row["OperatorName"].ToString();
				}
				if(row["OperatorWorkId"]!=null)
				{
					model.OperatorWorkId=row["OperatorWorkId"].ToString();
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
			strSql.Append("select Id,OrderNo,Amount,OrderType,ProductName,OrderTime,EntryTime,ExtraData,OrderExcelId,OrderInfoState,OperatorName,OperatorWorkId ");
			strSql.Append(" FROM OrderInfo ");
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
			strSql.Append(" Id,OrderNo,Amount,OrderType,ProductName,OrderTime,EntryTime,ExtraData,OrderExcelId,OrderInfoState,OperatorName,OperatorWorkId ");
			strSql.Append(" FROM OrderInfo ");
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
			strSql.Append("select count(1) FROM OrderInfo ");
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
			strSql.Append(")AS Row, T.*  from OrderInfo T ");
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
			parameters[0].Value = "OrderInfo";
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

