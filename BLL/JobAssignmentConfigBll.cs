using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.BLL
{
    public class JobAssignmentConfigBll
    {
        private BLL.SystemConfigBll bll = new SystemConfigBll();
        public bool getDistrictAssignmentEnable(int districtId)
        {
            return bll.getConfigValue($"district_{districtId}_jobassignment_enable") == "on";
        }

        public void setDistrictAssignmentEnable(int districtId, bool enable)
        {
            bll.setConfigValue($"district_{districtId}_jobassignment_enable", enable ? "on" : "off");
        }

    }
}
