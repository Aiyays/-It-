using System;
using System.Collections.Generic;
using System.Data;
using YCF_Server.Model;
using Maticsoft.DBUtility;
using System.Net.Sockets;
using System.Diagnostics;
using System.Text;

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

        #region 登录

        /// <summary>
        /// 接收到登录的消息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pwd"></param>       
        public void AskLand(string accounts, string pwd, ref Dictionary<string, string> dictSql, ref Dictionary<string, Socket> dictUser, ref Socket handl)
        {//Json.ObjectToJson(userInfoModel), Json.ObjectToJson(operatorModel), Json.ObjectToJson(roleModel), Json.ObjectToJson(userPrivilegData), Json.ObjectToJson(UserFunctionModuleData) });
            DbHelperSQL.SetSqlDatabase();//打开云服务 数据库

            string userInfoModelJson = "";
            string operatorModelJson = "";
            string roleModleJson = "";
            string userPrivilegDataJson = "";
            string UserFunctionModuleDataJson = "";


            bool flag = false;
            DataTable userInfoData = new YCF_Server.BLL.UserInfo().GetList("UserTEL='" + accounts + "' and Password='" + pwd + "'").Tables[0];

            ///==>判断是否有满足该条件的行存在
            if (userInfoData.Rows.Count > 0)
            {
                int UID = int.Parse(userInfoData.Rows[0]["UID"].ToString());
                UserInfo userInfoModel = new YCF_Server.BLL.UserInfo().GetModel(UID); //取到个人信息Model
                DataTable user_OperatorData = new YCF_Server.BLL.User_Operator().GetList("UID=" + UID + " and ISHospitalization=0 ").Tables[0];
                ///==>判断此个人信息是否有所属机构,且所属为员工
                if (user_OperatorData.Rows.Count > 0)
                {
                    try
                    {
                        userInfoModelJson = Json.ObjectToJson(userInfoModel);

                        int OID = int.Parse(user_OperatorData.Rows[0]["OID"].ToString());
                        Operator operatorModel = new YCF_Server.BLL.Operator().GetModel(OID);//取到机构model

                        operatorModelJson = Json.ObjectToJson(operatorModel);

                        DataTable operator_LicenseData = new YCF_Server.BLL.Operator_License().GetList("OID=" + OID).Tables[0];
                        DataTable licenseData = operator_LicenseData.Rows.Count > 0 ? new YCF_Server.BLL.OLicense().GetList("LID=" + int.Parse(operator_LicenseData.Rows[0]["LID"].ToString())).Tables[0] : new DataTable();//取到证件地址表



                        if (!dictSql.ContainsKey(OID.ToString()))//添加该机构打开数据库的方式
                            dictSql.Add(OID.ToString(), DbHelperSQL.BuildSqlDatabase(new YCF_Server.BLL.OperatorDatabase().GetModel(OID)));

                        DbHelperSQL.SetSqlDatabase(dictSql[OID.ToString()]);//==>打开机构端数据库

                        DataTable userRoleData = new YCF_Server.BLL.UserRole().GetList("UID=" + UID).Tables[0];//取到用户与角色的关联表

                        Role roleModel = new YCF_Server.BLL.Role().GetModel(int.Parse(userRoleData.Rows[0]["RID"].ToString()));//取到角色Model
                        roleModleJson = Json.ObjectToJson(roleModel);

                        DataTable userPrivilegData = new YCF_Server.BLL.UserPrivilege().GetList("RID=" + roleModel.RID).Tables[0];//角色与权限的关联表
                        userPrivilegDataJson = Json.ObjectToJson(userPrivilegData);

                        DataTable UserFunctionModuleData = new YCF_Server.BLL.UserFunctionModule().GetAllList().Tables[0];//取到所有的基础权限
                        UserFunctionModuleDataJson = Json.ObjectToJson(UserFunctionModuleData);


                        flag = true;

                        if (dictUser[accounts] != handl)
                        {
                            try
                            {
                                if (dictUser[accounts].Connected)
                                {
                                    dictUser[accounts].Send(Encoding.UTF8.GetBytes(Json.ObjectToJson(new object[] { "CompulsoryDown", "您的帐号已经在其他地方登陆，如果非您本人操作，请迅速更改您的密码，以确保您信息的安全" })));
                                    dictUser[accounts].Close();
                                }
                                dictUser[accounts].Dispose();
                            }
                            catch { }
                            dictUser[accounts] = handl;
                        }//添加登录成功的信息

                    }
                    catch
                    {
                        Debug.Print("数据库信息不完整，导致查询出错，请将数据库补充完整");
                    }

                }

                send(accounts, Json.ObjectToJson(new object[] { "Land", flag, userInfoModelJson, operatorModelJson, roleModleJson, userPrivilegDataJson, UserFunctionModuleDataJson }));
            }

        }

        #endregion

        #region 接待管理

        #region 个人接待

        /// <summary>
        /// 判断能否入院
        /// </summary>
        /// <param name="IdCard"></param>
        public void AskDecideCheck(string accounts, string OID, string IdCard)
        {

            bool flag = false;

            string userInfoModelJson = "";
            string patientModelJson = "";
            DbHelperSQL.SetSqlDatabase();//开启服务器数据库
            DataTable userInfoData = new YCF_Server.BLL.UserInfo().GetList("IDNumber='" + IdCard + "'").Tables[0];
            if (userInfoData.Rows.Count != 0)//如果有个人信息
            {
                int UID = int.Parse(userInfoData.Rows[0]["UID"].ToString());

                DataTable user_OperatorData = new YCF_Server.BLL.User_Operator().GetList("UID=" + UID + " and ISHospitalization=1").Tables[0];
                if (user_OperatorData.Rows.Count == 0)//与机构无关 非员工 或者未出院的病人
                {
                    flag = true;
                    userInfoModelJson = Json.ObjectToJson(new YCF_Server.BLL.UserInfo().GetModel(int.Parse(userInfoData.Rows[0][UID].ToString())));
                    DataTable user_operaData = new YCF_Server.BLL.User_Operator().GetList("UID=" + UID + " and ISHospitalization=1").Tables[0];
                    if (user_operaData.Rows.Count != 0)//是否有过病历卡
                    {
                        int P_OID = int.Parse(user_operaData.Rows[0]["OID"].ToString());
                        DbHelperSQL.SetSqlDatabase(Program.dictSql.ContainsKey(P_OID.ToString()) ? Program.dictSql[P_OID.ToString()] : DbHelperSQL.BuildSqlDatabase(new YCF_Server.BLL.OperatorDatabase().GetModel(P_OID)));

                        DataTable patientData = new YCF_Server.BLL.Patient().GetList("UID=" + UID).Tables[0];

                        patientModelJson = Json.ObjectToJson(new YCF_Server.BLL.Patient().GetModel(int.Parse(patientData.Rows[0]["PID"].ToString())));
                    }
                }


            }
            // DbHelperSQL.SetSqlDAtabase(Program.dictSql[OID.ToString()]);//开启机构端数据库
            send(accounts, Json.ObjectToJson(new object[] { "DecideCheck", flag, userInfoModelJson, patientModelJson }));
        }


        /// <summary>
        /// 入院登记管理
        /// </summary>
        /// <param name="account"></param>
        /// <param name="OID"></param>
        /// <param name="userInfoModelJson"></param>
        /// <param name="patientModelJson"></param>
        /// <param name="BailorInfoModelJson"></param>
        /// <param name="privetGoodDataJson"></param>
        public void AskCheck(string account, string OID, string userInfoModelJson, string patientModelJson, string bailorInfoModelJson, string privetGoodModelListJson)
        {
            DbHelperSQL.SetSqlDatabase();//开启云服务数据库
            bool flag = false;
            int UID = 0;
            int bailorUID = 0;

            try
            {
                //==>表的解析
                UserInfo userInfoModel = Json.JsonToObject<UserInfo>(userInfoModelJson, new UserInfo());
                UserInfo bailorInfoModel = Json.JsonToObject<UserInfo>(bailorInfoModelJson, new UserInfo());
                Patient patientModel = Json.JsonToObject<Patient>(patientModelJson, new Patient());
                List<string> listPrivateModeJson = Json.JsonToObject<List<string>>(privetGoodModelListJson, new List<string>());

                AddUpdates(ref UID, ref userInfoModel); //添加老人信息
                AddUpdates(ref bailorUID, ref bailorInfoModel);//添加委托人信息

                new YCF_Server.BLL.User_Operator().Add(new User_Operator() //添加 老人 与 机构的关联表
                {
                    ISHospitalization = 1,
                    OID = int.Parse(OID),
                    UID = UID,
                });

                patientModel.UID = UID;
                patientModel.BailorID = bailorUID;
                DbHelperSQL.SetSqlDatabase(Program.dictSql.ContainsKey(OID) ? Program.dictSql[OID] : DbHelperSQL.BuildSqlDatabase(new YCF_Server.BLL.OperatorDatabase().GetModel(int.Parse(OID))));//打开相应机构的数据库

                new YCF_Server.BLL.Patient().Add(patientModel);

                int PID = int.Parse(new YCF_Server.BLL.Patient().GetList("OutTime is null and  UID=" + UID ).Tables[0].Rows[0]["PID"].ToString());//病人表ID

                if (Json.JsonToObject<PrivateGoods>(listPrivateModeJson[0], new PrivateGoods()).Name != null)
                {
                    foreach (string item in listPrivateModeJson)
                    {
                        PrivateGoods privateGoodsModel = Json.JsonToObject<PrivateGoods>(item, new PrivateGoods());
                        privateGoodsModel.ParID = PID;
                        new YCF_Server.BLL.PrivateGoods().Add(privateGoodsModel);
                    }
                }//添加私人物品

                flag = true;
            }
            catch  //解析收到的数据
            {
                Debug.Print("入院登记失败 请稍后再试");
                flag = false;
            }
            finally
            {
                send(account, Json.ObjectToJson(new object[] { "Check", flag }));
            }
        }
        /// <summary>
        /// 对个人信息的快速添加或更新
        /// </summary>
        /// <param name="UID"></param>
        /// <param name="userInfoModel"></param>
        private void AddUpdates(ref int UID, ref UserInfo userInfoModel)
        {
            if (userInfoModel.UID == 0)//没有Id  需要添加
            {
                new YCF_Server.BLL.UserInfo().Add(userInfoModel);
                UID = int.Parse(new YCF_Server.BLL.UserInfo().GetList("IDNumber='" + userInfoModel.IDNumber + "'").Tables[0].Rows[0]["UID"].ToString());
            }
            else//有ID  需要更新
            {
                new YCF_Server.BLL.UserInfo().Update(userInfoModel);
                UID = userInfoModel.UID;
            }
        }
        

        /// <summary>
        /// 添加入院时老人的相关照片
        /// </summary>
        /// <param name="account"></param>
        /// <param name="OID"></param>
        /// <param 身份证前照="fImageJson"></param>
        /// <param 身份证后照="bImageJson"></param>
        /// <param 头像="headImageJson"></param>
        /// <param 体检报告单="medicalExaminationReportImageJson"></param>
        public void AskAddPhoto(string account,string OID,string fImageJson,string bImageJson,string headImageJson,string medicalExaminationReportImageJson)
        {

        }




        #endregion


        #endregion







    }
}
