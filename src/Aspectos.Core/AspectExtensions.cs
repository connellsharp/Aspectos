using System.Collections.Generic;

namespace Aspectos
{
    public static class AspectExtensions
    {
        public static void Invoke(this IAspect aspect, IInvocationContext context)
        {
            aspect.InvokeAsync(context).GetAwaiter().GetResult();
        }

        public static AggregateAspect Flatten(this IEnumerable<IAspect> aspects)
        {
            return new AggregateAspect(aspects);
        }
    }
}
