using System;
using System.Data;
using System.Collections.Generic;
//using Maticsoft.Common;
using TravelAgency.Model;
namespace TravelAgency.BLL
{
	/// <summary>
	/// Visa
	/// </summary>
	public partial class VisaWithActRecords
    {
		private readonly TravelAgency.DAL.VisaWithActRecords dal =new TravelAgency.DAL.VisaWithActRecords();
		public VisaWithActRecords()
		{}
				

		
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
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}
	}
}

