using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Model.Enums
{
    public class District
    {
        public static List<string> DistrictList = new List<string>()
        {
            "成都","重庆"
        };

        public static List<string> DistrictPrefix = new List<string>()
        {
            "QZC","QZQ"
        };

        public static string getDisPrefix(string disname)
        {
            int idx = DistrictList.IndexOf(disname);
            return DistrictPrefix[idx];
        }

        public static string key2Value(int key)
        {
            return DistrictList[key];
        }

        public static int value2Key(string value)
        {
            return DistrictList.IndexOf(value);
        }

    }
}
