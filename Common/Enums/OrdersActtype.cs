using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Common.Enums
{
    public class OrdersActtype
    {
        private static List<int> keyList = new List<int>()
        {
            1,
            2,
            11,
            12
        };

        private static List<string> valueList = new List<string>()
        {
            "客服:录入订单",
            "客服:订单确认",
            "操作:开始处理",
            "操作:处理完成"
        };


        public static int value2Key(string value)
        {
            return keyList[valueList.IndexOf(value)];
        }


        public static string value2Key(int key)
        {
            return valueList[keyList.IndexOf(key)];
        }


    }
}
