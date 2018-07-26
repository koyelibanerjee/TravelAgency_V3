using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace TravelAgency.Model
{
    //Commision_Sale
    [Serializable]
    public partial class Commision_Sale
    {

        private int _id;

        private string _country;

        private string _consulardistrict;

        private string _departuretype;

        private decimal? _companyprice;

        private decimal? _price1;

        private decimal? _commision1;

        private decimal? _margin1;

        private decimal? _price2;

        private decimal? _commision2;

        private decimal? _margin2;

        private decimal? _price3;

        private decimal? _commision3;

        private decimal? _margin3;

        private decimal? _directguestprice;

        private decimal? _directguestcommision;

        private decimal? _directguestmargin;

        private int? _salespersoncredits;

        /// <summary>
        /// Id
        /// </summary>		


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Country
        /// </summary>		


        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        /// <summary>
        /// ConsularDistrict
        /// </summary>		


        public string ConsularDistrict
        {
            get { return _consulardistrict; }
            set { _consulardistrict = value; }
        }

        /// <summary>
        /// DepartureType
        /// </summary>		


        public string DepartureType
        {
            get { return _departuretype; }
            set { _departuretype = value; }
        }

        /// <summary>
        /// CompanyPrice
        /// </summary>		


        public decimal? CompanyPrice
        {
            get { return _companyprice; }
            set { _companyprice = value; }
        }

        /// <summary>
        /// Price1
        /// </summary>		


        public decimal? Price1
        {
            get { return _price1; }
            set { _price1 = value; }
        }

        /// <summary>
        /// Commision1
        /// </summary>		


        public decimal? Commision1
        {
            get { return _commision1; }
            set { _commision1 = value; }
        }

        /// <summary>
        /// Margin1
        /// </summary>		


        public decimal? Margin1
        {
            get { return _margin1; }
            set { _margin1 = value; }
        }

        /// <summary>
        /// Price2
        /// </summary>		


        public decimal? Price2
        {
            get { return _price2; }
            set { _price2 = value; }
        }

        /// <summary>
        /// Commision2
        /// </summary>		


        public decimal? Commision2
        {
            get { return _commision2; }
            set { _commision2 = value; }
        }

        /// <summary>
        /// Margin2
        /// </summary>		


        public decimal? Margin2
        {
            get { return _margin2; }
            set { _margin2 = value; }
        }

        /// <summary>
        /// Price3
        /// </summary>		


        public decimal? Price3
        {
            get { return _price3; }
            set { _price3 = value; }
        }

        /// <summary>
        /// Commision3
        /// </summary>		


        public decimal? Commision3
        {
            get { return _commision3; }
            set { _commision3 = value; }
        }

        /// <summary>
        /// Margin3
        /// </summary>		


        public decimal? Margin3
        {
            get { return _margin3; }
            set { _margin3 = value; }
        }

        /// <summary>
        /// DirectGuestPrice
        /// </summary>		


        public decimal? DirectGuestPrice
        {
            get { return _directguestprice; }
            set { _directguestprice = value; }
        }

        /// <summary>
        /// DirectGuestCommision
        /// </summary>		


        public decimal? DirectGuestCommision
        {
            get { return _directguestcommision; }
            set { _directguestcommision = value; }
        }

        /// <summary>
        /// DirectGuestMargin
        /// </summary>		


        public decimal? DirectGuestMargin
        {
            get { return _directguestmargin; }
            set { _directguestmargin = value; }
        }

        /// <summary>
        /// SalesPersonCredits
        /// </summary>		


        public int? SalesPersonCredits
        {
            get { return _salespersoncredits; }
            set { _salespersoncredits = value; }
        }


    }
}