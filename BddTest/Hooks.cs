using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using TAF_ReportPortal_Configuration;
using TechTalk.SpecFlow;

namespace TAF_ReportPortal_BddTest
{
    [Binding]
    public sealed class Hooks
    {

        [BeforeScenario]
        public static void BaseSetUp()
        {
            Logger Log = InitiateLogger();
            Log.Log("SetUp");
            ScenarioContext.Current["Logger"] = Log;

            TestEnvironment.Instance.Before();
            var Driver = TestEnvironment.Instance.WebDriver;
            ScenarioContext.Current["WebDriver"] = Driver;

            //For future impelementation
            //HttpClient = TestEnvironment.Instance.HttpClient;
        }

        [AfterScenario]
        public static void BaseTearDown()
        {
            ScenarioContext.Current.Get<Logger>("Logger").Log("TearDown");

            ScenarioContext.Current.Remove("WebDriver");
            ScenarioContext.Current.Remove("Logger");
            
            TestEnvironment.Instance.After();
        }

        public static Logger InitiateLogger()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder => builder.AddConsole())
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            return new Logger(factory.CreateLogger<Logger>());
        }
    }
}