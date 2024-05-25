using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Extensions.Configuration;
using TAF_ReportPortal_Configuration.Models;
using System.Configuration;
using TechTalk.SpecFlow.Assist;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium.Remote;

namespace TAF_ReportPortal_Configuration
{
    public class TestEnvironment
    {
        private static readonly Lazy<TestEnvironment> instance = new Lazy<TestEnvironment>(() => new TestEnvironment());

        public static TestEnvironment Instance
        {
            get { return instance.Value; }
        }

        public IApiClient ApiClient { get; private set; }
        public IWebDriver WebDriver { get; private set; }
        public TestConfiguration Config { get; }
        public Logger Logger { get; private set; }
        public ScreenshotTaker ScreenshotTaker { get; private set; }

        private TestEnvironment() { 
            Config = InitializeConfiguration();
        }

        private TestConfiguration InitializeConfiguration()
        {
            IConfiguration configuration = ReadConfig();

            return configuration.Get<TestConfiguration>();
        }

        public IConfiguration ReadConfig()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetParent(AppContext.BaseDirectory).FullName, "..", "..", "..", "..", "Configuration", "bin", "Debug", "net8.0"))
                .AddJsonFile("appsettings.json", false)
                .Build();
        }

        public static TestEnvironment Create()
        {
            return new TestEnvironment();
        }

        public void InitializeWebDriver(IWebDriver driver)
        {
            WebDriver = driver;

            if (!Directory.Exists(Constatnt.screenshotsDirectory))
            {
                Directory.CreateDirectory(Constatnt.screenshotsDirectory);
            }
            ScreenshotTaker = new ScreenshotTaker(driver, Constatnt.screenshotsDirectory);
        }

        public void InitiateLogger()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder => builder.AddConsole())
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            Logger = new Logger(factory.CreateLogger<Logger>());
        }

        public void BeforeUiTests()
        {
            InitiateLogger();
            //var webDriver = new ChromeDriver();

            var browserOptions = new ChromeOptions();
            browserOptions.PlatformName = "Windows 11";
            browserOptions.BrowserVersion = "latest";
            var sauceOptions = new Dictionary<string, object>();
            sauceOptions.Add("username", "oauth-rivalkonstyan-1a303");
            sauceOptions.Add("accessKey", "528be141-5718-46b8-a0e5-ac2b9891cd8c");
            sauceOptions.Add("build", "selenium-build-GU857");
            sauceOptions.Add("name", "<your test name>");
            browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

            var uri = new Uri("https://ondemand.eu-central-1.saucelabs.com:443/wd/hub");
            var driver = new RemoteWebDriver(uri, browserOptions);

            TestEnvironment.Instance.InitializeWebDriver(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        public void BeforeApiTests()
        {
            InitiateLogger();
            var services = new ServiceCollection();

            string apiClient = Config.APIClient;

            if (apiClient == "HttpClient")
            {
                services.AddTransient<IApiClient, HttpClientApi>();
            }
            else if (apiClient == "RestClient")
            {
                services.AddTransient<IApiClient, RestSharpApiClient>();
            }

            var serviceProvider = services.BuildServiceProvider();

            ApiClient = serviceProvider.GetService<IApiClient>();
        }

        public void After()
        {
            // teardown HttpClient and WebDriver
            //TestEnvironment.Instance.HttpClient?.Dispose();

            TestEnvironment.Instance.WebDriver?.Quit();
            TestEnvironment.Instance.WebDriver?.Dispose();
        }
    }
}