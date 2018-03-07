using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 角色
	/// </summary>
	[Serializable]
	public partial class Role
	{
		public Role()
		{}
		#region Model
		private int _rid;
		private string _rolename;
		private string _rnumber;
		private int _did;
		/// <summary>
		/// 角色ID
		/// </summary>
		public int RID
		{
			set{ _rid=value;}
			get{return _rid;}
		}
		/// <summary>
		/// 角色
		/// </summary>
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// 角色编号
		/// </summary>
		public string RNumber
		{
			set{ _rnumber=value;}
			get{return _rnumber;}
		}
		/// <summary>
		/// 部门ID-外键
		/// </summary>
		public int DID
		{
			set{ _did=value;}
			get{return _did;}
		}
		#endregion Model

	}
}

