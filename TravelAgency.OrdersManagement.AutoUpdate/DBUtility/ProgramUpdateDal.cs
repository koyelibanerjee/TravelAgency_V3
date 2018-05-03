using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TravelAgency.OrdersManagement.AutoUpdate.DBUtility;//Please add references
using TravelAgency.OrdersManagement.AutoUpdate;
namespace TravelAgency.OrdersManagement.AutoUpdate.DAL
{
	/// <summary>
	/// 数据访问类:ProgramUpdate
	/// </summary>
	public partial class ProgramUpdateDal
	{
		public ProgramUpdateDal()
		{}

        #region My Method
        public Model.ProgramUpdateModel GetLatestModel()
        {
            string sql = "select top 1 * from ProgramUpdate order by Version desc";

            var ds = DbHelperSQL.Query(sql);
            try
            {
                if (ds != null)
                    return DataRowToModel(ds.Tables[0].Rows[0]);
                return null;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region  BasicMethod



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgency.OrdersManagement.AutoUpdate.Model.ProgramUpdateModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProgramUpdate(");
			strSql.Append("Version,UpdateFiles,UpdateDetails,EntryTime)");
			strSql.Append(" values (");
			strSql.Append("@Version,@UpdateFiles,@UpdateDetails,@EntryTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Version", SqlDbType.VarChar,50),
					new SqlParameter("@UpdateFiles", SqlDbType.Text),
					new SqlParameter("@UpdateDetails", SqlDbType.Text),
					new SqlParameter("@EntryTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Version;
			parameters[1].Value = model.UpdateFiles;
			parameters[2].Value = model.UpdateDetails;
			parameters[3].Value = model.EntryTime;

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
		public bool Update(TravelAgency.OrdersManagement.AutoUpdate.Model.ProgramUpdateModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProgramUpdate set ");
			strSql.Append("Version=@Version,");
			strSql.Append("UpdateFiles=@UpdateFiles,");
			strSql.Append("UpdateDetails=@UpdateDetails,");
			strSql.Append("EntryTime=@EntryTime");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Version", SqlDbType.VarChar,50),
					new SqlParameter("@UpdateFiles", SqlDbType.Text),
					new SqlParameter("@UpdateDetails", SqlDbType.Text),
					new SqlParameter("@EntryTime", SqlDbType.DateTime),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Version;
			parameters[1].Value = model.UpdateFiles;
			parameters[2].Value = model.UpdateDetails;
			parameters[3].Value = model.EntryTime;
			parameters[4].Value = model.Id;

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
			strSql.Append("delete from ProgramUpdate ");
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
			strSql.Append("delete from ProgramUpdate ");
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
		public TravelAgency.OrdersManagement.AutoUpdate.Model.ProgramUpdateModel GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Version,UpdateFiles,UpdateDetails,EntryTime from ProgramUpdate ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			TravelAgency.OrdersManagement.AutoUpdate.Model.ProgramUpdateModel model=new TravelAgency.OrdersManagement.AutoUpdate.Model.ProgramUpdateModel();
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
		public TravelAgency.OrdersManagement.AutoUpdate.Model.ProgramUpdateModel DataRowToModel(DataRow row)
		{
			TravelAgency.OrdersManagement.AutoUpdate.Model.ProgramUpdateModel model =new TravelAgency.OrdersManagement.AutoUpdate.Model.ProgramUpdateModel();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["Version"]!=null)
				{
					model.Version=row["Version"].ToString();
				}
				if(row["UpdateFiles"]!=null)
				{
					model.UpdateFiles=row["UpdateFiles"].ToString();
				}
				if(row["UpdateDetails"]!=null)
				{
					model.UpdateDetails=row["UpdateDetails"].ToString();
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
			strSql.Append("select Id,Version,UpdateFiles,UpdateDetails,EntryTime ");
			strSql.Append(" FROM ProgramUpdate ");
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
			strSql.Append(" Id,Version,UpdateFiles,UpdateDetails,EntryTime ");
			strSql.Append(" FROM ProgramUpdate ");
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
			strSql.Append("select count(1) FROM ProgramUpdate ");
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
			strSql.Append(")AS Row, T.*  from ProgramUpdate T ");
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
			parameters[0].Value = "ProgramUpdate";
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

