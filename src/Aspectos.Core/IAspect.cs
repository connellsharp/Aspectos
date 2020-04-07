using System;
using System.Threading.Tasks;

namespace Aspectos
{
    public interface IAspect
    {
        Task InvokeAsync(IInvocationContext context);
    }
}
