using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 个人药品
	/// </summary>
	[Serializable]
	public partial class PensnonalDrug
	{
		public PensnonalDrug()
		{}
		#region Model
		private int _pdid;
		private DateTime _dtime;
		private string _frequency;
		private string _dose;
		private int _did;
		private int _eid;
		private int _pid;
		private string _img;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int PDID
		{
			set{ _pdid=value;}
			get{return _pdid;}
		}
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime DTime
		{
			set{ _dtime=value;}
			get{return _dtime;}
		}
		/// <summary>
		/// 频次
		/// </summary>
		public string Frequency
		{
			set{ _frequency=value;}
			get{return _frequency;}
		}
		/// <summary>
		/// 剂量
		/// </summary>
		public string Dose
		{
			set{ _dose=value;}
			get{return _dose;}
		}
		/// <summary>
		/// 外键-药品
		/// </summary>
		public int DID
		{
			set{ _did=value;}
			get{return _did;}
		}
		/// <summary>
		/// 外键-员工
		/// </summary>
		public int EID
		{
			set{ _eid=value;}
			get{return _eid;}
		}
		/// <summary>
		/// 外键-病人
		/// </summary>
		public int PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 图片
		/// </summary>
		public string IMG
		{
			set{ _img=value;}
			get{return _img;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

