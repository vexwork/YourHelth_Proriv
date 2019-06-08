using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApiApplication.Services.Logging;
using WebApiApplication.Services.Logging.Implementation;

namespace WebApiApplication.Handlers
{
    public class LogRequestAndResponseHandler : DelegatingHandler
    {
        private readonly ILoggingService _loggingService = new LoggingService();


        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("Request: ");
            sb.Append(request.Method);
            if (request.Method == HttpMethod.Post)
            {
                var requestBody = await request.Content.ReadAsStringAsync();
                sb.AppendLine(requestBody);
            }
            else
            {
                sb.AppendLine(request.RequestUri.ToString());
            }

            // let other handlers process the request
            var result = await base.SendAsync(request, cancellationToken);

            if (result.Content != null)
            {
                // once response body is ready, log it
                var responseBody = await result.Content.ReadAsStringAsync();
                sb.AppendLine("Response: ");
                sb.AppendLine(responseBody);
            }

            if (IsNeedLogging(request.RequestUri?.OriginalString))
                _loggingService.Trace(sb.ToString());
            
            return result;
        }

        private bool IsNeedLogging(string originalUrl)
        {
            if (originalUrl == null)
                return false;

            if (originalUrl.Contains("swagger"))
                return false;

            return true;
        }
    }
}