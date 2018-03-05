using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 考题选项表
	/// </summary>
	[Serializable]
	public partial class PersonalService
	{
		public PersonalService()
		{}
		#region Model
		private int _psid;
		private int _pid;
		private int _gid;
		private int _sid;
		private DateTime _ptime;
		/// <summary>
		/// 
		/// </summary>
		public int PSID
		{
			set{ _psid=value;}
			get{return _psid;}
		}
		/// <summary>
		/// 外键-病人
		/// </summary>
		public int PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 外键-组
		/// </summary>
		public int GID
		{
			set{ _gid=value;}
			get{return _gid;}
		}
		/// <summary>
		/// 外键-服务
		/// </summary>
		public int SID
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime PTime
		{
			set{ _ptime=value;}
			get{return _ptime;}
		}
		#endregion Model

	}
}

