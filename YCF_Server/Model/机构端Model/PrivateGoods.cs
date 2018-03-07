using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 私人物品
	/// </summary>
	[Serializable]
	public partial class PrivateGoods
	{
		public PrivateGoods()
		{}
		#region Model
		private int _pid;
		private string _name;
		private string _number;
		private int _count;
		private int _parid;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
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
		/// 数量
		/// </summary>
		public int Count
		{
			set{ _count=value;}
			get{return _count;}
		}
		/// <summary>
		/// 外键-病人
		/// </summary>
		public int ParID
		{
			set{ _parid=value;}
			get{return _parid;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

