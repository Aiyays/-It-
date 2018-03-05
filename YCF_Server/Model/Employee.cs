using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 机构部门表
	/// </summary>
	[Serializable]
	public partial class Employee
	{
		public Employee()
		{}
		#region Model
		private int _eid;
		private int _uid;
		private datetime2 _natetime;
		private datetime2 _daparturtime;
		private string _state;
		private int? _gid;
		/// <summary>
		/// 主键
		/// </summary>
		public int EID
		{
			set{ _eid=value;}
			get{return _eid;}
		}
		/// <summary>
		/// (外键 关联)云服务 UserInfo 
		/// </summary>
		public int UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 入职时间
		/// </summary>
		public datetime2 NateTime
		{
			set{ _natetime=value;}
			get{return _natetime;}
		}
		/// <summary>
		/// 离职时间
		/// </summary>
		public datetime2 DaparturTime
		{
			set{ _daparturtime=value;}
			get{return _daparturtime;}
		}
		/// <summary>
		/// 目前装填 是否请假
		/// </summary>
		public string State
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// （外键）属于哪个组
		/// </summary>
		public int? GID
		{
			set{ _gid=value;}
			get{return _gid;}
		}
		#endregion Model

	}
}

