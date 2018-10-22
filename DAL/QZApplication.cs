using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace TravelAgency.DAL
{
    //QZApplication
    public partial class QZApplication
    {

        public bool Exists()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from QZApplication");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
            };

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }





        


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from QZApplication ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
            };


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
        /// 得到一个对象实体
        /// </summary>
        public TravelAgency.Model.QZApplication GetModel()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select QZApp_id, Visa_id, SubName, DepartmentId, GroupNo, SendTime, FinishTime, Person, Number, Tips, Price, Receipt, Quidco, ConsulateCost, VisaPersonCost, MailCost, PictureCost, Sales, WorkId, EntryTime, App_id, Flag, Country, Name, InvitationCost, Cost  ");
            strSql.Append("  from QZApplication ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
            };


            TravelAgency.Model.QZApplication model = new TravelAgency.Model.QZApplication();
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
        public TravelAgency.Model.QZApplication DataRowToModel(DataRow row)
        {
            TravelAgency.Model.QZApplication model = new TravelAgency.Model.QZApplication();
            if (row != null)
            {
                if (row["QZApp_id"] != null && row["QZApp_id"].ToString() != "")
                {
                    model.QZApp_id = new Guid(row["QZApp_id"].ToString());
                }
                if (row["Visa_id"] != null && row["Visa_id"].ToString() != "")
                {
                    model.Visa_id = new Guid(row["Visa_id"].ToString());
                }
                if (row["SubName"] != null && row["SubName"].ToString() != "")
                {
                    model.SubName = row["SubName"].ToString();
                }
                if (row["DepartmentId"] != null && row["DepartmentId"].ToString() != "")
                {
                    model.DepartmentId = new Guid(row["DepartmentId"].ToString());
                }
                if (row["GroupNo"] != null && row["GroupNo"].ToString() != "")
                {
                    model.GroupNo = row["GroupNo"].ToString();
                }
                if (row["SendTime"] != null && row["SendTime"].ToString() != "")
                {
                    model.SendTime = DateTime.Parse(row["SendTime"].ToString());
                }
                if (row["FinishTime"] != null && row["FinishTime"].ToString() != "")
                {
                    model.FinishTime = DateTime.Parse(row["FinishTime"].ToString());
                }
                if (row["Person"] != null && row["Person"].ToString() != "")
                {
                    model.Person = row["Person"].ToString();
                }
                if (row["Number"] != null && row["Number"].ToString() != "")
                {
                    model.Number = int.Parse(row["Number"].ToString());
                }
                if (row["Tips"] != null && row["Tips"].ToString() != "")
                {
                    model.Tips = row["Tips"].ToString();
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(row["Price"].ToString());
                }
                if (row["Receipt"] != null && row["Receipt"].ToString() != "")
                {
                    model.Receipt = decimal.Parse(row["Receipt"].ToString());
                }
                if (row["Quidco"] != null && row["Quidco"].ToString() != "")
                {
                    model.Quidco = decimal.Parse(row["Quidco"].ToString());
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
                if (row["PictureCost"] != null && row["PictureCost"].ToString() != "")
                {
                    model.PictureCost = decimal.Parse(row["PictureCost"].ToString());
                }
                if (row["Sales"] != null && row["Sales"].ToString() != "")
                {
                    model.Sales = row["Sales"].ToString();
                }
                if (row["WorkId"] != null && row["WorkId"].ToString() != "")
                {
                    model.WorkId = row["WorkId"].ToString();
                }
                if (row["EntryTime"] != null && row["EntryTime"].ToString() != "")
                {
                    model.EntryTime = DateTime.Parse(row["EntryTime"].ToString());
                }
                if (row["App_id"] != null && row["App_id"].ToString() != "")
                {
                    model.App_id = new Guid(row["App_id"].ToString());
                }
                if (row["Flag"] != null && row["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(row["Flag"].ToString());
                }
                if (row["Country"] != null && row["Country"].ToString() != "")
                {
                    model.Country = row["Country"].ToString();
                }
                if (row["Name"] != null && row["Name"].ToString() != "")
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["InvitationCost"] != null && row["InvitationCost"].ToString() != "")
                {
                    model.InvitationCost = decimal.Parse(row["InvitationCost"].ToString());
                }
                if (row["Cost"] != null && row["Cost"].ToString() != "")
                {
                    model.Cost = decimal.Parse(row["Cost"].ToString());
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
            strSql.Append(" QZApp_id, Visa_id, SubName, DepartmentId, GroupNo, SendTime, FinishTime, Person, Number, Tips, Price, Receipt, Quidco, ConsulateCost, VisaPersonCost, MailCost, PictureCost, Sales, WorkId, EntryTime, App_id, Flag, Country, Name, InvitationCost, Cost  ");
            strSql.Append(" FROM QZApplication ");
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
            strSql.Append("select count(1) FROM QZApplication ");
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
            strSql.Append("select QZApp_id, Visa_id, SubName, DepartmentId, GroupNo, SendTime, FinishTime, Person, Number, Tips, Price, Receipt, Quidco, ConsulateCost, VisaPersonCost, MailCost, PictureCost, Sales, WorkId, EntryTime, App_id, Flag, Country, Name, InvitationCost, Cost  ");

            strSql.Append(" FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            strSql.Append(")AS Row, T.*  from QZApplication T ");
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

