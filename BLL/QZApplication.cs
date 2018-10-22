using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using TravelAgency.Model;
namespace TravelAgency.BLL
{
    //QZApplication
    public partial class QZApplication
    {

        private readonly TravelAgency.DAL.QZApplication dal = new TravelAgency.DAL.QZApplication();
        public QZApplication()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists()
        {
            return dal.Exists();
        }



        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(TravelAgency.Model.QZApplication model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete()
        {

            return dal.Delete();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgency.Model.QZApplication GetModel()
        {

            return dal.GetModel();
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
        public List<TravelAgency.Model.QZApplication> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TravelAgency.Model.QZApplication> DataTableToList(DataTable dt)
        {
            List<TravelAgency.Model.QZApplication> modelList = new List<TravelAgency.Model.QZApplication>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TravelAgency.Model.QZApplication model;
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
        public List<TravelAgency.Model.QZApplication> GetListByPage(string where, string orderby, int startIndex, int endIndex)
        {
            DataSet ds = dal.GetListByPage(where, orderby, startIndex, endIndex);
            DataTable dt = ds.Tables[0];
            return DataTableToList(dt);
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        public List<TravelAgency.Model.QZApplication> GetListByPage(int pageIndex, int pageSize, string where, string orderby)
        {
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;
            return GetListByPage(where, orderby, startIndex, endIndex);
        }







        #endregion

    }
}