using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace TravelAgency.Model
{
	 	//WorkerQueue
		[Serializable]
	public partial class WorkerQueue
	{
        		                  
    private int _id;
        		                  
    private string _workid;
        		                  
    private string _username;
        		                  
    private bool? _isbusy;
        		                  
    private bool? _canaccept;
        		                  
    private int? _priority;
        		                  
    private int? _district;
        
    /// <summary>
		/// Id
        /// </summary>		
		      		  
  
        public int Id
        {
            get{ return _id; }
            set{ _id = value; }
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
		/// UserName
        /// </summary>		
		      		  
  
        public string UserName
        {
            get{ return _username; }
            set{ _username = value; }
        }    
      
		/// <summary>
		/// IsBusy
        /// </summary>		
		        		  
  
        public bool? IsBusy
        {
            get{ return _isbusy; }
            set{ _isbusy = value; }
        }    
      
		/// <summary>
		/// CanAccept
        /// </summary>		
		        		  
  
        public bool? CanAccept
        {
            get{ return _canaccept; }
            set{ _canaccept = value; }
        }    
      
		/// <summary>
		/// Priority
        /// </summary>		
		        		  
  
        public int? Priority
        {
            get{ return _priority; }
            set{ _priority = value; }
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