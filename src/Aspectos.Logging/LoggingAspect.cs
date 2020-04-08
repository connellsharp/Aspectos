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
            var logBuilder = _logger.Create(context.Method);

            try
            {
                logBuilder.AddArguments(context.Arguments);
                logBuilder.AddPreStates(context.PreStates);

                try
                {
                    await context.InvokeAsync();
                }
                catch (Exception ex)
                {
                    logBuilder.SetException(ex);
                    throw;
                }

                logBuilder.SetReturnValue(context.ReturnValue);
                logBuilder.AddPostStates(context.PostStates);
            }
            finally
            {
                logBuilder.Write();
            }
        }
    }
}