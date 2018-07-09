using System;
using System.Data;
using System.Collections.Generic;
using TravelAgency.Model;
namespace TravelAgency.BLL
{
	/// <summary>
	/// Enums_OrderInfo_PaymentPlatform
	/// </summary>
	public partial class Enums_OrderInfo_PaymentPlatform
	{
	    public static Dictionary<int, string> keyValueMap = new Dictionary<int, string>();
	    public static Dictionary<string, int> valueKeyMap = new Dictionary<string, int>();

	    static Enums_OrderInfo_PaymentPlatform()
        {
            var list = new Enums_OrderInfo_PaymentPlatform().GetModelList(String.Empty);
            foreach (var item in list)
            {
                keyValueMap.Add(item.PlatNo, item.PlateName);
                valueKeyMap.Add(item.PlateName, item.PlatNo);
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

