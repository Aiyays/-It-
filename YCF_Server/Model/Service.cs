using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 考题选项表
	/// </summary>
	[Serializable]
	public partial class Service
	{
		public Service()
		{}
		#region Model
		private int _sid;
		private string _sname;
		private DateTime _starttime;
		private DateTime _endtime;
		private int _frequency;
		private int _magnitude;
		private string _standard;
		private int _stid;
		/// <summary>
		/// 
		/// </summary>
		public int SID
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 服务名称
		/// </summary>
		public string SName
		{
			set{ _sname=value;}
			get{return _sname;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 次数频率
		/// </summary>
		public int Frequency
		{
			set{ _frequency=value;}
			get{return _frequency;}
		}
		/// <summary>
		/// 量值
		/// </summary>
		public int Magnitude
		{
			set{ _magnitude=value;}
			get{return _magnitude;}
		}
		/// <summary>
		/// 标准
		/// </summary>
		public string Standard
		{
			set{ _standard=value;}
			get{return _standard;}
		}
		/// <summary>
		/// 外键-服务类型
		/// </summary>
		public int STID
		{
			set{ _stid=value;}
			get{return _stid;}
		}
		#endregion Model

	}
}

