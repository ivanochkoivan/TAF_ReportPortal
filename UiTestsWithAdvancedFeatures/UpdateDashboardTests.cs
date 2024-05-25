using NUnit.Framework;
using NUnit;

namespace TAF_ReportPortal_Tests_UiTestsWithAdvancedFeatures
{
    [TestFixture]
    public class UpdateDashboardTests : BaseTest
    {
        private AllDashboardsPage _dashboardPage;

        [SetUp]
        public void SetUp()
        {
            _dashboardPage = new AllDashboardsPage(WebDriver);
        }

        [Test]
        public void UpdateDashboard_Positive()
        {
            string dashboardName = $"Test Dashboard {Guid.NewGuid()}";
            string dashboardDescription = "Test Description";

            _dashboardPage.GoToDashboards();

            _dashboardPage.AddNewDashboard(dashboardName, dashboardDescription);
            _dashboardPage.GoToDashboards();
            Assert.That(_dashboardPage.IsDashboardPresent(dashboardName), Is.True, "Dashboard was not added.");

            string dashboardNameUpdated = $"{dashboardName}_Updated";
            string dashboardDescriptionUpdated = $"{dashboardDescription}";

            _dashboardPage.UpdateDashboard(dashboardNameUpdated, dashboardDescriptionUpdated, dashboardName);
            Assert.That(_dashboardPage.IsDashboardPresent(dashboardNameUpdated), Is.True, "Dashboard was not updated.");
        }

        [Test]
        public void UpdateDashboard_Negative()
        {
            string dashboardName = $"Test Dashboard {Guid.NewGuid()}";
            string dashboardDescription = "Test Description";

            _dashboardPage.GoToDashboards();

            _dashboardPage.AddNewDashboard(dashboardName, dashboardDescription);
            _dashboardPage.GoToDashboards();
            Assert.That(_dashboardPage.IsDashboardPresent(dashboardName), Is.True, "Dashboard was not added.");

            string dashboardNameUpdated = $"1";
            string dashboardDescriptionUpdated = $"{dashboardDescription}";

            _dashboardPage.UpdateDashboard(dashboardNameUpdated, dashboardDescriptionUpdated, dashboardName);

            Assert.That(_dashboardPage.IsDashboardPresent(dashboardNameUpdated), Is.False, "Dashboard was not updated.");
        }
    }
}