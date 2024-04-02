using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TAF_ReportPortal_Business;
using NUnit.Framework;
using NUnit.Allure.Core;
using Microsoft.Extensions.Logging;
using TAF_ReportPortal_Configuration;

namespace TAF_ReportPortal_Tests
{
    [AllureNUnit]
    [TestFixture]
    public class LoginTest : BaseTest
    {
        [Test] 
        public void Login()
        {
            Logger.Log("Initiate driver");
            LoginPage loginPage = new LoginPage(WebDriver);
            loginPage.GoToLoginPage();
            loginPage.LoginWithData(TestEnvironment.Instance.Config.UiTestConfig.Login, TestEnvironment.Instance.Config.UiTestConfig.Password);
        }
    }
}
