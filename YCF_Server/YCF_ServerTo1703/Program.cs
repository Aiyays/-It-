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
            private set { lock (b) { dictSql = value; } }
        }

        //socket
        static YCF_ServerTo1703.SocketServer server = new YCF_ServerTo1703.SocketServer();

        static void Main(string[] args)
        {
            Console.WriteLine("YCFServer_1703");


            //数据库连接字符串
            //  DbHelperSQL.connectionString = "Data Source = 192.168.0.135,1433;Initial Catalog = YCFServer;User Id = sa;Password = sqlpass;";

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

            Debug.Print("接收到客户端:" + reStr);
            reStr = reStr.Substring(8);
            object[] obj = (object[])Json.JsonToObject(reStr, new object[10]);
            string userID = obj[0].ToString();
            string op_ID = obj[1].ToString();
            bool control = dictUser.ContainsKey(userID) ? dictUser[userID] == handle ? true : false : false;
            if (control)
            {
                switch (obj.Length)
                {
                    case 3:
                        new MethodReflection().Call(obj[2].ToString(), obj[0],obj[1]);
                        break;
                    case 4:
                        new MethodReflection().Call(obj[2].ToString(), obj[0], obj[1],obj[3]);
                        break;
                    case 5:
                        new MethodReflection().Call(obj[2].ToString(), obj[0], obj[1], obj[3],obj[4]);
                        break;
                    case 6:
                        new MethodReflection().Call(obj[2].ToString(), obj[0], obj[1], obj[3], obj[4],obj[5]);
                        break;
                    case 7:
                        new MethodReflection().Call(obj[2].ToString(), obj[0], obj[1], obj[3], obj[4], obj[5],obj[6]);
                        break;
                    case 8:
                        new MethodReflection().Call(obj[2].ToString(), obj[0], obj[1], obj[3], obj[4], obj[5], obj[6],obj[7]);
                        break;
                    case 9:
                        new MethodReflection().Call(obj[2].ToString(), obj[0], obj[1], obj[3], obj[4], obj[5], obj[6], obj[7],obj[8]);
                        break;
                    default:
                        Debug.Print("接收到无法解析的非法字符串:" + reStr);
                        break;
                }
            }
            else
            {
                new ServerToClient().AskLand(obj[2].ToString(), obj[3].ToString(), ref DictSql,ref DictUser,ref handle);
                Console.WriteLine(DateTime.Now.ToString() + " => 用户尝试登陆 [" + handle.RemoteEndPoint.ToString() + "]=[" + userID + "]");
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
