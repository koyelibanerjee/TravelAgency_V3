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
    public class ActionRecordsTests
    {
        [TestMethod()]
        public void GetVisaHasTypedInNumTest()
        {
            //Assert.Fail();

            Assert.AreEqual(3,new DAL.ActionRecords().GetVisaHasTypedInNum(Guid.Parse("33589729-8FCF-4DFC-827A-137AB3C1B52F")));

        }
    }
}