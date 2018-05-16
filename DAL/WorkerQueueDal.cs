using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using System.Collections.Generic;

namespace TravelAgency.DAL
{
    /// <summary>
    /// 数据访问类:WorkerQueue
    /// </summary>
    public partial class WorkerQueue
    {
        public Model.WorkerQueue GetNextWorker()
        {
            string sql = "select * from WorkerQueue where Priority = (select min(Priority) from WorkerQueue where IsBusy=0 and CanAccept=1)";
            DataSet ds = DbHelperSQL.Query(sql.ToString());
            List<Model.WorkerQueue> list = new List<Model.WorkerQueue>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; ++i)
                {
                    var modeltmp = DataRowToModel(ds.Tables[0].Rows[i]);
                    if (!modeltmp.IsBusy && modeltmp.CanAccept) //先去除不可能的
                    {
                        list.Add(modeltmp);
                    }
                }
                if (list.Count == 0)
                    return null;
                if (list.Count == 1)
                    return list[0];
                return list[new Random().Next(0, list.Count)]; //这个random也是左闭右开区间
            }
            else
            {
                return null;
            }
        }
    }
}

