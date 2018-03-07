using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 护理标签
	/// </summary>
	[Serializable]
	public partial class ServiceLabel
	{
		public ServiceLabel()
		{}
		#region Model
		private int _slid;
		private int _sid;
		private int _lid;
		/// <summary>
		/// 
		/// </summary>
		public int SLID
		{
			set{ _slid=value;}
			get{return _slid;}
		}
		/// <summary>
		/// 外键-服务ID
		/// </summary>
		public int SID
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 外键-服务标签
		/// </summary>
		public int LID
		{
			set{ _lid=value;}
			get{return _lid;}
		}
		#endregion Model

	}
}

