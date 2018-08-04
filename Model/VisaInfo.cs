using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace TravelAgency.Model
{
	 	//VisaInfo
		[Serializable]
	public partial class VisaInfo
	{
        		                  
    private Guid _visainfo_id;
        		                  
    private string _visa_id;
        		                  
    private string _groupno;
        		                  
    private string _name;
        		                  
    private string _englishname;
        		                  
    private string _sex;
        		                  
    private DateTime? _birthday;
        		                  
    private string _passportno;
        		                  
    private DateTime? _licencetime;
        		                  
    private DateTime? _expirydate;
        		                  
    private string _birthplace;
        		                  
    private string _issueplace;
        		                  
    private string _post;
        		                  
    private string _phone;
        		                  
    private string _guideno;
        		                  
    private string _client;
        		                  
    private string _salesperson;
        		                  
    private string _types;
        		                  
    private Guid _sale_id;
        		                  
    private Guid _departmentid;
        		                  
    private string _tips;
        		                  
    private DateTime? _entrytime;
        		                  
    private DateTime? _embassytime;
        		                  
    private DateTime? _intime;
        		                  
    private DateTime? _outtime;
        		                  
    private string _realout;
        		                  
    private DateTime? _realouttime;
        		                  
    private string _country;
        		                  
    private string _call;
        		                  
    private string _exportstate;
        		                  
    private string _outstate;
        		                  
    private string _residence;
        		                  
    private string _occupation;
        		                  
    private string _departurerecord;
        		                  
    private string _marriaged;
        		                  
    private string _identification;
        		                  
    private string _financialcapacity;
        		                  
    private string _agencyopinion;
        		                  
    private string _hastypein;
        		                  
    private DateTime? _abnormalouttime;
        		                  
    private string _haschecked;
        		                  
    private string _checkperson;
        		                  
    private DateTime? _returntime;
        		                  
    private int? _position;
        		                  
    private string _issueplaceenglish;
        		                  
    private string _birthplaceenglish;
        		                  
    private int? _jobid;
        		                  
    private string _assignmenttoworkid;
        		                  
    private string _assignmenttousername;
        		                  
    private int? _district;
        
    /// <summary>
		/// VisaInfo_id
        /// </summary>		
		      		  
  
        public Guid VisaInfo_id
        {
            get{ return _visainfo_id; }
            set{ _visainfo_id = value; }
        }    
      
		/// <summary>
		/// Visa_id
        /// </summary>		
		      		  
  
        public string Visa_id
        {
            get{ return _visa_id; }
            set{ _visa_id = value; }
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
		/// 姓名
        /// </summary>		
		      		  
  
        public string Name
        {
            get{ return _name; }
            set{ _name = value; }
        }    
      
		/// <summary>
		/// 英语姓名
        /// </summary>		
		      		  
  
        public string EnglishName
        {
            get{ return _englishname; }
            set{ _englishname = value; }
        }    
      
		/// <summary>
		/// 性别
        /// </summary>		
		      		  
  
        public string Sex
        {
            get{ return _sex; }
            set{ _sex = value; }
        }    
      
		/// <summary>
		/// 生日
        /// </summary>		
		        		  
  
        public DateTime? Birthday
        {
            get{ return _birthday; }
            set{ _birthday = value; }
        }    
      
		/// <summary>
		/// 护照号
        /// </summary>		
		      		  
  
        public string PassportNo
        {
            get{ return _passportno; }
            set{ _passportno = value; }
        }    
      
		/// <summary>
		/// 发证日期
        /// </summary>		
		        		  
  
        public DateTime? LicenceTime
        {
            get{ return _licencetime; }
            set{ _licencetime = value; }
        }    
      
		/// <summary>
		/// 有效期
        /// </summary>		
		        		  
  
        public DateTime? ExpiryDate
        {
            get{ return _expirydate; }
            set{ _expirydate = value; }
        }    
      
		/// <summary>
		/// 出生地
        /// </summary>		
		      		  
  
        public string Birthplace
        {
            get{ return _birthplace; }
            set{ _birthplace = value; }
        }    
      
		/// <summary>
		/// 签发地
        /// </summary>		
		      		  
  
        public string IssuePlace
        {
            get{ return _issueplace; }
            set{ _issueplace = value; }
        }    
      
		/// <summary>
		/// 职位
        /// </summary>		
		      		  
  
        public string Post
        {
            get{ return _post; }
            set{ _post = value; }
        }    
      
		/// <summary>
		/// 电话
        /// </summary>		
		      		  
  
        public string Phone
        {
            get{ return _phone; }
            set{ _phone = value; }
        }    
      
		/// <summary>
		/// 领队编号
        /// </summary>		
		      		  
  
        public string GuideNo
        {
            get{ return _guideno; }
            set{ _guideno = value; }
        }    
      
		/// <summary>
		/// 客户
        /// </summary>		
		      		  
  
        public string Client
        {
            get{ return _client; }
            set{ _client = value; }
        }    
      
		/// <summary>
		/// 销售员
        /// </summary>		
		      		  
  
        public string Salesperson
        {
            get{ return _salesperson; }
            set{ _salesperson = value; }
        }    
      
		/// <summary>
		/// 签证类型
        /// </summary>		
		      		  
  
        public string Types
        {
            get{ return _types; }
            set{ _types = value; }
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
		/// 备注
        /// </summary>		
		      		  
  
        public string Tips
        {
            get{ return _tips; }
            set{ _tips = value; }
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
		/// EmbassyTime
        /// </summary>		
		        		  
  
        public DateTime? EmbassyTime
        {
            get{ return _embassytime; }
            set{ _embassytime = value; }
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
		/// 归国时间
        /// </summary>		
		        		  
  
        public DateTime? OutTime
        {
            get{ return _outtime; }
            set{ _outtime = value; }
        }    
      
		/// <summary>
		/// RealOut
        /// </summary>		
		      		  
  
        public string RealOut
        {
            get{ return _realout; }
            set{ _realout = value; }
        }    
      
		/// <summary>
		/// RealOutTime
        /// </summary>		
		        		  
  
        public DateTime? RealOutTime
        {
            get{ return _realouttime; }
            set{ _realouttime = value; }
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
		/// Call
        /// </summary>		
		      		  
  
        public string Call
        {
            get{ return _call; }
            set{ _call = value; }
        }    
      
		/// <summary>
		/// 0未导出,1已导出
        /// </summary>		
		      		  
  
        public string ExportState
        {
            get{ return _exportstate; }
            set{ _exportstate = value; }
        }    
      
		/// <summary>
		/// outState
        /// </summary>		
		      		  
  
        public string outState
        {
            get{ return _outstate; }
            set{ _outstate = value; }
        }    
      
		/// <summary>
		/// Residence
        /// </summary>		
		      		  
  
        public string Residence
        {
            get{ return _residence; }
            set{ _residence = value; }
        }    
      
		/// <summary>
		/// Occupation
        /// </summary>		
		      		  
  
        public string Occupation
        {
            get{ return _occupation; }
            set{ _occupation = value; }
        }    
      
		/// <summary>
		/// DepartureRecord
        /// </summary>		
		      		  
  
        public string DepartureRecord
        {
            get{ return _departurerecord; }
            set{ _departurerecord = value; }
        }    
      
		/// <summary>
		/// Marriaged
        /// </summary>		
		      		  
  
        public string Marriaged
        {
            get{ return _marriaged; }
            set{ _marriaged = value; }
        }    
      
		/// <summary>
		/// Identification
        /// </summary>		
		      		  
  
        public string Identification
        {
            get{ return _identification; }
            set{ _identification = value; }
        }    
      
		/// <summary>
		/// FinancialCapacity
        /// </summary>		
		      		  
  
        public string FinancialCapacity
        {
            get{ return _financialcapacity; }
            set{ _financialcapacity = value; }
        }    
      
		/// <summary>
		/// AgencyOpinion
        /// </summary>		
		      		  
  
        public string AgencyOpinion
        {
            get{ return _agencyopinion; }
            set{ _agencyopinion = value; }
        }    
      
		/// <summary>
		/// HasTypeIn
        /// </summary>		
		      		  
  
        public string HasTypeIn
        {
            get{ return _hastypein; }
            set{ _hastypein = value; }
        }    
      
		/// <summary>
		/// AbnormalOutTime
        /// </summary>		
		        		  
  
        public DateTime? AbnormalOutTime
        {
            get{ return _abnormalouttime; }
            set{ _abnormalouttime = value; }
        }    
      
		/// <summary>
		/// HasChecked
        /// </summary>		
		      		  
  
        public string HasChecked
        {
            get{ return _haschecked; }
            set{ _haschecked = value; }
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
		/// ReturnTime
        /// </summary>		
		        		  
  
        public DateTime? ReturnTime
        {
            get{ return _returntime; }
            set{ _returntime = value; }
        }    
      
		/// <summary>
		/// Position
        /// </summary>		
		        		  
  
        public int? Position
        {
            get{ return _position; }
            set{ _position = value; }
        }    
      
		/// <summary>
		/// IssuePlaceEnglish
        /// </summary>		
		      		  
  
        public string IssuePlaceEnglish
        {
            get{ return _issueplaceenglish; }
            set{ _issueplaceenglish = value; }
        }    
      
		/// <summary>
		/// BirthPlaceEnglish
        /// </summary>		
		      		  
  
        public string BirthPlaceEnglish
        {
            get{ return _birthplaceenglish; }
            set{ _birthplaceenglish = value; }
        }    
      
		/// <summary>
		/// JobId
        /// </summary>		
		        		  
  
        public int? JobId
        {
            get{ return _jobid; }
            set{ _jobid = value; }
        }    
      
		/// <summary>
		/// AssignmentToWorkId
        /// </summary>		
		      		  
  
        public string AssignmentToWorkId
        {
            get{ return _assignmenttoworkid; }
            set{ _assignmenttoworkid = value; }
        }    
      
		/// <summary>
		/// AssignmentToUserName
        /// </summary>		
		      		  
  
        public string AssignmentToUserName
        {
            get{ return _assignmenttousername; }
            set{ _assignmenttousername = value; }
        }    
      
		/// <summary>
		/// District
        /// </summary>		
		        		  
  
        public int? District
        {
            get{ return _district; }
            set{ _district = value; }
        }    
      
		   
	}
}