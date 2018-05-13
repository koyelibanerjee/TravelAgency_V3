using System;
using System.Data;
using System.Collections.Generic;
using TravelAgency.Model;
namespace TravelAgency.BLL
{
    /// <summary>
    /// Message
    /// </summary>
    public partial class Message
    {

        public int GetUnReadMsgNum(string userName)
        {
            var list = GetModelList(string.Format(" ToUser = '{0}' and MsgState = '未读' ", userName)); //TODO:这里用select count(1)是性能最好的
            return list == null ? 0 : list.Count;
        }

        public List<Model.Message> GetListByPageOrderById(string strWhere, int pageNo, int pageSize)
        {
            int start = (pageNo - 1) * pageSize + 1;
            int end = pageNo * pageSize;
            var ds = GetListByPage(strWhere, " id desc ", start, end);
            return DataTableToList(ds.Tables[0]);
        }

        public List<Model.Message> GetListOfPage(string strWhere, string orderby, int pageNo, int pageSize)
        {
            int start = (pageNo - 1) * pageSize + 1;
            int end = pageNo * pageSize;
            var ds = GetListByPage(strWhere, orderby, start, end);
            return DataTableToList(ds.Tables[0]);
        }


        public int AddList(List<Model.Message> list)
        {
            int res = 0;
            foreach (var Message in list)
            {
                res += dal.Add(Message) == 0 ? 0 : 1; //返回值是id
            }
            return res;
        }

        public int DeleteList(List<Model.Message> list)
        {
            int res = 0;
            foreach (var Message in list)
            {
                res += Delete(Message.Id) ? 1 : 0;
            }
            return res;
        }

    }
}

