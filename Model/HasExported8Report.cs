using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// HasExported8Report:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class HasExported8Report
	{
		public HasExported8Report()
		{}
		#region Model
		private Guid _visainfo_id;
		private DateTime? _entrytime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public Guid VisaInfo_id
		{
			set{ _visainfo_id=value;}
			get{return _visainfo_id;}
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

