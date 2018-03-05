using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 考题选项表
	/// </summary>
	[Serializable]
	public partial class ServiceNote
	{
		public ServiceNote()
		{}
		#region Model
		private int _nid;
		private string _note;
		private string _picture;
		private DateTime _ntime;
		private int _eid;
		private int _pid;
		/// <summary>
		/// 
		/// </summary>
		public int NID
		{
			set{ _nid=value;}
			get{return _nid;}
		}
		/// <summary>
		/// 笔记
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// 图片
		/// </summary>
		public string Picture
		{
			set{ _picture=value;}
			get{return _picture;}
		}
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime NTime
		{
			set{ _ntime=value;}
			get{return _ntime;}
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
		#endregion Model

	}
}

