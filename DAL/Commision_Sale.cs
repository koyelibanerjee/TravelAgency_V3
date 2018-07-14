using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace TravelAgency.DAL
{
    //Commision_Sale
    public partial class Commision_Sale
    {

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Commision_Sale");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据,整形自增长返回id,guid返回parameters[0].Value,string返回true or false
        /// </summary>
        public int Add(TravelAgency.Model.Commision_Sale model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Commision_Sale(");
            strSql.Append("Country,ConsularDistrict,DepartureType,CompanyPrice,Price1,Commision1,Margin1,Price2,Commision2,Margin2,Price3,Commision3,Margin3,DirectGuestPrice,DirectGuestCommision,DirectGuestMargin,SalesPersonCredits");
            strSql.Append(") values (");
            strSql.Append("@Country,@ConsularDistrict,@DepartureType,@CompanyPrice,@Price1,@Commision1,@Margin1,@Price2,@Commision2,@Margin2,@Price3,@Commision3,@Margin3,@DirectGuestPrice,@DirectGuestCommision,@DirectGuestMargin,@SalesPersonCredits");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@Country", SqlDbType.VarChar,20) ,
                        new SqlParameter("@ConsularDistrict", SqlDbType.VarChar,20) ,
                        new SqlParameter("@DepartureType", SqlDbType.VarChar,50) ,
                        new SqlParameter("@CompanyPrice", SqlDbType.Money,8) ,
                        new SqlParameter("@Price1", SqlDbType.Money,8) ,
                        new SqlParameter("@Commision1", SqlDbType.Money,8) ,
                        new SqlParameter("@Margin1", SqlDbType.Money,8) ,
                        new SqlParameter("@Price2", SqlDbType.Money,8) ,
                        new SqlParameter("@Commision2", SqlDbType.Money,8) ,
                        new SqlParameter("@Margin2", SqlDbType.Money,8) ,
                        new SqlParameter("@Price3", SqlDbType.Money,8) ,
                        new SqlParameter("@Commision3", SqlDbType.Money,8) ,
                        new SqlParameter("@Margin3", SqlDbType.Money,8) ,
                        new SqlParameter("@DirectGuestPrice", SqlDbType.Money,8) ,
                        new SqlParameter("@DirectGuestCommision", SqlDbType.Money,8) ,
                        new SqlParameter("@DirectGuestMargin", SqlDbType.Money,8) ,
                        new SqlParameter("@SalesPersonCredits", SqlDbType.Int,4)

            };

            parameters[0].Value = model.Country;
            parameters[1].Value = model.ConsularDistrict;
            parameters[2].Value = model.DepartureType;
            parameters[3].Value = model.CompanyPrice;
            parameters[4].Value = model.Price1;
            parameters[5].Value = model.Commision1;
            parameters[6].Value = model.Margin1;
            parameters[7].Value = model.Price2;
            parameters[8].Value = model.Commision2;
            parameters[9].Value = model.Margin2;
            parameters[10].Value = model.Price3;
            parameters[11].Value = model.Commision3;
            parameters[12].Value = model.Margin3;
            parameters[13].Value = model.DirectGuestPrice;
            parameters[14].Value = model.DirectGuestCommision;
            parameters[15].Value = model.DirectGuestMargin;
            parameters[16].Value = model.SalesPersonCredits;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(TravelAgency.Model.Commision_Sale model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Commision_Sale set ");

            strSql.Append(" Country = @Country , ");
            strSql.Append(" ConsularDistrict = @ConsularDistrict , ");
            strSql.Append(" DepartureType = @DepartureType , ");
            strSql.Append(" CompanyPrice = @CompanyPrice , ");
            strSql.Append(" Price1 = @Price1 , ");
            strSql.Append(" Commision1 = @Commision1 , ");
            strSql.Append(" Margin1 = @Margin1 , ");
            strSql.Append(" Price2 = @Price2 , ");
            strSql.Append(" Commision2 = @Commision2 , ");
            strSql.Append(" Margin2 = @Margin2 , ");
            strSql.Append(" Price3 = @Price3 , ");
            strSql.Append(" Commision3 = @Commision3 , ");
            strSql.Append(" Margin3 = @Margin3 , ");
            strSql.Append(" DirectGuestPrice = @DirectGuestPrice , ");
            strSql.Append(" DirectGuestCommision = @DirectGuestCommision , ");
            strSql.Append(" DirectGuestMargin = @DirectGuestMargin , ");
            strSql.Append(" SalesPersonCredits = @SalesPersonCredits  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
                        new SqlParameter("@Id", SqlDbType.Int,4) ,
                        new SqlParameter("@Country", SqlDbType.VarChar,20) ,
                        new SqlParameter("@ConsularDistrict", SqlDbType.VarChar,20) ,
                        new SqlParameter("@DepartureType", SqlDbType.VarChar,50) ,
                        new SqlParameter("@CompanyPrice", SqlDbType.Money,8) ,
                        new SqlParameter("@Price1", SqlDbType.Money,8) ,
                        new SqlParameter("@Commision1", SqlDbType.Money,8) ,
                        new SqlParameter("@Margin1", SqlDbType.Money,8) ,
                        new SqlParameter("@Price2", SqlDbType.Money,8) ,
                        new SqlParameter("@Commision2", SqlDbType.Money,8) ,
                        new SqlParameter("@Margin2", SqlDbType.Money,8) ,
                        new SqlParameter("@Price3", SqlDbType.Money,8) ,
                        new SqlParameter("@Commision3", SqlDbType.Money,8) ,
                        new SqlParameter("@Margin3", SqlDbType.Money,8) ,
                        new SqlParameter("@DirectGuestPrice", SqlDbType.Money,8) ,
                        new SqlParameter("@DirectGuestCommision", SqlDbType.Money,8) ,
                        new SqlParameter("@DirectGuestMargin", SqlDbType.Money,8) ,
                        new SqlParameter("@SalesPersonCredits", SqlDbType.Int,4)

            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.Country;
            parameters[2].Value = model.ConsularDistrict;
            parameters[3].Value = model.DepartureType;
            parameters[4].Value = model.CompanyPrice;
            parameters[5].Value = model.Price1;
            parameters[6].Value = model.Commision1;
            parameters[7].Value = model.Margin1;
            parameters[8].Value = model.Price2;
            parameters[9].Value = model.Commision2;
            parameters[10].Value = model.Margin2;
            parameters[11].Value = model.Price3;
            parameters[12].Value = model.Commision3;
            parameters[13].Value = model.Margin3;
            parameters[14].Value = model.DirectGuestPrice;
            parameters[15].Value = model.DirectGuestCommision;
            parameters[16].Value = model.DirectGuestMargin;
            parameters[17].Value = model.SalesPersonCredits;
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
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Commision_Sale ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;


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
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Commision_Sale ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
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
        public TravelAgency.Model.Commision_Sale GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, Country, ConsularDistrict, DepartureType, CompanyPrice, Price1, Commision1, Margin1, Price2, Commision2, Margin2, Price3, Commision3, Margin3, DirectGuestPrice, DirectGuestCommision, DirectGuestMargin, SalesPersonCredits  ");
            strSql.Append("  from Commision_Sale ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;


            TravelAgency.Model.Commision_Sale model = new TravelAgency.Model.Commision_Sale();
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
        public TravelAgency.Model.Commision_Sale DataRowToModel(DataRow row)
        {
            TravelAgency.Model.Commision_Sale model = new TravelAgency.Model.Commision_Sale();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["Country"] != null && row["Country"].ToString() != "")
                {
                    model.Country = row["Country"].ToString();
                }
                if (row["ConsularDistrict"] != null && row["ConsularDistrict"].ToString() != "")
                {
                    model.ConsularDistrict = row["ConsularDistrict"].ToString();
                }
                if (row["DepartureType"] != null && row["DepartureType"].ToString() != "")
                {
                    model.DepartureType = row["DepartureType"].ToString();
                }
                if (row["CompanyPrice"] != null && row["CompanyPrice"].ToString() != "")
                {
                    model.CompanyPrice = decimal.Parse(row["CompanyPrice"].ToString());
                }
                if (row["Price1"] != null && row["Price1"].ToString() != "")
                {
                    model.Price1 = decimal.Parse(row["Price1"].ToString());
                }
                if (row["Commision1"] != null && row["Commision1"].ToString() != "")
                {
                    model.Commision1 = decimal.Parse(row["Commision1"].ToString());
                }
                if (row["Margin1"] != null && row["Margin1"].ToString() != "")
                {
                    model.Margin1 = decimal.Parse(row["Margin1"].ToString());
                }
                if (row["Price2"] != null && row["Price2"].ToString() != "")
                {
                    model.Price2 = decimal.Parse(row["Price2"].ToString());
                }
                if (row["Commision2"] != null && row["Commision2"].ToString() != "")
                {
                    model.Commision2 = decimal.Parse(row["Commision2"].ToString());
                }
                if (row["Margin2"] != null && row["Margin2"].ToString() != "")
                {
                    model.Margin2 = decimal.Parse(row["Margin2"].ToString());
                }
                if (row["Price3"] != null && row["Price3"].ToString() != "")
                {
                    model.Price3 = decimal.Parse(row["Price3"].ToString());
                }
                if (row["Commision3"] != null && row["Commision3"].ToString() != "")
                {
                    model.Commision3 = decimal.Parse(row["Commision3"].ToString());
                }
                if (row["Margin3"] != null && row["Margin3"].ToString() != "")
                {
                    model.Margin3 = decimal.Parse(row["Margin3"].ToString());
                }
                if (row["DirectGuestPrice"] != null && row["DirectGuestPrice"].ToString() != "")
                {
                    model.DirectGuestPrice = decimal.Parse(row["DirectGuestPrice"].ToString());
                }
                if (row["DirectGuestCommision"] != null && row["DirectGuestCommision"].ToString() != "")
                {
                    model.DirectGuestCommision = decimal.Parse(row["DirectGuestCommision"].ToString());
                }
                if (row["DirectGuestMargin"] != null && row["DirectGuestMargin"].ToString() != "")
                {
                    model.DirectGuestMargin = decimal.Parse(row["DirectGuestMargin"].ToString());
                }
                if (row["SalesPersonCredits"] != null && row["SalesPersonCredits"].ToString() != "")
                {
                    model.SalesPersonCredits = int.Parse(row["SalesPersonCredits"].ToString());
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
            strSql.Append(" Id, Country, ConsularDistrict, DepartureType, CompanyPrice, Price1, Commision1, Margin1, Price2, Commision2, Margin2, Price3, Commision3, Margin3, DirectGuestPrice, DirectGuestCommision, DirectGuestMargin, SalesPersonCredits  ");
            strSql.Append(" FROM Commision_Sale ");
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
            strSql.Append("select count(1) FROM Commision_Sale ");
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
            strSql.Append("select Id, Country, ConsularDistrict, DepartureType, CompanyPrice, Price1, Commision1, Margin1, Price2, Commision2, Margin2, Price3, Commision3, Margin3, DirectGuestPrice, DirectGuestCommision, DirectGuestMargin, SalesPersonCredits  ");

            strSql.Append(" FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            strSql.Append(")AS Row, T.*  from Commision_Sale T ");
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

