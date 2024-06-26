﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TAF_ReportPortal_Business;
using TAF_ReportPortal_Configuration;

namespace TAF_ReportPortal_Tests.MsTests
{
    public class BaseTest
    {
        protected Logger Logger { get; private set; }
        protected IWebDriver WebDriver { get; private set; }
        protected HttpClient HttpClient { get; private set; }

        public void InitiateLogger()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder => builder.AddConsole())
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            Logger = new Logger(factory.CreateLogger<Logger>());
        }

        public void Login()
        {
            LoginPage loginPage = new LoginPage(WebDriver);
            loginPage.GoToLoginPage();
            loginPage.LoginWithData(TestEnvironment.Instance.Config.UiTestConfig.Login, TestEnvironment.Instance.Config.UiTestConfig.Password);
        }

        [TestInitialize]
        public void BaseSetUp()
        {
            InitiateLogger();
            Logger.Log("SetUp");
            TestEnvironment.Instance.BeforeUiTests();
            WebDriver = TestEnvironment.Instance.WebDriver;
        }
        [TestCleanup]
        public void BaseTearDown()
        {
            Logger.Log("TearDown");
            TestEnvironment.Instance.After();
        }
    }
}