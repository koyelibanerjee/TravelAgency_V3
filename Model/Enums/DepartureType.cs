using System.Collections.Generic;

namespace TravelAgency.Model.Enums
{
    public static class DepartureType
    {
        public static Dictionary<string, int> Dict { get; set; }
        public static List<string> List { get; set; }
        //public static string[] CountryNameArr;
        static DepartureType()
        {
            Dict = new Dictionary<string, int>
            {
                {"单次", 1},
                {"单次30", 2},
                {"冲绳单次", 3},
                {"冲绳三年", 4},
                {"东北1单次", 5},
                {"东北1三年", 6},
                {"东北2A三年", 7},
                {"东北2B三年", 8},
                {"东北2C三年", 9},
                {"东北2D三年", 10},
                {"普通三年", 11},
                {"五年多次", 12},
                {"香港", 13}
            };

            List = new List<string>
            {
                "单次",
            "单次30",
            "冲绳单次",
            "冲绳三年",
            "东北1单次",
                "东北1三年",
                "东北2A三年",
                "东北2B三年",
                "东北2C三年",
                "东北2D三年",
                "普通三年",
            "五年多次",
            "香港"
        };

            //string CountrysString = "日本|韩国|泰国|澳大利亚|英国|美国|越南|加拿大|中国|马来西亚|新西兰|法国|德国|菲律宾";
            //CountryNameArr = CountrysString.Split('|');

        }


    }
}