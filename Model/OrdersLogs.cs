using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// OrdersLogs:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrdersLogs
	{
		public OrdersLogs()
		{}
		#region Model
		private int _id;
		private int? _acttype;
		private string _username;
		private int? _ordersid;
		private DateTime? _entrytime;
		private string _workid;
		private string _orderno;
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
		public int? ActType
		{
			set{ _acttype=value;}
			get{return _acttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrdersId
		{
			set{ _ordersid=value;}
			get{return _ordersid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EntryTime
		{
			set{ _entrytime=value;}
			get{return _entrytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkId
		{
			set{ _workid=value;}
			get{return _workid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrderNo
		{
			set{ _orderno=value;}
			get{return _orderno;}
		}
		#endregion Model

	}
}

