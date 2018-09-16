using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace TravelAgency.DAL  
{
	 	//ActivityOrder
		public partial class ActivityOrder
	{
   		     
		public bool Exists(string ActivityOrderNo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ActivityOrder");
			strSql.Append(" where ");
			                                       strSql.Append(" ActivityOrderNo = @ActivityOrderNo  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@ActivityOrderNo", SqlDbType.VarChar,50)			};
			parameters[0].Value = ActivityOrderNo;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据,整形自增长返回id,guid返回parameters[0].Value,string返回true or false
		/// </summary>
		      public bool Add(TravelAgency.Model.ActivityOrder model)
				{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ActivityOrder(");			
            strSql.Append("ActivityOrderNo,ProductName,Type_T,Number,Books_Set,Books_Sum,BalanceBooks,Amount,EntryTime,AmountPayable,TailMoney,EntryTimePay,AmountPaid,CustomerName,Company,Mobile,Deposit,Price_Active,PayState,Type_Sale,ActivityName");
			strSql.Append(") values (");
            strSql.Append("@ActivityOrderNo,@ProductName,@Type_T,@Number,@Books_Set,@Books_Sum,@BalanceBooks,@Amount,@EntryTime,@AmountPayable,@TailMoney,@EntryTimePay,@AmountPaid,@CustomerName,@Company,@Mobile,@Deposit,@Price_Active,@PayState,@Type_Sale,@ActivityName");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@ActivityOrderNo", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ProductName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Type_T", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Number", SqlDbType.Int,4) ,            
                        new SqlParameter("@Books_Set", SqlDbType.Int,4) ,            
                        new SqlParameter("@Books_Sum", SqlDbType.Int,4) ,            
                        new SqlParameter("@BalanceBooks", SqlDbType.Int,4) ,            
                        new SqlParameter("@Amount", SqlDbType.Float,8) ,            
                        new SqlParameter("@EntryTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@AmountPayable", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@TailMoney", SqlDbType.Float,8) ,            
                        new SqlParameter("@EntryTimePay", SqlDbType.DateTime) ,            
                        new SqlParameter("@AmountPaid", SqlDbType.Float,8) ,            
                        new SqlParameter("@CustomerName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Company", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Mobile", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Deposit", SqlDbType.Float,8) ,            
                        new SqlParameter("@Price_Active", SqlDbType.Float,8) ,            
                        new SqlParameter("@PayState", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Type_Sale", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ActivityName", SqlDbType.VarChar,50)             
              
            };
			            
            parameters[0].Value = model.ActivityOrderNo;                        
            parameters[1].Value = model.ProductName;                        
            parameters[2].Value = model.Type_T;                        
            parameters[3].Value = model.Number;                        
            parameters[4].Value = model.Books_Set;                        
            parameters[5].Value = model.Books_Sum;                        
            parameters[6].Value = model.BalanceBooks;                        
            parameters[7].Value = model.Amount;                        
            parameters[8].Value = model.EntryTime;                        
            parameters[9].Value = model.AmountPayable;                        
            parameters[10].Value = model.TailMoney;                        
            parameters[11].Value = model.EntryTimePay;                        
            parameters[12].Value = model.AmountPaid;                        
            parameters[13].Value = model.CustomerName;                        
            parameters[14].Value = model.Company;                        
            parameters[15].Value = model.Mobile;                        
            parameters[16].Value = model.Deposit;                        
            parameters[17].Value = model.Price_Active;                        
            parameters[18].Value = model.PayState;                        
            parameters[19].Value = model.Type_Sale;                        
            parameters[20].Value = model.ActivityName;                        
			      int rows = DbHelperSQL.ExecuteSql(strSql.ToString(),parameters); 
      if(rows > 0)
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
		public bool Update(TravelAgency.Model.ActivityOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ActivityOrder set ");
			                        
            strSql.Append(" ActivityOrderNo = @ActivityOrderNo , ");                                    
            strSql.Append(" ProductName = @ProductName , ");                                    
            strSql.Append(" Type_T = @Type_T , ");                                    
            strSql.Append(" Number = @Number , ");                                    
            strSql.Append(" Books_Set = @Books_Set , ");                                    
            strSql.Append(" Books_Sum = @Books_Sum , ");                                    
            strSql.Append(" BalanceBooks = @BalanceBooks , ");                                    
            strSql.Append(" Amount = @Amount , ");                                    
            strSql.Append(" EntryTime = @EntryTime , ");                                    
            strSql.Append(" AmountPayable = @AmountPayable , ");                                    
            strSql.Append(" TailMoney = @TailMoney , ");                                    
            strSql.Append(" EntryTimePay = @EntryTimePay , ");                                    
            strSql.Append(" AmountPaid = @AmountPaid , ");                                    
            strSql.Append(" CustomerName = @CustomerName , ");                                    
            strSql.Append(" Company = @Company , ");                                    
            strSql.Append(" Mobile = @Mobile , ");                                    
            strSql.Append(" Deposit = @Deposit , ");                                    
            strSql.Append(" Price_Active = @Price_Active , ");                                    
            strSql.Append(" PayState = @PayState , ");                                    
            strSql.Append(" Type_Sale = @Type_Sale , ");                                    
            strSql.Append(" ActivityName = @ActivityName  ");            			
			strSql.Append(" where ActivityOrderNo=@ActivityOrderNo  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@ActivityOrderNo", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ProductName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Type_T", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Number", SqlDbType.Int,4) ,            
                        new SqlParameter("@Books_Set", SqlDbType.Int,4) ,            
                        new SqlParameter("@Books_Sum", SqlDbType.Int,4) ,            
                        new SqlParameter("@BalanceBooks", SqlDbType.Int,4) ,            
                        new SqlParameter("@Amount", SqlDbType.Float,8) ,            
                        new SqlParameter("@EntryTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@AmountPayable", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@TailMoney", SqlDbType.Float,8) ,            
                        new SqlParameter("@EntryTimePay", SqlDbType.DateTime) ,            
                        new SqlParameter("@AmountPaid", SqlDbType.Float,8) ,            
                        new SqlParameter("@CustomerName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Company", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Mobile", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Deposit", SqlDbType.Float,8) ,            
                        new SqlParameter("@Price_Active", SqlDbType.Float,8) ,            
                        new SqlParameter("@PayState", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Type_Sale", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ActivityName", SqlDbType.VarChar,50)             
              
            };
						            
            parameters[0].Value = model.ActivityOrderNo;                        
            parameters[1].Value = model.ProductName;                        
            parameters[2].Value = model.Type_T;                        
            parameters[3].Value = model.Number;                        
            parameters[4].Value = model.Books_Set;                        
            parameters[5].Value = model.Books_Sum;                        
            parameters[6].Value = model.BalanceBooks;                        
            parameters[7].Value = model.Amount;                        
            parameters[8].Value = model.EntryTime;                        
            parameters[9].Value = model.AmountPayable;                        
            parameters[10].Value = model.TailMoney;                        
            parameters[11].Value = model.EntryTimePay;                        
            parameters[12].Value = model.AmountPaid;                        
            parameters[13].Value = model.CustomerName;                        
            parameters[14].Value = model.Company;                        
            parameters[15].Value = model.Mobile;                        
            parameters[16].Value = model.Deposit;                        
            parameters[17].Value = model.Price_Active;                        
            parameters[18].Value = model.PayState;                        
            parameters[19].Value = model.Type_Sale;                        
            parameters[20].Value = model.ActivityName;                        
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
		public bool Delete(string ActivityOrderNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ActivityOrder ");
			strSql.Append(" where ActivityOrderNo=@ActivityOrderNo ");
						SqlParameter[] parameters = {
					new SqlParameter("@ActivityOrderNo", SqlDbType.VarChar,50)			};
			parameters[0].Value = ActivityOrderNo;


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
		public bool DeleteList(string ActivityOrderNolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ActivityOrder ");
			strSql.Append(" where ActivityOrderNo in ("+ActivityOrderNolist + ")  ");
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
		public TravelAgency.Model.ActivityOrder GetModel(string ActivityOrderNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ActivityOrderNo, ProductName, Type_T, Number, Books_Set, Books_Sum, BalanceBooks, Amount, EntryTime, AmountPayable, TailMoney, EntryTimePay, AmountPaid, CustomerName, Company, Mobile, Deposit, Price_Active, PayState, Type_Sale, ActivityName  ");			
			strSql.Append("  from ActivityOrder ");
			strSql.Append(" where ActivityOrderNo=@ActivityOrderNo ");
						SqlParameter[] parameters = {
					new SqlParameter("@ActivityOrderNo", SqlDbType.VarChar,50)			};
			parameters[0].Value = ActivityOrderNo;

			
			TravelAgency.Model.ActivityOrder model=new TravelAgency.Model.ActivityOrder();
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
		public TravelAgency.Model.ActivityOrder DataRowToModel(DataRow row)
		{
			TravelAgency.Model.ActivityOrder model=new TravelAgency.Model.ActivityOrder();
			if(row != null)
			{
																if(row["ActivityOrderNo"]!=null && row["ActivityOrderNo"].ToString()!="")
				{
					model.ActivityOrderNo= row["ActivityOrderNo"].ToString();
				}
																																if(row["ProductName"]!=null && row["ProductName"].ToString()!="")
				{
					model.ProductName= row["ProductName"].ToString();
				}
																																if(row["Type_T"]!=null && row["Type_T"].ToString()!="")
				{
					model.Type_T= row["Type_T"].ToString();
				}
																												if(row["Number"]!=null && row["Number"].ToString()!="")
				{
					model.Number=int.Parse(row["Number"].ToString());
				}
																																if(row["Books_Set"]!=null && row["Books_Set"].ToString()!="")
				{
					model.Books_Set=int.Parse(row["Books_Set"].ToString());
				}
																																if(row["Books_Sum"]!=null && row["Books_Sum"].ToString()!="")
				{
					model.Books_Sum=int.Parse(row["Books_Sum"].ToString());
				}
																																if(row["BalanceBooks"]!=null && row["BalanceBooks"].ToString()!="")
				{
					model.BalanceBooks=int.Parse(row["BalanceBooks"].ToString());
				}
																																if(row["Amount"]!=null && row["Amount"].ToString()!="")
				{
					model.Amount=decimal.Parse(row["Amount"].ToString());
				}
																																if(row["EntryTime"]!=null && row["EntryTime"].ToString()!="")
				{
					model.EntryTime=DateTime.Parse(row["EntryTime"].ToString());
				}
																																				if(row["AmountPayable"]!=null && row["AmountPayable"].ToString()!="")
				{
					model.AmountPayable= row["AmountPayable"].ToString();
				}
																												if(row["TailMoney"]!=null && row["TailMoney"].ToString()!="")
				{
					model.TailMoney=decimal.Parse(row["TailMoney"].ToString());
				}
																																if(row["EntryTimePay"]!=null && row["EntryTimePay"].ToString()!="")
				{
					model.EntryTimePay=DateTime.Parse(row["EntryTimePay"].ToString());
				}
																																if(row["AmountPaid"]!=null && row["AmountPaid"].ToString()!="")
				{
					model.AmountPaid=decimal.Parse(row["AmountPaid"].ToString());
				}
																																				if(row["CustomerName"]!=null && row["CustomerName"].ToString()!="")
				{
					model.CustomerName= row["CustomerName"].ToString();
				}
																																if(row["Company"]!=null && row["Company"].ToString()!="")
				{
					model.Company= row["Company"].ToString();
				}
																																if(row["Mobile"]!=null && row["Mobile"].ToString()!="")
				{
					model.Mobile= row["Mobile"].ToString();
				}
																												if(row["Deposit"]!=null && row["Deposit"].ToString()!="")
				{
					model.Deposit=decimal.Parse(row["Deposit"].ToString());
				}
																																if(row["Price_Active"]!=null && row["Price_Active"].ToString()!="")
				{
					model.Price_Active=decimal.Parse(row["Price_Active"].ToString());
				}
																																				if(row["PayState"]!=null && row["PayState"].ToString()!="")
				{
					model.PayState= row["PayState"].ToString();
				}
																																if(row["Type_Sale"]!=null && row["Type_Sale"].ToString()!="")
				{
					model.Type_Sale= row["Type_Sale"].ToString();
				}
																																if(row["ActivityName"]!=null && row["ActivityName"].ToString()!="")
				{
					model.ActivityName= row["ActivityName"].ToString();
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
			strSql.Append(" ActivityOrderNo, ProductName, Type_T, Number, Books_Set, Books_Sum, BalanceBooks, Amount, EntryTime, AmountPayable, TailMoney, EntryTimePay, AmountPaid, CustomerName, Company, Mobile, Deposit, Price_Active, PayState, Type_Sale, ActivityName  ");
			strSql.Append(" FROM ActivityOrder ");
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
			strSql.Append("select count(1) FROM ActivityOrder ");
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
			strSql.Append("select ActivityOrderNo, ProductName, Type_T, Number, Books_Set, Books_Sum, BalanceBooks, Amount, EntryTime, AmountPayable, TailMoney, EntryTimePay, AmountPaid, CustomerName, Company, Mobile, Deposit, Price_Active, PayState, Type_Sale, ActivityName  ");
			
			strSql.Append(" FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			strSql.Append(")AS Row, T.*  from ActivityOrder T ");
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

