using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace TravelAgency.DAL  
{
	 	//OrderGuest
		public partial class OrderGuest
	{
   		     
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OrderGuest");
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
		      public int Add(TravelAgency.Model.OrderGuest model)
				{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OrderGuest(");			
            strSql.Append("OrdersId,GuestId,GuestType,GuestName,GuestNamePinYin,GuestSex,GuestBirthday,GuestPhone,GuestWeChat,GuestEMail,GuestPassportNo,GuestLastNightHotel,GuestCountry,Price");
			strSql.Append(") values (");
            strSql.Append("@OrdersId,@GuestId,@GuestType,@GuestName,@GuestNamePinYin,@GuestSex,@GuestBirthday,@GuestPhone,@GuestWeChat,@GuestEMail,@GuestPassportNo,@GuestLastNightHotel,@GuestCountry,@Price");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@OrdersId", SqlDbType.Int,4) ,            
                        new SqlParameter("@GuestId", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GuestType", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@GuestName", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@GuestNamePinYin", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GuestSex", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@GuestBirthday", SqlDbType.DateTime,3) ,            
                        new SqlParameter("@GuestPhone", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@GuestWeChat", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GuestEMail", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GuestPassportNo", SqlDbType.VarChar,30) ,            
                        new SqlParameter("@GuestLastNightHotel", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GuestCountry", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@Price", SqlDbType.Money,8)             
              
            };
			            
            parameters[0].Value = model.OrdersId;                        
            parameters[1].Value = model.GuestId;                        
            parameters[2].Value = model.GuestType;                        
            parameters[3].Value = model.GuestName;                        
            parameters[4].Value = model.GuestNamePinYin;                        
            parameters[5].Value = model.GuestSex;                        
            parameters[6].Value = model.GuestBirthday;                        
            parameters[7].Value = model.GuestPhone;                        
            parameters[8].Value = model.GuestWeChat;                        
            parameters[9].Value = model.GuestEMail;                        
            parameters[10].Value = model.GuestPassportNo;                        
            parameters[11].Value = model.GuestLastNightHotel;                        
            parameters[12].Value = model.GuestCountry;                        
            parameters[13].Value = model.Price;                        
			   
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
		public bool Update(TravelAgency.Model.OrderGuest model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OrderGuest set ");
			                                                
            strSql.Append(" OrdersId = @OrdersId , ");                                    
            strSql.Append(" GuestId = @GuestId , ");                                    
            strSql.Append(" GuestType = @GuestType , ");                                    
            strSql.Append(" GuestName = @GuestName , ");                                    
            strSql.Append(" GuestNamePinYin = @GuestNamePinYin , ");                                    
            strSql.Append(" GuestSex = @GuestSex , ");                                    
            strSql.Append(" GuestBirthday = @GuestBirthday , ");                                    
            strSql.Append(" GuestPhone = @GuestPhone , ");                                    
            strSql.Append(" GuestWeChat = @GuestWeChat , ");                                    
            strSql.Append(" GuestEMail = @GuestEMail , ");                                    
            strSql.Append(" GuestPassportNo = @GuestPassportNo , ");                                    
            strSql.Append(" GuestLastNightHotel = @GuestLastNightHotel , ");                                    
            strSql.Append(" GuestCountry = @GuestCountry , ");                                    
            strSql.Append(" Price = @Price  ");            			
			strSql.Append(" where Id=@Id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@OrdersId", SqlDbType.Int,4) ,            
                        new SqlParameter("@GuestId", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GuestType", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@GuestName", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@GuestNamePinYin", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GuestSex", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@GuestBirthday", SqlDbType.DateTime,3) ,            
                        new SqlParameter("@GuestPhone", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@GuestWeChat", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GuestEMail", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GuestPassportNo", SqlDbType.VarChar,30) ,            
                        new SqlParameter("@GuestLastNightHotel", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GuestCountry", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@Price", SqlDbType.Money,8)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.OrdersId;                        
            parameters[2].Value = model.GuestId;                        
            parameters[3].Value = model.GuestType;                        
            parameters[4].Value = model.GuestName;                        
            parameters[5].Value = model.GuestNamePinYin;                        
            parameters[6].Value = model.GuestSex;                        
            parameters[7].Value = model.GuestBirthday;                        
            parameters[8].Value = model.GuestPhone;                        
            parameters[9].Value = model.GuestWeChat;                        
            parameters[10].Value = model.GuestEMail;                        
            parameters[11].Value = model.GuestPassportNo;                        
            parameters[12].Value = model.GuestLastNightHotel;                        
            parameters[13].Value = model.GuestCountry;                        
            parameters[14].Value = model.Price;                        
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
			strSql.Append("delete from OrderGuest ");
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
			strSql.Append("delete from OrderGuest ");
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
		public TravelAgency.Model.OrderGuest GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, OrdersId, GuestId, GuestType, GuestName, GuestNamePinYin, GuestSex, GuestBirthday, GuestPhone, GuestWeChat, GuestEMail, GuestPassportNo, GuestLastNightHotel, GuestCountry, Price  ");			
			strSql.Append("  from OrderGuest ");
			strSql.Append(" where Id=@Id");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			
			TravelAgency.Model.OrderGuest model=new TravelAgency.Model.OrderGuest();
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
		public TravelAgency.Model.OrderGuest DataRowToModel(DataRow row)
		{
			TravelAgency.Model.OrderGuest model=new TravelAgency.Model.OrderGuest();
			if(row != null)
			{
												if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
																																if(row["OrdersId"]!=null && row["OrdersId"].ToString()!="")
				{
					model.OrdersId=int.Parse(row["OrdersId"].ToString());
				}
																																				if(row["GuestId"]!=null && row["GuestId"].ToString()!="")
				{
					model.GuestId= row["GuestId"].ToString();
				}
																																if(row["GuestType"]!=null && row["GuestType"].ToString()!="")
				{
					model.GuestType= row["GuestType"].ToString();
				}
																																if(row["GuestName"]!=null && row["GuestName"].ToString()!="")
				{
					model.GuestName= row["GuestName"].ToString();
				}
																																if(row["GuestNamePinYin"]!=null && row["GuestNamePinYin"].ToString()!="")
				{
					model.GuestNamePinYin= row["GuestNamePinYin"].ToString();
				}
																																if(row["GuestSex"]!=null && row["GuestSex"].ToString()!="")
				{
					model.GuestSex= row["GuestSex"].ToString();
				}
																												if(row["GuestBirthday"]!=null && row["GuestBirthday"].ToString()!="")
				{
					model.GuestBirthday=DateTime.Parse(row["GuestBirthday"].ToString());
				}
																																				if(row["GuestPhone"]!=null && row["GuestPhone"].ToString()!="")
				{
					model.GuestPhone= row["GuestPhone"].ToString();
				}
																																if(row["GuestWeChat"]!=null && row["GuestWeChat"].ToString()!="")
				{
					model.GuestWeChat= row["GuestWeChat"].ToString();
				}
																																if(row["GuestEMail"]!=null && row["GuestEMail"].ToString()!="")
				{
					model.GuestEMail= row["GuestEMail"].ToString();
				}
																																if(row["GuestPassportNo"]!=null && row["GuestPassportNo"].ToString()!="")
				{
					model.GuestPassportNo= row["GuestPassportNo"].ToString();
				}
																																if(row["GuestLastNightHotel"]!=null && row["GuestLastNightHotel"].ToString()!="")
				{
					model.GuestLastNightHotel= row["GuestLastNightHotel"].ToString();
				}
																																if(row["GuestCountry"]!=null && row["GuestCountry"].ToString()!="")
				{
					model.GuestCountry= row["GuestCountry"].ToString();
				}
																												if(row["Price"]!=null && row["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(row["Price"].ToString());
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
			strSql.Append(" Id, OrdersId, GuestId, GuestType, GuestName, GuestNamePinYin, GuestSex, GuestBirthday, GuestPhone, GuestWeChat, GuestEMail, GuestPassportNo, GuestLastNightHotel, GuestCountry, Price  ");
			strSql.Append(" FROM OrderGuest ");
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
			strSql.Append("select count(1) FROM OrderGuest ");
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
			strSql.Append("select Id, OrdersId, GuestId, GuestType, GuestName, GuestNamePinYin, GuestSex, GuestBirthday, GuestPhone, GuestWeChat, GuestEMail, GuestPassportNo, GuestLastNightHotel, GuestCountry, Price  ");
			
			strSql.Append(" FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			strSql.Append(")AS Row, T.*  from OrderGuest T ");
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

