using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TAF_ReportPortal_Business;
using Microsoft.Extensions.Logging;
using TAF_ReportPortal_Configuration;
using TAF_ReportPortal_Tests.MsTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TAF_ReportPortal_Tests.MsTests
{
    [TestClass]
    
    public class DashboardTest : BaseTest
    {
        [TestMethod]
        [DataRow("785785_Create", "!@#$%^&*()_AASSFFFfdfdf", true)]
        [DataRow("45648FSUJdddasdHJHJK_Create", "ShortDescription", true)]
        [DataRow("F@#$%^&*()_Create", " ", true)]
        [DataRow("Create_Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc nisl justo, tincidunt id pulvinar hendrerit, vehicula in mi libero.", "", true)]
        [DataRow("AA", "ShortDescription", false)]
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

            Assert.AreEqual(allDashboards.CheckIfDashboardWasCreated(), expectedResult);
            Logger.Log($"Assertion for dashboard creation passed. Expected: {expectedResult}");
        }

        [TestMethod]
        [DataRow("785", true)]
        [DataRow("#$%", true)]
        [DataRow("SUJddda", true)]
        [DataRow("Non-esistent", true)]
        [DataRow("1", false)]
        public void SearchDashboardFeature(string filter, bool expectedResult)
        {
            try
            {
                Login();
                Logger.Log("Successful login");
            }
            catch (Exception ex) { Logger.LogError("LoginFailed", ex); }

            Menu menu = new Menu(WebDriver);
            menu.GoToDashboardPage();

            AllDashboards allDashboards = new AllDashboards(WebDriver);
            allDashboards.FindDashboardByName(filter);

            Assert.AreEqual(allDashboards.CheckIfDashboardFilteredCorrectly(filter), expectedResult);
            Logger.Log($"Assertion for dashboard filtering passed. Expected: {expectedResult}");
        }

        [TestMethod]
        [DataRow("!HKF:LD<", "UpdatedDescription", true)]
        [DataRow("!p;.d,.d", "", true)]
        [DataRow("!Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc nisl justo, tincidunt id pulvinar hendrerit, vehicula in mi libero.", "UpdatedDescription", true)]
        [DataRow("!H", "", false)]
        [DataRow("existingName", "UpdatedDescription", false)]
        public void UpdateDashboardFeature(string name, string description, bool expectedResult)
        {
            try
            {
                Login();
                Logger.Log("Successful login");
            }
            catch (Exception ex) { Logger.LogError("LoginFailed", ex); }

            Menu menu = new Menu(WebDriver);
            menu.GoToDashboardPage();

            AllDashboards allDashboards = new AllDashboards(WebDriver);
            allDashboards.UpdateDashboard(name, description);

            Assert.AreEqual(allDashboards.CheckIfDashboardWasUpdated(), expectedResult);
            Logger.Log($"Assertion for dashboard filtering passed. Expected: {expectedResult}");
        }
    }
}
