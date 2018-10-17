using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelAgency.BLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.BLL.Tests
{
    [TestClass()]
    public class VisaTests
    {
        //[TestMethod()]
        //public void CopyVisaTest()
        //{
        //    BLL.Visa bll = new Visa();
        //    var model = bll.GetModel(Guid.Parse("0B3F8CDF-038D-402C-9405-0D2989A58436"));
        //    var copyModel = bll.CopyNewGroupNoVisa(model);
        //    Assert.AreEqual(model.GroupNo + "_2", copyModel.GroupNo);

        //    bll.Add(copyModel);
        //    copyModel = bll.CopyNewGroupNoVisa(model);
        //    Assert.AreEqual(model.GroupNo + "_3", copyModel.GroupNo);
        //}

        [TestMethod()]
        public void GetListByPageTest()
        {
            BLL.Visa bll = new Visa();
            long total = 0;
            int []pageSize = new []{50,100,300,1000,3000,10000};
            int testtime = 50;
            StringBuilder sb = new StringBuilder();
            for (int pageSizeIdx = 0; pageSizeIdx < pageSize.Length; pageSizeIdx++)
            {
                total = 0;
                for (int i = 0; i != testtime; i++)
                {
                    Stopwatch sw = Stopwatch.StartNew();

                    var list = bll.GetListByPage(1, pageSize[pageSizeIdx], "");
                    var span = sw.ElapsedMilliseconds;
                    total += span;
                }
                sb.Append($"pagesize:{pageSize[pageSizeIdx]},testtime:{testtime},total:{total},avg time:{total/testtime}ms\n");
            }



            string str = sb.ToString();

        }
    }
}