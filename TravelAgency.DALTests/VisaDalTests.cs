using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.DAL.Tests
{
    [TestClass()]
    public class VisaDalTests
    {
        [TestMethod()]
        public void GetLastRecordOfTheDayTest()
        {
            Visa dal = new Visa();
            dal.GetLastRecordOfTheDay(DateTime.Parse("2017/12/27"));
            

        }
    }
}