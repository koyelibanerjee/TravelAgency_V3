using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Common.Enums
{
    public class OrderInfo_OrderInfoState
    {
        public static Dictionary<int, string> keyValueMap = new Dictionary<int, string>();
        public static Dictionary<string, int> valueKeyMap = new Dictionary<string, int>();
        static OrderInfo_OrderInfoState()
        {
            var list = new BLL.Enums_OrderInfo_OrderInfoState().GetModelList(string.Empty);
            foreach (var item in list)
            {
                keyValueMap.Add(item.StateNo.Value, item.StateInfo);
                valueKeyMap.Add(item.StateInfo, item.StateNo.Value);
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

        public static string KeyToValue(int? key) //这种表应该在数据库加非空约束
        {
            if (!key.HasValue)
                return null;
            if (keyValueMap.ContainsKey(key.Value))
                return keyValueMap[key.Value];
            else return null;
        }

    }
}
