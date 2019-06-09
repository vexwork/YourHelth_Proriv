using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using WebApiApplication.Services.Logging;
using WebApiApplication.Services.Logging.Implementation;

namespace WebApiApplication.Filters
{
    public class GlobalExceptionHandlerFilterAttribute : ExceptionFilterAttribute 
    {
        private readonly ILoggingService _loggingService = new LoggingService();
        
        public override void OnException(HttpActionExecutedContext context)
        {
            _loggingService.LogError(context.Exception.Message, context.Exception);
                context.Response = context.Request.CreateErrorResponse(HttpStatusCode.BadRequest, context.Exception.Message);
        }
    }
}