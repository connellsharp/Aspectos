using Castle.DynamicProxy;

namespace Aspectos.DynamicProxy
{
    internal class AspectInterceptor : IInterceptor
    {
        private IAspect _aspect;

        public AspectInterceptor(IAspect aspect)
        {
            _aspect = aspect;
        }

        public void Intercept(IInvocation invocation)
        {
            _aspect.InvokeAsync(new InterceptorInvocationContext(invocation));
        }
    }
}
