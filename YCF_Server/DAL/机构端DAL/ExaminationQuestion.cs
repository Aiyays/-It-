using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:ExaminationQuestion
	/// </summary>
	public partial class ExaminationQuestion
	{
		public ExaminationQuestion()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("EID", "ExaminationQuestion"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int EID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ExaminationQuestion");
			strSql.Append(" where EID=@EID ");
			SqlParameter[] parameters = {
					new SqlParameter("@EID", SqlDbType.Int,4)			};
			parameters[0].Value = EID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(YCF_Server.Model.ExaminationQuestion model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ExaminationQuestion(");
			strSql.Append("EID,Question,EGroup,EType,IsRadio)");
			strSql.Append(" values (");
			strSql.Append("@EID,@Question,@EGroup,@EType,@IsRadio)");
			SqlParameter[] parameters = {
					new SqlParameter("@EID", SqlDbType.Int,4),
					new SqlParameter("@Question", SqlDbType.NVarChar,255),
					new SqlParameter("@EGroup", SqlDbType.Int,4),
					new SqlParameter("@EType", SqlDbType.NVarChar,255),
					new SqlParameter("@IsRadio", SqlDbType.Int,4)};
			parameters[0].Value = model.EID;
			parameters[1].Value = model.Question;
			parameters[2].Value = model.EGroup;
			parameters[3].Value = model.EType;
			parameters[4].Value = model.IsRadio;

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
		public bool Update(YCF_Server.Model.ExaminationQuestion model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ExaminationQuestion set ");
			strSql.Append("Question=@Question,");
			strSql.Append("EGroup=@EGroup,");
			strSql.Append("EType=@EType,");
			strSql.Append("IsRadio=@IsRadio");
			strSql.Append(" where EID=@EID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Question", SqlDbType.NVarChar,255),
					new SqlParameter("@EGroup", SqlDbType.Int,4),
					new SqlParameter("@EType", SqlDbType.NVarChar,255),
					new SqlParameter("@IsRadio", SqlDbType.Int,4),
					new SqlParameter("@EID", SqlDbType.Int,4)};
			parameters[0].Value = model.Question;
			parameters[1].Value = model.EGroup;
			parameters[2].Value = model.EType;
			parameters[3].Value = model.IsRadio;
			parameters[4].Value = model.EID;

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
		public bool Delete(int EID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ExaminationQuestion ");
			strSql.Append(" where EID=@EID ");
			SqlParameter[] parameters = {
					new SqlParameter("@EID", SqlDbType.Int,4)			};
			parameters[0].Value = EID;

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
		public bool DeleteList(string EIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ExaminationQuestion ");
			strSql.Append(" where EID in ("+EIDlist + ")  ");
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
		public YCF_Server.Model.ExaminationQuestion GetModel(int EID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 EID,Question,EGroup,EType,IsRadio from ExaminationQuestion ");
			strSql.Append(" where EID=@EID ");
			SqlParameter[] parameters = {
					new SqlParameter("@EID", SqlDbType.Int,4)			};
			parameters[0].Value = EID;

			YCF_Server.Model.ExaminationQuestion model=new YCF_Server.Model.ExaminationQuestion();
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
		public YCF_Server.Model.ExaminationQuestion DataRowToModel(DataRow row)
		{
			YCF_Server.Model.ExaminationQuestion model=new YCF_Server.Model.ExaminationQuestion();
			if (row != null)
			{
				if(row["EID"]!=null && row["EID"].ToString()!="")
				{
					model.EID=int.Parse(row["EID"].ToString());
				}
				if(row["Question"]!=null)
				{
					model.Question=row["Question"].ToString();
				}
				if(row["EGroup"]!=null && row["EGroup"].ToString()!="")
				{
					model.EGroup=int.Parse(row["EGroup"].ToString());
				}
				if(row["EType"]!=null)
				{
					model.EType=row["EType"].ToString();
				}
				if(row["IsRadio"]!=null && row["IsRadio"].ToString()!="")
				{
					model.IsRadio=int.Parse(row["IsRadio"].ToString());
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
			strSql.Append("select EID,Question,EGroup,EType,IsRadio ");
			strSql.Append(" FROM ExaminationQuestion ");
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
			strSql.Append(" EID,Question,EGroup,EType,IsRadio ");
			strSql.Append(" FROM ExaminationQuestion ");
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
			strSql.Append("select count(1) FROM ExaminationQuestion ");
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
				strSql.Append("order by T.EID desc");
			}
			strSql.Append(")AS Row, T.*  from ExaminationQuestion T ");
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
			parameters[0].Value = "ExaminationQuestion";
			parameters[1].Value = "EID";
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

