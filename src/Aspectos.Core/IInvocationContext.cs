using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aspectos
{
    public interface IInvocationContext
    {
        object Instance { get; }

        string MethodName { get; }

        Task InvokeAsync();

        CancellationToken CancellationToken { get; }

        object ReturnValue { get; }

        IEnumerable<IArgument> Arguments { get; }

        IEnumerable<IArgument> Extra { get; }
    }
}