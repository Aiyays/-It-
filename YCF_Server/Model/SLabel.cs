using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 考题选项表
	/// </summary>
	[Serializable]
	public partial class SLabel
	{
		public SLabel()
		{}
		#region Model
		private int _lid;
		private string _label;
		/// <summary>
		/// 
		/// </summary>
		public int LID
		{
			set{ _lid=value;}
			get{return _lid;}
		}
		/// <summary>
		/// 服务标签
		/// </summary>
		public string Label
		{
			set{ _label=value;}
			get{return _label;}
		}
		#endregion Model

	}
}

