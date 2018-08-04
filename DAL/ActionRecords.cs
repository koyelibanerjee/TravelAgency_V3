using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace TravelAgency.DAL  
{
	 	//ActionRecords
		public partial class ActionRecords
	{
   		     
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ActionRecords");
			strSql.Append(" where ");
			                                       strSql.Append(" id = @id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据,整形自增长返回id,guid返回parameters[0].Value,string返回true or false
		/// </summary>
		      public int Add(TravelAgency.Model.ActionRecords model)
				{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ActionRecords(");			
            strSql.Append("ActType,WorkId,UserName,VisaInfo_id,Visa_id,Type,EntryTime,Country,District");
			strSql.Append(") values (");
            strSql.Append("@ActType,@WorkId,@UserName,@VisaInfo_id,@Visa_id,@Type,@EntryTime,@Country,@District");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@ActType", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@WorkId", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@UserName", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@VisaInfo_id", SqlDbType.UniqueIdentifier,16) ,            
                        new SqlParameter("@Visa_id", SqlDbType.UniqueIdentifier,16) ,            
                        new SqlParameter("@Type", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@EntryTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Country", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@District", SqlDbType.Int,4)             
              
            };
			            
            parameters[0].Value = model.ActType;                        
            parameters[1].Value = model.WorkId;                        
            parameters[2].Value = model.UserName;                        
            parameters[3].Value = model.VisaInfo_id;                        
            parameters[4].Value = model.Visa_id;                        
            parameters[5].Value = model.Type;                        
            parameters[6].Value = model.EntryTime;                        
            parameters[7].Value = model.Country;                        
            parameters[8].Value = model.District;                        
			   
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
		public bool Update(TravelAgency.Model.ActionRecords model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ActionRecords set ");
			                                                
            strSql.Append(" ActType = @ActType , ");                                    
            strSql.Append(" WorkId = @WorkId , ");                                    
            strSql.Append(" UserName = @UserName , ");                                    
            strSql.Append(" VisaInfo_id = @VisaInfo_id , ");                                    
            strSql.Append(" Visa_id = @Visa_id , ");                                    
            strSql.Append(" Type = @Type , ");                                    
            strSql.Append(" EntryTime = @EntryTime , ");                                    
            strSql.Append(" Country = @Country , ");                                    
            strSql.Append(" District = @District  ");            			
			strSql.Append(" where id=@id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@ActType", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@WorkId", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@UserName", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@VisaInfo_id", SqlDbType.UniqueIdentifier,16) ,            
                        new SqlParameter("@Visa_id", SqlDbType.UniqueIdentifier,16) ,            
                        new SqlParameter("@Type", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@EntryTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Country", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@District", SqlDbType.Int,4)             
              
            };
						            
            parameters[0].Value = model.id;                        
            parameters[1].Value = model.ActType;                        
            parameters[2].Value = model.WorkId;                        
            parameters[3].Value = model.UserName;                        
            parameters[4].Value = model.VisaInfo_id;                        
            parameters[5].Value = model.Visa_id;                        
            parameters[6].Value = model.Type;                        
            parameters[7].Value = model.EntryTime;                        
            parameters[8].Value = model.Country;                        
            parameters[9].Value = model.District;                        
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
			strSql.Append("delete from ActionRecords ");
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
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ActionRecords ");
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
		public TravelAgency.Model.ActionRecords GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id, ActType, WorkId, UserName, VisaInfo_id, Visa_id, Type, EntryTime, Country, District  ");			
			strSql.Append("  from ActionRecords ");
			strSql.Append(" where id=@id");
						SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			
			TravelAgency.Model.ActionRecords model=new TravelAgency.Model.ActionRecords();
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
		public TravelAgency.Model.ActionRecords DataRowToModel(DataRow row)
		{
			TravelAgency.Model.ActionRecords model=new TravelAgency.Model.ActionRecords();
			if(row != null)
			{
												if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
																																				if(row["ActType"]!=null && row["ActType"].ToString()!="")
				{
					model.ActType= row["ActType"].ToString();
				}
																																if(row["WorkId"]!=null && row["WorkId"].ToString()!="")
				{
					model.WorkId= row["WorkId"].ToString();
				}
																																if(row["UserName"]!=null && row["UserName"].ToString()!="")
				{
					model.UserName= row["UserName"].ToString();
				}
																																								if(row["VisaInfo_id"]!=null && row["VisaInfo_id"].ToString()!="")
				{
					model.VisaInfo_id= new Guid(row["VisaInfo_id"].ToString());
				}
																																if(row["Visa_id"]!=null && row["Visa_id"].ToString()!="")
				{
					model.Visa_id= new Guid(row["Visa_id"].ToString());
				}
																								if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type= row["Type"].ToString();
				}
																												if(row["EntryTime"]!=null && row["EntryTime"].ToString()!="")
				{
					model.EntryTime=DateTime.Parse(row["EntryTime"].ToString());
				}
																																				if(row["Country"]!=null && row["Country"].ToString()!="")
				{
					model.Country= row["Country"].ToString();
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
			strSql.Append(" id, ActType, WorkId, UserName, VisaInfo_id, Visa_id, Type, EntryTime, Country, District  ");
			strSql.Append(" FROM ActionRecords ");
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
			strSql.Append("select count(1) FROM ActionRecords ");
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
			strSql.Append("select id, ActType, WorkId, UserName, VisaInfo_id, Visa_id, Type, EntryTime, Country, District  ");
			
			strSql.Append(" FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			strSql.Append(")AS Row, T.*  from ActionRecords T ");
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

