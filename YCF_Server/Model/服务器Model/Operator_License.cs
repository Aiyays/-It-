using  System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 机构与证件表
	/// </summary>
	[Serializable]
	public partial class Operator_License
	{
		public Operator_License()
		{}
		#region Model
		private int _olid;
		private int _oid;
		private int _lid;
		/// <summary>
		/// 
		/// </summary>
		public int OLID
		{
			set{ _olid=value;}
			get{return _olid;}
		}
		/// <summary>
		/// 外键-机构ID
		/// </summary>
		public int OID
		{
			set{ _oid=value;}
			get{return _oid;}
		}
		/// <summary>
		/// 外键-机构证照ID
		/// </summary>
		public int LID
		{
			set{ _lid=value;}
			get{return _lid;}
		}
		#endregion Model

	}
}

