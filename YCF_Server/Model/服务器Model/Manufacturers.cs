using  System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 生产厂家
	/// </summary>
	[Serializable]
	public partial class Manufacturers
	{
		public Manufacturers()
		{}
		#region Model
		private int _mid;
		private string _name;
		private string _number;
		private string _address;
		private string _logo;
		private string _tel;
		/// <summary>
		/// 
		/// </summary>
		public int MID
		{
			set{ _mid=value;}
			get{return _mid;}
		}
		/// <summary>
		/// 厂商名称
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 厂家编号
		/// </summary>
		public string Number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 标志
		/// </summary>
		public string Logo
		{
			set{ _logo=value;}
			get{return _logo;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string TEL
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		#endregion Model

	}
}

