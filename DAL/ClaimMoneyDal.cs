using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
    /// <summary>
    /// 数据访问类:ClaimMoney
    /// </summary>
    public partial class ClaimMoney
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TravelAgency.Model.ClaimMoney model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ClaimMoney(");
            strSql.Append("Claim_id,Money_id,DepartmentId,Name_Claim,GroupNo,Salesperson,Guests,Methods,Amount,WorkId,ClaimTime,username,OrderNo,EntryTime,MoneyType,Claim_Confirm)");
            strSql.Append(" values (");
            strSql.Append("@Claim_id,@Money_id,@DepartmentId,@Name_Claim,@GroupNo,@Salesperson,@Guests,@Methods,@Amount,@WorkId,@ClaimTime,@username,@OrderNo,@EntryTime,@MoneyType,@Claim_Confirm)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Claim_id", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@Money_id", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@DepartmentId", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@Name_Claim", SqlDbType.VarChar,50),
                    new SqlParameter("@GroupNo", SqlDbType.VarChar,900),
                    new SqlParameter("@Salesperson", SqlDbType.VarChar,50),
                    new SqlParameter("@Guests", SqlDbType.VarChar,50),
                    new SqlParameter("@Methods", SqlDbType.VarChar,255),
                    new SqlParameter("@Amount", SqlDbType.Float,8),
                    new SqlParameter("@WorkId", SqlDbType.VarChar,50),
                    new SqlParameter("@ClaimTime", SqlDbType.DateTime),
                    new SqlParameter("@username", SqlDbType.VarChar,50),
                    new SqlParameter("@OrderNo", SqlDbType.VarChar,255),
                    new SqlParameter("@EntryTime", SqlDbType.DateTime),
                    new SqlParameter("@MoneyType", SqlDbType.VarChar,50),
                    new SqlParameter("@Claim_Confirm", SqlDbType.VarChar,50)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.Money_id;
            parameters[2].Value = model.DepartmentId;
            parameters[3].Value = model.Name_Claim;
            parameters[4].Value = model.GroupNo;
            parameters[5].Value = model.Salesperson;
            parameters[6].Value = model.Guests;
            parameters[7].Value = model.Methods;
            parameters[8].Value = model.Amount;
            parameters[9].Value = model.WorkId;
            parameters[10].Value = model.ClaimTime;
            parameters[11].Value = model.username;
            parameters[12].Value = model.OrderNo;
            parameters[13].Value = model.EntryTime;
            parameters[14].Value = model.MoneyType;
            parameters[15].Value = model.Claim_Confirm;

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
    }
}

