using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Aspectos.MediatR
{
    public class AspectsBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IAllAspects _aspects;

        public AspectsBehavior(IAllAspects aspects)
        {
            _aspects = aspects;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var invocationContext = new MediatrInvocationContext<TResponse>(request, next);
            return _aspects.InvokeAsync(invocationContext, cancellationToken);
        }
    }
}
