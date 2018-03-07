﻿using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 周
	/// </summary>
	[Serializable]
	public partial class Week
	{
		public Week()
		{}
		#region Model
		private int _wid;
		private string _week;
		/// <summary>
		/// 主键
		/// </summary>
		public int WID
		{
			set{ _wid=value;}
			get{return _wid;}
		}
		/// <summary>
		/// 星期
		/// </summary>
		public string week
		{
			set{ _week=value;}
			get{return _week;}
		}
		#endregion Model

	}
}

