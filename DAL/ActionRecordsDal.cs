using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
    /// <summary>
    /// 数据访问类:ActionRecords
    /// </summary>
    public partial class ActionRecords
    {

        public string GetTypeSql(Model.VisaInfo model, string type)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT top 1 * from ActionRecords where visainfo_id = '" + model.VisaInfo_id + "'");
            sb.Append(" and ActType = '" + type + "' order by id desc"); //取最后的
            return sb.ToString();
        }

        public List<Model.ActionRecords> GetVisaInfoStatusList(Model.VisaInfo model)
        {
            List<Model.ActionRecords> listRes = new List<Model.ActionRecords>();

            string sql = GetTypeSql(model, "01录入(设置团号)");
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                listRes.Add(DataRowToModel(ds.Tables[0].Rows[0]));
            }

            sql = GetTypeSql(model, "02录入做资料");
            ds = DbHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                listRes.Add(DataRowToModel(ds.Tables[0].Rows[0]));
            }

            sql = GetTypeSql(model, "03修改资料");
            ds = DbHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                listRes.Add(DataRowToModel(ds.Tables[0].Rows[0]));
            }

            sql = GetTypeSql(model, "04校验");
            ds = DbHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                listRes.Add(DataRowToModel(ds.Tables[0].Rows[0]));
            }

            return listRes.Count > 0 ? listRes : null;

        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgency.Model.ActionRecords model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ActionRecords(");
            strSql.Append("ActType,WorkId,UserName,VisaInfo_id,Visa_id,Type,EntryTime,Country)");
            strSql.Append(" values (");
            strSql.Append("@ActType,@WorkId,@UserName,@VisaInfo_id,@Visa_id,@Type,@EntryTime,@Country)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@ActType", SqlDbType.VarChar,50),
                    new SqlParameter("@WorkId", SqlDbType.VarChar,50),
                    new SqlParameter("@UserName", SqlDbType.VarChar,100),
                    new SqlParameter("@VisaInfo_id", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@Visa_id", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@Type", SqlDbType.VarChar,50),
                    new SqlParameter("@EntryTime", SqlDbType.DateTime),
                    new SqlParameter("@Country", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = model.ActType;
            parameters[1].Value = model.WorkId;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.VisaInfo_id;//这里不能是new GUID
            parameters[4].Value = model.Visa_id;
            parameters[5].Value = model.Type;
            parameters[6].Value = model.EntryTime;
            parameters[7].Value = model.Country;

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
        /// 取指定visa里面已做资料的visainfo的数量
        /// </summary>
        /// <param name="visaGuid"></param>
        /// <returns></returns>
        public int GetVisaHasTypedInNum(Guid visaGuid)
        {
            string sql = "select count(1) from (select distinct VisaInfo_id from ActionRecords where Visa_id = '" +
                         visaGuid.ToString() +
                         "' and ActType = '02录入做资料') as b";
            return (int)DbHelperSQL.GetSingle(sql);
        }

        /// <summary>
        /// 按照entrytime倒序排序
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetDataByPageOrderByEntryTime(int start, int end, string where)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * from(SELECT *,ROW_NUMBER() OVER(ORDER BY EntryTime desc) as num from ActionRecords");
            if (!string.IsNullOrEmpty(where))
            {
                sb.Append(" where ");
                sb.Append(where);
            }
            sb.Append(")");
            //sb.Append(" as t WHERE t.num>=@Start AND t.num<=@End order by EntryTime desc,GroupNo desc,OutState desc");
            sb.Append(" as t WHERE t.num>=@Start AND t.num<=@End");
            string sql = sb.ToString();
            SqlParameter[] pams = new SqlParameter[]{
                new SqlParameter("@Start",SqlDbType.Int){Value=start},
                new SqlParameter("@End",SqlDbType.Int){Value=end}
            };
            return DbHelperSQL.Query(sql, pams);
        }

        public int GetVisaSubmitStateNum(Model.Visa model, string acttype)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(
                "select COUNT(1) from (select distinct visainfo_id from ActionRecords where Visa_id='" 
                + model.Visa_id + "' and acttype='" + acttype + "') as b");

            return (int)DbHelperSQL.GetSingle(sb.ToString());
        }


        //删除VisaInfo指定类型的操作记录
        public int DeleteVisaInfoSubmitStateRecord(Model.VisaInfo model, string acttype)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(
                "delete from  ActionRecords where VisaInfo_id='"
                + model.VisaInfo_id + "' and acttype='" + acttype + "'");
            object res = DbHelperSQL.GetSingle(sb.ToString());
            if (res == null)
                return 0;
            else return (int)res;
        }


    }
}

