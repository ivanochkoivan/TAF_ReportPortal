namespace TAF_ReportPortal_Configuration
{
    public static class StringUtils
    {
        public static string FormatMessage(string message)
        {
            return $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] {message}";
        }
    }
}
