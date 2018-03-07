using System;
using System.Collections.Generic;
using System.Data;
using YCF_Server.Model;
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
        /// <param name="id"></param>
        /// <param name="pwd"></param>
        public void Land(string id,string pwd)
        {
              



        }

        

    }
}
