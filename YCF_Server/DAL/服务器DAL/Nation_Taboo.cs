using  System;
using  System.Data;
using  System.Text;
using  System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:Nation_Taboo
	/// </summary>
	public partial class Nation_Taboo
	{
		public Nation_Taboo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("NTID", "Nation_Taboo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int NTID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Nation_Taboo");
			strSql.Append(" where NTID=@NTID");
			SqlParameter[] parameters = {
					new SqlParameter("@NTID", SqlDbType.Int,4)
			};
			parameters[0].Value = NTID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.Nation_Taboo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Nation_Taboo(");
			strSql.Append("NID,TID)");
			strSql.Append(" values (");
			strSql.Append("@NID,@TID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@NID", SqlDbType.Int,4),
					new SqlParameter("@TID", SqlDbType.Int,4)};
			parameters[0].Value = model.NID;
			parameters[1].Value = model.TID;

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
		public bool Update(YCF_Server.Model.Nation_Taboo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Nation_Taboo set ");
			strSql.Append("NID=@NID,");
			strSql.Append("TID=@TID");
			strSql.Append(" where NTID=@NTID");
			SqlParameter[] parameters = {
					new SqlParameter("@NID", SqlDbType.Int,4),
					new SqlParameter("@TID", SqlDbType.Int,4),
					new SqlParameter("@NTID", SqlDbType.Int,4)};
			parameters[0].Value = model.NID;
			parameters[1].Value = model.TID;
			parameters[2].Value = model.NTID;

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
		public bool Delete(int NTID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Nation_Taboo ");
			strSql.Append(" where NTID=@NTID");
			SqlParameter[] parameters = {
					new SqlParameter("@NTID", SqlDbType.Int,4)
			};
			parameters[0].Value = NTID;

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
		public bool DeleteList(string NTIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Nation_Taboo ");
			strSql.Append(" where NTID in ("+NTIDlist + ")  ");
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
		public YCF_Server.Model.Nation_Taboo GetModel(int NTID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 NTID,NID,TID from Nation_Taboo ");
			strSql.Append(" where NTID=@NTID");
			SqlParameter[] parameters = {
					new SqlParameter("@NTID", SqlDbType.Int,4)
			};
			parameters[0].Value = NTID;

			YCF_Server.Model.Nation_Taboo model=new YCF_Server.Model.Nation_Taboo();
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
		public YCF_Server.Model.Nation_Taboo DataRowToModel(DataRow row)
		{
			YCF_Server.Model.Nation_Taboo model=new YCF_Server.Model.Nation_Taboo();
			if (row != null)
			{
				if(row["NTID"]!=null && row["NTID"].ToString()!="")
				{
					model.NTID=int.Parse(row["NTID"].ToString());
				}
				if(row["NID"]!=null && row["NID"].ToString()!="")
				{
					model.NID=int.Parse(row["NID"].ToString());
				}
				if(row["TID"]!=null && row["TID"].ToString()!="")
				{
					model.TID=int.Parse(row["TID"].ToString());
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
			strSql.Append("select NTID,NID,TID ");
			strSql.Append(" FROM Nation_Taboo ");
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
			strSql.Append(" NTID,NID,TID ");
			strSql.Append(" FROM Nation_Taboo ");
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
			strSql.Append("select count(1) FROM Nation_Taboo ");
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
				strSql.Append("order by T.NTID desc");
			}
			strSql.Append(")AS Row, T.*  from Nation_Taboo T ");
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
			parameters[0].Value = "Nation_Taboo";
			parameters[1].Value = "NTID";
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

