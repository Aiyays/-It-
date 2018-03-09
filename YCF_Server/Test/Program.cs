using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maticsoft.DBUtility;
namespace Test
{
    public delegate string c();
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static void a()
        {
            Console.WriteLine("我打印了");

        }
        public static string b()
        {
            Console.WriteLine("我没打印");
            return "";
        }
    }
}
/*
 c#只有 assignment、call、increment、decrement 和 new 对象表达式可用作语句
     */
