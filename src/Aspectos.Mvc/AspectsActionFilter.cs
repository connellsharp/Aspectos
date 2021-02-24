using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aspectos.Mvc
{
    public class AspectsActionFilter : IAsyncActionFilter
    {
        private readonly IAspect _aspects;

        public AspectsActionFilter(IAspect aspects)
        {
            _aspects = aspects;
        }
        
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var invocationContext = new MvcInvocationContext(context, next);
            await _aspects.InvokeAsync(invocationContext);
        }
    }
}
