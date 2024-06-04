using NUnit.Framework;
using OpenQA.Selenium;
using TAF_ReportPortal_Configuration;

namespace TAF_ReportPortal_Tests_UiTestsWithAdvancedFeatures
{
    public class BaseTest
    {
        protected Logger Logger { get; private set; }
        protected IWebDriver WebDriver { get; private set; }

        public void LoginWithValidCredentials()
        {
            LoginPage _loginPage = new LoginPage(TestEnvironment.Instance.WebDriver);
            _loginPage.GoToLoginPage();
            _loginPage.EnterUsername(TestEnvironment.Instance.Config.UiTestConfig.Login);
            _loginPage.EnterPassword(TestEnvironment.Instance.Config.UiTestConfig.Password);
            _loginPage.ClickLoginButton();
            WebDriver.Manage().Window.Maximize();
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
            LoginWithValidCredentials();
        }

        [TearDown]
        public void BaseTearDown()
        {
            bool testFailed = TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed;
            if (testFailed)
            {
                try
                {
                    var screenshotName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}";
                    TestEnvironment.Instance.ScreenshotTaker.TakeScreenshot(screenshotName);
                }
                catch (Exception ex)
                {
                    Logger.Log($"Failed to take screenshot: {ex.Message}");
                }
            }

            Logger.Log("TearDown");
            TestEnvironment.Instance.After();
        }
    }
}