using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 病人表
	/// </summary>
	[Serializable]
	public partial class Patient
	{
		public Patient()
		{}
		#region Model
		private int _pid;
		private int _bailorid;
		private string _relationship;
		private DateTime _checkintime;
		private DateTime? _outtime;
		private string _emergencycontact;
		private string _ectel;
		private string _bloodtype;
		private string _height;
		private int _uid;
		/// <summary>
		/// 
		/// </summary>
		public int PID
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 外键-用户表UID
		/// </summary>
		public int BailorID
		{
			set{ _bailorid=value;}
			get{return _bailorid;}
		}
		/// <summary>
		/// 关系
		/// </summary>
		public string Relationship
		{
			set{ _relationship=value;}
			get{return _relationship;}
		}
		/// <summary>
		/// 入住时间
		/// </summary>
		public DateTime CheckInTime
		{
			set{ _checkintime=value;}
			get{return _checkintime;}
		}
		/// <summary>
		/// 出院时间
		/// </summary>
		public DateTime? OutTime
		{
			set{ _outtime=value;}
			get{return _outtime;}
		}
		/// <summary>
		/// 紧急联系人
		/// </summary>
		public string EmergencyContact
		{
			set{ _emergencycontact=value;}
			get{return _emergencycontact;}
		}
		/// <summary>
		/// 紧急联系电话
		/// </summary>
		public string ECTEL
		{
			set{ _ectel=value;}
			get{return _ectel;}
		}
		/// <summary>
		/// 血型
		/// </summary>
		public string BloodType
		{
			set{ _bloodtype=value;}
			get{return _bloodtype;}
		}
		/// <summary>
		/// 身高
		/// </summary>
		public string Height
		{
			set{ _height=value;}
			get{return _height;}
		}
		/// <summary>
		/// 外键-用户表
		/// </summary>
		public int UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		#endregion Model

	}
}

