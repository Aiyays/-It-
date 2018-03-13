namespace YCF_ServerTo1703
{  /// <summary>
   /// 反射
   /// </summary>
    public class MethodReflection : AbstractReflection
    {
        /// <summary>
        /// 反射的类名
        /// </summary>
        protected override string strClass { get { return "YCF_ServerTo1703.ServerToClient"; } }

        #region 代理的泛型方法

        public void Call(string MethodName) => Common(MethodName, null);

        public void Call(string MethodName, object a) => Common(MethodName, new object[] { a });

        public void Call(string MethodName, object a, object b) => Common(MethodName, new object[] { a, b });

        public void Call(string MethodName, object a, object b, object c) => Common(MethodName, new object[] { a, b, c });

        public void Call(string MethodName, object a, object b, object c, object d) => Common(MethodName, new object[] { a, b, c, d });

        public void Call(string MethodName, object a, object b, object c, object d, object e) => Common(MethodName, new object[] { a, b, c, d, e });

        public void Call(string MethodName, object a, object b, object c, object d, object e, object f) => Common(MethodName, new object[] { a, b, c, d, e, f });

        public void Call(string MethodName, object a, object b, object c, object d, object e, object f, object g) => Common(MethodName, new object[] { a, b, c, d, e, f, g });

        public void Call(string MethodName, object a, object b, object c, object d, object e, object f, object g ,object h) => Common(MethodName, new object[] { a, b, c, d, e, f, g,h });

        #endregion

    }
}
