using System;
using System.Reflection;
using System.Text.RegularExpressions;
using TravelAgency.Common.PinyinParse;
using TravelAgency.Model;

namespace TravelAgency.Common
{
    public class InfoChecker
    {

        public static bool CheckByPinYin(string Name, string PinYin)
        {
            return
                PinYinConverterHelp.GetTotalPingYin(Name).TotalPingYin
                    .Contains(PinYin.Replace(" ", "").ToLower());
        }

        public static bool CheckPhoneValid(string phone)
        {
            return Regex.IsMatch(phone, "^\\d{7,11}$"); //电话为7-11位数字
        }

        public static bool CheckVisaInfoSame(VisaInfo model1, VisaInfo model2)
        {
            if (model1.VisaInfo_id != model2.VisaInfo_id)
            {
                throw new Exception("not even same VisaInfo_ID,can't compare!");
            }

            Type t = model1.GetType();
            PropertyInfo[] pis = t.GetProperties();
            for (int i = 0; i != pis.Length; ++i)
            {
                if (pis[i].GetValue(model1) == null && pis[i].GetValue(model2) == null)
                    continue;
                if ((pis[i].GetValue(model1) == null && pis[i].GetValue(model2) != null) ||
                    (pis[i].GetValue(model2) == null && pis[i].GetValue(model1) != null) ||
                    (!pis[i].GetValue(model1).Equals(pis[i].GetValue(model2))))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool CheckVisaSame(Visa model1, Visa model2)
        {
            if (model1.Visa_id != model2.Visa_id)
            {
                throw new Exception("not even same Visa_Id,can't compare!");
            }

            Type t = model1.GetType();
            PropertyInfo[] pis = t.GetProperties();
            for (int i = 0; i != pis.Length; ++i)
            {
                if (pis[i].GetValue(model1) == null && pis[i].GetValue(model2) == null)
                    continue;
                if ((pis[i].GetValue(model1) == null && pis[i].GetValue(model2) != null) ||
                    (pis[i].GetValue(model2) == null && pis[i].GetValue(model1) != null) ||
                    (!pis[i].GetValue(model1).Equals(pis[i].GetValue(model2))))
                {
                    return false;
                }
            }
            return true;
        }


    }
}