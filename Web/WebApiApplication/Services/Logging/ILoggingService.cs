using System;

namespace WebApiApplication.Services.Logging
{
    public interface ILoggingService
    {
        void LogError(string message, Exception exception);

        void Trace(string message);
    }
}