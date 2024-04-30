
using System.Text;

namespace middleWareTest.MiddleWares
{
    public class LoggingReqAndRespMiddleWare(RequestDelegate _next,ILogger<LoggingReqAndRespMiddleWare> _logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"Received request: {context.Request.Method} {context.Request.Path}");
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            // Call the next middleware
            await _next(context);

            // Log the response
            var response = await FormatResponse(context.Response);
            _logger.LogInformation($"Sent response: {response}");

            // Restore the original response body
            await responseBody.CopyToAsync(originalBodyStream);
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var body = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            var builder = new StringBuilder();
            builder.AppendLine($" {response.StatusCode} succeed");
            foreach (var header in response.Headers)
            {
                builder.AppendLine($"{header.Key}: {header.Value}");
            }
            builder.AppendLine();
            builder.AppendLine(body);

            return builder.ToString();
        }
    }
}
