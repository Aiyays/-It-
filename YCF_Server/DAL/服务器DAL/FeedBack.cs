using  System;
using  System.Data;
using  System.Text;
using  System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:FeedBack
	/// </summary>
	public partial class FeedBack
	{
		public FeedBack()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("FID", "FeedBack"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FeedBack");
			strSql.Append(" where FID=@FID");
			SqlParameter[] parameters = {
					new SqlParameter("@FID", SqlDbType.Int,4)
			};
			parameters[0].Value = FID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.FeedBack model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FeedBack(");
			strSql.Append("FBDate,FBContent,FBsource,FBobject,UID,OID)");
			strSql.Append(" values (");
			strSql.Append("@FBDate,@FBContent,@FBsource,@FBobject,@UID,@OID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FBDate", SqlDbType.DateTime),
					new SqlParameter("@FBContent", SqlDbType.Text),
					new SqlParameter("@FBsource", SqlDbType.Int,4),
					new SqlParameter("@FBobject", SqlDbType.Int,4),
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@OID", SqlDbType.Int,4)};
			parameters[0].Value = model.FBDate;
			parameters[1].Value = model.FBContent;
			parameters[2].Value = model.FBsource;
			parameters[3].Value = model.FBobject;
			parameters[4].Value = model.UID;
			parameters[5].Value = model.OID;

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
		public bool Update(YCF_Server.Model.FeedBack model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FeedBack set ");
			strSql.Append("FBDate=@FBDate,");
			strSql.Append("FBContent=@FBContent,");
			strSql.Append("FBsource=@FBsource,");
			strSql.Append("FBobject=@FBobject,");
			strSql.Append("UID=@UID,");
			strSql.Append("OID=@OID");
			strSql.Append(" where FID=@FID");
			SqlParameter[] parameters = {
					new SqlParameter("@FBDate", SqlDbType.DateTime),
					new SqlParameter("@FBContent", SqlDbType.Text),
					new SqlParameter("@FBsource", SqlDbType.Int,4),
					new SqlParameter("@FBobject", SqlDbType.Int,4),
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@OID", SqlDbType.Int,4),
					new SqlParameter("@FID", SqlDbType.Int,4)};
			parameters[0].Value = model.FBDate;
			parameters[1].Value = model.FBContent;
			parameters[2].Value = model.FBsource;
			parameters[3].Value = model.FBobject;
			parameters[4].Value = model.UID;
			parameters[5].Value = model.OID;
			parameters[6].Value = model.FID;

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
		public bool Delete(int FID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FeedBack ");
			strSql.Append(" where FID=@FID");
			SqlParameter[] parameters = {
					new SqlParameter("@FID", SqlDbType.Int,4)
			};
			parameters[0].Value = FID;

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
		public bool DeleteList(string FIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FeedBack ");
			strSql.Append(" where FID in ("+FIDlist + ")  ");
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
		public YCF_Server.Model.FeedBack GetModel(int FID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FID,FBDate,FBContent,FBsource,FBobject,UID,OID from FeedBack ");
			strSql.Append(" where FID=@FID");
			SqlParameter[] parameters = {
					new SqlParameter("@FID", SqlDbType.Int,4)
			};
			parameters[0].Value = FID;

			YCF_Server.Model.FeedBack model=new YCF_Server.Model.FeedBack();
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
		public YCF_Server.Model.FeedBack DataRowToModel(DataRow row)
		{
			YCF_Server.Model.FeedBack model=new YCF_Server.Model.FeedBack();
			if (row != null)
			{
				if(row["FID"]!=null && row["FID"].ToString()!="")
				{
					model.FID=int.Parse(row["FID"].ToString());
				}
				if(row["FBDate"]!=null && row["FBDate"].ToString()!="")
				{
					model.FBDate=DateTime.Parse(row["FBDate"].ToString());
				}
				if(row["FBContent"]!=null)
				{
					model.FBContent=row["FBContent"].ToString();
				}
				if(row["FBsource"]!=null && row["FBsource"].ToString()!="")
				{
					model.FBsource=int.Parse(row["FBsource"].ToString());
				}
				if(row["FBobject"]!=null && row["FBobject"].ToString()!="")
				{
					model.FBobject=int.Parse(row["FBobject"].ToString());
				}
				if(row["UID"]!=null && row["UID"].ToString()!="")
				{
					model.UID=int.Parse(row["UID"].ToString());
				}
				if(row["OID"]!=null && row["OID"].ToString()!="")
				{
					model.OID=int.Parse(row["OID"].ToString());
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
			strSql.Append("select FID,FBDate,FBContent,FBsource,FBobject,UID,OID ");
			strSql.Append(" FROM FeedBack ");
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
			strSql.Append(" FID,FBDate,FBContent,FBsource,FBobject,UID,OID ");
			strSql.Append(" FROM FeedBack ");
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
			strSql.Append("select count(1) FROM FeedBack ");
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
				strSql.Append("order by T.FID desc");
			}
			strSql.Append(")AS Row, T.*  from FeedBack T ");
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
			parameters[0].Value = "FeedBack";
			parameters[1].Value = "FID";
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

