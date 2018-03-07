using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace YCF_ServerTo1703
{
    public class StateObject
    {
        // Client  socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 1024 * 1000;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
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
        public delegate void OnConnect_Delegate(Socket handle, string UserID);
        public delegate void OnClose_Delegate(string UserID);
        public delegate void OnReceive_Delegate(Socket handle, string Content);
        public delegate void Handler(StateObject ds);
        // Thread signal.
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public Handler handlerOnClose;
        public Handler handlerOnConnect;
        public static int ckTime = 180;

        private static Socket listener;
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

        public static int max, min;

        public void StarThreadPool()
        {
            int maxThreadNum, portThreadNum;
            int minThreadNum;
            ThreadPool.GetMaxThreads(out maxThreadNum, out portThreadNum);
            ThreadPool.GetMinThreads(out minThreadNum, out portThreadNum);
            max = maxThreadNum;
            min = minThreadNum;
        }

        public void Stop()
        {
            if (IsRun)
            {
                if (listener.Connected)
                {
                    listener.Shutdown(SocketShutdown.Both);
                }
                listener.Close();
                listener.Dispose();
                IsRun = false;
            }
        }
        public void StartListening(int port)
        {
            try
            {
                // Data buffer for incoming data.

                if (IsRun)
                {
                    return;
                }

                IPAddress ipAddress = IPAddress.Any;
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
                // Create a TCP/IP socket.
                listener = new Socket(AddressFamily.InterNetwork,
                  SocketType.Stream, ProtocolType.Tcp);

                // Bind the socket to the local endpoint and listen for incoming connections.
                try
                {
                    IsRun = true;
                    listener.Bind(localEndPoint);
                    listener.Listen(100);
                    Console.WriteLine(DateTime.Now.ToString() + " => Server State:Listen");
                    while (true)
                    {
                        // Set the event to nonsignaled state.
                        allDone.Reset();
                        //ACK
                        //SetKeepAlive(listener, 5000, 1000 * 30);
                        // Start an asynchronous socket to listen for connections.
                        listener.BeginAccept(
                            new AsyncCallback(AcceptCallback),
                            listener);
                        // Wait until a connection is made before continuing.
                        allDone.WaitOne();
                    }
                }
                catch (Exception e)
                {
                    Debug.Print(e.ToString());
                }
            }
            catch { }

        }

        public void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                // Signal the main thread to continue.
                allDone.Set();

                // Get the socket that handles the client request.
                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);

                // Create the state object.
                StateObject state = new StateObject();
                state.workSocket = handler;
                handlerOnConnect(state);
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
            }
            catch (Exception ex)
            {
                Debug.Print("AcceptCallback:" + ex.Message);
            }
        }

        public void ReadCallback(IAsyncResult ar)
        {
            try
            {
                String content = String.Empty;
                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.workSocket;
                int bytesRead = 0;
                try
                {
                    bytesRead = handler.EndReceive(ar);
                }
                catch (Exception ex)
                {
                    Debug.Print("ReadCallback->handler.EndReceive:" + ex.Message);
                    OnClose(state);
                    return;
                }

                if (bytesRead > 0)
                {
                    state.sb.Append(Encoding.UTF8.GetString(
                        state.buffer, 0, bytesRead));
                    content = state.sb.ToString();

                    try
                    {
                        while (content.IndexOf(key) > -1)
                        {
                            int pos = content.IndexOf(key);
                            if (pos > -1)
                            {
                                int len = int.Parse(content.Substring(pos + key.Length, 6));
                                state.sb.Remove(0, pos + len);
                                DataInfo datainfo = new DataInfo();
                                datainfo.workSocket = state.workSocket;
                                datainfo.content = content.Substring(pos, len);
                                //@@000054["18982226637","Login","18982226637","123456"]
                                state.id = content.Substring(10, content.IndexOf(",") - 11);
                                ThreadPool.QueueUserWorkItem(new WaitCallback(TaskProc), datainfo);
                                content = state.sb.ToString();
                            }
                        }
                    }
                    catch
                    {
                        content = "";
                        state.sb.Clear();
                    }
                    try
                    {
                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                               new AsyncCallback(ReadCallback), state);
                    }
                    catch (Exception ex)
                    {
                        Debug.Print("ReadCallback:" + ex.Message);
                        OnClose(state);
                        return;

                    }
                }
                else
                {
                    handlerOnClose(state);
                }
            }
            catch { }

        }

        //public static bool SetKeepAlive(Socket socket, ulong time, ulong interval)
        //{
        //    try
        //    {
        //        const int BytesPerLong = 4; // 32 / 8 
        //        const int BitsPerByte = 8;
        //        // Array to hold input values.                                                                           

        //        var input = new[]                                                                                       
        //            {                                                                                        
        //                (time == 0 || interval == 0) ? 0UL : 1UL, // on or off                                                                                    
        //                time,                                                                                      
        //                interval                                                                                 
        //            };
        //        // Pack input into byte struct.         
        //        byte[] inValue = new byte[3 * BytesPerLong];
        //        for (int i = 0; i < input.Length; i++)
        //        {
        //            inValue[i * BytesPerLong + 3] = (byte)(input[i] >> ((BytesPerLong - 1) * BitsPerByte) & 0xff);
        //            inValue[i * BytesPerLong + 2] = (byte)(input[i] >> ((BytesPerLong - 2) * BitsPerByte) & 0xff);
        //            inValue[i * BytesPerLong + 1] = (byte)(input[i] >> ((BytesPerLong - 3) * BitsPerByte) & 0xff);
        //            inValue[i * BytesPerLong + 0] = (byte)(input[i] >> ((BytesPerLong - 4) * BitsPerByte) & 0xff);

        //        }
        //        // Create bytestruct for result (bytes pending on server socket).         
        //        byte[] outValue = BitConverter.GetBytes(0);

        //        // Write SIO_VALS to Socket IOControl.                                                                   
        //        // socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.KeepAlive, true);
        //        socket.IOControl(IOControlCode.KeepAliveValues, inValue, outValue);
        //    }
        //    catch (SocketException e)
        //    {
        //        Console.WriteLine("Failed to set keep-alive: {0} {1}", e.ErrorCode, e);
        //        return false;
        //    }
        //    return true;
        //}
        public void Send(Socket handler, String data)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(data);

            if (!handler.Connected)
            {
                return;
            }
            try
            {
                handler.BeginSend(byteData, 0, byteData.Length, 0,
                    new AsyncCallback(SendCallback), handler);
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
                Debug.Print("SendCallback:" + e.Message);
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
            {
                OnClientClose(state.id);
            }
        }

        //thread job
        void TaskProc(object obdata)
        {
            DataInfo data = (DataInfo)obdata;
            if (OnReceive != null)
            {
                OnReceive(data.workSocket, data.content);
            }
        }
    }
}
