using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maticsoft.DBUtility;

namespace TravelAgency.DAL
{
    public partial class Orders
    {


        public Dictionary<string, decimal> GetOrderOnlineTotal(List<Model.Orders> ordersList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select orderno,total=sum(amount) from orderinfo where ");
            if (ordersList.Count > 0)
            {
                sb.Append(" orderno in (");
                foreach (var item in ordersList)
                {
                    sb.Append("'" + item.OrderNo + "',");
                }
            }
            string sql = sb.ToString().TrimEnd(',');
            sql += ") group by orderno";
            return GetHashTablesOfOrderOnlineTotalCount(DbHelperSQL.Query(sql));
        }


        /// <summary>
		/// 得到
		/// </summary>
		public Dictionary<string, decimal> GetHashTablesOfOrderOnlineTotalCount(DataSet ds)
        {
            Dictionary<string, decimal> res = new Dictionary<string, decimal>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; ++i)
            {
                var row = ds.Tables[0].Rows[i];

                if (row != null)
                {
                    if (row["orderno"] != null && row["orderno"].ToString() != "" 
                        && row["total"] != null && row["total"].ToString() != "")
                    {
                        res.Add(row["orderno"].ToString(), decimal.Parse(row["total"].ToString()));
                    }

                }

            }
            return res;
        }

    }
}
