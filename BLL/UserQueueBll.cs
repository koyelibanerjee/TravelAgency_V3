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
