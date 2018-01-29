using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
	/// <summary>
	/// 数据访问类:CommisionMoney
	/// </summary>
	public partial class CommisionMoney
	{
		public CommisionMoney()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "CommisionMoney"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CommisionMoney");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TravelAgency.Model.CommisionMoney model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CommisionMoney(");
			strSql.Append("Type,Type00ScanedIn,Type02TypeInData,Type05SendSubmission,Type06GetSubmission,Type07AccompanySubmission,Type08Plan)");
			strSql.Append(" values (");
			strSql.Append("@Type,@Type00ScanedIn,@Type02TypeInData,@Type05SendSubmission,@Type06GetSubmission,@Type07AccompanySubmission,@Type08Plan)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.VarChar,50),
					new SqlParameter("@Type00ScanedIn", SqlDbType.Float,8),
					new SqlParameter("@Type02TypeInData", SqlDbType.Float,8),
					new SqlParameter("@Type05SendSubmission", SqlDbType.Float,8),
					new SqlParameter("@Type06GetSubmission", SqlDbType.Float,8),
					new SqlParameter("@Type07AccompanySubmission", SqlDbType.Float,8),
					new SqlParameter("@Type08Plan", SqlDbType.Float,8)};
			parameters[0].Value = model.Type;
			parameters[1].Value = model.Type00ScanedIn;
			parameters[2].Value = model.Type02TypeInData;
			parameters[3].Value = model.Type05SendSubmission;
			parameters[4].Value = model.Type06GetSubmission;
			parameters[5].Value = model.Type07AccompanySubmission;
			parameters[6].Value = model.Type08Plan;

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
		public bool Update(TravelAgency.Model.CommisionMoney model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CommisionMoney set ");
			strSql.Append("Type=@Type,");
			strSql.Append("Type00ScanedIn=@Type00ScanedIn,");
			strSql.Append("Type02TypeInData=@Type02TypeInData,");
			strSql.Append("Type05SendSubmission=@Type05SendSubmission,");
			strSql.Append("Type06GetSubmission=@Type06GetSubmission,");
			strSql.Append("Type07AccompanySubmission=@Type07AccompanySubmission,");
			strSql.Append("Type08Plan=@Type08Plan");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.VarChar,50),
					new SqlParameter("@Type00ScanedIn", SqlDbType.Float,8),
					new SqlParameter("@Type02TypeInData", SqlDbType.Float,8),
					new SqlParameter("@Type05SendSubmission", SqlDbType.Float,8),
					new SqlParameter("@Type06GetSubmission", SqlDbType.Float,8),
					new SqlParameter("@Type07AccompanySubmission", SqlDbType.Float,8),
					new SqlParameter("@Type08Plan", SqlDbType.Float,8),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.Type;
			parameters[1].Value = model.Type00ScanedIn;
			parameters[2].Value = model.Type02TypeInData;
			parameters[3].Value = model.Type05SendSubmission;
			parameters[4].Value = model.Type06GetSubmission;
			parameters[5].Value = model.Type07AccompanySubmission;
			parameters[6].Value = model.Type08Plan;
			parameters[7].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CommisionMoney ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CommisionMoney ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public TravelAgency.Model.CommisionMoney GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,Type,Type00ScanedIn,Type02TypeInData,Type05SendSubmission,Type06GetSubmission,Type07AccompanySubmission,Type08Plan from CommisionMoney ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			TravelAgency.Model.CommisionMoney model=new TravelAgency.Model.CommisionMoney();
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
		public TravelAgency.Model.CommisionMoney DataRowToModel(DataRow row)
		{
			TravelAgency.Model.CommisionMoney model=new TravelAgency.Model.CommisionMoney();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["Type"]!=null)
				{
					model.Type=row["Type"].ToString();
				}
				if(row["Type00ScanedIn"]!=null && row["Type00ScanedIn"].ToString()!="")
				{
					model.Type00ScanedIn=decimal.Parse(row["Type00ScanedIn"].ToString());
				}
				if(row["Type02TypeInData"]!=null && row["Type02TypeInData"].ToString()!="")
				{
					model.Type02TypeInData=decimal.Parse(row["Type02TypeInData"].ToString());
				}
				if(row["Type05SendSubmission"]!=null && row["Type05SendSubmission"].ToString()!="")
				{
					model.Type05SendSubmission=decimal.Parse(row["Type05SendSubmission"].ToString());
				}
				if(row["Type06GetSubmission"]!=null && row["Type06GetSubmission"].ToString()!="")
				{
					model.Type06GetSubmission=decimal.Parse(row["Type06GetSubmission"].ToString());
				}
				if(row["Type07AccompanySubmission"]!=null && row["Type07AccompanySubmission"].ToString()!="")
				{
					model.Type07AccompanySubmission=decimal.Parse(row["Type07AccompanySubmission"].ToString());
				}
				if(row["Type08Plan"]!=null && row["Type08Plan"].ToString()!="")
				{
					model.Type08Plan=decimal.Parse(row["Type08Plan"].ToString());
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
			strSql.Append("select id,Type,Type00ScanedIn,Type02TypeInData,Type05SendSubmission,Type06GetSubmission,Type07AccompanySubmission,Type08Plan ");
			strSql.Append(" FROM CommisionMoney ");
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
			strSql.Append(" id,Type,Type00ScanedIn,Type02TypeInData,Type05SendSubmission,Type06GetSubmission,Type07AccompanySubmission,Type08Plan ");
			strSql.Append(" FROM CommisionMoney ");
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
			strSql.Append("select count(1) FROM CommisionMoney ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from CommisionMoney T ");
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
			parameters[0].Value = "CommisionMoney";
			parameters[1].Value = "id";
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

