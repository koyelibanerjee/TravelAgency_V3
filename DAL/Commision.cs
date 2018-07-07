using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace TravelAgency.DAL  
{
	 	//Commision
		public partial class Commision
	{
   		     
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Commision");
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
		      public int Add(TravelAgency.Model.Commision model)
				{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Commision(");			
            strSql.Append("Country,ConsularDistrict,TypeInWay,DepartureType,ConsulateCost,TypeInCost,SendVisaCost,OperatorCommision,FetchVisaCost,OtherCost,OtherCost2,VisaCost");
			strSql.Append(") values (");
            strSql.Append("@Country,@ConsularDistrict,@TypeInWay,@DepartureType,@ConsulateCost,@TypeInCost,@SendVisaCost,@OperatorCommision,@FetchVisaCost,@OtherCost,@OtherCost2,@VisaCost");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@Country", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@ConsularDistrict", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@TypeInWay", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@DepartureType", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@ConsulateCost", SqlDbType.Money,8) ,            
                        new SqlParameter("@TypeInCost", SqlDbType.Money,8) ,            
                        new SqlParameter("@SendVisaCost", SqlDbType.Money,8) ,            
                        new SqlParameter("@OperatorCommision", SqlDbType.Money,8) ,            
                        new SqlParameter("@FetchVisaCost", SqlDbType.Money,8) ,            
                        new SqlParameter("@OtherCost", SqlDbType.Money,8) ,            
                        new SqlParameter("@OtherCost2", SqlDbType.Money,8) ,            
                        new SqlParameter("@VisaCost", SqlDbType.Money,8)             
              
            };
			            
            parameters[0].Value = model.Country;                        
            parameters[1].Value = model.ConsularDistrict;                        
            parameters[2].Value = model.TypeInWay;                        
            parameters[3].Value = model.DepartureType;                        
            parameters[4].Value = model.ConsulateCost;                        
            parameters[5].Value = model.TypeInCost;                        
            parameters[6].Value = model.SendVisaCost;                        
            parameters[7].Value = model.OperatorCommision;                        
            parameters[8].Value = model.FetchVisaCost;                        
            parameters[9].Value = model.OtherCost;                        
            parameters[10].Value = model.OtherCost2;                        
            parameters[11].Value = model.VisaCost;                        
			   
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
		public bool Update(TravelAgency.Model.Commision model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Commision set ");
			                                                
            strSql.Append(" Country = @Country , ");                                    
            strSql.Append(" ConsularDistrict = @ConsularDistrict , ");                                    
            strSql.Append(" TypeInWay = @TypeInWay , ");                                    
            strSql.Append(" DepartureType = @DepartureType , ");                                    
            strSql.Append(" ConsulateCost = @ConsulateCost , ");                                    
            strSql.Append(" TypeInCost = @TypeInCost , ");                                    
            strSql.Append(" SendVisaCost = @SendVisaCost , ");                                    
            strSql.Append(" OperatorCommision = @OperatorCommision , ");                                    
            strSql.Append(" FetchVisaCost = @FetchVisaCost , ");                                    
            strSql.Append(" OtherCost = @OtherCost , ");                                    
            strSql.Append(" OtherCost2 = @OtherCost2 , ");                                    
            strSql.Append(" VisaCost = @VisaCost  ");            			
			strSql.Append(" where Id=@Id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Country", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@ConsularDistrict", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@TypeInWay", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@DepartureType", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@ConsulateCost", SqlDbType.Money,8) ,            
                        new SqlParameter("@TypeInCost", SqlDbType.Money,8) ,            
                        new SqlParameter("@SendVisaCost", SqlDbType.Money,8) ,            
                        new SqlParameter("@OperatorCommision", SqlDbType.Money,8) ,            
                        new SqlParameter("@FetchVisaCost", SqlDbType.Money,8) ,            
                        new SqlParameter("@OtherCost", SqlDbType.Money,8) ,            
                        new SqlParameter("@OtherCost2", SqlDbType.Money,8) ,            
                        new SqlParameter("@VisaCost", SqlDbType.Money,8)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.Country;                        
            parameters[2].Value = model.ConsularDistrict;                        
            parameters[3].Value = model.TypeInWay;                        
            parameters[4].Value = model.DepartureType;                        
            parameters[5].Value = model.ConsulateCost;                        
            parameters[6].Value = model.TypeInCost;                        
            parameters[7].Value = model.SendVisaCost;                        
            parameters[8].Value = model.OperatorCommision;                        
            parameters[9].Value = model.FetchVisaCost;                        
            parameters[10].Value = model.OtherCost;                        
            parameters[11].Value = model.OtherCost2;                        
            parameters[12].Value = model.VisaCost;                        
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
			strSql.Append("delete from Commision ");
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
			strSql.Append("delete from Commision ");
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
		public TravelAgency.Model.Commision GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, Country, ConsularDistrict, TypeInWay, DepartureType, ConsulateCost, TypeInCost, SendVisaCost, OperatorCommision, FetchVisaCost, OtherCost, OtherCost2, VisaCost  ");			
			strSql.Append("  from Commision ");
			strSql.Append(" where Id=@Id");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			
			TravelAgency.Model.Commision model=new TravelAgency.Model.Commision();
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
		public TravelAgency.Model.Commision DataRowToModel(DataRow row)
		{
			TravelAgency.Model.Commision model=new TravelAgency.Model.Commision();
			if(row != null)
			{
												if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
																																				if(row["Country"]!=null && row["Country"].ToString()!="")
				{
					model.Country= row["Country"].ToString();
				}
																																if(row["ConsularDistrict"]!=null && row["ConsularDistrict"].ToString()!="")
				{
					model.ConsularDistrict= row["ConsularDistrict"].ToString();
				}
																																if(row["TypeInWay"]!=null && row["TypeInWay"].ToString()!="")
				{
					model.TypeInWay= row["TypeInWay"].ToString();
				}
																																if(row["DepartureType"]!=null && row["DepartureType"].ToString()!="")
				{
					model.DepartureType= row["DepartureType"].ToString();
				}
																												if(row["ConsulateCost"]!=null && row["ConsulateCost"].ToString()!="")
				{
					model.ConsulateCost=decimal.Parse(row["ConsulateCost"].ToString());
				}
																																if(row["TypeInCost"]!=null && row["TypeInCost"].ToString()!="")
				{
					model.TypeInCost=decimal.Parse(row["TypeInCost"].ToString());
				}
																																if(row["SendVisaCost"]!=null && row["SendVisaCost"].ToString()!="")
				{
					model.SendVisaCost=decimal.Parse(row["SendVisaCost"].ToString());
				}
																																if(row["OperatorCommision"]!=null && row["OperatorCommision"].ToString()!="")
				{
					model.OperatorCommision=decimal.Parse(row["OperatorCommision"].ToString());
				}
																																if(row["FetchVisaCost"]!=null && row["FetchVisaCost"].ToString()!="")
				{
					model.FetchVisaCost=decimal.Parse(row["FetchVisaCost"].ToString());
				}
																																if(row["OtherCost"]!=null && row["OtherCost"].ToString()!="")
				{
					model.OtherCost=decimal.Parse(row["OtherCost"].ToString());
				}
																																if(row["OtherCost2"]!=null && row["OtherCost2"].ToString()!="")
				{
					model.OtherCost2=decimal.Parse(row["OtherCost2"].ToString());
				}
																																if(row["VisaCost"]!=null && row["VisaCost"].ToString()!="")
				{
					model.VisaCost=decimal.Parse(row["VisaCost"].ToString());
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
			strSql.Append(" Id, Country, ConsularDistrict, TypeInWay, DepartureType, ConsulateCost, TypeInCost, SendVisaCost, OperatorCommision, FetchVisaCost, OtherCost, OtherCost2, VisaCost  ");
			strSql.Append(" FROM Commision ");
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
			strSql.Append("select count(1) FROM Commision ");
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
			strSql.Append("select Id, Country, ConsularDistrict, TypeInWay, DepartureType, ConsulateCost, TypeInCost, SendVisaCost, OperatorCommision, FetchVisaCost, OtherCost, OtherCost2, VisaCost  ");
			
			strSql.Append(" FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			strSql.Append(")AS Row, T.*  from Commision T ");
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

