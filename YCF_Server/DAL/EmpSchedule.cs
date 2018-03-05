using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:EmpSchedule
	/// </summary>
	public partial class EmpSchedule
	{
		public EmpSchedule()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ESID", "EmpSchedule"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ESID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from EmpSchedule");
			strSql.Append(" where ESID=@ESID");
			SqlParameter[] parameters = {
					new SqlParameter("@ESID", SqlDbType.Int,4)
			};
			parameters[0].Value = ESID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.EmpSchedule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into EmpSchedule(");
			strSql.Append("EID,SID,DataTime)");
			strSql.Append(" values (");
			strSql.Append("@EID,@SID,@DataTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@EID", SqlDbType.Int,4),
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@DataTime", SqlDbType.datetime2,8)};
			parameters[0].Value = model.EID;
			parameters[1].Value = model.SID;
			parameters[2].Value = model.DataTime;

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
		public bool Update(YCF_Server.Model.EmpSchedule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update EmpSchedule set ");
			strSql.Append("EID=@EID,");
			strSql.Append("SID=@SID,");
			strSql.Append("DataTime=@DataTime");
			strSql.Append(" where ESID=@ESID");
			SqlParameter[] parameters = {
					new SqlParameter("@EID", SqlDbType.Int,4),
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@DataTime", SqlDbType.datetime2,8),
					new SqlParameter("@ESID", SqlDbType.Int,4)};
			parameters[0].Value = model.EID;
			parameters[1].Value = model.SID;
			parameters[2].Value = model.DataTime;
			parameters[3].Value = model.ESID;

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
		public bool Delete(int ESID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from EmpSchedule ");
			strSql.Append(" where ESID=@ESID");
			SqlParameter[] parameters = {
					new SqlParameter("@ESID", SqlDbType.Int,4)
			};
			parameters[0].Value = ESID;

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
		public bool DeleteList(string ESIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from EmpSchedule ");
			strSql.Append(" where ESID in ("+ESIDlist + ")  ");
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
		public YCF_Server.Model.EmpSchedule GetModel(int ESID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ESID,EID,SID,DataTime from EmpSchedule ");
			strSql.Append(" where ESID=@ESID");
			SqlParameter[] parameters = {
					new SqlParameter("@ESID", SqlDbType.Int,4)
			};
			parameters[0].Value = ESID;

			YCF_Server.Model.EmpSchedule model=new YCF_Server.Model.EmpSchedule();
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
		public YCF_Server.Model.EmpSchedule DataRowToModel(DataRow row)
		{
			YCF_Server.Model.EmpSchedule model=new YCF_Server.Model.EmpSchedule();
			if (row != null)
			{
				if(row["ESID"]!=null && row["ESID"].ToString()!="")
				{
					model.ESID=int.Parse(row["ESID"].ToString());
				}
				if(row["EID"]!=null && row["EID"].ToString()!="")
				{
					model.EID=int.Parse(row["EID"].ToString());
				}
				if(row["SID"]!=null && row["SID"].ToString()!="")
				{
					model.SID=int.Parse(row["SID"].ToString());
				}
					//model.DataTime=row["DataTime"].ToString();
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ESID,EID,SID,DataTime ");
			strSql.Append(" FROM EmpSchedule ");
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
			strSql.Append(" ESID,EID,SID,DataTime ");
			strSql.Append(" FROM EmpSchedule ");
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
			strSql.Append("select count(1) FROM EmpSchedule ");
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
				strSql.Append("order by T.ESID desc");
			}
			strSql.Append(")AS Row, T.*  from EmpSchedule T ");
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
			parameters[0].Value = "EmpSchedule";
			parameters[1].Value = "ESID";
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

