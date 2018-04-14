using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// OrderInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrderInfo
	{
		public OrderInfo()
		{}
		#region Model
		private int _id;
		private string _orderno;
		private decimal? _amount;
		private int _ordertype;
		private int _paymentplatform;
		private string _productname;
		private DateTime? _ordertime;
		private DateTime? _entrytime;
		private string _extradata;
		private int? _orderexcelid;
		private int _orderinfostate;
		private string _operatorname;
		private string _operatorworkid;
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
		public string OrderNo
		{
			set{ _orderno=value;}
			get{return _orderno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int OrderType
		{
			set{ _ordertype=value;}
			get{return _ordertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PaymentPlatform
		{
			set{ _paymentplatform=value;}
			get{return _paymentplatform;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OrderTime
		{
			set{ _ordertime=value;}
			get{return _ordertime;}
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
		public string ExtraData
		{
			set{ _extradata=value;}
			get{return _extradata;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderExcelId
		{
			set{ _orderexcelid=value;}
			get{return _orderexcelid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int OrderInfoState
		{
			set{ _orderinfostate=value;}
			get{return _orderinfostate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OperatorName
		{
			set{ _operatorname=value;}
			get{return _operatorname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OperatorWorkId
		{
			set{ _operatorworkid=value;}
			get{return _operatorworkid;}
		}
		#endregion Model

	}
}

