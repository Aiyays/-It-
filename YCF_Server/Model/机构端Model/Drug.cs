using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 药品
	/// </summary>
	[Serializable]
	public partial class Drug
	{
		public Drug()
		{}
		#region Model
		private int _did;
		private string _drugname;
		private int _dlevel;
		private DateTime _manufacturedate;
		private DateTime _validtime;
		private string _price;
		private string _specification;
		private string _drugsource;
		private DateTime? _indate;
		private string _storagetempera;
		private string _manufacturers;
		private string _brand;
		private string _drugimg;
		private int _tid;
		/// <summary>
		/// 
		/// </summary>
		public int DID
		{
			set{ _did=value;}
			get{return _did;}
		}
		/// <summary>
		/// 药品名称
		/// </summary>
		public string DrugName
		{
			set{ _drugname=value;}
			get{return _drugname;}
		}
		/// <summary>
		/// 药品级别
		/// </summary>
		public int Dlevel
		{
			set{ _dlevel=value;}
			get{return _dlevel;}
		}
		/// <summary>
		/// 生产日期
		/// </summary>
		public DateTime ManufactureDate
		{
			set{ _manufacturedate=value;}
			get{return _manufacturedate;}
		}
		/// <summary>
		/// 有效日期
		/// </summary>
		public DateTime ValidTime
		{
			set{ _validtime=value;}
			get{return _validtime;}
		}
		/// <summary>
		/// 价格
		/// </summary>
		public string Price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 规格
		/// </summary>
		public string Specification
		{
			set{ _specification=value;}
			get{return _specification;}
		}
		/// <summary>
		/// 来源
		/// </summary>
		public string DrugSource
		{
			set{ _drugsource=value;}
			get{return _drugsource;}
		}
		/// <summary>
		/// 入库时间
		/// </summary>
		public DateTime? InDate
		{
			set{ _indate=value;}
			get{return _indate;}
		}
		/// <summary>
		/// 存储温度
		/// </summary>
		public string Storagetempera
		{
			set{ _storagetempera=value;}
			get{return _storagetempera;}
		}
		/// <summary>
		/// 厂家
		/// </summary>
		public string Manufacturers
		{
			set{ _manufacturers=value;}
			get{return _manufacturers;}
		}
		/// <summary>
		/// 品牌
		/// </summary>
		public string Brand
		{
			set{ _brand=value;}
			get{return _brand;}
		}
		/// <summary>
		/// 图片
		/// </summary>
		public string DrugIMG
		{
			set{ _drugimg=value;}
			get{return _drugimg;}
		}
		/// <summary>
		/// 外键-药品类型
		/// </summary>
		public int TID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		#endregion Model

	}
}

