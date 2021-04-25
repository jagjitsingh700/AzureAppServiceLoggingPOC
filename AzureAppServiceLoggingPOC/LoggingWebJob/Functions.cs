using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace LoggingWebJob
{
    public class Functions
    {
        public static void ProcessQueueMessage([QueueTrigger("webjobqueue")] string message, ILogger logger)
        {
            var ts = new TraceSource("Diagoutput");

            ts.TraceEvent(TraceEventType.Verbose, 1, $"ProcessQueueMessage verbose trace {message}");
            ts.TraceEvent(TraceEventType.Information, 1, $"ProcessQueueMessage info trace {message}");
            ts.TraceEvent(TraceEventType.Warning, 1, $"ProcessQueueMessage warn trace {message}");
            ts.TraceEvent(TraceEventType.Error, 1, $"ProcessQueueMessage err trace {message}");
            ts.TraceEvent(TraceEventType.Critical, 1, $"ProcessQueueMessage crit trace {message}");

            logger.LogInformation(message);

            Console.WriteLine($"ProcessQueueMessage Console {message}");
            Console.Error.WriteLine($"ProcessQueueMessage Console Error {message}");
        }
    }
}
