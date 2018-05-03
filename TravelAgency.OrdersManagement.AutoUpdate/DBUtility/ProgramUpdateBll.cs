

using System;
using System.Data;
using System.Collections.Generic;
using TravelAgency.OrdersManagement.AutoUpdate.Model;
namespace TravelAgency.OrdersManagement.AutoUpdate.BLL
{
    /// <summary>
    /// ProgramUpdate
    /// </summary>
    public partial class ProgramUpdateBll
    {
        private readonly TravelAgency.OrdersManagement.AutoUpdate.DAL.ProgramUpdateDal dal = new TravelAgency.OrdersManagement.AutoUpdate.DAL.ProgramUpdateDal();
        public ProgramUpdateBll()
        { }

        #region My Method

        public AutoUpdate.Model.ProgramUpdateModel GetLatestModel()
        {
            return dal.GetLatestModel();
        }

        /// <summary>
        /// 根据当前版本获取需要更新的所有内容,按照版本从旧到新排列
        /// </summary>
        /// <param name="curVersion"></param>
        /// <returns></returns>
        public List<AutoUpdate.Model.ProgramUpdateModel> GetUpdateModelList(string curVersion)
        {
            var list = GetModelList(string.Format(" Version > '{0}'", curVersion));
            if (list != null)
            {
                list.Sort((model1, model2) =>
                {
                    return string.Compare(model1.Version, model2.Version);
                });
            }
            return list;
        }
        #endregion

        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TravelAgency.OrdersManagement.AutoUpdate.Model.ProgramUpdateModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(TravelAgency.OrdersManagement.AutoUpdate.Model.ProgramUpdateModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TravelAgency.OrdersManagement.AutoUpdate.Model.ProgramUpdateModel GetModel(int Id)
        {

            return dal.GetModel(Id);
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
        public List<TravelAgency.OrdersManagement.AutoUpdate.Model.ProgramUpdateModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TravelAgency.OrdersManagement.AutoUpdate.Model.ProgramUpdateModel> DataTableToList(DataTable dt)
        {
            List<TravelAgency.OrdersManagement.AutoUpdate.Model.ProgramUpdateModel> modelList = new List<TravelAgency.OrdersManagement.AutoUpdate.Model.ProgramUpdateModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TravelAgency.OrdersManagement.AutoUpdate.Model.ProgramUpdateModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
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
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}



