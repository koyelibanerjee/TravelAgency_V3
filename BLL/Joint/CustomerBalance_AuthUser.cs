using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.BLL.Joint
{
    public class CustomerBalance_AuthUser
    {
        private readonly  DAL.Joint.CustomerBalance_AuthUser _dal = new DAL.Joint.CustomerBalance_AuthUser();

        public List<Model.CustomerBalance_AuthUser> GetModelList(string where ="")
        {
            return _dal.GetModelList(where);
        } 


    }
}
