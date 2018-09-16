using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace TravelAgency.Model
{
	 	//ActivityOrder
		[Serializable]
	public partial class ActivityOrder
	{
        		                  
    private string _activityorderno;
        		                  
    private string _productname;
        		                  
    private string _type_t;
        		                  
    private int? _number;
        		                  
    private int? _books_set;
        		                  
    private int? _books_sum;
        		                  
    private int? _balancebooks;
        		                  
    private decimal? _amount;
        		                  
    private DateTime? _entrytime;
        		                  
    private string _amountpayable;
        		                  
    private decimal? _tailmoney;
        		                  
    private DateTime? _entrytimepay;
        		                  
    private decimal? _amountpaid;
        		                  
    private string _customername;
        		                  
    private string _company;
        		                  
    private string _mobile;
        		                  
    private decimal? _deposit;
        		                  
    private decimal? _price_active;
        		                  
    private string _paystate;
        		                  
    private string _type_sale;
        		                  
    private string _activityname;
        
    /// <summary>
		/// ActivityOrderNo
        /// </summary>		
		      		  
  
        public string ActivityOrderNo
        {
            get{ return _activityorderno; }
            set{ _activityorderno = value; }
        }    
      
		/// <summary>
		/// 产品名称
        /// </summary>		
		      		  
  
        public string ProductName
        {
            get{ return _productname; }
            set{ _productname = value; }
        }    
      
		/// <summary>
		/// 抢购类型
        /// </summary>		
		      		  
  
        public string Type_T
        {
            get{ return _type_t; }
            set{ _type_t = value; }
        }    
      
		/// <summary>
		/// 购买套数
        /// </summary>		
		        		  
  
        public int? Number
        {
            get{ return _number; }
            set{ _number = value; }
        }    
      
		/// <summary>
		/// 每套本数
        /// </summary>		
		        		  
  
        public int? Books_Set
        {
            get{ return _books_set; }
            set{ _books_set = value; }
        }    
      
		/// <summary>
		/// 总购买本数
        /// </summary>		
		        		  
  
        public int? Books_Sum
        {
            get{ return _books_sum; }
            set{ _books_sum = value; }
        }    
      
		/// <summary>
		/// 使用后剩余的本数
        /// </summary>		
		        		  
  
        public int? BalanceBooks
        {
            get{ return _balancebooks; }
            set{ _balancebooks = value; }
        }    
      
		/// <summary>
		/// 总金额
        /// </summary>		
		        		  
  
        public decimal? Amount
        {
            get{ return _amount; }
            set{ _amount = value; }
        }    
      
		/// <summary>
		/// 购买时间
        /// </summary>		
		        		  
  
        public DateTime? EntryTime
        {
            get{ return _entrytime; }
            set{ _entrytime = value; }
        }    
      
		/// <summary>
		/// 应付定金
        /// </summary>		
		      		  
  
        public string AmountPayable
        {
            get{ return _amountpayable; }
            set{ _amountpayable = value; }
        }    
      
		/// <summary>
		/// 尾款
        /// </summary>		
		        		  
  
        public decimal? TailMoney
        {
            get{ return _tailmoney; }
            set{ _tailmoney = value; }
        }    
      
		/// <summary>
		/// 支付时间
        /// </summary>		
		        		  
  
        public DateTime? EntryTimePay
        {
            get{ return _entrytimepay; }
            set{ _entrytimepay = value; }
        }    
      
		/// <summary>
		/// 已付定金
        /// </summary>		
		        		  
  
        public decimal? AmountPaid
        {
            get{ return _amountpaid; }
            set{ _amountpaid = value; }
        }    
      
		/// <summary>
		/// 客户
        /// </summary>		
		      		  
  
        public string CustomerName
        {
            get{ return _customername; }
            set{ _customername = value; }
        }    
      
		/// <summary>
		/// 公司
        /// </summary>		
		      		  
  
        public string Company
        {
            get{ return _company; }
            set{ _company = value; }
        }    
      
		/// <summary>
		/// 手机
        /// </summary>		
		      		  
  
        public string Mobile
        {
            get{ return _mobile; }
            set{ _mobile = value; }
        }    
      
		/// <summary>
		/// 产品要求定金
        /// </summary>		
		        		  
  
        public decimal? Deposit
        {
            get{ return _deposit; }
            set{ _deposit = value; }
        }    
      
		/// <summary>
		/// 活动单价
        /// </summary>		
		        		  
  
        public decimal? Price_Active
        {
            get{ return _price_active; }
            set{ _price_active = value; }
        }    
      
		/// <summary>
		/// 支付状态
        /// </summary>		
		      		  
  
        public string PayState
        {
            get{ return _paystate; }
            set{ _paystate = value; }
        }    
      
		/// <summary>
		/// 活动类型
        /// </summary>		
		      		  
  
        public string Type_Sale
        {
            get{ return _type_sale; }
            set{ _type_sale = value; }
        }    
      
		/// <summary>
		/// ActivityName
        /// </summary>		
		      		  
  
        public string ActivityName
        {
            get{ return _activityname; }
            set{ _activityname = value; }
        }    
      
		   
	}
}