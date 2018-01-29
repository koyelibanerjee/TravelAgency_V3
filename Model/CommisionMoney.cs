using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// CommisionMoney:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CommisionMoney
	{
		public CommisionMoney()
		{}
		#region Model
		private int _id;
		private string _type;
		private decimal? _type00scanedin;
		private decimal? _type02typeindata;
		private decimal? _type05sendsubmission;
		private decimal? _type06getsubmission;
		private decimal? _type07accompanysubmission;
		private decimal? _type08plan;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Type00ScanedIn
		{
			set{ _type00scanedin=value;}
			get{return _type00scanedin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Type02TypeInData
		{
			set{ _type02typeindata=value;}
			get{return _type02typeindata;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Type05SendSubmission
		{
			set{ _type05sendsubmission=value;}
			get{return _type05sendsubmission;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Type06GetSubmission
		{
			set{ _type06getsubmission=value;}
			get{return _type06getsubmission;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Type07AccompanySubmission
		{
			set{ _type07accompanysubmission=value;}
			get{return _type07accompanysubmission;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Type08Plan
		{
			set{ _type08plan=value;}
			get{return _type08plan;}
		}
		#endregion Model

	}
}

