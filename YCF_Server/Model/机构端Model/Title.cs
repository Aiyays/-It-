using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 职称
	/// </summary>
	[Serializable]
	public partial class Title
	{
		public Title()
		{}
		#region Model
		private int _tid;
		private string _name;
		/// <summary>
		/// 主键
		/// </summary>
		public int TID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 职称名称
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		#endregion Model

	}
}

