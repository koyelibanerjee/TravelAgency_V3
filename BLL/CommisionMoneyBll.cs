using System;
using System.Data;
using System.Collections.Generic;

using TravelAgency.Model;
namespace TravelAgency.BLL
{
	/// <summary>
	/// CommisionMoney
	/// </summary>
	public partial class CommisionMoney
	{
        public List<Model.CommisionMoney> GetListByPageOrderById
    (int pageIndex, int pageSize, string where)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;

            DataSet ds = dal.GetDataByPageOrderById(start, end, where);
            DataTable dt = ds.Tables[0];
            return DataTableToList(dt);
        }
    }
}

