using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// Message:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Message
	{
		public Message()
		{}
		#region Model
		private int _id;
		private string _fromuser;
		private string _touser;
		private string _msgcontent;
		private string _msgtype;
		private string _msgstate;
		private string _orderno;
		private int? _replyid;
		private bool _isurgent;
		private DateTime? _entrytime= DateTime.Now;
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
		public string FromUser
		{
			set{ _fromuser=value;}
			get{return _fromuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ToUser
		{
			set{ _touser=value;}
			get{return _touser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MsgContent
		{
			set{ _msgcontent=value;}
			get{return _msgcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MsgType
		{
			set{ _msgtype=value;}
			get{return _msgtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MsgState
		{
			set{ _msgstate=value;}
			get{return _msgstate;}
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
		public int? ReplyId
		{
			set{ _replyid=value;}
			get{return _replyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsUrgent
		{
			set{ _isurgent=value;}
			get{return _isurgent;}
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

