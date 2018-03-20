using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// AuthUser:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserQueueItem
	{
		public UserQueueItem()
		{}
        private int _id;
		private string _workid;
		private string _username;
        private bool _isbusy;
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string WorkId
		{
			set{ _workid=value;}
			get{return _workid;}
		}
		
		/// <summary>
		/// 用户姓名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}

        public bool IsBusy
        {
            set { _isbusy = value; }
            get { return _isbusy; }
        }
		

	}
}

