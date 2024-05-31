using NUnit.Framework;
using TAF_ReportPortal_Business.AdvancedFeature;

namespace TAF_ReportPortal_Tests_UiTestsWithAdvancedFeatures
{
    public class RemoveVidgetTests : BaseTest
    {
        [Test]
        public void TestDeleteWidget()
        {        
            AllDashboardsPage allDashboardsPage = new AllDashboardsPage(WebDriver);
            allDashboardsPage.GoToDashboards();

            
            string dashboardName = "Test Dashboard";
            string dashboardDescription = "Description for Test Dashboard";

            allDashboardsPage.DeleteDashboardIfPresent(dashboardName);
            allDashboardsPage.AddNewDashboard(dashboardName, dashboardDescription);

            DashboardPage dashboardPage = new DashboardPage(WebDriver);

            string widgetName = "Test Widget";
            dashboardPage.AddOverallStatisticsWidget(widgetName);

            Assert.That(dashboardPage.IsWidgetPresent(widgetName), Is.True, "Widget was not added");

            dashboardPage.DeleteWidget(widgetName);

            Assert.That(dashboardPage.IsWidgetPresent(widgetName), Is.False, "Widget was not deleted");
        }
    }
}
