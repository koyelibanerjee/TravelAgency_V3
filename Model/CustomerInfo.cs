using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// CustomerInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CustomerInfo
	{
		public CustomerInfo()
		{}
		#region Model
		private Guid _customeid;
		private string _customername;
		private string _company;
		private string _uniformcode;
		private string _department;
		private string _principal;
		private string _mobile;
		private string _tobear;
		private string _tobearmobile;
		private string _address;
		private string _contractno;
		private string _contractdate;
		private string _contractexpiration;
		private string _contractperiod;
		private string _phone;
		private string _wechat;
		private string _qq;
		private string _fax;
		private string _type;
		private string _workid;
		private string _departmentid;
		private string _tips;
		private string _datatype;
		private Guid _parentid;
		private DateTime? _entrytime= DateTime.Now;
		private string _lng;
		private string _lat;
		private string _operator;
		private string _imgpath;
		/// <summary>
		/// 
		/// </summary>
		public Guid CustomeID
		{
			set{ _customeid=value;}
			get{return _customeid;}
		}
		/// <summary>
		/// 同担当(业务对接人)
		/// </summary>
		public string CustomerName
		{
			set{ _customername=value;}
			get{return _customername;}
		}
		/// <summary>
		/// 旅行社全称（行政录入）
		/// </summary>
		public string Company
		{
			set{ _company=value;}
			get{return _company;}
		}
		/// <summary>
		/// 统一信用代码（行政录入）
		/// </summary>
		public string UniformCode
		{
			set{ _uniformcode=value;}
			get{return _uniformcode;}
		}
		/// <summary>
		/// 部门
		/// </summary>
		public string Department
		{
			set{ _department=value;}
			get{return _department;}
		}
		/// <summary>
		/// 负责人（部门经理）
		/// </summary>
		public string Principal
		{
			set{ _principal=value;}
			get{return _principal;}
		}
		/// <summary>
		/// 部门经理手机
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 担当(业务对接人)
		/// </summary>
		public string ToBear
		{
			set{ _tobear=value;}
			get{return _tobear;}
		}
		/// <summary>
		/// 担当联系方式
		/// </summary>
		public string ToBearMobile
		{
			set{ _tobearmobile=value;}
			get{return _tobearmobile;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 合同编号
		/// </summary>
		public string ContractNo
		{
			set{ _contractno=value;}
			get{return _contractno;}
		}
		/// <summary>
		/// 合同签订日期
		/// </summary>
		public string ContractDate
		{
			set{ _contractdate=value;}
			get{return _contractdate;}
		}
		/// <summary>
		/// 合同到期时间
		/// </summary>
		public string ContractExpiration
		{
			set{ _contractexpiration=value;}
			get{return _contractexpiration;}
		}
		/// <summary>
		/// 合约账期分为：团走款结、月结（或指定时间段）、定额结算、平台结算、其他方式（需备注具体情况）
		/// </summary>
		public string ContractPeriod
		{
			set{ _contractperiod=value;}
			get{return _contractperiod;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WeChat
		{
			set{ _wechat=value;}
			get{return _wechat;}
		}
		/// <summary>
		/// QQ号
		/// </summary>
		public string QQ
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 传真
		/// </summary>
		public string Fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// 类型(同行\直客\网络\大客户)
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
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
		public string DepartmentId
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
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
		/// 
		/// </summary>
		public string DataType
		{
			set{ _datatype=value;}
			get{return _datatype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
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
		public string Lng
		{
			set{ _lng=value;}
			get{return _lng;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Lat
		{
			set{ _lat=value;}
			get{return _lat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Operator
		{
			set{ _operator=value;}
			get{return _operator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImgPath
		{
			set{ _imgpath=value;}
			get{return _imgpath;}
		}
		#endregion Model

	}
}

