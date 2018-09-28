using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maticsoft.DBUtility;
using TravelAgency.Model;

namespace TravelAgency.DAL.Joint
{
    public class CustomerBalance_AuthUser
    {
        public List<Model.CustomerBalance_AuthUser> GetModelList(string where = "")
        {
            string sql = "select cb.BalanceId,CustomerName,Amount,BalanceAmount,cb.ActivityName,au.UserName as UserName,cb.EntryTime as EntryTime " +
                         "from customerbalance as cb " +
                         "left join authuser as au on au.workid=cb.workid " +
                         "where balanceAmount>0 ";
            if (!string.IsNullOrEmpty(where))
                sql += " and (" + where + ") ";
            sql += "order by entrytime desc";
            DataSet ds = DbHelperSQL.Query(sql);
            List<Model.CustomerBalance_AuthUser> res = new List<Model.CustomerBalance_AuthUser>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                res.Add(DataRowToModel(ds.Tables[0].Rows[i]));
            }
            return res;
        }


        public TravelAgency.Model.CustomerBalance_AuthUser DataRowToModel(DataRow row)
        {
            TravelAgency.Model.CustomerBalance_AuthUser model = new TravelAgency.Model.CustomerBalance_AuthUser();
            if (row != null)
            {
                if (row["BalanceId"] != null && row["BalanceId"].ToString() != "")
                {
                    model.BalanceId = Guid.Parse(row["BalanceId"].ToString());
                }

                if (row["CustomerName"] != null && row["CustomerName"].ToString() != "")
                {
                    model.CustomerName = row["CustomerName"].ToString();
                }
                if (row["Amount"] != null && row["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(row["Amount"].ToString());
                }
                if (row["balanceAmount"] != null && row["balanceAmount"].ToString() != "")
                {
                    model.BalanceAmount = decimal.Parse(row["balanceAmount"].ToString());
                }

                if (row["ActivityName"] != null && row["ActivityName"].ToString() != "")
                {
                    model.ActivityName = row["ActivityName"].ToString();
                }

                if (row["EntryTime"] != null && row["EntryTime"].ToString() != "")
                {
                    model.EntryTime = DateTime.Parse(row["EntryTime"].ToString());
                }
                if (row["UserName"] != null && row["UserName"].ToString() != "")
                {
                    model.UserName = row["UserName"].ToString();
                }
            }
            return model;
        }
    }
}
