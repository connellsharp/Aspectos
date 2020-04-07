using System;
using System.Threading.Tasks;

namespace Aspectos
{
    public interface IAspect
    {
        Task<T> InvokeAsync<T>(Func<Task<T>> next, IInvocationContext context);
    }
}
