using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 护理等级评估表
	/// </summary>
	[Serializable]
	public partial class AssessRecord
	{
		public AssessRecord()
		{}
		#region Model
		private int _aid;
		private string _uname;
		private int _sex;
		private string _fn;
		private DateTime? _birthdate;
		private string _thebed;
		private DateTime _valuationdate;
		private string _evaluator;
		private string _registrar;
		private DateTime? _recorddata;
		private int? _badl;
		private int? _ladl;
		private int? _lsp;
		private string _sysevaluation;
		private string _assessment;
		private int _uid;
		private string _comment;
		/// <summary>
		/// 主键ID 自增
		/// </summary>
		public int AID
		{
			set{ _aid=value;}
			get{return _aid;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string UName
		{
			set{ _uname=value;}
			get{return _uname;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public int Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 档案号
		/// </summary>
		public string FN
		{
			set{ _fn=value;}
			get{return _fn;}
		}
		/// <summary>
		/// 生日
		/// </summary>
		public DateTime? BirthDate
		{
			set{ _birthdate=value;}
			get{return _birthdate;}
		}
		/// <summary>
		/// 病床号
		/// </summary>
		public string TheBed
		{
			set{ _thebed=value;}
			get{return _thebed;}
		}
		/// <summary>
		/// 评估日期
		/// </summary>
		public DateTime ValuationDate
		{
			set{ _valuationdate=value;}
			get{return _valuationdate;}
		}
		/// <summary>
		/// 评估员
		/// </summary>
		public string Evaluator
		{
			set{ _evaluator=value;}
			get{return _evaluator;}
		}
		/// <summary>
		/// 登记员
		/// </summary>
		public string Registrar
		{
			set{ _registrar=value;}
			get{return _registrar;}
		}
		/// <summary>
		/// 登记日期
		/// </summary>
		public DateTime? RecordData
		{
			set{ _recorddata=value;}
			get{return _recorddata;}
		}
		/// <summary>
		/// BADL指数
		/// </summary>
		public int? BADL
		{
			set{ _badl=value;}
			get{return _badl;}
		}
		/// <summary>
		/// LADL指数
		/// </summary>
		public int? LADL
		{
			set{ _ladl=value;}
			get{return _ladl;}
		}
		/// <summary>
		/// LSP指数
		/// </summary>
		public int? LSP
		{
			set{ _lsp=value;}
			get{return _lsp;}
		}
		/// <summary>
		/// 系统评估
		/// </summary>
		public string SysEvaluation
		{
			set{ _sysevaluation=value;}
			get{return _sysevaluation;}
		}
		/// <summary>
		/// 综合评估（评估人员进行评估）
		/// </summary>
		public string Assessment
		{
			set{ _assessment=value;}
			get{return _assessment;}
		}
		/// <summary>
		/// 用户ID（被评估人员ID）-外键
		/// </summary>
		public int UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 护理等级分配备注
		/// </summary>
		public string Comment
		{
			set{ _comment=value;}
			get{return _comment;}
		}
		#endregion Model

	}
}

