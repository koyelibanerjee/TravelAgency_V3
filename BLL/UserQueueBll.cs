using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.BLL
{
    public class UserQueue
    {
        public DAL.UserQueue _dal = new DAL.UserQueue();
        public enum QueueType
        {
            QueueHigh,
            QueueLow
        }

        //public TravelAgency.Model.UserQueueItem GetAvailableUser()
        //{
        //    var model = Top(QueueType.QueueHigh);
        //    if (model == null) //高优先级队列没有
        //    {
        //        //从低队列拿，低队列是一定有
        //        model = Top(QueueType.QueueLow);
        //        Pop(QueueType.QueueLow);

        //        while (model != null && model.IsBusy)
        //        {
        //            Enque(QueueType.QueueHigh, model);
        //            model = Top(QueueType.QueueLow);
        //            Pop(QueueType.QueueLow);
        //        }


        //    }
        //    else
        //    {
        //        while (model != null && model.IsBusy) //如果始终是忙的，就持续拿
        //        {
        //            model = Top(QueueType.QueueHigh);

        //        }

        //        if (model == null) //高拿完了，没拿到，去拿低的

        //            return
        //    }
        //}


        private static string GetTableName(QueueType type)
        {
            return type == QueueType.QueueHigh ? "UserQueueHigh" : "UserQueueLow";
        }




        public int Enque(QueueType type, Model.UserQueueItem model) //选择进那个队列里面
        {
            return _dal.Enque(GetTableName(type), model);
        }

        public bool Pop(QueueType type)
        {
            return _dal.Pop(GetTableName(type));
        }

        public TravelAgency.Model.UserQueueItem Top(QueueType type)
        {
            return _dal.Top(GetTableName(type));
        }
    }
}
