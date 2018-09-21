using System;
using System.Data;
using System.Collections.Generic;
using TravelAgency.Model;
namespace TravelAgency.BLL
{
    /// <summary>
    /// CustomerBalance
    /// </summary>
    public partial class CustomerBalance
    {
        public List<Model.CustomerBalance> GetClientBalanceListOrderByBalanceAsc(string clientName, string activityName)
        {
            //var balanceList = GetModelList(" CustomerName = '" + clientName + "' and BalanceAmount > 0");
            //balanceList.Sort((b1, b2) => b1.BalanceAmount - b2.BalanceAmount < 0 ? -1 : 1);
            string where = $" (CustomerName = '{clientName}' and BalanceAmount > 0 ";
            if (!string.IsNullOrEmpty(activityName))
                where += $" and ActivityName = '{activityName}') ";
            else
                where += $" and (len(ActivityName)=0 or ActivityName is null or ActivityName='无')) ";
            where += " order by BalanceAmount asc ";
            var balanceList = GetModelList(where);
            return balanceList;
        }

        public List<string> GetValidClientList()
        {
            return dal.GetValidCleintList();
        }


    }
}

