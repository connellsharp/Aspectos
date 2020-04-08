using System.Threading.Tasks;
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
}
