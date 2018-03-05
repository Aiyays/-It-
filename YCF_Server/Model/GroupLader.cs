using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 考题表（BADL、IADL、LSP）单选和多选考题
	/// </summary>
	[Serializable]
	public partial class GroupLader
	{
		public GroupLader()
		{}
		#region Model
		private int _gid;
		private string _name;
		private int? _uid;
		private string _remak;
		/// <summary>
		/// 主键
		/// </summary>
		public int GID
		{
			set{ _gid=value;}
			get{return _gid;}
		}
		/// <summary>
		/// 组名
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// （外键）组长的个人信息
		/// </summary>
		public int? UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string Remak
		{
			set{ _remak=value;}
			get{return _remak;}
		}
		#endregion Model

	}
}

