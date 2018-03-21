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
            High,
            Low
        }


        /// <summary>
        /// 每次遍历两个表全部用户，作为一轮
        /// 至多遍历完两个表，提前拿到就不会全部遍历
        /// </summary>
        /// <returns></returns>
        public TravelAgency.Model.UserQueueItem GetAvailableUser()
        {
            int cntHigh = GetRecordCount(QueueType.High, "");
            int cntLow = GetRecordCount(QueueType.Low, "");
            int all = cntHigh + cntLow;
            int cnt = 0;
            var model = Top(QueueType.High);
            if (model == null) //高优先级队列没有，所有人都在低优先级队列
            {
                //从低队列拿，低队列是一定有,因为现在是高队列没有才从低队列拿
                model = Top(QueueType.Low);
                while (model == null || model.IsBusy || !model.CanAccept)
                {
                    if (model == null) //低队列也拿完了，理论上由cnt控制是不会出现的
                        return null;
                    ++cnt; //拿到了，但是不能用
                    Pop(QueueType.Low);
                    Enque(QueueType.High, model); //加入高队列
                    if (cnt < all)
                        model = Top(QueueType.Low);
                    else //本轮已经完了
                        return null;
                }

                //现在的model就一定是可用的了
                //还需要进行一次pop和enque
                ++cnt;//虽然没用了但是还是加一下
                Pop(QueueType.Low);
                Enque(QueueType.Low, model); //用完加入低队列
                return model;
            }
            else //高队列拿到了
            {
                QueueType curType = QueueType.High;
                while (model == null || model.IsBusy || !model.CanAccept) //拿到的不能用
                {
                    if (model == null) //高或低拿完了
                    {
                        //高拿完了，转低优先级队列
                        if (curType == QueueType.High)
                        {
                            curType = QueueType.Low;
                            model = Top(curType);
                            continue;
                        }
                        //低也拿完了，就直接return
                        if (curType == QueueType.Low)
                            return null;
                    }

                    //拿到的是忙或者开关关闭的,加入高优先级的尾部
                    ++cnt; //拿到了
                    Pop(curType);
                    Enque(QueueType.High, model);
                    if (cnt == cntHigh && curType == QueueType.High)//高的又回到了队列，因此要判断一下切换队列
                        curType = QueueType.Low;
                    if (cnt < all)
                        model = Top(curType);
                    else
                        return null;
                }

                //现在的model就一定是可用的了
                //还需要进行一次pop和enque
                ++cnt;//虽然没用了但是还是加一下
                Pop(curType); //这里pop一定要curtype
                Enque(QueueType.Low, model); //用完加入低队列
                return model;
            }
        }

        public int GetRecordCount(QueueType type, string where)
        {
            return _dal.GetRecordCount(GetTableName(type), where);
        }

        private static string GetTableName(QueueType type)
        {
            return type == QueueType.High ? "UserQueueHigh" : "UserQueueLow";
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
