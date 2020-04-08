using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Aspectos
{
    internal class AggregateInvocationContext : IInvocationContext
    {
        private IInvocationContext _context;
        private Func<Task> _invokeInnerAsync;

        public AggregateInvocationContext(IInvocationContext context, Func<Task> invokeAllAsync)
        {
            _context = context;
            _invokeInnerAsync = invokeAllAsync;
        }

        public object Instance => _context.Instance;

        public MethodInfo Method => _context.Method;

        public object ReturnValue => _context.ReturnValue;

        public IEnumerable<IArgument> Arguments => _context.Arguments;

        public IEnumerable<IState> PreStates => _context.PreStates;

        public IEnumerable<IState> PostStates => _context.PostStates;

        public CancellationToken CancellationToken => _context.CancellationToken;

        public Task InvokeAsync() => _invokeInnerAsync();
    }
}
