using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 体重
	/// </summary>
	[Serializable]
	public partial class Weight
	{
		public Weight()
		{}
		#region Model
		private int _wid;
		private DateTime _wtime;
		private string _weight;
		private int _pid;
		/// <summary>
		/// 
		/// </summary>
		public int WID
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime WTime
		{
			set{ _wtime=value;}
			get{return _wtime;}
		}
		/// <summary>
		/// 体重
		/// </summary>
		public string weight
		{
			set{ _weight=value;}
			get{return _weight;}
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

