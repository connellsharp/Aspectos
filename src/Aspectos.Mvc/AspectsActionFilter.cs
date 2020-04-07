using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspectos;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aspectos.Mvc
{
    public class AspectsActionFilter : IAsyncActionFilter
    {
        private readonly IAllAspects _aspects;

        public AspectsActionFilter(IAllAspects aspects)
        {
            _aspects = aspects;
        }
        
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var invocationContext = new MvcInvocationContext(context, next);
            await _aspects.InvokeAsync(invocationContext);
        }
    }

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

        public string MethodName => _context.ActionDescriptor.DisplayName;

        public async Task InvokeAsync() => _result = await _next();

        public object ReturnValue => _result;

        public IEnumerable<IArgument> Arguments => throw new NotImplementedException();

        public IEnumerable<IArgument> Extra => throw new NotImplementedException();
    }
}
