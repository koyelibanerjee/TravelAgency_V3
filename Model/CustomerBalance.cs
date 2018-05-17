using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// CustomerBalance:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CustomerBalance
	{
		public CustomerBalance()
		{}
		#region Model
		private Guid _balanceid;
		private Guid _money_id;
		private Guid _customeid;
		private string _customername;
		private string _mobile;
		private decimal _amount;
		private decimal _balanceamount;
		private int? _balanceflag;
		private string _workid;
		private DateTime _entrytime= DateTime.Now;
		private string _moneytype;
		/// <summary>
		/// 主键
		/// </summary>
		public Guid BalanceId
		{
			set{ _balanceid=value;}
			get{return _balanceid;}
		}
		/// <summary>
		/// 财务发布账的id
		/// </summary>
		public Guid Money_id
		{
			set{ _money_id=value;}
			get{return _money_id;}
		}
		/// <summary>
		/// 客户表中主键
		/// </summary>
		public Guid CustomeID
		{
			set{ _customeid=value;}
			get{return _customeid;}
		}
		/// <summary>
		/// 客户名称
		/// </summary>
		public string CustomerName
		{
			set{ _customername=value;}
			get{return _customername;}
		}
		/// <summary>
		/// 客户电话
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 财务到账金额
		/// </summary>
		public decimal Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 认领后的余额
		/// </summary>
		public decimal BalanceAmount
		{
			set{ _balanceamount=value;}
			get{return _balanceamount;}
		}
		/// <summary>
		/// 1表示认领完,0表示未认领
		/// </summary>
		public int? BalanceFlag
		{
			set{ _balanceflag=value;}
			get{return _balanceflag;}
		}
		/// <summary>
		/// 员工从财务表认领的操作员工号
		/// </summary>
		public string WorkId
		{
			set{ _workid=value;}
			get{return _workid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime EntryTime
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
		#endregion Model

	}
}

