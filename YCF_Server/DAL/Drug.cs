using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:Drug
	/// </summary>
	public partial class Drug
	{
		public Drug()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("DID", "Drug"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Drug");
			strSql.Append(" where DID=@DID");
			SqlParameter[] parameters = {
					new SqlParameter("@DID", SqlDbType.Int,4)
			};
			parameters[0].Value = DID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.Drug model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Drug(");
			strSql.Append("DrugName,Dlevel,ManufactureDate,ValidTime,Price,Specification,DrugSource,InDate,Storagetempera,Manufacturers,Brand,DrugIMG,TID)");
			strSql.Append(" values (");
			strSql.Append("@DrugName,@Dlevel,@ManufactureDate,@ValidTime,@Price,@Specification,@DrugSource,@InDate,@Storagetempera,@Manufacturers,@Brand,@DrugIMG,@TID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DrugName", SqlDbType.NVarChar,50),
					new SqlParameter("@Dlevel", SqlDbType.Int,4),
					new SqlParameter("@ManufactureDate", SqlDbType.DateTime),
					new SqlParameter("@ValidTime", SqlDbType.DateTime),
					new SqlParameter("@Price", SqlDbType.NVarChar,50),
					new SqlParameter("@Specification", SqlDbType.NVarChar,50),
					new SqlParameter("@DrugSource", SqlDbType.NVarChar,50),
					new SqlParameter("@InDate", SqlDbType.DateTime),
					new SqlParameter("@Storagetempera", SqlDbType.NVarChar,50),
					new SqlParameter("@Manufacturers", SqlDbType.NVarChar,50),
					new SqlParameter("@Brand", SqlDbType.NVarChar,50),
					new SqlParameter("@DrugIMG", SqlDbType.NVarChar,255),
					new SqlParameter("@TID", SqlDbType.Int,4)};
			parameters[0].Value = model.DrugName;
			parameters[1].Value = model.Dlevel;
			parameters[2].Value = model.ManufactureDate;
			parameters[3].Value = model.ValidTime;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.Specification;
			parameters[6].Value = model.DrugSource;
			parameters[7].Value = model.InDate;
			parameters[8].Value = model.Storagetempera;
			parameters[9].Value = model.Manufacturers;
			parameters[10].Value = model.Brand;
			parameters[11].Value = model.DrugIMG;
			parameters[12].Value = model.TID;

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
		public bool Update(YCF_Server.Model.Drug model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Drug set ");
			strSql.Append("DrugName=@DrugName,");
			strSql.Append("Dlevel=@Dlevel,");
			strSql.Append("ManufactureDate=@ManufactureDate,");
			strSql.Append("ValidTime=@ValidTime,");
			strSql.Append("Price=@Price,");
			strSql.Append("Specification=@Specification,");
			strSql.Append("DrugSource=@DrugSource,");
			strSql.Append("InDate=@InDate,");
			strSql.Append("Storagetempera=@Storagetempera,");
			strSql.Append("Manufacturers=@Manufacturers,");
			strSql.Append("Brand=@Brand,");
			strSql.Append("DrugIMG=@DrugIMG,");
			strSql.Append("TID=@TID");
			strSql.Append(" where DID=@DID");
			SqlParameter[] parameters = {
					new SqlParameter("@DrugName", SqlDbType.NVarChar,50),
					new SqlParameter("@Dlevel", SqlDbType.Int,4),
					new SqlParameter("@ManufactureDate", SqlDbType.DateTime),
					new SqlParameter("@ValidTime", SqlDbType.DateTime),
					new SqlParameter("@Price", SqlDbType.NVarChar,50),
					new SqlParameter("@Specification", SqlDbType.NVarChar,50),
					new SqlParameter("@DrugSource", SqlDbType.NVarChar,50),
					new SqlParameter("@InDate", SqlDbType.DateTime),
					new SqlParameter("@Storagetempera", SqlDbType.NVarChar,50),
					new SqlParameter("@Manufacturers", SqlDbType.NVarChar,50),
					new SqlParameter("@Brand", SqlDbType.NVarChar,50),
					new SqlParameter("@DrugIMG", SqlDbType.NVarChar,255),
					new SqlParameter("@TID", SqlDbType.Int,4),
					new SqlParameter("@DID", SqlDbType.Int,4)};
			parameters[0].Value = model.DrugName;
			parameters[1].Value = model.Dlevel;
			parameters[2].Value = model.ManufactureDate;
			parameters[3].Value = model.ValidTime;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.Specification;
			parameters[6].Value = model.DrugSource;
			parameters[7].Value = model.InDate;
			parameters[8].Value = model.Storagetempera;
			parameters[9].Value = model.Manufacturers;
			parameters[10].Value = model.Brand;
			parameters[11].Value = model.DrugIMG;
			parameters[12].Value = model.TID;
			parameters[13].Value = model.DID;

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
		public bool Delete(int DID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Drug ");
			strSql.Append(" where DID=@DID");
			SqlParameter[] parameters = {
					new SqlParameter("@DID", SqlDbType.Int,4)
			};
			parameters[0].Value = DID;

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
		public bool DeleteList(string DIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Drug ");
			strSql.Append(" where DID in ("+DIDlist + ")  ");
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
		public YCF_Server.Model.Drug GetModel(int DID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DID,DrugName,Dlevel,ManufactureDate,ValidTime,Price,Specification,DrugSource,InDate,Storagetempera,Manufacturers,Brand,DrugIMG,TID from Drug ");
			strSql.Append(" where DID=@DID");
			SqlParameter[] parameters = {
					new SqlParameter("@DID", SqlDbType.Int,4)
			};
			parameters[0].Value = DID;

			YCF_Server.Model.Drug model=new YCF_Server.Model.Drug();
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
		public YCF_Server.Model.Drug DataRowToModel(DataRow row)
		{
			YCF_Server.Model.Drug model=new YCF_Server.Model.Drug();
			if (row != null)
			{
				if(row["DID"]!=null && row["DID"].ToString()!="")
				{
					model.DID=int.Parse(row["DID"].ToString());
				}
				if(row["DrugName"]!=null)
				{
					model.DrugName=row["DrugName"].ToString();
				}
				if(row["Dlevel"]!=null && row["Dlevel"].ToString()!="")
				{
					model.Dlevel=int.Parse(row["Dlevel"].ToString());
				}
				if(row["ManufactureDate"]!=null && row["ManufactureDate"].ToString()!="")
				{
					model.ManufactureDate=DateTime.Parse(row["ManufactureDate"].ToString());
				}
				if(row["ValidTime"]!=null && row["ValidTime"].ToString()!="")
				{
					model.ValidTime=DateTime.Parse(row["ValidTime"].ToString());
				}
				if(row["Price"]!=null)
				{
					model.Price=row["Price"].ToString();
				}
				if(row["Specification"]!=null)
				{
					model.Specification=row["Specification"].ToString();
				}
				if(row["DrugSource"]!=null)
				{
					model.DrugSource=row["DrugSource"].ToString();
				}
				if(row["InDate"]!=null && row["InDate"].ToString()!="")
				{
					model.InDate=DateTime.Parse(row["InDate"].ToString());
				}
				if(row["Storagetempera"]!=null)
				{
					model.Storagetempera=row["Storagetempera"].ToString();
				}
				if(row["Manufacturers"]!=null)
				{
					model.Manufacturers=row["Manufacturers"].ToString();
				}
				if(row["Brand"]!=null)
				{
					model.Brand=row["Brand"].ToString();
				}
				if(row["DrugIMG"]!=null)
				{
					model.DrugIMG=row["DrugIMG"].ToString();
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
			strSql.Append("select DID,DrugName,Dlevel,ManufactureDate,ValidTime,Price,Specification,DrugSource,InDate,Storagetempera,Manufacturers,Brand,DrugIMG,TID ");
			strSql.Append(" FROM Drug ");
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
			strSql.Append(" DID,DrugName,Dlevel,ManufactureDate,ValidTime,Price,Specification,DrugSource,InDate,Storagetempera,Manufacturers,Brand,DrugIMG,TID ");
			strSql.Append(" FROM Drug ");
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
			strSql.Append("select count(1) FROM Drug ");
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
				strSql.Append("order by T.DID desc");
			}
			strSql.Append(")AS Row, T.*  from Drug T ");
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
			parameters[0].Value = "Drug";
			parameters[1].Value = "DID";
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

