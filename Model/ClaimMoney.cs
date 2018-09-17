using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace TravelAgency.Model
{
	 	//ClaimMoney
		[Serializable]
	public partial class ClaimMoney
	{
        		                  
    private Guid _claim_id;
        		                  
    private Guid _money_id;
        		                  
    private Guid _departmentid;
        		                  
    private string _name_claim;
        		                  
    private string _groupno;
        		                  
    private string _salesperson;
        		                  
    private string _guests;
        		                  
    private string _methods;
        		                  
    private decimal? _amount;
        		                  
    private string _workid;
        		                  
    private DateTime? _claimtime;
        		                  
    private string _username;
        		                  
    private string _orderno;
        		                  
    private DateTime? _entrytime;
        		                  
    private string _moneytype;
        		                  
    private string _claim_confirm;
        		                  
    private string _activityorderno;
        
    /// <summary>
		/// Claim_id
        /// </summary>		
		      		  
  
        public Guid Claim_id
        {
            get{ return _claim_id; }
            set{ _claim_id = value; }
        }    
      
		/// <summary>
		/// 私账ID
        /// </summary>		
		      		  
  
        public Guid Money_id
        {
            get{ return _money_id; }
            set{ _money_id = value; }
        }    
      
		/// <summary>
		/// DepartmentId
        /// </summary>		
		      		  
  
        public Guid DepartmentId
        {
            get{ return _departmentid; }
            set{ _departmentid = value; }
        }    
      
		/// <summary>
		/// 认领人
        /// </summary>		
		      		  
  
        public string Name_Claim
        {
            get{ return _name_claim; }
            set{ _name_claim = value; }
        }    
      
		/// <summary>
		/// 团号
        /// </summary>		
		      		  
  
        public string GroupNo
        {
            get{ return _groupno; }
            set{ _groupno = value; }
        }    
      
		/// <summary>
		/// 销售人员
        /// </summary>		
		      		  
  
        public string Salesperson
        {
            get{ return _salesperson; }
            set{ _salesperson = value; }
        }    
      
		/// <summary>
		/// 客户
        /// </summary>		
		      		  
  
        public string Guests
        {
            get{ return _guests; }
            set{ _guests = value; }
        }    
      
		/// <summary>
		/// 款项用途
        /// </summary>		
		      		  
  
        public string Methods
        {
            get{ return _methods; }
            set{ _methods = value; }
        }    
      
		/// <summary>
		/// 认款金额
        /// </summary>		
		        		  
  
        public decimal? Amount
        {
            get{ return _amount; }
            set{ _amount = value; }
        }    
      
		/// <summary>
		/// 工号
        /// </summary>		
		      		  
  
        public string WorkId
        {
            get{ return _workid; }
            set{ _workid = value; }
        }    
      
		/// <summary>
		/// ClaimTime
        /// </summary>		
		        		  
  
        public DateTime? ClaimTime
        {
            get{ return _claimtime; }
            set{ _claimtime = value; }
        }    
      
		/// <summary>
		/// 操作用户
        /// </summary>		
		      		  
  
        public string username
        {
            get{ return _username; }
            set{ _username = value; }
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
		/// EntryTime
        /// </summary>		
		        		  
  
        public DateTime? EntryTime
        {
            get{ return _entrytime; }
            set{ _entrytime = value; }
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
		/// 表示是否确认认领，0或空表示未认领完成，1表示认领完成
        /// </summary>		
		      		  
  
        public string Claim_Confirm
        {
            get{ return _claim_confirm; }
            set{ _claim_confirm = value; }
        }    
      
		/// <summary>
		/// ActivityOrderNo
        /// </summary>		
		      		  
  
        public string ActivityOrderNo
        {
            get{ return _activityorderno; }
            set{ _activityorderno = value; }
        }    
      
		   
	}
}