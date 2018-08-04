using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace TravelAgency.Model
{
	 	//JobAssignment
		[Serializable]
	public partial class JobAssignment
	{
        		                  
    private int _id;
        		                  
    private DateTime? _entrytime;
        		                  
    private string _assignmenttoworkid;
        		                  
    private string _operatorid;
        		                  
    private DateTime? _assignmenttime;
        		                  
    private string _assignmenttousername;
        		                  
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
		/// EntryTime
        /// </summary>		
		        		  
  
        public DateTime? EntryTime
        {
            get{ return _entrytime; }
            set{ _entrytime = value; }
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
		/// OperatorId
        /// </summary>		
		      		  
  
        public string OperatorId
        {
            get{ return _operatorid; }
            set{ _operatorid = value; }
        }    
      
		/// <summary>
		/// AssignmentTime
        /// </summary>		
		        		  
  
        public DateTime? AssignmentTime
        {
            get{ return _assignmenttime; }
            set{ _assignmenttime = value; }
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