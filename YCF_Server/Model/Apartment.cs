using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// Apartment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Apartment
	{
		public Apartment()
		{}
		#region Model
		private int _aid;
		private string _name;
		private string _number;
		private int _areaid;
		private int _tid;
		/// <summary>
		/// 
		/// </summary>
		public int AID
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		/// <summary>
		/// 房间名
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 房间号
		/// </summary>
		public string Number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 外键-房间区域
		/// </summary>
		public int AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 外键-房间类型
		/// </summary>
		public int TID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		#endregion Model

	}
}

