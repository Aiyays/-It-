using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:Service
	/// </summary>
	public partial class Service
	{
		public Service()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SID", "Service"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Service");
			strSql.Append(" where SID=@SID");
			SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4)
			};
			parameters[0].Value = SID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.Service model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Service(");
			strSql.Append("SName,StartTime,EndTime,Frequency,Magnitude,Standard,STID)");
			strSql.Append(" values (");
			strSql.Append("@SName,@StartTime,@EndTime,@Frequency,@Magnitude,@Standard,@STID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SName", SqlDbType.NVarChar,50),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@Frequency", SqlDbType.Int,4),
					new SqlParameter("@Magnitude", SqlDbType.Int,4),
					new SqlParameter("@Standard", SqlDbType.NVarChar,50),
					new SqlParameter("@STID", SqlDbType.Int,4)};
			parameters[0].Value = model.SName;
			parameters[1].Value = model.StartTime;
			parameters[2].Value = model.EndTime;
			parameters[3].Value = model.Frequency;
			parameters[4].Value = model.Magnitude;
			parameters[5].Value = model.Standard;
			parameters[6].Value = model.STID;

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
		public bool Update(YCF_Server.Model.Service model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Service set ");
			strSql.Append("SName=@SName,");
			strSql.Append("StartTime=@StartTime,");
			strSql.Append("EndTime=@EndTime,");
			strSql.Append("Frequency=@Frequency,");
			strSql.Append("Magnitude=@Magnitude,");
			strSql.Append("Standard=@Standard,");
			strSql.Append("STID=@STID");
			strSql.Append(" where SID=@SID");
			SqlParameter[] parameters = {
					new SqlParameter("@SName", SqlDbType.NVarChar,50),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@Frequency", SqlDbType.Int,4),
					new SqlParameter("@Magnitude", SqlDbType.Int,4),
					new SqlParameter("@Standard", SqlDbType.NVarChar,50),
					new SqlParameter("@STID", SqlDbType.Int,4),
					new SqlParameter("@SID", SqlDbType.Int,4)};
			parameters[0].Value = model.SName;
			parameters[1].Value = model.StartTime;
			parameters[2].Value = model.EndTime;
			parameters[3].Value = model.Frequency;
			parameters[4].Value = model.Magnitude;
			parameters[5].Value = model.Standard;
			parameters[6].Value = model.STID;
			parameters[7].Value = model.SID;

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
		public bool Delete(int SID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Service ");
			strSql.Append(" where SID=@SID");
			SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4)
			};
			parameters[0].Value = SID;

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
		public bool DeleteList(string SIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Service ");
			strSql.Append(" where SID in ("+SIDlist + ")  ");
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
		public YCF_Server.Model.Service GetModel(int SID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SID,SName,StartTime,EndTime,Frequency,Magnitude,Standard,STID from Service ");
			strSql.Append(" where SID=@SID");
			SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4)
			};
			parameters[0].Value = SID;

			YCF_Server.Model.Service model=new YCF_Server.Model.Service();
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
		public YCF_Server.Model.Service DataRowToModel(DataRow row)
		{
			YCF_Server.Model.Service model=new YCF_Server.Model.Service();
			if (row != null)
			{
				if(row["SID"]!=null && row["SID"].ToString()!="")
				{
					model.SID=int.Parse(row["SID"].ToString());
				}
				if(row["SName"]!=null)
				{
					model.SName=row["SName"].ToString();
				}
				if(row["StartTime"]!=null && row["StartTime"].ToString()!="")
				{
					model.StartTime=DateTime.Parse(row["StartTime"].ToString());
				}
				if(row["EndTime"]!=null && row["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(row["EndTime"].ToString());
				}
				if(row["Frequency"]!=null && row["Frequency"].ToString()!="")
				{
					model.Frequency=int.Parse(row["Frequency"].ToString());
				}
				if(row["Magnitude"]!=null && row["Magnitude"].ToString()!="")
				{
					model.Magnitude=int.Parse(row["Magnitude"].ToString());
				}
				if(row["Standard"]!=null)
				{
					model.Standard=row["Standard"].ToString();
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
			strSql.Append("select SID,SName,StartTime,EndTime,Frequency,Magnitude,Standard,STID ");
			strSql.Append(" FROM Service ");
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
			strSql.Append(" SID,SName,StartTime,EndTime,Frequency,Magnitude,Standard,STID ");
			strSql.Append(" FROM Service ");
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
			strSql.Append("select count(1) FROM Service ");
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
				strSql.Append("order by T.SID desc");
			}
			strSql.Append(")AS Row, T.*  from Service T ");
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
			parameters[0].Value = "Service";
			parameters[1].Value = "SID";
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

