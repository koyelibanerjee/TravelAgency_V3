namespace TravelAgency.Model.Enums
{
    /// <summary>
    /// 状态文本
    /// </summary>
    public class OutState
    {
        public const string Type01NoRecord = "01未记录";
        public const string Type01Delay = "01延后";
        public const string Type02In = "02进签";
        public const string Type03NormalOut = "03出签";
        public const string TYPE04AbnormalOut = "04未正常出签";
        //public const string TYPE04AbnormalOut = "04未正常出签";
        public const string TYPE10Exported = "10已导出";
    }
}