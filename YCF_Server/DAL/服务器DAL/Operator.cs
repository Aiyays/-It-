using  System;
using  System.Data;
using  System.Text;
using  System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:Operator
	/// </summary>
	public partial class Operator
	{
		public Operator()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("OID", "Operator"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int OID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Operator");
			strSql.Append(" where OID=@OID");
			SqlParameter[] parameters = {
					new SqlParameter("@OID", SqlDbType.Int,4)
			};
			parameters[0].Value = OID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.Operator model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Operator(");
			strSql.Append("OperatorName,OperatorTEL,OperatorLogoPath,NickName,Address,Longitude,Latitude,UID,Remark)");
			strSql.Append(" values (");
			strSql.Append("@OperatorName,@OperatorTEL,@OperatorLogoPath,@NickName,@Address,@Longitude,@Latitude,@UID,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OperatorName", SqlDbType.NVarChar,50),
					new SqlParameter("@OperatorTEL", SqlDbType.NVarChar,50),
					new SqlParameter("@OperatorLogoPath", SqlDbType.NVarChar,255),
					new SqlParameter("@NickName", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@Longitude", SqlDbType.NVarChar,50),
					new SqlParameter("@Latitude", SqlDbType.NVarChar,50),
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.Text)};
			parameters[0].Value = model.OperatorName;
			parameters[1].Value = model.OperatorTEL;
			parameters[2].Value = model.OperatorLogoPath;
			parameters[3].Value = model.NickName;
			parameters[4].Value = model.Address;
			parameters[5].Value = model.Longitude;
			parameters[6].Value = model.Latitude;
			parameters[7].Value = model.UID;
			parameters[8].Value = model.Remark;

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
		public bool Update(YCF_Server.Model.Operator model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Operator set ");
			strSql.Append("OperatorName=@OperatorName,");
			strSql.Append("OperatorTEL=@OperatorTEL,");
			strSql.Append("OperatorLogoPath=@OperatorLogoPath,");
			strSql.Append("NickName=@NickName,");
			strSql.Append("Address=@Address,");
			strSql.Append("Longitude=@Longitude,");
			strSql.Append("Latitude=@Latitude,");
			strSql.Append("UID=@UID,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where OID=@OID");
			SqlParameter[] parameters = {
					new SqlParameter("@OperatorName", SqlDbType.NVarChar,50),
					new SqlParameter("@OperatorTEL", SqlDbType.NVarChar,50),
					new SqlParameter("@OperatorLogoPath", SqlDbType.NVarChar,255),
					new SqlParameter("@NickName", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@Longitude", SqlDbType.NVarChar,50),
					new SqlParameter("@Latitude", SqlDbType.NVarChar,50),
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@OID", SqlDbType.Int,4)};
			parameters[0].Value = model.OperatorName;
			parameters[1].Value = model.OperatorTEL;
			parameters[2].Value = model.OperatorLogoPath;
			parameters[3].Value = model.NickName;
			parameters[4].Value = model.Address;
			parameters[5].Value = model.Longitude;
			parameters[6].Value = model.Latitude;
			parameters[7].Value = model.UID;
			parameters[8].Value = model.Remark;
			parameters[9].Value = model.OID;

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
		public bool Delete(int OID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Operator ");
			strSql.Append(" where OID=@OID");
			SqlParameter[] parameters = {
					new SqlParameter("@OID", SqlDbType.Int,4)
			};
			parameters[0].Value = OID;

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
		public bool DeleteList(string OIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Operator ");
			strSql.Append(" where OID in ("+OIDlist + ")  ");
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
		public YCF_Server.Model.Operator GetModel(int OID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 OID,OperatorName,OperatorTEL,OperatorLogoPath,NickName,Address,Longitude,Latitude,UID,Remark from Operator ");
			strSql.Append(" where OID=@OID");
			SqlParameter[] parameters = {
					new SqlParameter("@OID", SqlDbType.Int,4)
			};
			parameters[0].Value = OID;

			YCF_Server.Model.Operator model=new YCF_Server.Model.Operator();
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
		public YCF_Server.Model.Operator DataRowToModel(DataRow row)
		{
			YCF_Server.Model.Operator model=new YCF_Server.Model.Operator();
			if (row != null)
			{
				if(row["OID"]!=null && row["OID"].ToString()!="")
				{
					model.OID=int.Parse(row["OID"].ToString());
				}
				if(row["OperatorName"]!=null)
				{
					model.OperatorName=row["OperatorName"].ToString();
				}
				if(row["OperatorTEL"]!=null)
				{
					model.OperatorTEL=row["OperatorTEL"].ToString();
				}
				if(row["OperatorLogoPath"]!=null)
				{
					model.OperatorLogoPath=row["OperatorLogoPath"].ToString();
				}
				if(row["NickName"]!=null)
				{
					model.NickName=row["NickName"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["Longitude"]!=null)
				{
					model.Longitude=row["Longitude"].ToString();
				}
				if(row["Latitude"]!=null)
				{
					model.Latitude=row["Latitude"].ToString();
				}
				if(row["UID"]!=null && row["UID"].ToString()!="")
				{
					model.UID=int.Parse(row["UID"].ToString());
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
			strSql.Append("select OID,OperatorName,OperatorTEL,OperatorLogoPath,NickName,Address,Longitude,Latitude,UID,Remark ");
			strSql.Append(" FROM Operator ");
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
			strSql.Append(" OID,OperatorName,OperatorTEL,OperatorLogoPath,NickName,Address,Longitude,Latitude,UID,Remark ");
			strSql.Append(" FROM Operator ");
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
			strSql.Append("select count(1) FROM Operator ");
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
				strSql.Append("order by T.OID desc");
			}
			strSql.Append(")AS Row, T.*  from Operator T ");
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
			parameters[0].Value = "Operator";
			parameters[1].Value = "OID";
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

