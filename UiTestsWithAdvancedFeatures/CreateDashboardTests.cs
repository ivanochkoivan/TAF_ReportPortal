using NUnit.Framework;

namespace TAF_ReportPortal_Tests_UiTestsWithAdvancedFeatures
{
    [TestFixture]
    public class CreateDashboardTests : BaseTest
    {
        private AllDashboardsPage _dashboardPage;

        [SetUp]
        public void SetUp()
        {
            _dashboardPage = new AllDashboardsPage(WebDriver);
        }

        [Test]
        public void AddNewDashboard_Positive()
        {
            _dashboardPage.GoToDashboards();
            _dashboardPage.ClickAddNewDashboard();
            _dashboardPage.EnterDashboardDetails("TestDashboard", "This is a test dashboard");
            _dashboardPage.ConfirmAddition();
            Assert.That(_dashboardPage.IsDashboardPresent("TestDashboard"), Is.EqualTo(true), "Newly added dashboard should be present.");
        }

        [Test]
        public void AddNewDashboard_Negative()
        {
            _dashboardPage.GoToDashboards();
            _dashboardPage.ClickAddNewDashboard();
            _dashboardPage.EnterDashboardDetails("1", "This is a test dashboard without a name");
            _dashboardPage.ConfirmAddition();

            // You'll need to verify that the addition did not proceed and check for an error message.
            Assert.That(_dashboardPage.IsDashboardPresent("1"), Is.EqualTo(false), "dashboard shouldn`t be presented.");
        }
    }
}