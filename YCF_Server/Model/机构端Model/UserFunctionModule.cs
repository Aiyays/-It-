using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 具体权限相关功能
	/// </summary>
	[Serializable]
	public partial class UserFunctionModule
	{
		public UserFunctionModule()
		{}
		#region Model
		private int _mid;
		private int _f_id;
		private string _remarks;
		private string _name;
		/// <summary>
		/// 权限ID
		/// </summary>
		public int MID
		{
			set{ _mid=value;}
			get{return _mid;}
		}
		/// <summary>
		/// 父级ID
		/// </summary>
		public int F_ID
		{
			set{ _f_id=value;}
			get{return _f_id;}
		}
		/// <summary>
		/// 功能模块名称备注(如：信息管理、权限管理、添加按钮、删除按钮等) 
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		/// <summary>
		/// 功能模块名称（如：UserInfoPage、AddButton）
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		#endregion Model

	}
}

