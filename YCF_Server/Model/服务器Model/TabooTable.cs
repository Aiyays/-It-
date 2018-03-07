using  System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 禁忌表
	/// </summary>
	[Serializable]
	public partial class TabooTable
	{
		public TabooTable()
		{}
		#region Model
		private int _tid;
		private string _taboo;
		/// <summary>
		/// 
		/// </summary>
		public int TID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 禁忌
		/// </summary>
		public string Taboo
		{
			set{ _taboo=value;}
			get{return _taboo;}
		}
		#endregion Model

	}
}

