﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using TAF_ReportPortal.Models;

namespace TAF_ReportPortal.Configuration
{
    public class TestEnvironment
    {
        private static readonly Lazy<TestEnvironment> instance = new Lazy<TestEnvironment>(() => new TestEnvironment());

        public static TestEnvironment Instance
        {
            get { return instance.Value; }
        }

        public HttpClient HttpClient { get; private set; }
        public IWebDriver WebDriver { get; private set; }
        public TestConfiguration Config { get; }

        private TestEnvironment() { Config = InitializeConfiguration(); }

        private TestConfiguration InitializeConfiguration()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("Appsettings.json", false)
                .Build();

            return configuration.Get<TestConfiguration>();
        }

        public void InitializeHttpClient(HttpClient client)
        {
            HttpClient = client;
        }

        public void InitializeWebDriver(IWebDriver driver)
        {
            WebDriver = driver;
        }

        [SetUp]
        public void Before()
        {
            // setup HttpClient and WebDriver
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Config.ApiTestConfig.APIHost);
            TestEnvironment.Instance.InitializeHttpClient(httpClient);

            var webDriver = new ChromeDriver();
            TestEnvironment.Instance.InitializeWebDriver(webDriver);
        }

        [TearDown]
        public void After(MethodInfo methodUnderTest)
        {
            // teardown HttpClient and WebDriver
            TestEnvironment.Instance.HttpClient?.Dispose();

            TestEnvironment.Instance.WebDriver?.Quit();
            TestEnvironment.Instance.WebDriver?.Dispose();
        }
    }
}