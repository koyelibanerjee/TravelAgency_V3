using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace TravelAgency.DAL  
{
	 	//Orders
		public partial class Orders
	{
   		     
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Orders");
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
		      public int Add(TravelAgency.Model.Orders model)
				{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Orders(");			
            strSql.Append("OrderNo,PaymentPlatform,GroupNo,ProductName,ProductId,ProductType,PurchaseNum,OrderAmount,ReallyPay,PlatformActivity,GuestOrderTime,WaitorOrderTime,WaitorConfirmTime,ReserveTime,DiningTime,DiningShop,CheckMoneyTime,RefundAmout,GuestRefundApplyTime,WaitorRefundApplyTime,WaitorName,IsPraise,RefundReason,WaitorRemark,JpOrderNo,OrderWay,OperOrderTime,JpConfirmTime,ReplyWaitorConfirmTime,ReplyResult,SettlePrice,ExchangeRate,OperRemark,RealIntoAccountTime,TyperName,Commission,WaitorCommision,AdminRemark,OperName,GuestInfoTypedIn,MoneyType,ComboName,DepartureDate,GuestUseTime,OrderState");
			strSql.Append(") values (");
            strSql.Append("@OrderNo,@PaymentPlatform,@GroupNo,@ProductName,@ProductId,@ProductType,@PurchaseNum,@OrderAmount,@ReallyPay,@PlatformActivity,@GuestOrderTime,@WaitorOrderTime,@WaitorConfirmTime,@ReserveTime,@DiningTime,@DiningShop,@CheckMoneyTime,@RefundAmout,@GuestRefundApplyTime,@WaitorRefundApplyTime,@WaitorName,@IsPraise,@RefundReason,@WaitorRemark,@JpOrderNo,@OrderWay,@OperOrderTime,@JpConfirmTime,@ReplyWaitorConfirmTime,@ReplyResult,@SettlePrice,@ExchangeRate,@OperRemark,@RealIntoAccountTime,@TyperName,@Commission,@WaitorCommision,@AdminRemark,@OperName,@GuestInfoTypedIn,@MoneyType,@ComboName,@DepartureDate,@GuestUseTime,@OrderState");            
            strSql.Append(") ");            
            strSql.Append(";select @@IDENTITY");		
			SqlParameter[] parameters = {
			            new SqlParameter("@OrderNo", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@PaymentPlatform", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@GroupNo", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@ProductName", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@ProductId", SqlDbType.Int,4) ,            
                        new SqlParameter("@ProductType", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@PurchaseNum", SqlDbType.Int,4) ,            
                        new SqlParameter("@OrderAmount", SqlDbType.Money,8) ,            
                        new SqlParameter("@ReallyPay", SqlDbType.Money,8) ,            
                        new SqlParameter("@PlatformActivity", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@GuestOrderTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@WaitorOrderTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@WaitorConfirmTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ReserveTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@DiningTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@DiningShop", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@CheckMoneyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@RefundAmout", SqlDbType.Money,8) ,            
                        new SqlParameter("@GuestRefundApplyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@WaitorRefundApplyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@WaitorName", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@IsPraise", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@RefundReason", SqlDbType.Text) ,            
                        new SqlParameter("@WaitorRemark", SqlDbType.Text) ,            
                        new SqlParameter("@JpOrderNo", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@OrderWay", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@OperOrderTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@JpConfirmTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ReplyWaitorConfirmTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ReplyResult", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@SettlePrice", SqlDbType.Money,8) ,            
                        new SqlParameter("@ExchangeRate", SqlDbType.Money,8) ,            
                        new SqlParameter("@OperRemark", SqlDbType.Text) ,            
                        new SqlParameter("@RealIntoAccountTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@TyperName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Commission", SqlDbType.Money,8) ,            
                        new SqlParameter("@WaitorCommision", SqlDbType.Money,8) ,            
                        new SqlParameter("@AdminRemark", SqlDbType.Text) ,            
                        new SqlParameter("@OperName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GuestInfoTypedIn", SqlDbType.Bit,1) ,            
                        new SqlParameter("@MoneyType", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@ComboName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@DepartureDate", SqlDbType.DateTime,3) ,            
                        new SqlParameter("@GuestUseTime", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@OrderState", SqlDbType.VarChar,20)             
              
            };
			            
            parameters[0].Value = model.OrderNo;                        
            parameters[1].Value = model.PaymentPlatform;                        
            parameters[2].Value = model.GroupNo;                        
            parameters[3].Value = model.ProductName;                        
            parameters[4].Value = model.ProductId;                        
            parameters[5].Value = model.ProductType;                        
            parameters[6].Value = model.PurchaseNum;                        
            parameters[7].Value = model.OrderAmount;                        
            parameters[8].Value = model.ReallyPay;                        
            parameters[9].Value = model.PlatformActivity;                        
            parameters[10].Value = model.GuestOrderTime;                        
            parameters[11].Value = model.WaitorOrderTime;                        
            parameters[12].Value = model.WaitorConfirmTime;                        
            parameters[13].Value = model.ReserveTime;                        
            parameters[14].Value = model.DiningTime;                        
            parameters[15].Value = model.DiningShop;                        
            parameters[16].Value = model.CheckMoneyTime;                        
            parameters[17].Value = model.RefundAmout;                        
            parameters[18].Value = model.GuestRefundApplyTime;                        
            parameters[19].Value = model.WaitorRefundApplyTime;                        
            parameters[20].Value = model.WaitorName;                        
            parameters[21].Value = model.IsPraise;                        
            parameters[22].Value = model.RefundReason;                        
            parameters[23].Value = model.WaitorRemark;                        
            parameters[24].Value = model.JpOrderNo;                        
            parameters[25].Value = model.OrderWay;                        
            parameters[26].Value = model.OperOrderTime;                        
            parameters[27].Value = model.JpConfirmTime;                        
            parameters[28].Value = model.ReplyWaitorConfirmTime;                        
            parameters[29].Value = model.ReplyResult;                        
            parameters[30].Value = model.SettlePrice;                        
            parameters[31].Value = model.ExchangeRate;                        
            parameters[32].Value = model.OperRemark;                        
            parameters[33].Value = model.RealIntoAccountTime;                        
            parameters[34].Value = model.TyperName;                        
            parameters[35].Value = model.Commission;                        
            parameters[36].Value = model.WaitorCommision;                        
            parameters[37].Value = model.AdminRemark;                        
            parameters[38].Value = model.OperName;                        
            parameters[39].Value = model.GuestInfoTypedIn;                        
            parameters[40].Value = model.MoneyType;                        
            parameters[41].Value = model.ComboName;                        
            parameters[42].Value = model.DepartureDate;                        
            parameters[43].Value = model.GuestUseTime;                        
            parameters[44].Value = model.OrderState;                        
			   
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
		public bool Update(TravelAgency.Model.Orders model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Orders set ");
			                                                
            strSql.Append(" OrderNo = @OrderNo , ");                                    
            strSql.Append(" PaymentPlatform = @PaymentPlatform , ");                                    
            strSql.Append(" GroupNo = @GroupNo , ");                                    
            strSql.Append(" ProductName = @ProductName , ");                                    
            strSql.Append(" ProductId = @ProductId , ");                                    
            strSql.Append(" ProductType = @ProductType , ");                                    
            strSql.Append(" PurchaseNum = @PurchaseNum , ");                                    
            strSql.Append(" OrderAmount = @OrderAmount , ");                                    
            strSql.Append(" ReallyPay = @ReallyPay , ");                                    
            strSql.Append(" PlatformActivity = @PlatformActivity , ");                                    
            strSql.Append(" GuestOrderTime = @GuestOrderTime , ");                                    
            strSql.Append(" WaitorOrderTime = @WaitorOrderTime , ");                                    
            strSql.Append(" WaitorConfirmTime = @WaitorConfirmTime , ");                                    
            strSql.Append(" ReserveTime = @ReserveTime , ");                                    
            strSql.Append(" DiningTime = @DiningTime , ");                                    
            strSql.Append(" DiningShop = @DiningShop , ");                                    
            strSql.Append(" CheckMoneyTime = @CheckMoneyTime , ");                                    
            strSql.Append(" RefundAmout = @RefundAmout , ");                                    
            strSql.Append(" GuestRefundApplyTime = @GuestRefundApplyTime , ");                                    
            strSql.Append(" WaitorRefundApplyTime = @WaitorRefundApplyTime , ");                                    
            strSql.Append(" WaitorName = @WaitorName , ");                                    
            strSql.Append(" IsPraise = @IsPraise , ");                                    
            strSql.Append(" RefundReason = @RefundReason , ");                                    
            strSql.Append(" WaitorRemark = @WaitorRemark , ");                                    
            strSql.Append(" JpOrderNo = @JpOrderNo , ");                                    
            strSql.Append(" OrderWay = @OrderWay , ");                                    
            strSql.Append(" OperOrderTime = @OperOrderTime , ");                                    
            strSql.Append(" JpConfirmTime = @JpConfirmTime , ");                                    
            strSql.Append(" ReplyWaitorConfirmTime = @ReplyWaitorConfirmTime , ");                                    
            strSql.Append(" ReplyResult = @ReplyResult , ");                                    
            strSql.Append(" SettlePrice = @SettlePrice , ");                                    
            strSql.Append(" ExchangeRate = @ExchangeRate , ");                                    
            strSql.Append(" OperRemark = @OperRemark , ");                                    
            strSql.Append(" RealIntoAccountTime = @RealIntoAccountTime , ");                                    
            strSql.Append(" TyperName = @TyperName , ");                                    
            strSql.Append(" Commission = @Commission , ");                                    
            strSql.Append(" WaitorCommision = @WaitorCommision , ");                                    
            strSql.Append(" AdminRemark = @AdminRemark , ");                                    
            strSql.Append(" OperName = @OperName , ");                                    
            strSql.Append(" GuestInfoTypedIn = @GuestInfoTypedIn , ");                                    
            strSql.Append(" MoneyType = @MoneyType , ");                                    
            strSql.Append(" ComboName = @ComboName , ");                                    
            strSql.Append(" DepartureDate = @DepartureDate , ");                                    
            strSql.Append(" GuestUseTime = @GuestUseTime , ");                                    
            strSql.Append(" OrderState = @OrderState  ");            			
			strSql.Append(" where Id=@Id ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@OrderNo", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@PaymentPlatform", SqlDbType.TinyInt,1) ,            
                        new SqlParameter("@GroupNo", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@ProductName", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@ProductId", SqlDbType.Int,4) ,            
                        new SqlParameter("@ProductType", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@PurchaseNum", SqlDbType.Int,4) ,            
                        new SqlParameter("@OrderAmount", SqlDbType.Money,8) ,            
                        new SqlParameter("@ReallyPay", SqlDbType.Money,8) ,            
                        new SqlParameter("@PlatformActivity", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@GuestOrderTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@WaitorOrderTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@WaitorConfirmTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ReserveTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@DiningTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@DiningShop", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@CheckMoneyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@RefundAmout", SqlDbType.Money,8) ,            
                        new SqlParameter("@GuestRefundApplyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@WaitorRefundApplyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@WaitorName", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@IsPraise", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@RefundReason", SqlDbType.Text) ,            
                        new SqlParameter("@WaitorRemark", SqlDbType.Text) ,            
                        new SqlParameter("@JpOrderNo", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@OrderWay", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@OperOrderTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@JpConfirmTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ReplyWaitorConfirmTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ReplyResult", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@SettlePrice", SqlDbType.Money,8) ,            
                        new SqlParameter("@ExchangeRate", SqlDbType.Money,8) ,            
                        new SqlParameter("@OperRemark", SqlDbType.Text) ,            
                        new SqlParameter("@RealIntoAccountTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@TyperName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@Commission", SqlDbType.Money,8) ,            
                        new SqlParameter("@WaitorCommision", SqlDbType.Money,8) ,            
                        new SqlParameter("@AdminRemark", SqlDbType.Text) ,            
                        new SqlParameter("@OperName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GuestInfoTypedIn", SqlDbType.Bit,1) ,            
                        new SqlParameter("@MoneyType", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@ComboName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@DepartureDate", SqlDbType.DateTime,3) ,            
                        new SqlParameter("@GuestUseTime", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@OrderState", SqlDbType.VarChar,20)             
              
            };
						            
            parameters[0].Value = model.Id;                        
            parameters[1].Value = model.OrderNo;                        
            parameters[2].Value = model.PaymentPlatform;                        
            parameters[3].Value = model.GroupNo;                        
            parameters[4].Value = model.ProductName;                        
            parameters[5].Value = model.ProductId;                        
            parameters[6].Value = model.ProductType;                        
            parameters[7].Value = model.PurchaseNum;                        
            parameters[8].Value = model.OrderAmount;                        
            parameters[9].Value = model.ReallyPay;                        
            parameters[10].Value = model.PlatformActivity;                        
            parameters[11].Value = model.GuestOrderTime;                        
            parameters[12].Value = model.WaitorOrderTime;                        
            parameters[13].Value = model.WaitorConfirmTime;                        
            parameters[14].Value = model.ReserveTime;                        
            parameters[15].Value = model.DiningTime;                        
            parameters[16].Value = model.DiningShop;                        
            parameters[17].Value = model.CheckMoneyTime;                        
            parameters[18].Value = model.RefundAmout;                        
            parameters[19].Value = model.GuestRefundApplyTime;                        
            parameters[20].Value = model.WaitorRefundApplyTime;                        
            parameters[21].Value = model.WaitorName;                        
            parameters[22].Value = model.IsPraise;                        
            parameters[23].Value = model.RefundReason;                        
            parameters[24].Value = model.WaitorRemark;                        
            parameters[25].Value = model.JpOrderNo;                        
            parameters[26].Value = model.OrderWay;                        
            parameters[27].Value = model.OperOrderTime;                        
            parameters[28].Value = model.JpConfirmTime;                        
            parameters[29].Value = model.ReplyWaitorConfirmTime;                        
            parameters[30].Value = model.ReplyResult;                        
            parameters[31].Value = model.SettlePrice;                        
            parameters[32].Value = model.ExchangeRate;                        
            parameters[33].Value = model.OperRemark;                        
            parameters[34].Value = model.RealIntoAccountTime;                        
            parameters[35].Value = model.TyperName;                        
            parameters[36].Value = model.Commission;                        
            parameters[37].Value = model.WaitorCommision;                        
            parameters[38].Value = model.AdminRemark;                        
            parameters[39].Value = model.OperName;                        
            parameters[40].Value = model.GuestInfoTypedIn;                        
            parameters[41].Value = model.MoneyType;                        
            parameters[42].Value = model.ComboName;                        
            parameters[43].Value = model.DepartureDate;                        
            parameters[44].Value = model.GuestUseTime;                        
            parameters[45].Value = model.OrderState;                        
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
			strSql.Append("delete from Orders ");
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
			strSql.Append("delete from Orders ");
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
		public TravelAgency.Model.Orders GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id, OrderNo, PaymentPlatform, GroupNo, ProductName, ProductId, ProductType, PurchaseNum, OrderAmount, ReallyPay, PlatformActivity, GuestOrderTime, WaitorOrderTime, WaitorConfirmTime, ReserveTime, DiningTime, DiningShop, CheckMoneyTime, RefundAmout, GuestRefundApplyTime, WaitorRefundApplyTime, WaitorName, IsPraise, RefundReason, WaitorRemark, JpOrderNo, OrderWay, OperOrderTime, JpConfirmTime, ReplyWaitorConfirmTime, ReplyResult, SettlePrice, ExchangeRate, OperRemark, RealIntoAccountTime, TyperName, Commission, WaitorCommision, AdminRemark, OperName, GuestInfoTypedIn, MoneyType, ComboName, DepartureDate, GuestUseTime, OrderState  ");			
			strSql.Append("  from Orders ");
			strSql.Append(" where Id=@Id");
						SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			
			TravelAgency.Model.Orders model=new TravelAgency.Model.Orders();
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
		public TravelAgency.Model.Orders DataRowToModel(DataRow row)
		{
			TravelAgency.Model.Orders model=new TravelAgency.Model.Orders();
			if(row != null)
			{
												if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
																																				if(row["OrderNo"]!=null && row["OrderNo"].ToString()!="")
				{
					model.OrderNo= row["OrderNo"].ToString();
				}
																												if(row["PaymentPlatform"]!=null && row["PaymentPlatform"].ToString()!="")
				{
					model.PaymentPlatform=int.Parse(row["PaymentPlatform"].ToString());
				}
																																				if(row["GroupNo"]!=null && row["GroupNo"].ToString()!="")
				{
					model.GroupNo= row["GroupNo"].ToString();
				}
																																if(row["ProductName"]!=null && row["ProductName"].ToString()!="")
				{
					model.ProductName= row["ProductName"].ToString();
				}
																												if(row["ProductId"]!=null && row["ProductId"].ToString()!="")
				{
					model.ProductId=int.Parse(row["ProductId"].ToString());
				}
																																				if(row["ProductType"]!=null && row["ProductType"].ToString()!="")
				{
					model.ProductType= row["ProductType"].ToString();
				}
																												if(row["PurchaseNum"]!=null && row["PurchaseNum"].ToString()!="")
				{
					model.PurchaseNum=int.Parse(row["PurchaseNum"].ToString());
				}
																																if(row["OrderAmount"]!=null && row["OrderAmount"].ToString()!="")
				{
					model.OrderAmount=decimal.Parse(row["OrderAmount"].ToString());
				}
																																if(row["ReallyPay"]!=null && row["ReallyPay"].ToString()!="")
				{
					model.ReallyPay=decimal.Parse(row["ReallyPay"].ToString());
				}
																																				if(row["PlatformActivity"]!=null && row["PlatformActivity"].ToString()!="")
				{
					model.PlatformActivity= row["PlatformActivity"].ToString();
				}
																												if(row["GuestOrderTime"]!=null && row["GuestOrderTime"].ToString()!="")
				{
					model.GuestOrderTime=DateTime.Parse(row["GuestOrderTime"].ToString());
				}
																																if(row["WaitorOrderTime"]!=null && row["WaitorOrderTime"].ToString()!="")
				{
					model.WaitorOrderTime=DateTime.Parse(row["WaitorOrderTime"].ToString());
				}
																																if(row["WaitorConfirmTime"]!=null && row["WaitorConfirmTime"].ToString()!="")
				{
					model.WaitorConfirmTime=DateTime.Parse(row["WaitorConfirmTime"].ToString());
				}
																																if(row["ReserveTime"]!=null && row["ReserveTime"].ToString()!="")
				{
					model.ReserveTime=DateTime.Parse(row["ReserveTime"].ToString());
				}
																																if(row["DiningTime"]!=null && row["DiningTime"].ToString()!="")
				{
					model.DiningTime=DateTime.Parse(row["DiningTime"].ToString());
				}
																																				if(row["DiningShop"]!=null && row["DiningShop"].ToString()!="")
				{
					model.DiningShop= row["DiningShop"].ToString();
				}
																												if(row["CheckMoneyTime"]!=null && row["CheckMoneyTime"].ToString()!="")
				{
					model.CheckMoneyTime=DateTime.Parse(row["CheckMoneyTime"].ToString());
				}
																																if(row["RefundAmout"]!=null && row["RefundAmout"].ToString()!="")
				{
					model.RefundAmout=decimal.Parse(row["RefundAmout"].ToString());
				}
																																if(row["GuestRefundApplyTime"]!=null && row["GuestRefundApplyTime"].ToString()!="")
				{
					model.GuestRefundApplyTime=DateTime.Parse(row["GuestRefundApplyTime"].ToString());
				}
																																if(row["WaitorRefundApplyTime"]!=null && row["WaitorRefundApplyTime"].ToString()!="")
				{
					model.WaitorRefundApplyTime=DateTime.Parse(row["WaitorRefundApplyTime"].ToString());
				}
																																				if(row["WaitorName"]!=null && row["WaitorName"].ToString()!="")
				{
					model.WaitorName= row["WaitorName"].ToString();
				}
																																if(row["IsPraise"]!=null && row["IsPraise"].ToString()!="")
				{
					model.IsPraise= row["IsPraise"].ToString();
				}
																																if(row["RefundReason"]!=null && row["RefundReason"].ToString()!="")
				{
					model.RefundReason= row["RefundReason"].ToString();
				}
																																if(row["WaitorRemark"]!=null && row["WaitorRemark"].ToString()!="")
				{
					model.WaitorRemark= row["WaitorRemark"].ToString();
				}
																																if(row["JpOrderNo"]!=null && row["JpOrderNo"].ToString()!="")
				{
					model.JpOrderNo= row["JpOrderNo"].ToString();
				}
																																if(row["OrderWay"]!=null && row["OrderWay"].ToString()!="")
				{
					model.OrderWay= row["OrderWay"].ToString();
				}
																												if(row["OperOrderTime"]!=null && row["OperOrderTime"].ToString()!="")
				{
					model.OperOrderTime=DateTime.Parse(row["OperOrderTime"].ToString());
				}
																																if(row["JpConfirmTime"]!=null && row["JpConfirmTime"].ToString()!="")
				{
					model.JpConfirmTime=DateTime.Parse(row["JpConfirmTime"].ToString());
				}
																																if(row["ReplyWaitorConfirmTime"]!=null && row["ReplyWaitorConfirmTime"].ToString()!="")
				{
					model.ReplyWaitorConfirmTime=DateTime.Parse(row["ReplyWaitorConfirmTime"].ToString());
				}
																																				if(row["ReplyResult"]!=null && row["ReplyResult"].ToString()!="")
				{
					model.ReplyResult= row["ReplyResult"].ToString();
				}
																												if(row["SettlePrice"]!=null && row["SettlePrice"].ToString()!="")
				{
					model.SettlePrice=decimal.Parse(row["SettlePrice"].ToString());
				}
																																if(row["ExchangeRate"]!=null && row["ExchangeRate"].ToString()!="")
				{
					model.ExchangeRate=decimal.Parse(row["ExchangeRate"].ToString());
				}
																																				if(row["OperRemark"]!=null && row["OperRemark"].ToString()!="")
				{
					model.OperRemark= row["OperRemark"].ToString();
				}
																												if(row["RealIntoAccountTime"]!=null && row["RealIntoAccountTime"].ToString()!="")
				{
					model.RealIntoAccountTime=DateTime.Parse(row["RealIntoAccountTime"].ToString());
				}
																																				if(row["TyperName"]!=null && row["TyperName"].ToString()!="")
				{
					model.TyperName= row["TyperName"].ToString();
				}
																												if(row["Commission"]!=null && row["Commission"].ToString()!="")
				{
					model.Commission=decimal.Parse(row["Commission"].ToString());
				}
																																if(row["WaitorCommision"]!=null && row["WaitorCommision"].ToString()!="")
				{
					model.WaitorCommision=decimal.Parse(row["WaitorCommision"].ToString());
				}
																																				if(row["AdminRemark"]!=null && row["AdminRemark"].ToString()!="")
				{
					model.AdminRemark= row["AdminRemark"].ToString();
				}
																																if(row["OperName"]!=null && row["OperName"].ToString()!="")
				{
					model.OperName= row["OperName"].ToString();
				}
																																												if(row["GuestInfoTypedIn"]!=null && row["GuestInfoTypedIn"].ToString()!="")
				{
					if((row["GuestInfoTypedIn"].ToString()=="1")||(row["GuestInfoTypedIn"].ToString().ToLower()=="true"))
					{
					model.GuestInfoTypedIn= true;
					}
					else
					{
					model.GuestInfoTypedIn= false;
					}
				}
																				if(row["MoneyType"]!=null && row["MoneyType"].ToString()!="")
				{
					model.MoneyType= row["MoneyType"].ToString();
				}
																																if(row["ComboName"]!=null && row["ComboName"].ToString()!="")
				{
					model.ComboName= row["ComboName"].ToString();
				}
																												if(row["DepartureDate"]!=null && row["DepartureDate"].ToString()!="")
				{
					model.DepartureDate=DateTime.Parse(row["DepartureDate"].ToString());
				}
																																				if(row["GuestUseTime"]!=null && row["GuestUseTime"].ToString()!="")
				{
					model.GuestUseTime= row["GuestUseTime"].ToString();
				}
																																if(row["OrderState"]!=null && row["OrderState"].ToString()!="")
				{
					model.OrderState= row["OrderState"].ToString();
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
			strSql.Append(" Id, OrderNo, PaymentPlatform, GroupNo, ProductName, ProductId, ProductType, PurchaseNum, OrderAmount, ReallyPay, PlatformActivity, GuestOrderTime, WaitorOrderTime, WaitorConfirmTime, ReserveTime, DiningTime, DiningShop, CheckMoneyTime, RefundAmout, GuestRefundApplyTime, WaitorRefundApplyTime, WaitorName, IsPraise, RefundReason, WaitorRemark, JpOrderNo, OrderWay, OperOrderTime, JpConfirmTime, ReplyWaitorConfirmTime, ReplyResult, SettlePrice, ExchangeRate, OperRemark, RealIntoAccountTime, TyperName, Commission, WaitorCommision, AdminRemark, OperName, GuestInfoTypedIn, MoneyType, ComboName, DepartureDate, GuestUseTime, OrderState  ");
			strSql.Append(" FROM Orders ");
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
			strSql.Append("select count(1) FROM Orders ");
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
			strSql.Append("select Id, OrderNo, PaymentPlatform, GroupNo, ProductName, ProductId, ProductType, PurchaseNum, OrderAmount, ReallyPay, PlatformActivity, GuestOrderTime, WaitorOrderTime, WaitorConfirmTime, ReserveTime, DiningTime, DiningShop, CheckMoneyTime, RefundAmout, GuestRefundApplyTime, WaitorRefundApplyTime, WaitorName, IsPraise, RefundReason, WaitorRemark, JpOrderNo, OrderWay, OperOrderTime, JpConfirmTime, ReplyWaitorConfirmTime, ReplyResult, SettlePrice, ExchangeRate, OperRemark, RealIntoAccountTime, TyperName, Commission, WaitorCommision, AdminRemark, OperName, GuestInfoTypedIn, MoneyType, ComboName, DepartureDate, GuestUseTime, OrderState  ");
			
			strSql.Append(" FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			strSql.Append(")AS Row, T.*  from Orders T ");
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

