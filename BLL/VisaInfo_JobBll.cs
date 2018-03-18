using System;
using System.Data;
using System.Collections.Generic;
using TravelAgency.Model;
namespace TravelAgency.BLL
{
	/// <summary>
	/// VisaInfo
	/// </summary>
	public partial class VisaInfo_Job
    {
		private readonly TravelAgency.DAL.VisaInfo_Job dal =new TravelAgency.DAL.VisaInfo_Job();
		public VisaInfo_Job()
		{}
		#region  BasicMethod

        public List<Model.VisaInfo_Job> GetModelListByPage(string strWhere, string orderby, int pageSize, int pageIndex)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;

            DataSet ds = GetListByPage(strWhere, orderby, start, end);
            return DataTableToList(ds.Tables[0]);
        }
		

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TravelAgency.Model.VisaInfo_Job> DataTableToList(DataTable dt)
		{
			List<TravelAgency.Model.VisaInfo_Job> modelList = new List<TravelAgency.Model.VisaInfo_Job>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TravelAgency.Model.VisaInfo_Job model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}

		#endregion  BasicMethod
		
	}
}

