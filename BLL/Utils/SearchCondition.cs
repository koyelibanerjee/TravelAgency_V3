using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.BLL
{
    public class SearchCondition
    {

        //private string getKeyValueCondition(string key, List<string> values)
        //{
        //    string condition = $" (";

        //    for (int i = 0; i < values.Count; i++)
        //    {
        //        if (values[i] == null)
        //        {
                    
        //        }
        //    }
        //}

        public static void GetVisaTypesCondition(List<string> conditionsList,string visaTypes)
        {
            string condition = null;
            switch (visaTypes)
            {
                case "全部":
                    break;
                case "未记录":
                    condition = " (Types is null or Types='') ";
                    break;
                case "个签":
                    condition = " (Types = '个签') ";
                    break;
                case "团签":
                    condition = " (Types = '团签') ";
                    break;
                case "团做个":
                    condition = " (Types = '团做个') ";
                    break;
                case "个签&&团做个":
                    condition = " (Types = '团做个' or Types = '个签') ";
                    break;
                case "缺省":
                    condition = " (Types = '缺省') ";
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(condition))
                conditionsList.Add(condition);
        }

        public static void GetVisaPaymentNoCondion(List<string> conditionsList, string paymentNo)
        {
            if (!string.IsNullOrEmpty(paymentNo))
            {
                conditionsList.Add($" (paymentNo like '%{paymentNo}%' ) ");
            }
        }


    }
}
