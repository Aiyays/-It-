using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 取药
	/// </summary>
	[Serializable]
	public partial class GetDrug
	{
		public GetDrug()
		{}
		#region Model
		private int _id;
		private int _eid;
		private int _did;
		private DateTime _gdtime;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
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
		/// 外键-药品
		/// </summary>
		public int DID
		{
			set{ _did=value;}
			get{return _did;}
		}
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime GDTime
		{
			set{ _gdtime=value;}
			get{return _gdtime;}
		}
		#endregion Model

	}
}

