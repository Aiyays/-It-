using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:ScheduleCount
	/// </summary>
	public partial class ScheduleCount
	{
		public ScheduleCount()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SCID", "ScheduleCount"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SCID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ScheduleCount");
			strSql.Append(" where SCID=@SCID");
			SqlParameter[] parameters = {
					new SqlParameter("@SCID", SqlDbType.Int,4)
			};
			parameters[0].Value = SCID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.ScheduleCount model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ScheduleCount(");
			strSql.Append("Name,StartTime,EndTime)");
			strSql.Append(" values (");
			strSql.Append("@Name,@StartTime,@EndTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,255),
					new SqlParameter("@StartTime", SqlDbType.datetime2,8),
					new SqlParameter("@EndTime", SqlDbType.datetime2,8)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.StartTime;
			parameters[2].Value = model.EndTime;

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
		public bool Update(YCF_Server.Model.ScheduleCount model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ScheduleCount set ");
			strSql.Append("Name=@Name,");
			strSql.Append("StartTime=@StartTime,");
			strSql.Append("EndTime=@EndTime");
			strSql.Append(" where SCID=@SCID");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,255),
					new SqlParameter("@StartTime", SqlDbType.datetime2,8),
					new SqlParameter("@EndTime", SqlDbType.datetime2,8),
					new SqlParameter("@SCID", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.StartTime;
			parameters[2].Value = model.EndTime;
			parameters[3].Value = model.SCID;

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
		public bool Delete(int SCID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ScheduleCount ");
			strSql.Append(" where SCID=@SCID");
			SqlParameter[] parameters = {
					new SqlParameter("@SCID", SqlDbType.Int,4)
			};
			parameters[0].Value = SCID;

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
		public bool DeleteList(string SCIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ScheduleCount ");
			strSql.Append(" where SCID in ("+SCIDlist + ")  ");
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
		public YCF_Server.Model.ScheduleCount GetModel(int SCID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SCID,Name,StartTime,EndTime from ScheduleCount ");
			strSql.Append(" where SCID=@SCID");
			SqlParameter[] parameters = {
					new SqlParameter("@SCID", SqlDbType.Int,4)
			};
			parameters[0].Value = SCID;

			YCF_Server.Model.ScheduleCount model=new YCF_Server.Model.ScheduleCount();
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
		public YCF_Server.Model.ScheduleCount DataRowToModel(DataRow row)
		{
			YCF_Server.Model.ScheduleCount model=new YCF_Server.Model.ScheduleCount();
			if (row != null)
			{
				if(row["SCID"]!=null && row["SCID"].ToString()!="")
				{
					model.SCID=int.Parse(row["SCID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
					//model.StartTime=row["StartTime"].ToString();
					//model.EndTime=row["EndTime"].ToString();
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SCID,Name,StartTime,EndTime ");
			strSql.Append(" FROM ScheduleCount ");
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
			strSql.Append(" SCID,Name,StartTime,EndTime ");
			strSql.Append(" FROM ScheduleCount ");
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
			strSql.Append("select count(1) FROM ScheduleCount ");
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
				strSql.Append("order by T.SCID desc");
			}
			strSql.Append(")AS Row, T.*  from ScheduleCount T ");
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
			parameters[0].Value = "ScheduleCount";
			parameters[1].Value = "SCID";
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

