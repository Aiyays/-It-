
using  System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 机构端与数据库信息表
	/// </summary>
	[Serializable]
	public partial class OperatorDatabase
	{
		public OperatorDatabase()
		{}
		#region Model
		private int _did;
		private int _oid;
		private string _datahost;
		private int _dataport;
		private string _dataname;
		private string _username;
		private string _userpassword;
		/// <summary>
		/// 
		/// </summary>
		public int DID
		{
			set{ _did=value;}
			get{return _did;}
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
		/// 数据库HOST
		/// </summary>
		public string DataHost
		{
			set{ _datahost=value;}
			get{return _datahost;}
		}
		/// <summary>
		/// 数据端口
		/// </summary>
		public int DataPort
		{
			set{ _dataport=value;}
			get{return _dataport;}
		}
		/// <summary>
		/// 库名
		/// </summary>
		public string DataName
		{
			set{ _dataname=value;}
			get{return _dataname;}
		}
		/// <summary>
		/// 登录数据库名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 登录数据库密码
		/// </summary>
		public string UserPassword
		{
			set{ _userpassword=value;}
			get{return _userpassword;}
		}
		#endregion Model

	}
}

