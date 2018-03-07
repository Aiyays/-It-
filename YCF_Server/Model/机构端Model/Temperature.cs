using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 温度
	/// </summary>
	[Serializable]
	public partial class Temperature
	{
		public Temperature()
		{}
		#region Model
		private int _tid;
		private DateTime _measuredatetime;
		private string _temperature;
		private int _pid;
		/// <summary>
		/// 
		/// </summary>
		public int TID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 测量时间
		/// </summary>
		public DateTime MeasureDateTime
		{
			set{ _measuredatetime=value;}
			get{return _measuredatetime;}
		}
		/// <summary>
		/// 温度
		/// </summary>
		public string temperature
		{
			set{ _temperature=value;}
			get{return _temperature;}
		}
		/// <summary>
		/// 外键-病人表
		/// </summary>
		public int PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		#endregion Model

	}
}

