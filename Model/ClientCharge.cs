using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// ClientCharge:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ClientCharge
	{
		public ClientCharge()
		{}
		#region Model
		private int _id;
		private string _client;
		private string _country;
		private string _types;
		private string _departuretype;
		private decimal? _charge;
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
		public string Client
		{
			set{ _client=value;}
			get{return _client;}
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
		public decimal? Charge
		{
			set{ _charge=value;}
			get{return _charge;}
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

