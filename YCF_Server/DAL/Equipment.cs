using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:Equipment
	/// </summary>
	public partial class Equipment
	{
		public Equipment()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("EID", "Equipment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int EID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Equipment");
			strSql.Append(" where EID=@EID");
			SqlParameter[] parameters = {
					new SqlParameter("@EID", SqlDbType.Int,4)
			};
			parameters[0].Value = EID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.Equipment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Equipment(");
			strSql.Append("SN,EName,ManufactureDate,ValidTime,Specification,Model,MaintenanceCycle,Price,Color,Count,TID,Remark)");
			strSql.Append(" values (");
			strSql.Append("@SN,@EName,@ManufactureDate,@ValidTime,@Specification,@Model,@MaintenanceCycle,@Price,@Color,@Count,@TID,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.NVarChar,50),
					new SqlParameter("@EName", SqlDbType.NVarChar,50),
					new SqlParameter("@ManufactureDate", SqlDbType.DateTime),
					new SqlParameter("@ValidTime", SqlDbType.DateTime),
					new SqlParameter("@Specification", SqlDbType.NVarChar,50),
					new SqlParameter("@Model", SqlDbType.NVarChar,50),
					new SqlParameter("@MaintenanceCycle", SqlDbType.NVarChar,50),
					new SqlParameter("@Price", SqlDbType.NVarChar,50),
					new SqlParameter("@Color", SqlDbType.NVarChar,50),
					new SqlParameter("@Count", SqlDbType.Int,4),
					new SqlParameter("@TID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.Text)};
			parameters[0].Value = model.SN;
			parameters[1].Value = model.EName;
			parameters[2].Value = model.ManufactureDate;
			parameters[3].Value = model.ValidTime;
			parameters[4].Value = model.Specification;
			parameters[5].Value = model.Model;
			parameters[6].Value = model.MaintenanceCycle;
			parameters[7].Value = model.Price;
			parameters[8].Value = model.Color;
			parameters[9].Value = model.Count;
			parameters[10].Value = model.TID;
			parameters[11].Value = model.Remark;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(YCF_Server.Model.Equipment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Equipment set ");
			strSql.Append("SN=@SN,");
			strSql.Append("EName=@EName,");
			strSql.Append("ManufactureDate=@ManufactureDate,");
			strSql.Append("ValidTime=@ValidTime,");
			strSql.Append("Specification=@Specification,");
			strSql.Append("Model=@Model,");
			strSql.Append("MaintenanceCycle=@MaintenanceCycle,");
			strSql.Append("Price=@Price,");
			strSql.Append("Color=@Color,");
			strSql.Append("Count=@Count,");
			strSql.Append("TID=@TID,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where EID=@EID");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.NVarChar,50),
					new SqlParameter("@EName", SqlDbType.NVarChar,50),
					new SqlParameter("@ManufactureDate", SqlDbType.DateTime),
					new SqlParameter("@ValidTime", SqlDbType.DateTime),
					new SqlParameter("@Specification", SqlDbType.NVarChar,50),
					new SqlParameter("@Model", SqlDbType.NVarChar,50),
					new SqlParameter("@MaintenanceCycle", SqlDbType.NVarChar,50),
					new SqlParameter("@Price", SqlDbType.NVarChar,50),
					new SqlParameter("@Color", SqlDbType.NVarChar,50),
					new SqlParameter("@Count", SqlDbType.Int,4),
					new SqlParameter("@TID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@EID", SqlDbType.Int,4)};
			parameters[0].Value = model.SN;
			parameters[1].Value = model.EName;
			parameters[2].Value = model.ManufactureDate;
			parameters[3].Value = model.ValidTime;
			parameters[4].Value = model.Specification;
			parameters[5].Value = model.Model;
			parameters[6].Value = model.MaintenanceCycle;
			parameters[7].Value = model.Price;
			parameters[8].Value = model.Color;
			parameters[9].Value = model.Count;
			parameters[10].Value = model.TID;
			parameters[11].Value = model.Remark;
			parameters[12].Value = model.EID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int EID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Equipment ");
			strSql.Append(" where EID=@EID");
			SqlParameter[] parameters = {
					new SqlParameter("@EID", SqlDbType.Int,4)
			};
			parameters[0].Value = EID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string EIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Equipment ");
			strSql.Append(" where EID in ("+EIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public YCF_Server.Model.Equipment GetModel(int EID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 EID,SN,EName,ManufactureDate,ValidTime,Specification,Model,MaintenanceCycle,Price,Color,Count,TID,Remark from Equipment ");
			strSql.Append(" where EID=@EID");
			SqlParameter[] parameters = {
					new SqlParameter("@EID", SqlDbType.Int,4)
			};
			parameters[0].Value = EID;

			YCF_Server.Model.Equipment model=new YCF_Server.Model.Equipment();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public YCF_Server.Model.Equipment DataRowToModel(DataRow row)
		{
			YCF_Server.Model.Equipment model=new YCF_Server.Model.Equipment();
			if (row != null)
			{
				if(row["EID"]!=null && row["EID"].ToString()!="")
				{
					model.EID=int.Parse(row["EID"].ToString());
				}
				if(row["SN"]!=null)
				{
					model.SN=row["SN"].ToString();
				}
				if(row["EName"]!=null)
				{
					model.EName=row["EName"].ToString();
				}
				if(row["ManufactureDate"]!=null && row["ManufactureDate"].ToString()!="")
				{
					model.ManufactureDate=DateTime.Parse(row["ManufactureDate"].ToString());
				}
				if(row["ValidTime"]!=null && row["ValidTime"].ToString()!="")
				{
					model.ValidTime=DateTime.Parse(row["ValidTime"].ToString());
				}
				if(row["Specification"]!=null)
				{
					model.Specification=row["Specification"].ToString();
				}
				if(row["Model"]!=null)
				{
					model.Model=row["Model"].ToString();
				}
				if(row["MaintenanceCycle"]!=null)
				{
					model.MaintenanceCycle=row["MaintenanceCycle"].ToString();
				}
				if(row["Price"]!=null)
				{
					model.Price=row["Price"].ToString();
				}
				if(row["Color"]!=null)
				{
					model.Color=row["Color"].ToString();
				}
				if(row["Count"]!=null && row["Count"].ToString()!="")
				{
					model.Count=int.Parse(row["Count"].ToString());
				}
				if(row["TID"]!=null && row["TID"].ToString()!="")
				{
					model.TID=int.Parse(row["TID"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select EID,SN,EName,ManufactureDate,ValidTime,Specification,Model,MaintenanceCycle,Price,Color,Count,TID,Remark ");
			strSql.Append(" FROM Equipment ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" EID,SN,EName,ManufactureDate,ValidTime,Specification,Model,MaintenanceCycle,Price,Color,Count,TID,Remark ");
			strSql.Append(" FROM Equipment ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Equipment ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.EID desc");
			}
			strSql.Append(")AS Row, T.*  from Equipment T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Equipment";
			parameters[1].Value = "EID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

