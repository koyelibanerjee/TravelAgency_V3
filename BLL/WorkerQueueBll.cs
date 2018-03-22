using System;
using System.Data;
using System.Collections.Generic;
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

    }
}

