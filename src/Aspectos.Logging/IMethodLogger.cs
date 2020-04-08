using System.Reflection;

namespace Aspectos
{
    public interface IMethodLogger
    {
        IMethodLogBuilder Create(MethodInfo methodInfo);
    }
}