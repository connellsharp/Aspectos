using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aspectos.Mvc
{
    internal class MvcInvocationContext : IInvocationContext
    {
        private ActionExecutingContext _context;
        private ActionExecutedContext _result;
        private ActionExecutionDelegate _next;

        public MvcInvocationContext(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _context = context;
            _next = next;
        }

        public object Instance => _context.Controller;

        public async Task InvokeAsync() => _result = await _next();

        public CancellationToken CancellationToken => CancellationToken.None; // TODO

        public object ReturnValue => _result;

        public IEnumerable<IArgument> Arguments => throw new NotImplementedException();

        public MethodInfo Method => _context.Controller.GetType().GetMethod(_context.ActionDescriptor.DisplayName);

        public IEnumerable<IState> PreStates => throw new NotImplementedException();

        public IEnumerable<IState> PostStates => throw new NotImplementedException();
    }
}
