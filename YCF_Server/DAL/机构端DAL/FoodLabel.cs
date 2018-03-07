using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:FoodLabel
	/// </summary>
	public partial class FoodLabel
	{
		public FoodLabel()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("FLID", "FoodLabel"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FLID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FoodLabel");
			strSql.Append(" where FLID=@FLID");
			SqlParameter[] parameters = {
					new SqlParameter("@FLID", SqlDbType.Int,4)
			};
			parameters[0].Value = FLID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.FoodLabel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FoodLabel(");
			strSql.Append("FID,LID)");
			strSql.Append(" values (");
			strSql.Append("@FID,@LID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FID", SqlDbType.Int,4),
					new SqlParameter("@LID", SqlDbType.Int,4)};
			parameters[0].Value = model.FID;
			parameters[1].Value = model.LID;

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
		public bool Update(YCF_Server.Model.FoodLabel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FoodLabel set ");
			strSql.Append("FID=@FID,");
			strSql.Append("LID=@LID");
			strSql.Append(" where FLID=@FLID");
			SqlParameter[] parameters = {
					new SqlParameter("@FID", SqlDbType.Int,4),
					new SqlParameter("@LID", SqlDbType.Int,4),
					new SqlParameter("@FLID", SqlDbType.Int,4)};
			parameters[0].Value = model.FID;
			parameters[1].Value = model.LID;
			parameters[2].Value = model.FLID;

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
		public bool Delete(int FLID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FoodLabel ");
			strSql.Append(" where FLID=@FLID");
			SqlParameter[] parameters = {
					new SqlParameter("@FLID", SqlDbType.Int,4)
			};
			parameters[0].Value = FLID;

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
		public bool DeleteList(string FLIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FoodLabel ");
			strSql.Append(" where FLID in ("+FLIDlist + ")  ");
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
		public YCF_Server.Model.FoodLabel GetModel(int FLID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FLID,FID,LID from FoodLabel ");
			strSql.Append(" where FLID=@FLID");
			SqlParameter[] parameters = {
					new SqlParameter("@FLID", SqlDbType.Int,4)
			};
			parameters[0].Value = FLID;

			YCF_Server.Model.FoodLabel model=new YCF_Server.Model.FoodLabel();
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
		public YCF_Server.Model.FoodLabel DataRowToModel(DataRow row)
		{
			YCF_Server.Model.FoodLabel model=new YCF_Server.Model.FoodLabel();
			if (row != null)
			{
				if(row["FLID"]!=null && row["FLID"].ToString()!="")
				{
					model.FLID=int.Parse(row["FLID"].ToString());
				}
				if(row["FID"]!=null && row["FID"].ToString()!="")
				{
					model.FID=int.Parse(row["FID"].ToString());
				}
				if(row["LID"]!=null && row["LID"].ToString()!="")
				{
					model.LID=int.Parse(row["LID"].ToString());
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
			strSql.Append("select FLID,FID,LID ");
			strSql.Append(" FROM FoodLabel ");
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
			strSql.Append(" FLID,FID,LID ");
			strSql.Append(" FROM FoodLabel ");
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
			strSql.Append("select count(1) FROM FoodLabel ");
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
				strSql.Append("order by T.FLID desc");
			}
			strSql.Append(")AS Row, T.*  from FoodLabel T ");
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
			parameters[0].Value = "FoodLabel";
			parameters[1].Value = "FLID";
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

