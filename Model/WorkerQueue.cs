using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// WorkerQueue:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WorkerQueue
	{
		public WorkerQueue()
		{}
		#region Model
		private int _id;
		private string _workid;
		private string _username;
		private bool _isbusy;
		private bool _canaccept;
		private int? _priority;
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
		public string WorkId
		{
			set{ _workid=value;}
			get{return _workid;}
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
		public bool IsBusy
		{
			set{ _isbusy=value;}
			get{return _isbusy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool CanAccept
		{
			set{ _canaccept=value;}
			get{return _canaccept;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Priority
		{
			set{ _priority=value;}
			get{return _priority;}
		}
		#endregion Model

	}
}

