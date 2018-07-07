using System.Collections.Generic;

namespace TravelAgency.Model.Enums
{
    public static class DepartureType
    {
        public static Dictionary<string, int> Dict = new Dictionary<string, int>();

        //public static string[] CountryNameArr;
        static DepartureType()
        {
            Dict.Add("单次", 1);
            Dict.Add("单次30", 2);
            Dict.Add("冲绳单次", 3);
            Dict.Add("冲绳三年", 4);
            Dict.Add("东北1单次", 5);
            Dict.Add("东北1三年", 6);
            Dict.Add("东北2A三年", 7);
            Dict.Add("东北2B三年", 8);
            Dict.Add("东北2C三年", 9);
            Dict.Add("东北2D三年", 10);
            Dict.Add("普通三年", 11);
            Dict.Add("五年多次", 12);
            Dict.Add("香港", 13);

            //string CountrysString = "日本|韩国|泰国|澳大利亚|英国|美国|越南|加拿大|中国|马来西亚|新西兰|法国|德国|菲律宾";
            //CountryNameArr = CountrysString.Split('|');

        }


    }
}