using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 员工与护理关联表
	/// </summary>
	[Serializable]
	public partial class EmpRankTitle
	{
		public EmpRankTitle()
		{}
		#region Model
		private int _ertid;
		private int _eid;
		private int _tid;
		private int _rtid;
		/// <summary>
		/// 主键
		/// </summary>
		public int ERTID
		{
			set{ _ertid=value;}
			get{return _ertid;}
		}
		/// <summary>
		/// （外键） 关联员工表
		/// </summary>
		public int EID
		{
			set{ _eid=value;}
			get{return _eid;}
		}
		/// <summary>
		/// 外键（关联职称表）
		/// </summary>
		public int TID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 外键（职称等级关联表）
		/// </summary>
		public int RTID
		{
			set{ _rtid=value;}
			get{return _rtid;}
		}
		#endregion Model

	}
}

