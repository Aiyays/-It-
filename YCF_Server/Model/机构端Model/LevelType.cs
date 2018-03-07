using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 级别类型
	/// </summary>
	[Serializable]
	public partial class LevelType
	{
		public LevelType()
		{}
		#region Model
		private int _ltid;
		private int _lid;
		private int _stid;
		/// <summary>
		/// 
		/// </summary>
		public int LTID
		{
			set{ _ltid=value;}
			get{return _ltid;}
		}
		/// <summary>
		/// 外键-级别
		/// </summary>
		public int LID
		{
			set{ _lid=value;}
			get{return _lid;}
		}
		/// <summary>
		/// 外键-级别类型
		/// </summary>
		public int STID
		{
			set{ _stid=value;}
			get{return _stid;}
		}
		#endregion Model

	}
}

