namespace TravelAgency.Common
{
    public static class PayoutUpdateRules
    {
        public static void UpdateSinglePriceOfVisa(Model.Visa model)
        {
            decimal ConsulateCost = model.ConsulateCost ?? 0;
            decimal VisaPersonCost = model.VisaPersonCost ?? 0;
            //decimal InvitationCost = model.InvitationCost ?? 0;

            model.Price = ConsulateCost + VisaPersonCost ;
        }

        public static void UpdateTotalPriceOfVisa(Model.Visa model)
        {
            decimal price = model.Price ?? 0;
            decimal picture = model.Picture ?? 0;
            decimal mail = model.MailCost ?? 0;
            decimal other = model.OtherCost ?? 0;
            model.Cost = price * model.Number + picture + mail + other + (model.InvitationCost ?? 0);
        }


    }
}