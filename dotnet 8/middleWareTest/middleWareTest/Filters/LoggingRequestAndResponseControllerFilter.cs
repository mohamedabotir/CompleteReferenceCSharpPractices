using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace middleWareTest.Filters
{
    public class LoggingRequestAndResponseControllerFilter(ILogger<LoggingRequestAndResponseControllerFilter> _logger) : IActionFilter
    {
       
        public void OnActionExecuting(ActionExecutingContext context)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(context.ActionArguments.GetType());
            using StringWriter textWriter = new StringWriter();
             
                xmlSerializer.Serialize(textWriter, context.ActionArguments);
             _logger.Log(LogLevel.Information,textWriter.ToString());


             //JsonSerializer.Deserialize(context.ActionArguments);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(context.Result!.GetType());
            using StringWriter textWriter = new StringWriter();

            xmlSerializer.Serialize(textWriter, context.Result);
            _logger.Log(LogLevel.Information, textWriter.ToString());
        }
    }
}
