using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:PostureHabit
	/// </summary>
	public partial class PostureHabit
	{
		public PostureHabit()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PHID", "PostureHabit"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PHID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PostureHabit");
			strSql.Append(" where PHID=@PHID");
			SqlParameter[] parameters = {
					new SqlParameter("@PHID", SqlDbType.Int,4)
			};
			parameters[0].Value = PHID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.PostureHabit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PostureHabit(");
			strSql.Append("Height,Medicine,Back,Head,Waist,Leg,UID)");
			strSql.Append(" values (");
			strSql.Append("@Height,@Medicine,@Back,@Head,@Waist,@Leg,@UID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Height", SqlDbType.Int,4),
					new SqlParameter("@Medicine", SqlDbType.Int,4),
					new SqlParameter("@Back", SqlDbType.Int,4),
					new SqlParameter("@Head", SqlDbType.Int,4),
					new SqlParameter("@Waist", SqlDbType.Int,4),
					new SqlParameter("@Leg", SqlDbType.Int,4),
					new SqlParameter("@UID", SqlDbType.Int,4)};
			parameters[0].Value = model.Height;
			parameters[1].Value = model.Medicine;
			parameters[2].Value = model.Back;
			parameters[3].Value = model.Head;
			parameters[4].Value = model.Waist;
			parameters[5].Value = model.Leg;
			parameters[6].Value = model.UID;

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
		public bool Update(YCF_Server.Model.PostureHabit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PostureHabit set ");
			strSql.Append("Height=@Height,");
			strSql.Append("Medicine=@Medicine,");
			strSql.Append("Back=@Back,");
			strSql.Append("Head=@Head,");
			strSql.Append("Waist=@Waist,");
			strSql.Append("Leg=@Leg,");
			strSql.Append("UID=@UID");
			strSql.Append(" where PHID=@PHID");
			SqlParameter[] parameters = {
					new SqlParameter("@Height", SqlDbType.Int,4),
					new SqlParameter("@Medicine", SqlDbType.Int,4),
					new SqlParameter("@Back", SqlDbType.Int,4),
					new SqlParameter("@Head", SqlDbType.Int,4),
					new SqlParameter("@Waist", SqlDbType.Int,4),
					new SqlParameter("@Leg", SqlDbType.Int,4),
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@PHID", SqlDbType.Int,4)};
			parameters[0].Value = model.Height;
			parameters[1].Value = model.Medicine;
			parameters[2].Value = model.Back;
			parameters[3].Value = model.Head;
			parameters[4].Value = model.Waist;
			parameters[5].Value = model.Leg;
			parameters[6].Value = model.UID;
			parameters[7].Value = model.PHID;

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
		public bool Delete(int PHID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PostureHabit ");
			strSql.Append(" where PHID=@PHID");
			SqlParameter[] parameters = {
					new SqlParameter("@PHID", SqlDbType.Int,4)
			};
			parameters[0].Value = PHID;

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
		public bool DeleteList(string PHIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PostureHabit ");
			strSql.Append(" where PHID in ("+PHIDlist + ")  ");
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
		public YCF_Server.Model.PostureHabit GetModel(int PHID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PHID,Height,Medicine,Back,Head,Waist,Leg,UID from PostureHabit ");
			strSql.Append(" where PHID=@PHID");
			SqlParameter[] parameters = {
					new SqlParameter("@PHID", SqlDbType.Int,4)
			};
			parameters[0].Value = PHID;

			YCF_Server.Model.PostureHabit model=new YCF_Server.Model.PostureHabit();
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
		public YCF_Server.Model.PostureHabit DataRowToModel(DataRow row)
		{
			YCF_Server.Model.PostureHabit model=new YCF_Server.Model.PostureHabit();
			if (row != null)
			{
				if(row["PHID"]!=null && row["PHID"].ToString()!="")
				{
					model.PHID=int.Parse(row["PHID"].ToString());
				}
				if(row["Height"]!=null && row["Height"].ToString()!="")
				{
					model.Height=int.Parse(row["Height"].ToString());
				}
				if(row["Medicine"]!=null && row["Medicine"].ToString()!="")
				{
					model.Medicine=int.Parse(row["Medicine"].ToString());
				}
				if(row["Back"]!=null && row["Back"].ToString()!="")
				{
					model.Back=int.Parse(row["Back"].ToString());
				}
				if(row["Head"]!=null && row["Head"].ToString()!="")
				{
					model.Head=int.Parse(row["Head"].ToString());
				}
				if(row["Waist"]!=null && row["Waist"].ToString()!="")
				{
					model.Waist=int.Parse(row["Waist"].ToString());
				}
				if(row["Leg"]!=null && row["Leg"].ToString()!="")
				{
					model.Leg=int.Parse(row["Leg"].ToString());
				}
				if(row["UID"]!=null && row["UID"].ToString()!="")
				{
					model.UID=int.Parse(row["UID"].ToString());
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
			strSql.Append("select PHID,Height,Medicine,Back,Head,Waist,Leg,UID ");
			strSql.Append(" FROM PostureHabit ");
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
			strSql.Append(" PHID,Height,Medicine,Back,Head,Waist,Leg,UID ");
			strSql.Append(" FROM PostureHabit ");
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
			strSql.Append("select count(1) FROM PostureHabit ");
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
				strSql.Append("order by T.PHID desc");
			}
			strSql.Append(")AS Row, T.*  from PostureHabit T ");
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
			parameters[0].Value = "PostureHabit";
			parameters[1].Value = "PHID";
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

