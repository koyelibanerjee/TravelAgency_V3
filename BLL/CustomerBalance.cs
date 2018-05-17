using System;
using System.Data;
using System.Collections.Generic;
using TravelAgency.Model;
namespace TravelAgency.BLL
{
	/// <summary>
	/// CustomerBalance
	/// </summary>
	public partial class CustomerBalance
	{
		private readonly TravelAgency.DAL.CustomerBalance dal=new TravelAgency.DAL.CustomerBalance();
		public CustomerBalance()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid BalanceId)
		{
			return dal.Exists(BalanceId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(TravelAgency.Model.CustomerBalance model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(TravelAgency.Model.CustomerBalance model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(Guid BalanceId)
		{
			
			return dal.Delete(BalanceId);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TravelAgency.Model.CustomerBalance GetModel(Guid BalanceId)
		{
			
			return dal.GetModel(BalanceId);
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
		public List<TravelAgency.Model.CustomerBalance> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TravelAgency.Model.CustomerBalance> DataTableToList(DataTable dt)
		{
			List<TravelAgency.Model.CustomerBalance> modelList = new List<TravelAgency.Model.CustomerBalance>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TravelAgency.Model.CustomerBalance model;
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

