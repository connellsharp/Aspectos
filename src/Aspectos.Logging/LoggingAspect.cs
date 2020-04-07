using System;
using System.Threading.Tasks;

namespace Aspectos
{
    public class LoggingAspect : IAspect
    {
        private readonly IMethodLogger _logger;

        public LoggingAspect(IMethodLogger logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(IInvocationContext context)
        {
            foreach(var argument in context.Arguments)
            {
                
            }

            try
            {
                await context.InvokeAsync();
            }
            catch
            {
                _logger.LogException(ex);
                throw;
            }

            _logger.LogSuccess(result);
        }
    }

    public interface IMethodLogger
    {
    }
}