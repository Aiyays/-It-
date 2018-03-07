using System;
using System.Diagnostics;
using System.Reflection;

namespace YCF_ServerTo1703
{
    public abstract class AbstractReflection
    {
        private Type type;
        private object obj;
        protected abstract string strClass { get; }
        private string strMethod;

        /// <summary>
        /// 调用这个方法
        /// </summary>
        /// <param 方法名="MethodName"></param>
        public void Common(string MethodName, object[] objs)
        {
            strMethod = MethodName;
            type = Type.GetType(strClass);
            if (type != null)
            {
                obj = System.Activator.CreateInstance(type);
                MethodInfo method = type.GetMethod(strMethod);
                try
                {
                    method.Invoke(obj, objs);
                }
                catch(Exception e)
                {
                    Debug.Print("未找到接收的方法:"+e);
                }
            }
        }
    }
}
