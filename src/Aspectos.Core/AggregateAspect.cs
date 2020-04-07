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

        public Task<T> InvokeAsync<T>(Func<Task<T>> next, IInvocationContext context)
        {
            foreach(var aspect in _aspects)
            {
                next = () => aspect.InvokeAsync(next, context);
            }

            return next();
        }
    }
}
