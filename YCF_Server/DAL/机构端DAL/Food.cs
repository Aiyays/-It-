using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:Food
	/// </summary>
	public partial class Food
	{
		public Food()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("FID", "Food"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Food");
			strSql.Append(" where FID=@FID");
			SqlParameter[] parameters = {
					new SqlParameter("@FID", SqlDbType.Int,4)
			};
			parameters[0].Value = FID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.Food model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Food(");
			strSql.Append("Name,Price,Unit,Quantity,TID)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Price,@Unit,@Quantity,@TID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Price", SqlDbType.NVarChar,50),
					new SqlParameter("@Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@Quantity", SqlDbType.Int,4),
					new SqlParameter("@TID", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Price;
			parameters[2].Value = model.Unit;
			parameters[3].Value = model.Quantity;
			parameters[4].Value = model.TID;

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
		public bool Update(YCF_Server.Model.Food model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Food set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Price=@Price,");
			strSql.Append("Unit=@Unit,");
			strSql.Append("Quantity=@Quantity,");
			strSql.Append("TID=@TID");
			strSql.Append(" where FID=@FID");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Price", SqlDbType.NVarChar,50),
					new SqlParameter("@Unit", SqlDbType.NVarChar,50),
					new SqlParameter("@Quantity", SqlDbType.Int,4),
					new SqlParameter("@TID", SqlDbType.Int,4),
					new SqlParameter("@FID", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Price;
			parameters[2].Value = model.Unit;
			parameters[3].Value = model.Quantity;
			parameters[4].Value = model.TID;
			parameters[5].Value = model.FID;

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
		public bool Delete(int FID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Food ");
			strSql.Append(" where FID=@FID");
			SqlParameter[] parameters = {
					new SqlParameter("@FID", SqlDbType.Int,4)
			};
			parameters[0].Value = FID;

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
		public bool DeleteList(string FIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Food ");
			strSql.Append(" where FID in ("+FIDlist + ")  ");
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
		public YCF_Server.Model.Food GetModel(int FID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FID,Name,Price,Unit,Quantity,TID from Food ");
			strSql.Append(" where FID=@FID");
			SqlParameter[] parameters = {
					new SqlParameter("@FID", SqlDbType.Int,4)
			};
			parameters[0].Value = FID;

			YCF_Server.Model.Food model=new YCF_Server.Model.Food();
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
		public YCF_Server.Model.Food DataRowToModel(DataRow row)
		{
			YCF_Server.Model.Food model=new YCF_Server.Model.Food();
			if (row != null)
			{
				if(row["FID"]!=null && row["FID"].ToString()!="")
				{
					model.FID=int.Parse(row["FID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Price"]!=null)
				{
					model.Price=row["Price"].ToString();
				}
				if(row["Unit"]!=null)
				{
					model.Unit=row["Unit"].ToString();
				}
				if(row["Quantity"]!=null && row["Quantity"].ToString()!="")
				{
					model.Quantity=int.Parse(row["Quantity"].ToString());
				}
				if(row["TID"]!=null && row["TID"].ToString()!="")
				{
					model.TID=int.Parse(row["TID"].ToString());
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
			strSql.Append("select FID,Name,Price,Unit,Quantity,TID ");
			strSql.Append(" FROM Food ");
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
			strSql.Append(" FID,Name,Price,Unit,Quantity,TID ");
			strSql.Append(" FROM Food ");
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
			strSql.Append("select count(1) FROM Food ");
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
				strSql.Append("order by T.FID desc");
			}
			strSql.Append(")AS Row, T.*  from Food T ");
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
			parameters[0].Value = "Food";
			parameters[1].Value = "FID";
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

