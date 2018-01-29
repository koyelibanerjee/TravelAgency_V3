using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// AppAll:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AppAll
	{
		public AppAll()
		{}
		#region Model
		private Guid _app_id;
		private string _username;
		private string _workid;
		private Guid _departmentid;
		private decimal? _amount;
		private string _groupno;
		private string _details;
		private string _payway;
		private DateTime? _apptime;
		private string _account;
		private string _bank_to;
		private string _bank;
		private string _person;
		private string _bank_from;
		private decimal? _amount_spend;
		private string _img;
		private DateTime? _entrytime= DateTime.Now;
		private int? _flag;
		private int _temp;
		private string _appno;
		private string _printstate;
		/// <summary>
		/// 请款ID
		/// </summary>
		public Guid App_id
		{
			set{ _app_id=value;}
			get{return _app_id;}
		}
		/// <summary>
		/// 请款人姓名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 请款人工号
		/// </summary>
		public string WorkId
		{
			set{ _workid=value;}
			get{return _workid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid DepartmentId
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 请款金额
		/// </summary>
		public decimal? Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 团号
		/// </summary>
		public string GroupNo
		{
			set{ _groupno=value;}
			get{return _groupno;}
		}
		/// <summary>
		/// 情况详情
		/// </summary>
		public string Details
		{
			set{ _details=value;}
			get{return _details;}
		}
		/// <summary>
		/// 现金or汇款？
		/// </summary>
		public string PayWay
		{
			set{ _payway=value;}
			get{return _payway;}
		}
		/// <summary>
		/// 请款时间
		/// </summary>
		public DateTime? AppTime
		{
			set{ _apptime=value;}
			get{return _apptime;}
		}
		/// <summary>
		/// 汇款账户
		/// </summary>
		public string Account
		{
			set{ _account=value;}
			get{return _account;}
		}
		/// <summary>
		/// 汇款银行
		/// </summary>
		public string Bank_To
		{
			set{ _bank_to=value;}
			get{return _bank_to;}
		}
		/// <summary>
		/// 开户行
		/// </summary>
		public string Bank
		{
			set{ _bank=value;}
			get{return _bank;}
		}
		/// <summary>
		/// 开户名
		/// </summary>
		public string Person
		{
			set{ _person=value;}
			get{return _person;}
		}
		/// <summary>
		/// 支出银行
		/// </summary>
		public string Bank_From
		{
			set{ _bank_from=value;}
			get{return _bank_from;}
		}
		/// <summary>
		/// 支出金额
		/// </summary>
		public decimal? Amount_Spend
		{
			set{ _amount_spend=value;}
			get{return _amount_spend;}
		}
		/// <summary>
		/// 财务汇款水单
		/// </summary>
		public string Img
		{
			set{ _img=value;}
			get{return _img;}
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
		/// 用于判断是否是个签的请款（为1则是签证请款，2是销售请款，空则不是）
		/// </summary>
		public int? Flag
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int temp
		{
			set{ _temp=value;}
			get{return _temp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AppNo
		{
			set{ _appno=value;}
			get{return _appno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PrintState
		{
			set{ _printstate=value;}
			get{return _printstate;}
		}
		#endregion Model

	}
}

