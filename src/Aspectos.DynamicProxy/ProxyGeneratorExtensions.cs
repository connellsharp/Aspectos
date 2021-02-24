using Castle.DynamicProxy;

namespace Aspectos.DynamicProxy
{
    public static class ProxyGeneratorExtensions
    {
        public static T CreateProxyWithAspects<T>(this IProxyGenerator proxyGenerator, T original, params IAspect[] aspects)
            where T : class
        {
            var interceptor = new AspectInterceptor(aspects.Flatten());
            var proxy = proxyGenerator.CreateInterfaceProxyWithTarget<T>(original, interceptor);
            return proxy;
        }
    }
}
