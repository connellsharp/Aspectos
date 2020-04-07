using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aspectos
{
    public static class AspectExtensions
    {
        public static T Invoke<T>(this IAspect aspect, Func<T> next, IInvocationContext context)
        {
            return aspect.InvokeAsync(() => Task.FromResult(next()), context).Result;
        }

        public static void Invoke(this IAspect aspect, Action next, IInvocationContext context)
        {
            aspect.InvokeAsync<Unit>(() => { next(); return Task.FromResult(Unit.Instance); }, context).Wait();
        }

        public static Task InvokeAsync(this IAspect aspect, Func<Task> next, IInvocationContext context)
        {
            return aspect.InvokeAsync<Unit>(() => { next(); return Task.FromResult(Unit.Instance); }, context);
        }

        public static AggregateAspect Flatten(this IEnumerable<IAspect> aspects)
        {
            return new AggregateAspect(aspects);
        }
    }
}
