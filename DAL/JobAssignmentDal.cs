﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using TravelAgency.Common;
//Please add references
using TravelAgency.Model;

namespace TravelAgency.DAL
{
    /// <summary>
    /// 数据访问类:JobAssignment
    /// </summary>
    public partial class JobAssignment
    {



        public Model.JobAssignment Top()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from JobAssignment ");
            strSql.Append($" where AssignmentToWorkId is null and district = {GlobalUtils.LoginUser.District} order by entrytime asc" );//TODO:这里应该是先录的先出吧
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public Model.JobAssignment LatestAssignmented()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from JobAssignment ");
            strSql.Append($" where AssignmentTime is not null and district = {GlobalUtils.LoginUser.District} order by AssignmentTime desc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
    }
}

