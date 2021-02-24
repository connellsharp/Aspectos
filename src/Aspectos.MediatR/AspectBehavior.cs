using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Aspectos.MediatR
{
    public class AspectBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IAspect _aspects;

        public AspectBehavior(IAspect aspects)
        {
            _aspects = aspects;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var invocationContext = new MediatrInvocationContext<TRequest, TResponse>(request, cancellationToken, next);

            await _aspects.InvokeAsync(invocationContext);

            return (TResponse)invocationContext.ReturnValue;
        }
    }
}
