using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace TravelAgency.Model
{
    //VisaInfo_Tmp
    [Serializable]
    public partial class VisaInfo_Tmp
    {

        private Guid _visainfo_id;

        private string _name;

        private string _englishname;

        private string _sex;

        private DateTime? _birthday;

        private string _passportno;

        private DateTime? _licencetime;

        private DateTime? _expirydate;

        private string _birthplace;

        private string _issueplace;

        private string _types;

        private string _country;

        private string _issueplaceenglish;

        private string _birthplaceenglish;

        private string _haschecked;

        private string _checkperson;

        private DateTime? _entrytime;

        private int? _district;

        /// <summary>
        /// VisaInfo_id
        /// </summary>		


        public Guid VisaInfo_id
        {
            get { return _visainfo_id; }
            set { _visainfo_id = value; }
        }

        /// <summary>
        /// Name
        /// </summary>		


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// EnglishName
        /// </summary>		


        public string EnglishName
        {
            get { return _englishname; }
            set { _englishname = value; }
        }

        /// <summary>
        /// Sex
        /// </summary>		


        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        /// <summary>
        /// Birthday
        /// </summary>		


        public DateTime? Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        /// <summary>
        /// PassportNo
        /// </summary>		


        public string PassportNo
        {
            get { return _passportno; }
            set { _passportno = value; }
        }

        /// <summary>
        /// LicenceTime
        /// </summary>		


        public DateTime? LicenceTime
        {
            get { return _licencetime; }
            set { _licencetime = value; }
        }

        /// <summary>
        /// ExpiryDate
        /// </summary>		


        public DateTime? ExpiryDate
        {
            get { return _expirydate; }
            set { _expirydate = value; }
        }

        /// <summary>
        /// Birthplace
        /// </summary>		


        public string Birthplace
        {
            get { return _birthplace; }
            set { _birthplace = value; }
        }

        /// <summary>
        /// IssuePlace
        /// </summary>		


        public string IssuePlace
        {
            get { return _issueplace; }
            set { _issueplace = value; }
        }

        /// <summary>
        /// Types
        /// </summary>		


        public string Types
        {
            get { return _types; }
            set { _types = value; }
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
        /// IssuePlaceEnglish
        /// </summary>		


        public string IssuePlaceEnglish
        {
            get { return _issueplaceenglish; }
            set { _issueplaceenglish = value; }
        }

        /// <summary>
        /// BirthPlaceEnglish
        /// </summary>		


        public string BirthPlaceEnglish
        {
            get { return _birthplaceenglish; }
            set { _birthplaceenglish = value; }
        }

        /// <summary>
        /// HasChecked
        /// </summary>		


        public string HasChecked
        {
            get { return _haschecked; }
            set { _haschecked = value; }
        }

        /// <summary>
        /// CheckPerson
        /// </summary>		


        public string CheckPerson
        {
            get { return _checkperson; }
            set { _checkperson = value; }
        }

        /// <summary>
        /// EntryTime
        /// </summary>		


        public DateTime? EntryTime
        {
            get { return _entrytime; }
            set { _entrytime = value; }
        }

        /// <summary>
        /// District
        /// </summary>		


        public int? District
        {
            get { return _district; }
            set { _district = value; }
        }


    }
}