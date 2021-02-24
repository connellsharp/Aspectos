using Castle.DynamicProxy;

namespace Aspectos.DynamicProxy
{
    public static class Aspects
    {
        private static ProxyGenerator ProxyGenerator = new ProxyGenerator();

        public static T Apply<T>(T original, params IAspect[] aspects)
                    where T : class
        {
            return ProxyGenerator.CreateProxyWithAspects<T>(original, aspects);
        }
    }
}
