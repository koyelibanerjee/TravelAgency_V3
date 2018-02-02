using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DAL;


namespace TravelAgency.BLL
{
    public class VisaActTypeCountBll

    {
        private readonly DAL.VisaActTypeCount _dalVisaActTypeCount = new VisaActTypeCount();
        public List<Model.VisaActTypeCount> GetVisaActTypeCountModels(List<Model.Visa> visaList, string type)
        {
            return DataTableToList(_dalVisaActTypeCount.GetVisaActTypeCountModels(visaList, type).Tables[0]);
        }

        public Dictionary<Guid, int> GetVisaActTypeCountDict(List<Model.Visa> visaList, string type)
        {
            Dictionary<Guid, int> res = new Dictionary<Guid, int>();
            var list = GetVisaActTypeCountModels(visaList, type);
            foreach (var visaActTypeCount in list)
            {
                res.Add(visaActTypeCount.Visa_id, visaActTypeCount.Count);
            }
            return res;
        }
        /// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TravelAgency.Model.VisaActTypeCount> DataTableToList(DataTable dt)
        {
            List<TravelAgency.Model.VisaActTypeCount> modelList = new List<TravelAgency.Model.VisaActTypeCount>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                for (int n = 0; n < rowsCount; n++)
                {
                    var model = _dalVisaActTypeCount.DataRowToModel(dt.Rows[n]);
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
