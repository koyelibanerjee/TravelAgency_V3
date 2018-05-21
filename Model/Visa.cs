using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace TravelAgency.Model
{
	 	//Visa
		[Serializable]
	public partial class Visa
	{
        		                  
    private Guid _visa_id;
        		                  
    private string _groupno;
        		                  
    private string _name;
        		                  
    private string _types;
        		                  
    private string _tips;
        		                  
    private DateTime? _predicttime;
        		                  
    private DateTime? _realtime;
        		                  
    private DateTime? _finishtime;
        		                  
    private string _satus;
        		                  
    private string _person;
        		                  
    private int? _number;
        		                  
    private decimal? _picture;
        		                  
    private decimal? _listcount;
        		                  
    private string _list;
        		                  
    private string _salesperson;
        		                  
    private decimal? _receipt;
        		                  
    private decimal? _quidco;
        		                  
    private decimal? _cost;
        		                  
    private decimal? _othercost;
        		                  
    private string _expressno;
        		                  
    private string _call;
        		                  
    private Guid _sale_id;
        		                  
    private Guid _departmentid;
        		                  
    private DateTime? _entrytime;
        		                  
    private string _country;
        		                  
    private string _passengers;
        		                  
    private string _workid;
        		                  
    private string _documenter;
        		                  
    private decimal? _price;
        		                  
    private decimal? _consulatecost;
        		                  
    private decimal? _visapersoncost;
        		                  
    private decimal? _mailcost;
        		                  
    private string _tips2;
        		                  
    private int? _submitflag;
        		                  
    private decimal? _groupprice;
        		                  
    private decimal? _invitationcost;
        		                  
    private string _remark;
        		                  
    private DateTime? _submittime;
        		                  
    private DateTime? _intime;
        		                  
    private DateTime? _outtime;
        		                  
    private string _client;
        		                  
    private string _departuretype;
        		                  
    private string _submitcondition;
        		                  
    private string _fetchcondition;
        		                  
    private string _typeinperson;
        		                  
    private string _checkperson;
        		                  
    private bool? _isurgent;
        		                  
    private string _peiqianyuan;
        		                  
    private string _quqianyuan;
        		                  
    private string _operator;
        		                  
    private string _claimedflag;
        
    /// <summary>
		/// Visa_id
        /// </summary>		
		      		  
  
        public Guid Visa_id
        {
            get{ return _visa_id; }
            set{ _visa_id = value; }
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
		/// 姓名(客人姓名/领队姓名)
        /// </summary>		
		      		  
  
        public string Name
        {
            get{ return _name; }
            set{ _name = value; }
        }    
      
		/// <summary>
		/// 签证类型(团签\个签\其他)
        /// </summary>		
		      		  
  
        public string Types
        {
            get{ return _types; }
            set{ _types = value; }
        }    
      
		/// <summary>
		/// 对团签个签进行备注说明.比如做单次、三年、五年
        /// </summary>		
		      		  
  
        public string Tips
        {
            get{ return _tips; }
            set{ _tips = value; }
        }    
      
		/// <summary>
		/// 预计送签时间
        /// </summary>		
		        		  
  
        public DateTime? PredictTime
        {
            get{ return _predicttime; }
            set{ _predicttime = value; }
        }    
      
		/// <summary>
		/// 实际送签时间
        /// </summary>		
		        		  
  
        public DateTime? RealTime
        {
            get{ return _realtime; }
            set{ _realtime = value; }
        }    
      
		/// <summary>
		/// 出签时间
        /// </summary>		
		        		  
  
        public DateTime? FinishTime
        {
            get{ return _finishtime; }
            set{ _finishtime = value; }
        }    
      
		/// <summary>
		/// 办理签证的状态
        /// </summary>		
		      		  
  
        public string Satus
        {
            get{ return _satus; }
            set{ _satus = value; }
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
		/// 洗照片
        /// </summary>		
		        		  
  
        public decimal? Picture
        {
            get{ return _picture; }
            set{ _picture = value; }
        }    
      
		/// <summary>
		/// 出境名单费用
        /// </summary>		
		        		  
  
        public decimal? ListCount
        {
            get{ return _listcount; }
            set{ _listcount = value; }
        }    
      
		/// <summary>
		/// 出境名单社
        /// </summary>		
		      		  
  
        public string List
        {
            get{ return _list; }
            set{ _list = value; }
        }    
      
		/// <summary>
		/// 销售人员姓名
        /// </summary>		
		      		  
  
        public string SalesPerson
        {
            get{ return _salesperson; }
            set{ _salesperson = value; }
        }    
      
		/// <summary>
		/// 收款
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
		/// 签证成本
        /// </summary>		
		        		  
  
        public decimal? Cost
        {
            get{ return _cost; }
            set{ _cost = value; }
        }    
      
		/// <summary>
		/// 杂费
        /// </summary>		
		        		  
  
        public decimal? OtherCost
        {
            get{ return _othercost; }
            set{ _othercost = value; }
        }    
      
		/// <summary>
		/// 快递号
        /// </summary>		
		      		  
  
        public string ExpressNo
        {
            get{ return _expressno; }
            set{ _expressno = value; }
        }    
      
		/// <summary>
		/// 是否归国回访
        /// </summary>		
		      		  
  
        public string Call
        {
            get{ return _call; }
            set{ _call = value; }
        }    
      
		/// <summary>
		/// Sale_id
        /// </summary>		
		      		  
  
        public Guid Sale_id
        {
            get{ return _sale_id; }
            set{ _sale_id = value; }
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
		/// EntryTime
        /// </summary>		
		        		  
  
        public DateTime? EntryTime
        {
            get{ return _entrytime; }
            set{ _entrytime = value; }
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
		/// Passengers
        /// </summary>		
		      		  
  
        public string Passengers
        {
            get{ return _passengers; }
            set{ _passengers = value; }
        }    
      
		/// <summary>
		/// WorkId
        /// </summary>		
		      		  
  
        public string WorkId
        {
            get{ return _workid; }
            set{ _workid = value; }
        }    
      
		/// <summary>
		/// Documenter
        /// </summary>		
		      		  
  
        public string Documenter
        {
            get{ return _documenter; }
            set{ _documenter = value; }
        }    
      
		/// <summary>
		/// 单价
        /// </summary>		
		        		  
  
        public decimal? Price
        {
            get{ return _price; }
            set{ _price = value; }
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
		/// Tips2
        /// </summary>		
		      		  
  
        public string Tips2
        {
            get{ return _tips2; }
            set{ _tips2 = value; }
        }    
      
		/// <summary>
		/// 提交给财务后是1  未提交为0
        /// </summary>		
		        		  
  
        public int? SubmitFlag
        {
            get{ return _submitflag; }
            set{ _submitflag = value; }
        }    
      
		/// <summary>
		/// GroupPrice
        /// </summary>		
		        		  
  
        public decimal? GroupPrice
        {
            get{ return _groupprice; }
            set{ _groupprice = value; }
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
		/// Remark
        /// </summary>		
		      		  
  
        public string Remark
        {
            get{ return _remark; }
            set{ _remark = value; }
        }    
      
		/// <summary>
		/// SubmitTime
        /// </summary>		
		        		  
  
        public DateTime? SubmitTime
        {
            get{ return _submittime; }
            set{ _submittime = value; }
        }    
      
		/// <summary>
		/// InTime
        /// </summary>		
		        		  
  
        public DateTime? InTime
        {
            get{ return _intime; }
            set{ _intime = value; }
        }    
      
		/// <summary>
		/// OutTime
        /// </summary>		
		        		  
  
        public DateTime? OutTime
        {
            get{ return _outtime; }
            set{ _outtime = value; }
        }    
      
		/// <summary>
		/// client
        /// </summary>		
		      		  
  
        public string client
        {
            get{ return _client; }
            set{ _client = value; }
        }    
      
		/// <summary>
		/// DepartureType
        /// </summary>		
		      		  
  
        public string DepartureType
        {
            get{ return _departuretype; }
            set{ _departuretype = value; }
        }    
      
		/// <summary>
		/// SubmitCondition
        /// </summary>		
		      		  
  
        public string SubmitCondition
        {
            get{ return _submitcondition; }
            set{ _submitcondition = value; }
        }    
      
		/// <summary>
		/// FetchCondition
        /// </summary>		
		      		  
  
        public string FetchCondition
        {
            get{ return _fetchcondition; }
            set{ _fetchcondition = value; }
        }    
      
		/// <summary>
		/// TypeInPerson
        /// </summary>		
		      		  
  
        public string TypeInPerson
        {
            get{ return _typeinperson; }
            set{ _typeinperson = value; }
        }    
      
		/// <summary>
		/// CheckPerson
        /// </summary>		
		      		  
  
        public string CheckPerson
        {
            get{ return _checkperson; }
            set{ _checkperson = value; }
        }    
      
		/// <summary>
		/// IsUrgent
        /// </summary>		
		        		  
  
        public bool? IsUrgent
        {
            get{ return _isurgent; }
            set{ _isurgent = value; }
        }    
      
		/// <summary>
		/// PeiQianYuan
        /// </summary>		
		      		  
  
        public string PeiQianYuan
        {
            get{ return _peiqianyuan; }
            set{ _peiqianyuan = value; }
        }    
      
		/// <summary>
		/// QuQianYuan
        /// </summary>		
		      		  
  
        public string QuQianYuan
        {
            get{ return _quqianyuan; }
            set{ _quqianyuan = value; }
        }    
      
		/// <summary>
		/// Operator
        /// </summary>		
		      		  
  
        public string Operator
        {
            get{ return _operator; }
            set{ _operator = value; }
        }    
      
		/// <summary>
		/// ClaimedFlag
        /// </summary>		
		      		  
  
        public string ClaimedFlag
        {
            get{ return _claimedflag; }
            set{ _claimedflag = value; }
        }    
      
		   
	}
}