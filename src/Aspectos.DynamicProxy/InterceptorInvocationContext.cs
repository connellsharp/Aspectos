using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Aspectos.DynamicProxy
{
    internal class InterceptorInvocationContext : IInvocationContext
    {
        private IInvocation _invocation;

        public InterceptorInvocationContext(IInvocation invocation)
        {
            _invocation = invocation;
        }

        public object Instance => _invocation.InvocationTarget;

        public MethodInfo Method => _invocation.Method;

        public IEnumerable<IArgument> Arguments =>  _invocation.Method.GetParameters()
                                                        .Zip(_invocation.Arguments, KnownArgument.Create);

        public IEnumerable<IState> PreStates => Enumerable.Empty<IState>();

        public IEnumerable<IState> PostStates => Enumerable.Empty<IState>();

        public CancellationToken CancellationToken { get; private set; }

        public Task InvokeAsync()
        {
            CancellationToken = _invocation.Arguments.OfType<CancellationToken>().FirstOrDefault();

            _invocation.Proceed();

            if(_invocation.ReturnValue is Task returnedTask)
                return returnedTask;
            
            return Task.CompletedTask;
        }

        public object ReturnValue
        {
            get
            {
                var returnValue = _invocation.ReturnValue;

                if(returnValue is Task task)
                    return task.GetType().GetProperty("Result").GetValue(task);

                return returnValue;
            }
        }
    }
}
