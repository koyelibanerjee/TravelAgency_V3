using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace TravelAgency.DAL
{
    //Visa
    public partial class Visa
    {

        public bool Exists(Guid Visa_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Visa");
            strSql.Append(" where ");
            strSql.Append(" Visa_id = @Visa_id  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Visa_id", SqlDbType.UniqueIdentifier,16)         };
            parameters[0].Value = Visa_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据,整形自增长返回id,guid返回parameters[0].Value,string返回true or false
        /// </summary>
        public Guid Add(TravelAgency.Model.Visa model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Visa(");
            strSql.Append("Visa_id,GroupNo,Name,Types,Tips,DepartureTime,RealTime,FinishTime,Satus,Person,Number,Picture,ListCount,List,SalesPerson,Receipt,Quidco,Cost,OtherCost,ExpressNo,Call,Sale_id,DepartmentId,EntryTime,Country,Passengers,WorkId,Documenter,Price,ConsulateCost,VisaPersonCost,MailCost,Tips2,SubmitFlag,GroupPrice,InvitationCost,Remark,SubmitTime,InTime,OutTime,client,DepartureType,SubmitCondition,FetchCondition,TypeInPerson,CheckPerson,IsUrgent,PeiQianYuan,QuQianYuan,Operator,ClaimedFlag,ActuallyAmount,IsOutDelivery,OutDeliveryPlace,RequestFlag,RequestFlagUserName,ForRequestGroupNo,District,PaymentNo,ActivityOrderNo,PredictTime,SubmitTempNo,ClaimPrice");
            strSql.Append(") values (");
            strSql.Append("@Visa_id,@GroupNo,@Name,@Types,@Tips,@DepartureTime,@RealTime,@FinishTime,@Satus,@Person,@Number,@Picture,@ListCount,@List,@SalesPerson,@Receipt,@Quidco,@Cost,@OtherCost,@ExpressNo,@Call,@Sale_id,@DepartmentId,@EntryTime,@Country,@Passengers,@WorkId,@Documenter,@Price,@ConsulateCost,@VisaPersonCost,@MailCost,@Tips2,@SubmitFlag,@GroupPrice,@InvitationCost,@Remark,@SubmitTime,@InTime,@OutTime,@client,@DepartureType,@SubmitCondition,@FetchCondition,@TypeInPerson,@CheckPerson,@IsUrgent,@PeiQianYuan,@QuQianYuan,@Operator,@ClaimedFlag,@ActuallyAmount,@IsOutDelivery,@OutDeliveryPlace,@RequestFlag,@RequestFlagUserName,@ForRequestGroupNo,@District,@PaymentNo,@ActivityOrderNo,@PredictTime,@SubmitTempNo,@ClaimPrice");
            strSql.Append(") ");

            SqlParameter[] parameters = {
                        new SqlParameter("@Visa_id", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@GroupNo", SqlDbType.VarChar,5000) ,
                        new SqlParameter("@Name", SqlDbType.VarChar,150) ,
                        new SqlParameter("@Types", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Tips", SqlDbType.VarChar,150) ,
                        new SqlParameter("@DepartureTime", SqlDbType.DateTime,3) ,
                        new SqlParameter("@RealTime", SqlDbType.DateTime) ,
                        new SqlParameter("@FinishTime", SqlDbType.DateTime) ,
                        new SqlParameter("@Satus", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Person", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Number", SqlDbType.Int,4) ,
                        new SqlParameter("@Picture", SqlDbType.Float,8) ,
                        new SqlParameter("@ListCount", SqlDbType.Float,8) ,
                        new SqlParameter("@List", SqlDbType.VarChar,50) ,
                        new SqlParameter("@SalesPerson", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Receipt", SqlDbType.Float,8) ,
                        new SqlParameter("@Quidco", SqlDbType.Float,8) ,
                        new SqlParameter("@Cost", SqlDbType.Float,8) ,
                        new SqlParameter("@OtherCost", SqlDbType.Float,8) ,
                        new SqlParameter("@ExpressNo", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Call", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Sale_id", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@DepartmentId", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@EntryTime", SqlDbType.DateTime) ,
                        new SqlParameter("@Country", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Passengers", SqlDbType.VarChar,-1) ,
                        new SqlParameter("@WorkId", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Documenter", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Price", SqlDbType.Float,8) ,
                        new SqlParameter("@ConsulateCost", SqlDbType.Float,8) ,
                        new SqlParameter("@VisaPersonCost", SqlDbType.Float,8) ,
                        new SqlParameter("@MailCost", SqlDbType.Float,8) ,
                        new SqlParameter("@Tips2", SqlDbType.VarChar,50) ,
                        new SqlParameter("@SubmitFlag", SqlDbType.Int,4) ,
                        new SqlParameter("@GroupPrice", SqlDbType.Float,8) ,
                        new SqlParameter("@InvitationCost", SqlDbType.Float,8) ,
                        new SqlParameter("@Remark", SqlDbType.VarChar,20) ,
                        new SqlParameter("@SubmitTime", SqlDbType.DateTime) ,
                        new SqlParameter("@InTime", SqlDbType.DateTime) ,
                        new SqlParameter("@OutTime", SqlDbType.DateTime) ,
                        new SqlParameter("@client", SqlDbType.VarChar,50) ,
                        new SqlParameter("@DepartureType", SqlDbType.VarChar,50) ,
                        new SqlParameter("@SubmitCondition", SqlDbType.VarChar,50) ,
                        new SqlParameter("@FetchCondition", SqlDbType.VarChar,50) ,
                        new SqlParameter("@TypeInPerson", SqlDbType.VarChar,50) ,
                        new SqlParameter("@CheckPerson", SqlDbType.VarChar,50) ,
                        new SqlParameter("@IsUrgent", SqlDbType.Bit,1) ,
                        new SqlParameter("@PeiQianYuan", SqlDbType.VarChar,50) ,
                        new SqlParameter("@QuQianYuan", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Operator", SqlDbType.VarChar,50) ,
                        new SqlParameter("@ClaimedFlag", SqlDbType.VarChar,10) ,
                        new SqlParameter("@ActuallyAmount", SqlDbType.Money,8) ,
                        new SqlParameter("@IsOutDelivery", SqlDbType.Bit,1) ,
                        new SqlParameter("@OutDeliveryPlace", SqlDbType.VarChar,20) ,
                        new SqlParameter("@RequestFlag", SqlDbType.VarChar,50) ,
                        new SqlParameter("@RequestFlagUserName", SqlDbType.VarChar,50) ,
                        new SqlParameter("@ForRequestGroupNo", SqlDbType.Bit,1) ,
                        new SqlParameter("@District", SqlDbType.Int,4) ,
                        new SqlParameter("@PaymentNo", SqlDbType.VarChar,100) ,
                        new SqlParameter("@ActivityOrderNo", SqlDbType.VarChar,50) ,
                        new SqlParameter("@PredictTime", SqlDbType.DateTime) ,
                        new SqlParameter("@SubmitTempNo", SqlDbType.VarChar,50) ,
                        new SqlParameter("@ClaimPrice", SqlDbType.Float,8)

            };

            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.GroupNo;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Types;
            parameters[4].Value = model.Tips;
            parameters[5].Value = model.DepartureTime;
            parameters[6].Value = model.RealTime;
            parameters[7].Value = model.FinishTime;
            parameters[8].Value = model.Satus;
            parameters[9].Value = model.Person;
            parameters[10].Value = model.Number;
            parameters[11].Value = model.Picture;
            parameters[12].Value = model.ListCount;
            parameters[13].Value = model.List;
            parameters[14].Value = model.SalesPerson;
            parameters[15].Value = model.Receipt;
            parameters[16].Value = model.Quidco;
            parameters[17].Value = model.Cost;
            parameters[18].Value = model.OtherCost;
            parameters[19].Value = model.ExpressNo;
            parameters[20].Value = model.Call;
            parameters[21].Value = model.Sale_id;
            parameters[22].Value = model.DepartmentId;
            parameters[23].Value = model.EntryTime;
            parameters[24].Value = model.Country;
            parameters[25].Value = model.Passengers;
            parameters[26].Value = model.WorkId;
            parameters[27].Value = model.Documenter;
            parameters[28].Value = model.Price;
            parameters[29].Value = model.ConsulateCost;
            parameters[30].Value = model.VisaPersonCost;
            parameters[31].Value = model.MailCost;
            parameters[32].Value = model.Tips2;
            parameters[33].Value = model.SubmitFlag;
            parameters[34].Value = model.GroupPrice;
            parameters[35].Value = model.InvitationCost;
            parameters[36].Value = model.Remark;
            parameters[37].Value = model.SubmitTime;
            parameters[38].Value = model.InTime;
            parameters[39].Value = model.OutTime;
            parameters[40].Value = model.client;
            parameters[41].Value = model.DepartureType;
            parameters[42].Value = model.SubmitCondition;
            parameters[43].Value = model.FetchCondition;
            parameters[44].Value = model.TypeInPerson;
            parameters[45].Value = model.CheckPerson;
            parameters[46].Value = model.IsUrgent;
            parameters[47].Value = model.PeiQianYuan;
            parameters[48].Value = model.QuQianYuan;
            parameters[49].Value = model.Operator;
            parameters[50].Value = model.ClaimedFlag;
            parameters[51].Value = model.ActuallyAmount;
            parameters[52].Value = model.IsOutDelivery;
            parameters[53].Value = model.OutDeliveryPlace;
            parameters[54].Value = model.RequestFlag;
            parameters[55].Value = model.RequestFlagUserName;
            parameters[56].Value = model.ForRequestGroupNo;
            parameters[57].Value = model.District;
            parameters[58].Value = model.PaymentNo;
            parameters[59].Value = model.ActivityOrderNo;
            parameters[60].Value = model.PredictTime;
            parameters[61].Value = model.SubmitTempNo;
            parameters[62].Value = model.ClaimPrice;
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
        public bool Update(TravelAgency.Model.Visa model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Visa set ");

            strSql.Append(" Visa_id = @Visa_id , ");
            strSql.Append(" GroupNo = @GroupNo , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" Types = @Types , ");
            strSql.Append(" Tips = @Tips , ");
            strSql.Append(" DepartureTime = @DepartureTime , ");
            strSql.Append(" RealTime = @RealTime , ");
            strSql.Append(" FinishTime = @FinishTime , ");
            strSql.Append(" Satus = @Satus , ");
            strSql.Append(" Person = @Person , ");
            strSql.Append(" Number = @Number , ");
            strSql.Append(" Picture = @Picture , ");
            strSql.Append(" ListCount = @ListCount , ");
            strSql.Append(" List = @List , ");
            strSql.Append(" SalesPerson = @SalesPerson , ");
            strSql.Append(" Receipt = @Receipt , ");
            strSql.Append(" Quidco = @Quidco , ");
            strSql.Append(" Cost = @Cost , ");
            strSql.Append(" OtherCost = @OtherCost , ");
            strSql.Append(" ExpressNo = @ExpressNo , ");
            strSql.Append(" Call = @Call , ");
            strSql.Append(" Sale_id = @Sale_id , ");
            strSql.Append(" DepartmentId = @DepartmentId , ");
            strSql.Append(" EntryTime = @EntryTime , ");
            strSql.Append(" Country = @Country , ");
            strSql.Append(" Passengers = @Passengers , ");
            strSql.Append(" WorkId = @WorkId , ");
            strSql.Append(" Documenter = @Documenter , ");
            strSql.Append(" Price = @Price , ");
            strSql.Append(" ConsulateCost = @ConsulateCost , ");
            strSql.Append(" VisaPersonCost = @VisaPersonCost , ");
            strSql.Append(" MailCost = @MailCost , ");
            strSql.Append(" Tips2 = @Tips2 , ");
            strSql.Append(" SubmitFlag = @SubmitFlag , ");
            strSql.Append(" GroupPrice = @GroupPrice , ");
            strSql.Append(" InvitationCost = @InvitationCost , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" SubmitTime = @SubmitTime , ");
            strSql.Append(" InTime = @InTime , ");
            strSql.Append(" OutTime = @OutTime , ");
            strSql.Append(" client = @client , ");
            strSql.Append(" DepartureType = @DepartureType , ");
            strSql.Append(" SubmitCondition = @SubmitCondition , ");
            strSql.Append(" FetchCondition = @FetchCondition , ");
            strSql.Append(" TypeInPerson = @TypeInPerson , ");
            strSql.Append(" CheckPerson = @CheckPerson , ");
            strSql.Append(" IsUrgent = @IsUrgent , ");
            strSql.Append(" PeiQianYuan = @PeiQianYuan , ");
            strSql.Append(" QuQianYuan = @QuQianYuan , ");
            strSql.Append(" Operator = @Operator , ");
            strSql.Append(" ClaimedFlag = @ClaimedFlag , ");
            strSql.Append(" ActuallyAmount = @ActuallyAmount , ");
            strSql.Append(" IsOutDelivery = @IsOutDelivery , ");
            strSql.Append(" OutDeliveryPlace = @OutDeliveryPlace , ");
            strSql.Append(" RequestFlag = @RequestFlag , ");
            strSql.Append(" RequestFlagUserName = @RequestFlagUserName , ");
            strSql.Append(" ForRequestGroupNo = @ForRequestGroupNo , ");
            strSql.Append(" District = @District , ");
            strSql.Append(" PaymentNo = @PaymentNo , ");
            strSql.Append(" ActivityOrderNo = @ActivityOrderNo , ");
            strSql.Append(" PredictTime = @PredictTime , ");
            strSql.Append(" SubmitTempNo = @SubmitTempNo , ");
            strSql.Append(" ClaimPrice = @ClaimPrice  ");
            strSql.Append(" where Visa_id=@Visa_id  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@Visa_id", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@GroupNo", SqlDbType.VarChar,5000) ,
                        new SqlParameter("@Name", SqlDbType.VarChar,150) ,
                        new SqlParameter("@Types", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Tips", SqlDbType.VarChar,150) ,
                        new SqlParameter("@DepartureTime", SqlDbType.DateTime,3) ,
                        new SqlParameter("@RealTime", SqlDbType.DateTime) ,
                        new SqlParameter("@FinishTime", SqlDbType.DateTime) ,
                        new SqlParameter("@Satus", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Person", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Number", SqlDbType.Int,4) ,
                        new SqlParameter("@Picture", SqlDbType.Float,8) ,
                        new SqlParameter("@ListCount", SqlDbType.Float,8) ,
                        new SqlParameter("@List", SqlDbType.VarChar,50) ,
                        new SqlParameter("@SalesPerson", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Receipt", SqlDbType.Float,8) ,
                        new SqlParameter("@Quidco", SqlDbType.Float,8) ,
                        new SqlParameter("@Cost", SqlDbType.Float,8) ,
                        new SqlParameter("@OtherCost", SqlDbType.Float,8) ,
                        new SqlParameter("@ExpressNo", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Call", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Sale_id", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@DepartmentId", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@EntryTime", SqlDbType.DateTime) ,
                        new SqlParameter("@Country", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Passengers", SqlDbType.VarChar,-1) ,
                        new SqlParameter("@WorkId", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Documenter", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Price", SqlDbType.Float,8) ,
                        new SqlParameter("@ConsulateCost", SqlDbType.Float,8) ,
                        new SqlParameter("@VisaPersonCost", SqlDbType.Float,8) ,
                        new SqlParameter("@MailCost", SqlDbType.Float,8) ,
                        new SqlParameter("@Tips2", SqlDbType.VarChar,50) ,
                        new SqlParameter("@SubmitFlag", SqlDbType.Int,4) ,
                        new SqlParameter("@GroupPrice", SqlDbType.Float,8) ,
                        new SqlParameter("@InvitationCost", SqlDbType.Float,8) ,
                        new SqlParameter("@Remark", SqlDbType.VarChar,20) ,
                        new SqlParameter("@SubmitTime", SqlDbType.DateTime) ,
                        new SqlParameter("@InTime", SqlDbType.DateTime) ,
                        new SqlParameter("@OutTime", SqlDbType.DateTime) ,
                        new SqlParameter("@client", SqlDbType.VarChar,50) ,
                        new SqlParameter("@DepartureType", SqlDbType.VarChar,50) ,
                        new SqlParameter("@SubmitCondition", SqlDbType.VarChar,50) ,
                        new SqlParameter("@FetchCondition", SqlDbType.VarChar,50) ,
                        new SqlParameter("@TypeInPerson", SqlDbType.VarChar,50) ,
                        new SqlParameter("@CheckPerson", SqlDbType.VarChar,50) ,
                        new SqlParameter("@IsUrgent", SqlDbType.Bit,1) ,
                        new SqlParameter("@PeiQianYuan", SqlDbType.VarChar,50) ,
                        new SqlParameter("@QuQianYuan", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Operator", SqlDbType.VarChar,50) ,
                        new SqlParameter("@ClaimedFlag", SqlDbType.VarChar,10) ,
                        new SqlParameter("@ActuallyAmount", SqlDbType.Money,8) ,
                        new SqlParameter("@IsOutDelivery", SqlDbType.Bit,1) ,
                        new SqlParameter("@OutDeliveryPlace", SqlDbType.VarChar,20) ,
                        new SqlParameter("@RequestFlag", SqlDbType.VarChar,50) ,
                        new SqlParameter("@RequestFlagUserName", SqlDbType.VarChar,50) ,
                        new SqlParameter("@ForRequestGroupNo", SqlDbType.Bit,1) ,
                        new SqlParameter("@District", SqlDbType.Int,4) ,
                        new SqlParameter("@PaymentNo", SqlDbType.VarChar,100) ,
                        new SqlParameter("@ActivityOrderNo", SqlDbType.VarChar,50) ,
                        new SqlParameter("@PredictTime", SqlDbType.DateTime) ,
                        new SqlParameter("@SubmitTempNo", SqlDbType.VarChar,50) ,
                        new SqlParameter("@ClaimPrice", SqlDbType.Float,8)

            };

            parameters[0].Value = model.Visa_id;
            parameters[1].Value = model.GroupNo;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Types;
            parameters[4].Value = model.Tips;
            parameters[5].Value = model.DepartureTime;
            parameters[6].Value = model.RealTime;
            parameters[7].Value = model.FinishTime;
            parameters[8].Value = model.Satus;
            parameters[9].Value = model.Person;
            parameters[10].Value = model.Number;
            parameters[11].Value = model.Picture;
            parameters[12].Value = model.ListCount;
            parameters[13].Value = model.List;
            parameters[14].Value = model.SalesPerson;
            parameters[15].Value = model.Receipt;
            parameters[16].Value = model.Quidco;
            parameters[17].Value = model.Cost;
            parameters[18].Value = model.OtherCost;
            parameters[19].Value = model.ExpressNo;
            parameters[20].Value = model.Call;
            parameters[21].Value = model.Sale_id;
            parameters[22].Value = model.DepartmentId;
            parameters[23].Value = model.EntryTime;
            parameters[24].Value = model.Country;
            parameters[25].Value = model.Passengers;
            parameters[26].Value = model.WorkId;
            parameters[27].Value = model.Documenter;
            parameters[28].Value = model.Price;
            parameters[29].Value = model.ConsulateCost;
            parameters[30].Value = model.VisaPersonCost;
            parameters[31].Value = model.MailCost;
            parameters[32].Value = model.Tips2;
            parameters[33].Value = model.SubmitFlag;
            parameters[34].Value = model.GroupPrice;
            parameters[35].Value = model.InvitationCost;
            parameters[36].Value = model.Remark;
            parameters[37].Value = model.SubmitTime;
            parameters[38].Value = model.InTime;
            parameters[39].Value = model.OutTime;
            parameters[40].Value = model.client;
            parameters[41].Value = model.DepartureType;
            parameters[42].Value = model.SubmitCondition;
            parameters[43].Value = model.FetchCondition;
            parameters[44].Value = model.TypeInPerson;
            parameters[45].Value = model.CheckPerson;
            parameters[46].Value = model.IsUrgent;
            parameters[47].Value = model.PeiQianYuan;
            parameters[48].Value = model.QuQianYuan;
            parameters[49].Value = model.Operator;
            parameters[50].Value = model.ClaimedFlag;
            parameters[51].Value = model.ActuallyAmount;
            parameters[52].Value = model.IsOutDelivery;
            parameters[53].Value = model.OutDeliveryPlace;
            parameters[54].Value = model.RequestFlag;
            parameters[55].Value = model.RequestFlagUserName;
            parameters[56].Value = model.ForRequestGroupNo;
            parameters[57].Value = model.District;
            parameters[58].Value = model.PaymentNo;
            parameters[59].Value = model.ActivityOrderNo;
            parameters[60].Value = model.PredictTime;
            parameters[61].Value = model.SubmitTempNo;
            parameters[62].Value = model.ClaimPrice;
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
        public bool Delete(Guid Visa_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Visa ");
            strSql.Append(" where Visa_id=@Visa_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Visa_id", SqlDbType.UniqueIdentifier,16)         };
            parameters[0].Value = Visa_id;


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
        public bool DeleteList(string Visa_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Visa ");
            strSql.Append(" where Visa_id in (" + Visa_idlist + ")  ");
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
        public TravelAgency.Model.Visa GetModel(Guid Visa_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Visa_id, GroupNo, Name, Types, Tips, DepartureTime, RealTime, FinishTime, Satus, Person, Number, Picture, ListCount, List, SalesPerson, Receipt, Quidco, Cost, OtherCost, ExpressNo, Call, Sale_id, DepartmentId, EntryTime, Country, Passengers, WorkId, Documenter, Price, ConsulateCost, VisaPersonCost, MailCost, Tips2, SubmitFlag, GroupPrice, InvitationCost, Remark, SubmitTime, InTime, OutTime, client, DepartureType, SubmitCondition, FetchCondition, TypeInPerson, CheckPerson, IsUrgent, PeiQianYuan, QuQianYuan, Operator, ClaimedFlag, ActuallyAmount, IsOutDelivery, OutDeliveryPlace, RequestFlag, RequestFlagUserName, ForRequestGroupNo, District, PaymentNo, ActivityOrderNo, PredictTime, SubmitTempNo, ClaimPrice  ");
            strSql.Append("  from Visa ");
            strSql.Append(" where Visa_id=@Visa_id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Visa_id", SqlDbType.UniqueIdentifier,16)         };
            parameters[0].Value = Visa_id;


            TravelAgency.Model.Visa model = new TravelAgency.Model.Visa();
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
        public TravelAgency.Model.Visa DataRowToModel(DataRow row)
        {
            TravelAgency.Model.Visa model = new TravelAgency.Model.Visa();
            if (row != null)
            {
                if (row["Visa_id"] != null && row["Visa_id"].ToString() != "")
                {
                    model.Visa_id = new Guid(row["Visa_id"].ToString());
                }
                if (row["GroupNo"] != null && row["GroupNo"].ToString() != "")
                {
                    model.GroupNo = row["GroupNo"].ToString();
                }
                if (row["Name"] != null && row["Name"].ToString() != "")
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Types"] != null && row["Types"].ToString() != "")
                {
                    model.Types = row["Types"].ToString();
                }
                if (row["Tips"] != null && row["Tips"].ToString() != "")
                {
                    model.Tips = row["Tips"].ToString();
                }
                if (row["DepartureTime"] != null && row["DepartureTime"].ToString() != "")
                {
                    model.DepartureTime = DateTime.Parse(row["DepartureTime"].ToString());
                }
                if (row["RealTime"] != null && row["RealTime"].ToString() != "")
                {
                    model.RealTime = DateTime.Parse(row["RealTime"].ToString());
                }
                if (row["FinishTime"] != null && row["FinishTime"].ToString() != "")
                {
                    model.FinishTime = DateTime.Parse(row["FinishTime"].ToString());
                }
                if (row["Satus"] != null && row["Satus"].ToString() != "")
                {
                    model.Satus = row["Satus"].ToString();
                }
                if (row["Person"] != null && row["Person"].ToString() != "")
                {
                    model.Person = row["Person"].ToString();
                }
                if (row["Number"] != null && row["Number"].ToString() != "")
                {
                    model.Number = int.Parse(row["Number"].ToString());
                }
                if (row["Picture"] != null && row["Picture"].ToString() != "")
                {
                    model.Picture = decimal.Parse(row["Picture"].ToString());
                }
                if (row["ListCount"] != null && row["ListCount"].ToString() != "")
                {
                    model.ListCount = decimal.Parse(row["ListCount"].ToString());
                }
                if (row["List"] != null && row["List"].ToString() != "")
                {
                    model.List = row["List"].ToString();
                }
                if (row["SalesPerson"] != null && row["SalesPerson"].ToString() != "")
                {
                    model.SalesPerson = row["SalesPerson"].ToString();
                }
                if (row["Receipt"] != null && row["Receipt"].ToString() != "")
                {
                    model.Receipt = decimal.Parse(row["Receipt"].ToString());
                }
                if (row["Quidco"] != null && row["Quidco"].ToString() != "")
                {
                    model.Quidco = decimal.Parse(row["Quidco"].ToString());
                }
                if (row["Cost"] != null && row["Cost"].ToString() != "")
                {
                    model.Cost = decimal.Parse(row["Cost"].ToString());
                }
                if (row["OtherCost"] != null && row["OtherCost"].ToString() != "")
                {
                    model.OtherCost = decimal.Parse(row["OtherCost"].ToString());
                }
                if (row["ExpressNo"] != null && row["ExpressNo"].ToString() != "")
                {
                    model.ExpressNo = row["ExpressNo"].ToString();
                }
                if (row["Call"] != null && row["Call"].ToString() != "")
                {
                    model.Call = row["Call"].ToString();
                }
                if (row["Sale_id"] != null && row["Sale_id"].ToString() != "")
                {
                    model.Sale_id = new Guid(row["Sale_id"].ToString());
                }
                if (row["DepartmentId"] != null && row["DepartmentId"].ToString() != "")
                {
                    model.DepartmentId = new Guid(row["DepartmentId"].ToString());
                }
                if (row["EntryTime"] != null && row["EntryTime"].ToString() != "")
                {
                    model.EntryTime = DateTime.Parse(row["EntryTime"].ToString());
                }
                if (row["Country"] != null && row["Country"].ToString() != "")
                {
                    model.Country = row["Country"].ToString();
                }
                if (row["Passengers"] != null && row["Passengers"].ToString() != "")
                {
                    model.Passengers = row["Passengers"].ToString();
                }
                if (row["WorkId"] != null && row["WorkId"].ToString() != "")
                {
                    model.WorkId = row["WorkId"].ToString();
                }
                if (row["Documenter"] != null && row["Documenter"].ToString() != "")
                {
                    model.Documenter = row["Documenter"].ToString();
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(row["Price"].ToString());
                }
                if (row["ConsulateCost"] != null && row["ConsulateCost"].ToString() != "")
                {
                    model.ConsulateCost = decimal.Parse(row["ConsulateCost"].ToString());
                }
                if (row["VisaPersonCost"] != null && row["VisaPersonCost"].ToString() != "")
                {
                    model.VisaPersonCost = decimal.Parse(row["VisaPersonCost"].ToString());
                }
                if (row["MailCost"] != null && row["MailCost"].ToString() != "")
                {
                    model.MailCost = decimal.Parse(row["MailCost"].ToString());
                }
                if (row["Tips2"] != null && row["Tips2"].ToString() != "")
                {
                    model.Tips2 = row["Tips2"].ToString();
                }
                if (row["SubmitFlag"] != null && row["SubmitFlag"].ToString() != "")
                {
                    model.SubmitFlag = int.Parse(row["SubmitFlag"].ToString());
                }
                if (row["GroupPrice"] != null && row["GroupPrice"].ToString() != "")
                {
                    model.GroupPrice = decimal.Parse(row["GroupPrice"].ToString());
                }
                if (row["InvitationCost"] != null && row["InvitationCost"].ToString() != "")
                {
                    model.InvitationCost = decimal.Parse(row["InvitationCost"].ToString());
                }
                if (row["Remark"] != null && row["Remark"].ToString() != "")
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["SubmitTime"] != null && row["SubmitTime"].ToString() != "")
                {
                    model.SubmitTime = DateTime.Parse(row["SubmitTime"].ToString());
                }
                if (row["InTime"] != null && row["InTime"].ToString() != "")
                {
                    model.InTime = DateTime.Parse(row["InTime"].ToString());
                }
                if (row["OutTime"] != null && row["OutTime"].ToString() != "")
                {
                    model.OutTime = DateTime.Parse(row["OutTime"].ToString());
                }
                if (row["client"] != null && row["client"].ToString() != "")
                {
                    model.client = row["client"].ToString();
                }
                if (row["DepartureType"] != null && row["DepartureType"].ToString() != "")
                {
                    model.DepartureType = row["DepartureType"].ToString();
                }
                if (row["SubmitCondition"] != null && row["SubmitCondition"].ToString() != "")
                {
                    model.SubmitCondition = row["SubmitCondition"].ToString();
                }
                if (row["FetchCondition"] != null && row["FetchCondition"].ToString() != "")
                {
                    model.FetchCondition = row["FetchCondition"].ToString();
                }
                if (row["TypeInPerson"] != null && row["TypeInPerson"].ToString() != "")
                {
                    model.TypeInPerson = row["TypeInPerson"].ToString();
                }
                if (row["CheckPerson"] != null && row["CheckPerson"].ToString() != "")
                {
                    model.CheckPerson = row["CheckPerson"].ToString();
                }
                if (row["IsUrgent"] != null && row["IsUrgent"].ToString() != "")
                {
                    if ((row["IsUrgent"].ToString() == "1") || (row["IsUrgent"].ToString().ToLower() == "true"))
                    {
                        model.IsUrgent = true;
                    }
                    else
                    {
                        model.IsUrgent = false;
                    }
                }
                if (row["PeiQianYuan"] != null && row["PeiQianYuan"].ToString() != "")
                {
                    model.PeiQianYuan = row["PeiQianYuan"].ToString();
                }
                if (row["QuQianYuan"] != null && row["QuQianYuan"].ToString() != "")
                {
                    model.QuQianYuan = row["QuQianYuan"].ToString();
                }
                if (row["Operator"] != null && row["Operator"].ToString() != "")
                {
                    model.Operator = row["Operator"].ToString();
                }
                if (row["ClaimedFlag"] != null && row["ClaimedFlag"].ToString() != "")
                {
                    model.ClaimedFlag = row["ClaimedFlag"].ToString();
                }
                if (row["ActuallyAmount"] != null && row["ActuallyAmount"].ToString() != "")
                {
                    model.ActuallyAmount = decimal.Parse(row["ActuallyAmount"].ToString());
                }
                if (row["IsOutDelivery"] != null && row["IsOutDelivery"].ToString() != "")
                {
                    if ((row["IsOutDelivery"].ToString() == "1") || (row["IsOutDelivery"].ToString().ToLower() == "true"))
                    {
                        model.IsOutDelivery = true;
                    }
                    else
                    {
                        model.IsOutDelivery = false;
                    }
                }
                if (row["OutDeliveryPlace"] != null && row["OutDeliveryPlace"].ToString() != "")
                {
                    model.OutDeliveryPlace = row["OutDeliveryPlace"].ToString();
                }
                if (row["RequestFlag"] != null && row["RequestFlag"].ToString() != "")
                {
                    model.RequestFlag = row["RequestFlag"].ToString();
                }
                if (row["RequestFlagUserName"] != null && row["RequestFlagUserName"].ToString() != "")
                {
                    model.RequestFlagUserName = row["RequestFlagUserName"].ToString();
                }
                if (row["ForRequestGroupNo"] != null && row["ForRequestGroupNo"].ToString() != "")
                {
                    if ((row["ForRequestGroupNo"].ToString() == "1") || (row["ForRequestGroupNo"].ToString().ToLower() == "true"))
                    {
                        model.ForRequestGroupNo = true;
                    }
                    else
                    {
                        model.ForRequestGroupNo = false;
                    }
                }
                if (row["District"] != null && row["District"].ToString() != "")
                {
                    model.District = int.Parse(row["District"].ToString());
                }
                if (row["PaymentNo"] != null && row["PaymentNo"].ToString() != "")
                {
                    model.PaymentNo = row["PaymentNo"].ToString();
                }
                if (row["ActivityOrderNo"] != null && row["ActivityOrderNo"].ToString() != "")
                {
                    model.ActivityOrderNo = row["ActivityOrderNo"].ToString();
                }
                if (row["PredictTime"] != null && row["PredictTime"].ToString() != "")
                {
                    model.PredictTime = DateTime.Parse(row["PredictTime"].ToString());
                }
                if (row["SubmitTempNo"] != null && row["SubmitTempNo"].ToString() != "")
                {
                    model.SubmitTempNo = row["SubmitTempNo"].ToString();
                }
                if (row["ClaimPrice"] != null && row["ClaimPrice"].ToString() != "")
                {
                    model.ClaimPrice = decimal.Parse(row["ClaimPrice"].ToString());
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
            strSql.Append(" Visa_id, GroupNo, Name, Types, Tips, DepartureTime, RealTime, FinishTime, Satus, Person, Number, Picture, ListCount, List, SalesPerson, Receipt, Quidco, Cost, OtherCost, ExpressNo, Call, Sale_id, DepartmentId, EntryTime, Country, Passengers, WorkId, Documenter, Price, ConsulateCost, VisaPersonCost, MailCost, Tips2, SubmitFlag, GroupPrice, InvitationCost, Remark, SubmitTime, InTime, OutTime, client, DepartureType, SubmitCondition, FetchCondition, TypeInPerson, CheckPerson, IsUrgent, PeiQianYuan, QuQianYuan, Operator, ClaimedFlag, ActuallyAmount, IsOutDelivery, OutDeliveryPlace, RequestFlag, RequestFlagUserName, ForRequestGroupNo, District, PaymentNo, ActivityOrderNo, PredictTime, SubmitTempNo, ClaimPrice  ");
            strSql.Append(" FROM Visa ");
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
            strSql.Append("select count(1) FROM Visa ");
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
            strSql.Append("select Visa_id, GroupNo, Name, Types, Tips, DepartureTime, RealTime, FinishTime, Satus, Person, Number, Picture, ListCount, List, SalesPerson, Receipt, Quidco, Cost, OtherCost, ExpressNo, Call, Sale_id, DepartmentId, EntryTime, Country, Passengers, WorkId, Documenter, Price, ConsulateCost, VisaPersonCost, MailCost, Tips2, SubmitFlag, GroupPrice, InvitationCost, Remark, SubmitTime, InTime, OutTime, client, DepartureType, SubmitCondition, FetchCondition, TypeInPerson, CheckPerson, IsUrgent, PeiQianYuan, QuQianYuan, Operator, ClaimedFlag, ActuallyAmount, IsOutDelivery, OutDeliveryPlace, RequestFlag, RequestFlagUserName, ForRequestGroupNo, District, PaymentNo, ActivityOrderNo, PredictTime, SubmitTempNo, ClaimPrice  ");

            strSql.Append(" FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            strSql.Append(")AS Row, T.*  from Visa T ");
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

