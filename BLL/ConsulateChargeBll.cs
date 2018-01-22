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

        public List<Model.ConsulateCharge> GetListByPageOrderByCountry
    (int pageIndex, int pageSize, string where)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;

            DataSet ds = dal.GetDataByPageOrderByCountry(start, end, where);
            DataTable dt = ds.Tables[0];
            return DataTableToList(dt);
        }

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

