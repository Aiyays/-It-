using System;
namespace YCF_Server.Model
{
	/// <summary>
	///房间区域表
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
		public string apartmentArea
		{
			set{ _apartmentarea=value;}
			get{return _apartmentarea;}
		}
		#endregion Model

	}
}

