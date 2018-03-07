using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YCF_ServerTo1703
{
    class Program
    {
        static object a = new object();
        //登陆用户SOCKET字典
        private static Dictionary<string, Socket> DictUser = new Dictionary<string, Socket>();
        static Dictionary<string, Socket> dictUser
        {
            get { lock (a) { return DictUser; } }
            set { lock (a) { DictUser = value; } }
        }

        static object b = new object();
        private static Dictionary<string, string> DictSql = new Dictionary<string, string>();
        //机构的Sql字典
        public static Dictionary<string, string> dictSql
        {
            get { lock (b) { return DictSql; } }
            set { lock (b) { dictSql = value; } }
        }

        //socket
        static YCF_ServerTo1703.SocketServer server = new YCF_ServerTo1703.SocketServer();

        static void Main(string[] args)
        {
            Console.WriteLine("YCFServer_1703");


            //数据库连接字符串
            DbHelperSQL.connectionString = "Data Source = 192.168.0.135,1433;Initial Catalog = YCFServer;User Id = sa;Password = sqlpass;";

            Console.WriteLine(DateTime.Now.ToString() + " => Server Starting……");

            //Socket服务
            server.OnReceive += new YCF_ServerTo1703.SocketServer.OnReceive_Delegate(OnReceive);
            server.OnClientClose += new YCF_ServerTo1703.SocketServer.OnClose_Delegate(OnClose);
            ServerToClient.send += new Send_Delegate(sendToClient);

            new Thread(() =>
            {
                server.StartListening(10000);
            }).Start();

            Console.WriteLine(DateTime.Now.ToString() + " => SocketServer ThreadPool:" + YCF_ServerTo1703.SocketServer.min + "-" + YCF_ServerTo1703.SocketServer.max);

            cmd();
        }

        //接收数据处理
        static void OnReceive(Socket handle, string reStr)
        {

            //@@000054["帐号","机构id","方法名","参数1","参数二"]
            //@@000054["18982226637","2","Login","18982226637","123456"]
            Debug.Print("接收到客户端:" + reStr);
            reStr = reStr.Substring(8);
            object[] obj = (object[])Json.JsonToObject(reStr, new object[10]);
            string userID = obj[0].ToString();
            string op_ID = obj[1].ToString();

            if (dictUser.ContainsKey(userID)&&dictSql.ContainsKey(op_ID))
            {
                #region 更新用户字典

                if (dictUser[userID] != handle)
                {
                    try
                    {
                        if (dictUser[userID].Connected)
                        {
                            //强制下线
                            dictUser[userID].Send(Encoding.UTF8.GetBytes(Json.ObjectToJson(new object[] { "CompulsoryDownline", "您的帐号在别处登录，如果非您本人操作，请及时修改密码"})));
                            dictUser[userID].Close();
                        }
                        dictUser[userID].Dispose();
                    }
                    catch { }
                    //更新用户Socket字典
                    dictUser[userID] = handle;
                }

                #endregion
                switch (obj.Length)
                {
                    case 3:
                        new MethodReflection().Call(obj[1].ToString(), obj[0]);
                        break;
                    case 4:
                        new MethodReflection().Call(obj[1].ToString(), obj[0], obj[2]);
                        break;
                    case 5:
                        new MethodReflection().Call(obj[1].ToString(), obj[0], obj[2], obj[3]);
                        break;
                    case 6:
                        new MethodReflection().Call(obj[1].ToString(), obj[0], obj[2], obj[3], obj[4]);
                        break;
                    case 7:
                        new MethodReflection().Call(obj[1].ToString(), obj[0], obj[2], obj[3], obj[4], obj[5]);
                        break;
                    case 8:
                        new MethodReflection().Call(obj[1].ToString(), obj[0], obj[2], obj[3], obj[4], obj[5], obj[6]);
                        break;
                    case 9:
                        new MethodReflection().Call(obj[1].ToString(), obj[0], obj[2], obj[3], obj[4], obj[5], obj[6], obj[7]);
                        break;
                    default:
                        Debug.Print("接收到异常信息:"+ reStr);
                        break;
                }

            }
            else
            {
                dictUser.Add(userID, handle);
                ///@@000054["18982226637","","18982226637","123456"]
                new ServerToClient().Land(obj[2].ToString(),obj[3].ToString());
               // Console.WriteLine(DateTime.Now.ToString() + " => 用户登陆 [" + handle.RemoteEndPoint.ToString() + "]=[" + userID + "]");
            }


        }

        /// <summary>
        /// 连接断开处理
        /// </summary>
        /// <param name="userID"></param>
        static void OnClose(string userID)
        {
            if (dictUser.ContainsKey(userID))
            {
                dictUser.Remove(userID);
            }
            Console.WriteLine(DateTime.Now.ToString() + " => 断开连接 " + userID);
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="sendStr"></param>
        static void sendToClient(string userID, string sendStr)
        {
            sendStr = "@@" + (sendStr.Length + 8).ToString("000000") + sendStr;
            server.Send(dictUser[userID], sendStr);
            Debug.Print("发送给机构端" + userID + ":" + sendStr);
        }

        /// <summary>
        /// 控制台常用指令
        /// </summary>
        static void cmd()
        {
            while (true)
            {
                string cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "cls"://清屏
                        Console.Clear();
                        break;
                    case "exit"://退出
                        server.Stop();
                        System.Environment.Exit(0);
                        break;
                    case "online"://查看在线用户
                        Console.WriteLine("The number of online users:" + dictUser.Count);
                        Console.WriteLine("online User List:");
                        string olStr = "";
                        int x = 1;
                        foreach (string id in dictUser.Keys)
                        {
                            olStr += id + "\t";
                            if (x != 3)
                            {
                                x++;
                            }
                            else
                            {
                                olStr += "\r\n";
                                x = 1;
                            }
                        }
                        Console.WriteLine(olStr);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
