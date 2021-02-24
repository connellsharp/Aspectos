using Castle.DynamicProxy;

namespace Aspectos.DynamicProxy
{
    internal class AspectsInterceptor : IInterceptor
    {
        private IAllAspects _aspects;

        public AspectsInterceptor(IAllAspects aspects)
        {
            _aspects = aspects;
        }

        public void Intercept(IInvocation invocation)
        {
            _aspects.InvokeAsync(new InterceptorInvocationContext(invocation));
        }
    }
}
