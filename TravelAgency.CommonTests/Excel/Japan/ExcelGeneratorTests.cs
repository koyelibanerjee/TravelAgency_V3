using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.Common.Excel.Japan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Model;

namespace TravelAgency.Common.Excel.Japan.Tests
{
    [TestClass()]
    public class ExcelGeneratorTests
    {
        [TestMethod()]
        public void CheckGroupNoMatchTest()
        {
            List<Model.Visa> list= new List<Visa>();

            list.Add(new Visa() {GroupNo = "TOPC171214"});
            list.Add(new Visa() { GroupNo = "TOPC171214我玩" });

            Assert.IsTrue(ExcelGenerator.CheckGroupNoMatch(list));
            list.Add(new Visa() { GroupNo = "TOPC171211我玩" });
            Assert.IsFalse(ExcelGenerator.CheckGroupNoMatch(list));


        }

        [TestMethod()]
        public void GetTeamVisaExcelOfJapan()
        {
            //List<Model.visa>
        }


    }
}