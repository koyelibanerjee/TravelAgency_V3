using System;
using System.Data;
using System.Collections.Generic;
using TravelAgency.Model;
namespace TravelAgency.BLL
{
	/// <summary>
	/// ClientCharge
	/// </summary>
	public partial class ClientCharge
	{

        public string TableName { get { return "ClientCharge"; } }


        public List<Model.ClientCharge> GetListByPageOrderByClientName
            (int pageIndex, int pageSize, string where)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;

            DataSet ds = dal.GetDataByPageOrderByClientName(start, end, where);
            DataTable dt = ds.Tables[0];
            return DataTableToList(dt);
        }

        public List<string> GetClientChargeList()
        {
            return CommonBll.GetFieldList(TableName, "Charge");
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

    }
}

