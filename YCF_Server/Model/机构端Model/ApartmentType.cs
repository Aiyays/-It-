using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 房间区域表
	/// </summary>
	[Serializable]
	public partial class ApartmentType
	{
		public ApartmentType()
		{}
		#region Model
		private int _tid;
		private string _type;
		/// <summary>
		/// 
		/// </summary>
		public int TID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 房间类型
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		#endregion Model

	}
}

