using  System;
namespace Maticsoft.Model
{
	/// <summary>
	/// EquipmentType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EquipmentType
	{
		public EquipmentType()
		{}
		#region Model
		private int _tid;
		private string _type;
		private int _pid;
		/// <summary>
		/// 
		/// </summary>
		public int TID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 设备类型
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 外键-协议ID
		/// </summary>
		public int PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		#endregion Model

	}
}

