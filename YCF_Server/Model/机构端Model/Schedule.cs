using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 排班
	/// </summary>
	[Serializable]
	public partial class Schedule
	{
		public Schedule()
		{}
		#region Model
		private int _sid;
		private int _scid;
		private int _wid;
		/// <summary>
		/// 主键
		/// </summary>
		public int SID
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 外键（班次）
		/// </summary>
		public int SCID
		{
			set{ _scid=value;}
			get{return _scid;}
		}
		/// <summary>
		/// （外键）时间周
		/// </summary>
		public int WID
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		#endregion Model

	}
}

