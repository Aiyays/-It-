using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 班次
	/// </summary>
	[Serializable]
	public partial class ScheduleCount
	{
		public ScheduleCount()
		{}
		#region Model
		private int _scid;
		private string _name;
		private DateTime _starttime;
		private DateTime _endtime;
		/// <summary>
		/// 主键
		/// </summary>
		public int SCID
		{
			set{ _scid=value;}
			get{return _scid;}
		}
		/// <summary>
		/// 班次名
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 班次开始时间
		/// </summary>
		public DateTime StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 班次结束时间
		/// </summary>
		public DateTime EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		#endregion Model

	}
}

