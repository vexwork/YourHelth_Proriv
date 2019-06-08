using System;
using NLog;

namespace WebApiApplication.Services.Logging.Implementation
{
    internal class LoggingService : ILoggingService
    {
        protected static Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly Logger _logger = Logger;


        public void LogError(string message, Exception exception)
        {
            _logger.Log(LogLevel.Error, $"{message} {exception}");
        }

        public void Trace(string message)
        {
            _logger.Log(LogLevel.Trace, message);
        }
    }
}