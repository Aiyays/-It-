using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:PersonalEquipment
	/// </summary>
	public partial class PersonalEquipment
	{
		public PersonalEquipment()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PEID", "PersonalEquipment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PEID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PersonalEquipment");
			strSql.Append(" where PEID=@PEID");
			SqlParameter[] parameters = {
					new SqlParameter("@PEID", SqlDbType.Int,4)
			};
			parameters[0].Value = PEID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.PersonalEquipment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PersonalEquipment(");
			strSql.Append("EID,PID,EmpID,GID,PTime,Number)");
			strSql.Append(" values (");
			strSql.Append("@EID,@PID,@EmpID,@GID,@PTime,@Number)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@EID", SqlDbType.Int,4),
					new SqlParameter("@PID", SqlDbType.Int,4),
					new SqlParameter("@EmpID", SqlDbType.Int,4),
					new SqlParameter("@GID", SqlDbType.Int,4),
					new SqlParameter("@PTime", SqlDbType.DateTime),
					new SqlParameter("@Number", SqlDbType.Int,4)};
			parameters[0].Value = model.EID;
			parameters[1].Value = model.PID;
			parameters[2].Value = model.EmpID;
			parameters[3].Value = model.GID;
			parameters[4].Value = model.PTime;
			parameters[5].Value = model.Number;

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
		public bool Update(YCF_Server.Model.PersonalEquipment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PersonalEquipment set ");
			strSql.Append("EID=@EID,");
			strSql.Append("PID=@PID,");
			strSql.Append("EmpID=@EmpID,");
			strSql.Append("GID=@GID,");
			strSql.Append("PTime=@PTime,");
			strSql.Append("Number=@Number");
			strSql.Append(" where PEID=@PEID");
			SqlParameter[] parameters = {
					new SqlParameter("@EID", SqlDbType.Int,4),
					new SqlParameter("@PID", SqlDbType.Int,4),
					new SqlParameter("@EmpID", SqlDbType.Int,4),
					new SqlParameter("@GID", SqlDbType.Int,4),
					new SqlParameter("@PTime", SqlDbType.DateTime),
					new SqlParameter("@Number", SqlDbType.Int,4),
					new SqlParameter("@PEID", SqlDbType.Int,4)};
			parameters[0].Value = model.EID;
			parameters[1].Value = model.PID;
			parameters[2].Value = model.EmpID;
			parameters[3].Value = model.GID;
			parameters[4].Value = model.PTime;
			parameters[5].Value = model.Number;
			parameters[6].Value = model.PEID;

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
		public bool Delete(int PEID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PersonalEquipment ");
			strSql.Append(" where PEID=@PEID");
			SqlParameter[] parameters = {
					new SqlParameter("@PEID", SqlDbType.Int,4)
			};
			parameters[0].Value = PEID;

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
		public bool DeleteList(string PEIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PersonalEquipment ");
			strSql.Append(" where PEID in ("+PEIDlist + ")  ");
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
		public YCF_Server.Model.PersonalEquipment GetModel(int PEID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PEID,EID,PID,EmpID,GID,PTime,Number from PersonalEquipment ");
			strSql.Append(" where PEID=@PEID");
			SqlParameter[] parameters = {
					new SqlParameter("@PEID", SqlDbType.Int,4)
			};
			parameters[0].Value = PEID;

			YCF_Server.Model.PersonalEquipment model=new YCF_Server.Model.PersonalEquipment();
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
		public YCF_Server.Model.PersonalEquipment DataRowToModel(DataRow row)
		{
			YCF_Server.Model.PersonalEquipment model=new YCF_Server.Model.PersonalEquipment();
			if (row != null)
			{
				if(row["PEID"]!=null && row["PEID"].ToString()!="")
				{
					model.PEID=int.Parse(row["PEID"].ToString());
				}
				if(row["EID"]!=null && row["EID"].ToString()!="")
				{
					model.EID=int.Parse(row["EID"].ToString());
				}
				if(row["PID"]!=null && row["PID"].ToString()!="")
				{
					model.PID=int.Parse(row["PID"].ToString());
				}
				if(row["EmpID"]!=null && row["EmpID"].ToString()!="")
				{
					model.EmpID=int.Parse(row["EmpID"].ToString());
				}
				if(row["GID"]!=null && row["GID"].ToString()!="")
				{
					model.GID=int.Parse(row["GID"].ToString());
				}
				if(row["PTime"]!=null && row["PTime"].ToString()!="")
				{
					model.PTime=DateTime.Parse(row["PTime"].ToString());
				}
				if(row["Number"]!=null && row["Number"].ToString()!="")
				{
					model.Number=int.Parse(row["Number"].ToString());
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
			strSql.Append("select PEID,EID,PID,EmpID,GID,PTime,Number ");
			strSql.Append(" FROM PersonalEquipment ");
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
			strSql.Append(" PEID,EID,PID,EmpID,GID,PTime,Number ");
			strSql.Append(" FROM PersonalEquipment ");
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
			strSql.Append("select count(1) FROM PersonalEquipment ");
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
				strSql.Append("order by T.PEID desc");
			}
			strSql.Append(")AS Row, T.*  from PersonalEquipment T ");
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
			parameters[0].Value = "PersonalEquipment";
			parameters[1].Value = "PEID";
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

