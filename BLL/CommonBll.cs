using System.Collections.Generic;
using TravelAgency.DAL;

namespace TravelAgency.BLL
{
    public class CommonBll
    {
        public static List<string> GetFieldList(string tableName, string filedName,string where="")
        {
            return CommonDal.GetFieldList(tableName, filedName,where);
        }
    }
}