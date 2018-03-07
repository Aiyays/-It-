using  System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 民族与禁忌表
	/// </summary>
	[Serializable]
	public partial class Nation_Taboo
	{
		public Nation_Taboo()
		{}
		#region Model
		private int _ntid;
		private int _nid;
		private int _tid;
		/// <summary>
		/// 
		/// </summary>
		public int NTID
		{
			set{ _ntid=value;}
			get{return _ntid;}
		}
		/// <summary>
		/// 外键-民族ID
		/// </summary>
		public int NID
		{
			set{ _nid=value;}
			get{return _nid;}
		}
		/// <summary>
		/// 外键-禁忌ID
		/// </summary>
		public int TID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		#endregion Model

	}
}

