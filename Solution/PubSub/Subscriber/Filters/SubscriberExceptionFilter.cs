using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Subscriber.Filters
{
    public class SubscriberExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<SubscriberExceptionFilter> _logger;

        public SubscriberExceptionFilter(ILogger<SubscriberExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "An unhandled exception occurred.");
            string StackTrace = context.Exception.StackTrace;
            var errorResponse = new
            {
                message = StackTrace,
                StatusCode = 500
            };

            var result = new ObjectResult(errorResponse)
            {
                StatusCode = 500
            };

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
