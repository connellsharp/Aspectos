using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aspectos
{
    public static class AspectExtensions
    {
        public static void Invoke(this IAspect aspect, IInvocationContext context)
        {
            aspect.InvokeAsync(context).Wait();
        }

        public static AggregateAspect Flatten(this IEnumerable<IAspect> aspects)
        {
            return new AggregateAspect(aspects);
        }
    }
}
