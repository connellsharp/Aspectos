using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aspectos
{
    public class AggregateAspect : IAllAspects, IAspect
    {
        private readonly IEnumerable<IAspect> _aspects;

        public AggregateAspect(IEnumerable<IAspect> aspects)
        {
            _aspects = aspects;
        }

        public Task InvokeAsync(IInvocationContext context)
        {
            Func<Task> invokeAllAsync = context.InvokeAsync;

            foreach(var aspect in _aspects)
            {
                var invokeInnerAsync = invokeAllAsync;
                invokeAllAsync = () => aspect.InvokeAsync(new AggregateInvocationContext(context, invokeInnerAsync));
            }

            return invokeAllAsync();
        }
    }
}
