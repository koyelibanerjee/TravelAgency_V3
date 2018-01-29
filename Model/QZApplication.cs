using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// QZApplication:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class QZApplication
	{
		public QZApplication()
		{}
		#region Model
		private Guid _qzapp_id;
		private Guid _visa_id;
		private string _subname;
		private Guid _departmentid;
		private string _groupno;
		private DateTime? _sendtime;
		private DateTime? _finishtime;
		private string _person;
		private int? _number;
		private string _tips;
		private decimal? _price;
		private decimal? _receipt;
		private decimal? _quidco;
		private decimal? _consulatecost;
		private decimal? _visapersoncost;
		private decimal? _mailcost;
		private decimal? _picturecost;
		private string _sales;
		private string _workid;
		private DateTime? _entrytime= DateTime.Now;
		private Guid _app_id;
		private int? _flag;
		private string _country;
		private string _name;
		private decimal? _invitationcost;
		private decimal? _cost;
		/// <summary>
		/// 
		/// </summary>
		public Guid QZApp_id
		{
			set{ _qzapp_id=value;}
			get{return _qzapp_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid Visa_id
		{
			set{ _visa_id=value;}
			get{return _visa_id;}
		}
		/// <summary>
		/// 提交人
		/// </summary>
		public string SubName
		{
			set{ _subname=value;}
			get{return _subname;}
		}
		/// <summary>
		/// 部门id
		/// </summary>
		public Guid DepartmentId
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 个签生成的团号
		/// </summary>
		public string GroupNo
		{
			set{ _groupno=value;}
			get{return _groupno;}
		}
		/// <summary>
		/// 送签日期
		/// </summary>
		public DateTime? SendTime
		{
			set{ _sendtime=value;}
			get{return _sendtime;}
		}
		/// <summary>
		/// 出签日期
		/// </summary>
		public DateTime? FinishTime
		{
			set{ _finishtime=value;}
			get{return _finishtime;}
		}
		/// <summary>
		/// 送签社担当
		/// </summary>
		public string Person
		{
			set{ _person=value;}
			get{return _person;}
		}
		/// <summary>
		/// 人数
		/// </summary>
		public int? Number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Tips
		{
			set{ _tips=value;}
			get{return _tips;}
		}
		/// <summary>
		/// 签证成本单价
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 收款(给销售的售价)
		/// </summary>
		public decimal? Receipt
		{
			set{ _receipt=value;}
			get{return _receipt;}
		}
		/// <summary>
		/// 返款
		/// </summary>
		public decimal? Quidco
		{
			set{ _quidco=value;}
			get{return _quidco;}
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
		public decimal? MailCost
		{
			set{ _mailcost=value;}
			get{return _mailcost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PictureCost
		{
			set{ _picturecost=value;}
			get{return _picturecost;}
		}
		/// <summary>
		/// 销售
		/// </summary>
		public string Sales
		{
			set{ _sales=value;}
			get{return _sales;}
		}
		/// <summary>
		/// 销售工号（可能是销售部的，也可能是签证部销售的）
		/// </summary>
		public string WorkId
		{
			set{ _workid=value;}
			get{return _workid;}
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
		public Guid App_id
		{
			set{ _app_id=value;}
			get{return _app_id;}
		}
		/// <summary>
		/// Flag=0表明签证提交了。销售提交给财务后Flag从1变为2   销售插入后的数据flag=1
		/// </summary>
		public int? Flag
		{
			set{ _flag=value;}
			get{return _flag;}
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
		/// 客户名
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
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
		public decimal? cost
		{
			set{ _cost=value;}
			get{return _cost;}
		}
		#endregion Model

	}
}

