using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.BLL
{
    public class UtilsBll
    {
        public static string getClientNameNoHR(string custName)
        {
            if (custName.Contains("-"))
                custName = custName.Substring(0, custName.IndexOf("-"));
            return custName;
        }

    }
}
