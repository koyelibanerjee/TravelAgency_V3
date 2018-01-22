using System;
using System.Text;
using TravelAgency.DAL;

namespace TravelAgency.BLL
{
    public class VisaInfoStatisticsBll:StatisticsBll
    {
        public VisaInfoStatisticsBll()
        {
            this.tablename = "visainfo";
        }
    }
}