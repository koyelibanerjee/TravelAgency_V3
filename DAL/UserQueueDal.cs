using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
    /// <summary>
    /// 数据访问类:AuthUser
    /// </summary>
    public partial class UserQueue
    {
        public UserQueue()
        { }
        //#region  BasicMethod

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgency.Model.UserQueueItem DataRowToModel(DataRow row)
        {
            TravelAgency.Model.UserQueueItem model = new TravelAgency.Model.UserQueueItem();
            if (row != null)
            {
                if (row["Id"] != null)
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["WorkId"] != null)
                {
                    model.WorkId = row["WorkId"].ToString();
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }

                if (row["IsBusy"] != null && row["IsBusy"].ToString() != "")
                {
                    if ((row["IsBusy"].ToString() == "1") || (row["IsBusy"].ToString().ToLower() == "true"))
                    {
                        model.IsBusy = true;
                    }
                    else
                    {
                        model.IsBusy = false;
                    }
                }

            }
            return model;
        }


        public int Enque(string tablename,Model.UserQueueItem model) //选择进那个队列里面
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}(", tablename);
            strSql.Append("WorkId,UserName,IsBusy)");
            strSql.Append(" values (");
            strSql.Append("@WorkId,@UserName,@IsBusy)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@WorkId", SqlDbType.VarChar,50),
                    new SqlParameter("@UserName", SqlDbType.VarChar,50),
                    new SqlParameter("@IsBusy", SqlDbType.Bit)
            };
            parameters[0].Value = model.WorkId;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.IsBusy;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }




        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Pop(string tablename)
        {
            Model.UserQueueItem userQueueItem = Top(tablename);
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0} ",tablename);
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
                          new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = userQueueItem.Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 取得队列顶 
        /// </summary>
        public TravelAgency.Model.UserQueueItem Top(string tablename)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select  top 1 * from {0} ",tablename);
            strSql.Append("order by id asc");
            TravelAgency.Model.UserQueueItem model = new TravelAgency.Model.UserQueueItem();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
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

