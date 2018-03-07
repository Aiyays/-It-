using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 个人设备
	/// </summary>
	[Serializable]
	public partial class PersonalEquipment
	{
		public PersonalEquipment()
		{}
		#region Model
		private int _peid;
		private int _eid;
		private int _pid;
		private int _empid;
		private int _gid;
		private DateTime _ptime;
		private int _number;
		/// <summary>
		/// 
		/// </summary>
		public int PEID
		{
			set{ _peid=value;}
			get{return _peid;}
		}
		/// <summary>
		/// 外键-设备
		/// </summary>
		public int EID
		{
			set{ _eid=value;}
			get{return _eid;}
		}
		/// <summary>
		/// 外键-病人
		/// </summary>
		public int PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 外键-员工
		/// </summary>
		public int EmpID
		{
			set{ _empid=value;}
			get{return _empid;}
		}
		/// <summary>
		/// 外键-组
		/// </summary>
		public int GID
		{
			set{ _gid=value;}
			get{return _gid;}
		}
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime PTime
		{
			set{ _ptime=value;}
			get{return _ptime;}
		}
		/// <summary>
		/// 数量
		/// </summary>
		public int Number
		{
			set{ _number=value;}
			get{return _number;}
		}
		#endregion Model

	}
}

