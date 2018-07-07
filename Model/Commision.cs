using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace TravelAgency.Model
{
	 	//Commision
		[Serializable]
	public partial class Commision
	{
        		                  
    private int _id;
        		                  
    private string _country;
        		                  
    private string _consulardistrict;
        		                  
    private string _typeinway;
        		                  
    private string _departuretype;
        		                  
    private decimal? _consulatecost;
        		                  
    private decimal? _typeincost;
        		                  
    private decimal? _sendvisacost;
        		                  
    private decimal? _operatorcommision;
        		                  
    private decimal? _fetchvisacost;
        		                  
    private decimal? _othercost;
        		                  
    private decimal? _othercost2;
        		                  
    private decimal? _visacost;
        
    /// <summary>
		/// Id
        /// </summary>		
		      		  
  
        public int Id
        {
            get{ return _id; }
            set{ _id = value; }
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
		/// ConsularDistrict
        /// </summary>		
		      		  
  
        public string ConsularDistrict
        {
            get{ return _consulardistrict; }
            set{ _consulardistrict = value; }
        }    
      
		/// <summary>
		/// TypeInWay
        /// </summary>		
		      		  
  
        public string TypeInWay
        {
            get{ return _typeinway; }
            set{ _typeinway = value; }
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
		/// ConsulateCost
        /// </summary>		
		        		  
  
        public decimal? ConsulateCost
        {
            get{ return _consulatecost; }
            set{ _consulatecost = value; }
        }    
      
		/// <summary>
		/// TypeInCost
        /// </summary>		
		        		  
  
        public decimal? TypeInCost
        {
            get{ return _typeincost; }
            set{ _typeincost = value; }
        }    
      
		/// <summary>
		/// SendVisaCost
        /// </summary>		
		        		  
  
        public decimal? SendVisaCost
        {
            get{ return _sendvisacost; }
            set{ _sendvisacost = value; }
        }    
      
		/// <summary>
		/// OperatorCommision
        /// </summary>		
		        		  
  
        public decimal? OperatorCommision
        {
            get{ return _operatorcommision; }
            set{ _operatorcommision = value; }
        }    
      
		/// <summary>
		/// FetchVisaCost
        /// </summary>		
		        		  
  
        public decimal? FetchVisaCost
        {
            get{ return _fetchvisacost; }
            set{ _fetchvisacost = value; }
        }    
      
		/// <summary>
		/// OtherCost
        /// </summary>		
		        		  
  
        public decimal? OtherCost
        {
            get{ return _othercost; }
            set{ _othercost = value; }
        }    
      
		/// <summary>
		/// OtherCost2
        /// </summary>		
		        		  
  
        public decimal? OtherCost2
        {
            get{ return _othercost2; }
            set{ _othercost2 = value; }
        }    
      
		/// <summary>
		/// VisaCost
        /// </summary>		
		        		  
  
        public decimal? VisaCost
        {
            get{ return _visacost; }
            set{ _visacost = value; }
        }    
      
		   
	}
}