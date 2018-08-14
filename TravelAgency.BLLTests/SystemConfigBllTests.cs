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
    public class SystemConfigBllTests
    {
        BLL.SystemConfigBll bll = new SystemConfigBll();
        [TestMethod()]
        public void getConfigValueTest()
        {
            string str = bll.getConfigValue("district_0_jobassignment_enable");
            Assert.IsTrue(str == "on");
            Assert.IsTrue(bll.getConfigValue("district_1_jobassignment_enable") == "on");

        }

        [TestMethod()]
        public void setConfigValueTest()
        {
            bll.setConfigValue("district_0_jobassignment_enable","off");
            Assert.IsTrue(bll.getConfigValue("district_0_jobassignment_enable") == "off");
        }
    }
}