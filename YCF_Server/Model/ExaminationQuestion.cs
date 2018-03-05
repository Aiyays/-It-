using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 考题表（BADL、IADL、LSP）单选和多选考题
	/// </summary>
	[Serializable]
	public partial class ExaminationQuestion
	{
		public ExaminationQuestion()
		{}
		#region Model
		private int _eid;
		private string _question;
		private int _egroup;
		private string _etype;
		private int? _isradio=0;
		/// <summary>
		/// id 自增
		/// </summary>
		public int EID
		{
			set{ _eid=value;}
			get{return _eid;}
		}
		/// <summary>
		/// 考题题目
		/// </summary>
		public string Question
		{
			set{ _question=value;}
			get{return _question;}
		}
		/// <summary>
		/// 考题分组（1,2,3）
		/// </summary>
		public int EGroup
		{
			set{ _egroup=value;}
			get{return _egroup;}
		}
		/// <summary>
		/// 题目类型（BADL、IADL、LSP）
		/// </summary>
		public string EType
		{
			set{ _etype=value;}
			get{return _etype;}
		}
		/// <summary>
		/// 是否单选题（0是,1否）
		/// </summary>
		public int? IsRadio
		{
			set{ _isradio=value;}
			get{return _isradio;}
		}
		#endregion Model

	}
}

