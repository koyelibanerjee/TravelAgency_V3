using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DAL;


namespace TravelAgency.BLL
{
    public class VisaTypedInCountBll
        
    {
        private DAL.VisaTypedInCount _dalVisaTypedInCount = new VisaTypedInCount();
        public List<Model.VisaTypedInCount> GetVisaTypedInCountModels(List<Model.Visa> visaList)
        {
            return DataTableToList(_dalVisaTypedInCount.GetVisaTypedInCountModels(visaList).Tables[0]);
        }

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TravelAgency.Model.VisaTypedInCount> DataTableToList(DataTable dt)
        {
            List<TravelAgency.Model.VisaTypedInCount> modelList = new List<TravelAgency.Model.VisaTypedInCount>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TravelAgency.Model.VisaTypedInCount model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = _dalVisaTypedInCount.DataRowToModel(dt.Rows[n]);
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
