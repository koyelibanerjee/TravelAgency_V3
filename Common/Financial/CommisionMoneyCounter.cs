using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.BLL;

namespace TravelAgency.Common.Financial
{
    public static class CommisionMoneyCounter
    {
        private static readonly BLL.CommisionMoney _bllCommisionMoney = new CommisionMoney();

        public static Dictionary<string, Model.CommisionMoney> CommisionMoniesDict = new Dictionary<string, Model.CommisionMoney>();

        static CommisionMoneyCounter()
        {
            UpdateCommisionConfig();
        }

        public static void UpdateCommisionConfig()
        {
            var list = _bllCommisionMoney.GetModelList(string.Empty);
            CommisionMoniesDict.Clear();
            foreach (var commisionMoney in list)
            {
                CommisionMoniesDict.Add(commisionMoney.Type, commisionMoney);
            }
        }

        public static decimal CalcCommisionMoney(Model.CommissionModel model)
        {
            if (!CommisionMoniesDict.ContainsKey(model.Type))
                return 0;
            var moneyModel = CommisionMoniesDict[model.Type];
            decimal res = 0;
            res += model.Type00ScanedIn*moneyModel.Type00ScanedIn.Value;
            res += model.Type02TypeInData*moneyModel.Type02TypeInData.Value;
            res += model.Type05SendSubmission*moneyModel.Type05SendSubmission.Value;
            res += model.Type06GetSubmission*moneyModel.Type06GetSubmission.Value;
            res += model.Type07AccompanySubmission*moneyModel.Type07AccompanySubmission.Value;
            res += model.Type08Plan * moneyModel.Type08Plan.Value;
            return res;
        }

    }
}
