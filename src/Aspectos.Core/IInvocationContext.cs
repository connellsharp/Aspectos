using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Aspectos
{
    public interface IInvocationContext
    {
        object Instance { get; }

        MethodInfo Method { get; }

        Task InvokeAsync();

        CancellationToken CancellationToken { get; }

        object ReturnValue { get; }

        IEnumerable<IArgument> Arguments { get; }

        IEnumerable<IState> PreStates { get; }

        IEnumerable<IState> PostStates { get; }
    }
}