using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.BLL.Tests
{
    [TestClass()]
    public class StatisticsBllTests
    {
        StatisticsBll bll = new StatisticsBll();
        [TestMethod()]
        public void GetVisaInfoCountByTimeSpanTest()
        {
            //Console.WriteLine(bll.GetVisaCountByTimeSpan(Date));
            //Console.WriteLine(bll.GetVisaInfoCountOfCurYear());
            //Console.WriteLine(bll.GetVisaInfoCountOfCurMonth());
            //Console.WriteLine(bll.GetVisaInfoCountOfCurWeek());
        }
    }
}