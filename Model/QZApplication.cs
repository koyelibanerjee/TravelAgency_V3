using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace TravelAgency.Model
{
	 	//QZApplication
		[Serializable]
	public partial class QZApplication
	{
        		                  
    private Guid _qzapp_id;
        		                  
    private Guid _visa_id;
        		                  
    private string _subname;
        		                  
    private Guid _departmentid;
        		                  
    private string _groupno;
        		                  
    private DateTime? _sendtime;
        		                  
    private DateTime? _finishtime;
        		                  
    private string _person;
        		                  
    private int? _number;
        		                  
    private string _tips;
        		                  
    private decimal? _price;
        		                  
    private decimal? _receipt;
        		                  
    private decimal? _quidco;
        		                  
    private decimal? _consulatecost;
        		                  
    private decimal? _visapersoncost;
        		                  
    private decimal? _mailcost;
        		                  
    private decimal? _picturecost;
        		                  
    private string _sales;
        		                  
    private string _workid;
        		                  
    private DateTime? _entrytime;
        		                  
    private Guid _app_id;
        		                  
    private int? _flag;
        		                  
    private string _country;
        		                  
    private string _name;
        		                  
    private decimal? _invitationcost;
        		                  
    private decimal? _cost;
        
    /// <summary>
		/// QZApp_id
        /// </summary>		
		      		  
  
        public Guid QZApp_id
        {
            get{ return _qzapp_id; }
            set{ _qzapp_id = value; }
        }    
      
		/// <summary>
		/// Visa_id
        /// </summary>		
		      		  
  
        public Guid Visa_id
        {
            get{ return _visa_id; }
            set{ _visa_id = value; }
        }    
      
		/// <summary>
		/// 提交人
        /// </summary>		
		      		  
  
        public string SubName
        {
            get{ return _subname; }
            set{ _subname = value; }
        }    
      
		/// <summary>
		/// 部门id
        /// </summary>		
		      		  
  
        public Guid DepartmentId
        {
            get{ return _departmentid; }
            set{ _departmentid = value; }
        }    
      
		/// <summary>
		/// 个签生成的团号
        /// </summary>		
		      		  
  
        public string GroupNo
        {
            get{ return _groupno; }
            set{ _groupno = value; }
        }    
      
		/// <summary>
		/// 送签日期
        /// </summary>		
		        		  
  
        public DateTime? SendTime
        {
            get{ return _sendtime; }
            set{ _sendtime = value; }
        }    
      
		/// <summary>
		/// 出签日期
        /// </summary>		
		        		  
  
        public DateTime? FinishTime
        {
            get{ return _finishtime; }
            set{ _finishtime = value; }
        }    
      
		/// <summary>
		/// 送签社担当
        /// </summary>		
		      		  
  
        public string Person
        {
            get{ return _person; }
            set{ _person = value; }
        }    
      
		/// <summary>
		/// 人数
        /// </summary>		
		        		  
  
        public int? Number
        {
            get{ return _number; }
            set{ _number = value; }
        }    
      
		/// <summary>
		/// 备注
        /// </summary>		
		      		  
  
        public string Tips
        {
            get{ return _tips; }
            set{ _tips = value; }
        }    
      
		/// <summary>
		/// 签证成本单价
        /// </summary>		
		        		  
  
        public decimal? Price
        {
            get{ return _price; }
            set{ _price = value; }
        }    
      
		/// <summary>
		/// 收款(给销售的售价)
        /// </summary>		
		        		  
  
        public decimal? Receipt
        {
            get{ return _receipt; }
            set{ _receipt = value; }
        }    
      
		/// <summary>
		/// 返款
        /// </summary>		
		        		  
  
        public decimal? Quidco
        {
            get{ return _quidco; }
            set{ _quidco = value; }
        }    
      
		/// <summary>
		/// ConsulateCost
        /// </summary>		
		        		  
  
        public decimal? ConsulateCost
        {
            get{ return _consulatecost; }
            set{ _consulatecost = value; }
        }    
      
		/// <summary>
		/// VisaPersonCost
        /// </summary>		
		        		  
  
        public decimal? VisaPersonCost
        {
            get{ return _visapersoncost; }
            set{ _visapersoncost = value; }
        }    
      
		/// <summary>
		/// MailCost
        /// </summary>		
		        		  
  
        public decimal? MailCost
        {
            get{ return _mailcost; }
            set{ _mailcost = value; }
        }    
      
		/// <summary>
		/// PictureCost
        /// </summary>		
		        		  
  
        public decimal? PictureCost
        {
            get{ return _picturecost; }
            set{ _picturecost = value; }
        }    
      
		/// <summary>
		/// 销售
        /// </summary>		
		      		  
  
        public string Sales
        {
            get{ return _sales; }
            set{ _sales = value; }
        }    
      
		/// <summary>
		/// 销售工号（可能是销售部的，也可能是签证部销售的）
        /// </summary>		
		      		  
  
        public string WorkId
        {
            get{ return _workid; }
            set{ _workid = value; }
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
		/// App_id
        /// </summary>		
		      		  
  
        public Guid App_id
        {
            get{ return _app_id; }
            set{ _app_id = value; }
        }    
      
		/// <summary>
		/// Flag=0表明签证提交了。销售提交给财务后Flag从1变为2   销售插入后的数据flag=1
        /// </summary>		
		        		  
  
        public int? Flag
        {
            get{ return _flag; }
            set{ _flag = value; }
        }    
      
		/// <summary>
		/// Country
        /// </summary>		
		      		  
  
        public string Country
        {
            get{ return _country; }
            set{ _country = value; }
        }    
      
		/// <summary>
		/// 客户名
        /// </summary>		
		      		  
  
        public string Name
        {
            get{ return _name; }
            set{ _name = value; }
        }    
      
		/// <summary>
		/// InvitationCost
        /// </summary>		
		        		  
  
        public decimal? InvitationCost
        {
            get{ return _invitationcost; }
            set{ _invitationcost = value; }
        }    
      
		/// <summary>
		/// Cost
        /// </summary>		
		        		  
  
        public decimal? Cost
        {
            get{ return _cost; }
            set{ _cost = value; }
        }    
      
		   
	}
}