using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 姿态
	/// </summary>
	[Serializable]
	public partial class PostureHabit
	{
		public PostureHabit()
		{}
		#region Model
		private int _phid;
		private int? _height;
		private int? _medicine;
		private int? _back;
		private int? _head;
		private int? _waist;
		private int? _leg;
		private int _uid;
		/// <summary>
		/// 
		/// </summary>
		public int PHID
		{
			set{ _phid=value;}
			get{return _phid;}
		}
		/// <summary>
		/// 高
		/// </summary>
		public int? Height
		{
			set{ _height=value;}
			get{return _height;}
		}
		/// <summary>
		/// 医学
		/// </summary>
		public int? Medicine
		{
			set{ _medicine=value;}
			get{return _medicine;}
		}
		/// <summary>
		/// 背
		/// </summary>
		public int? Back
		{
			set{ _back=value;}
			get{return _back;}
		}
		/// <summary>
		/// 头
		/// </summary>
		public int? Head
		{
			set{ _head=value;}
			get{return _head;}
		}
		/// <summary>
		/// 腰
		/// </summary>
		public int? Waist
		{
			set{ _waist=value;}
			get{return _waist;}
		}
		/// <summary>
		/// 腿
		/// </summary>
		public int? Leg
		{
			set{ _leg=value;}
			get{return _leg;}
		}
		/// <summary>
		/// 外键-个人
		/// </summary>
		public int UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		#endregion Model

	}
}

