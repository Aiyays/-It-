using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:LevelType
	/// </summary>
	public partial class LevelType
	{
		public LevelType()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("LTID", "LevelType"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LTID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from LevelType");
			strSql.Append(" where LTID=@LTID");
			SqlParameter[] parameters = {
					new SqlParameter("@LTID", SqlDbType.Int,4)
			};
			parameters[0].Value = LTID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.LevelType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into LevelType(");
			strSql.Append("LID,STID)");
			strSql.Append(" values (");
			strSql.Append("@LID,@STID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@LID", SqlDbType.Int,4),
					new SqlParameter("@STID", SqlDbType.Int,4)};
			parameters[0].Value = model.LID;
			parameters[1].Value = model.STID;

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
		public bool Update(YCF_Server.Model.LevelType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update LevelType set ");
			strSql.Append("LID=@LID,");
			strSql.Append("STID=@STID");
			strSql.Append(" where LTID=@LTID");
			SqlParameter[] parameters = {
					new SqlParameter("@LID", SqlDbType.Int,4),
					new SqlParameter("@STID", SqlDbType.Int,4),
					new SqlParameter("@LTID", SqlDbType.Int,4)};
			parameters[0].Value = model.LID;
			parameters[1].Value = model.STID;
			parameters[2].Value = model.LTID;

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
		public bool Delete(int LTID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LevelType ");
			strSql.Append(" where LTID=@LTID");
			SqlParameter[] parameters = {
					new SqlParameter("@LTID", SqlDbType.Int,4)
			};
			parameters[0].Value = LTID;

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
		public bool DeleteList(string LTIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LevelType ");
			strSql.Append(" where LTID in ("+LTIDlist + ")  ");
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
		public YCF_Server.Model.LevelType GetModel(int LTID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LTID,LID,STID from LevelType ");
			strSql.Append(" where LTID=@LTID");
			SqlParameter[] parameters = {
					new SqlParameter("@LTID", SqlDbType.Int,4)
			};
			parameters[0].Value = LTID;

			YCF_Server.Model.LevelType model=new YCF_Server.Model.LevelType();
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
		public YCF_Server.Model.LevelType DataRowToModel(DataRow row)
		{
			YCF_Server.Model.LevelType model=new YCF_Server.Model.LevelType();
			if (row != null)
			{
				if(row["LTID"]!=null && row["LTID"].ToString()!="")
				{
					model.LTID=int.Parse(row["LTID"].ToString());
				}
				if(row["LID"]!=null && row["LID"].ToString()!="")
				{
					model.LID=int.Parse(row["LID"].ToString());
				}
				if(row["STID"]!=null && row["STID"].ToString()!="")
				{
					model.STID=int.Parse(row["STID"].ToString());
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
			strSql.Append("select LTID,LID,STID ");
			strSql.Append(" FROM LevelType ");
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
			strSql.Append(" LTID,LID,STID ");
			strSql.Append(" FROM LevelType ");
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
			strSql.Append("select count(1) FROM LevelType ");
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
				strSql.Append("order by T.LTID desc");
			}
			strSql.Append(")AS Row, T.*  from LevelType T ");
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
			parameters[0].Value = "LevelType";
			parameters[1].Value = "LTID";
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

