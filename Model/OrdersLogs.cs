using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace TravelAgency.Model
{
	 	//OrdersLogs
		public class OrdersLogs
	{
        		                  
    private int? _id;
        		                  
    private int? _acttype;
        		                  
    private string _username;
        		                  
    private int? _ordersid;
        		                  
    private DateTime? _entrytime;
        		                  
    private string _workid;
        		                  
    private string _orderno;
        
    /// <summary>
		/// id
        /// </summary>		
		        		  
  
        public int? id
        {
            get{ return _id; }
            set{ _id = value; }
        }    
      
		/// <summary>
		/// ActType
        /// </summary>		
		        		  
  
        public int? ActType
        {
            get{ return _acttype; }
            set{ _acttype = value; }
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
		/// OrdersId
        /// </summary>		
		        		  
  
        public int? OrdersId
        {
            get{ return _ordersid; }
            set{ _ordersid = value; }
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
		/// WorkId
        /// </summary>		
		      		  
  
        public string WorkId
        {
            get{ return _workid; }
            set{ _workid = value; }
        }    
      
		/// <summary>
		/// OrderNo
        /// </summary>		
		      		  
  
        public string OrderNo
        {
            get{ return _orderno; }
            set{ _orderno = value; }
        }    
      
		   
	}
}