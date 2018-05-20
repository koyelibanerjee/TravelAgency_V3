using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace TravelAgency.Model
{
	 	//user_copy
		public class user_copy
	{
        		                  
    private string _workid;
        		                  
    private string _account;
        		                  
    private string _username;
        		                  
    private string _password;
        		                  
    private string _usermobile;
        		                  
    private Guid _departmentid;
        		                  
    private Guid _rid;
        		                  
    private string _rolename;
        
    /// <summary>
		/// WorkId
        /// </summary>		
		      		  
  
        public string WorkId
        {
            get{ return _workid; }
            set{ _workid = value; }
        }    
      
		/// <summary>
		/// Account
        /// </summary>		
		      		  
  
        public string Account
        {
            get{ return _account; }
            set{ _account = value; }
        }    
      
		/// <summary>
		/// UserName
        /// </summary>		
		      		  
  
        public string UserName
        {
            get{ return _username; }
            set{ _username = value; }
        }    
      
		/// <summary>
		/// Password
        /// </summary>		
		      		  
  
        public string Password
        {
            get{ return _password; }
            set{ _password = value; }
        }    
      
		/// <summary>
		/// UserMobile
        /// </summary>		
		      		  
  
        public string UserMobile
        {
            get{ return _usermobile; }
            set{ _usermobile = value; }
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
		/// RID
        /// </summary>		
		      		  
  
        public Guid RID
        {
            get{ return _rid; }
            set{ _rid = value; }
        }    
      
		/// <summary>
		/// RoleName
        /// </summary>		
		      		  
  
        public string RoleName
        {
            get{ return _rolename; }
            set{ _rolename = value; }
        }    
      
		   
	}
}