﻿using  System;
using  System.Data;
using  System.Text;
using  System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:User_Operator
	/// </summary>
	public partial class User_Operator
	{
		public User_Operator()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("UOID", "User_Operator"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UOID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from User_Operator");
			strSql.Append(" where UOID=@UOID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UOID", SqlDbType.Int,4)			};
			parameters[0].Value = UOID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(YCF_Server.Model.User_Operator model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into User_Operator(");
			strSql.Append("UOID,UID,OID,ISHospitalization)");
			strSql.Append(" values (");
			strSql.Append("@UOID,@UID,@OID,@ISHospitalization)");
			SqlParameter[] parameters = {
					new SqlParameter("@UOID", SqlDbType.Int,4),
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@OID", SqlDbType.Int,4),
					new SqlParameter("@ISHospitalization", SqlDbType.Int,4)};
			parameters[0].Value = model.UOID;
			parameters[1].Value = model.UID;
			parameters[2].Value = model.OID;
			parameters[3].Value = model.ISHospitalization;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(YCF_Server.Model.User_Operator model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update User_Operator set ");
			strSql.Append("UID=@UID,");
			strSql.Append("OID=@OID,");
			strSql.Append("ISHospitalization=@ISHospitalization");
			strSql.Append(" where UOID=@UOID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@OID", SqlDbType.Int,4),
					new SqlParameter("@ISHospitalization", SqlDbType.Int,4),
					new SqlParameter("@UOID", SqlDbType.Int,4)};
			parameters[0].Value = model.UID;
			parameters[1].Value = model.OID;
			parameters[2].Value = model.ISHospitalization;
			parameters[3].Value = model.UOID;

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
		public bool Delete(int UOID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_Operator ");
			strSql.Append(" where UOID=@UOID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UOID", SqlDbType.Int,4)			};
			parameters[0].Value = UOID;

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
		public bool DeleteList(string UOIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_Operator ");
			strSql.Append(" where UOID in ("+UOIDlist + ")  ");
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
		public YCF_Server.Model.User_Operator GetModel(int UOID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UOID,UID,OID,ISHospitalization from User_Operator ");
			strSql.Append(" where UOID=@UOID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UOID", SqlDbType.Int,4)			};
			parameters[0].Value = UOID;

			YCF_Server.Model.User_Operator model=new YCF_Server.Model.User_Operator();
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
		public YCF_Server.Model.User_Operator DataRowToModel(DataRow row)
		{
			YCF_Server.Model.User_Operator model=new YCF_Server.Model.User_Operator();
			if (row != null)
			{
				if(row["UOID"]!=null && row["UOID"].ToString()!="")
				{
					model.UOID=int.Parse(row["UOID"].ToString());
				}
				if(row["UID"]!=null && row["UID"].ToString()!="")
				{
					model.UID=int.Parse(row["UID"].ToString());
				}
				if(row["OID"]!=null && row["OID"].ToString()!="")
				{
					model.OID=int.Parse(row["OID"].ToString());
				}
				if(row["ISHospitalization"]!=null && row["ISHospitalization"].ToString()!="")
				{
					model.ISHospitalization=int.Parse(row["ISHospitalization"].ToString());
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
			strSql.Append("select UOID,UID,OID,ISHospitalization ");
			strSql.Append(" FROM User_Operator ");
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
			strSql.Append(" UOID,UID,OID,ISHospitalization ");
			strSql.Append(" FROM User_Operator ");
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
			strSql.Append("select count(1) FROM User_Operator ");
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
				strSql.Append("order by T.UOID desc");
			}
			strSql.Append(")AS Row, T.*  from User_Operator T ");
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
			parameters[0].Value = "User_Operator";
			parameters[1].Value = "UOID";
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

