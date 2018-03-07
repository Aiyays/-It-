using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading;
using System.Timers;

namespace YCF_ServerTo1703
{
    class Program
    {
        /// <summary>
        /// 序列号Socket对应字典
        /// </summary>
        static Dictionary<string, Socket> dictUser = new Dictionary<string, Socket>();
        static object objUser = new object();

        /// <summary>
        ///等应答指令数据 userID,sendStr
        /// </summary>
        static Dictionary<string, string> dictSend = new Dictionary<string, string>();
        static object objSend = new object();

        /// <summary>
        /// Server
        /// </summary>
        static SocketServer server = new SocketServer();

        static void Main(string[] args)
        {
            Console.WriteLine("YCFServer_1705");

            //数据库连接字符串
            Console.WriteLine(DateTime.Now.ToString() + " => Server Starting……");

            //Socket服务
            server.OnReceive += new SocketServer.OnReceive_Delegate(OnReceive);
            server.OnClientClose += new SocketServer.OnClose_Delegate(OnClose);
            new Thread(() =>
            {
                server.StartListening(10001);
            }).Start();

            //定时发送指定直到收到应答数据
            System.Timers.Timer t = new System.Timers.Timer(1000);
            t.Enabled = true;
            t.Elapsed += T_Elapsed;
            t.Start();

            cmd();
        }

        /// <summary>
        /// 定时发送指令数据到设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            //头  流水号    设备码（22个字符）  数据字节数         数据               结束标识
            //@@S 000001 AAAAAA0120170609123456     21     GETADC1=?，SETGPIOA01=1      \r\n
            while (dictSend.Count > 0)
            {
                foreach (string id in dictSend.Keys)
                {
                    try
                    {
                        server.Send(dictUser[id], dictSend[id]);
                    }
                    catch (Exception ex)
                    {
                        Debug.Print(ex.Message);
                        lock (objSend)
                        {
                            dictSend.Remove(id);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 接收数据处理
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="reStr"></param>
        static void OnReceive(Socket handle, string reStr)
        {
            Debug.Print("OnReceive:" + reStr);
            string userID = "";
            string cmdHead = reStr.Substring(2, 1);
            switch (cmdHead)
            {
                case "S":
                    userID = reStr.Substring(9, 22);
                    break;
                case "H":
                    userID = reStr.Substring(3, 22);
                    break;
                case "A":
                    userID = reStr.Substring(9, 22);
                    foreach (string value in dictSend.Values)
                    {
                        if (value.Substring(3, 6) == reStr.Substring(3, 6))
                        {
                            lock (objSend)
                            {
                                dictSend.Remove(userID);
                            }
                        }
                    }
                    break;
            }

            if (dictUser.ContainsKey(userID))
            {
                //用户Socket字典：清理之前的连接
                if (dictUser[userID] != handle)
                {
                    try
                    {
                        if (dictUser[userID].Connected)
                        {
                            dictUser[userID].Close();
                        }
                        dictUser[userID].Dispose();
                    }
                    catch { }
                    lock (objUser)
                    {
                        //更新用户Socket字典
                        dictUser[userID] = handle;
                    }
                }
            }
            else
            {
                lock (objUser)
                {
                    dictUser.Add(userID, handle);
                }
                Console.WriteLine(DateTime.Now.ToString() + " => 设备登陆 [" + handle.RemoteEndPoint.ToString() + "]=[" + userID + "]");
            }
        }

        /// <summary>
        /// 连接断开处理
        /// </summary>
        /// <param name="s"></param>
        static void OnClose(Socket s)
        {
            if (dictUser.ContainsValue(s))
            {
                foreach (string key in dictUser.Keys)
                {
                    if (dictUser[key] == s)
                    {
                        lock (objUser)
                        {
                            dictUser.Remove(key);
                        }
                        Console.WriteLine(DateTime.Now.ToString() + " => 断开连接 " + key);
                    }
                }
            }
        }

        /// <summary>
        /// 控制台指令
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
                    case "online"://查看在线设备
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
                    case "send":
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
