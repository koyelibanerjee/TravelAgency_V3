using System;
using System.Collections.Generic;
using TravelAgency.Model;

namespace TravelAgency.BLL
{



    public partial class Commision
    {
        private BLL.Visa _bllVisa = new BLL.Visa();

        public List<StatStruct> GetTStatList(string timefrom, string timeto, string type, string userName)
        {
            //var typeInPersonList = _bllVisa.GetTypeInPersonList();

            var commisionList = GetModelList("");
            List<StatStruct> res = new List<StatStruct>();
            for (int i = 0; i < commisionList.Count; i++)
            {
                string depatureType = commisionList[i].DepartureType;
                string country = commisionList[i].Country;
                var singlePrice = type == "TypeInPerson" ? (commisionList[i].TypeInCost ?? 0) : (commisionList[i].OperatorCommision ?? 0);

                int count;
                if (commisionList[i].DepartureType == "团队签证")
                    count = _bllVisa.GetRecordVisaInfoCount($" (entrytime between '{timefrom}' and '{timeto}') and " +
                                                    $"{type}='{userName}' and Types='团签' and Country = '{country}'");
                else
                {
                    count = _bllVisa.GetRecordVisaInfoCount($" (entrytime between '{timefrom}' and '{timeto}') and " +
                                                     $"{type}='{userName}' and DepartureType='{depatureType}' and Country = '{country}'");
                }

                StatStruct ss = new StatStruct()
                {
                    Country = country,
                    DepartureType = depatureType,
                    CommisionSingle = singlePrice,
                    Count = count,
                    CommisionTotal = count * singlePrice
                };
                res.Add(ss);
            }
            res.Sort((model1, model2) => model1.CommisionTotal > model2.CommisionTotal ? -1 : 1);
            return res;
        }




    }
}