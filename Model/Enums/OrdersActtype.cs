﻿using System.Collections.Generic;

namespace TravelAgency.Model.Enums
{
    public class OrdersActtype
    {
        public static List<int> keyList = new List<int>()
        {
            1,
            2,
            11,
            12
        };

        public static List<string> valueList = new List<string>()
        {
            "客服:录入订单",
            "客服:确认订单",
            "操作:开始处理",
            "操作:处理完成"
        };


        public static int Value2Key(string value)
        {
            return keyList[valueList.IndexOf(value)];
        }

        public static string Key2Value(int key)
        {
            return valueList[keyList.IndexOf(key)];
        }

    }
}
