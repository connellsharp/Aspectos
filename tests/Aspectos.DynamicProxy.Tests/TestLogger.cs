using System.Reflection;

namespace Aspectos.DynamicProxy.Tests
{
    internal class TestLogger : IMethodLogger
    {
        public IMethodLogBuilder Create(MethodInfo methodInfo)
        {
            return new TestLogBuilder(methodInfo);
        }
    }
}
