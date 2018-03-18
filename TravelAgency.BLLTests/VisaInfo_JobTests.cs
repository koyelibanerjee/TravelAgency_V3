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
    public class VisaInfo_JobTests
    {
        [TestMethod()]
        public void GetModelListByPageTest()
        {
            var list = new BLL.VisaInfo_Job().GetModelListByPage("", "", 10, 1);

        }
    }
}