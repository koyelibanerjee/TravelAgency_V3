using System;
using System.Data;
using System.Collections.Generic;
using TravelAgency.Model;
namespace TravelAgency.BLL
{
    /// <summary>
    /// Enums_OrderInfo_OrderInfoState
    /// </summary>
    public partial class Enums_OrderInfo_OrderInfoState
    {
        public static Dictionary<int, string> keyValueMap = new Dictionary<int, string>();
        public static Dictionary<string, int> valueKeyMap = new Dictionary<string, int>();
        static Enums_OrderInfo_OrderInfoState()
        {
            var list = new BLL.Enums_OrderInfo_OrderInfoState().GetModelList(string.Empty);
            foreach (var item in list)
            {
                keyValueMap.Add(item.StateNo, item.StateInfo);
                valueKeyMap.Add(item.StateInfo, item.StateNo);
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

