using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 护理记录
	/// </summary>
	[Serializable]
	public partial class ServiceRecord
	{
		public ServiceRecord()
		{}
		#region Model
		private int _rid;
		private DateTime _rtime;
		private string _evaluate;
		private string _picture;
		private int _eid;
		private int _pid;
		private int _sid;
		/// <summary>
		/// 
		/// </summary>
		public int RID
		{
			set{ _rid=value;}
			get{return _rid;}
		}
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime RTime
		{
			set{ _rtime=value;}
			get{return _rtime;}
		}
		/// <summary>
		/// 评价
		/// </summary>
		public string Evaluate
		{
			set{ _evaluate=value;}
			get{return _evaluate;}
		}
		/// <summary>
		/// 照片
		/// </summary>
		public string Picture
		{
			set{ _picture=value;}
			get{return _picture;}
		}
		/// <summary>
		/// 外键-员工
		/// </summary>
		public int EID
		{
			set{ _eid=value;}
			get{return _eid;}
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
		/// 外键-服务
		/// </summary>
		public int SID
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		#endregion Model

	}
}

