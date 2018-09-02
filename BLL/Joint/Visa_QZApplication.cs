using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.BLL.Joint
{

    public class Visa_QZApplication
    {
        private DAL.Joint.Visa_QZApplication dal = new DAL.Joint.Visa_QZApplication();

        public HashSet<string> CheckVisaSendPayoutRequest(List<Model.Visa> visaList)
        {
            return dal.CheckVisaSendPayoutRequest(visaList);
        }

    }

}
