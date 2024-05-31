using Microsoft.Extensions.Logging;
using TAF_ReportPortal_Configuration.Utilities;

namespace TAF_ReportPortal_Configuration
{
    public class Logger
    {
        private readonly ILogger _logger;

        public Logger(ILogger<Logger> logger)
        {
            _logger = logger;
        }

        public void Log(string message)
        {
            _logger.LogInformation(StringUtils.FormatMessage(message));
        }

        public void LogJson(object obj)
        {
            string jsonString = System.Text.Json.JsonSerializer.Serialize(obj);
            Log(jsonString);
        }

        public void LogError(string message, Exception ex)
        {
            string errorMessage = StringUtils.FormatMessage($"ERROR: {message}. Exception: {ex}");
            _logger.LogError(ex, errorMessage);
        }

    }
}