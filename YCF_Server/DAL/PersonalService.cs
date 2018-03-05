﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:PersonalService
	/// </summary>
	public partial class PersonalService
	{
		public PersonalService()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PSID", "PersonalService"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PSID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PersonalService");
			strSql.Append(" where PSID=@PSID");
			SqlParameter[] parameters = {
					new SqlParameter("@PSID", SqlDbType.Int,4)
			};
			parameters[0].Value = PSID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.PersonalService model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PersonalService(");
			strSql.Append("PID,GID,SID,PTime)");
			strSql.Append(" values (");
			strSql.Append("@PID,@GID,@SID,@PTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.Int,4),
					new SqlParameter("@GID", SqlDbType.Int,4),
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@PTime", SqlDbType.DateTime)};
			parameters[0].Value = model.PID;
			parameters[1].Value = model.GID;
			parameters[2].Value = model.SID;
			parameters[3].Value = model.PTime;

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
		public bool Update(YCF_Server.Model.PersonalService model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PersonalService set ");
			strSql.Append("PID=@PID,");
			strSql.Append("GID=@GID,");
			strSql.Append("SID=@SID,");
			strSql.Append("PTime=@PTime");
			strSql.Append(" where PSID=@PSID");
			SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.Int,4),
					new SqlParameter("@GID", SqlDbType.Int,4),
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@PTime", SqlDbType.DateTime),
					new SqlParameter("@PSID", SqlDbType.Int,4)};
			parameters[0].Value = model.PID;
			parameters[1].Value = model.GID;
			parameters[2].Value = model.SID;
			parameters[3].Value = model.PTime;
			parameters[4].Value = model.PSID;

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
		public bool Delete(int PSID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PersonalService ");
			strSql.Append(" where PSID=@PSID");
			SqlParameter[] parameters = {
					new SqlParameter("@PSID", SqlDbType.Int,4)
			};
			parameters[0].Value = PSID;

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
		public bool DeleteList(string PSIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PersonalService ");
			strSql.Append(" where PSID in ("+PSIDlist + ")  ");
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
		public YCF_Server.Model.PersonalService GetModel(int PSID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PSID,PID,GID,SID,PTime from PersonalService ");
			strSql.Append(" where PSID=@PSID");
			SqlParameter[] parameters = {
					new SqlParameter("@PSID", SqlDbType.Int,4)
			};
			parameters[0].Value = PSID;

			YCF_Server.Model.PersonalService model=new YCF_Server.Model.PersonalService();
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
		public YCF_Server.Model.PersonalService DataRowToModel(DataRow row)
		{
			YCF_Server.Model.PersonalService model=new YCF_Server.Model.PersonalService();
			if (row != null)
			{
				if(row["PSID"]!=null && row["PSID"].ToString()!="")
				{
					model.PSID=int.Parse(row["PSID"].ToString());
				}
				if(row["PID"]!=null && row["PID"].ToString()!="")
				{
					model.PID=int.Parse(row["PID"].ToString());
				}
				if(row["GID"]!=null && row["GID"].ToString()!="")
				{
					model.GID=int.Parse(row["GID"].ToString());
				}
				if(row["SID"]!=null && row["SID"].ToString()!="")
				{
					model.SID=int.Parse(row["SID"].ToString());
				}
				if(row["PTime"]!=null && row["PTime"].ToString()!="")
				{
					model.PTime=DateTime.Parse(row["PTime"].ToString());
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
			strSql.Append("select PSID,PID,GID,SID,PTime ");
			strSql.Append(" FROM PersonalService ");
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
			strSql.Append(" PSID,PID,GID,SID,PTime ");
			strSql.Append(" FROM PersonalService ");
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
			strSql.Append("select count(1) FROM PersonalService ");
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
				strSql.Append("order by T.PSID desc");
			}
			strSql.Append(")AS Row, T.*  from PersonalService T ");
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
			parameters[0].Value = "PersonalService";
			parameters[1].Value = "PSID";
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
