using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 设备表
	/// </summary>
	[Serializable]
	public partial class Equipment
	{
		public Equipment()
		{}
		#region Model
		private int _eid;
		private string _sn;
		private string _ename;
		private DateTime _manufacturedate;
		private DateTime _validtime;
		private string _specification;
		private string _model;
		private string _maintenancecycle;
		private string _price;
		private string _color;
		private int _count;
		private int _tid;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int EID
		{
			set{ _eid=value;}
			get{return _eid;}
		}
		/// <summary>
		/// 设备编号
		/// </summary>
		public string SN
		{
			set{ _sn=value;}
			get{return _sn;}
		}
		/// <summary>
		/// 设备名称
		/// </summary>
		public string EName
		{
			set{ _ename=value;}
			get{return _ename;}
		}
		/// <summary>
		/// 生产日期
		/// </summary>
		public DateTime ManufactureDate
		{
			set{ _manufacturedate=value;}
			get{return _manufacturedate;}
		}
		/// <summary>
		/// 有效期
		/// </summary>
		public DateTime ValidTime
		{
			set{ _validtime=value;}
			get{return _validtime;}
		}
		/// <summary>
		/// 规格
		/// </summary>
		public string Specification
		{
			set{ _specification=value;}
			get{return _specification;}
		}
		/// <summary>
		/// 型号
		/// </summary>
		public string Model
		{
			set{ _model=value;}
			get{return _model;}
		}
		/// <summary>
		/// 维护周期
		/// </summary>
		public string MaintenanceCycle
		{
			set{ _maintenancecycle=value;}
			get{return _maintenancecycle;}
		}
		/// <summary>
		/// 价格
		/// </summary>
		public string Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 颜色
		/// </summary>
		public string Color
		{
			set{ _color=value;}
			get{return _color;}
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
		/// 外键-设备类型
		/// </summary>
		public int TID
		{
			set{ _tid=value;}
			get{return _tid;}
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

