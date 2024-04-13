using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class PublisherExceptionFilter : IExceptionFilter
{
    private readonly ILogger<PublisherExceptionFilter> _logger;

    public PublisherExceptionFilter(ILogger<PublisherExceptionFilter> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "An unhandled exception occurred.");

        var result = new ObjectResult(new { error = "An unexpected error occurred." })
        {
            StatusCode = 500
        };

        context.Result = result;
        context.ExceptionHandled = true;
    }
}