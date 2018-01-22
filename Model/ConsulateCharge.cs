using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// ConsulateCharge:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ConsulateCharge
	{
		public ConsulateCharge()
		{}
		#region Model
		private int _id;
		private string _country;
		private string _types;
		private string _departuretype;
		private decimal? _consulatecost;
		private decimal? _visapersoncost;
		private decimal? _invitationcost;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Types
		{
			set{ _types=value;}
			get{return _types;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepartureType
		{
			set{ _departuretype=value;}
			get{return _departuretype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ConsulateCost
		{
			set{ _consulatecost=value;}
			get{return _consulatecost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? VisaPersonCost
		{
			set{ _visapersoncost=value;}
			get{return _visapersoncost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? InvitationCost
		{
			set{ _invitationcost=value;}
			get{return _invitationcost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

