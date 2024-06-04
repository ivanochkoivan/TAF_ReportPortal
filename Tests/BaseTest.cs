using NUnit.Framework;
using OpenQA.Selenium;
using TAF_ReportPortal_Business;
using TAF_ReportPortal_Configuration;
using TechTalk.SpecFlow;

namespace TAF_ReportPortal_Tests
{
    public class BaseTest
    {
        protected Logger Logger { get; private set; }
        protected IWebDriver WebDriver { get; private set; }
        protected HttpClient HttpClient { get; private set; }

        public void Login()
        {
            LoginPage loginPage = new LoginPage(WebDriver);
            loginPage.GoToLoginPage();
            loginPage.LoginWithData(TestEnvironment.Instance.Config.UiTestConfig.Login, TestEnvironment.Instance.Config.UiTestConfig.Password);
        }


        [OneTimeSetUp]
        public void SetupBeforeTestRun()
        {
            TestEnvironment.Instance.BeforeTestSuit();
        }

        [OneTimeTearDown]
        public void AfterTestRun()
        {
            TestEnvironment.Instance.AfterTestSuit();
        }

        [SetUp]
        public void BaseSetUp()
        {
            TestEnvironment.Instance.BeforeUiTests();
            Logger = TestEnvironment.Instance.Logger;           
            Logger.Log("SetUp");           
            WebDriver = TestEnvironment.Instance.WebDriver;            
        }
        [TearDown]
        public void BaseTearDown()
        {
            Logger.Log("TearDown");
            TestEnvironment.Instance.After();
        }


    }
}