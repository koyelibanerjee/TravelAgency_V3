using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// Enums_OrderInfo_OrderType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Enums_OrderInfo_OrderType
	{
		public Enums_OrderInfo_OrderType()
		{}
		#region Model
		private int? _typeno;
		private string _typename;
		/// <summary>
		/// 
		/// </summary>
		public int? TypeNo
		{
			set{ _typeno=value;}
			get{return _typeno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TypeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		#endregion Model

	}
}

