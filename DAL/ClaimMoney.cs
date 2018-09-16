using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace TravelAngecy.DAL  
{
	 	//ClaimMoney
		public partial class ClaimMoney
	{
   		     
		public bool Exists(Guid Claim_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ClaimMoney");
			strSql.Append(" where ");
			                                       strSql.Append(" Claim_id = @Claim_id  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@Claim_id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Claim_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据,整形自增长返回id,guid返回parameters[0].Value,string返回true or false
		/// </summary>
		      public Guid Add(TravelAngecy.Model.ClaimMoney model)
    		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ClaimMoney(");			
            strSql.Append("Claim_id,Money_id,DepartmentId,Name_Claim,GroupNo,Salesperson,Guests,Methods,Amount,WorkId,ClaimTime,username,OrderNo,EntryTime,MoneyType,Claim_Confirm,ActivityOrderNo");
			strSql.Append(") values (");
            strSql.Append("@Claim_id,@Money_id,@DepartmentId,@Name_Claim,@GroupNo,@Salesperson,@Guests,@Methods,@Amount,@WorkId,@ClaimTime,@username,@OrderNo,@EntryTime,@MoneyType,@Claim_Confirm,@ActivityOrderNo");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@Claim_id", SqlDbType.UniqueIdentifier,16) ,            
                        new SqlParameter("@Money_id", SqlDbType.UniqueIdentifier,16) ,            
                        new SqlParameter("@DepartmentId", SqlDbType.UniqueIdentifier,16) ,            
                        new SqlParameter("@Name_Claim", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GroupNo", SqlDbType.VarChar,1500) ,            
                        new SqlParameter("@Salesperson", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Guests", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Methods", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Amount", SqlDbType.Float,8) ,            
                        new SqlParameter("@WorkId", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ClaimTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@username", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@OrderNo", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@EntryTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@MoneyType", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Claim_Confirm", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ActivityOrderNo", SqlDbType.VarChar,50)             
              
            };
			            
            parameters[0].Value = Guid.NewGuid();                        
            parameters[1].Value = model.Money_id;                        
            parameters[2].Value = model.DepartmentId;                        
            parameters[3].Value = model.Name_Claim;                        
            parameters[4].Value = model.GroupNo;                        
            parameters[5].Value = model.Salesperson;                        
            parameters[6].Value = model.Guests;                        
            parameters[7].Value = model.Methods;                        
            parameters[8].Value = model.Amount;                        
            parameters[9].Value = model.WorkId;                        
            parameters[10].Value = model.ClaimTime;                        
            parameters[11].Value = model.username;                        
            parameters[12].Value = model.OrderNo;                        
            parameters[13].Value = model.EntryTime;                        
            parameters[14].Value = model.MoneyType;                        
            parameters[15].Value = model.Claim_Confirm;                        
            parameters[16].Value = model.ActivityOrderNo;                        
			      int rows = DbHelperSQL.ExecuteSql(strSql.ToString(),parameters); 
      if(rows > 0)
      {
        return (Guid)(parameters[0].Value);
      }
      else
      {
          return Guid.Empty;
      }
      			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(TravelAngecy.Model.ClaimMoney model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ClaimMoney set ");
			                        
            strSql.Append(" Claim_id = @Claim_id , ");                                    
            strSql.Append(" Money_id = @Money_id , ");                                    
            strSql.Append(" DepartmentId = @DepartmentId , ");                                    
            strSql.Append(" Name_Claim = @Name_Claim , ");                                    
            strSql.Append(" GroupNo = @GroupNo , ");                                    
            strSql.Append(" Salesperson = @Salesperson , ");                                    
            strSql.Append(" Guests = @Guests , ");                                    
            strSql.Append(" Methods = @Methods , ");                                    
            strSql.Append(" Amount = @Amount , ");                                    
            strSql.Append(" WorkId = @WorkId , ");                                    
            strSql.Append(" ClaimTime = @ClaimTime , ");                                    
            strSql.Append(" username = @username , ");                                    
            strSql.Append(" OrderNo = @OrderNo , ");                                    
            strSql.Append(" EntryTime = @EntryTime , ");                                    
            strSql.Append(" MoneyType = @MoneyType , ");                                    
            strSql.Append(" Claim_Confirm = @Claim_Confirm , ");                                    
            strSql.Append(" ActivityOrderNo = @ActivityOrderNo  ");            			
			strSql.Append(" where Claim_id=@Claim_id  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Claim_id", SqlDbType.UniqueIdentifier,16) ,            
                        new SqlParameter("@Money_id", SqlDbType.UniqueIdentifier,16) ,            
                        new SqlParameter("@DepartmentId", SqlDbType.UniqueIdentifier,16) ,            
                        new SqlParameter("@Name_Claim", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GroupNo", SqlDbType.VarChar,1500) ,            
                        new SqlParameter("@Salesperson", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Guests", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Methods", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Amount", SqlDbType.Float,8) ,            
                        new SqlParameter("@WorkId", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ClaimTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@username", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@OrderNo", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@EntryTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@MoneyType", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Claim_Confirm", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ActivityOrderNo", SqlDbType.VarChar,50)             
              
            };
						            
            parameters[0].Value = model.Claim_id;                        
            parameters[1].Value = model.Money_id;                        
            parameters[2].Value = model.DepartmentId;                        
            parameters[3].Value = model.Name_Claim;                        
            parameters[4].Value = model.GroupNo;                        
            parameters[5].Value = model.Salesperson;                        
            parameters[6].Value = model.Guests;                        
            parameters[7].Value = model.Methods;                        
            parameters[8].Value = model.Amount;                        
            parameters[9].Value = model.WorkId;                        
            parameters[10].Value = model.ClaimTime;                        
            parameters[11].Value = model.username;                        
            parameters[12].Value = model.OrderNo;                        
            parameters[13].Value = model.EntryTime;                        
            parameters[14].Value = model.MoneyType;                        
            parameters[15].Value = model.Claim_Confirm;                        
            parameters[16].Value = model.ActivityOrderNo;                        
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
		public bool Delete(Guid Claim_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ClaimMoney ");
			strSql.Append(" where Claim_id=@Claim_id ");
						SqlParameter[] parameters = {
					new SqlParameter("@Claim_id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Claim_id;


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
		public bool DeleteList(string Claim_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ClaimMoney ");
			strSql.Append(" where Claim_id in ("+Claim_idlist + ")  ");
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
		public TravelAngecy.Model.ClaimMoney GetModel(Guid Claim_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Claim_id, Money_id, DepartmentId, Name_Claim, GroupNo, Salesperson, Guests, Methods, Amount, WorkId, ClaimTime, username, OrderNo, EntryTime, MoneyType, Claim_Confirm, ActivityOrderNo  ");			
			strSql.Append("  from ClaimMoney ");
			strSql.Append(" where Claim_id=@Claim_id ");
						SqlParameter[] parameters = {
					new SqlParameter("@Claim_id", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = Claim_id;

			
			TravelAngecy.Model.ClaimMoney model=new TravelAngecy.Model.ClaimMoney();
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
		public TravelAngecy.Model.ClaimMoney DataRowToModel(DataRow row)
		{
			TravelAngecy.Model.ClaimMoney model=new TravelAngecy.Model.ClaimMoney();
			if(row != null)
			{
																								if(row["Claim_id"]!=null && row["Claim_id"].ToString()!="")
				{
					model.Claim_id= new Guid(row["Claim_id"].ToString());
				}
																																if(row["Money_id"]!=null && row["Money_id"].ToString()!="")
				{
					model.Money_id= new Guid(row["Money_id"].ToString());
				}
																																if(row["DepartmentId"]!=null && row["DepartmentId"].ToString()!="")
				{
					model.DepartmentId= new Guid(row["DepartmentId"].ToString());
				}
																								if(row["Name_Claim"]!=null && row["Name_Claim"].ToString()!="")
				{
					model.Name_Claim= row["Name_Claim"].ToString();
				}
																																if(row["GroupNo"]!=null && row["GroupNo"].ToString()!="")
				{
					model.GroupNo= row["GroupNo"].ToString();
				}
																																if(row["Salesperson"]!=null && row["Salesperson"].ToString()!="")
				{
					model.Salesperson= row["Salesperson"].ToString();
				}
																																if(row["Guests"]!=null && row["Guests"].ToString()!="")
				{
					model.Guests= row["Guests"].ToString();
				}
																																if(row["Methods"]!=null && row["Methods"].ToString()!="")
				{
					model.Methods= row["Methods"].ToString();
				}
																												if(row["Amount"]!=null && row["Amount"].ToString()!="")
				{
					model.Amount=decimal.Parse(row["Amount"].ToString());
				}
																																				if(row["WorkId"]!=null && row["WorkId"].ToString()!="")
				{
					model.WorkId= row["WorkId"].ToString();
				}
																												if(row["ClaimTime"]!=null && row["ClaimTime"].ToString()!="")
				{
					model.ClaimTime=DateTime.Parse(row["ClaimTime"].ToString());
				}
																																				if(row["username"]!=null && row["username"].ToString()!="")
				{
					model.username= row["username"].ToString();
				}
																																if(row["OrderNo"]!=null && row["OrderNo"].ToString()!="")
				{
					model.OrderNo= row["OrderNo"].ToString();
				}
																												if(row["EntryTime"]!=null && row["EntryTime"].ToString()!="")
				{
					model.EntryTime=DateTime.Parse(row["EntryTime"].ToString());
				}
																																				if(row["MoneyType"]!=null && row["MoneyType"].ToString()!="")
				{
					model.MoneyType= row["MoneyType"].ToString();
				}
																																if(row["Claim_Confirm"]!=null && row["Claim_Confirm"].ToString()!="")
				{
					model.Claim_Confirm= row["Claim_Confirm"].ToString();
				}
																																if(row["ActivityOrderNo"]!=null && row["ActivityOrderNo"].ToString()!="")
				{
					model.ActivityOrderNo= row["ActivityOrderNo"].ToString();
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
			strSql.Append(" Claim_id, Money_id, DepartmentId, Name_Claim, GroupNo, Salesperson, Guests, Methods, Amount, WorkId, ClaimTime, username, OrderNo, EntryTime, MoneyType, Claim_Confirm, ActivityOrderNo  ");
			strSql.Append(" FROM ClaimMoney ");
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
			strSql.Append("select count(1) FROM ClaimMoney ");
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
			strSql.Append("select Claim_id, Money_id, DepartmentId, Name_Claim, GroupNo, Salesperson, Guests, Methods, Amount, WorkId, ClaimTime, username, OrderNo, EntryTime, MoneyType, Claim_Confirm, ActivityOrderNo  ");
			
			strSql.Append(" FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			strSql.Append(")AS Row, T.*  from ClaimMoney T ");
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

