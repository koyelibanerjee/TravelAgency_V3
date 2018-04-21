using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
	/// <summary>
	/// 数据访问类:Orders
	/// </summary>
	public partial class Orders
	{
		public Orders()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "Orders"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Orders");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TravelAgency.Model.Orders model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Orders(");
			strSql.Append("OrderNo,PaymentPlatform,GroupNo,ProductName,ProductId,ProductType,GuestId,GuestName,GuestNamePinYin,GuestSex,GuestBirthday,GuestUseTime,GuestPhone,GuestWeiChat,GuestEMail,GuestPassportNo,GuestLastNightHotel,GuestCountry,PurchaseNum,OrderAmount,ReallyPay,PlatformActivity,GuestOrderTime,WaitorOrderTime,WaitorConfirmTime,ReserveTime,DiningTime,DiningShop,CheckMoneyTime,RefundAmout,GuestRefundApplyTime,WaitorRefundApplyTime,WaitorName,IsPraise,RefundReason,WaitorRemark,JpOrderNo,OrderWay,OperOrderTime,JpConfirmTime,ReplyWaitorConfirmTime,ReplyResult,SettlePrice,ExchangeRate,OperRemark,RealIntoAccountTime,TyperName,Commission,WaitorCommision,AdminRemark)");
			strSql.Append(" values (");
			strSql.Append("@OrderNo,@PaymentPlatform,@GroupNo,@ProductName,@ProductId,@ProductType,@GuestId,@GuestName,@GuestNamePinYin,@GuestSex,@GuestBirthday,@GuestUseTime,@GuestPhone,@GuestWeiChat,@GuestEMail,@GuestPassportNo,@GuestLastNightHotel,@GuestCountry,@PurchaseNum,@OrderAmount,@ReallyPay,@PlatformActivity,@GuestOrderTime,@WaitorOrderTime,@WaitorConfirmTime,@ReserveTime,@DiningTime,@DiningShop,@CheckMoneyTime,@RefundAmout,@GuestRefundApplyTime,@WaitorRefundApplyTime,@WaitorName,@IsPraise,@RefundReason,@WaitorRemark,@JpOrderNo,@OrderWay,@OperOrderTime,@JpConfirmTime,@ReplyWaitorConfirmTime,@ReplyResult,@SettlePrice,@ExchangeRate,@OperRemark,@RealIntoAccountTime,@TyperName,@Commission,@WaitorCommision,@AdminRemark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.VarChar,50),
					new SqlParameter("@PaymentPlatform", SqlDbType.TinyInt,1),
					new SqlParameter("@GroupNo", SqlDbType.VarChar,500),
					new SqlParameter("@ProductName", SqlDbType.VarChar,200),
					new SqlParameter("@ProductId", SqlDbType.Int,4),
					new SqlParameter("@ProductType", SqlDbType.VarChar,50),
					new SqlParameter("@GuestId", SqlDbType.Int,4),
					new SqlParameter("@GuestName", SqlDbType.VarChar,20),
					new SqlParameter("@GuestNamePinYin", SqlDbType.VarChar,50),
					new SqlParameter("@GuestSex", SqlDbType.VarChar,10),
					new SqlParameter("@GuestBirthday", SqlDbType.DateTime,3),
					new SqlParameter("@GuestUseTime", SqlDbType.Int,4),
					new SqlParameter("@GuestPhone", SqlDbType.VarChar,20),
					new SqlParameter("@GuestWeiChat", SqlDbType.VarChar,50),
					new SqlParameter("@GuestEMail", SqlDbType.VarChar,50),
					new SqlParameter("@GuestPassportNo", SqlDbType.VarChar,30),
					new SqlParameter("@GuestLastNightHotel", SqlDbType.VarChar,50),
					new SqlParameter("@GuestCountry", SqlDbType.VarChar,10),
					new SqlParameter("@PurchaseNum", SqlDbType.Int,4),
					new SqlParameter("@OrderAmount", SqlDbType.Money,8),
					new SqlParameter("@ReallyPay", SqlDbType.Money,8),
					new SqlParameter("@PlatformActivity", SqlDbType.VarChar,100),
					new SqlParameter("@GuestOrderTime", SqlDbType.DateTime),
					new SqlParameter("@WaitorOrderTime", SqlDbType.DateTime),
					new SqlParameter("@WaitorConfirmTime", SqlDbType.DateTime),
					new SqlParameter("@ReserveTime", SqlDbType.Int,4),
					new SqlParameter("@DiningTime", SqlDbType.DateTime),
					new SqlParameter("@DiningShop", SqlDbType.VarChar,50),
					new SqlParameter("@CheckMoneyTime", SqlDbType.DateTime),
					new SqlParameter("@RefundAmout", SqlDbType.Money,8),
					new SqlParameter("@GuestRefundApplyTime", SqlDbType.DateTime),
					new SqlParameter("@WaitorRefundApplyTime", SqlDbType.DateTime),
					new SqlParameter("@WaitorName", SqlDbType.VarChar,20),
					new SqlParameter("@IsPraise", SqlDbType.VarChar,10),
					new SqlParameter("@RefundReason", SqlDbType.Text),
					new SqlParameter("@WaitorRemark", SqlDbType.Text),
					new SqlParameter("@JpOrderNo", SqlDbType.VarChar,50),
					new SqlParameter("@OrderWay", SqlDbType.VarChar,50),
					new SqlParameter("@OperOrderTime", SqlDbType.DateTime),
					new SqlParameter("@JpConfirmTime", SqlDbType.DateTime),
					new SqlParameter("@ReplyWaitorConfirmTime", SqlDbType.DateTime),
					new SqlParameter("@ReplyResult", SqlDbType.VarChar,20),
					new SqlParameter("@SettlePrice", SqlDbType.Money,8),
					new SqlParameter("@ExchangeRate", SqlDbType.Money,8),
					new SqlParameter("@OperRemark", SqlDbType.Text),
					new SqlParameter("@RealIntoAccountTime", SqlDbType.DateTime),
					new SqlParameter("@TyperName", SqlDbType.VarChar,50),
					new SqlParameter("@Commission", SqlDbType.Money,8),
					new SqlParameter("@WaitorCommision", SqlDbType.Money,8),
					new SqlParameter("@AdminRemark", SqlDbType.Text)};
			parameters[0].Value = model.OrderNo;
			parameters[1].Value = model.PaymentPlatform;
			parameters[2].Value = model.GroupNo;
			parameters[3].Value = model.ProductName;
			parameters[4].Value = model.ProductId;
			parameters[5].Value = model.ProductType;
			parameters[6].Value = model.GuestId;
			parameters[7].Value = model.GuestName;
			parameters[8].Value = model.GuestNamePinYin;
			parameters[9].Value = model.GuestSex;
			parameters[10].Value = model.GuestBirthday;
			parameters[11].Value = model.GuestUseTime;
			parameters[12].Value = model.GuestPhone;
			parameters[13].Value = model.GuestWeiChat;
			parameters[14].Value = model.GuestEMail;
			parameters[15].Value = model.GuestPassportNo;
			parameters[16].Value = model.GuestLastNightHotel;
			parameters[17].Value = model.GuestCountry;
			parameters[18].Value = model.PurchaseNum;
			parameters[19].Value = model.OrderAmount;
			parameters[20].Value = model.ReallyPay;
			parameters[21].Value = model.PlatformActivity;
			parameters[22].Value = model.GuestOrderTime;
			parameters[23].Value = model.WaitorOrderTime;
			parameters[24].Value = model.WaitorConfirmTime;
			parameters[25].Value = model.ReserveTime;
			parameters[26].Value = model.DiningTime;
			parameters[27].Value = model.DiningShop;
			parameters[28].Value = model.CheckMoneyTime;
			parameters[29].Value = model.RefundAmout;
			parameters[30].Value = model.GuestRefundApplyTime;
			parameters[31].Value = model.WaitorRefundApplyTime;
			parameters[32].Value = model.WaitorName;
			parameters[33].Value = model.IsPraise;
			parameters[34].Value = model.RefundReason;
			parameters[35].Value = model.WaitorRemark;
			parameters[36].Value = model.JpOrderNo;
			parameters[37].Value = model.OrderWay;
			parameters[38].Value = model.OperOrderTime;
			parameters[39].Value = model.JpConfirmTime;
			parameters[40].Value = model.ReplyWaitorConfirmTime;
			parameters[41].Value = model.ReplyResult;
			parameters[42].Value = model.SettlePrice;
			parameters[43].Value = model.ExchangeRate;
			parameters[44].Value = model.OperRemark;
			parameters[45].Value = model.RealIntoAccountTime;
			parameters[46].Value = model.TyperName;
			parameters[47].Value = model.Commission;
			parameters[48].Value = model.WaitorCommision;
			parameters[49].Value = model.AdminRemark;

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
			strSql.Append("OrderNo=@OrderNo,");
			strSql.Append("PaymentPlatform=@PaymentPlatform,");
			strSql.Append("GroupNo=@GroupNo,");
			strSql.Append("ProductName=@ProductName,");
			strSql.Append("ProductId=@ProductId,");
			strSql.Append("ProductType=@ProductType,");
			strSql.Append("GuestId=@GuestId,");
			strSql.Append("GuestName=@GuestName,");
			strSql.Append("GuestNamePinYin=@GuestNamePinYin,");
			strSql.Append("GuestSex=@GuestSex,");
			strSql.Append("GuestBirthday=@GuestBirthday,");
			strSql.Append("GuestUseTime=@GuestUseTime,");
			strSql.Append("GuestPhone=@GuestPhone,");
			strSql.Append("GuestWeiChat=@GuestWeiChat,");
			strSql.Append("GuestEMail=@GuestEMail,");
			strSql.Append("GuestPassportNo=@GuestPassportNo,");
			strSql.Append("GuestLastNightHotel=@GuestLastNightHotel,");
			strSql.Append("GuestCountry=@GuestCountry,");
			strSql.Append("PurchaseNum=@PurchaseNum,");
			strSql.Append("OrderAmount=@OrderAmount,");
			strSql.Append("ReallyPay=@ReallyPay,");
			strSql.Append("PlatformActivity=@PlatformActivity,");
			strSql.Append("GuestOrderTime=@GuestOrderTime,");
			strSql.Append("WaitorOrderTime=@WaitorOrderTime,");
			strSql.Append("WaitorConfirmTime=@WaitorConfirmTime,");
			strSql.Append("ReserveTime=@ReserveTime,");
			strSql.Append("DiningTime=@DiningTime,");
			strSql.Append("DiningShop=@DiningShop,");
			strSql.Append("CheckMoneyTime=@CheckMoneyTime,");
			strSql.Append("RefundAmout=@RefundAmout,");
			strSql.Append("GuestRefundApplyTime=@GuestRefundApplyTime,");
			strSql.Append("WaitorRefundApplyTime=@WaitorRefundApplyTime,");
			strSql.Append("WaitorName=@WaitorName,");
			strSql.Append("IsPraise=@IsPraise,");
			strSql.Append("RefundReason=@RefundReason,");
			strSql.Append("WaitorRemark=@WaitorRemark,");
			strSql.Append("JpOrderNo=@JpOrderNo,");
			strSql.Append("OrderWay=@OrderWay,");
			strSql.Append("OperOrderTime=@OperOrderTime,");
			strSql.Append("JpConfirmTime=@JpConfirmTime,");
			strSql.Append("ReplyWaitorConfirmTime=@ReplyWaitorConfirmTime,");
			strSql.Append("ReplyResult=@ReplyResult,");
			strSql.Append("SettlePrice=@SettlePrice,");
			strSql.Append("ExchangeRate=@ExchangeRate,");
			strSql.Append("OperRemark=@OperRemark,");
			strSql.Append("RealIntoAccountTime=@RealIntoAccountTime,");
			strSql.Append("TyperName=@TyperName,");
			strSql.Append("Commission=@Commission,");
			strSql.Append("WaitorCommision=@WaitorCommision,");
			strSql.Append("AdminRemark=@AdminRemark");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.VarChar,50),
					new SqlParameter("@PaymentPlatform", SqlDbType.TinyInt,1),
					new SqlParameter("@GroupNo", SqlDbType.VarChar,500),
					new SqlParameter("@ProductName", SqlDbType.VarChar,200),
					new SqlParameter("@ProductId", SqlDbType.Int,4),
					new SqlParameter("@ProductType", SqlDbType.VarChar,50),
					new SqlParameter("@GuestId", SqlDbType.Int,4),
					new SqlParameter("@GuestName", SqlDbType.VarChar,20),
					new SqlParameter("@GuestNamePinYin", SqlDbType.VarChar,50),
					new SqlParameter("@GuestSex", SqlDbType.VarChar,10),
					new SqlParameter("@GuestBirthday", SqlDbType.DateTime,3),
					new SqlParameter("@GuestUseTime", SqlDbType.Int,4),
					new SqlParameter("@GuestPhone", SqlDbType.VarChar,20),
					new SqlParameter("@GuestWeiChat", SqlDbType.VarChar,50),
					new SqlParameter("@GuestEMail", SqlDbType.VarChar,50),
					new SqlParameter("@GuestPassportNo", SqlDbType.VarChar,30),
					new SqlParameter("@GuestLastNightHotel", SqlDbType.VarChar,50),
					new SqlParameter("@GuestCountry", SqlDbType.VarChar,10),
					new SqlParameter("@PurchaseNum", SqlDbType.Int,4),
					new SqlParameter("@OrderAmount", SqlDbType.Money,8),
					new SqlParameter("@ReallyPay", SqlDbType.Money,8),
					new SqlParameter("@PlatformActivity", SqlDbType.VarChar,100),
					new SqlParameter("@GuestOrderTime", SqlDbType.DateTime),
					new SqlParameter("@WaitorOrderTime", SqlDbType.DateTime),
					new SqlParameter("@WaitorConfirmTime", SqlDbType.DateTime),
					new SqlParameter("@ReserveTime", SqlDbType.Int,4),
					new SqlParameter("@DiningTime", SqlDbType.DateTime),
					new SqlParameter("@DiningShop", SqlDbType.VarChar,50),
					new SqlParameter("@CheckMoneyTime", SqlDbType.DateTime),
					new SqlParameter("@RefundAmout", SqlDbType.Money,8),
					new SqlParameter("@GuestRefundApplyTime", SqlDbType.DateTime),
					new SqlParameter("@WaitorRefundApplyTime", SqlDbType.DateTime),
					new SqlParameter("@WaitorName", SqlDbType.VarChar,20),
					new SqlParameter("@IsPraise", SqlDbType.VarChar,10),
					new SqlParameter("@RefundReason", SqlDbType.Text),
					new SqlParameter("@WaitorRemark", SqlDbType.Text),
					new SqlParameter("@JpOrderNo", SqlDbType.VarChar,50),
					new SqlParameter("@OrderWay", SqlDbType.VarChar,50),
					new SqlParameter("@OperOrderTime", SqlDbType.DateTime),
					new SqlParameter("@JpConfirmTime", SqlDbType.DateTime),
					new SqlParameter("@ReplyWaitorConfirmTime", SqlDbType.DateTime),
					new SqlParameter("@ReplyResult", SqlDbType.VarChar,20),
					new SqlParameter("@SettlePrice", SqlDbType.Money,8),
					new SqlParameter("@ExchangeRate", SqlDbType.Money,8),
					new SqlParameter("@OperRemark", SqlDbType.Text),
					new SqlParameter("@RealIntoAccountTime", SqlDbType.DateTime),
					new SqlParameter("@TyperName", SqlDbType.VarChar,50),
					new SqlParameter("@Commission", SqlDbType.Money,8),
					new SqlParameter("@WaitorCommision", SqlDbType.Money,8),
					new SqlParameter("@AdminRemark", SqlDbType.Text),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.OrderNo;
			parameters[1].Value = model.PaymentPlatform;
			parameters[2].Value = model.GroupNo;
			parameters[3].Value = model.ProductName;
			parameters[4].Value = model.ProductId;
			parameters[5].Value = model.ProductType;
			parameters[6].Value = model.GuestId;
			parameters[7].Value = model.GuestName;
			parameters[8].Value = model.GuestNamePinYin;
			parameters[9].Value = model.GuestSex;
			parameters[10].Value = model.GuestBirthday;
			parameters[11].Value = model.GuestUseTime;
			parameters[12].Value = model.GuestPhone;
			parameters[13].Value = model.GuestWeiChat;
			parameters[14].Value = model.GuestEMail;
			parameters[15].Value = model.GuestPassportNo;
			parameters[16].Value = model.GuestLastNightHotel;
			parameters[17].Value = model.GuestCountry;
			parameters[18].Value = model.PurchaseNum;
			parameters[19].Value = model.OrderAmount;
			parameters[20].Value = model.ReallyPay;
			parameters[21].Value = model.PlatformActivity;
			parameters[22].Value = model.GuestOrderTime;
			parameters[23].Value = model.WaitorOrderTime;
			parameters[24].Value = model.WaitorConfirmTime;
			parameters[25].Value = model.ReserveTime;
			parameters[26].Value = model.DiningTime;
			parameters[27].Value = model.DiningShop;
			parameters[28].Value = model.CheckMoneyTime;
			parameters[29].Value = model.RefundAmout;
			parameters[30].Value = model.GuestRefundApplyTime;
			parameters[31].Value = model.WaitorRefundApplyTime;
			parameters[32].Value = model.WaitorName;
			parameters[33].Value = model.IsPraise;
			parameters[34].Value = model.RefundReason;
			parameters[35].Value = model.WaitorRemark;
			parameters[36].Value = model.JpOrderNo;
			parameters[37].Value = model.OrderWay;
			parameters[38].Value = model.OperOrderTime;
			parameters[39].Value = model.JpConfirmTime;
			parameters[40].Value = model.ReplyWaitorConfirmTime;
			parameters[41].Value = model.ReplyResult;
			parameters[42].Value = model.SettlePrice;
			parameters[43].Value = model.ExchangeRate;
			parameters[44].Value = model.OperRemark;
			parameters[45].Value = model.RealIntoAccountTime;
			parameters[46].Value = model.TyperName;
			parameters[47].Value = model.Commission;
			parameters[48].Value = model.WaitorCommision;
			parameters[49].Value = model.AdminRemark;
			parameters[50].Value = model.Id;

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
		/// 批量删除数据
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
			strSql.Append("select  top 1 Id,OrderNo,PaymentPlatform,GroupNo,ProductName,ProductId,ProductType,GuestId,GuestName,GuestNamePinYin,GuestSex,GuestBirthday,GuestUseTime,GuestPhone,GuestWeiChat,GuestEMail,GuestPassportNo,GuestLastNightHotel,GuestCountry,PurchaseNum,OrderAmount,ReallyPay,PlatformActivity,GuestOrderTime,WaitorOrderTime,WaitorConfirmTime,ReserveTime,DiningTime,DiningShop,CheckMoneyTime,RefundAmout,GuestRefundApplyTime,WaitorRefundApplyTime,WaitorName,IsPraise,RefundReason,WaitorRemark,JpOrderNo,OrderWay,OperOrderTime,JpConfirmTime,ReplyWaitorConfirmTime,ReplyResult,SettlePrice,ExchangeRate,OperRemark,RealIntoAccountTime,TyperName,Commission,WaitorCommision,AdminRemark from Orders ");
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
		/// 得到一个对象实体
		/// </summary>
		public TravelAgency.Model.Orders DataRowToModel(DataRow row)
		{
			TravelAgency.Model.Orders model=new TravelAgency.Model.Orders();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["OrderNo"]!=null)
				{
					model.OrderNo=row["OrderNo"].ToString();
				}
				if(row["PaymentPlatform"]!=null && row["PaymentPlatform"].ToString()!="")
				{
					model.PaymentPlatform=int.Parse(row["PaymentPlatform"].ToString());
				}
				if(row["GroupNo"]!=null)
				{
					model.GroupNo=row["GroupNo"].ToString();
				}
				if(row["ProductName"]!=null)
				{
					model.ProductName=row["ProductName"].ToString();
				}
				if(row["ProductId"]!=null && row["ProductId"].ToString()!="")
				{
					model.ProductId=int.Parse(row["ProductId"].ToString());
				}
				if(row["ProductType"]!=null)
				{
					model.ProductType=row["ProductType"].ToString();
				}
				if(row["GuestId"]!=null && row["GuestId"].ToString()!="")
				{
					model.GuestId=int.Parse(row["GuestId"].ToString());
				}
				if(row["GuestName"]!=null)
				{
					model.GuestName=row["GuestName"].ToString();
				}
				if(row["GuestNamePinYin"]!=null)
				{
					model.GuestNamePinYin=row["GuestNamePinYin"].ToString();
				}
				if(row["GuestSex"]!=null)
				{
					model.GuestSex=row["GuestSex"].ToString();
				}
				if(row["GuestBirthday"]!=null && row["GuestBirthday"].ToString()!="")
				{
					model.GuestBirthday=DateTime.Parse(row["GuestBirthday"].ToString());
				}
				if(row["GuestUseTime"]!=null && row["GuestUseTime"].ToString()!="")
				{
					model.GuestUseTime=int.Parse(row["GuestUseTime"].ToString());
				}
				if(row["GuestPhone"]!=null)
				{
					model.GuestPhone=row["GuestPhone"].ToString();
				}
				if(row["GuestWeiChat"]!=null)
				{
					model.GuestWeiChat=row["GuestWeiChat"].ToString();
				}
				if(row["GuestEMail"]!=null)
				{
					model.GuestEMail=row["GuestEMail"].ToString();
				}
				if(row["GuestPassportNo"]!=null)
				{
					model.GuestPassportNo=row["GuestPassportNo"].ToString();
				}
				if(row["GuestLastNightHotel"]!=null)
				{
					model.GuestLastNightHotel=row["GuestLastNightHotel"].ToString();
				}
				if(row["GuestCountry"]!=null)
				{
					model.GuestCountry=row["GuestCountry"].ToString();
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
				if(row["PlatformActivity"]!=null)
				{
					model.PlatformActivity=row["PlatformActivity"].ToString();
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
					model.ReserveTime=int.Parse(row["ReserveTime"].ToString());
				}
				if(row["DiningTime"]!=null && row["DiningTime"].ToString()!="")
				{
					model.DiningTime=DateTime.Parse(row["DiningTime"].ToString());
				}
				if(row["DiningShop"]!=null)
				{
					model.DiningShop=row["DiningShop"].ToString();
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
				if(row["WaitorName"]!=null)
				{
					model.WaitorName=row["WaitorName"].ToString();
				}
				if(row["IsPraise"]!=null)
				{
					model.IsPraise=row["IsPraise"].ToString();
				}
				if(row["RefundReason"]!=null)
				{
					model.RefundReason=row["RefundReason"].ToString();
				}
				if(row["WaitorRemark"]!=null)
				{
					model.WaitorRemark=row["WaitorRemark"].ToString();
				}
				if(row["JpOrderNo"]!=null)
				{
					model.JpOrderNo=row["JpOrderNo"].ToString();
				}
				if(row["OrderWay"]!=null)
				{
					model.OrderWay=row["OrderWay"].ToString();
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
				if(row["ReplyResult"]!=null)
				{
					model.ReplyResult=row["ReplyResult"].ToString();
				}
				if(row["SettlePrice"]!=null && row["SettlePrice"].ToString()!="")
				{
					model.SettlePrice=decimal.Parse(row["SettlePrice"].ToString());
				}
				if(row["ExchangeRate"]!=null && row["ExchangeRate"].ToString()!="")
				{
					model.ExchangeRate=decimal.Parse(row["ExchangeRate"].ToString());
				}
				if(row["OperRemark"]!=null)
				{
					model.OperRemark=row["OperRemark"].ToString();
				}
				if(row["RealIntoAccountTime"]!=null && row["RealIntoAccountTime"].ToString()!="")
				{
					model.RealIntoAccountTime=DateTime.Parse(row["RealIntoAccountTime"].ToString());
				}
				if(row["TyperName"]!=null)
				{
					model.TyperName=row["TyperName"].ToString();
				}
				if(row["Commission"]!=null && row["Commission"].ToString()!="")
				{
					model.Commission=decimal.Parse(row["Commission"].ToString());
				}
				if(row["WaitorCommision"]!=null && row["WaitorCommision"].ToString()!="")
				{
					model.WaitorCommision=decimal.Parse(row["WaitorCommision"].ToString());
				}
				if(row["AdminRemark"]!=null)
				{
					model.AdminRemark=row["AdminRemark"].ToString();
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
			strSql.Append("select Id,OrderNo,PaymentPlatform,GroupNo,ProductName,ProductId,ProductType,GuestId,GuestName,GuestNamePinYin,GuestSex,GuestBirthday,GuestUseTime,GuestPhone,GuestWeiChat,GuestEMail,GuestPassportNo,GuestLastNightHotel,GuestCountry,PurchaseNum,OrderAmount,ReallyPay,PlatformActivity,GuestOrderTime,WaitorOrderTime,WaitorConfirmTime,ReserveTime,DiningTime,DiningShop,CheckMoneyTime,RefundAmout,GuestRefundApplyTime,WaitorRefundApplyTime,WaitorName,IsPraise,RefundReason,WaitorRemark,JpOrderNo,OrderWay,OperOrderTime,JpConfirmTime,ReplyWaitorConfirmTime,ReplyResult,SettlePrice,ExchangeRate,OperRemark,RealIntoAccountTime,TyperName,Commission,WaitorCommision,AdminRemark ");
			strSql.Append(" FROM Orders ");
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
			strSql.Append(" Id,OrderNo,PaymentPlatform,GroupNo,ProductName,ProductId,ProductType,GuestId,GuestName,GuestNamePinYin,GuestSex,GuestBirthday,GuestUseTime,GuestPhone,GuestWeiChat,GuestEMail,GuestPassportNo,GuestLastNightHotel,GuestCountry,PurchaseNum,OrderAmount,ReallyPay,PlatformActivity,GuestOrderTime,WaitorOrderTime,WaitorConfirmTime,ReserveTime,DiningTime,DiningShop,CheckMoneyTime,RefundAmout,GuestRefundApplyTime,WaitorRefundApplyTime,WaitorName,IsPraise,RefundReason,WaitorRemark,JpOrderNo,OrderWay,OperOrderTime,JpConfirmTime,ReplyWaitorConfirmTime,ReplyResult,SettlePrice,ExchangeRate,OperRemark,RealIntoAccountTime,TyperName,Commission,WaitorCommision,AdminRemark ");
			strSql.Append(" FROM Orders ");
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
			strSql.Append(")AS Row, T.*  from Orders T ");
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
			parameters[0].Value = "Orders";
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

