using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:Weight
	/// </summary>
	public partial class Weight
	{
		public Weight()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("WID", "Weight"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int WID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Weight");
			strSql.Append(" where WID=@WID");
			SqlParameter[] parameters = {
					new SqlParameter("@WID", SqlDbType.Int,4)
			};
			parameters[0].Value = WID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.Weight model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Weight(");
			strSql.Append("WTime,Weight,PID)");
			strSql.Append(" values (");
			strSql.Append("@WTime,@Weight,@PID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@WTime", SqlDbType.DateTime),
					new SqlParameter("@Weight", SqlDbType.NVarChar,50),
					new SqlParameter("@PID", SqlDbType.Int,4)};
			parameters[0].Value = model.WTime;
			parameters[1].Value = model.weight;
			parameters[2].Value = model.PID;

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
		public bool Update(YCF_Server.Model.Weight model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Weight set ");
			strSql.Append("WTime=@WTime,");
			strSql.Append("Weight=@Weight,");
			strSql.Append("PID=@PID");
			strSql.Append(" where WID=@WID");
			SqlParameter[] parameters = {
					new SqlParameter("@WTime", SqlDbType.DateTime),
					new SqlParameter("@Weight", SqlDbType.NVarChar,50),
					new SqlParameter("@PID", SqlDbType.Int,4),
					new SqlParameter("@WID", SqlDbType.Int,4)};
			parameters[0].Value = model.WTime;
			parameters[1].Value = model.weight;
			parameters[2].Value = model.PID;
			parameters[3].Value = model.WID;

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
		public bool Delete(int WID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Weight ");
			strSql.Append(" where WID=@WID");
			SqlParameter[] parameters = {
					new SqlParameter("@WID", SqlDbType.Int,4)
			};
			parameters[0].Value = WID;

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
		public bool DeleteList(string WIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Weight ");
			strSql.Append(" where WID in ("+WIDlist + ")  ");
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
		public YCF_Server.Model.Weight GetModel(int WID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 WID,WTime,Weight,PID from Weight ");
			strSql.Append(" where WID=@WID");
			SqlParameter[] parameters = {
					new SqlParameter("@WID", SqlDbType.Int,4)
			};
			parameters[0].Value = WID;

			YCF_Server.Model.Weight model=new YCF_Server.Model.Weight();
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
		public YCF_Server.Model.Weight DataRowToModel(DataRow row)
		{
			YCF_Server.Model.Weight model=new YCF_Server.Model.Weight();
			if (row != null)
			{
				if(row["WID"]!=null && row["WID"].ToString()!="")
				{
					model.WID=int.Parse(row["WID"].ToString());
				}
				if(row["WTime"]!=null && row["WTime"].ToString()!="")
				{
					model.WTime=DateTime.Parse(row["WTime"].ToString());
				}
				if(row["Weight"]!=null)
				{
					model.weight=row["Weight"].ToString();
				}
				if(row["PID"]!=null && row["PID"].ToString()!="")
				{
					model.PID=int.Parse(row["PID"].ToString());
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
			strSql.Append("select WID,WTime,Weight,PID ");
			strSql.Append(" FROM Weight ");
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
			strSql.Append(" WID,WTime,Weight,PID ");
			strSql.Append(" FROM Weight ");
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
			strSql.Append("select count(1) FROM Weight ");
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
				strSql.Append("order by T.WID desc");
			}
			strSql.Append(")AS Row, T.*  from Weight T ");
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
			parameters[0].Value = "Weight";
			parameters[1].Value = "WID";
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

