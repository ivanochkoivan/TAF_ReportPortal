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
    public class DashboardTest : BaseTest
    {
        [TestCase("785", "!@#$%^&*()_AASSFFFfdfdf", true)]
        [TestCase("45648FSUJdddasdHJHJK", "ShortDescription", true)]
        [TestCase("!@#$%^&*()", " ", true)]
        [TestCase("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc nisl justo, tincidunt id pulvinar hendrerit, vehicula in mi libero.", "", true)]
        [TestCase("AA", "ShortDescription", false)]
        public void CreateDashboardFeature(string name, string description, bool expectedResult)
        {
            try
            {
                Login();
                Logger.Log("Successful login");
            } catch (Exception ex) { Logger.LogError("LoginFailed", ex); }

            Menu menu = new Menu(WebDriver);
            menu.GoToDashboardPage();

            AllDashboards allDashboards = new AllDashboards(WebDriver);
            allDashboards.CreateNewDashboard(name, description);

            Assert.That(allDashboards.CheckIfDashboardWasCreated(), Is.EqualTo(expectedResult));
            Logger.Log($"Assertion for dashboard creation passed. Expected: {expectedResult}");
        }
    }
}
