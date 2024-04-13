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
        protected static Logger Logger
        {
            get { return ScenarioContext.Current.Get<Logger>("Logger"); }
            set { ScenarioContext.Current.Set(value, "Logger"); }
        }
        protected static IWebDriver WebDriver
        {
            get { return ScenarioContext.Current.Get<IWebDriver>("WebDriver"); }
            set { ScenarioContext.Current.Set(value, "WebDriver"); }
        }
        protected HttpClient HttpClient { get; private set; }
        protected ScenarioContext ScenarioContext { get; private set; }

        public BaseStep(ScenarioContext scenarioContext)
        {
            ScenarioContext = scenarioContext;
        }

        public void Login()
        {
            LoginPage loginPage = new LoginPage(WebDriver);
            loginPage.GoToLoginPage();
            loginPage.LoginWithData(TestEnvironment.Instance.Config.UiTestConfig.Login, TestEnvironment.Instance.Config.UiTestConfig.Password);
        }       
    }
}