using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelAgency.BLL;

namespace DatabaseStressTest
{
    class Program
    {
        static void testVisa(object no)
        {
            int number = 0;
            if (no != null)
                number = (int)no;
            TravelAgency.BLL.Visa bll = new Visa();
            long total = 0;
            int[] pageSize = new[] { 50, 100, 300, 1000, 3000, 10000 };
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
                sb.Append($"pagesize:{pageSize[pageSizeIdx]},testtime:{testtime},total:{total},avg time:{total / testtime}ms\n");
            }

            File.WriteAllText($"testVisaLocal_{number}.txt", sb.ToString());
        }


        static void testVisaInfo(object no)
        {
            int number = 0;
            if (no != null)
                number = (int)no;
            TravelAgency.BLL.VisaInfo bll = new VisaInfo();
            long total = 0;
            int[] pageSize = new[] { 50, 100, 300, 1000, 3000, 10000 };
            int testtime = 50;
            StringBuilder sb = new StringBuilder();
            for (int pageSizeIdx = 0; pageSizeIdx < pageSize.Length; pageSizeIdx++)
            {
                total = 0;
                for (int i = 0; i != testtime; i++)
                {
                    Stopwatch sw = Stopwatch.StartNew();

                    var list = bll.GetListByPage("", "", 1, pageSize[pageSizeIdx]);
                    var span = sw.ElapsedMilliseconds;
                    total += span;
                }
                sb.Append($"pagesize:{pageSize[pageSizeIdx]},testtime:{testtime},total:{total},avg time:{total / testtime}ms\n");
            }

            File.WriteAllText($"testVisaInfoLocal_{number}.txt", sb.ToString());
        }

        

        static void Main(string[] args)
        {
            int thNum = 16; //换了服务器后，最大的优点就是多线程的时候，本机不会CPU使用率很高，因为之前就是一直在等待服务器CPU的响应
            for (int i = 0; i < thNum; i++)
            {
                new Thread(testVisa).Start(i);
                //new Thread(testVisaInfo).Start(i);
            }
            Console.Read();
        }
    }
}
