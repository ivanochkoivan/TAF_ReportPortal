using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using TAF_ReportPortal_Business;
using TAF_ReportPortal_Configuration;
using TechTalk.SpecFlow;

namespace TAF_ReportPortal_Tests
{
    [Binding]
    public class BaseStep
    {
        protected static Logger Logger { get; private set; }
        protected static IWebDriver WebDriver { get; private set; }
        protected HttpClient HttpClient { get; private set; }
        protected ScenarioContext ScenarioContext { get; private set; }

        public BaseStep(ScenarioContext scenarioContext)
        {
            ScenarioContext = scenarioContext;
        }

        public static void InitiateLogger()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder => builder.AddConsole())
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            Logger = new Logger(factory.CreateLogger<Logger>());
        }

        public void Login()
        {
            LoginPage loginPage = new LoginPage(WebDriver);
            loginPage.GoToLoginPage();
            loginPage.LoginWithData(TestEnvironment.Instance.Config.UiTestConfig.Login, TestEnvironment.Instance.Config.UiTestConfig.Password);
        }

        [BeforeScenario]
        public static void BaseSetUp()
        {
            InitiateLogger();
            Logger.Log("SetUp");
            TestEnvironment.Instance.Before();
            WebDriver = TestEnvironment.Instance.WebDriver;
            //HttpClient = TestEnvironment.Instance.HttpClient;
        }

        [AfterScenario]
        public static void BaseTearDown()
        {
            Logger.Log("TearDown");
            TestEnvironment.Instance.After();
        }
    }
}