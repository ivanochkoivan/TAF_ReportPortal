using NUnit.Framework;
using TAF_ReportPortal_Business.AdvancedFeature;

namespace TAF_ReportPortal_Tests_UiTestsWithAdvancedFeatures
{
    public class AddWidgetTest : BaseTest
    {
        [Test]
        public void VerifyWidgetAddition_Positive()
        {
            
            var allDashboardsPage = new AllDashboardsPage(WebDriver);
            allDashboardsPage.GoToDashboards();

            string dashboardName = "Test Dashboard";
            string dashboardDescription = "Test Description";
           
            allDashboardsPage.DeleteDashboardIfPresent(dashboardName);

            allDashboardsPage.AddNewDashboard(dashboardName, dashboardDescription);

            var dashboardPage = new DashboardPage(WebDriver);

            string widgetName = "Test widget Name";

            dashboardPage.ClickAddNewWidget();
            dashboardPage.SelectOverallStatistics();
            dashboardPage.ClickNextStep();
            dashboardPage.SelectDemoFilter();
            dashboardPage.ClickNextStep();
            dashboardPage.EnterWidgetName(widgetName);
            dashboardPage.ConfirmWidgetAddition();
            
            Assert.That(dashboardPage.IsWidgetPresent(widgetName), Is.True, "The widget was not added successfully.");
        }

        [Test]
        public void VerifyWidgetAddition_Negative()
        {

            var allDashboardsPage = new AllDashboardsPage(WebDriver);
            allDashboardsPage.GoToDashboards();

            string dashboardName = "Test Dashboard";
            string dashboardDescription = "Test Description";

            allDashboardsPage.DeleteDashboardIfPresent(dashboardName);

            allDashboardsPage.AddNewDashboard(dashboardName, dashboardDescription);

            var dashboardPage = new DashboardPage(WebDriver);

            string widgetName = "5";

            dashboardPage.ClickAddNewWidget();
            dashboardPage.SelectOverallStatistics();
            dashboardPage.ClickNextStep();
            dashboardPage.SelectDemoFilter();
            dashboardPage.ClickNextStep();
            dashboardPage.EnterWidgetName(widgetName);
            dashboardPage.ConfirmWidgetAddition();

            Assert.That(dashboardPage.IsWidgetPresent(widgetName), Is.False, "The widget was added successfully.");
        }
    }
}
