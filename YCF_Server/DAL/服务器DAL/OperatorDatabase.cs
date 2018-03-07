using  System;
using  System.Data;
using  System.Text;
using  System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:OperatorDatabase
	/// </summary>
	public partial class OperatorDatabase
	{
		public OperatorDatabase()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("DID", "OperatorDatabase"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OperatorDatabase");
			strSql.Append(" where DID=@DID");
			SqlParameter[] parameters = {
					new SqlParameter("@DID", SqlDbType.Int,4)
			};
			parameters[0].Value = DID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.OperatorDatabase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OperatorDatabase(");
			strSql.Append("OID,DataHost,DataPort,DataName,UserName,UserPassword)");
			strSql.Append(" values (");
			strSql.Append("@OID,@DataHost,@DataPort,@DataName,@UserName,@UserPassword)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OID", SqlDbType.Int,4),
					new SqlParameter("@DataHost", SqlDbType.NVarChar,50),
					new SqlParameter("@DataPort", SqlDbType.Int,4),
					new SqlParameter("@DataName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,255),
					new SqlParameter("@UserPassword", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.OID;
			parameters[1].Value = model.DataHost;
			parameters[2].Value = model.DataPort;
			parameters[3].Value = model.DataName;
			parameters[4].Value = model.UserName;
			parameters[5].Value = model.UserPassword;

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
		public bool Update(YCF_Server.Model.OperatorDatabase model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OperatorDatabase set ");
			strSql.Append("OID=@OID,");
			strSql.Append("DataHost=@DataHost,");
			strSql.Append("DataPort=@DataPort,");
			strSql.Append("DataName=@DataName,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("UserPassword=@UserPassword");
			strSql.Append(" where DID=@DID");
			SqlParameter[] parameters = {
					new SqlParameter("@OID", SqlDbType.Int,4),
					new SqlParameter("@DataHost", SqlDbType.NVarChar,50),
					new SqlParameter("@DataPort", SqlDbType.Int,4),
					new SqlParameter("@DataName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,255),
					new SqlParameter("@UserPassword", SqlDbType.NVarChar,255),
					new SqlParameter("@DID", SqlDbType.Int,4)};
			parameters[0].Value = model.OID;
			parameters[1].Value = model.DataHost;
			parameters[2].Value = model.DataPort;
			parameters[3].Value = model.DataName;
			parameters[4].Value = model.UserName;
			parameters[5].Value = model.UserPassword;
			parameters[6].Value = model.DID;

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
		public bool Delete(int DID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OperatorDatabase ");
			strSql.Append(" where DID=@DID");
			SqlParameter[] parameters = {
					new SqlParameter("@DID", SqlDbType.Int,4)
			};
			parameters[0].Value = DID;

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
		public bool DeleteList(string DIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OperatorDatabase ");
			strSql.Append(" where DID in ("+DIDlist + ")  ");
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
		public YCF_Server.Model.OperatorDatabase GetModel(int DID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DID,OID,DataHost,DataPort,DataName,UserName,UserPassword from OperatorDatabase ");
			strSql.Append(" where DID=@DID");
			SqlParameter[] parameters = {
					new SqlParameter("@DID", SqlDbType.Int,4)
			};
			parameters[0].Value = DID;

			YCF_Server.Model.OperatorDatabase model=new YCF_Server.Model.OperatorDatabase();
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
		public YCF_Server.Model.OperatorDatabase DataRowToModel(DataRow row)
		{
			YCF_Server.Model.OperatorDatabase model=new YCF_Server.Model.OperatorDatabase();
			if (row != null)
			{
				if(row["DID"]!=null && row["DID"].ToString()!="")
				{
					model.DID=int.Parse(row["DID"].ToString());
				}
				if(row["OID"]!=null && row["OID"].ToString()!="")
				{
					model.OID=int.Parse(row["OID"].ToString());
				}
				if(row["DataHost"]!=null)
				{
					model.DataHost=row["DataHost"].ToString();
				}
				if(row["DataPort"]!=null && row["DataPort"].ToString()!="")
				{
					model.DataPort=int.Parse(row["DataPort"].ToString());
				}
				if(row["DataName"]!=null)
				{
					model.DataName=row["DataName"].ToString();
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["UserPassword"]!=null)
				{
					model.UserPassword=row["UserPassword"].ToString();
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
			strSql.Append("select DID,OID,DataHost,DataPort,DataName,UserName,UserPassword ");
			strSql.Append(" FROM OperatorDatabase ");
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
			strSql.Append(" DID,OID,DataHost,DataPort,DataName,UserName,UserPassword ");
			strSql.Append(" FROM OperatorDatabase ");
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
			strSql.Append("select count(1) FROM OperatorDatabase ");
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
				strSql.Append("order by T.DID desc");
			}
			strSql.Append(")AS Row, T.*  from OperatorDatabase T ");
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
			parameters[0].Value = "OperatorDatabase";
			parameters[1].Value = "DID";
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

