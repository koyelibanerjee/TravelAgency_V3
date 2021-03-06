﻿using System;
using System.Data;
using System.Collections.Generic;
using TravelAgency.Model;
namespace TravelAgency.BLL
{

    //这个类是用的UserQueue的，不用了现在

    /// <summary>
    /// JobAssignment
    /// </summary>
    public partial class JobAssignment
    {
        private readonly BLL.UserQueue _bllUserQueue = new UserQueue();
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
            return GetModelList(string.Format("AssignmentToWorkId='{0}' and HasTypeIn = '否'",workId)).Count <= 0;
        }

        /// <summary>
        /// 负责协调的总的方法，10s限制时间调用一次,每调用一次，最多给每个用户分配一个工作，若无可用用户，提前终止
        /// </summary>
        public void AssignmentJob()
        {
            //check 10s
            var latestModel = LatestAssignmented();
            if ((latestModel.AssignmentTime.Value-DateTime.Now).Duration().TotalSeconds < 10) //TODO:这里的10s应该读取配置文件，但是这里bll层没法引用common,后面应把所有业务逻辑相关的从common移出到bll
            {
                return;
            }

            var jobModel = Top();
            int cnt = 0;
            int userCnt = _bllUserQueue.GetRecordCount(UserQueue.QueueType.High, "") +
                _bllUserQueue.GetRecordCount(UserQueue.QueueType.Low, "");
            while (jobModel != null && cnt < userCnt) //每一次尽可能分配完任务
            {
                var user = _bllUserQueue.GetAvailableUser();
                if (user == null)
                    return;

                //执行分配
                AssignmentToUser(jobModel, user);
                ++userCnt;
                jobModel = Top();
            }
        }

        public void AssignmentToUser(Model.JobAssignment jobModel, Model.UserQueueItem user)
        {
            if (jobModel == null || user == null)
                return;
            jobModel.AssignmentToWorkId = user.WorkId;
            jobModel.AssignmentToUserName = user.UserName;
            jobModel.AssignmentTime = DateTime.Now;
            var visainfoList = _bllVisaInfo.GetModelList(" jobid = '" + jobModel.Id + "' ");
            if (visainfoList == null)
                return;
            foreach (var visainfo in visainfoList)
            {
                visainfo.AssignmentToWorkId = user.WorkId;
                visainfo.AssignmentToUserName = user.UserName;
            }
            user.IsBusy = true;

            Update(jobModel);
            _bllVisaInfo.UpdateByList(visainfoList);
            _bllUserQueue.Update(user); //自动判断用户在哪个表中，执行更新

        }

    }
}

