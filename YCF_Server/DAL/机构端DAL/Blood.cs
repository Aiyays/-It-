using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:Blood
	/// </summary>
	public partial class Blood
	{
		public Blood()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("BID", "Blood"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int BID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Blood");
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
		public int Add(YCF_Server.Model.Blood model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Blood(");
			strSql.Append("Btime,BloodPressure,BloodFat,BlooGlucose,PID)");
			strSql.Append(" values (");
			strSql.Append("@Btime,@BloodPressure,@BloodFat,@BlooGlucose,@PID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Btime", SqlDbType.DateTime),
					new SqlParameter("@BloodPressure", SqlDbType.Int,4),
					new SqlParameter("@BloodFat", SqlDbType.Int,4),
					new SqlParameter("@BlooGlucose", SqlDbType.Int,4),
					new SqlParameter("@PID", SqlDbType.Int,4)};
			parameters[0].Value = model.Btime;
			parameters[1].Value = model.BloodPressure;
			parameters[2].Value = model.BloodFat;
			parameters[3].Value = model.BlooGlucose;
			parameters[4].Value = model.PID;

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
		public bool Update(YCF_Server.Model.Blood model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Blood set ");
			strSql.Append("Btime=@Btime,");
			strSql.Append("BloodPressure=@BloodPressure,");
			strSql.Append("BloodFat=@BloodFat,");
			strSql.Append("BlooGlucose=@BlooGlucose,");
			strSql.Append("PID=@PID");
			strSql.Append(" where BID=@BID");
			SqlParameter[] parameters = {
					new SqlParameter("@Btime", SqlDbType.DateTime),
					new SqlParameter("@BloodPressure", SqlDbType.Int,4),
					new SqlParameter("@BloodFat", SqlDbType.Int,4),
					new SqlParameter("@BlooGlucose", SqlDbType.Int,4),
					new SqlParameter("@PID", SqlDbType.Int,4),
					new SqlParameter("@BID", SqlDbType.Int,4)};
			parameters[0].Value = model.Btime;
			parameters[1].Value = model.BloodPressure;
			parameters[2].Value = model.BloodFat;
			parameters[3].Value = model.BlooGlucose;
			parameters[4].Value = model.PID;
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
			strSql.Append("delete from Blood ");
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
			strSql.Append("delete from Blood ");
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
		public YCF_Server.Model.Blood GetModel(int BID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 BID,Btime,BloodPressure,BloodFat,BlooGlucose,PID from Blood ");
			strSql.Append(" where BID=@BID");
			SqlParameter[] parameters = {
					new SqlParameter("@BID", SqlDbType.Int,4)
			};
			parameters[0].Value = BID;

			YCF_Server.Model.Blood model=new YCF_Server.Model.Blood();
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
		public YCF_Server.Model.Blood DataRowToModel(DataRow row)
		{
			YCF_Server.Model.Blood model=new YCF_Server.Model.Blood();
			if (row != null)
			{
				if(row["BID"]!=null && row["BID"].ToString()!="")
				{
					model.BID=int.Parse(row["BID"].ToString());
				}
				if(row["Btime"]!=null && row["Btime"].ToString()!="")
				{
					model.Btime=DateTime.Parse(row["Btime"].ToString());
				}
				if(row["BloodPressure"]!=null && row["BloodPressure"].ToString()!="")
				{
					model.BloodPressure=int.Parse(row["BloodPressure"].ToString());
				}
				if(row["BloodFat"]!=null && row["BloodFat"].ToString()!="")
				{
					model.BloodFat=int.Parse(row["BloodFat"].ToString());
				}
				if(row["BlooGlucose"]!=null && row["BlooGlucose"].ToString()!="")
				{
					model.BlooGlucose=int.Parse(row["BlooGlucose"].ToString());
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
			strSql.Append("select BID,Btime,BloodPressure,BloodFat,BlooGlucose,PID ");
			strSql.Append(" FROM Blood ");
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
			strSql.Append(" BID,Btime,BloodPressure,BloodFat,BlooGlucose,PID ");
			strSql.Append(" FROM Blood ");
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
			strSql.Append("select count(1) FROM Blood ");
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
			strSql.Append(")AS Row, T.*  from Blood T ");
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
			parameters[0].Value = "Blood";
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

