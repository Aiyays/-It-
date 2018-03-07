using  System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 机构表
	/// </summary>
	[Serializable]
	public partial class Operator
	{
		public Operator()
		{}
		#region Model
		private int _oid;
		private string _operatorname;
		private string _operatortel;
		private string _operatorlogopath;
		private string _nickname;
		private string _address;
		private string _longitude;
		private string _latitude;
		private int _uid;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int OID
		{
			set{ _oid=value;}
			get{return _oid;}
		}
		/// <summary>
		/// 机构名称
		/// </summary>
		public string OperatorName
		{
			set{ _operatorname=value;}
			get{return _operatorname;}
		}
		/// <summary>
		/// 机构电话
		/// </summary>
		public string OperatorTEL
		{
			set{ _operatortel=value;}
			get{return _operatortel;}
		}
		/// <summary>
		/// 机构LOGO路径
		/// </summary>
		public string OperatorLogoPath
		{
			set{ _operatorlogopath=value;}
			get{return _operatorlogopath;}
		}
		/// <summary>
		/// 简称
		/// </summary>
		public string NickName
		{
			set{ _nickname=value;}
			get{return _nickname;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 经度
		/// </summary>
		public string Longitude
		{
			set{ _longitude=value;}
			get{return _longitude;}
		}
		/// <summary>
		/// 纬度
		/// </summary>
		public string Latitude
		{
			set{ _latitude=value;}
			get{return _latitude;}
		}
		/// <summary>
		/// 外键-法人信息
		/// </summary>
		public int UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

