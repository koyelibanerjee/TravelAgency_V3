using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace TravelAgency.DAL  
{
	 	//JobAssignment
		public partial class JobAssignment
	{
   		     
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from JobAssignment");
			strSql.Append(" where ");
			                                       strSql.Append(" Id = @Id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据,整形自增长返回id,guid返回parameters[0].Value,string返回true or false
		/// </summary>
		      public int Add(TravelAgency.Model.JobAssignment model)
				{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into JobAssignment(");			
            strSql.Append("EntryTime,AssignmentToWorkId,OperatorId,AssignmentTime,AssignmentToUserName,District");
			strSql.Append(") values (");
            strSql.Append("@EntryTime,@AssignmentToWorkId,@OperatorId,@AssignmentTime,@AssignmentToUserName,@District");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@EntryTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@AssignmentToWorkId", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@OperatorId", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@AssignmentTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@AssignmentToUserName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@District", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.EntryTime;                        
            parameters[1].Value = model.AssignmentToWorkId;                        
            parameters[2].Value = model.OperatorId;                        
            parameters[3].Value = model.AssignmentTime;                        
            parameters[4].Value = model.AssignmentToUserName;                        
            parameters[5].Value = model.District;                        
			   
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
		public bool Update(TravelAgency.Model.JobAssignment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update JobAssignment set ");
			                                                
            strSql.Append(" EntryTime = @EntryTime , ");                                    
            strSql.Append(" AssignmentToWorkId = @AssignmentToWorkId , ");                                    
            strSql.Append(" OperatorId = @OperatorId , ");                                    
            strSql.Append(" AssignmentTime = @AssignmentTime , ");                                    
            strSql.Append(" AssignmentToUserName = @AssignmentToUserName , ");                                    
            strSql.Append(" District = @District  ");            			
			strSql.Append(" where Id=@Id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@EntryTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@AssignmentToWorkId", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@OperatorId", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@AssignmentTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@AssignmentToUserName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@District", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.EntryTime;                        
            parameters[2].Value = model.AssignmentToWorkId;                        
            parameters[3].Value = model.OperatorId;                        
            parameters[4].Value = model.AssignmentTime;                        
            parameters[5].Value = model.AssignmentToUserName;                        
            parameters[6].Value = model.District;                        
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
			strSql.Append("delete from JobAssignment ");
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
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from JobAssignment ");
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
		public TravelAgency.Model.JobAssignment GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, EntryTime, AssignmentToWorkId, OperatorId, AssignmentTime, AssignmentToUserName, District  ");			
			strSql.Append("  from JobAssignment ");
			strSql.Append(" where Id=@Id");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			
			TravelAgency.Model.JobAssignment model=new TravelAgency.Model.JobAssignment();
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
		/// DataRow to Object Model
		/// </summary>
		public TravelAgency.Model.JobAssignment DataRowToModel(DataRow row)
		{
			TravelAgency.Model.JobAssignment model=new TravelAgency.Model.JobAssignment();
			if(row != null)
			{
												if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
																																if(row["EntryTime"]!=null && row["EntryTime"].ToString()!="")
				{
					model.EntryTime=DateTime.Parse(row["EntryTime"].ToString());
				}
																																				if(row["AssignmentToWorkId"]!=null && row["AssignmentToWorkId"].ToString()!="")
				{
					model.AssignmentToWorkId= row["AssignmentToWorkId"].ToString();
				}
																																if(row["OperatorId"]!=null && row["OperatorId"].ToString()!="")
				{
					model.OperatorId= row["OperatorId"].ToString();
				}
																												if(row["AssignmentTime"]!=null && row["AssignmentTime"].ToString()!="")
				{
					model.AssignmentTime=DateTime.Parse(row["AssignmentTime"].ToString());
				}
																																				if(row["AssignmentToUserName"]!=null && row["AssignmentToUserName"].ToString()!="")
				{
					model.AssignmentToUserName= row["AssignmentToUserName"].ToString();
				}
																												if(row["District"]!=null && row["District"].ToString()!="")
				{
					model.District=int.Parse(row["District"].ToString());
				}
																														
				return model;
			}
			else
			{
				return null;
			}
		}
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return GetList(0,strWhere,"");
		}
		
		/// <summary>
		/// 获得前几行数据,top=0则是全部数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Id, EntryTime, AssignmentToWorkId, OperatorId, AssignmentTime, AssignmentToUserName, District  ");
			strSql.Append(" FROM JobAssignment ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
      if(filedOrder.Trim()!="")
			{
        strSql.Append(" order by " + filedOrder);
      }
			return DbHelperSQL.Query(strSql.ToString());
		}
		
		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM JobAssignment ");
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
		/// 分页获取数据列表,orderby 必须传(要自己带desc)
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, EntryTime, AssignmentToWorkId, OperatorId, AssignmentTime, AssignmentToUserName, District  ");
			
			strSql.Append(" FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			strSql.Append(")AS Row, T.*  from JobAssignment T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}
	}
}

