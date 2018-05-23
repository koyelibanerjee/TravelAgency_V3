using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using TravelAgency.Model;
namespace TravelAgency.BLL
{
    //Visa
    public partial class Visa
    {

        private readonly TravelAgency.DAL.Visa dal = new TravelAgency.DAL.Visa();
        public Visa()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid Visa_id)
        {
            return dal.Exists(Visa_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public Guid Add(TravelAgency.Model.Visa model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(TravelAgency.Model.Visa model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid Visa_id)
        {

            return dal.Delete(Visa_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgency.Model.Visa GetModel(Guid Visa_id)
        {

            return dal.GetModel(Visa_id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TravelAgency.Model.Visa> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TravelAgency.Model.Visa> DataTableToList(DataTable dt)
        {
            List<TravelAgency.Model.Visa> modelList = new List<TravelAgency.Model.Visa>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TravelAgency.Model.Visa model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                        modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        public List<TravelAgency.Model.Visa> GetListByPage(string where, string orderby, int startIndex, int endIndex)
        {
            DataSet ds = dal.GetListByPage(where, orderby, startIndex, endIndex);
            DataTable dt = ds.Tables[0];
            return DataTableToList(dt);
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        public List<TravelAgency.Model.Visa> GetListByPage(int pageIndex, int pageSize, string where, string orderby)
        {
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;
            return GetListByPage(where, orderby, startIndex, endIndex);
        }





        /// <summary>
        /// 分页获取数据
        /// </summary>
        public List<TravelAgency.Model.Visa> GetListByPageOrderByPK(int pageIndex, int pageSize, string where)
        {
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;
            string orderby = "";
            orderby = "Visa_id desc";
            return GetListByPage(where, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 新增list
        /// </summary>		
        public int AddList(List<TravelAgency.Model.Visa> list)
        {
            int res = 0;
            foreach (var item in list)
            {
                res += dal.Add(item) == Guid.Empty ? 0 : 1; //返回值是Guid
            }
            return res;
        }

        /// <summary>
        /// 更新list
        /// </summary>
        public int UpdateList(List<TravelAgency.Model.Visa> list)
        {
            int res = 0;
            foreach (var item in list)
            {
                res += dal.Update(item) ? 1 : 0; //返回值是id
            }
            return res;
        }

        /// <summary>
        /// 删除list
        /// </summary>    
        public bool DeleteList(List<TravelAgency.Model.Visa> list)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; ++i)
            {
                sb.AppendFormat("'{0}',", list[i].Visa_id);
            }
            string str_id_list = sb.ToString().TrimEnd(',');
            return dal.DeleteList(str_id_list);
        }



        #endregion

    }
}