using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// Orders:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Orders
	{
		public Orders()
		{}
		#region Model
		private int _id;
		private string _orderno;
		private int _paymentplatform;
		private string _groupno;
		private string _productname;
		private int? _productid;
		private string _producttype;
		private string _guestid;
		private string _guestname;
		private string _guestnamepinyin;
		private string _guestsex;
		private DateTime? _guestbirthday;
		private DateTime? _guestusetime;
		private string _guestphone;
		private string _guestweichat;
		private string _guestemail;
		private string _guestpassportno;
		private string _guestlastnighthotel;
		private string _guestcountry;
		private int? _purchasenum;
		private decimal? _orderamount;
		private decimal? _reallypay;
		private string _platformactivity;
		private DateTime? _guestordertime;
		private DateTime? _waitorordertime;
		private DateTime? _waitorconfirmtime;
		private DateTime? _reservetime;
		private DateTime? _diningtime;
		private string _diningshop;
		private DateTime? _checkmoneytime;
		private decimal? _refundamout;
		private DateTime? _guestrefundapplytime;
		private DateTime? _waitorrefundapplytime;
		private string _waitorname;
		private string _ispraise;
		private string _refundreason;
		private string _waitorremark;
		private string _jporderno;
		private string _orderway;
		private DateTime? _operordertime;
		private DateTime? _jpconfirmtime;
		private DateTime? _replywaitorconfirmtime;
		private string _replyresult;
		private decimal? _settleprice;
		private decimal? _exchangerate;
		private string _operremark;
		private DateTime? _realintoaccounttime;
		private string _typername;
		private decimal? _commission;
		private decimal? _waitorcommision;
		private string _adminremark;
		private string _opername;
		private bool _guestinfotypedin;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrderNo
		{
			set{ _orderno=value;}
			get{return _orderno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PaymentPlatform
		{
			set{ _paymentplatform=value;}
			get{return _paymentplatform;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GroupNo
		{
			set{ _groupno=value;}
			get{return _groupno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductType
		{
			set{ _producttype=value;}
			get{return _producttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GuestId
		{
			set{ _guestid=value;}
			get{return _guestid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GuestName
		{
			set{ _guestname=value;}
			get{return _guestname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GuestNamePinYin
		{
			set{ _guestnamepinyin=value;}
			get{return _guestnamepinyin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GuestSex
		{
			set{ _guestsex=value;}
			get{return _guestsex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? GuestBirthday
		{
			set{ _guestbirthday=value;}
			get{return _guestbirthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? GuestUseTime
		{
			set{ _guestusetime=value;}
			get{return _guestusetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GuestPhone
		{
			set{ _guestphone=value;}
			get{return _guestphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GuestWeiChat
		{
			set{ _guestweichat=value;}
			get{return _guestweichat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GuestEMail
		{
			set{ _guestemail=value;}
			get{return _guestemail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GuestPassportNo
		{
			set{ _guestpassportno=value;}
			get{return _guestpassportno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GuestLastNightHotel
		{
			set{ _guestlastnighthotel=value;}
			get{return _guestlastnighthotel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GuestCountry
		{
			set{ _guestcountry=value;}
			get{return _guestcountry;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PurchaseNum
		{
			set{ _purchasenum=value;}
			get{return _purchasenum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OrderAmount
		{
			set{ _orderamount=value;}
			get{return _orderamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ReallyPay
		{
			set{ _reallypay=value;}
			get{return _reallypay;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlatformActivity
		{
			set{ _platformactivity=value;}
			get{return _platformactivity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? GuestOrderTime
		{
			set{ _guestordertime=value;}
			get{return _guestordertime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? WaitorOrderTime
		{
			set{ _waitorordertime=value;}
			get{return _waitorordertime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? WaitorConfirmTime
		{
			set{ _waitorconfirmtime=value;}
			get{return _waitorconfirmtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ReserveTime
		{
			set{ _reservetime=value;}
			get{return _reservetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DiningTime
		{
			set{ _diningtime=value;}
			get{return _diningtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DiningShop
		{
			set{ _diningshop=value;}
			get{return _diningshop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CheckMoneyTime
		{
			set{ _checkmoneytime=value;}
			get{return _checkmoneytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? RefundAmout
		{
			set{ _refundamout=value;}
			get{return _refundamout;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? GuestRefundApplyTime
		{
			set{ _guestrefundapplytime=value;}
			get{return _guestrefundapplytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? WaitorRefundApplyTime
		{
			set{ _waitorrefundapplytime=value;}
			get{return _waitorrefundapplytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WaitorName
		{
			set{ _waitorname=value;}
			get{return _waitorname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IsPraise
		{
			set{ _ispraise=value;}
			get{return _ispraise;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RefundReason
		{
			set{ _refundreason=value;}
			get{return _refundreason;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WaitorRemark
		{
			set{ _waitorremark=value;}
			get{return _waitorremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JpOrderNo
		{
			set{ _jporderno=value;}
			get{return _jporderno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrderWay
		{
			set{ _orderway=value;}
			get{return _orderway;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OperOrderTime
		{
			set{ _operordertime=value;}
			get{return _operordertime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? JpConfirmTime
		{
			set{ _jpconfirmtime=value;}
			get{return _jpconfirmtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ReplyWaitorConfirmTime
		{
			set{ _replywaitorconfirmtime=value;}
			get{return _replywaitorconfirmtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReplyResult
		{
			set{ _replyresult=value;}
			get{return _replyresult;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SettlePrice
		{
			set{ _settleprice=value;}
			get{return _settleprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ExchangeRate
		{
			set{ _exchangerate=value;}
			get{return _exchangerate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OperRemark
		{
			set{ _operremark=value;}
			get{return _operremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RealIntoAccountTime
		{
			set{ _realintoaccounttime=value;}
			get{return _realintoaccounttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TyperName
		{
			set{ _typername=value;}
			get{return _typername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Commission
		{
			set{ _commission=value;}
			get{return _commission;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? WaitorCommision
		{
			set{ _waitorcommision=value;}
			get{return _waitorcommision;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AdminRemark
		{
			set{ _adminremark=value;}
			get{return _adminremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OperName
		{
			set{ _opername=value;}
			get{return _opername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool GuestInfoTypedIn
		{
			set{ _guestinfotypedin=value;}
			get{return _guestinfotypedin;}
		}
		#endregion Model

	}
}

