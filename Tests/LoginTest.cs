using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_ReportPortal.Business;
using WebDriverManager.DriverConfigs.Impl;
using NUnit;
using NUnit.Framework;
using TAF_ReportPortal.Configuration;

namespace TAF_ReportPortal.Tests
{
    [TestFixture]
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
            loginPage.LoginWithData(TestEnvironment.Instance.Config.UiTestConfig.Login, TestEnvironment.Instance.Config.UiTestConfig.Password);
        }
    }
}
