using System;
using Castle.DynamicProxy;

namespace Aspectos.DynamicProxy
{
    public static class Aspects
    {
        private static ProxyGenerator ProxyGenerator = new ProxyGenerator();

        public static T Apply<T>(T original, params IAspect[] aspects)
            where T : class
        {
            var interceptor = new AspectsInterceptor(new AggregateAspect(aspects));
            var proxy = ProxyGenerator.CreateInterfaceProxyWithTarget<T>(original, interceptor);
            return proxy;
        }
    }
}
