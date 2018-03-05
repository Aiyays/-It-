using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 机构部门表
	/// </summary>
	[Serializable]
	public partial class Department
	{
		public Department()
		{}
		#region Model
		private int _did;
		private string _edepartmentname;
		private string _dnumber;
		/// <summary>
		/// 部门ID
		/// </summary>
		public int DID
		{
			set{ _did=value;}
			get{return _did;}
		}
		/// <summary>
		/// 部门名称
		/// </summary>
		public string EdepartmentName
		{
			set{ _edepartmentname=value;}
			get{return _edepartmentname;}
		}
		/// <summary>
		/// 部门编号
		/// </summary>
		public string DNumber
		{
			set{ _dnumber=value;}
			get{return _dnumber;}
		}
		#endregion Model

	}
}

