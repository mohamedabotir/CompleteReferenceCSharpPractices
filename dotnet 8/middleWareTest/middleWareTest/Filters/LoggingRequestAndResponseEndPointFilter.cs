namespace middleWareTest.Filters
{
    public class LoggingRequestAndResponseEndPointFilter(ILogger<LoggingRequestAndResponseEndPointFilter> _logger) : IEndpointFilter
    {

        public ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            _logger.Log(LogLevel.Information,context.HttpContext.Request.ToString());

            return next(context);
        }
    }
}
