using System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 考题表（BADL、IADL、LSP）单选和多选考题
	/// </summary>
	[Serializable]
	public partial class Food
	{
		public Food()
		{}
		#region Model
		private int _fid;
		private string _name;
		private string _price;
		private string _unit;
		private int? _quantity;
		private int _tid;
		/// <summary>
		/// 
		/// </summary>
		public int FID
		{
			set{ _fid=value;}
			get{return _fid;}
		}
		/// <summary>
		/// 菜品名称
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
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
		/// 单位
		/// </summary>
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 数量
		/// </summary>
		public int? Quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// 外键-菜品类型
		/// </summary>
		public int TID
		{
			set{ _tid=value;}
			get{return _tid;}
		}
		#endregion Model

	}
}

