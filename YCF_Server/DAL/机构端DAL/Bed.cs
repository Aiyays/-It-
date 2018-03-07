﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:Bed
	/// </summary>
	public partial class Bed
	{
		public Bed()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("BID", "Bed"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int BID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Bed");
			strSql.Append(" where BID=@BID");
			SqlParameter[] parameters = {
					new SqlParameter("@BID", SqlDbType.Int,4)
			};
			parameters[0].Value = BID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.Bed model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Bed(");
			strSql.Append("Number,Posture,PID,EID,AID)");
			strSql.Append(" values (");
			strSql.Append("@Number,@Posture,@PID,@EID,@AID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Number", SqlDbType.NVarChar,50),
					new SqlParameter("@Posture", SqlDbType.NVarChar,50),
					new SqlParameter("@PID", SqlDbType.Int,4),
					new SqlParameter("@EID", SqlDbType.Int,4),
					new SqlParameter("@AID", SqlDbType.Int,4)};
			parameters[0].Value = model.Number;
			parameters[1].Value = model.Posture;
			parameters[2].Value = model.PID;
			parameters[3].Value = model.EID;
			parameters[4].Value = model.AID;

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
		public bool Update(YCF_Server.Model.Bed model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Bed set ");
			strSql.Append("Number=@Number,");
			strSql.Append("Posture=@Posture,");
			strSql.Append("PID=@PID,");
			strSql.Append("EID=@EID,");
			strSql.Append("AID=@AID");
			strSql.Append(" where BID=@BID");
			SqlParameter[] parameters = {
					new SqlParameter("@Number", SqlDbType.NVarChar,50),
					new SqlParameter("@Posture", SqlDbType.NVarChar,50),
					new SqlParameter("@PID", SqlDbType.Int,4),
					new SqlParameter("@EID", SqlDbType.Int,4),
					new SqlParameter("@AID", SqlDbType.Int,4),
					new SqlParameter("@BID", SqlDbType.Int,4)};
			parameters[0].Value = model.Number;
			parameters[1].Value = model.Posture;
			parameters[2].Value = model.PID;
			parameters[3].Value = model.EID;
			parameters[4].Value = model.AID;
			parameters[5].Value = model.BID;

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
		public bool Delete(int BID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Bed ");
			strSql.Append(" where BID=@BID");
			SqlParameter[] parameters = {
					new SqlParameter("@BID", SqlDbType.Int,4)
			};
			parameters[0].Value = BID;

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
		public bool DeleteList(string BIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Bed ");
			strSql.Append(" where BID in ("+BIDlist + ")  ");
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
		public YCF_Server.Model.Bed GetModel(int BID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 BID,Number,Posture,PID,EID,AID from Bed ");
			strSql.Append(" where BID=@BID");
			SqlParameter[] parameters = {
					new SqlParameter("@BID", SqlDbType.Int,4)
			};
			parameters[0].Value = BID;

			YCF_Server.Model.Bed model=new YCF_Server.Model.Bed();
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
		public YCF_Server.Model.Bed DataRowToModel(DataRow row)
		{
			YCF_Server.Model.Bed model=new YCF_Server.Model.Bed();
			if (row != null)
			{
				if(row["BID"]!=null && row["BID"].ToString()!="")
				{
					model.BID=int.Parse(row["BID"].ToString());
				}
				if(row["Number"]!=null)
				{
					model.Number=row["Number"].ToString();
				}
				if(row["Posture"]!=null)
				{
					model.Posture=row["Posture"].ToString();
				}
				if(row["PID"]!=null && row["PID"].ToString()!="")
				{
					model.PID=int.Parse(row["PID"].ToString());
				}
				if(row["EID"]!=null && row["EID"].ToString()!="")
				{
					model.EID=int.Parse(row["EID"].ToString());
				}
				if(row["AID"]!=null && row["AID"].ToString()!="")
				{
					model.AID=int.Parse(row["AID"].ToString());
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
			strSql.Append("select BID,Number,Posture,PID,EID,AID ");
			strSql.Append(" FROM Bed ");
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
			strSql.Append(" BID,Number,Posture,PID,EID,AID ");
			strSql.Append(" FROM Bed ");
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
			strSql.Append("select count(1) FROM Bed ");
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
				strSql.Append("order by T.BID desc");
			}
			strSql.Append(")AS Row, T.*  from Bed T ");
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
			parameters[0].Value = "Bed";
			parameters[1].Value = "BID";
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

