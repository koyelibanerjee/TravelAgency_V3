using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Common;

namespace TravelAgency.BLL
{
    public class DistrictCondAppender
    {
        public static List<string> AddDistrictCondition(List<string> condi)
        {
            if (GlobalUtils.LoginUser.District != 0)
                condi.Add($" ((District = {GlobalUtils.LoginUser.District}) or " +
                          $"(IsOutDelivery = 1 and OutDeliveryPlace = '" +
                          $"{TravelAgency.Model.Enums.District.DistrictList[GlobalUtils.LoginUser.District.Value]}')) ");
            return condi;
        }
    }
}
