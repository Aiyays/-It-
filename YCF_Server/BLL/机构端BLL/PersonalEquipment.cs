﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using YCF_Server.Model;
namespace YCF_Server.BLL
{
	/// <summary>
	/// 个人设备
	/// </summary>
	public partial class PersonalEquipment
	{
		private readonly YCF_Server.DAL.PersonalEquipment dal=new YCF_Server.DAL.PersonalEquipment();
		public PersonalEquipment()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PEID)
		{
			return dal.Exists(PEID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(YCF_Server.Model.PersonalEquipment model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(YCF_Server.Model.PersonalEquipment model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int PEID)
		{
			
			return dal.Delete(PEID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string PEIDlist )
		{
			return dal.DeleteList(PEIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public YCF_Server.Model.PersonalEquipment GetModel(int PEID)
		{
			
			return dal.GetModel(PEID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public YCF_Server.Model.PersonalEquipment GetModelByCache(int PEID)
		{
			
			string CacheKey = "PersonalEquipmentModel-" + PEID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PEID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (YCF_Server.Model.PersonalEquipment)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<YCF_Server.Model.PersonalEquipment> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<YCF_Server.Model.PersonalEquipment> DataTableToList(DataTable dt)
		{
			List<YCF_Server.Model.PersonalEquipment> modelList = new List<YCF_Server.Model.PersonalEquipment>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				YCF_Server.Model.PersonalEquipment model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

