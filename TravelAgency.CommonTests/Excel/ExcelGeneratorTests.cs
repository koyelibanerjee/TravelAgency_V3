using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.Common.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Common.Excel.Tests
{
    [TestClass()]
    public class ExcelGeneratorTests
    {
        [TestMethod()]
        public void Get8PassPicTableTest()
        {
            ExcelGenerator.Get8PassPicTable(null);
        }

        [TestMethod()]
        public void TestGenTest()
        {
            ExcelGenerator.TestGen();
        }
    }
}