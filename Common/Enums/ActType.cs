namespace TravelAgency.Common.Enums
{
    public class ActType
    {
        public const string _00ScanIn = "00录入(扫描)";
        public const string _01CreateGroupNo = "01创建团号";
        public const string _01TypeIn = "01录入(设置团号)";
        public const string _01AddToExist = "01录入(添加到已有团号)";
        public const string _02TypeInData = "02录入做资料";
        //public const string _03GaoPai = "03高拍仪做资料";
        public const string _03Modify = "03修改资料";
        public const string _04Checked = "04校验";
        public const string _05SubmitIn = "05进签";
        public const string _05SubmitOut = "05出签";
        public const string _05SubmitAbOut = "05出签(非正常)";
        public const string _10Exported = "10已导出";
    }
}