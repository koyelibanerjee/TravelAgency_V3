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
                condi.Add($" (District = {GlobalUtils.LoginUser.District}) ");
            return condi;
        }

    }
}
