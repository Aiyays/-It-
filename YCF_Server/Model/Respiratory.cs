using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 考题选项表
	/// </summary>
	[Serializable]
	public partial class Respiratory
	{
		public Respiratory()
		{}
		#region Model
		private int _rid;
		private DateTime _rtime;
		private int _breathe;
		private int _heartrate;
		private int _pid;
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
		public DateTime Rtime
		{
			set{ _rtime=value;}
			get{return _rtime;}
		}
		/// <summary>
		/// 呼吸
		/// </summary>
		public int Breathe
		{
			set{ _breathe=value;}
			get{return _breathe;}
		}
		/// <summary>
		/// 心率
		/// </summary>
		public int HeartRate
		{
			set{ _heartrate=value;}
			get{return _heartrate;}
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

