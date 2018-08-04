using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace TravelAgency.DAL
{
    //VisaInfo
    public partial class VisaInfo
    {

        public bool Exists(Guid VisaInfo_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from VisaInfo");
            strSql.Append(" where ");
            strSql.Append(" VisaInfo_id = @VisaInfo_id  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@VisaInfo_id", SqlDbType.UniqueIdentifier,16)         };
            parameters[0].Value = VisaInfo_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据,整形自增长返回id,guid返回parameters[0].Value,string返回true or false
        /// </summary>
        public Guid Add(TravelAgency.Model.VisaInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into VisaInfo(");
            strSql.Append("VisaInfo_id,Visa_id,GroupNo,Name,EnglishName,Sex,Birthday,PassportNo,LicenceTime,ExpiryDate,Birthplace,IssuePlace,Post,Phone,GuideNo,Client,Salesperson,Types,Sale_id,DepartmentId,Tips,EntryTime,EmbassyTime,InTime,OutTime,RealOut,RealOutTime,Country,Call,ExportState,outState,Residence,Occupation,DepartureRecord,Marriaged,Identification,FinancialCapacity,AgencyOpinion,HasTypeIn,AbnormalOutTime,HasChecked,CheckPerson,ReturnTime,Position,IssuePlaceEnglish,BirthPlaceEnglish,JobId,AssignmentToWorkId,AssignmentToUserName,District");
            strSql.Append(") values (");
            strSql.Append("@VisaInfo_id,@Visa_id,@GroupNo,@Name,@EnglishName,@Sex,@Birthday,@PassportNo,@LicenceTime,@ExpiryDate,@Birthplace,@IssuePlace,@Post,@Phone,@GuideNo,@Client,@Salesperson,@Types,@Sale_id,@DepartmentId,@Tips,@EntryTime,@EmbassyTime,@InTime,@OutTime,@RealOut,@RealOutTime,@Country,@Call,@ExportState,@outState,@Residence,@Occupation,@DepartureRecord,@Marriaged,@Identification,@FinancialCapacity,@AgencyOpinion,@HasTypeIn,@AbnormalOutTime,@HasChecked,@CheckPerson,@ReturnTime,@Position,@IssuePlaceEnglish,@BirthPlaceEnglish,@JobId,@AssignmentToWorkId,@AssignmentToUserName,@District");
            strSql.Append(") ");

            SqlParameter[] parameters = {
                        new SqlParameter("@VisaInfo_id", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@Visa_id", SqlDbType.VarChar,50) ,
                        new SqlParameter("@GroupNo", SqlDbType.VarChar,500) ,
                        new SqlParameter("@Name", SqlDbType.VarChar,50) ,
                        new SqlParameter("@EnglishName", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Sex", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Birthday", SqlDbType.DateTime,3) ,
                        new SqlParameter("@PassportNo", SqlDbType.VarChar,50) ,
                        new SqlParameter("@LicenceTime", SqlDbType.DateTime,3) ,
                        new SqlParameter("@ExpiryDate", SqlDbType.DateTime,3) ,
                        new SqlParameter("@Birthplace", SqlDbType.VarChar,50) ,
                        new SqlParameter("@IssuePlace", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Post", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Phone", SqlDbType.VarChar,50) ,
                        new SqlParameter("@GuideNo", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Client", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Salesperson", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Types", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Sale_id", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@DepartmentId", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@Tips", SqlDbType.VarChar,-1) ,
                        new SqlParameter("@EntryTime", SqlDbType.DateTime) ,
                        new SqlParameter("@EmbassyTime", SqlDbType.DateTime) ,
                        new SqlParameter("@InTime", SqlDbType.DateTime) ,
                        new SqlParameter("@OutTime", SqlDbType.DateTime) ,
                        new SqlParameter("@RealOut", SqlDbType.VarChar,50) ,
                        new SqlParameter("@RealOutTime", SqlDbType.DateTime) ,
                        new SqlParameter("@Country", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Call", SqlDbType.VarChar,50) ,
                        new SqlParameter("@ExportState", SqlDbType.VarChar,50) ,
                        new SqlParameter("@outState", SqlDbType.VarChar,12) ,
                        new SqlParameter("@Residence", SqlDbType.VarChar,100) ,
                        new SqlParameter("@Occupation", SqlDbType.VarChar,50) ,
                        new SqlParameter("@DepartureRecord", SqlDbType.VarChar,10) ,
                        new SqlParameter("@Marriaged", SqlDbType.VarChar,10) ,
                        new SqlParameter("@Identification", SqlDbType.VarChar,100) ,
                        new SqlParameter("@FinancialCapacity", SqlDbType.VarChar,500) ,
                        new SqlParameter("@AgencyOpinion", SqlDbType.VarChar,20) ,
                        new SqlParameter("@HasTypeIn", SqlDbType.VarChar,2) ,
                        new SqlParameter("@AbnormalOutTime", SqlDbType.DateTime) ,
                        new SqlParameter("@HasChecked", SqlDbType.VarChar,2) ,
                        new SqlParameter("@CheckPerson", SqlDbType.VarChar,50) ,
                        new SqlParameter("@ReturnTime", SqlDbType.DateTime) ,
                        new SqlParameter("@Position", SqlDbType.Int,4) ,
                        new SqlParameter("@IssuePlaceEnglish", SqlDbType.VarChar,50) ,
                        new SqlParameter("@BirthPlaceEnglish", SqlDbType.VarChar,50) ,
                        new SqlParameter("@JobId", SqlDbType.Int,4) ,
                        new SqlParameter("@AssignmentToWorkId", SqlDbType.VarChar,50) ,
                        new SqlParameter("@AssignmentToUserName", SqlDbType.VarChar,50) ,
                        new SqlParameter("@District", SqlDbType.Int,4)

            };

            parameters[0].Value = Guid.NewGuid();
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
            parameters[18].Value = model.Sale_id;
            parameters[19].Value = model.DepartmentId;
            parameters[20].Value = model.Tips;
            parameters[21].Value = model.EntryTime;
            parameters[22].Value = model.EmbassyTime;
            parameters[23].Value = model.InTime;
            parameters[24].Value = model.OutTime;
            parameters[25].Value = model.RealOut;
            parameters[26].Value = model.RealOutTime;
            parameters[27].Value = model.Country;
            parameters[28].Value = model.Call;
            parameters[29].Value = model.ExportState;
            parameters[30].Value = model.outState;
            parameters[31].Value = model.Residence;
            parameters[32].Value = model.Occupation;
            parameters[33].Value = model.DepartureRecord;
            parameters[34].Value = model.Marriaged;
            parameters[35].Value = model.Identification;
            parameters[36].Value = model.FinancialCapacity;
            parameters[37].Value = model.AgencyOpinion;
            parameters[38].Value = model.HasTypeIn;
            parameters[39].Value = model.AbnormalOutTime;
            parameters[40].Value = model.HasChecked;
            parameters[41].Value = model.CheckPerson;
            parameters[42].Value = model.ReturnTime;
            parameters[43].Value = model.Position;
            parameters[44].Value = model.IssuePlaceEnglish;
            parameters[45].Value = model.BirthPlaceEnglish;
            parameters[46].Value = model.JobId;
            parameters[47].Value = model.AssignmentToWorkId;
            parameters[48].Value = model.AssignmentToUserName;
            parameters[49].Value = model.District;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return (Guid)(parameters[0].Value);
            }
            else
            {
                return Guid.Empty;
            }

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(TravelAgency.Model.VisaInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update VisaInfo set ");

            strSql.Append(" VisaInfo_id = @VisaInfo_id , ");
            strSql.Append(" Visa_id = @Visa_id , ");
            strSql.Append(" GroupNo = @GroupNo , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" EnglishName = @EnglishName , ");
            strSql.Append(" Sex = @Sex , ");
            strSql.Append(" Birthday = @Birthday , ");
            strSql.Append(" PassportNo = @PassportNo , ");
            strSql.Append(" LicenceTime = @LicenceTime , ");
            strSql.Append(" ExpiryDate = @ExpiryDate , ");
            strSql.Append(" Birthplace = @Birthplace , ");
            strSql.Append(" IssuePlace = @IssuePlace , ");
            strSql.Append(" Post = @Post , ");
            strSql.Append(" Phone = @Phone , ");
            strSql.Append(" GuideNo = @GuideNo , ");
            strSql.Append(" Client = @Client , ");
            strSql.Append(" Salesperson = @Salesperson , ");
            strSql.Append(" Types = @Types , ");
            strSql.Append(" Sale_id = @Sale_id , ");
            strSql.Append(" DepartmentId = @DepartmentId , ");
            strSql.Append(" Tips = @Tips , ");
            strSql.Append(" EntryTime = @EntryTime , ");
            strSql.Append(" EmbassyTime = @EmbassyTime , ");
            strSql.Append(" InTime = @InTime , ");
            strSql.Append(" OutTime = @OutTime , ");
            strSql.Append(" RealOut = @RealOut , ");
            strSql.Append(" RealOutTime = @RealOutTime , ");
            strSql.Append(" Country = @Country , ");
            strSql.Append(" Call = @Call , ");
            strSql.Append(" ExportState = @ExportState , ");
            strSql.Append(" outState = @outState , ");
            strSql.Append(" Residence = @Residence , ");
            strSql.Append(" Occupation = @Occupation , ");
            strSql.Append(" DepartureRecord = @DepartureRecord , ");
            strSql.Append(" Marriaged = @Marriaged , ");
            strSql.Append(" Identification = @Identification , ");
            strSql.Append(" FinancialCapacity = @FinancialCapacity , ");
            strSql.Append(" AgencyOpinion = @AgencyOpinion , ");
            strSql.Append(" HasTypeIn = @HasTypeIn , ");
            strSql.Append(" AbnormalOutTime = @AbnormalOutTime , ");
            strSql.Append(" HasChecked = @HasChecked , ");
            strSql.Append(" CheckPerson = @CheckPerson , ");
            strSql.Append(" ReturnTime = @ReturnTime , ");
            strSql.Append(" Position = @Position , ");
            strSql.Append(" IssuePlaceEnglish = @IssuePlaceEnglish , ");
            strSql.Append(" BirthPlaceEnglish = @BirthPlaceEnglish , ");
            strSql.Append(" JobId = @JobId , ");
            strSql.Append(" AssignmentToWorkId = @AssignmentToWorkId , ");
            strSql.Append(" AssignmentToUserName = @AssignmentToUserName , ");
            strSql.Append(" District = @District  ");
            strSql.Append(" where VisaInfo_id=@VisaInfo_id  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@VisaInfo_id", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@Visa_id", SqlDbType.VarChar,50) ,
                        new SqlParameter("@GroupNo", SqlDbType.VarChar,500) ,
                        new SqlParameter("@Name", SqlDbType.VarChar,50) ,
                        new SqlParameter("@EnglishName", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Sex", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Birthday", SqlDbType.DateTime,3) ,
                        new SqlParameter("@PassportNo", SqlDbType.VarChar,50) ,
                        new SqlParameter("@LicenceTime", SqlDbType.DateTime,3) ,
                        new SqlParameter("@ExpiryDate", SqlDbType.DateTime,3) ,
                        new SqlParameter("@Birthplace", SqlDbType.VarChar,50) ,
                        new SqlParameter("@IssuePlace", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Post", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Phone", SqlDbType.VarChar,50) ,
                        new SqlParameter("@GuideNo", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Client", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Salesperson", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Types", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Sale_id", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@DepartmentId", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@Tips", SqlDbType.VarChar,-1) ,
                        new SqlParameter("@EntryTime", SqlDbType.DateTime) ,
                        new SqlParameter("@EmbassyTime", SqlDbType.DateTime) ,
                        new SqlParameter("@InTime", SqlDbType.DateTime) ,
                        new SqlParameter("@OutTime", SqlDbType.DateTime) ,
                        new SqlParameter("@RealOut", SqlDbType.VarChar,50) ,
                        new SqlParameter("@RealOutTime", SqlDbType.DateTime) ,
                        new SqlParameter("@Country", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Call", SqlDbType.VarChar,50) ,
                        new SqlParameter("@ExportState", SqlDbType.VarChar,50) ,
                        new SqlParameter("@outState", SqlDbType.VarChar,12) ,
                        new SqlParameter("@Residence", SqlDbType.VarChar,100) ,
                        new SqlParameter("@Occupation", SqlDbType.VarChar,50) ,
                        new SqlParameter("@DepartureRecord", SqlDbType.VarChar,10) ,
                        new SqlParameter("@Marriaged", SqlDbType.VarChar,10) ,
                        new SqlParameter("@Identification", SqlDbType.VarChar,100) ,
                        new SqlParameter("@FinancialCapacity", SqlDbType.VarChar,500) ,
                        new SqlParameter("@AgencyOpinion", SqlDbType.VarChar,20) ,
                        new SqlParameter("@HasTypeIn", SqlDbType.VarChar,2) ,
                        new SqlParameter("@AbnormalOutTime", SqlDbType.DateTime) ,
                        new SqlParameter("@HasChecked", SqlDbType.VarChar,2) ,
                        new SqlParameter("@CheckPerson", SqlDbType.VarChar,50) ,
                        new SqlParameter("@ReturnTime", SqlDbType.DateTime) ,
                        new SqlParameter("@Position", SqlDbType.Int,4) ,
                        new SqlParameter("@IssuePlaceEnglish", SqlDbType.VarChar,50) ,
                        new SqlParameter("@BirthPlaceEnglish", SqlDbType.VarChar,50) ,
                        new SqlParameter("@JobId", SqlDbType.Int,4) ,
                        new SqlParameter("@AssignmentToWorkId", SqlDbType.VarChar,50) ,
                        new SqlParameter("@AssignmentToUserName", SqlDbType.VarChar,50) ,
                        new SqlParameter("@District", SqlDbType.Int,4)

            };

            parameters[0].Value = model.VisaInfo_id;
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
            parameters[18].Value = model.Sale_id;
            parameters[19].Value = model.DepartmentId;
            parameters[20].Value = model.Tips;
            parameters[21].Value = model.EntryTime;
            parameters[22].Value = model.EmbassyTime;
            parameters[23].Value = model.InTime;
            parameters[24].Value = model.OutTime;
            parameters[25].Value = model.RealOut;
            parameters[26].Value = model.RealOutTime;
            parameters[27].Value = model.Country;
            parameters[28].Value = model.Call;
            parameters[29].Value = model.ExportState;
            parameters[30].Value = model.outState;
            parameters[31].Value = model.Residence;
            parameters[32].Value = model.Occupation;
            parameters[33].Value = model.DepartureRecord;
            parameters[34].Value = model.Marriaged;
            parameters[35].Value = model.Identification;
            parameters[36].Value = model.FinancialCapacity;
            parameters[37].Value = model.AgencyOpinion;
            parameters[38].Value = model.HasTypeIn;
            parameters[39].Value = model.AbnormalOutTime;
            parameters[40].Value = model.HasChecked;
            parameters[41].Value = model.CheckPerson;
            parameters[42].Value = model.ReturnTime;
            parameters[43].Value = model.Position;
            parameters[44].Value = model.IssuePlaceEnglish;
            parameters[45].Value = model.BirthPlaceEnglish;
            parameters[46].Value = model.JobId;
            parameters[47].Value = model.AssignmentToWorkId;
            parameters[48].Value = model.AssignmentToUserName;
            parameters[49].Value = model.District;
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid VisaInfo_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from VisaInfo ");
            strSql.Append(" where VisaInfo_id=@VisaInfo_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@VisaInfo_id", SqlDbType.UniqueIdentifier,16)         };
            parameters[0].Value = VisaInfo_id;


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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string VisaInfo_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from VisaInfo ");
            strSql.Append(" where VisaInfo_id in (" + VisaInfo_idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public TravelAgency.Model.VisaInfo GetModel(Guid VisaInfo_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select VisaInfo_id, Visa_id, GroupNo, Name, EnglishName, Sex, Birthday, PassportNo, LicenceTime, ExpiryDate, Birthplace, IssuePlace, Post, Phone, GuideNo, Client, Salesperson, Types, Sale_id, DepartmentId, Tips, EntryTime, EmbassyTime, InTime, OutTime, RealOut, RealOutTime, Country, Call, ExportState, outState, Residence, Occupation, DepartureRecord, Marriaged, Identification, FinancialCapacity, AgencyOpinion, HasTypeIn, AbnormalOutTime, HasChecked, CheckPerson, ReturnTime, Position, IssuePlaceEnglish, BirthPlaceEnglish, JobId, AssignmentToWorkId, AssignmentToUserName, District  ");
            strSql.Append("  from VisaInfo ");
            strSql.Append(" where VisaInfo_id=@VisaInfo_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@VisaInfo_id", SqlDbType.UniqueIdentifier,16)         };
            parameters[0].Value = VisaInfo_id;


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


        /// <summary>
        /// DataRow to Object Model
        /// </summary>
        public TravelAgency.Model.VisaInfo DataRowToModel(DataRow row)
        {
            TravelAgency.Model.VisaInfo model = new TravelAgency.Model.VisaInfo();
            if (row != null)
            {
                if (row["VisaInfo_id"] != null && row["VisaInfo_id"].ToString() != "")
                {
                    model.VisaInfo_id = new Guid(row["VisaInfo_id"].ToString());
                }
                if (row["Visa_id"] != null && row["Visa_id"].ToString() != "")
                {
                    model.Visa_id = row["Visa_id"].ToString();
                }
                if (row["GroupNo"] != null && row["GroupNo"].ToString() != "")
                {
                    model.GroupNo = row["GroupNo"].ToString();
                }
                if (row["Name"] != null && row["Name"].ToString() != "")
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["EnglishName"] != null && row["EnglishName"].ToString() != "")
                {
                    model.EnglishName = row["EnglishName"].ToString();
                }
                if (row["Sex"] != null && row["Sex"].ToString() != "")
                {
                    model.Sex = row["Sex"].ToString();
                }
                if (row["Birthday"] != null && row["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(row["Birthday"].ToString());
                }
                if (row["PassportNo"] != null && row["PassportNo"].ToString() != "")
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
                if (row["Birthplace"] != null && row["Birthplace"].ToString() != "")
                {
                    model.Birthplace = row["Birthplace"].ToString();
                }
                if (row["IssuePlace"] != null && row["IssuePlace"].ToString() != "")
                {
                    model.IssuePlace = row["IssuePlace"].ToString();
                }
                if (row["Post"] != null && row["Post"].ToString() != "")
                {
                    model.Post = row["Post"].ToString();
                }
                if (row["Phone"] != null && row["Phone"].ToString() != "")
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["GuideNo"] != null && row["GuideNo"].ToString() != "")
                {
                    model.GuideNo = row["GuideNo"].ToString();
                }
                if (row["Client"] != null && row["Client"].ToString() != "")
                {
                    model.Client = row["Client"].ToString();
                }
                if (row["Salesperson"] != null && row["Salesperson"].ToString() != "")
                {
                    model.Salesperson = row["Salesperson"].ToString();
                }
                if (row["Types"] != null && row["Types"].ToString() != "")
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
                if (row["Tips"] != null && row["Tips"].ToString() != "")
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
                if (row["RealOut"] != null && row["RealOut"].ToString() != "")
                {
                    model.RealOut = row["RealOut"].ToString();
                }
                if (row["RealOutTime"] != null && row["RealOutTime"].ToString() != "")
                {
                    model.RealOutTime = DateTime.Parse(row["RealOutTime"].ToString());
                }
                if (row["Country"] != null && row["Country"].ToString() != "")
                {
                    model.Country = row["Country"].ToString();
                }
                if (row["Call"] != null && row["Call"].ToString() != "")
                {
                    model.Call = row["Call"].ToString();
                }
                if (row["ExportState"] != null && row["ExportState"].ToString() != "")
                {
                    model.ExportState = row["ExportState"].ToString();
                }
                if (row["outState"] != null && row["outState"].ToString() != "")
                {
                    model.outState = row["outState"].ToString();
                }
                if (row["Residence"] != null && row["Residence"].ToString() != "")
                {
                    model.Residence = row["Residence"].ToString();
                }
                if (row["Occupation"] != null && row["Occupation"].ToString() != "")
                {
                    model.Occupation = row["Occupation"].ToString();
                }
                if (row["DepartureRecord"] != null && row["DepartureRecord"].ToString() != "")
                {
                    model.DepartureRecord = row["DepartureRecord"].ToString();
                }
                if (row["Marriaged"] != null && row["Marriaged"].ToString() != "")
                {
                    model.Marriaged = row["Marriaged"].ToString();
                }
                if (row["Identification"] != null && row["Identification"].ToString() != "")
                {
                    model.Identification = row["Identification"].ToString();
                }
                if (row["FinancialCapacity"] != null && row["FinancialCapacity"].ToString() != "")
                {
                    model.FinancialCapacity = row["FinancialCapacity"].ToString();
                }
                if (row["AgencyOpinion"] != null && row["AgencyOpinion"].ToString() != "")
                {
                    model.AgencyOpinion = row["AgencyOpinion"].ToString();
                }
                if (row["HasTypeIn"] != null && row["HasTypeIn"].ToString() != "")
                {
                    model.HasTypeIn = row["HasTypeIn"].ToString();
                }
                if (row["AbnormalOutTime"] != null && row["AbnormalOutTime"].ToString() != "")
                {
                    model.AbnormalOutTime = DateTime.Parse(row["AbnormalOutTime"].ToString());
                }
                if (row["HasChecked"] != null && row["HasChecked"].ToString() != "")
                {
                    model.HasChecked = row["HasChecked"].ToString();
                }
                if (row["CheckPerson"] != null && row["CheckPerson"].ToString() != "")
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
                if (row["IssuePlaceEnglish"] != null && row["IssuePlaceEnglish"].ToString() != "")
                {
                    model.IssuePlaceEnglish = row["IssuePlaceEnglish"].ToString();
                }
                if (row["BirthPlaceEnglish"] != null && row["BirthPlaceEnglish"].ToString() != "")
                {
                    model.BirthPlaceEnglish = row["BirthPlaceEnglish"].ToString();
                }
                if (row["JobId"] != null && row["JobId"].ToString() != "")
                {
                    model.JobId = int.Parse(row["JobId"].ToString());
                }
                if (row["AssignmentToWorkId"] != null && row["AssignmentToWorkId"].ToString() != "")
                {
                    model.AssignmentToWorkId = row["AssignmentToWorkId"].ToString();
                }
                if (row["AssignmentToUserName"] != null && row["AssignmentToUserName"].ToString() != "")
                {
                    model.AssignmentToUserName = row["AssignmentToUserName"].ToString();
                }
                if (row["District"] != null && row["District"].ToString() != "")
                {
                    model.District = int.Parse(row["District"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return GetList(0, strWhere, "");
        }

        /// <summary>
        /// 获得前几行数据,top=0则是全部数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" VisaInfo_id, Visa_id, GroupNo, Name, EnglishName, Sex, Birthday, PassportNo, LicenceTime, ExpiryDate, Birthplace, IssuePlace, Post, Phone, GuideNo, Client, Salesperson, Types, Sale_id, DepartmentId, Tips, EntryTime, EmbassyTime, InTime, OutTime, RealOut, RealOutTime, Country, Call, ExportState, outState, Residence, Occupation, DepartureRecord, Marriaged, Identification, FinancialCapacity, AgencyOpinion, HasTypeIn, AbnormalOutTime, HasChecked, CheckPerson, ReturnTime, Position, IssuePlaceEnglish, BirthPlaceEnglish, JobId, AssignmentToWorkId, AssignmentToUserName, District  ");
            strSql.Append(" FROM VisaInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

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
        /// 分页获取数据列表,orderby 必须传(要自己带desc)
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select VisaInfo_id, Visa_id, GroupNo, Name, EnglishName, Sex, Birthday, PassportNo, LicenceTime, ExpiryDate, Birthplace, IssuePlace, Post, Phone, GuideNo, Client, Salesperson, Types, Sale_id, DepartmentId, Tips, EntryTime, EmbassyTime, InTime, OutTime, RealOut, RealOutTime, Country, Call, ExportState, outState, Residence, Occupation, DepartureRecord, Marriaged, Identification, FinancialCapacity, AgencyOpinion, HasTypeIn, AbnormalOutTime, HasChecked, CheckPerson, ReturnTime, Position, IssuePlaceEnglish, BirthPlaceEnglish, JobId, AssignmentToWorkId, AssignmentToUserName, District  ");

            strSql.Append(" FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            strSql.Append(")AS Row, T.*  from VisaInfo T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

