using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 药品类型
	/// </summary>
	[Serializable]
	public partial class DrugType
	{
		public DrugType()
		{}
		#region Model
		private int _tid;
		private string _drugtype;
		/// <summary>
		/// 
		/// </summary>
		public int TID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 药品类型
		/// </summary>
		public string drugType
		{
			set{ _drugtype=value;}
			get{return _drugtype;}
		}
		#endregion Model

	}
}

