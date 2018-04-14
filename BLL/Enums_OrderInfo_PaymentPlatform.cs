using System;
using System.Data;
using System.Collections.Generic;
using TravelAgency.Model;
namespace TravelAgency.BLL
{
	/// <summary>
	/// Enums_OrderInfo_PaymentPlatform
	/// </summary>
	public partial class Enums_OrderInfo_PaymentPlatform
	{
		private readonly TravelAgency.DAL.Enums_OrderInfo_PaymentPlatform dal=new TravelAgency.DAL.Enums_OrderInfo_PaymentPlatform();
		public Enums_OrderInfo_PaymentPlatform()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PlatNo,string PlateName)
		{
			return dal.Exists(PlatNo,PlateName);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(TravelAgency.Model.Enums_OrderInfo_PaymentPlatform model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(TravelAgency.Model.Enums_OrderInfo_PaymentPlatform model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int PlatNo,string PlateName)
		{
			
			return dal.Delete(PlatNo,PlateName);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TravelAgency.Model.Enums_OrderInfo_PaymentPlatform GetModel(int PlatNo,string PlateName)
		{
			
			return dal.GetModel(PlatNo,PlateName);
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TravelAgency.Model.Enums_OrderInfo_PaymentPlatform> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TravelAgency.Model.Enums_OrderInfo_PaymentPlatform> DataTableToList(DataTable dt)
		{
			List<TravelAgency.Model.Enums_OrderInfo_PaymentPlatform> modelList = new List<TravelAgency.Model.Enums_OrderInfo_PaymentPlatform>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TravelAgency.Model.Enums_OrderInfo_PaymentPlatform model;
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

