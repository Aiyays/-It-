using  System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 机构人员证件表
	/// </summary>
	[Serializable]
	public partial class OLicense
	{
		public OLicense()
		{}
		#region Model
		private int _lid;
		private string _licensename;
		private string _licenseimg;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int LID
		{
			set{ _lid=value;}
			get{return _lid;}
		}
		/// <summary>
		/// 证照名称
		/// </summary>
		public string LicenseName
		{
			set{ _licensename=value;}
			get{return _licensename;}
		}
		/// <summary>
		/// 证照图像
		/// </summary>
		public string LicenseIMG
		{
			set{ _licenseimg=value;}
			get{return _licenseimg;}
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

