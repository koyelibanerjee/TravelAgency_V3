using System.Collections.Generic;
using System.Security.AccessControl;

namespace TravelAgency.Common
{
    public static class CountryCode
    {
        public static Dictionary<string, string> Dict = new Dictionary<string, string>();

        public static string[] CountryNameArr;
        static CountryCode()
        {
            Dict.Add("日本", "JP");
            Dict.Add("韩国", "KR");
            Dict.Add("泰国", "TH");
            Dict.Add("澳大利亚", "AU");
            Dict.Add("英国", "GB");
            Dict.Add("美国", "US");
            Dict.Add("越南", "VN");
            Dict.Add("加拿大", "CA");
            Dict.Add("中国", "CN");
            Dict.Add("马来西亚", "MY");
            Dict.Add("新西兰", "NZ");
            Dict.Add("法国", "FR");
            Dict.Add("德国", "DE");
            Dict.Add("菲律宾", "PH");
            Dict.Add("捷克", "CZ");
            Dict.Add("瑞士", "CH");
            Dict.Add("西班牙", "ES");
            Dict.Add("意大利", "IT");
            Dict.Add("荷兰", "NL");
            Dict.Add("冰岛", "IS");
            Dict.Add("南非", "ZA");
            Dict.Add("奥地利", "AT");
            Dict.Add("丹麦", "DK");
            Dict.Add("波兰", "PL");

            string CountrysString = "日本|韩国|泰国|澳大利亚|英国|美国|越南|加拿大|中国|马来西亚|新西兰|法国|德国|菲律宾|捷克|瑞士|西班牙|意大利|荷兰|冰岛|南非|奥地利|丹麦|波兰";
            CountryNameArr = CountrysString.Split('|');

        }


    }
}