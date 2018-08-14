using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DAL;

namespace TravelAgency.BLL
{
    public class SystemConfigBll
    {
        private DAL.SystemConfigDal dal = new SystemConfigDal();

        public string getConfigValue(string configname)
        {
            return dal.getConfigValue(configname);
        }

        public bool setConfigValue(string configname, string value)
        {
            return dal.setConfigValue(configname, value) > 0;
        }
    }
}
