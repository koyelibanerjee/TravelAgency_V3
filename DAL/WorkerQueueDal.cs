using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
	/// <summary>
	/// 数据访问类:WorkerQueue
	/// </summary>
	public partial class WorkerQueue
	{
        public Model.WorkerQueue GetNextWorker()
        {
            string sql = " select top 1 * from WorkerQueue where IsBusy=0 and CanAccept=1 order by Priority asc";

            TravelAgency.Model.WorkerQueue model = new TravelAgency.Model.WorkerQueue();
            DataSet ds = DbHelperSQL.Query(sql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
	}
}

