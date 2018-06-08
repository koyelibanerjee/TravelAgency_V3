using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace TravelAgency.Model
{
	 	//Orders
		[Serializable]
	public partial class Orders
	{
        		                  
    private int _id;
        		                  
    private string _orderno;
        		                  
    private int? _paymentplatform;
        		                  
    private string _groupno;
        		                  
    private string _productname;
        		                  
    private int? _productid;
        		                  
    private string _producttype;
        		                  
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
        		                  
    private bool? _guestinfotypedin;
        		                  
    private string _moneytype;
        		                  
    private string _comboname;
        		                  
    private DateTime? _departuredate;
        		                  
    private string _guestusetime;
        		                  
    private string _orderstate;
        
    /// <summary>
		/// Id
        /// </summary>		
		      		  
  
        public int Id
        {
            get{ return _id; }
            set{ _id = value; }
        }    
      
		/// <summary>
		/// OrderNo
        /// </summary>		
		      		  
  
        public string OrderNo
        {
            get{ return _orderno; }
            set{ _orderno = value; }
        }    
      
		/// <summary>
		/// PaymentPlatform
        /// </summary>		
		        		  
  
        public int? PaymentPlatform
        {
            get{ return _paymentplatform; }
            set{ _paymentplatform = value; }
        }    
      
		/// <summary>
		/// GroupNo
        /// </summary>		
		      		  
  
        public string GroupNo
        {
            get{ return _groupno; }
            set{ _groupno = value; }
        }    
      
		/// <summary>
		/// ProductName
        /// </summary>		
		      		  
  
        public string ProductName
        {
            get{ return _productname; }
            set{ _productname = value; }
        }    
      
		/// <summary>
		/// ProductId
        /// </summary>		
		        		  
  
        public int? ProductId
        {
            get{ return _productid; }
            set{ _productid = value; }
        }    
      
		/// <summary>
		/// ProductType
        /// </summary>		
		      		  
  
        public string ProductType
        {
            get{ return _producttype; }
            set{ _producttype = value; }
        }    
      
		/// <summary>
		/// PurchaseNum
        /// </summary>		
		        		  
  
        public int? PurchaseNum
        {
            get{ return _purchasenum; }
            set{ _purchasenum = value; }
        }    
      
		/// <summary>
		/// OrderAmount
        /// </summary>		
		        		  
  
        public decimal? OrderAmount
        {
            get{ return _orderamount; }
            set{ _orderamount = value; }
        }    
      
		/// <summary>
		/// ReallyPay
        /// </summary>		
		        		  
  
        public decimal? ReallyPay
        {
            get{ return _reallypay; }
            set{ _reallypay = value; }
        }    
      
		/// <summary>
		/// PlatformActivity
        /// </summary>		
		      		  
  
        public string PlatformActivity
        {
            get{ return _platformactivity; }
            set{ _platformactivity = value; }
        }    
      
		/// <summary>
		/// GuestOrderTime
        /// </summary>		
		        		  
  
        public DateTime? GuestOrderTime
        {
            get{ return _guestordertime; }
            set{ _guestordertime = value; }
        }    
      
		/// <summary>
		/// WaitorOrderTime
        /// </summary>		
		        		  
  
        public DateTime? WaitorOrderTime
        {
            get{ return _waitorordertime; }
            set{ _waitorordertime = value; }
        }    
      
		/// <summary>
		/// WaitorConfirmTime
        /// </summary>		
		        		  
  
        public DateTime? WaitorConfirmTime
        {
            get{ return _waitorconfirmtime; }
            set{ _waitorconfirmtime = value; }
        }    
      
		/// <summary>
		/// ReserveTime
        /// </summary>		
		        		  
  
        public DateTime? ReserveTime
        {
            get{ return _reservetime; }
            set{ _reservetime = value; }
        }    
      
		/// <summary>
		/// DiningTime
        /// </summary>		
		        		  
  
        public DateTime? DiningTime
        {
            get{ return _diningtime; }
            set{ _diningtime = value; }
        }    
      
		/// <summary>
		/// DiningShop
        /// </summary>		
		      		  
  
        public string DiningShop
        {
            get{ return _diningshop; }
            set{ _diningshop = value; }
        }    
      
		/// <summary>
		/// CheckMoneyTime
        /// </summary>		
		        		  
  
        public DateTime? CheckMoneyTime
        {
            get{ return _checkmoneytime; }
            set{ _checkmoneytime = value; }
        }    
      
		/// <summary>
		/// RefundAmout
        /// </summary>		
		        		  
  
        public decimal? RefundAmout
        {
            get{ return _refundamout; }
            set{ _refundamout = value; }
        }    
      
		/// <summary>
		/// GuestRefundApplyTime
        /// </summary>		
		        		  
  
        public DateTime? GuestRefundApplyTime
        {
            get{ return _guestrefundapplytime; }
            set{ _guestrefundapplytime = value; }
        }    
      
		/// <summary>
		/// WaitorRefundApplyTime
        /// </summary>		
		        		  
  
        public DateTime? WaitorRefundApplyTime
        {
            get{ return _waitorrefundapplytime; }
            set{ _waitorrefundapplytime = value; }
        }    
      
		/// <summary>
		/// WaitorName
        /// </summary>		
		      		  
  
        public string WaitorName
        {
            get{ return _waitorname; }
            set{ _waitorname = value; }
        }    
      
		/// <summary>
		/// IsPraise
        /// </summary>		
		      		  
  
        public string IsPraise
        {
            get{ return _ispraise; }
            set{ _ispraise = value; }
        }    
      
		/// <summary>
		/// RefundReason
        /// </summary>		
		      		  
  
        public string RefundReason
        {
            get{ return _refundreason; }
            set{ _refundreason = value; }
        }    
      
		/// <summary>
		/// WaitorRemark
        /// </summary>		
		      		  
  
        public string WaitorRemark
        {
            get{ return _waitorremark; }
            set{ _waitorremark = value; }
        }    
      
		/// <summary>
		/// JpOrderNo
        /// </summary>		
		      		  
  
        public string JpOrderNo
        {
            get{ return _jporderno; }
            set{ _jporderno = value; }
        }    
      
		/// <summary>
		/// OrderWay
        /// </summary>		
		      		  
  
        public string OrderWay
        {
            get{ return _orderway; }
            set{ _orderway = value; }
        }    
      
		/// <summary>
		/// OperOrderTime
        /// </summary>		
		        		  
  
        public DateTime? OperOrderTime
        {
            get{ return _operordertime; }
            set{ _operordertime = value; }
        }    
      
		/// <summary>
		/// JpConfirmTime
        /// </summary>		
		        		  
  
        public DateTime? JpConfirmTime
        {
            get{ return _jpconfirmtime; }
            set{ _jpconfirmtime = value; }
        }    
      
		/// <summary>
		/// ReplyWaitorConfirmTime
        /// </summary>		
		        		  
  
        public DateTime? ReplyWaitorConfirmTime
        {
            get{ return _replywaitorconfirmtime; }
            set{ _replywaitorconfirmtime = value; }
        }    
      
		/// <summary>
		/// ReplyResult
        /// </summary>		
		      		  
  
        public string ReplyResult
        {
            get{ return _replyresult; }
            set{ _replyresult = value; }
        }    
      
		/// <summary>
		/// SettlePrice
        /// </summary>		
		        		  
  
        public decimal? SettlePrice
        {
            get{ return _settleprice; }
            set{ _settleprice = value; }
        }    
      
		/// <summary>
		/// ExchangeRate
        /// </summary>		
		        		  
  
        public decimal? ExchangeRate
        {
            get{ return _exchangerate; }
            set{ _exchangerate = value; }
        }    
      
		/// <summary>
		/// OperRemark
        /// </summary>		
		      		  
  
        public string OperRemark
        {
            get{ return _operremark; }
            set{ _operremark = value; }
        }    
      
		/// <summary>
		/// RealIntoAccountTime
        /// </summary>		
		        		  
  
        public DateTime? RealIntoAccountTime
        {
            get{ return _realintoaccounttime; }
            set{ _realintoaccounttime = value; }
        }    
      
		/// <summary>
		/// TyperName
        /// </summary>		
		      		  
  
        public string TyperName
        {
            get{ return _typername; }
            set{ _typername = value; }
        }    
      
		/// <summary>
		/// Commission
        /// </summary>		
		        		  
  
        public decimal? Commission
        {
            get{ return _commission; }
            set{ _commission = value; }
        }    
      
		/// <summary>
		/// WaitorCommision
        /// </summary>		
		        		  
  
        public decimal? WaitorCommision
        {
            get{ return _waitorcommision; }
            set{ _waitorcommision = value; }
        }    
      
		/// <summary>
		/// AdminRemark
        /// </summary>		
		      		  
  
        public string AdminRemark
        {
            get{ return _adminremark; }
            set{ _adminremark = value; }
        }    
      
		/// <summary>
		/// OperName
        /// </summary>		
		      		  
  
        public string OperName
        {
            get{ return _opername; }
            set{ _opername = value; }
        }    
      
		/// <summary>
		/// GuestInfoTypedIn
        /// </summary>		
		        		  
  
        public bool? GuestInfoTypedIn
        {
            get{ return _guestinfotypedin; }
            set{ _guestinfotypedin = value; }
        }    
      
		/// <summary>
		/// MoneyType
        /// </summary>		
		      		  
  
        public string MoneyType
        {
            get{ return _moneytype; }
            set{ _moneytype = value; }
        }    
      
		/// <summary>
		/// ComboName
        /// </summary>		
		      		  
  
        public string ComboName
        {
            get{ return _comboname; }
            set{ _comboname = value; }
        }    
      
		/// <summary>
		/// DepartureDate
        /// </summary>		
		        		  
  
        public DateTime? DepartureDate
        {
            get{ return _departuredate; }
            set{ _departuredate = value; }
        }    
      
		/// <summary>
		/// GuestUseTime
        /// </summary>		
		      		  
  
        public string GuestUseTime
        {
            get{ return _guestusetime; }
            set{ _guestusetime = value; }
        }    
      
		/// <summary>
		/// OrderState
        /// </summary>		
		      		  
  
        public string OrderState
        {
            get{ return _orderstate; }
            set{ _orderstate = value; }
        }    
      
		   
	}
}