using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace TravelAgency.Model
{
    //ActionRecords
    [Serializable]
    public partial class ActionRecords
    {

        private int _id;

        private string _acttype;

        private string _workid;

        private string _username;

        private Guid _visainfo_id;

        private Guid _visa_id;

        private string _type;

        private DateTime? _entrytime;

        private string _country;

        private int? _district;

        /// <summary>
        /// id
        /// </summary>		


        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// ActType
        /// </summary>		


        public string ActType
        {
            get { return _acttype; }
            set { _acttype = value; }
        }

        /// <summary>
        /// WorkId
        /// </summary>		


        public string WorkId
        {
            get { return _workid; }
            set { _workid = value; }
        }

        /// <summary>
        /// UserName
        /// </summary>		


        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        /// <summary>
        /// VisaInfo_id
        /// </summary>		


        public Guid VisaInfo_id
        {
            get { return _visainfo_id; }
            set { _visainfo_id = value; }
        }

        /// <summary>
        /// Visa_id
        /// </summary>		


        public Guid Visa_id
        {
            get { return _visa_id; }
            set { _visa_id = value; }
        }

        /// <summary>
        /// Type
        /// </summary>		


        public string Type
        {
            get { return _type; }
            set { _type = value; }
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
        /// Country
        /// </summary>		


        public string Country
        {
            get { return _country; }
            set { _country = value; }
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