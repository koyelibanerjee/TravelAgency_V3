using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using NPOI.SS.UserModel;
using TravelAgency.DAL.Joint;
using TravelAgency.Model;
namespace TravelAgency.BLL
{
    //Commision_Sale
    public partial class Commision_Sale
    {
        private DAL.Joint.Visa_ClaimMoneyDal _dal = new Visa_ClaimMoneyDal();
        public List<StatStruct_Sale> GetTStatList(string timefrom, string timeto, string userName)
        {
            var commisionList = GetModelList("");
            List<StatStruct_Sale> res = new List<StatStruct_Sale>();
            for (int i = 0; i < commisionList.Count; i++)
            {
                string depatureType = commisionList[i].DepartureType;
                string country = commisionList[i].Country;
                int[] cnt = new int[4];
                if (commisionList[i].DepartureType == "团队签证")
                    continue;
                else
                {
                    cnt[0] = _dal.GetSaleCommisionCount(timefrom, timeto, country, depatureType,
                        commisionList[i].Price1 ?? 0, commisionList[i].Price2 ?? -1);
                    cnt[1] = _dal.GetSaleCommisionCount(timefrom, timeto, country, depatureType,
    commisionList[i].Price2 ?? 0, commisionList[i].Price3 ?? -1);
                    cnt[2] = _dal.GetSaleCommisionCount(timefrom, timeto, country, depatureType,
    commisionList[i].Price3 ?? 0, commisionList[i].DirectGuestPrice ?? -1);
                    cnt[3] = _dal.GetSaleCommisionCount(timefrom, timeto, country, depatureType,
commisionList[i].DirectGuestPrice ?? 0, -1);
                }

                StatStruct_Sale ss = new StatStruct_Sale()
                {
                    Country = country,
                    DepartureType =  depatureType,
                    Count1 = cnt[0],
                    Count2 = cnt[1],
                    Count3 = cnt[2],
                    CountDirect = cnt[3],
                    Commision1 = commisionList[i].Commision1??0,
                    Commision2 = commisionList[i].Commision2??0,
                    Commision3 = commisionList[i].Commision3??0,
                    CommisionDirect = commisionList[i].DirectGuestCommision ?? 0
                };
                ss.CommisionTotal = ss.Count1 * ss.Commision1 + ss.Count2 * ss.Commision2 + ss.Count3 * ss.Commision3 + ss.CountDirect * ss.CommisionDirect;
                res.Add(ss);
            }
            res.Sort((model1, model2) => model1.CommisionTotal > model2.CommisionTotal ? -1 : 1);
            return res;
        }

    }
}