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
        private ScenarioContext scenarioContext;
        public Hooks(ScenarioContext scenarioContext) { 
            this.scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BaseSetUp()
        {
            Logger Log = InitiateLogger();
            Log.Log("SetUp");
            scenarioContext["Logger"] = Log;

            TestEnvironment.Instance.BeforeUiTests();
            var Driver = TestEnvironment.Instance.WebDriver;
            scenarioContext["WebDriver"] = Driver;

            //For future impelementation
            //HttpClient = TestEnvironment.Instance.HttpClient;
        }

        [AfterScenario]
        public void BaseTearDown()
        {
            (scenarioContext["Logger"] as Logger).Log("TearDown");

            scenarioContext.Remove("WebDriver");
            scenarioContext.Remove("Logger");
            
            TestEnvironment.Instance.After();
        }

        public Logger InitiateLogger()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder => builder.AddConsole())
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            return new Logger(factory.CreateLogger<Logger>());
        }
    }
}