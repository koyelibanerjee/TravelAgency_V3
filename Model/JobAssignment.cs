using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// JobAssignment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class JobAssignment
	{
		public JobAssignment()
		{}
		#region Model
		private int _id;
		private DateTime? _entrytime;
		private string _assignmenttoworkid;
		private string _operatorid;
		private DateTime? _assignmenttime;
		private string _assignmenttousername;
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
		public DateTime? EntryTime
		{
			set{ _entrytime=value;}
			get{return _entrytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AssignmentToWorkId
		{
			set{ _assignmenttoworkid=value;}
			get{return _assignmenttoworkid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OperatorId
		{
			set{ _operatorid=value;}
			get{return _operatorid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AssignmentTime
		{
			set{ _assignmenttime=value;}
			get{return _assignmenttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AssignmentToUserName
		{
			set{ _assignmenttousername=value;}
			get{return _assignmenttousername;}
		}
		#endregion Model

	}
}

