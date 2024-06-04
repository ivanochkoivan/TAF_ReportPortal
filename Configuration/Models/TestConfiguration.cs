namespace TAF_ReportPortal_Configuration.Models
{
    public class APITestConfig
    {
        public string APIHost { get; set; }
        public string Port { get; set; }
    }

    public class UITestConfig
    {
        public string UIHost { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class TestConfiguration
    {
        public string TeamsWebhookUrl {  get; set; }
        public string APIClient { get; set; }
        public APITestConfig ApiTestConfig { get; set; }
        public UITestConfig UiTestConfig { get; set; }
    }
}