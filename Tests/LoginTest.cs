using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TAF_ReportPortal_Business;
using NUnit.Framework;
using TAF_ReportPortal_Configuration;
using NUnit.Allure.Core;
using Microsoft.Extensions.Logging;

namespace TAF_ReportPortal_Tests
{
    [AllureNUnit]
    [TestFixture]
    public class LoginTest : BaseTest
    {
        private IWebDriver driver;

        [Test] 
        public void Login()
        {
            Logger.Log("Initiate driver");
            driver = new ChromeDriver();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.GoToLoginPage();
            loginPage.LoginWithData(TestEnvironment.Instance.Config.UiTestConfig.Login, TestEnvironment.Instance.Config.UiTestConfig.Password);
        }
    }
}
