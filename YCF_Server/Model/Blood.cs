using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// Blood:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Blood
	{
		public Blood()
		{}
		#region Model
		private int _bid;
		private DateTime _btime;
		private int _bloodpressure;
		private int? _bloodfat;
		private int? _blooglucose;
		private int _pid;
		/// <summary>
		/// 
		/// </summary>
		public int BID
		{
			set{ _bid=value;}
			get{return _bid;}
		}
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime Btime
		{
			set{ _btime=value;}
			get{return _btime;}
		}
		/// <summary>
		/// 血压
		/// </summary>
		public int BloodPressure
		{
			set{ _bloodpressure=value;}
			get{return _bloodpressure;}
		}
		/// <summary>
		/// 血脂
		/// </summary>
		public int? BloodFat
		{
			set{ _bloodfat=value;}
			get{return _bloodfat;}
		}
		/// <summary>
		/// 血糖
		/// </summary>
		public int? BlooGlucose
		{
			set{ _blooglucose=value;}
			get{return _blooglucose;}
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

