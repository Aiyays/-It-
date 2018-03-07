using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:UserFunctionModule
	/// </summary>
	public partial class UserFunctionModule
	{
		public UserFunctionModule()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MID", "UserFunctionModule"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserFunctionModule");
			strSql.Append(" where MID=@MID");
			SqlParameter[] parameters = {
					new SqlParameter("@MID", SqlDbType.Int,4)
			};
			parameters[0].Value = MID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.UserFunctionModule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserFunctionModule(");
			strSql.Append("F_ID,Remarks,Name)");
			strSql.Append(" values (");
			strSql.Append("@F_ID,@Remarks,@Name)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.F_ID;
			parameters[1].Value = model.Remarks;
			parameters[2].Value = model.Name;

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
		public bool Update(YCF_Server.Model.UserFunctionModule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserFunctionModule set ");
			strSql.Append("F_ID=@F_ID,");
			strSql.Append("Remarks=@Remarks,");
			strSql.Append("Name=@Name");
			strSql.Append(" where MID=@MID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@MID", SqlDbType.Int,4)};
			parameters[0].Value = model.F_ID;
			parameters[1].Value = model.Remarks;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.MID;

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
		public bool Delete(int MID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserFunctionModule ");
			strSql.Append(" where MID=@MID");
			SqlParameter[] parameters = {
					new SqlParameter("@MID", SqlDbType.Int,4)
			};
			parameters[0].Value = MID;

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
		public bool DeleteList(string MIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserFunctionModule ");
			strSql.Append(" where MID in ("+MIDlist + ")  ");
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
		public YCF_Server.Model.UserFunctionModule GetModel(int MID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MID,F_ID,Remarks,Name from UserFunctionModule ");
			strSql.Append(" where MID=@MID");
			SqlParameter[] parameters = {
					new SqlParameter("@MID", SqlDbType.Int,4)
			};
			parameters[0].Value = MID;

			YCF_Server.Model.UserFunctionModule model=new YCF_Server.Model.UserFunctionModule();
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
		public YCF_Server.Model.UserFunctionModule DataRowToModel(DataRow row)
		{
			YCF_Server.Model.UserFunctionModule model=new YCF_Server.Model.UserFunctionModule();
			if (row != null)
			{
				if(row["MID"]!=null && row["MID"].ToString()!="")
				{
					model.MID=int.Parse(row["MID"].ToString());
				}
				if(row["F_ID"]!=null && row["F_ID"].ToString()!="")
				{
					model.F_ID=int.Parse(row["F_ID"].ToString());
				}
				if(row["Remarks"]!=null)
				{
					model.Remarks=row["Remarks"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
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
			strSql.Append("select MID,F_ID,Remarks,Name ");
			strSql.Append(" FROM UserFunctionModule ");
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
			strSql.Append(" MID,F_ID,Remarks,Name ");
			strSql.Append(" FROM UserFunctionModule ");
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
			strSql.Append("select count(1) FROM UserFunctionModule ");
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
				strSql.Append("order by T.MID desc");
			}
			strSql.Append(")AS Row, T.*  from UserFunctionModule T ");
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
			parameters[0].Value = "UserFunctionModule";
			parameters[1].Value = "MID";
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

