using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
    /// <summary>
    /// 数据访问类:VisaInfo
    /// </summary>
    public partial class VisaInfo_Job
    {
        public VisaInfo_Job()
        { }
        #region  BasicMethod

        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public TravelAgency.Model.VisaInfo_Job GetModel(Guid VisaInfo_id)
        //{

        //	StringBuilder strSql=new StringBuilder();
        //	strSql.Append("select  top 1 VisaInfo_id,Visa_id,GroupNo,Name,EnglishName,Sex,Birthday,PassportNo,LicenceTime,ExpiryDate,Birthplace,IssuePlace,Post,Phone,GuideNo,Client,Salesperson,Types,Sale_id,DepartmentId,Tips,EntryTime,EmbassyTime,InTime,OutTime,RealOut,RealOutTime,Country,Call,ExportState,outState,Residence,Occupation,DepartureRecord,Marriaged,Identification,FinancialCapacity,AgencyOpinion,HasTypeIn,AbnormalOutTime,HasChecked,CheckPerson,ReturnTime,Position,IssuePlaceEnglish,BirthPlaceEnglish,JobId from VisaInfo ");
        //	strSql.Append(" where VisaInfo_id=@VisaInfo_id ");
        //	SqlParameter[] parameters = {
        //			new SqlParameter("@VisaInfo_id", SqlDbType.UniqueIdentifier,16)			};
        //	parameters[0].Value = VisaInfo_id;

        //	TravelAgency.Model.VisaInfo_Job model=new TravelAgency.Model.VisaInfo_Job();
        //	DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
        //	if(ds.Tables[0].Rows.Count>0)
        //	{
        //		return DataRowToModel(ds.Tables[0].Rows[0]);
        //	}
        //	else
        //	{
        //		return null;
        //	}
        //}


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgency.Model.VisaInfo_Job DataRowToModel(DataRow row)
        {
            TravelAgency.Model.VisaInfo_Job model = new TravelAgency.Model.VisaInfo_Job();
            if (row != null)
            {
                if (row["VisaInfo_id"] != null && row["VisaInfo_id"].ToString() != "")
                {
                    model.VisaInfo_id = new Guid(row["VisaInfo_id"].ToString());
                }
                if (row["Visa_id"] != null)
                {
                    model.Visa_id = row["Visa_id"].ToString();
                }
                if (row["GroupNo"] != null)
                {
                    model.GroupNo = row["GroupNo"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["EnglishName"] != null)
                {
                    model.EnglishName = row["EnglishName"].ToString();
                }
                if (row["Sex"] != null)
                {
                    model.Sex = row["Sex"].ToString();
                }
                if (row["Birthday"] != null && row["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(row["Birthday"].ToString());
                }
                if (row["PassportNo"] != null)
                {
                    model.PassportNo = row["PassportNo"].ToString();
                }
                if (row["LicenceTime"] != null && row["LicenceTime"].ToString() != "")
                {
                    model.LicenceTime = DateTime.Parse(row["LicenceTime"].ToString());
                }
                if (row["ExpiryDate"] != null && row["ExpiryDate"].ToString() != "")
                {
                    model.ExpiryDate = DateTime.Parse(row["ExpiryDate"].ToString());
                }
                if (row["Birthplace"] != null)
                {
                    model.Birthplace = row["Birthplace"].ToString();
                }
                if (row["IssuePlace"] != null)
                {
                    model.IssuePlace = row["IssuePlace"].ToString();
                }
                if (row["Post"] != null)
                {
                    model.Post = row["Post"].ToString();
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["GuideNo"] != null)
                {
                    model.GuideNo = row["GuideNo"].ToString();
                }
                if (row["Client"] != null)
                {
                    model.Client = row["Client"].ToString();
                }
                if (row["Salesperson"] != null)
                {
                    model.Salesperson = row["Salesperson"].ToString();
                }
                if (row["Types"] != null)
                {
                    model.Types = row["Types"].ToString();
                }
                if (row["Sale_id"] != null && row["Sale_id"].ToString() != "")
                {
                    model.Sale_id = new Guid(row["Sale_id"].ToString());
                }
                if (row["DepartmentId"] != null && row["DepartmentId"].ToString() != "")
                {
                    model.DepartmentId = new Guid(row["DepartmentId"].ToString());
                }
                if (row["Tips"] != null)
                {
                    model.Tips = row["Tips"].ToString();
                }
                if (row["EntryTime"] != null && row["EntryTime"].ToString() != "")
                {
                    model.EntryTime = DateTime.Parse(row["EntryTime"].ToString());
                }
                if (row["EmbassyTime"] != null && row["EmbassyTime"].ToString() != "")
                {
                    model.EmbassyTime = DateTime.Parse(row["EmbassyTime"].ToString());
                }
                if (row["InTime"] != null && row["InTime"].ToString() != "")
                {
                    model.InTime = DateTime.Parse(row["InTime"].ToString());
                }
                if (row["OutTime"] != null && row["OutTime"].ToString() != "")
                {
                    model.OutTime = DateTime.Parse(row["OutTime"].ToString());
                }
                if (row["RealOut"] != null)
                {
                    model.RealOut = row["RealOut"].ToString();
                }
                if (row["RealOutTime"] != null && row["RealOutTime"].ToString() != "")
                {
                    model.RealOutTime = DateTime.Parse(row["RealOutTime"].ToString());
                }
                if (row["Country"] != null)
                {
                    model.Country = row["Country"].ToString();
                }
                if (row["Call"] != null)
                {
                    model.Call = row["Call"].ToString();
                }
                if (row["ExportState"] != null)
                {
                    model.ExportState = row["ExportState"].ToString();
                }
                if (row["outState"] != null)
                {
                    model.outState = row["outState"].ToString();
                }
                if (row["Residence"] != null)
                {
                    model.Residence = row["Residence"].ToString();
                }
                if (row["Occupation"] != null)
                {
                    model.Occupation = row["Occupation"].ToString();
                }
                if (row["DepartureRecord"] != null)
                {
                    model.DepartureRecord = row["DepartureRecord"].ToString();
                }
                if (row["Marriaged"] != null)
                {
                    model.Marriaged = row["Marriaged"].ToString();
                }
                if (row["Identification"] != null)
                {
                    model.Identification = row["Identification"].ToString();
                }
                if (row["FinancialCapacity"] != null)
                {
                    model.FinancialCapacity = row["FinancialCapacity"].ToString();
                }
                if (row["AgencyOpinion"] != null)
                {
                    model.AgencyOpinion = row["AgencyOpinion"].ToString();
                }
                if (row["HasTypeIn"] != null)
                {
                    model.HasTypeIn = row["HasTypeIn"].ToString();
                }
                if (row["AbnormalOutTime"] != null && row["AbnormalOutTime"].ToString() != "")
                {
                    model.AbnormalOutTime = DateTime.Parse(row["AbnormalOutTime"].ToString());
                }
                if (row["HasChecked"] != null)
                {
                    model.HasChecked = row["HasChecked"].ToString();
                }
                if (row["CheckPerson"] != null)
                {
                    model.CheckPerson = row["CheckPerson"].ToString();
                }
                if (row["ReturnTime"] != null && row["ReturnTime"].ToString() != "")
                {
                    model.ReturnTime = DateTime.Parse(row["ReturnTime"].ToString());
                }
                if (row["Position"] != null && row["Position"].ToString() != "")
                {
                    model.Position = int.Parse(row["Position"].ToString());
                }
                if (row["IssuePlaceEnglish"] != null)
                {
                    model.IssuePlaceEnglish = row["IssuePlaceEnglish"].ToString();
                }
                if (row["BirthPlaceEnglish"] != null)
                {
                    model.BirthPlaceEnglish = row["BirthPlaceEnglish"].ToString();
                }
                if (row["JobId"] != null && row["JobId"].ToString() != "")
                {
                    model.JobId = int.Parse(row["JobId"].ToString());
                }
                if (row["AssignmentToWorkId"] != null && row["AssignmentToWorkId"].ToString() != "")
                {
                    model.AssignmentToWorkId = int.Parse(row["AssignmentToWorkId"].ToString());
                }
                if (row["AssignmentTime"] != null && row["AssignmentTime"].ToString() != "")
                {
                    model.AssignmentTime = DateTime.Parse(row["AssignmentTime"].ToString());
                }

                if (row["AssignmentState"] != null && row["AssignmentState"].ToString() != "")
                {
                    model.AssignmentState = row["AssignmentState"].ToString();
                }

            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t1.*,t2.AssignmentToWorkId,t2.AssignmentTime,AssignmentState = case when t2.AssignmentTime IS not null then \'已分配\' else \'未分配\' end from VisaInfo as t1 inner join JobAssignment as t2 on t1.JobId = t2.Id  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        ///// <summary>
        ///// 获得前几行数据
        ///// </summary>
        //public DataSet GetList(int Top, string strWhere, string filedOrder)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select ");
        //    if (Top > 0)
        //    {
        //        strSql.Append(" top " + Top.ToString());
        //    }
        //    strSql.Append(" VisaInfo_id,Visa_id,GroupNo,Name,EnglishName,Sex,Birthday,PassportNo,LicenceTime,ExpiryDate,Birthplace,IssuePlace,Post,Phone,GuideNo,Client,Salesperson,Types,Sale_id,DepartmentId,Tips,EntryTime,EmbassyTime,InTime,OutTime,RealOut,RealOutTime,Country,Call,ExportState,outState,Residence,Occupation,DepartureRecord,Marriaged,Identification,FinancialCapacity,AgencyOpinion,HasTypeIn,AbnormalOutTime,HasChecked,CheckPerson,ReturnTime,Position,IssuePlaceEnglish,BirthPlaceEnglish,JobId ");
        //    strSql.Append(" FROM VisaInfo ");
        //    if (strWhere.Trim() != "")
        //    {
        //        strSql.Append(" where " + strWhere);
        //    }
        //    strSql.Append(" order by " + filedOrder);
        //    return DbHelperSQL.Query(strSql.ToString());
        //}

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM VisaInfo ");
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from(select *,ROW_NUMBER() over(" +
                          "order by t3.entrytime desc" +
                          ") as no from(select t1.*,t2.AssignmentToWorkId,t2.AssignmentTime,AssignmentState = case when t2.AssignmentTime IS not null then \'已分配\'else \'未分配\'end from VisaInfo as t1 inner join JobAssignment as t2 on t1.JobId = t2.Id) as t3 "
                          );

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(") as t4");
            strSql.AppendFormat(" WHERE t4.no between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  BasicMethod

    }
}

