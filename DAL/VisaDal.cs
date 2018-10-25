using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maticsoft.DBUtility;

namespace TravelAgency.DAL
{
    public partial class Visa
    {
        
        public DataSet GetDataByPage(int start, int end, string where)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * from(SELECT *,ROW_NUMBER() OVER(ORDER BY EntryTime desc) as num from Visa");

            if (!string.IsNullOrEmpty(where))
            {
                sb.Append(" where ");
                sb.Append(where);
            }
            sb.Append(")");

            sb.Append(" as t WHERE t.num>=@Start AND t.num<=@End order by EntryTime desc");
            string sql = sb.ToString();
            SqlParameter[] pams = new SqlParameter[]{
                new SqlParameter("@Start",SqlDbType.Int){Value=start},
                new SqlParameter("@End",SqlDbType.Int){Value=end}
            };
            return DbHelperSQL.Query(sql, pams);
        }

        public DataSet GetLastRecord(string type,string TypeInPerson,string country)
        {
            string sql = "select top 1 * from visa";
            if (!string.IsNullOrEmpty(type))
            {
                sql += " where types='" + type + "'";
            }
            if (!string.IsNullOrEmpty(TypeInPerson))
            {
                sql += " and typeinperson = '" + TypeInPerson + "' ";
            }
            if (!string.IsNullOrEmpty(country))
            {
                sql += " and country = '" + country + "' ";
            }
            sql += "order by entryTime desc";
            return DbHelperSQL.Query(sql);
        }

        public DataSet GetLastRecordOfTheDay(DateTime date)
        {
            string sql = "select top 1 * from visa";

            sql += " where entrytime between'" + date.ToString("yyyy-MM-dd") + " 0:0:0' and '" + date.ToString("yyyy-MM-dd") + " 23:59:59' ";
            sql += "order by entryTime desc";

            return DbHelperSQL.Query(sql);
        }

        /// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordVisaInfoCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(Number) FROM Visa ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
        /// 更新一条数据
        /// </summary>
        public bool Update_FrmSetGroup(TravelAgency.Model.Visa model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Visa set ");
            strSql.Append(" Visa_id = @Visa_id , ");
            strSql.Append(" GroupNo = @GroupNo , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" Types = @Types , ");
            strSql.Append(" DepartureTime = @DepartureTime , ");
            strSql.Append(" Person = @Person , ");
            strSql.Append(" Number = @Number , ");
            strSql.Append(" SalesPerson = @SalesPerson , ");
            strSql.Append(" EntryTime = @EntryTime , ");
            strSql.Append(" Country = @Country , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" SubmitTime = @SubmitTime , ");
            strSql.Append(" InTime = @InTime , ");
            strSql.Append(" OutTime = @OutTime , ");
            strSql.Append(" client = @client , ");
            strSql.Append(" DepartureType = @DepartureType , ");
            strSql.Append(" SubmitCondition = @SubmitCondition , ");
            strSql.Append(" FetchCondition = @FetchCondition , ");
            strSql.Append(" TypeInPerson = @TypeInPerson , ");
            strSql.Append(" IsUrgent = @IsUrgent , ");
            strSql.Append(" PeiQianYuan = @PeiQianYuan , ");
            strSql.Append(" QuQianYuan = @QuQianYuan , ");
            strSql.Append(" Operator = @Operator , ");
            strSql.Append(" IsOutDelivery = @IsOutDelivery , ");
            strSql.Append(" OutDeliveryPlace = @OutDeliveryPlace , ");
            strSql.Append(" ForRequestGroupNo = @ForRequestGroupNo , ");
            strSql.Append(" District = @District , ");
            strSql.Append(" PredictTime = @PredictTime , ");
            strSql.Append(" WorkingState = @WorkingState , ");
            strSql.Append(" OtherDistrictTypeInPerson = @OtherDistrictTypeInPerson  ");
            strSql.Append(" where Visa_id=@Visa_id  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@Visa_id", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@GroupNo", SqlDbType.VarChar,5000) ,
                        new SqlParameter("@Name", SqlDbType.VarChar,150) ,
                        new SqlParameter("@Types", SqlDbType.VarChar,50) ,
                        new SqlParameter("@DepartureTime", SqlDbType.DateTime,3) ,
                        new SqlParameter("@Person", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Number", SqlDbType.Int,4) ,
                        new SqlParameter("@SalesPerson", SqlDbType.VarChar,50) ,
                        new SqlParameter("@EntryTime", SqlDbType.DateTime) ,
                        new SqlParameter("@Country", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Remark", SqlDbType.VarChar,20) ,
                        new SqlParameter("@SubmitTime", SqlDbType.DateTime) ,
                        new SqlParameter("@InTime", SqlDbType.DateTime) ,
                        new SqlParameter("@OutTime", SqlDbType.DateTime) ,
                        new SqlParameter("@client", SqlDbType.VarChar,50) ,
                        new SqlParameter("@DepartureType", SqlDbType.VarChar,50) ,
                        new SqlParameter("@SubmitCondition", SqlDbType.VarChar,50) ,
                        new SqlParameter("@FetchCondition", SqlDbType.VarChar,50) ,
                        new SqlParameter("@TypeInPerson", SqlDbType.VarChar,50) ,
                        new SqlParameter("@IsUrgent", SqlDbType.Bit,1) ,
                        new SqlParameter("@PeiQianYuan", SqlDbType.VarChar,50) ,
                        new SqlParameter("@QuQianYuan", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Operator", SqlDbType.VarChar,50) ,
                        new SqlParameter("@IsOutDelivery", SqlDbType.Bit,1) ,
                        new SqlParameter("@OutDeliveryPlace", SqlDbType.VarChar,20) ,
                        new SqlParameter("@ForRequestGroupNo", SqlDbType.Bit,1) ,
                        new SqlParameter("@District", SqlDbType.Int,4) ,
                        new SqlParameter("@PredictTime", SqlDbType.DateTime) ,
                        new SqlParameter("@WorkingState", SqlDbType.VarChar,500) ,
                        new SqlParameter("@OtherDistrictTypeInPerson", SqlDbType.VarChar,50)

            };

            parameters[0].Value = model.Visa_id;
            parameters[1].Value = model.GroupNo;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Types;
            parameters[4].Value = model.DepartureTime;
            parameters[5].Value = model.Person;
            parameters[6].Value = model.Number;
            parameters[7].Value = model.SalesPerson;
            parameters[8].Value = model.EntryTime;
            parameters[9].Value = model.Country;
            parameters[10].Value = model.Remark;
            parameters[11].Value = model.SubmitTime;
            parameters[12].Value = model.InTime;
            parameters[13].Value = model.OutTime;
            parameters[14].Value = model.client;
            parameters[15].Value = model.DepartureType;
            parameters[16].Value = model.SubmitCondition;
            parameters[17].Value = model.FetchCondition;
            parameters[18].Value = model.TypeInPerson;
            parameters[19].Value = model.IsUrgent;
            parameters[20].Value = model.PeiQianYuan;
            parameters[21].Value = model.QuQianYuan;
            parameters[22].Value = model.Operator;
            parameters[23].Value = model.IsOutDelivery;
            parameters[24].Value = model.OutDeliveryPlace;
            parameters[25].Value = model.ForRequestGroupNo;
            parameters[26].Value = model.District;
            parameters[27].Value = model.PredictTime;
            parameters[28].Value = model.WorkingState;
            parameters[29].Value = model.OtherDistrictTypeInPerson;
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
