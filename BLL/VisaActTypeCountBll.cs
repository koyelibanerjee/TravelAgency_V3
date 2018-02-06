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

        /// <summary>
        /// 查询指定团的人里面的outstate数量，注意这个sql语句如果为0的话是没有的，因此要自己加一行，所以这个方法private不对外使用，先处理成dict再给外面用
        /// </summary>
        /// <param name="visaList"></param>
        /// <param name="outState"></param>
        /// <returns></returns>
        private List<Model.VisaActTypeCount> GetVisaOutStateCountModels(List<Model.Visa> visaList, string outState)
        {
            return DataTableToList(_dalVisaActTypeCount.GetVisaOutStateCountModels(visaList, outState).Tables[0]);
        }

        public Dictionary<Guid, int> GetVisaOutStateCountDict(List<Model.Visa> visaList, string outState)
        {
            Dictionary<Guid, int> res = new Dictionary<Guid, int>();
            foreach (var visa in visaList)
            {
                res.Add(visa.Visa_id, 0); //先全部建成0
            }

            var list = GetVisaOutStateCountModels(visaList, outState);
            foreach (var outStateCountModel in list)
            {
                res[outStateCountModel.Visa_id] = outStateCountModel.Count;
            }
            return res;
        }

        /// <summary>
        /// 查询visa_id们的操作类型的记录数目
        /// </summary>
        /// <param name="visaList"></param>
        /// <param name="type"></param>
        /// <returns></returns>
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
