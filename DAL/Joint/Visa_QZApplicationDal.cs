using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maticsoft.DBUtility;

namespace TravelAgency.DAL.Joint
{
    public class Visa_QZApplication
    {
        public HashSet<string> CheckVisaSendPayoutRequest(List<Model.Visa> visaList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select visa_id from qzapplication where visa_id in (");
            for (int i = 0; i < visaList.Count - 1; i++)
            {
                sb.AppendFormat("'{0}',", visaList[i].Visa_id);
            }
            sb.AppendFormat("'{0}')", visaList[visaList.Count - 1].Visa_id);
            DataSet ds = DbHelperSQL.Query(sb.ToString());
            HashSet<string> set = new HashSet<string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                set.Add(ds.Tables[0].Rows[i]["visa_id"].ToString());
            }

            return set;
        }

    }
}
