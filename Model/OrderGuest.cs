using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace TravelAgency.Model
{
	 	//OrderGuest
		[Serializable]
	public partial class OrderGuest
	{
        		                  
    private int _id;
        		                  
    private int? _ordersid;
        		                  
    private string _guestid;
        		                  
    private string _guesttype;
        		                  
    private string _guestname;
        		                  
    private string _guestnamepinyin;
        		                  
    private string _guestsex;
        		                  
    private DateTime? _guestbirthday;
        		                  
    private string _guestphone;
        		                  
    private string _guestwechat;
        		                  
    private string _guestemail;
        		                  
    private string _guestpassportno;
        		                  
    private string _guestlastnighthotel;
        		                  
    private string _guestcountry;
        		                  
    private decimal? _price;
        		                  
    private int? _position;
        
    /// <summary>
		/// Id
        /// </summary>		
		      		  
  
        public int Id
        {
            get{ return _id; }
            set{ _id = value; }
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
		/// GuestId
        /// </summary>		
		      		  
  
        public string GuestId
        {
            get{ return _guestid; }
            set{ _guestid = value; }
        }    
      
		/// <summary>
		/// GuestType
        /// </summary>		
		      		  
  
        public string GuestType
        {
            get{ return _guesttype; }
            set{ _guesttype = value; }
        }    
      
		/// <summary>
		/// GuestName
        /// </summary>		
		      		  
  
        public string GuestName
        {
            get{ return _guestname; }
            set{ _guestname = value; }
        }    
      
		/// <summary>
		/// GuestNamePinYin
        /// </summary>		
		      		  
  
        public string GuestNamePinYin
        {
            get{ return _guestnamepinyin; }
            set{ _guestnamepinyin = value; }
        }    
      
		/// <summary>
		/// GuestSex
        /// </summary>		
		      		  
  
        public string GuestSex
        {
            get{ return _guestsex; }
            set{ _guestsex = value; }
        }    
      
		/// <summary>
		/// GuestBirthday
        /// </summary>		
		        		  
  
        public DateTime? GuestBirthday
        {
            get{ return _guestbirthday; }
            set{ _guestbirthday = value; }
        }    
      
		/// <summary>
		/// GuestPhone
        /// </summary>		
		      		  
  
        public string GuestPhone
        {
            get{ return _guestphone; }
            set{ _guestphone = value; }
        }    
      
		/// <summary>
		/// GuestWeChat
        /// </summary>		
		      		  
  
        public string GuestWeChat
        {
            get{ return _guestwechat; }
            set{ _guestwechat = value; }
        }    
      
		/// <summary>
		/// GuestEMail
        /// </summary>		
		      		  
  
        public string GuestEMail
        {
            get{ return _guestemail; }
            set{ _guestemail = value; }
        }    
      
		/// <summary>
		/// GuestPassportNo
        /// </summary>		
		      		  
  
        public string GuestPassportNo
        {
            get{ return _guestpassportno; }
            set{ _guestpassportno = value; }
        }    
      
		/// <summary>
		/// GuestLastNightHotel
        /// </summary>		
		      		  
  
        public string GuestLastNightHotel
        {
            get{ return _guestlastnighthotel; }
            set{ _guestlastnighthotel = value; }
        }    
      
		/// <summary>
		/// GuestCountry
        /// </summary>		
		      		  
  
        public string GuestCountry
        {
            get{ return _guestcountry; }
            set{ _guestcountry = value; }
        }    
      
		/// <summary>
		/// Price
        /// </summary>		
		        		  
  
        public decimal? Price
        {
            get{ return _price; }
            set{ _price = value; }
        }    
      
		/// <summary>
		/// Position
        /// </summary>		
		        		  
  
        public int? Position
        {
            get{ return _position; }
            set{ _position = value; }
        }    
      
		   
	}
}