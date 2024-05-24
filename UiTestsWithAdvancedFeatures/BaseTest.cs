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
