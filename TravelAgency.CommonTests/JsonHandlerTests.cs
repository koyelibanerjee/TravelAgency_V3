using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Common.Tests
{
    [TestClass()]
    public class JsonHandlerTests
    {
        [TestMethod()]
        public void GenJsonTest()
        {

            List<string> keyList = new List<string> { "a", "b", "c" };
            List<string> valueList = new List<string> { "aa", "bb", "cc" };


            string res = JsonHandler.GenJson(keyList, valueList);
        }
    }
}