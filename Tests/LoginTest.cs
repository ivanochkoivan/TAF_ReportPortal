using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TAF_ReportPortal.Business;
using NUnit.Framework;
using TAF_ReportPortal.Configuration;
using NUnit.Allure.Core;

namespace TAF_ReportPortal.Tests
{
    [AllureNUnit]
    //[TestFixture]
    public class LoginTest
    {
        private IWebDriver driver;
        [Test] 
        public void Login()
        {
            Logger loger = new Logger();
            loger.Log("Initiate driver");
            driver = new ChromeDriver();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.GoToLoginPage();
            loginPage.LoginWithData(TestEnvironment.Instance.Config.UiTestConfig.Login, TestEnvironment.Instance.Config.UiTestConfig.Password);
        }
    }
}
