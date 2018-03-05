using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 考题选项表
	/// </summary>
	[Serializable]
	public partial class Options
	{
		public Options()
		{}
		#region Model
		private int _oid;
		private int _eid;
		private string _content;
		private int? _score;
		private int _ogroup;
		private int _number;
		private string _label;
		/// <summary>
		/// id 自增
		/// </summary>
		public int OID
		{
			set{ _oid=value;}
			get{return _oid;}
		}
		/// <summary>
		/// 考题ID
		/// </summary>
		public int EID
		{
			set{ _eid=value;}
			get{return _eid;}
		}
		/// <summary>
		/// 选项内容 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// ADL评分
		/// </summary>
		public int? Score
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 分组（1,2,3）
		/// </summary>
		public int OGroup
		{
			set{ _ogroup=value;}
			get{return _ogroup;}
		}
		/// <summary>
		/// 选项编号
		/// </summary>
		public int Number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 标签-对应护理标签（联想补充，培训、商业不对外发布）
		/// </summary>
		public string Label
		{
			set{ _label=value;}
			get{return _label;}
		}
		#endregion Model

	}
}

