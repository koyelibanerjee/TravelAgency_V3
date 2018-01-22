namespace TravelAgency.Common
{
    public static class PayoutUpdateRules
    {

        /// <summary>
        /// 根据价格计算总价
        /// </summary>
        /// <param name="ConsulateCost"></param>
        /// <param name="VisaPersonCost"></param>
        /// <param name="InvitationCost"></param>
        /// <returns></returns>
        public static decimal GetSinglePrice(decimal ConsulateCost, decimal VisaPersonCost, decimal InvitationCost)
        {
            return ConsulateCost + VisaPersonCost + InvitationCost;
        }

        public static void UpdateSinglePriceOfVisa(Model.Visa model)
        {
            decimal ConsulateCost = model.ConsulateCost ?? 0;
            decimal VisaPersonCost = model.VisaPersonCost ?? 0;
            decimal InvitationCost = model.InvitationCost ?? 0;

            model.Price = ConsulateCost + VisaPersonCost + InvitationCost;
        }

        public static void UpdateTotalPriceOfVisa(Model.Visa model)
        {
            decimal price = model.Price ?? 0;
            decimal picture = model.Picture ?? 0;
            decimal mail = model.MailCost ?? 0;
            decimal other = model.OtherCost ?? 0;
            model.Cost = price * model.Number + picture + mail + other;
        }


    }
}