using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Model;

namespace TravelAgency.Common.Tests
{
    [TestClass()]
    public class InfoCheckerTests
    {
        [TestMethod()]
        public void CheckByPinYinTest()
        {
            Assert.IsTrue(InfoChecker.CheckByPinYin("杨小鹏", "YANG XIAOPENG"));
            Assert.IsFalse(InfoChecker.CheckByPinYin("杨小鹏", "YAN XIAOPENG"));
            Assert.IsTrue(InfoChecker.CheckByPinYin("杨小鹏", "YANG    XIAOPENG"));
            Assert.IsTrue(InfoChecker.CheckByPinYin("杨小鹏", "YANG    xiaopeng"));

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

        [TestMethod()]
        public void CheckTheSameTest()
        {
            Model.VisaInfo visaInfo1 = new VisaInfo() { VisaInfo_id = new Guid(), Name = "杨小鹏", ExpiryDate = DateTime.Now, Position = 1 };
            Model.VisaInfo visaInfo2 = visaInfo1.ToObjectCopy();
            Assert.IsTrue(InfoChecker.CheckVisaInfoSame(visaInfo1, visaInfo2));
            visaInfo2.Name = "杨小1";
            Assert.IsFalse(InfoChecker.CheckVisaInfoSame(visaInfo1, visaInfo2));
            visaInfo2.Name = "";
            Assert.IsFalse(InfoChecker.CheckVisaInfoSame(visaInfo1, visaInfo2));
            visaInfo2.Name = null;
            Assert.IsFalse(InfoChecker.CheckVisaInfoSame(visaInfo1, visaInfo2));
        }

        [TestMethod()]
        public void CheckNotExpireTest()
        {
            DateTime date = DateTime.Now.AddMonths(-3);
           Assert.IsTrue(!InfoChecker.CheckNotExpire(date));
            date = DateTime.Now.AddMonths(3);
            Assert.IsTrue(!InfoChecker.CheckNotExpire(date));
            date = DateTime.Now.AddMonths(6);
            Assert.IsTrue(InfoChecker.CheckNotExpire(date));
            date = DateTime.Now.AddMonths(7);
            Assert.IsTrue(InfoChecker.CheckNotExpire(date));
        }
    }
}