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
    public class DateTimeFormatorTests
    {
        [TestMethod()]
        public void DateTimeFormatTest()
        {
            Console.WriteLine(DateTime.Now.ToString()); //默认的就是"2018/1/10 19:31:33"
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmss"));
            Console.WriteLine(DateTime.Now.ToString("d-mmm-yy"));
            Console.WriteLine(DateTime.Now.ToLongTimeString());
        }

        [TestMethod()]
        public void CheckPhoneValidTest()
        {
            Assert.IsTrue(InfoChecker.CheckPhoneValid("13154632825"));
            Assert.IsTrue(InfoChecker.CheckPhoneValid("1234567"));
            Assert.IsTrue(InfoChecker.CheckPhoneValid("12345678901"));
            Assert.IsFalse(InfoChecker.CheckPhoneValid("123456789011"));
            Assert.IsFalse(InfoChecker.CheckPhoneValid("123456"));

        }




    }
}
