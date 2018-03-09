using System;
using System.Collections.Generic;
using System.Data;
using YCF_Server.Model;
using Maticsoft.DBUtility;
using System.Net.Sockets;

namespace YCF_ServerTo1703
{
    /// <summary>
    /// 委托发送数据
    /// </summary>
    /// <param name="UserID"></param>
    /// <param name="jsonStr"></param>
    public delegate void Send_Delegate(string UserID, string jsonStr);
    //  public delegate void dictAddUser_Delegate(string UserID, bool flag);

    class ServerToClient
    {


        //socket发送
        public static Send_Delegate send;

        /// <summary>
        /// 接收到登录的消息
        /// </summary>
        /// 
        /// <param name="user"></param>
        /// <param name="pwd"></param>       
        public void Land(string accounts, string pwd,ref Dictionary<string, string> dictSql,ref Dictionary<string, Socket> dictUser ,ref Socket handl)
        {
            bool flag = false;
            string str = "";
            DataTable userInfoData = new YCF_Server.BLL.UserInfo().GetList("UserTEL='" + accounts + "' and Password='" + pwd + "'").Tables[0];

            ///==>判断是否有满足该条件的行存在
            if (userInfoData.Rows.Count > 0)
            {
                int UID = int.Parse(userInfoData.Rows[0]["UID"].ToString());
                UserInfo userInfoModel = new YCF_Server.BLL.UserInfo().GetModel(UID); //取到个人信息Model
                DataTable user_OperatorData = new YCF_Server.BLL.User_Operator().GetList("UID=" + UID+ " and ISHospitalization=0 ").Tables[0];
                ///==>判断此个人信息是否有所属机构
                if (user_OperatorData.Rows.Count > 0)
                {
                    int OID = int.Parse(user_OperatorData.Rows[0]["OID"].ToString());
                    Operator operatorModel = new YCF_Server.BLL.Operator().GetModel(OID);//取到机构model

                    DataTable operator_LicenseData = new YCF_Server.BLL.Operator_License().GetList("OID=" + OID).Tables[0];
                    DataTable licenseData = operator_LicenseData.Rows.Count > 0 ? new YCF_Server.BLL.OLicense().GetList("LID=" + int.Parse(operator_LicenseData.Rows[0]["LID"].ToString())).Tables[0] : new DataTable();//取到证件地址表


                    if (!dictSql.ContainsKey(OID.ToString()))
                        dictSql.Add(OID.ToString(), DbHelperSQL.BuildSqlDatabase(new YCF_Server.BLL.OperatorDatabase().GetModel(OID)));


                   

            


                }
            }

        }



    }
}
