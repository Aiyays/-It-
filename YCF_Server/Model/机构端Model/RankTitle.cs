using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 职称等级
	/// </summary>
	[Serializable]
	public partial class RankTitle
	{
		public RankTitle()
		{}
		#region Model
		private int _rtid;
		private int _nub;
		/// <summary>
		/// 
		/// </summary>
		public int RTID
		{
			set{ _rtid=value;}
			get{return _rtid;}
		}
		/// <summary>
		/// 职称的等级
		/// </summary>
		public int Nub
		{
			set{ _nub=value;}
			get{return _nub;}
		}
		#endregion Model

	}
}

