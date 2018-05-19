using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// ClaimMoney:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ClaimMoney
	{
		public ClaimMoney()
		{}
		#region Model
		private Guid _claim_id;
		private Guid _money_id;
		private Guid _departmentid;
		private string _name_claim;
		private string _groupno;
		private string _salesperson;
		private string _guests;
		private string _methods;
		private decimal? _amount;
		private string _workid;
		private DateTime? _claimtime;
		private string _username;
		private string _orderno;
		private DateTime? _entrytime= DateTime.Now;
		private string _moneytype;
		private string _claim_confirm;
		/// <summary>
		/// 
		/// </summary>
		public Guid Claim_id
		{
			set{ _claim_id=value;}
			get{return _claim_id;}
		}
		/// <summary>
		/// 私账ID
		/// </summary>
		public Guid Money_id
		{
			set{ _money_id=value;}
			get{return _money_id;}
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
		/// 认领人
		/// </summary>
		public string Name_Claim
		{
			set{ _name_claim=value;}
			get{return _name_claim;}
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
		/// 销售人员
		/// </summary>
		public string Salesperson
		{
			set{ _salesperson=value;}
			get{return _salesperson;}
		}
		/// <summary>
		/// 客户
		/// </summary>
		public string Guests
		{
			set{ _guests=value;}
			get{return _guests;}
		}
		/// <summary>
		/// 款项用途
		/// </summary>
		public string Methods
		{
			set{ _methods=value;}
			get{return _methods;}
		}
		/// <summary>
		/// 认款金额
		/// </summary>
		public decimal? Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 工号
		/// </summary>
		public string WorkId
		{
			set{ _workid=value;}
			get{return _workid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ClaimTime
		{
			set{ _claimtime=value;}
			get{return _claimtime;}
		}
		/// <summary>
		/// 操作用户
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
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
		public DateTime? EntryTime
		{
			set{ _entrytime=value;}
			get{return _entrytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MoneyType
		{
			set{ _moneytype=value;}
			get{return _moneytype;}
		}
		/// <summary>
		/// 表示是否确认认领，0或空表示未认领完成，1表示认领完成
		/// </summary>
		public string Claim_Confirm
		{
			set{ _claim_confirm=value;}
			get{return _claim_confirm;}
		}
		#endregion Model

	}
}

