using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maticsoft.DBUtility;

namespace TravelAgency.DAL
{
    public class VisaTypedInCount
    {
        public DataSet GetVisaTypedInCountModels(List<Model.Visa> visaList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select Visa_id, COUNT(distinct VisaInfo_id) as TypedInNum from ActionRecords where ActType = '02录入做资料' ");
            if (visaList.Count > 0)
            {
                sb.Append(" and visa_id in (");
                foreach (var visa in visaList)
                {
                    sb.Append("'" + visa.Visa_id + "',");
                }
            }
            string sql = sb.ToString().TrimEnd(',');
            sql += ") group by visa_id";
           return DbHelperSQL.Query(sql);
        }

        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TravelAgency.Model.VisaTypedInCount DataRowToModel(DataRow row)
        {
            TravelAgency.Model.VisaTypedInCount model = new TravelAgency.Model.VisaTypedInCount();
            if (row != null)
            {
                if (row["Visa_id"] != null && row["Visa_id"].ToString() != "")
                {
                    model.Visa_id = new Guid(row["Visa_id"].ToString());
                }
                if (row["TypedInNum"] != null)
                {
                    model.TypedInNum = int.Parse(row["TypedInNum"].ToString());
                }
            }
            return model;
        }

    }
}
