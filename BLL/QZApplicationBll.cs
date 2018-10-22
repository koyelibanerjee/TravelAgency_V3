using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using TravelAgency.Model;

namespace TravelAgency.BLL
{
    //QZApplication
    public partial class QZApplication
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TravelAgency.Model.QZApplication model)
        {
            return dal.Add(model);
        }
    }
}