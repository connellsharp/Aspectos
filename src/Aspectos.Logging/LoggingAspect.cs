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

        public async Task<T> InvokeAsync<T>(Func<Task<T>> next, IInvocationContext context)
        {
            foreach(var argument in context.Arguments)
            {
                _logger.AddProperty();
            }

            T result;

            try
            {
                result = await next();
            }
            catch
            {
                _logger.LogException(ex);
                throw;
            }

            _logger.LogSuccess(result);
            return result;
        }
    }

    public interface IMethodLogger
    {
    }
}