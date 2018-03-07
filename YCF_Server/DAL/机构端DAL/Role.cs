using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:Role
	/// </summary>
	public partial class Role
	{
		public Role()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("RID", "Role"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Role");
			strSql.Append(" where RID=@RID");
			SqlParameter[] parameters = {
					new SqlParameter("@RID", SqlDbType.Int,4)
			};
			parameters[0].Value = RID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.Role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Role(");
			strSql.Append("RoleName,RNumber,DID)");
			strSql.Append(" values (");
			strSql.Append("@RoleName,@RNumber,@DID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.NVarChar,50),
					new SqlParameter("@RNumber", SqlDbType.NVarChar,20),
					new SqlParameter("@DID", SqlDbType.Int,4)};
			parameters[0].Value = model.RoleName;
			parameters[1].Value = model.RNumber;
			parameters[2].Value = model.DID;

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
		public bool Update(YCF_Server.Model.Role model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Role set ");
			strSql.Append("RoleName=@RoleName,");
			strSql.Append("RNumber=@RNumber,");
			strSql.Append("DID=@DID");
			strSql.Append(" where RID=@RID");
			SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.NVarChar,50),
					new SqlParameter("@RNumber", SqlDbType.NVarChar,20),
					new SqlParameter("@DID", SqlDbType.Int,4),
					new SqlParameter("@RID", SqlDbType.Int,4)};
			parameters[0].Value = model.RoleName;
			parameters[1].Value = model.RNumber;
			parameters[2].Value = model.DID;
			parameters[3].Value = model.RID;

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
		public bool Delete(int RID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Role ");
			strSql.Append(" where RID=@RID");
			SqlParameter[] parameters = {
					new SqlParameter("@RID", SqlDbType.Int,4)
			};
			parameters[0].Value = RID;

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
		public bool DeleteList(string RIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Role ");
			strSql.Append(" where RID in ("+RIDlist + ")  ");
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
		public YCF_Server.Model.Role GetModel(int RID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RID,RoleName,RNumber,DID from Role ");
			strSql.Append(" where RID=@RID");
			SqlParameter[] parameters = {
					new SqlParameter("@RID", SqlDbType.Int,4)
			};
			parameters[0].Value = RID;

			YCF_Server.Model.Role model=new YCF_Server.Model.Role();
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
		public YCF_Server.Model.Role DataRowToModel(DataRow row)
		{
			YCF_Server.Model.Role model=new YCF_Server.Model.Role();
			if (row != null)
			{
				if(row["RID"]!=null && row["RID"].ToString()!="")
				{
					model.RID=int.Parse(row["RID"].ToString());
				}
				if(row["RoleName"]!=null)
				{
					model.RoleName=row["RoleName"].ToString();
				}
				if(row["RNumber"]!=null)
				{
					model.RNumber=row["RNumber"].ToString();
				}
				if(row["DID"]!=null && row["DID"].ToString()!="")
				{
					model.DID=int.Parse(row["DID"].ToString());
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
			strSql.Append("select RID,RoleName,RNumber,DID ");
			strSql.Append(" FROM Role ");
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
			strSql.Append(" RID,RoleName,RNumber,DID ");
			strSql.Append(" FROM Role ");
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
			strSql.Append("select count(1) FROM Role ");
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
				strSql.Append("order by T.RID desc");
			}
			strSql.Append(")AS Row, T.*  from Role T ");
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
			parameters[0].Value = "Role";
			parameters[1].Value = "RID";
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

