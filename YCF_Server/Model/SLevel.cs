using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 考题选项表
	/// </summary>
	[Serializable]
	public partial class SLevel
	{
		public SLevel()
		{}
		#region Model
		private int _lid;
		private string _slevel;
		private int _ltid;
		/// <summary>
		/// 
		/// </summary>
		public int LID
		{
			set{ _lid=value;}
			get{return _lid;}
		}
		/// <summary>
		/// 服务级别
		/// </summary>
		public string SLevel
		{
			set{ _slevel=value;}
			get{return _slevel;}
		}
		/// <summary>
		/// 外键-级别类型
		/// </summary>
		public int LTID
		{
			set{ _ltid=value;}
			get{return _ltid;}
		}
		#endregion Model

	}
}

