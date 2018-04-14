using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
	/// <summary>
	/// 数据访问类:Enums_OrderInfo_OrderInfoState
	/// </summary>
	public partial class Enums_OrderInfo_OrderInfoState
	{
		public Enums_OrderInfo_OrderInfoState()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(TravelAgency.Model.Enums_OrderInfo_OrderInfoState model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Enums_OrderInfo_OrderInfoState(");
			strSql.Append("StateNo,StateInfo)");
			strSql.Append(" values (");
			strSql.Append("@StateNo,@StateInfo)");
			SqlParameter[] parameters = {
					new SqlParameter("@StateNo", SqlDbType.TinyInt,1),
					new SqlParameter("@StateInfo", SqlDbType.VarChar,50)};
			parameters[0].Value = model.StateNo;
			parameters[1].Value = model.StateInfo;

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
		public bool Update(TravelAgency.Model.Enums_OrderInfo_OrderInfoState model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Enums_OrderInfo_OrderInfoState set ");
			strSql.Append("StateNo=@StateNo,");
			strSql.Append("StateInfo=@StateInfo");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@StateNo", SqlDbType.TinyInt,1),
					new SqlParameter("@StateInfo", SqlDbType.VarChar,50)};
			parameters[0].Value = model.StateNo;
			parameters[1].Value = model.StateInfo;

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
			strSql.Append("delete from Enums_OrderInfo_OrderInfoState ");
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
		public TravelAgency.Model.Enums_OrderInfo_OrderInfoState GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StateNo,StateInfo from Enums_OrderInfo_OrderInfoState ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			TravelAgency.Model.Enums_OrderInfo_OrderInfoState model=new TravelAgency.Model.Enums_OrderInfo_OrderInfoState();
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
		public TravelAgency.Model.Enums_OrderInfo_OrderInfoState DataRowToModel(DataRow row)
		{
			TravelAgency.Model.Enums_OrderInfo_OrderInfoState model=new TravelAgency.Model.Enums_OrderInfo_OrderInfoState();
			if (row != null)
			{
				if(row["StateNo"]!=null && row["StateNo"].ToString()!="")
				{
					model.StateNo=int.Parse(row["StateNo"].ToString());
				}
				if(row["StateInfo"]!=null)
				{
					model.StateInfo=row["StateInfo"].ToString();
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
			strSql.Append("select StateNo,StateInfo ");
			strSql.Append(" FROM Enums_OrderInfo_OrderInfoState ");
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
			strSql.Append(" StateNo,StateInfo ");
			strSql.Append(" FROM Enums_OrderInfo_OrderInfoState ");
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
			strSql.Append("select count(1) FROM Enums_OrderInfo_OrderInfoState ");
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
			strSql.Append(")AS Row, T.*  from Enums_OrderInfo_OrderInfoState T ");
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
			parameters[0].Value = "Enums_OrderInfo_OrderInfoState";
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

