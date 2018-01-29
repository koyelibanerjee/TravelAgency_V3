using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// AppStatus:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AppStatus
	{
		public AppStatus()
		{}
		#region Model
		private Guid _appstatus_id;
		private Guid _app_id;
		private string _checkpersonid;
		private string _checkperson;
		private int _statusflag;
		private string _opinions;
		private string _tips;
		private DateTime? _checktime;
		private DateTime? _entrytime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public Guid AppStatus_id
		{
			set{ _appstatus_id=value;}
			get{return _appstatus_id;}
		}
		/// <summary>
		/// 请款ID
		/// </summary>
		public Guid App_id
		{
			set{ _app_id=value;}
			get{return _app_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckPersonId
		{
			set{ _checkpersonid=value;}
			get{return _checkpersonid;}
		}
		/// <summary>
		/// 审批人
		/// </summary>
		public string CheckPerson
		{
			set{ _checkperson=value;}
			get{return _checkperson;}
		}
		/// <summary>
		/// 状态标志（0：申请请款，1：部门经理确认，2：财务确认，3：总经理确认）
		/// </summary>
		public int StatusFlag
		{
			set{ _statusflag=value;}
			get{return _statusflag;}
		}
		/// <summary>
		/// 审批意见（同意/不同意）
		/// </summary>
		public string Opinions
		{
			set{ _opinions=value;}
			get{return _opinions;}
		}
		/// <summary>
		/// 审批备注
		/// </summary>
		public string Tips
		{
			set{ _tips=value;}
			get{return _tips;}
		}
		/// <summary>
		/// 审批确认时间
		/// </summary>
		public DateTime? CheckTime
		{
			set{ _checktime=value;}
			get{return _checktime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EntryTime
		{
			set{ _entrytime=value;}
			get{return _entrytime;}
		}
		#endregion Model

	}
}

