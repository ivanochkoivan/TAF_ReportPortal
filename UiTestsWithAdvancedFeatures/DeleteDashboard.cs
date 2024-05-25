using NUnit.Framework;

namespace TAF_ReportPortal_Tests_UiTestsWithAdvancedFeatures
{
    public class DeleteDashboard : BaseTest
    {
        private DashboardPage _dashboardPage;

        [SetUp]
        public void SetUp()
        {
            _dashboardPage = new DashboardPage(WebDriver);
        }

        [Test]
        public void TestAddAndDeleteDashboard()
        {
            string dashboardName = $"Test Dashboard {Guid.NewGuid()}";
            string dashboardDescription = "Test Description";

            
            _dashboardPage.GoToDashboards();

            
            _dashboardPage.AddNewDashboard(dashboardName, dashboardDescription);
            _dashboardPage.GoToDashboards();
            Assert.That(_dashboardPage.IsDashboardPresent(dashboardName), Is.True, "Dashboard was not added.");

            
            _dashboardPage.DeleteDashboardIfPresent(dashboardName);
            Assert.That(_dashboardPage.IsDashboardPresent(dashboardName), Is.False, "Dashboard was not deleted.");
        }
    }
}
