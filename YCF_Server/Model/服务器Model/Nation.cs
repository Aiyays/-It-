using  System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 民族表
	/// </summary>
	[Serializable]
	public partial class Nation
	{
		public Nation()
		{}
		#region Model
		private int _nid;
		private string _nation;
		/// <summary>
		/// 
		/// </summary>
		public int NID
		{
			set{ _nid=value;}
			get{return _nid;}
		}
		/// <summary>
		/// 民族
		/// </summary>
		public string nation
		{
			set{ _nation=value;}
			get{return _nation;}
		}
		#endregion Model

	}
}

