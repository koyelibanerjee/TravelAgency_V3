using System;
using System.Data;
using System.Collections.Generic;
using TravelAgency.Model;

namespace TravelAgency.BLL
{
    /// <summary>
    /// AppAll
    /// </summary>
    public partial class AppAll
    {
        public string TableName { get { return "AppAll"; } }

        public int GetMaxTemp()
        {
            return dal.GetMaxTemp();
        }
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public Guid Add(TravelAgency.Model.AppAll model)
        {
            return dal.Add(model);
        }

        public List<string> GetBankFromToList()
        {
            var list = CommonBll.GetFieldList(TableName, "Bank_To");
            list.AddRange(CommonBll.GetFieldList(TableName, "Bank_From"));
            return list;
        }

        public List<string> GetBankList()
        {
            var list = CommonBll.GetFieldList(TableName, "Bank");
            return list;
        }

        public List<string> GetPersonList()
        {
            var list = CommonBll.GetFieldList(TableName, "Person");
            return list;
        }

    }
}