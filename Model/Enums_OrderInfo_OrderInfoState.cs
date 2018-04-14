using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// Enums_OrderInfo_OrderInfoState:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Enums_OrderInfo_OrderInfoState
	{
		public Enums_OrderInfo_OrderInfoState()
		{}
		#region Model
		private int _stateno;
		private string _stateinfo;
		/// <summary>
		/// 
		/// </summary>
		public int StateNo
		{
			set{ _stateno=value;}
			get{return _stateno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StateInfo
		{
			set{ _stateinfo=value;}
			get{return _stateinfo;}
		}
		#endregion Model

	}
}

