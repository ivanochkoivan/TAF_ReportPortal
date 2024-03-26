using Newtonsoft.Json;

namespace TAF_ReportPortal.Configuration
{
    public class Logger
    {
        private string FormatMessage(string message)
        {
            return $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] {message}";
        }

        public void Log(string message)
        {
            Console.WriteLine(FormatMessage(message));
        }

        public void LogJson(object obj)
        {
            string jsonString = JsonConvert.SerializeObject(obj);
            Log(jsonString);
        }

        public void LogError(string message, Exception ex)
        {
            string errorMessage = $"ERROR: {message}. Exception: {ex}";
            Log(errorMessage);
        }
    }
}