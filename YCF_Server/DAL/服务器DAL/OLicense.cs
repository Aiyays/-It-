﻿using  System;
using  System.Data;
using  System.Text;
using  System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:OLicense
	/// </summary>
	public partial class OLicense
	{
		public OLicense()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("LID", "OLicense"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OLicense");
			strSql.Append(" where LID=@LID");
			SqlParameter[] parameters = {
					new SqlParameter("@LID", SqlDbType.Int,4)
			};
			parameters[0].Value = LID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.OLicense model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OLicense(");
			strSql.Append("LicenseName,LicenseIMG,Remark)");
			strSql.Append(" values (");
			strSql.Append("@LicenseName,@LicenseIMG,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@LicenseName", SqlDbType.NVarChar,50),
					new SqlParameter("@LicenseIMG", SqlDbType.NVarChar,255),
					new SqlParameter("@Remark", SqlDbType.Text)};
			parameters[0].Value = model.LicenseName;
			parameters[1].Value = model.LicenseIMG;
			parameters[2].Value = model.Remark;

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
		public bool Update(YCF_Server.Model.OLicense model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OLicense set ");
			strSql.Append("LicenseName=@LicenseName,");
			strSql.Append("LicenseIMG=@LicenseIMG,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where LID=@LID");
			SqlParameter[] parameters = {
					new SqlParameter("@LicenseName", SqlDbType.NVarChar,50),
					new SqlParameter("@LicenseIMG", SqlDbType.NVarChar,255),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@LID", SqlDbType.Int,4)};
			parameters[0].Value = model.LicenseName;
			parameters[1].Value = model.LicenseIMG;
			parameters[2].Value = model.Remark;
			parameters[3].Value = model.LID;

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
		public bool Delete(int LID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OLicense ");
			strSql.Append(" where LID=@LID");
			SqlParameter[] parameters = {
					new SqlParameter("@LID", SqlDbType.Int,4)
			};
			parameters[0].Value = LID;

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
		public bool DeleteList(string LIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OLicense ");
			strSql.Append(" where LID in ("+LIDlist + ")  ");
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
		public YCF_Server.Model.OLicense GetModel(int LID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LID,LicenseName,LicenseIMG,Remark from OLicense ");
			strSql.Append(" where LID=@LID");
			SqlParameter[] parameters = {
					new SqlParameter("@LID", SqlDbType.Int,4)
			};
			parameters[0].Value = LID;

			YCF_Server.Model.OLicense model=new YCF_Server.Model.OLicense();
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
		public YCF_Server.Model.OLicense DataRowToModel(DataRow row)
		{
			YCF_Server.Model.OLicense model=new YCF_Server.Model.OLicense();
			if (row != null)
			{
				if(row["LID"]!=null && row["LID"].ToString()!="")
				{
					model.LID=int.Parse(row["LID"].ToString());
				}
				if(row["LicenseName"]!=null)
				{
					model.LicenseName=row["LicenseName"].ToString();
				}
				if(row["LicenseIMG"]!=null)
				{
					model.LicenseIMG=row["LicenseIMG"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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
			strSql.Append("select LID,LicenseName,LicenseIMG,Remark ");
			strSql.Append(" FROM OLicense ");
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
			strSql.Append(" LID,LicenseName,LicenseIMG,Remark ");
			strSql.Append(" FROM OLicense ");
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
			strSql.Append("select count(1) FROM OLicense ");
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
				strSql.Append("order by T.LID desc");
			}
			strSql.Append(")AS Row, T.*  from OLicense T ");
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
			parameters[0].Value = "OLicense";
			parameters[1].Value = "LID";
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

