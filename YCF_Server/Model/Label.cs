using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 考题表（BADL、IADL、LSP）单选和多选考题
	/// </summary>
	[Serializable]
	public partial class Label
	{
		public Label()
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
		/// 标签
		/// </summary>
		public string Label
		{
			set{ _label=value;}
			get{return _label;}
		}
		#endregion Model

	}
}

