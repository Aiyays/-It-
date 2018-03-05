using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace YCF_Server.DAL
{
	/// <summary>
	/// 数据访问类:Patient
	/// </summary>
	public partial class Patient
	{
		public Patient()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PID", "Patient"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Patient");
			strSql.Append(" where PID=@PID");
			SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.Int,4)
			};
			parameters[0].Value = PID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YCF_Server.Model.Patient model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Patient(");
			strSql.Append("BailorID,Relationship,CheckInTime,OutTime,EmergencyContact,ECTEL,BloodType,Height,UID)");
			strSql.Append(" values (");
			strSql.Append("@BailorID,@Relationship,@CheckInTime,@OutTime,@EmergencyContact,@ECTEL,@BloodType,@Height,@UID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BailorID", SqlDbType.Int,4),
					new SqlParameter("@Relationship", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckInTime", SqlDbType.DateTime),
					new SqlParameter("@OutTime", SqlDbType.DateTime),
					new SqlParameter("@EmergencyContact", SqlDbType.NVarChar,50),
					new SqlParameter("@ECTEL", SqlDbType.NVarChar,50),
					new SqlParameter("@BloodType", SqlDbType.NVarChar,50),
					new SqlParameter("@Height", SqlDbType.NVarChar,50),
					new SqlParameter("@UID", SqlDbType.Int,4)};
			parameters[0].Value = model.BailorID;
			parameters[1].Value = model.Relationship;
			parameters[2].Value = model.CheckInTime;
			parameters[3].Value = model.OutTime;
			parameters[4].Value = model.EmergencyContact;
			parameters[5].Value = model.ECTEL;
			parameters[6].Value = model.BloodType;
			parameters[7].Value = model.Height;
			parameters[8].Value = model.UID;

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
		public bool Update(YCF_Server.Model.Patient model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Patient set ");
			strSql.Append("BailorID=@BailorID,");
			strSql.Append("Relationship=@Relationship,");
			strSql.Append("CheckInTime=@CheckInTime,");
			strSql.Append("OutTime=@OutTime,");
			strSql.Append("EmergencyContact=@EmergencyContact,");
			strSql.Append("ECTEL=@ECTEL,");
			strSql.Append("BloodType=@BloodType,");
			strSql.Append("Height=@Height,");
			strSql.Append("UID=@UID");
			strSql.Append(" where PID=@PID");
			SqlParameter[] parameters = {
					new SqlParameter("@BailorID", SqlDbType.Int,4),
					new SqlParameter("@Relationship", SqlDbType.NVarChar,50),
					new SqlParameter("@CheckInTime", SqlDbType.DateTime),
					new SqlParameter("@OutTime", SqlDbType.DateTime),
					new SqlParameter("@EmergencyContact", SqlDbType.NVarChar,50),
					new SqlParameter("@ECTEL", SqlDbType.NVarChar,50),
					new SqlParameter("@BloodType", SqlDbType.NVarChar,50),
					new SqlParameter("@Height", SqlDbType.NVarChar,50),
					new SqlParameter("@UID", SqlDbType.Int,4),
					new SqlParameter("@PID", SqlDbType.Int,4)};
			parameters[0].Value = model.BailorID;
			parameters[1].Value = model.Relationship;
			parameters[2].Value = model.CheckInTime;
			parameters[3].Value = model.OutTime;
			parameters[4].Value = model.EmergencyContact;
			parameters[5].Value = model.ECTEL;
			parameters[6].Value = model.BloodType;
			parameters[7].Value = model.Height;
			parameters[8].Value = model.UID;
			parameters[9].Value = model.PID;

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
		public bool Delete(int PID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Patient ");
			strSql.Append(" where PID=@PID");
			SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.Int,4)
			};
			parameters[0].Value = PID;

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
		public bool DeleteList(string PIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Patient ");
			strSql.Append(" where PID in ("+PIDlist + ")  ");
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
		public YCF_Server.Model.Patient GetModel(int PID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PID,BailorID,Relationship,CheckInTime,OutTime,EmergencyContact,ECTEL,BloodType,Height,UID from Patient ");
			strSql.Append(" where PID=@PID");
			SqlParameter[] parameters = {
					new SqlParameter("@PID", SqlDbType.Int,4)
			};
			parameters[0].Value = PID;

			YCF_Server.Model.Patient model=new YCF_Server.Model.Patient();
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
		public YCF_Server.Model.Patient DataRowToModel(DataRow row)
		{
			YCF_Server.Model.Patient model=new YCF_Server.Model.Patient();
			if (row != null)
			{
				if(row["PID"]!=null && row["PID"].ToString()!="")
				{
					model.PID=int.Parse(row["PID"].ToString());
				}
				if(row["BailorID"]!=null && row["BailorID"].ToString()!="")
				{
					model.BailorID=int.Parse(row["BailorID"].ToString());
				}
				if(row["Relationship"]!=null)
				{
					model.Relationship=row["Relationship"].ToString();
				}
				if(row["CheckInTime"]!=null && row["CheckInTime"].ToString()!="")
				{
					model.CheckInTime=DateTime.Parse(row["CheckInTime"].ToString());
				}
				if(row["OutTime"]!=null && row["OutTime"].ToString()!="")
				{
					model.OutTime=DateTime.Parse(row["OutTime"].ToString());
				}
				if(row["EmergencyContact"]!=null)
				{
					model.EmergencyContact=row["EmergencyContact"].ToString();
				}
				if(row["ECTEL"]!=null)
				{
					model.ECTEL=row["ECTEL"].ToString();
				}
				if(row["BloodType"]!=null)
				{
					model.BloodType=row["BloodType"].ToString();
				}
				if(row["Height"]!=null)
				{
					model.Height=row["Height"].ToString();
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
			strSql.Append("select PID,BailorID,Relationship,CheckInTime,OutTime,EmergencyContact,ECTEL,BloodType,Height,UID ");
			strSql.Append(" FROM Patient ");
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
			strSql.Append(" PID,BailorID,Relationship,CheckInTime,OutTime,EmergencyContact,ECTEL,BloodType,Height,UID ");
			strSql.Append(" FROM Patient ");
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
			strSql.Append("select count(1) FROM Patient ");
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
				strSql.Append("order by T.PID desc");
			}
			strSql.Append(")AS Row, T.*  from Patient T ");
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
			parameters[0].Value = "Patient";
			parameters[1].Value = "PID";
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

