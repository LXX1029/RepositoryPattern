using AspNetCore_NlogTest.Contracts;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_NlogTest
{

    public class LoggerManager : ILoggerManager
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }

        public void LogError(string message)
        {
            _logger.Error(message);
        }

        public void LogError(Exception exception)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Message:{exception.Message}");
            builder.AppendLine($"StackTrace".PadRight(100, '='));
            builder.AppendLine($"{exception.StackTrace}");
            builder.AppendLine($"StackTrace".PadRight(100, '='));
            if (exception.InnerException != null)
            {
                builder.AppendLine($"InnerException:{exception.InnerException.Message}");
            }
            _logger.Error(builder.ToString());

        }

        public void LogInfo(string message)
        {
            _logger.Info(message);
        }

        public void LogWarn(string message)
        {
            _logger.Warn(message);
        }
    }
}
