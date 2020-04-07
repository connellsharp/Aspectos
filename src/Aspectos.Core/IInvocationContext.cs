using System.Collections.Generic;

namespace Aspectos
{
    public interface IInvocationContext
    {
        object Instance { get; }

        string MethodName { get; }

        IEnumerable<IArgument> Arguments { get; }

        IEnumerable<IArgument> Extra { get; }
    }
}