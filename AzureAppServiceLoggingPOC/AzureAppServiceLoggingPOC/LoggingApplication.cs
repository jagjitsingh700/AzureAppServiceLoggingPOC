using Microsoft.Extensions.Logging;
using System;

namespace AzureAppServiceLoggingPOC
{
    // Dependency Injection of ILogger - Built In Provider & Logging of all LogLevels. 
    public class LoggingApplication
    {
        private readonly ILogger _logger;
        public LoggingApplication(ILogger<LoggingApplication> logger)
        {
            _logger = logger;
        }

        public void LogTrace()
        {
            _logger.LogTrace("Level 0 Initiated - Trace");
        }

        public void LogDebug()
        {
            _logger.LogDebug ("Level 1 Initiated - Debug");
        }

        public void LogInformation()
        {
            _logger.LogInformation("Level 2 Initiated - Information");
        }
        
        public void LogWarning()
        {
            _logger.LogWarning("Level 3 Initiated - Warning");
        }

        public void LogError()
        {
            System.Diagnostics.Trace.TraceError("Level 4 Initiated - Error");

            throw new Exception();

            _logger.LogError("Level 4 Initiated - Error");
        }

        public void LogCritical()
        {
            _logger.LogError("Level 5 Initiated - Critical");
        }
    }
}
