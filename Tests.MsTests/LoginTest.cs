using TAF_ReportPortal_Business;
using Microsoft.Extensions.Logging;
using TAF_ReportPortal_Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TAF_ReportPortal_Tests.MsTests
{
    [TestClass]
    public class LoginTest : BaseTest
    {
        [TestMethod] 
        public void Login()
        {
            Logger.Log("Initiate driver");
            LoginPage loginPage = new LoginPage(WebDriver);
            loginPage.GoToLoginPage();
            loginPage.LoginWithData(TestEnvironment.Instance.Config.UiTestConfig.Login, TestEnvironment.Instance.Config.UiTestConfig.Password);
        }
    }
}
