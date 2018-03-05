using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:AssessRecord
	/// </summary>
	public partial class AssessRecord
	{
		public AssessRecord()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("AID", "AssessRecord"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from AssessRecord");
			strSql.Append(" where AID=@AID");
			SqlParameter[] parameters = {
					new SqlParameter("@AID", SqlDbType.Int,4)
			};
			parameters[0].Value = AID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.AssessRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AssessRecord(");
			strSql.Append("UName,Sex,FN,BirthDate,TheBed,ValuationDate,Evaluator,Registrar,RecordData,BADL,LADL,LSP,SysEvaluation,Assessment,UID,Comment)");
			strSql.Append(" values (");
			strSql.Append("@UName,@Sex,@FN,@BirthDate,@TheBed,@ValuationDate,@Evaluator,@Registrar,@RecordData,@BADL,@LADL,@LSP,@SysEvaluation,@Assessment,@UID,@Comment)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UName", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@FN", SqlDbType.VarChar,50),
					new SqlParameter("@BirthDate", SqlDbType.DateTime),
					new SqlParameter("@TheBed", SqlDbType.NVarChar,50),
					new SqlParameter("@ValuationDate", SqlDbType.DateTime),
					new SqlParameter("@Evaluator", SqlDbType.NVarChar,50),
					new SqlParameter("@Registrar", SqlDbType.NVarChar,50),
					new SqlParameter("@RecordData", SqlDbType.DateTime),
					new SqlParameter("@BADL", SqlDbType.Int,4),
					new SqlParameter("@LADL", SqlDbType.Int,4),
					new SqlParameter("@LSP", SqlDbType.Int,4),
					new SqlParameter("@SysEvaluation", SqlDbType.NVarChar,255),
					new SqlParameter("@Assessment", SqlDbType.NVarChar,255),
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@Comment", SqlDbType.VarChar,500)};
			parameters[0].Value = model.UName;
			parameters[1].Value = model.Sex;
			parameters[2].Value = model.FN;
			parameters[3].Value = model.BirthDate;
			parameters[4].Value = model.TheBed;
			parameters[5].Value = model.ValuationDate;
			parameters[6].Value = model.Evaluator;
			parameters[7].Value = model.Registrar;
			parameters[8].Value = model.RecordData;
			parameters[9].Value = model.BADL;
			parameters[10].Value = model.LADL;
			parameters[11].Value = model.LSP;
			parameters[12].Value = model.SysEvaluation;
			parameters[13].Value = model.Assessment;
			parameters[14].Value = model.UID;
			parameters[15].Value = model.Comment;

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
		public bool Update(YCF_Server.Model.AssessRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AssessRecord set ");
			strSql.Append("UName=@UName,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("FN=@FN,");
			strSql.Append("BirthDate=@BirthDate,");
			strSql.Append("TheBed=@TheBed,");
			strSql.Append("ValuationDate=@ValuationDate,");
			strSql.Append("Evaluator=@Evaluator,");
			strSql.Append("Registrar=@Registrar,");
			strSql.Append("RecordData=@RecordData,");
			strSql.Append("BADL=@BADL,");
			strSql.Append("LADL=@LADL,");
			strSql.Append("LSP=@LSP,");
			strSql.Append("SysEvaluation=@SysEvaluation,");
			strSql.Append("Assessment=@Assessment,");
			strSql.Append("UID=@UID,");
			strSql.Append("Comment=@Comment");
			strSql.Append(" where AID=@AID");
			SqlParameter[] parameters = {
					new SqlParameter("@UName", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.Int,4),
					new SqlParameter("@FN", SqlDbType.VarChar,50),
					new SqlParameter("@BirthDate", SqlDbType.DateTime),
					new SqlParameter("@TheBed", SqlDbType.NVarChar,50),
					new SqlParameter("@ValuationDate", SqlDbType.DateTime),
					new SqlParameter("@Evaluator", SqlDbType.NVarChar,50),
					new SqlParameter("@Registrar", SqlDbType.NVarChar,50),
					new SqlParameter("@RecordData", SqlDbType.DateTime),
					new SqlParameter("@BADL", SqlDbType.Int,4),
					new SqlParameter("@LADL", SqlDbType.Int,4),
					new SqlParameter("@LSP", SqlDbType.Int,4),
					new SqlParameter("@SysEvaluation", SqlDbType.NVarChar,255),
					new SqlParameter("@Assessment", SqlDbType.NVarChar,255),
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@Comment", SqlDbType.VarChar,500),
					new SqlParameter("@AID", SqlDbType.Int,4)};
			parameters[0].Value = model.UName;
			parameters[1].Value = model.Sex;
			parameters[2].Value = model.FN;
			parameters[3].Value = model.BirthDate;
			parameters[4].Value = model.TheBed;
			parameters[5].Value = model.ValuationDate;
			parameters[6].Value = model.Evaluator;
			parameters[7].Value = model.Registrar;
			parameters[8].Value = model.RecordData;
			parameters[9].Value = model.BADL;
			parameters[10].Value = model.LADL;
			parameters[11].Value = model.LSP;
			parameters[12].Value = model.SysEvaluation;
			parameters[13].Value = model.Assessment;
			parameters[14].Value = model.UID;
			parameters[15].Value = model.Comment;
			parameters[16].Value = model.AID;

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
		public bool Delete(int AID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AssessRecord ");
			strSql.Append(" where AID=@AID");
			SqlParameter[] parameters = {
					new SqlParameter("@AID", SqlDbType.Int,4)
			};
			parameters[0].Value = AID;

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
		public bool DeleteList(string AIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from AssessRecord ");
			strSql.Append(" where AID in ("+AIDlist + ")  ");
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
		public YCF_Server.Model.AssessRecord GetModel(int AID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AID,UName,Sex,FN,BirthDate,TheBed,ValuationDate,Evaluator,Registrar,RecordData,BADL,LADL,LSP,SysEvaluation,Assessment,UID,Comment from AssessRecord ");
			strSql.Append(" where AID=@AID");
			SqlParameter[] parameters = {
					new SqlParameter("@AID", SqlDbType.Int,4)
			};
			parameters[0].Value = AID;

			YCF_Server.Model.AssessRecord model=new YCF_Server.Model.AssessRecord();
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
		public YCF_Server.Model.AssessRecord DataRowToModel(DataRow row)
		{
			YCF_Server.Model.AssessRecord model=new YCF_Server.Model.AssessRecord();
			if (row != null)
			{
				if(row["AID"]!=null && row["AID"].ToString()!="")
				{
					model.AID=int.Parse(row["AID"].ToString());
				}
				if(row["UName"]!=null)
				{
					model.UName=row["UName"].ToString();
				}
				if(row["Sex"]!=null && row["Sex"].ToString()!="")
				{
					model.Sex=int.Parse(row["Sex"].ToString());
				}
				if(row["FN"]!=null)
				{
					model.FN=row["FN"].ToString();
				}
				if(row["BirthDate"]!=null && row["BirthDate"].ToString()!="")
				{
					model.BirthDate=DateTime.Parse(row["BirthDate"].ToString());
				}
				if(row["TheBed"]!=null)
				{
					model.TheBed=row["TheBed"].ToString();
				}
				if(row["ValuationDate"]!=null && row["ValuationDate"].ToString()!="")
				{
					model.ValuationDate=DateTime.Parse(row["ValuationDate"].ToString());
				}
				if(row["Evaluator"]!=null)
				{
					model.Evaluator=row["Evaluator"].ToString();
				}
				if(row["Registrar"]!=null)
				{
					model.Registrar=row["Registrar"].ToString();
				}
				if(row["RecordData"]!=null && row["RecordData"].ToString()!="")
				{
					model.RecordData=DateTime.Parse(row["RecordData"].ToString());
				}
				if(row["BADL"]!=null && row["BADL"].ToString()!="")
				{
					model.BADL=int.Parse(row["BADL"].ToString());
				}
				if(row["LADL"]!=null && row["LADL"].ToString()!="")
				{
					model.LADL=int.Parse(row["LADL"].ToString());
				}
				if(row["LSP"]!=null && row["LSP"].ToString()!="")
				{
					model.LSP=int.Parse(row["LSP"].ToString());
				}
				if(row["SysEvaluation"]!=null)
				{
					model.SysEvaluation=row["SysEvaluation"].ToString();
				}
				if(row["Assessment"]!=null)
				{
					model.Assessment=row["Assessment"].ToString();
				}
				if(row["UID"]!=null && row["UID"].ToString()!="")
				{
					model.UID=int.Parse(row["UID"].ToString());
				}
				if(row["Comment"]!=null)
				{
					model.Comment=row["Comment"].ToString();
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
			strSql.Append("select AID,UName,Sex,FN,BirthDate,TheBed,ValuationDate,Evaluator,Registrar,RecordData,BADL,LADL,LSP,SysEvaluation,Assessment,UID,Comment ");
			strSql.Append(" FROM AssessRecord ");
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
			strSql.Append(" AID,UName,Sex,FN,BirthDate,TheBed,ValuationDate,Evaluator,Registrar,RecordData,BADL,LADL,LSP,SysEvaluation,Assessment,UID,Comment ");
			strSql.Append(" FROM AssessRecord ");
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
			strSql.Append("select count(1) FROM AssessRecord ");
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
				strSql.Append("order by T.AID desc");
			}
			strSql.Append(")AS Row, T.*  from AssessRecord T ");
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
			parameters[0].Value = "AssessRecord";
			parameters[1].Value = "AID";
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

