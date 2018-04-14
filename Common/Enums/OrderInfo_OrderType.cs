using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Common.Enums
{
    public class OrderInfo_OrderType
    {
        public static Dictionary<int, string> keyValueMap = new Dictionary<int, string>();
        public static Dictionary<string, int> valueKeyMap = new Dictionary<string, int>();
        static OrderInfo_OrderType()
        {
            var list = new BLL.Enums_OrderInfo_OrderType().GetModelList(string.Empty);
            foreach (var item in list)
            {
                keyValueMap.Add(item.TypeNo, item.TypeName);
                valueKeyMap.Add(item.TypeName, item.TypeNo);
            }
        }

        public static int ValueToKey(string value)
        {
            if (valueKeyMap.ContainsKey(value))
                return valueKeyMap[value];
            else
                return -1;
        }

        public static string KeyToValue(int key)
        {
            if (keyValueMap.ContainsKey(key))
                return keyValueMap[key];
            else return null;
        }

    }
}
