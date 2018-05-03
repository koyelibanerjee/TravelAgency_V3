using System;
namespace TravelAgency.OrdersManagement.AutoUpdate.Model
{
	/// <summary>
	/// ProgramUpdate:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProgramUpdateModel
	{
		public ProgramUpdateModel()
		{}
		#region Model
		private int _id;
		private string _version;
		private string _updatefiles;
		private string _updatedetails;
		private DateTime? _entrytime;
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
		public string Version
		{
			set{ _version=value;}
			get{return _version;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UpdateFiles
		{
			set{ _updatefiles=value;}
			get{return _updatefiles;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UpdateDetails
		{
			set{ _updatedetails=value;}
			get{return _updatedetails;}
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

