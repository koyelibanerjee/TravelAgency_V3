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
        public string TableName { get { return "ConsulateCharge"; } }
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
            return CommonBll.GetFieldList(TableName, "Country");
        }

        public List<string> GetTypeList()
        {
            return CommonBll.GetFieldList(TableName, "Type");
        }

        public List<string> GetDepartureTypeList()
        {
            return CommonBll.GetFieldList(TableName, "DepartureType");
        }

        public List<string> GetConsulateCostList()
        {
            return CommonBll.GetFieldList(TableName, "ConsulateCost");
        }

        public List<string> GetVisaPersonCostList()
        {
            return CommonBll.GetFieldList(TableName, "VisaPersonCost");
        }
        public List<string> GetInvitationCostList()
        {
            return CommonBll.GetFieldList(TableName, "InvitationCost");
        }

    }
}

