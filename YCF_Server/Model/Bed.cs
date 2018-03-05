using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// Bed:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Bed
	{
		public Bed()
		{}
		#region Model
		private int _bid;
		private string _number;
		private string _posture;
		private int? _pid;
		private int? _eid;
		private int _aid;
		/// <summary>
		/// 
		/// </summary>
		public int BID
		{
			set{ _bid=value;}
			get{return _bid;}
		}
		/// <summary>
		/// 编号
		/// </summary>
		public string Number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 姿态
		/// </summary>
		public string Posture
		{
			set{ _posture=value;}
			get{return _posture;}
		}
		/// <summary>
		/// 外键-病人
		/// </summary>
		public int? PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 外键-设备
		/// </summary>
		public int? EID
		{
			set{ _eid=value;}
			get{return _eid;}
		}
		/// <summary>
		/// 外键-房间
		/// </summary>
		public int AID
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		#endregion Model

	}
}

