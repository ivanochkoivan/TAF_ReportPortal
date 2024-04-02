using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using TAF_ReportPortal_Configuration.Models;

namespace TAF_ReportPortal_Configuration
{
    public class TestEnvironment
    {
        private static readonly Lazy<TestEnvironment> instance = new Lazy<TestEnvironment>(() => new TestEnvironment());

        public static TestEnvironment Instance
        {
            get { return instance.Value; }
        }

        public HttpClient HttpClient { get; private set; }
        public IWebDriver WebDriver { get; private set; }
        public TestConfiguration Config { get; }

        private TestEnvironment() { 
            Config = InitializeConfiguration();
            WebDriver = new ChromeDriver();
            HttpClient = new HttpClient();
        }

        private TestConfiguration InitializeConfiguration()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetParent(AppContext.BaseDirectory).FullName, "..", "..", "..", "..", "Configuration", "bin", "Debug", "net8.0"))
                .AddJsonFile("appsettings.json", false)
                .Build();

            return configuration.Get<TestConfiguration>();
        }

        public static TestEnvironment Create()
        {
            return new TestEnvironment();
        }

        public void InitializeHttpClient(HttpClient client)
        {
            HttpClient = client;
        }

        public void InitializeWebDriver(IWebDriver driver)
        {
            WebDriver = driver;
        }

        public void Before()
        {
            // setup HttpClient and WebDriver
            //var httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri(Config.ApiTestConfig.APIHost);
            //TestEnvironment.Instance.InitializeHttpClient(httpClient);

            var webDriver = new ChromeDriver();
            TestEnvironment.Instance.InitializeWebDriver(webDriver);
        }

        public void After()
        {
            // teardown HttpClient and WebDriver
            TestEnvironment.Instance.HttpClient?.Dispose();

            TestEnvironment.Instance.WebDriver?.Quit();
            TestEnvironment.Instance.WebDriver?.Dispose();
        }
    }
}