using  System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 用户和机构关联表
	/// </summary>
	[Serializable]
	public partial class User_Operator
	{
		public User_Operator()
		{}
		#region Model
		private int _uoid;
		private int _uid;
		private int _oid;
		private int _ishospitalization;
		/// <summary>
		/// 
		/// </summary>
		public int UOID
		{
			set{ _uoid=value;}
			get{return _uoid;}
		}
		/// <summary>
		/// 外键-用户ID
		/// </summary>
		public int UID
		{
			set{ _uid=value;}
			get{return _uid;}
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
		/// 是否在院
		/// </summary>
		public int ISHospitalization
		{
			set{ _ishospitalization=value;}
			get{return _ishospitalization;}
		}
		#endregion Model

	}
}

