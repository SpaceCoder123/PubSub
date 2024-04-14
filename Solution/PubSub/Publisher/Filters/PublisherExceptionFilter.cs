using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.Interfaces;

public class PublisherExceptionFilter : IExceptionFilter
{
    private readonly ILogger<PublisherExceptionFilter> _logger;
    private readonly IAuditService _auditService;

    public PublisherExceptionFilter(ILogger<PublisherExceptionFilter> logger, IAuditService auditService)
    {
        _logger = logger;
        _auditService = auditService;
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "An unhandled exception occurred.");
        string headerMessage = context.HttpContext.Request.Headers["TransactionId"].ToString();
        string StackTrace = context.Exception.StackTrace;
        
        var errorResponse = new
        {
            error = "An unexpected error occurred.",
            message = context.Exception.Message,
            stackTrace = StackTrace
        };

        if(!string.IsNullOrEmpty(StackTrace))
        {
           _auditService.InsertExceptionAudit(StackTrace, headerMessage, "ErrorPublisher");
        }
        
        var result = new ObjectResult(errorResponse)    
        {
            StatusCode = 500
        };
        context.Result = result;
        context.ExceptionHandled = true;
    }
}