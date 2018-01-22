using System;
using System.Data;
using System.Collections.Generic;
using TravelAgency.Model;
namespace TravelAgency.BLL
{
    /// <summary>
    /// ConsulateCharge
    /// </summary>
    public partial class ConsulateCharge
    {
        public List<string> GetCountryList()
        {
            return dal.GetCountryList();
        }

        public List<string> GetTypeList()
        {
            return dal.GetTypeList();
        }

        public List<string> GetDepartureTypeList()
        {
            return dal.GetDepartureTypeList();
        }

    }
}

