using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 具体功能权限表
	/// </summary>
	[Serializable]
	public partial class UserRole
	{
		public UserRole()
		{}
		#region Model
		private int _urid;
		private int _uid;
		private int _rid;
		/// <summary>
		/// 结构用户角色部门关系ID
		/// </summary>
		public int URID
		{
			set{ _urid=value;}
			get{return _urid;}
		}
		/// <summary>
		/// 机构用户ID-外键
		/// </summary>
		public int UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 角色ID-外键
		/// </summary>
		public int RID
		{
			set{ _rid=value;}
			get{return _rid;}
		}
		#endregion Model

	}
}

