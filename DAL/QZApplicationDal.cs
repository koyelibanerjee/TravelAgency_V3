using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace TravelAgency.DAL
{
	/// <summary>
	/// 数据访问类:QZApplication
	/// </summary>
	public partial class QZApplication
	{
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(TravelAgency.Model.QZApplication model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into QZApplication(");
            strSql.Append("QZApp_id,Visa_id,SubName,DepartmentId,GroupNo,SendTime,FinishTime,Person,Number,Tips,Price,Receipt,Quidco,ConsulateCost,VisaPersonCost,MailCost,PictureCost,Sales,WorkId,EntryTime,App_id,Flag,Country,Name,InvitationCost,cost)");
            strSql.Append(" values (");
            strSql.Append("@QZApp_id,@Visa_id,@SubName,@DepartmentId,@GroupNo,@SendTime,@FinishTime,@Person,@Number,@Tips,@Price,@Receipt,@Quidco,@ConsulateCost,@VisaPersonCost,@MailCost,@PictureCost,@Sales,@WorkId,@EntryTime,@App_id,@Flag,@Country,@Name,@InvitationCost,@cost)");
            SqlParameter[] parameters = {
                    new SqlParameter("@QZApp_id", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@Visa_id", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@SubName", SqlDbType.VarChar,50),
                    new SqlParameter("@DepartmentId", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@GroupNo", SqlDbType.VarChar,255),
                    new SqlParameter("@SendTime", SqlDbType.DateTime,3),
                    new SqlParameter("@FinishTime", SqlDbType.DateTime,3),
                    new SqlParameter("@Person", SqlDbType.NChar,10),
                    new SqlParameter("@Number", SqlDbType.Int,4),
                    new SqlParameter("@Tips", SqlDbType.VarChar,50),
                    new SqlParameter("@Price", SqlDbType.Float,8),
                    new SqlParameter("@Receipt", SqlDbType.Float,8),
                    new SqlParameter("@Quidco", SqlDbType.Float,8),
                    new SqlParameter("@ConsulateCost", SqlDbType.Float,8),
                    new SqlParameter("@VisaPersonCost", SqlDbType.Float,8),
                    new SqlParameter("@MailCost", SqlDbType.Float,8),
                    new SqlParameter("@PictureCost", SqlDbType.Float,8),
                    new SqlParameter("@Sales", SqlDbType.VarChar,50),
                    new SqlParameter("@WorkId", SqlDbType.VarChar,50),
                    new SqlParameter("@EntryTime", SqlDbType.DateTime),
                    new SqlParameter("@App_id", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@Flag", SqlDbType.Int,4),
                    new SqlParameter("@Country", SqlDbType.VarChar,50),
                    new SqlParameter("@Name", SqlDbType.VarChar,150),
                    new SqlParameter("@InvitationCost", SqlDbType.Float,8),
                    new SqlParameter("@cost", SqlDbType.Float,8)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.Visa_id;
            parameters[2].Value = model.SubName;
            parameters[3].Value =model.DepartmentId;
            parameters[4].Value = model.GroupNo;
            parameters[5].Value = model.SendTime;
            parameters[6].Value = model.FinishTime;
            parameters[7].Value = model.Person;
            parameters[8].Value = model.Number;
            parameters[9].Value = model.Tips;
            parameters[10].Value = model.Price;
            parameters[11].Value = model.Receipt;
            parameters[12].Value = model.Quidco;
            parameters[13].Value = model.ConsulateCost;
            parameters[14].Value = model.VisaPersonCost;
            parameters[15].Value = model.MailCost;
            parameters[16].Value = model.PictureCost;
            parameters[17].Value = model.Sales;
            parameters[18].Value = model.WorkId;
            parameters[19].Value = model.EntryTime;
            parameters[20].Value = model.App_id;
            parameters[21].Value = model.Flag;
            parameters[22].Value = model.Country;
            parameters[23].Value = model.Name;
            parameters[24].Value = model.InvitationCost;
            parameters[25].Value = model.Cost;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(TravelAgency.Model.QZApplication model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update QZApplication set ");

            strSql.Append(" QZApp_id = @QZApp_id , ");
            strSql.Append(" Visa_id = @Visa_id , ");
            strSql.Append(" SubName = @SubName , ");
            strSql.Append(" DepartmentId = @DepartmentId , ");
            strSql.Append(" GroupNo = @GroupNo , ");
            strSql.Append(" SendTime = @SendTime , ");
            strSql.Append(" FinishTime = @FinishTime , ");
            strSql.Append(" Person = @Person , ");
            strSql.Append(" Number = @Number , ");
            strSql.Append(" Tips = @Tips , ");
            strSql.Append(" Price = @Price , ");
            strSql.Append(" Receipt = @Receipt , ");
            strSql.Append(" Quidco = @Quidco , ");
            strSql.Append(" ConsulateCost = @ConsulateCost , ");
            strSql.Append(" VisaPersonCost = @VisaPersonCost , ");
            strSql.Append(" MailCost = @MailCost , ");
            strSql.Append(" PictureCost = @PictureCost , ");
            strSql.Append(" Sales = @Sales , ");
            strSql.Append(" WorkId = @WorkId , ");
            strSql.Append(" EntryTime = @EntryTime , ");
            strSql.Append(" App_id = @App_id , ");
            strSql.Append(" Flag = @Flag , ");
            strSql.Append(" Country = @Country , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" InvitationCost = @InvitationCost , ");
            strSql.Append(" Cost = @Cost  ");
            strSql.Append(" where  QZApp_id = @QZApp_id ");

            SqlParameter[] parameters = {
                        new SqlParameter("@QZApp_id", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@Visa_id", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@SubName", SqlDbType.VarChar,50) ,
                        new SqlParameter("@DepartmentId", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@GroupNo", SqlDbType.VarChar,5000) ,
                        new SqlParameter("@SendTime", SqlDbType.DateTime,3) ,
                        new SqlParameter("@FinishTime", SqlDbType.DateTime,3) ,
                        new SqlParameter("@Person", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Number", SqlDbType.Int,4) ,
                        new SqlParameter("@Tips", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Price", SqlDbType.Float,8) ,
                        new SqlParameter("@Receipt", SqlDbType.Float,8) ,
                        new SqlParameter("@Quidco", SqlDbType.Float,8) ,
                        new SqlParameter("@ConsulateCost", SqlDbType.Float,8) ,
                        new SqlParameter("@VisaPersonCost", SqlDbType.Float,8) ,
                        new SqlParameter("@MailCost", SqlDbType.Float,8) ,
                        new SqlParameter("@PictureCost", SqlDbType.Float,8) ,
                        new SqlParameter("@Sales", SqlDbType.VarChar,50) ,
                        new SqlParameter("@WorkId", SqlDbType.VarChar,50) ,
                        new SqlParameter("@EntryTime", SqlDbType.DateTime) ,
                        new SqlParameter("@App_id", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@Flag", SqlDbType.Int,4) ,
                        new SqlParameter("@Country", SqlDbType.VarChar,50) ,
                        new SqlParameter("@Name", SqlDbType.VarChar,150) ,
                        new SqlParameter("@InvitationCost", SqlDbType.Float,8) ,
                        new SqlParameter("@Cost", SqlDbType.Float,8)

            };

            parameters[0].Value = model.QZApp_id;
            parameters[1].Value = model.Visa_id;
            parameters[2].Value = model.SubName;
            parameters[3].Value = model.DepartmentId;
            parameters[4].Value = model.GroupNo;
            parameters[5].Value = model.SendTime;
            parameters[6].Value = model.FinishTime;
            parameters[7].Value = model.Person;
            parameters[8].Value = model.Number;
            parameters[9].Value = model.Tips;
            parameters[10].Value = model.Price;
            parameters[11].Value = model.Receipt;
            parameters[12].Value = model.Quidco;
            parameters[13].Value = model.ConsulateCost;
            parameters[14].Value = model.VisaPersonCost;
            parameters[15].Value = model.MailCost;
            parameters[16].Value = model.PictureCost;
            parameters[17].Value = model.Sales;
            parameters[18].Value = model.WorkId;
            parameters[19].Value = model.EntryTime;
            parameters[20].Value = model.App_id;
            parameters[21].Value = model.Flag;
            parameters[22].Value = model.Country;
            parameters[23].Value = model.Name;
            parameters[24].Value = model.InvitationCost;
            parameters[25].Value = model.Cost;
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

