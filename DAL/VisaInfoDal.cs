using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references

namespace TravelAgency.DAL
{
    /// <summary>
    /// 数据访问类:VisaInfo
    /// </summary>
    public partial class VisaInfo
    {
        /// <summary>
        /// 按照entrytime,outstate,groupNo排序，给送签管理界面用的
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetDataByPageOrderByOutState(int start, int end,string where)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * from(SELECT *,ROW_NUMBER() OVER(ORDER BY EntryTime desc) as num from VisaInfo");
            if (!string.IsNullOrEmpty(where))
            {
                sb.Append(" where ");
                sb.Append(where);
            }
            sb.Append(")");
            sb.Append(" as t WHERE t.num>=@Start AND t.num<=@End order by EntryTime desc,OutState desc,GroupNo desc");
            string sql = sb.ToString();
            SqlParameter[] pams = new SqlParameter[]{
                new SqlParameter("@Start",SqlDbType.Int){Value=start},
                new SqlParameter("@End",SqlDbType.Int){Value=end}
            };
            return DbHelperSQL.Query(sql, pams);
        }



        /// <summary>
        /// 按照entrytime,groupNo,outstate排序，给签证录入界面用的//20180109修改为只按照录入时间排序
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetDataByPageOrderByGroupNo(int start, int end,string where)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * from(SELECT *,ROW_NUMBER() OVER(ORDER BY EntryTime desc) as num from VisaInfo");
            if (!string.IsNullOrEmpty(where))
            {
                sb.Append(" where ");
                sb.Append(where);
            }
            sb.Append(")");
            //sb.Append(" as t WHERE t.num>=@Start AND t.num<=@End order by EntryTime desc,GroupNo desc,OutState desc");
            sb.Append(" as t WHERE t.num>=@Start AND t.num<=@End order by entrytime asc"); //20180109修改为只按照录入时间排序
            string sql = sb.ToString();
            SqlParameter[] pams = new SqlParameter[]{
                new SqlParameter("@Start",SqlDbType.Int){Value=start},
                new SqlParameter("@End",SqlDbType.Int){Value=end}
            };
            return DbHelperSQL.Query(sql, pams);
        }


        /// <summary>
        /// 这个是给检查信息界面用的
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataSet GetDataByPageOrderByHasChecked(int start, int end)
        {
            string sql = "SELECT * from(SELECT *," +
                         "ROW_NUMBER() OVER(ORDER BY EntryTime desc) " +
                         "as num from VisaInfo " +
                         "where (HasChecked is null or HasChecked='否' or HasChecked=' ')) " +
                         "as t WHERE t.num>=@Start AND t.num<=@End order by EntryTime desc,GroupNo desc";
            SqlParameter[] pams = new SqlParameter[]{
                new SqlParameter("@Start",SqlDbType.Int){Value=start},
                new SqlParameter("@End",SqlDbType.Int){Value=end}
            };
            return DbHelperSQL.Query(sql, pams);
        }

        /// <summary>
        /// 获取总记录条数
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            string sql = "select count(1) from VisaInfo";
            return (int)DbHelperSQL.GetSingle(sql);
        }


        public int DeleteListByPassNo(List<string> passNums)
        {
            int ret = 0; //执行成功的数目
            for (int i = 0; i < passNums.Count; i++)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from VisaInfo ");
                strSql.Append(" where PassportNo=@passportNo ");
                SqlParameter[] parameters = {
					new SqlParameter("@passportNo", SqlDbType.VarChar,50)};
                parameters[0].Value = passNums[i];

                int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                ret = rows > 0 ? ret + 1 : ret;
            }
            return ret;
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public int DeleteList(string VisaInfo_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from VisaInfo ");
            strSql.Append(" where VisaInfo_id in (" + VisaInfo_idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            return rows;
        }


        public TravelAgency.Model.VisaInfo GetModelByPassportNo(string passportNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from VisaInfo ");
            strSql.Append(" where PassportNo=@PassportNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@PassportNo", SqlDbType.VarChar,50)			};
            parameters[0].Value = passportNo;

            TravelAgency.Model.VisaInfo model = new TravelAgency.Model.VisaInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public DataSet GetLastRecordOfTheDay(DateTime date)
        {
            string sql = "select top 1 * from visainfo";

            sql += " where entrytime between'" + date.ToString("yyyy-MM-dd") + " 0:0:0' and '" + date.ToString("yyyy-MM-dd") + " 23:59:59' ";
            sql += "order by entryTime desc";

            return DbHelperSQL.Query(sql);
        }

        /// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(TravelAgency.Model.VisaInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into VisaInfo(");
            strSql.Append("VisaInfo_id,Visa_id,GroupNo,Name,EnglishName,Sex,Birthday,PassportNo,LicenceTime,ExpiryDate,Birthplace,IssuePlace,Post,Phone,GuideNo,Client,Salesperson,Types,Sale_id,DepartmentId,Tips,EntryTime,EmbassyTime,InTime,OutTime,RealOut,RealOutTime,Country,Call,outState,Residence,Occupation,DepartureRecord,Marriaged,Identification,FinancialCapacity,AgencyOpinion,HasTypeIn,AbnormalOutTime,HasChecked,CheckPerson,ReturnTime,Position,IssuePlaceEnglish,BirthPlaceEnglish)");
            strSql.Append(" values (");
            strSql.Append("@VisaInfo_id,@Visa_id,@GroupNo,@Name,@EnglishName,@Sex,@Birthday,@PassportNo,@LicenceTime,@ExpiryDate,@Birthplace,@IssuePlace,@Post,@Phone,@GuideNo,@Client,@Salesperson,@Types,@Sale_id,@DepartmentId,@Tips,@EntryTime,@EmbassyTime,@InTime,@OutTime,@RealOut,@RealOutTime,@Country,@Call,@outState,@Residence,@Occupation,@DepartureRecord,@Marriaged,@Identification,@FinancialCapacity,@AgencyOpinion,@HasTypeIn,@AbnormalOutTime,@HasChecked,@CheckPerson,@ReturnTime,@Position,@IssuePlaceEnglish,@BirthPlaceEnglish)");
            SqlParameter[] parameters = {
                    new SqlParameter("@VisaInfo_id", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@Visa_id", SqlDbType.VarChar,50),
                    new SqlParameter("@GroupNo", SqlDbType.VarChar,500),
                    new SqlParameter("@Name", SqlDbType.VarChar,50),
                    new SqlParameter("@EnglishName", SqlDbType.VarChar,50),
                    new SqlParameter("@Sex", SqlDbType.VarChar,50),
                    new SqlParameter("@Birthday", SqlDbType.DateTime,3),
                    new SqlParameter("@PassportNo", SqlDbType.VarChar,50),
                    new SqlParameter("@LicenceTime", SqlDbType.DateTime,3),
                    new SqlParameter("@ExpiryDate", SqlDbType.DateTime,3),
                    new SqlParameter("@Birthplace", SqlDbType.VarChar,50),
                    new SqlParameter("@IssuePlace", SqlDbType.VarChar,50),
                    new SqlParameter("@Post", SqlDbType.VarChar,50),
                    new SqlParameter("@Phone", SqlDbType.VarChar,50),
                    new SqlParameter("@GuideNo", SqlDbType.VarChar,50),
                    new SqlParameter("@Client", SqlDbType.VarChar,50),
                    new SqlParameter("@Salesperson", SqlDbType.VarChar,50),
                    new SqlParameter("@Types", SqlDbType.VarChar,50),
                    new SqlParameter("@Sale_id", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@DepartmentId", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@Tips", SqlDbType.VarChar,-1),
                    new SqlParameter("@EntryTime", SqlDbType.DateTime),
                    new SqlParameter("@EmbassyTime", SqlDbType.DateTime),
                    new SqlParameter("@InTime", SqlDbType.DateTime),
                    new SqlParameter("@OutTime", SqlDbType.DateTime),
                    new SqlParameter("@RealOut", SqlDbType.VarChar,50),
                    new SqlParameter("@RealOutTime", SqlDbType.DateTime),
                    new SqlParameter("@Country", SqlDbType.VarChar,50),
                    new SqlParameter("@Call", SqlDbType.VarChar,50),
                    new SqlParameter("@outState", SqlDbType.VarChar,12),
                    new SqlParameter("@Residence", SqlDbType.VarChar,100),
                    new SqlParameter("@Occupation", SqlDbType.VarChar,50),
                    new SqlParameter("@DepartureRecord", SqlDbType.VarChar,10),
                    new SqlParameter("@Marriaged", SqlDbType.VarChar,10),
                    new SqlParameter("@Identification", SqlDbType.VarChar,100),
                    new SqlParameter("@FinancialCapacity", SqlDbType.VarChar,100),
                    new SqlParameter("@AgencyOpinion", SqlDbType.VarChar,20),
                    new SqlParameter("@HasTypeIn", SqlDbType.VarChar,2),
                    new SqlParameter("@AbnormalOutTime", SqlDbType.DateTime),
                    new SqlParameter("@HasChecked", SqlDbType.VarChar,2),
                    new SqlParameter("@CheckPerson", SqlDbType.VarChar,50),
                    new SqlParameter("@ReturnTime", SqlDbType.DateTime),
                    new SqlParameter("@Position", SqlDbType.Int,4),
                    new SqlParameter("@IssuePlaceEnglish", SqlDbType.VarChar,50),
                    new SqlParameter("@BirthPlaceEnglish", SqlDbType.VarChar,50)};
            parameters[0].Value = model.VisaInfo_id; //这里千万不能用new guid
            parameters[1].Value = model.Visa_id;
            parameters[2].Value = model.GroupNo;
            parameters[3].Value = model.Name;
            parameters[4].Value = model.EnglishName;
            parameters[5].Value = model.Sex;
            parameters[6].Value = model.Birthday;
            parameters[7].Value = model.PassportNo;
            parameters[8].Value = model.LicenceTime;
            parameters[9].Value = model.ExpiryDate;
            parameters[10].Value = model.Birthplace;
            parameters[11].Value = model.IssuePlace;
            parameters[12].Value = model.Post;
            parameters[13].Value = model.Phone;
            parameters[14].Value = model.GuideNo;
            parameters[15].Value = model.Client;
            parameters[16].Value = model.Salesperson;
            parameters[17].Value = model.Types;
            parameters[18].Value = Guid.NewGuid();
            parameters[19].Value = Guid.NewGuid();
            parameters[20].Value = model.Tips;
            parameters[21].Value = model.EntryTime;
            parameters[22].Value = model.EmbassyTime;
            parameters[23].Value = model.InTime;
            parameters[24].Value = model.OutTime;
            parameters[25].Value = model.RealOut;
            parameters[26].Value = model.RealOutTime;
            parameters[27].Value = model.Country;
            parameters[28].Value = model.Call;
            parameters[29].Value = model.outState;
            parameters[30].Value = model.Residence;
            parameters[31].Value = model.Occupation;
            parameters[32].Value = model.DepartureRecord;
            parameters[33].Value = model.Marriaged;
            parameters[34].Value = model.Identification;
            parameters[35].Value = model.FinancialCapacity;
            parameters[36].Value = model.AgencyOpinion;
            parameters[37].Value = model.HasTypeIn;
            parameters[38].Value = model.AbnormalOutTime;
            parameters[39].Value = model.HasChecked;
            parameters[40].Value = model.CheckPerson;
            parameters[41].Value = model.ReturnTime;
            parameters[42].Value = model.Position;
            parameters[43].Value = model.IssuePlaceEnglish;
            parameters[44].Value = model.BirthPlaceEnglish;

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