using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:TransferClass
	/// </summary>
	public partial class TransferClass
	{
		public TransferClass()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("TID", "TransferClass"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from TransferClass");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@TID", SqlDbType.Int,4)
			};
			parameters[0].Value = TID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.TransferClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into TransferClass(");
			strSql.Append("A_OID,R_OID,Reason,TransferTime,NowTime)");
			strSql.Append(" values (");
			strSql.Append("@A_OID,@R_OID,@Reason,@TransferTime,@NowTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@A_OID", SqlDbType.Int,4),
					new SqlParameter("@R_OID", SqlDbType.Int,4),
					new SqlParameter("@Reason", SqlDbType.NVarChar,255),
					new SqlParameter("@TransferTime", SqlDbType.datetime2,8),
					new SqlParameter("@NowTime", SqlDbType.datetime2,8)};
			parameters[0].Value = model.A_OID;
			parameters[1].Value = model.R_OID;
			parameters[2].Value = model.Reason;
			parameters[3].Value = model.TransferTime;
			parameters[4].Value = model.NowTime;

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
		public bool Update(YCF_Server.Model.TransferClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update TransferClass set ");
			strSql.Append("A_OID=@A_OID,");
			strSql.Append("R_OID=@R_OID,");
			strSql.Append("Reason=@Reason,");
			strSql.Append("TransferTime=@TransferTime,");
			strSql.Append("NowTime=@NowTime");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@A_OID", SqlDbType.Int,4),
					new SqlParameter("@R_OID", SqlDbType.Int,4),
					new SqlParameter("@Reason", SqlDbType.NVarChar,255),
					new SqlParameter("@TransferTime", SqlDbType.datetime2,8),
					new SqlParameter("@NowTime", SqlDbType.datetime2,8),
					new SqlParameter("@TID", SqlDbType.Int,4)};
			parameters[0].Value = model.A_OID;
			parameters[1].Value = model.R_OID;
			parameters[2].Value = model.Reason;
			parameters[3].Value = model.TransferTime;
			parameters[4].Value = model.NowTime;
			parameters[5].Value = model.TID;

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
		public bool Delete(int TID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TransferClass ");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@TID", SqlDbType.Int,4)
			};
			parameters[0].Value = TID;

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
		public bool DeleteList(string TIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from TransferClass ");
			strSql.Append(" where TID in ("+TIDlist + ")  ");
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
		public YCF_Server.Model.TransferClass GetModel(int TID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TID,A_OID,R_OID,Reason,TransferTime,NowTime from TransferClass ");
			strSql.Append(" where TID=@TID");
			SqlParameter[] parameters = {
					new SqlParameter("@TID", SqlDbType.Int,4)
			};
			parameters[0].Value = TID;

			YCF_Server.Model.TransferClass model=new YCF_Server.Model.TransferClass();
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
		public YCF_Server.Model.TransferClass DataRowToModel(DataRow row)
		{
			YCF_Server.Model.TransferClass model=new YCF_Server.Model.TransferClass();
			if (row != null)
			{
				if(row["TID"]!=null && row["TID"].ToString()!="")
				{
					model.TID=int.Parse(row["TID"].ToString());
				}
				if(row["A_OID"]!=null && row["A_OID"].ToString()!="")
				{
					model.A_OID=int.Parse(row["A_OID"].ToString());
				}
				if(row["R_OID"]!=null && row["R_OID"].ToString()!="")
				{
					model.R_OID=int.Parse(row["R_OID"].ToString());
				}
				if(row["Reason"]!=null)
				{
					model.Reason=row["Reason"].ToString();
				}
					//model.TransferTime=row["TransferTime"].ToString();
					//model.NowTime=row["NowTime"].ToString();
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TID,A_OID,R_OID,Reason,TransferTime,NowTime ");
			strSql.Append(" FROM TransferClass ");
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
			strSql.Append(" TID,A_OID,R_OID,Reason,TransferTime,NowTime ");
			strSql.Append(" FROM TransferClass ");
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
			strSql.Append("select count(1) FROM TransferClass ");
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
				strSql.Append("order by T.TID desc");
			}
			strSql.Append(")AS Row, T.*  from TransferClass T ");
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
			parameters[0].Value = "TransferClass";
			parameters[1].Value = "TID";
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

