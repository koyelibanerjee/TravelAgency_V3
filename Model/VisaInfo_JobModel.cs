﻿using System;
namespace TravelAgency.Model
{
	/// <summary>
	/// VisaInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class VisaInfo_Job
	{
		public VisaInfo_Job()
		{}
		#region Model
		private Guid _visainfo_id;
		private string _visa_id;
		private string _groupno;
		private string _name;
		private string _englishname;
		private string _sex;
		private DateTime? _birthday;
		private string _passportno;
		private DateTime? _licencetime;
		private DateTime? _expirydate;
		private string _birthplace;
		private string _issueplace;
		private string _post;
		private string _phone;
		private string _guideno;
		private string _client;
		private string _salesperson;
		private string _types;
		private Guid _sale_id;
		private Guid _departmentid;
		private string _tips;
		private DateTime? _entrytime= DateTime.Now;
		private DateTime? _embassytime;
		private DateTime? _intime;
		private DateTime? _outtime;
		private string _realout;
		private DateTime? _realouttime;
		private string _country;
		private string _call;
		private string _exportstate;
		private string _outstate="01未记录";
		private string _residence;
		private string _occupation;
		private string _departurerecord;
		private string _marriaged;
		private string _identification;
		private string _financialcapacity;
		private string _agencyopinion;
		private string _hastypein="否";
		private DateTime? _abnormalouttime;
		private string _haschecked="否";
		private string _checkperson;
		private DateTime? _returntime;
		private int? _position;
		private string _issueplaceenglish;
		private string _birthplaceenglish;
		private int? _jobid;
		private int? _assignmenttoworkid;
		private DateTime? _assignmenttime;
		private string _assignmentstate;
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
		public string Visa_id
		{
			set{ _visa_id=value;}
			get{return _visa_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GroupNo
		{
			set{ _groupno=value;}
			get{return _groupno;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 英语姓名
		/// </summary>
		public string EnglishName
		{
			set{ _englishname=value;}
			get{return _englishname;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 生日
		/// </summary>
		public DateTime? Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 护照号
		/// </summary>
		public string PassportNo
		{
			set{ _passportno=value;}
			get{return _passportno;}
		}
		/// <summary>
		/// 发证日期
		/// </summary>
		public DateTime? LicenceTime
		{
			set{ _licencetime=value;}
			get{return _licencetime;}
		}
		/// <summary>
		/// 有效期
		/// </summary>
		public DateTime? ExpiryDate
		{
			set{ _expirydate=value;}
			get{return _expirydate;}
		}
		/// <summary>
		/// 出生地
		/// </summary>
		public string Birthplace
		{
			set{ _birthplace=value;}
			get{return _birthplace;}
		}
		/// <summary>
		/// 签发地
		/// </summary>
		public string IssuePlace
		{
			set{ _issueplace=value;}
			get{return _issueplace;}
		}
		/// <summary>
		/// 职位
		/// </summary>
		public string Post
		{
			set{ _post=value;}
			get{return _post;}
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
		/// 领队编号
		/// </summary>
		public string GuideNo
		{
			set{ _guideno=value;}
			get{return _guideno;}
		}
		/// <summary>
		/// 客户
		/// </summary>
		public string Client
		{
			set{ _client=value;}
			get{return _client;}
		}
		/// <summary>
		/// 销售员
		/// </summary>
		public string Salesperson
		{
			set{ _salesperson=value;}
			get{return _salesperson;}
		}
		/// <summary>
		/// 签证类型
		/// </summary>
		public string Types
		{
			set{ _types=value;}
			get{return _types;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid Sale_id
		{
			set{ _sale_id=value;}
			get{return _sale_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid DepartmentId
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
		public DateTime? EntryTime
		{
			set{ _entrytime=value;}
			get{return _entrytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EmbassyTime
		{
			set{ _embassytime=value;}
			get{return _embassytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? InTime
		{
			set{ _intime=value;}
			get{return _intime;}
		}
		/// <summary>
		/// 归国时间
		/// </summary>
		public DateTime? OutTime
		{
			set{ _outtime=value;}
			get{return _outtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RealOut
		{
			set{ _realout=value;}
			get{return _realout;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RealOutTime
		{
			set{ _realouttime=value;}
			get{return _realouttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Call
		{
			set{ _call=value;}
			get{return _call;}
		}
		/// <summary>
		/// 0未导出,1已导出
		/// </summary>
		public string ExportState
		{
			set{ _exportstate=value;}
			get{return _exportstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string outState
		{
			set{ _outstate=value;}
			get{return _outstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Residence
		{
			set{ _residence=value;}
			get{return _residence;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Occupation
		{
			set{ _occupation=value;}
			get{return _occupation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DepartureRecord
		{
			set{ _departurerecord=value;}
			get{return _departurerecord;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Marriaged
		{
			set{ _marriaged=value;}
			get{return _marriaged;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Identification
		{
			set{ _identification=value;}
			get{return _identification;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FinancialCapacity
		{
			set{ _financialcapacity=value;}
			get{return _financialcapacity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AgencyOpinion
		{
			set{ _agencyopinion=value;}
			get{return _agencyopinion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HasTypeIn
		{
			set{ _hastypein=value;}
			get{return _hastypein;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AbnormalOutTime
		{
			set{ _abnormalouttime=value;}
			get{return _abnormalouttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HasChecked
		{
			set{ _haschecked=value;}
			get{return _haschecked;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckPerson
		{
			set{ _checkperson=value;}
			get{return _checkperson;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ReturnTime
		{
			set{ _returntime=value;}
			get{return _returntime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Position
		{
			set{ _position=value;}
			get{return _position;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IssuePlaceEnglish
		{
			set{ _issueplaceenglish=value;}
			get{return _issueplaceenglish;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BirthPlaceEnglish
		{
			set{ _birthplaceenglish=value;}
			get{return _birthplaceenglish;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? JobId
		{
			set{ _jobid=value;}
			get{return _jobid;}
		}

	    public int? AssignmentToWorkId
	    {
            set { _assignmenttoworkid = value; }
            get { return _assignmenttoworkid; }
	    }

	    public DateTime? AssignmentTime
        {
	        set { _assignmenttime = value; }
	        get { return _assignmenttime; }
	    }

	    public string AssignmentState
	    {
	        set { _assignmentstate = value; }
	        get { return _assignmentstate; }
	    }

        #endregion Model

    }
}

