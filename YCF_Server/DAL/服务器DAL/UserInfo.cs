using  System;
using  System.Data;
using  System.Text;
using  System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:UserInfo
	/// </summary>
	public partial class UserInfo
	{
		public UserInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("UID", "UserInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserInfo");
			strSql.Append(" where UID=@UID");
			SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4)
			};
			parameters[0].Value = UID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.UserInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserInfo(");
			strSql.Append("UserName,PicturePath,UserSex,BirthDate,NID,Address,IDNumber,Company,Political_outlook,Education,UserTEL,Maritalstatus,Password,Remark)");
			strSql.Append(" values (");
			strSql.Append("@UserName,@PicturePath,@UserSex,@BirthDate,@NID,@Address,@IDNumber,@Company,@Political_outlook,@Education,@UserTEL,@Maritalstatus,@Password,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PicturePath", SqlDbType.NVarChar,255),
					new SqlParameter("@UserSex", SqlDbType.NVarChar,50),
					new SqlParameter("@BirthDate", SqlDbType.DateTime),
					new SqlParameter("@NID", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,255),
					new SqlParameter("@IDNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@Company", SqlDbType.NVarChar,50),
					new SqlParameter("@Political_outlook", SqlDbType.NVarChar,50),
					new SqlParameter("@Education", SqlDbType.NVarChar,50),
					new SqlParameter("@UserTEL", SqlDbType.NVarChar,50),
					new SqlParameter("@Maritalstatus", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,255),
					new SqlParameter("@Remark", SqlDbType.Text)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.PicturePath;
			parameters[2].Value = model.UserSex;
			parameters[3].Value = model.BirthDate;
			parameters[4].Value = model.NID;
			parameters[5].Value = model.Address;
			parameters[6].Value = model.IDNumber;
			parameters[7].Value = model.Company;
			parameters[8].Value = model.Political_outlook;
			parameters[9].Value = model.Education;
			parameters[10].Value = model.UserTEL;
			parameters[11].Value = model.Maritalstatus;
			parameters[12].Value = model.Password;
			parameters[13].Value = model.Remark;

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
		public bool Update(YCF_Server.Model.UserInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserInfo set ");
			strSql.Append("UserName=@UserName,");
			strSql.Append("PicturePath=@PicturePath,");
			strSql.Append("UserSex=@UserSex,");
			strSql.Append("BirthDate=@BirthDate,");
			strSql.Append("NID=@NID,");
			strSql.Append("Address=@Address,");
			strSql.Append("IDNumber=@IDNumber,");
			strSql.Append("Company=@Company,");
			strSql.Append("Political_outlook=@Political_outlook,");
			strSql.Append("Education=@Education,");
			strSql.Append("UserTEL=@UserTEL,");
			strSql.Append("Maritalstatus=@Maritalstatus,");
			strSql.Append("Password=@Password,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where UID=@UID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PicturePath", SqlDbType.NVarChar,255),
					new SqlParameter("@UserSex", SqlDbType.NVarChar,50),
					new SqlParameter("@BirthDate", SqlDbType.DateTime),
					new SqlParameter("@NID", SqlDbType.Int,4),
					new SqlParameter("@Address", SqlDbType.NVarChar,255),
					new SqlParameter("@IDNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@Company", SqlDbType.NVarChar,50),
					new SqlParameter("@Political_outlook", SqlDbType.NVarChar,50),
					new SqlParameter("@Education", SqlDbType.NVarChar,50),
					new SqlParameter("@UserTEL", SqlDbType.NVarChar,50),
					new SqlParameter("@Maritalstatus", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,255),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@UID", SqlDbType.Int,4)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.PicturePath;
			parameters[2].Value = model.UserSex;
			parameters[3].Value = model.BirthDate;
			parameters[4].Value = model.NID;
			parameters[5].Value = model.Address;
			parameters[6].Value = model.IDNumber;
			parameters[7].Value = model.Company;
			parameters[8].Value = model.Political_outlook;
			parameters[9].Value = model.Education;
			parameters[10].Value = model.UserTEL;
			parameters[11].Value = model.Maritalstatus;
			parameters[12].Value = model.Password;
			parameters[13].Value = model.Remark;
			parameters[14].Value = model.UID;

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
		public bool Delete(int UID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserInfo ");
			strSql.Append(" where UID=@UID");
			SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4)
			};
			parameters[0].Value = UID;

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
		public bool DeleteList(string UIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserInfo ");
			strSql.Append(" where UID in ("+UIDlist + ")  ");
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
		public YCF_Server.Model.UserInfo GetModel(int UID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UID,UserName,PicturePath,UserSex,BirthDate,NID,Address,IDNumber,Company,Political_outlook,Education,UserTEL,Maritalstatus,Password,Remark from UserInfo ");
			strSql.Append(" where UID=@UID");
			SqlParameter[] parameters = {
					new SqlParameter("@UID", SqlDbType.Int,4)
			};
			parameters[0].Value = UID;

			YCF_Server.Model.UserInfo model=new YCF_Server.Model.UserInfo();
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
		public YCF_Server.Model.UserInfo DataRowToModel(DataRow row)
		{
			YCF_Server.Model.UserInfo model=new YCF_Server.Model.UserInfo();
			if (row != null)
			{
				if(row["UID"]!=null && row["UID"].ToString()!="")
				{
					model.UID=int.Parse(row["UID"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["PicturePath"]!=null)
				{
					model.PicturePath=row["PicturePath"].ToString();
				}
				if(row["UserSex"]!=null)
				{
					model.UserSex=row["UserSex"].ToString();
				}
				if(row["BirthDate"]!=null && row["BirthDate"].ToString()!="")
				{
					model.BirthDate=DateTime.Parse(row["BirthDate"].ToString());
				}
				if(row["NID"]!=null && row["NID"].ToString()!="")
				{
					model.NID=int.Parse(row["NID"].ToString());
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["IDNumber"]!=null)
				{
					model.IDNumber=row["IDNumber"].ToString();
				}
				if(row["Company"]!=null)
				{
					model.Company=row["Company"].ToString();
				}
				if(row["Political_outlook"]!=null)
				{
					model.Political_outlook=row["Political_outlook"].ToString();
				}
				if(row["Education"]!=null)
				{
					model.Education=row["Education"].ToString();
				}
				if(row["UserTEL"]!=null)
				{
					model.UserTEL=row["UserTEL"].ToString();
				}
				if(row["Maritalstatus"]!=null)
				{
					model.Maritalstatus=row["Maritalstatus"].ToString();
				}
				if(row["Password"]!=null)
				{
					model.Password=row["Password"].ToString();
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
			strSql.Append("select UID,UserName,PicturePath,UserSex,BirthDate,NID,Address,IDNumber,Company,Political_outlook,Education,UserTEL,Maritalstatus,Password,Remark ");
			strSql.Append(" FROM UserInfo ");
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
			strSql.Append(" UID,UserName,PicturePath,UserSex,BirthDate,NID,Address,IDNumber,Company,Political_outlook,Education,UserTEL,Maritalstatus,Password,Remark ");
			strSql.Append(" FROM UserInfo ");
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
			strSql.Append("select count(1) FROM UserInfo ");
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
				strSql.Append("order by T.UID desc");
			}
			strSql.Append(")AS Row, T.*  from UserInfo T ");
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
			parameters[0].Value = "UserInfo";
			parameters[1].Value = "UID";
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

