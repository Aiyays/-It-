using System;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace YCF_ServerTo1703
{
    public class StateObject
    {
        public Socket workSocket = null;
        public const int BufferSize = 1024 * 100;
        public byte[] buffer = new byte[BufferSize];
        public StringBuilder sb = new StringBuilder();
        public String ip;
        public String id;
        public int port;
        public object pdata = null;
    }

    public class DataInfo
    {
        public Socket workSocket = null;
        public string content;
        public object obtem = null;
    }

    public class SocketServer
    {
        public static object CopyLock = new object();

        public delegate void OnConnect_Delegate(Socket handle, string UserID);
        public delegate void OnClose_Delegate(Socket s);
        public delegate void OnReceive_Delegate(Socket handle, string Content);
        public delegate void Handler(StateObject ds);
        // Thread signal.
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public Handler handlerOnClose;
        public Handler handlerOnConnect;
        /// <summary>
        /// 数据池（存储程序未处理数据）
        /// </summary>
        public static ArrayList dataPool = new ArrayList();
        public static Dictionary<string, Socket> dic_DataPool = new Dictionary<string, Socket>();
        //public static ConcurrentBag<String> dataPool2 = new ConcurrentBag<string>();
        public static int ckTime = 180;

        private static Socket ServerSocket;
        private static bool IsRun = false;
        private static System.Object lockuser = new System.Object();

        //解包KEY标识 
        private const String key = "@@";

        public SocketServer()
        {
            handlerOnClose = new Handler(OnClose);
            handlerOnConnect = new Handler(OnConnect);
            StarThreadPool();
        }

        public void StarThreadPool()
        {
            int maxThreadNum, minThreadNum, portThreadNum;
            ThreadPool.GetMaxThreads(out maxThreadNum, out portThreadNum);
            ThreadPool.GetMinThreads(out minThreadNum, out portThreadNum);
        }

        public void Stop()
        {
            if (IsRun)
            {
                if (ServerSocket.Connected)
                    ServerSocket.Shutdown(SocketShutdown.Both);
                ServerSocket.Close();
                IsRun = false;
            }
        }

        public void StartListening(int port)
        {
            try
            {
                if (IsRun)
                    return;
                IsRun = true;

                IPAddress ipAddress = IPAddress.Any;
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
                ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ServerSocket.Bind(localEndPoint);
                ServerSocket.Listen(100);
                Console.WriteLine("ServerSocket Listen Port:" + port);
                while (true)
                {
                    try
                    {
                        allDone.Reset();
                        SetKeepAlive(ServerSocket, 60000, 1000);//60秒探测客户端是否在线
                        ServerSocket.BeginAccept(new AsyncCallback(AcceptCallBack), ServerSocket);
                        allDone.WaitOne();
                    }
                    catch (Exception ex)
                    {
                        OnClose(ServerSocket);
                        Debug.Print("Listening Ex:" + ex.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                OnClose(ServerSocket);
                Debug.Print("StartListening Exception:" + e.Message + "  " + e.StackTrace);
            }
        }

        /// <summary>
        /// 数据接收回调
        /// </summary>
        /// <param name="ar">Socket 对象</param>
        public void AcceptCallBack(IAsyncResult ar)
        {
            try
            {
                allDone.Set();
                Socket listener = (Socket)ar.AsyncState;//对象转换 
                Socket ClientSocket = listener.EndAccept(ar);
                Console.WriteLine(DateTime.Now.ToString() + " => [" + ClientSocket.RemoteEndPoint.ToString() + "]连接!");

                StateObject state = new StateObject();
                state.workSocket = ClientSocket;
                handlerOnConnect(state);
                ClientSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallBack), state);
            }
            catch (Exception ex)
            {
                OnClose(ServerSocket);
                Debug.Print(DateTime.Now.ToString() + " => AcceptCallback Exception:" + ex.Message);
            }
        }

        /// <summary>
        /// 读取网络数据回调(第一手接收网络数据)
        /// </summary>
        /// <param name="ar"></param>
        public void ReadCallBack(IAsyncResult ar)
        {
            try
            {
                String content = String.Empty;
                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.workSocket;
                int bytesRead = 0;
                try
                {
                    bytesRead = handler.EndReceive(ar);//获取网络数据长度
                }
                catch (Exception ex)
                {
                    Debug.Print(DateTime.Now.ToString() + " => ReadCallBack:" + ex.Message);
                    handlerOnClose(state);//关闭连接
                    return;
                }

                if (bytesRead > 0)
                {
                    content = Encoding.UTF8.GetString(state.buffer, 0, bytesRead);
                    state.sb.Append(content);
                    try
                    {
                        while (content.IndexOf(key) > -1 && content.IndexOf("\r\n") > -1)
                        {
                            int pos = content.IndexOf(key);
                            int end = content.IndexOf("\r\n");
                            if (pos > -1)
                            {
                                //心跳
                                //@@H0002018120170929000001,nowHR=98,nowRESP=23,nowOnBed=Y,nowMove=Y,nowUrine=N, nowTEMP=11,nowSpO2=22,nowBP=33,nowPR=44,nowWeight=55,nowUrineWeight=66\r\n
                                state.sb.Remove(0, end + 2);
                                DataInfo datainfo = new DataInfo();
                                datainfo.workSocket = state.workSocket;
                                datainfo.content = content.Substring(pos, end + 2);
                                string cmdHead = content.Substring(2, 1);
                                switch (cmdHead)
                                {
                                    case "S":
                                        state.id = content.Substring(9, 22);
                                        Send(state.workSocket, "@@A" + content.Substring(3, 6) + "\r\n");
                                        break;
                                    case "H":
                                        state.id = content.Substring(3, 22);
                                        break;
                                    case "A":
                                        state.id = content.Substring(9, 22);
                                        break;
                                }
                                ThreadPool.QueueUserWorkItem(new WaitCallback(TaskProc), datainfo);
                                content = state.sb.ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.Print(DateTime.Now.ToString() + " => 数据解析:" + ex.Message);
                        content = "";
                        state.sb.Clear();
                        handlerOnClose(state);
                    }
                    try
                    {
                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallBack), state);
                    }
                    catch (Exception ex)
                    {
                        Debug.Print(DateTime.Now.ToString() + " => 数据接收回调:[" + state.id + "]" + ex.Message);
                        handlerOnClose(state);
                    }
                }
                else
                {
                    handlerOnClose(state);
                }
            }
            catch (Exception ex)
            {
                Debug.Print(DateTime.Now.ToString() + " => ReadCallBack:" + ex.Message);
            }
        }

        /// <summary>
        /// 定时向远程主机发送连接保持信息
        /// </summary>
        /// <param name="socket">远程连接</param>
        /// <param name="time"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static bool SetKeepAlive(Socket socket, ulong time, ulong interval)
        {
            try
            {
                const int BytesPerLong = 4;
                const int BitsPerByte = 8;

                byte[] inValue = new byte[3 * BytesPerLong];
                var input = new[] { (time == 0 || interval == 0) ? 0UL : 1UL, time, interval };
                for (int i = 0; i < input.Length; i++)
                {
                    inValue[i * BytesPerLong + 3] = (byte)(input[i] >> ((BytesPerLong - 1) * BitsPerByte) & 0xff);
                    inValue[i * BytesPerLong + 2] = (byte)(input[i] >> ((BytesPerLong - 2) * BitsPerByte) & 0xff);
                    inValue[i * BytesPerLong + 1] = (byte)(input[i] >> ((BytesPerLong - 3) * BitsPerByte) & 0xff);
                    inValue[i * BytesPerLong + 0] = (byte)(input[i] >> ((BytesPerLong - 4) * BitsPerByte) & 0xff);
                }

                byte[] outValue = BitConverter.GetBytes(0);
                socket.IOControl(IOControlCode.KeepAliveValues, inValue, outValue);
            }
            catch (SocketException e)
            {
                Debug.Print("Failed to set keep-alive: {0} {1}", e.ErrorCode, e);
                return false;
            }
            return true;
        }

        public void Send(Socket handler, String data)
        {
            if (!handler.Connected)
                return;
            try
            {
                byte[] byteData = Encoding.ASCII.GetBytes(data);
                handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
            }
            catch (Exception ex)
            {
                Debug.Print("Send:" + ex.Message);
            }
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket handler = (Socket)ar.AsyncState;
                int bytesSent = handler.EndSend(ar);
            }
            catch (Exception e)
            {
                Console.WriteLine("SendCallback:" + e.Message);
            }
        }

        private static void OnConnect(StateObject state)
        {
            try
            {
                Socket handler = state.workSocket;
                state.ip = ((System.Net.IPEndPoint)handler.RemoteEndPoint).Address.ToString();
                state.port = ((System.Net.IPEndPoint)handler.RemoteEndPoint).Port;
            }
            catch { }
        }

        public OnConnect_Delegate OnClientConnect;
        public OnClose_Delegate OnClientClose;
        public OnReceive_Delegate OnReceive;

        private void OnClose(StateObject state)
        {
            try
            {
                Socket handler = state.workSocket;
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch { }
            if (OnClientClose != null)
                OnClientClose(state.workSocket);
        }

        private void OnClose(Socket s)
        {
            try
            {
                s.Shutdown(SocketShutdown.Both);
                s.Close();
            }
            catch { }
            if (OnClientClose != null)
                OnClientClose(s);
        }

        static byte Str2Hex(byte Dat1, byte Dat2)
        {
            byte[] Dat = new byte[2];
            Dat[0] = Dat1;
            Dat[1] = Dat2;
            string str = Encoding.ASCII.GetString(Dat);
            return (byte)Convert.ToByte(str, 16);
        }

        void TaskProc(object obdata)
        {
            DataInfo data = (DataInfo)obdata;
            if (OnReceive != null)
                OnReceive(data.workSocket, data.content);
        }
    }
}
