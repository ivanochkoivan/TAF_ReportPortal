using NUnit.Framework;
using OpenQA.Selenium;
using TAF_ReportPortal_Business.AdvancedFeature;

namespace TAF_ReportPortal_Tests_UiTestsWithAdvancedFeatures
{
    public class MoveVidgetTests : BaseTest
    {
        [Test]
        public void AddAndRearrangeWidgetsTest()
        {
            var allDashboardsPage = new AllDashboardsPage(WebDriver);
            
            allDashboardsPage.GoToDashboards();

            string dashboardName = "Test Dashboard";
            string dashboardDescription = "This is a test dashboard";
            allDashboardsPage.DeleteDashboardIfPresent(dashboardName);
            allDashboardsPage.AddNewDashboard(dashboardName, dashboardDescription);

            var dashboardPage = new DashboardPage(WebDriver);

            string widgetName1 = "Overall Statistics Widget 1";
            string widgetName2 = "Overall Statistics Widget 2";
            dashboardPage.AddOverallStatisticsWidget(widgetName1);
            dashboardPage.AddOverallStatisticsWidget(widgetName2);

            Assert.That(dashboardPage.IsWidgetPresent(widgetName1), Is.True, "Widget 1 is not present on the dashboard.");
            Assert.That(dashboardPage.IsWidgetPresent(widgetName2), Is.True, "Widget 2 is not present on the dashboard.");

            dashboardPage.DragAndDropFirstWidgetToSecondWidget();

            Assert.That(dashboardPage.IsFirstWidgetBelowSecondWidget(), Is.True, "The first widget is not below the second widget after rearranging.");
        }
    }
}
