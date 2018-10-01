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

        public static void GetVisaTypesCondition(List<string> conditionsList, string visaTypes)
        {
            string condition = null;
            switch (visaTypes.Trim())
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

        public static void GetFuzzyQueryCondition(List<string> conditionsList, string fieldName, string value)
        {
            if (!string.IsNullOrEmpty(value.Trim()))
                conditionsList.Add($" ({fieldName} like '%{value}%' ) ");
        }

        public static void GetSpanQueryCondition(List<string> conditionsList, string fieldName, string value1, string value2)
        {
            if (!string.IsNullOrEmpty(value1.Trim()) && !string.IsNullOrEmpty(value2.Trim()))
                conditionsList.Add(" ({fieldName} between '{value1}' and '{value2}') ");
        }


        public static string GetSearchConditon(List<string> conditionList)
        {
            string[] arr = conditionList.ToArray();
            string where = string.Join(" and ", arr);
            return where;
        }


    }
}
