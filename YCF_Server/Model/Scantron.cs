using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 考题选项表
	/// </summary>
	[Serializable]
	public partial class Scantron
	{
		public Scantron()
		{}
		#region Model
		private int _sid;
		private int _aid;
		private int _eid;
		private int _oid;
		private int _singlescore;
		private int _sgroup;
		private int _onumber;
		/// <summary>
		/// 主键ID 自增
		/// </summary>
		public int SID
		{
			set{ _sid=value;}
			get{return _sid;}
		}
		/// <summary>
		/// 评估记录表ID-外键
		/// </summary>
		public int AID
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		/// <summary>
		/// 考题ID-外键
		/// </summary>
		public int EID
		{
			set{ _eid=value;}
			get{return _eid;}
		}
		/// <summary>
		/// 考题选项ID-外键
		/// </summary>
		public int OID
		{
			set{ _oid=value;}
			get{return _oid;}
		}
		/// <summary>
		/// 单项评分
		/// </summary>
		public int SingleScore
		{
			set{ _singlescore=value;}
			get{return _singlescore;}
		}
		/// <summary>
		/// 分组（1,2,3）
		/// </summary>
		public int SGroup
		{
			set{ _sgroup=value;}
			get{return _sgroup;}
		}
		/// <summary>
		/// 具体选项编号
		/// </summary>
		public int ONumber
		{
			set{ _onumber=value;}
			get{return _onumber;}
		}
		#endregion Model

	}
}

