using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maticsoft.DBUtility;

namespace TravelAgency.DAL.Joint
{
    public class Visa_ClaimMoneyDal
    {

        public int GetSaleCommisionCount(string timefrom, string timeto, string country, string departuretype,
            decimal price1, decimal price2 = -1)
        {
            string sql = $" select count(1) from Visa " +
                         $"inner join ClaimMoney as cm on cm.groupNo=Visa.GroupNo " +
                         $"where visa.EntryTime between '{timefrom}' and '{timeto}' " +
                         $"and Visa.Number is not null and Visa.Number>0 " +
                         $"and Country = '{country}' and DepartureType = '{departuretype}' ";


            if (price2 != -1)
                sql += $"and cm.Amount/Visa.Number >= {price1} and cm.Amount/Visa.Number <= {price2 - 1}";
            else
                sql += $"and cm.Amount/Visa.Number >= {price1}";
            object o = DbHelperSQL.GetSingle(sql);
            if (o == null)
                return -1;
            return Convert.ToInt32(o);
        }
    }
}
