using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.BLL
{
    public class VisaClaimChecker
    {

        public static bool checkGreaterThanCost(List<Model.Visa> list)
        {
            BLL.QZApplication qzApplication = new QZApplication();
            foreach (var visa in list)
            {
                var qzappList = qzApplication.GetModelList($" visa_id = '{visa.Visa_id}'");
                if (qzappList.Count > 0) //TODO:对应关系???,多条or?
                {
                    if ((qzappList[0].Price ?? 0) * (qzappList[0].Number ?? 0) > (visa.ActuallyAmount ?? 0))
                        return false;
                }
            }
            return true;
        }

    }
}
