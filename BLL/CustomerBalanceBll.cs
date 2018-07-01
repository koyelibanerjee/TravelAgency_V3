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
        public List<Model.CustomerBalance> GetClientBalanceListOrderByBalanceasc(string clientName)
        {

            var balanceList = GetModelList(" CustomerName = '" + clientName + "' and BalanceAmount > 0");
            balanceList.Sort((b1, b2) => b1.BalanceAmount - b2.BalanceAmount < 0 ? -1 : 1);
            return balanceList;
        }

        public List<string> GetValidClientList()
        {
            return dal.GetValidCleintList();
        } 


    }
}

