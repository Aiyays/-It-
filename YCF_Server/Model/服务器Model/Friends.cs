using  System;
namespace YCF_Server.Model
{
	/// <summary>
	/// 好友表
	/// </summary>
	[Serializable]
	public partial class Friends
	{
		public Friends()
		{}
		#region Model
		private int _id;
		private int _id_key;
		private int _id_value;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 外键UID
		/// </summary>
		public int ID_Key
		{
			set{ _id_key=value;}
			get{return _id_key;}
		}
		/// <summary>
		/// 外键UID
		/// </summary>
		public int ID_Value
		{
			set{ _id_value=value;}
			get{return _id_value;}
		}
		#endregion Model

	}
}

