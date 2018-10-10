using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace TravelAgency.Model
{
	 	//DeniedVisaInfo
		[Serializable]
	public partial class DeniedVisaInfo
	{
        		                  
    private int _id;
        		                  
    private DateTime? _entrytime;
        		                  
    private string _name;
        		                  
    private string _passportno;
        		                  
    private string _denyreason;
        		                  
    private string _remark;
        		                  
    private string _operatorname;
        		                  
    private string _operatorworkid;
        		                  
    private string _country;
        		                  
    private string _client;
        
    /// <summary>
		/// Id
        /// </summary>		
		      		  
  
        public int Id
        {
            get{ return _id; }
            set{ _id = value; }
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
		/// Name
        /// </summary>		
		      		  
  
        public string Name
        {
            get{ return _name; }
            set{ _name = value; }
        }    
      
		/// <summary>
		/// PassportNo
        /// </summary>		
		      		  
  
        public string PassportNo
        {
            get{ return _passportno; }
            set{ _passportno = value; }
        }    
      
		/// <summary>
		/// DenyReason
        /// </summary>		
		      		  
  
        public string DenyReason
        {
            get{ return _denyreason; }
            set{ _denyreason = value; }
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
		/// OperatorName
        /// </summary>		
		      		  
  
        public string OperatorName
        {
            get{ return _operatorname; }
            set{ _operatorname = value; }
        }    
      
		/// <summary>
		/// OperatorWorkId
        /// </summary>		
		      		  
  
        public string OperatorWorkId
        {
            get{ return _operatorworkid; }
            set{ _operatorworkid = value; }
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
		/// Client
        /// </summary>		
		      		  
  
        public string Client
        {
            get{ return _client; }
            set{ _client = value; }
        }    
      
		   
	}
}