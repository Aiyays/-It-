using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 考题选项表
	/// </summary>
	[Serializable]
	public partial class RemindRecord
	{
		public RemindRecord()
		{}
		#region Model
		private int _rid;
		private int _pid;
		private string _rcontent;
		private DateTime _remindtime;
		/// <summary>
		/// 
		/// </summary>
		public int RID
		{
			set{ _rid=value;}
			get{return _rid;}
		}
		/// <summary>
		/// 病人
		/// </summary>
		public int PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string Rcontent
		{
			set{ _rcontent=value;}
			get{return _rcontent;}
		}
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime RemindTime
		{
			set{ _remindtime=value;}
			get{return _remindtime;}
		}
		#endregion Model

	}
}

