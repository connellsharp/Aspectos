using System;
using System.Collections.Generic;
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

        public string MethodName => _context.MethodName;

        public object ReturnValue => _context.ReturnValue;

        public IEnumerable<IArgument> Arguments => _context.Arguments;

        public IEnumerable<IArgument> Extra => _context.Extra;

        public Task InvokeAsync() => _invokeInnerAsync();
    }
}
