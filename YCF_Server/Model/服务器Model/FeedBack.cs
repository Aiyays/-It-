using  System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 反馈表
	/// </summary>
	[Serializable]
	public partial class FeedBack
	{
		public FeedBack()
		{}
		#region Model
		private int _fid;
		private DateTime _fbdate;
		private string _fbcontent;
		private int _fbsource;
		private int _fbobject;
		private int _uid;
		private int? _oid;
		/// <summary>
		/// 
		/// </summary>
		public int FID
		{
			set{ _fid=value;}
			get{return _fid;}
		}
		/// <summary>
		/// 反馈时间
		/// </summary>
		public DateTime FBDate
		{
			set{ _fbdate=value;}
			get{return _fbdate;}
		}
		/// <summary>
		/// 反馈内容
		/// </summary>
		public string FBContent
		{
			set{ _fbcontent=value;}
			get{return _fbcontent;}
		}
		/// <summary>
		/// 反馈源
		/// </summary>
		public int FBsource
		{
			set{ _fbsource=value;}
			get{return _fbsource;}
		}
		/// <summary>
		/// 反馈对象
		/// </summary>
		public int FBobject
		{
			set{ _fbobject=value;}
			get{return _fbobject;}
		}
		/// <summary>
		/// 外键-用户
		/// </summary>
		public int UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 外键-机构
		/// </summary>
		public int? OID
		{
			set{ _oid=value;}
			get{return _oid;}
		}
		#endregion Model

	}
}

