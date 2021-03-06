﻿using System;
using System.Data;
using System.Collections.Generic;
using TravelAgency.Common;
using TravelAgency.Model;
namespace TravelAgency.BLL
{
    /// <summary>
    /// JobAssignment
    /// </summary>
    public partial class JobAssignment
    {
        private readonly BLL.WorkerQueue _bllWorkerQueue = new WorkerQueue();
        private readonly BLL.VisaInfo _bllVisaInfo = new VisaInfo();

        public Model.JobAssignment Top()
        {
            return dal.Top();
        }

        public Model.JobAssignment LatestAssignmented()
        {
            return dal.LatestAssignmented();
        }

        /// <summary>
        /// 判断指定用户工作完成没有
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
        public bool UserWorkFinished(string workId)
        {
            return _bllVisaInfo.GetModelList(
                $"AssignmentToWorkId='{workId}' and HasTypeIn = '否' and Country='日本' and Types in ('个签','团做个','商务') ")
                .Count <= 0;//其他国家根本不会有AssignmentToWorkId，所以不用加国家限制,还是加上国家限制。。
        }

        /// <summary>
        /// 负责协调的总的方法，10s限制时间调用一次,每调用一次，最多给每个用户分配一个工作，若无可用用户，提前终止
        /// </summary>
        public void AssignmentJob()
        {
            //check 10s
            var latestModel = LatestAssignmented();
            //


            if ((latestModel != null) &&
                (latestModel.AssignmentTime.Value - DateTime.Now).Duration().TotalSeconds < 3)
            //TODO:这里的10s应该读取配置文件，但是这里bll层没法引用common,后面应把所有业务逻辑相关的从common移出到bll
            {
                return;
            }

            var jobModel = Top();
            int cnt = 0;
            int userCnt = _bllWorkerQueue.GetRecordCount($" district = {GlobalUtils.LoginUser.District} ");
            while (jobModel != null && cnt < userCnt) //每一次尽可能分配完任务
            {
                var user = _bllWorkerQueue.GetNextWorker();
                if (user == null)
                    return;

                //执行分配
                cnt +=AssignmentToUser(jobModel, user);
                jobModel = Top();
            }
        }

        public int AssignmentToUser(Model.JobAssignment jobModel, Model.WorkerQueue user)
        {
            if (jobModel == null || user == null)
                return 0;
            jobModel.AssignmentToWorkId = user.WorkId;
            jobModel.AssignmentToUserName = user.UserName;
            jobModel.AssignmentTime = DateTime.Now;
            var visainfoList = _bllVisaInfo.GetModelList(" jobid = '" + jobModel.Id + "' ");
            if (visainfoList == null)
                return 0;

            bool changed = false;
            foreach (var visainfo in visainfoList)
            {
                if (!changed && visainfo.HasTypeIn == "否")
                {
                    //已经做过的了
                    user.IsBusy = true;
                    _bllWorkerQueue.Update(user);  //置为忙的状态
                    changed = true;
                }
                visainfo.AssignmentToWorkId = user.WorkId;
                visainfo.AssignmentToUserName = user.UserName;
            }

            Update(jobModel);
            _bllVisaInfo.UpdateByList(visainfoList);

            return changed ? 1 : 0; //有一个用户变成了忙

        }

    }
}

