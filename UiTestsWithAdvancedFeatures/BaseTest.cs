using NUnit.Framework;
using OpenQA.Selenium;
using TAF_ReportPortal_Business;
using TAF_ReportPortal_Configuration;

namespace TAF_ReportPortal_Tests_UiTestsWithAdvancedFeatures
{
    public class BaseTest
    {
        protected Logger Logger { get; private set; }
        protected IWebDriver WebDriver { get; private set; }

        public void Login()
        {
            LoginPage loginPage = new LoginPage(WebDriver);
            loginPage.GoToLoginPage();
            loginPage.LoginWithData(TestEnvironment.Instance.Config.UiTestConfig.Login, TestEnvironment.Instance.Config.UiTestConfig.Password);
        }

        [SetUp]
        public void BaseSetUp()
        {
            Logger = TestEnvironment.Instance.Logger;
            Logger.Log("SetUp");
            TestEnvironment.Instance.BeforeUiTests();
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
