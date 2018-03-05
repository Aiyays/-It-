using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class TransferClass
	{
		public TransferClass()
		{}
		#region Model
		private int _tid;
		private int _a_oid;
		private int _r_oid;
		private string _reason;
		private datetime2 _transfertime;
		private datetime2 _nowtime;
		/// <summary>
		/// 主键
		/// </summary>
		public int TID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		/// <summary>
		/// 申请调代班
		/// </summary>
		public int A_OID
		{
			set{ _a_oid=value;}
			get{return _a_oid;}
		}
		/// <summary>
		/// 接收调代班
		/// </summary>
		public int R_OID
		{
			set{ _r_oid=value;}
			get{return _r_oid;}
		}
		/// <summary>
		/// 申请调代班的原因
		/// </summary>
		public string Reason
		{
			set{ _reason=value;}
			get{return _reason;}
		}
		/// <summary>
		/// 请求调代班的时间
		/// </summary>
		public datetime2 TransferTime
		{
			set{ _transfertime=value;}
			get{return _transfertime;}
		}
		/// <summary>
		/// 确认通过时间
		/// </summary>
		public datetime2 NowTime
		{
			set{ _nowtime=value;}
			get{return _nowtime;}
		}
		#endregion Model

	}
}

