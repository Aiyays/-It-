using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:PensnonalDrug
	/// </summary>
	public partial class PensnonalDrug
	{
		public PensnonalDrug()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PDID", "PensnonalDrug"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PDID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PensnonalDrug");
			strSql.Append(" where PDID=@PDID");
			SqlParameter[] parameters = {
					new SqlParameter("@PDID", SqlDbType.Int,4)
			};
			parameters[0].Value = PDID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.PensnonalDrug model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PensnonalDrug(");
			strSql.Append("DTime,Frequency,Dose,DID,EID,PID,IMG,Remark)");
			strSql.Append(" values (");
			strSql.Append("@DTime,@Frequency,@Dose,@DID,@EID,@PID,@IMG,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DTime", SqlDbType.DateTime),
					new SqlParameter("@Frequency", SqlDbType.NVarChar,50),
					new SqlParameter("@Dose", SqlDbType.NVarChar,50),
					new SqlParameter("@DID", SqlDbType.Int,4),
					new SqlParameter("@EID", SqlDbType.Int,4),
					new SqlParameter("@PID", SqlDbType.Int,4),
					new SqlParameter("@IMG", SqlDbType.NVarChar,255),
					new SqlParameter("@Remark", SqlDbType.Text)};
			parameters[0].Value = model.DTime;
			parameters[1].Value = model.Frequency;
			parameters[2].Value = model.Dose;
			parameters[3].Value = model.DID;
			parameters[4].Value = model.EID;
			parameters[5].Value = model.PID;
			parameters[6].Value = model.IMG;
			parameters[7].Value = model.Remark;

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
		public bool Update(YCF_Server.Model.PensnonalDrug model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PensnonalDrug set ");
			strSql.Append("DTime=@DTime,");
			strSql.Append("Frequency=@Frequency,");
			strSql.Append("Dose=@Dose,");
			strSql.Append("DID=@DID,");
			strSql.Append("EID=@EID,");
			strSql.Append("PID=@PID,");
			strSql.Append("IMG=@IMG,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where PDID=@PDID");
			SqlParameter[] parameters = {
					new SqlParameter("@DTime", SqlDbType.DateTime),
					new SqlParameter("@Frequency", SqlDbType.NVarChar,50),
					new SqlParameter("@Dose", SqlDbType.NVarChar,50),
					new SqlParameter("@DID", SqlDbType.Int,4),
					new SqlParameter("@EID", SqlDbType.Int,4),
					new SqlParameter("@PID", SqlDbType.Int,4),
					new SqlParameter("@IMG", SqlDbType.NVarChar,255),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@PDID", SqlDbType.Int,4)};
			parameters[0].Value = model.DTime;
			parameters[1].Value = model.Frequency;
			parameters[2].Value = model.Dose;
			parameters[3].Value = model.DID;
			parameters[4].Value = model.EID;
			parameters[5].Value = model.PID;
			parameters[6].Value = model.IMG;
			parameters[7].Value = model.Remark;
			parameters[8].Value = model.PDID;

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
		public bool Delete(int PDID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PensnonalDrug ");
			strSql.Append(" where PDID=@PDID");
			SqlParameter[] parameters = {
					new SqlParameter("@PDID", SqlDbType.Int,4)
			};
			parameters[0].Value = PDID;

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
		public bool DeleteList(string PDIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PensnonalDrug ");
			strSql.Append(" where PDID in ("+PDIDlist + ")  ");
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
		public YCF_Server.Model.PensnonalDrug GetModel(int PDID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PDID,DTime,Frequency,Dose,DID,EID,PID,IMG,Remark from PensnonalDrug ");
			strSql.Append(" where PDID=@PDID");
			SqlParameter[] parameters = {
					new SqlParameter("@PDID", SqlDbType.Int,4)
			};
			parameters[0].Value = PDID;

			YCF_Server.Model.PensnonalDrug model=new YCF_Server.Model.PensnonalDrug();
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
		public YCF_Server.Model.PensnonalDrug DataRowToModel(DataRow row)
		{
			YCF_Server.Model.PensnonalDrug model=new YCF_Server.Model.PensnonalDrug();
			if (row != null)
			{
				if(row["PDID"]!=null && row["PDID"].ToString()!="")
				{
					model.PDID=int.Parse(row["PDID"].ToString());
				}
				if(row["DTime"]!=null && row["DTime"].ToString()!="")
				{
					model.DTime=DateTime.Parse(row["DTime"].ToString());
				}
				if(row["Frequency"]!=null)
				{
					model.Frequency=row["Frequency"].ToString();
				}
				if(row["Dose"]!=null)
				{
					model.Dose=row["Dose"].ToString();
				}
				if(row["DID"]!=null && row["DID"].ToString()!="")
				{
					model.DID=int.Parse(row["DID"].ToString());
				}
				if(row["EID"]!=null && row["EID"].ToString()!="")
				{
					model.EID=int.Parse(row["EID"].ToString());
				}
				if(row["PID"]!=null && row["PID"].ToString()!="")
				{
					model.PID=int.Parse(row["PID"].ToString());
				}
				if(row["IMG"]!=null)
				{
					model.IMG=row["IMG"].ToString();
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
			strSql.Append("select PDID,DTime,Frequency,Dose,DID,EID,PID,IMG,Remark ");
			strSql.Append(" FROM PensnonalDrug ");
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
			strSql.Append(" PDID,DTime,Frequency,Dose,DID,EID,PID,IMG,Remark ");
			strSql.Append(" FROM PensnonalDrug ");
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
			strSql.Append("select count(1) FROM PensnonalDrug ");
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
				strSql.Append("order by T.PDID desc");
			}
			strSql.Append(")AS Row, T.*  from PensnonalDrug T ");
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
			parameters[0].Value = "PensnonalDrug";
			parameters[1].Value = "PDID";
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

