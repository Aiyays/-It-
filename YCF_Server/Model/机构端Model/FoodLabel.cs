using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 菜品与标签的关联表
	/// </summary>
	[Serializable]
	public partial class FoodLabel
	{
		public FoodLabel()
		{}
		#region Model
		private int _flid;
		private int _fid;
		private int _lid;
		/// <summary>
		/// 
		/// </summary>
		public int FLID
		{
			set{ _flid=value;}
			get{return _flid;}
		}
		/// <summary>
		/// 外键-菜品
		/// </summary>
		public int FID
		{
			set{ _fid=value;}
			get{return _fid;}
		}
		/// <summary>
		/// 外键-标签
		/// </summary>
		public int LID
		{
			set{ _lid=value;}
			get{return _lid;}
		}
		#endregion Model

	}
}

