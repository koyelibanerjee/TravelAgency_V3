using System;
using System.Data;
using System.Collections.Generic;
using TravelAgency.Common;
using TravelAgency.Model;
namespace TravelAgency.BLL
{
	/// <summary>
	/// WorkerQueue
	/// </summary>
	public partial class WorkerQueue
	{
        //取可用用户
        public Model.WorkerQueue GetNextWorker()
        {
            return dal.GetNextWorker();
        }

        public bool ChangeUserBusyState(string workId, bool v)
        {
            var model = GetModelList($" workid = '{workId}' and district = {GlobalUtils.LoginUser.District} ")[0];
            model.IsBusy = v;
            return Update(model);
        }

        public bool ChangeUserAcceptState(string workId, bool v)
        {
            var list = GetModelList($" workid = '{workId}' and district = {GlobalUtils.LoginUser.District} ");
            if (list.Count == 0)
                return false;
            var model = list[0];
            model.CanAccept = v;
            return Update(model);
        }

    }
}

