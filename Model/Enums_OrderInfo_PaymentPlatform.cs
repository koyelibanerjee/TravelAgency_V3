using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// Enums_OrderInfo_PaymentPlatform:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Enums_OrderInfo_PaymentPlatform
	{
		public Enums_OrderInfo_PaymentPlatform()
		{}
		#region Model
		private int _platno;
		private string _platename;
		/// <summary>
		/// 
		/// </summary>
		public int PlatNo
		{
			set{ _platno=value;}
			get{return _platno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlateName
		{
			set{ _platename=value;}
			get{return _platename;}
		}
		#endregion Model

	}
}

