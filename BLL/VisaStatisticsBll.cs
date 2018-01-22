using System;
using System.Text;
using TravelAgency.DAL;

namespace TravelAgency.BLL
{
    public class VisaStatisticsBll:StatisticsBll
    {
        public VisaStatisticsBll()
        {
            this.tablename = "visa";
        }
    }
}