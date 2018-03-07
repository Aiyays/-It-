using  System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 设备协议表
	/// </summary>
	[Serializable]
	public partial class Protocol
	{
		public Protocol()
		{}
		#region Model
		private int _pid;
		private string _protocol;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 协议
		/// </summary>
		public string protocol
		{
			set{ _protocol=value;}
			get{return _protocol;}
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

