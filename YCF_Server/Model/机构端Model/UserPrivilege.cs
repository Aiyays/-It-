using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 机构权限
	/// </summary>
	[Serializable]
	public partial class UserPrivilege
	{
		public UserPrivilege()
		{}
		#region Model
		private int _id;
		private int _urid;
		private int _mid;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 机构用户角色关系表ID-外键
		/// </summary>
		public int RID
		{
			set{ _urid=value;}
			get{return _urid;}
		}
		/// <summary>
		/// 功能模块ID-外键
		/// </summary>
		public int MID
		{
			set{ _mid=value;}
			get{return _mid;}
		}
		#endregion Model

	}
}

