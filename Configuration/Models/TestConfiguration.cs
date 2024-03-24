﻿namespace TAF_ReportPortal.Models
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
        public APITestConfig ApiTestConfig { get; set; }
        public UITestConfig UiTestConfig { get; set; }
    }
}