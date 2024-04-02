using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TAF_ReportPortal_Configuration;

namespace TAF_ReportPortal_Tests.MsTests
{
    public class BaseTest
    {
        protected Logger Logger { get; private set; }
        protected IWebDriver WebDriver { get; private set; }
        protected HttpClient HttpClient { get; private set; }

        public void InitiateLogger()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder => builder.AddConsole())
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            Logger = new Logger(factory.CreateLogger<Logger>());
        }

        [TestInitialize]
        public void BaseSetUp()
        {
            WebDriver = TestEnvironment.Instance.WebDriver;
            HttpClient = TestEnvironment.Instance.HttpClient;

            InitiateLogger();
        }
        [TestCleanup]
        public void BaseTearDown()
        {
            TestEnvironment.Instance.After();
        }
    }
}