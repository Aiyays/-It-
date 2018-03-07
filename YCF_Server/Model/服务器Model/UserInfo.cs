using  System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 用户表
	/// </summary>
	[Serializable]
	public partial class UserInfo
	{
		public UserInfo()
		{}
		#region Model
		private int _uid;
		private string _username;
		private string _picturepath;
		private string _usersex;
		private DateTime _birthdate;
		private int _nid;
		private string _address;
		private string _idnumber;
		private string _company;
		private string _political_outlook;
		private string _education;
		private string _usertel;
		private string _maritalstatus;
		private string _password;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 照片路径
		/// </summary>
		public string PicturePath
		{
			set{ _picturepath=value;}
			get{return _picturepath;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string UserSex
		{
			set{ _usersex=value;}
			get{return _usersex;}
		}
		/// <summary>
		/// 出生日期
		/// </summary>
		public DateTime BirthDate
		{
			set{ _birthdate=value;}
			get{return _birthdate;}
		}
		/// <summary>
		/// 外键-民族
		/// </summary>
		public int NID
		{
			set{ _nid=value;}
			get{return _nid;}
		}
		/// <summary>
		/// 住址
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 身份证号码
		/// </summary>
		public string IDNumber
		{
			set{ _idnumber=value;}
			get{return _idnumber;}
		}
		/// <summary>
		/// 单位
		/// </summary>
		public string Company
		{
			set{ _company=value;}
			get{return _company;}
		}
		/// <summary>
		/// 政治面貌
		/// </summary>
		public string Political_outlook
		{
			set{ _political_outlook=value;}
			get{return _political_outlook;}
		}
		/// <summary>
		/// 学历
		/// </summary>
		public string Education
		{
			set{ _education=value;}
			get{return _education;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string UserTEL
		{
			set{ _usertel=value;}
			get{return _usertel;}
		}
		/// <summary>
		/// 婚姻状况
		/// </summary>
		public string Maritalstatus
		{
			set{ _maritalstatus=value;}
			get{return _maritalstatus;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

