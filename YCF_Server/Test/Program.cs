using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maticsoft.DBUtility;
using System.Drawing;
using System.IO;
using YCF_ServerTo1703;
namespace Test
{
    public delegate string c();
    class Program
    {
        static void Main(string[] args)
        {
            Image a = Json.GetImage(@"C:\Users\Administrator\Desktop\S]68`VZO~{`LBO@WBGO81E9.jpg");
            Json.SaveImage(a, "阿萨德");
            Console.ReadLine();

          

        }



    }
}
/*
 c#只有 assignment、call、increment、decrement 和 new 对象表达式可用作语句
     */
