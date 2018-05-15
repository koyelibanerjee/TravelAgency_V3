using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// OrderFiles:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrderFiles
	{
		public OrderFiles()
		{}
		#region Model
		private int _id;
		private string _origfilename;
		private string _filename;
		private DateTime? _entrytime;
		private int? _ordersid;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrigFileName
		{
			set{ _origfilename=value;}
			get{return _origfilename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FileName
		{
			set{ _filename=value;}
			get{return _filename;}
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
		public int? OrdersId
		{
			set{ _ordersid=value;}
			get{return _ordersid;}
		}
		#endregion Model

	}
}

