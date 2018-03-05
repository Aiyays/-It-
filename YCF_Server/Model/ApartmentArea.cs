using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// ApartmentArea:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ApartmentArea
	{
		public ApartmentArea()
		{}
		#region Model
		private int _aid;
		private string _apartmentarea;
		/// <summary>
		/// 
		/// </summary>
		public int AID
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		/// <summary>
		/// 房间区域
		/// </summary>
		public string ApartmentArea
		{
			set{ _apartmentarea=value;}
			get{return _apartmentarea;}
		}
		#endregion Model

	}
}

