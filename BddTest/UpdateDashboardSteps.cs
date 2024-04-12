using NUnit.Framework;
using TAF_ReportPortal_Business;
using TAF_ReportPortal_Configuration;
using TechTalk.SpecFlow;

namespace TAF_ReportPortal_Tests.MsTests
{
    [Binding]
    public class UpdateDashboardSteps : BaseStep
    {
        public UpdateDashboardSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [When("an User update a dashboard with (.*) and (.*)")]
        public void WhenAnUserCreateADashboardWithData(string name, string description)
        {
            Menu menu = new Menu(WebDriver);
            menu.GoToDashboardPage();

            AllDashboards allDashboards = new AllDashboards(WebDriver);
            allDashboards.UpdateDashboard(name, description);
            ScenarioContext["allDashboards"] = allDashboards;
        }

        [Then("check a result of updating with (.*)")]
        public void ThenADashboardWasCreated(string expectedResultString)
        {
            var expectedResult = Convert.ToBoolean(expectedResultString);
            AllDashboards allDashboards = ScenarioContext["allDashboards"] as AllDashboards;
            Assert.That(allDashboards.CheckIfDashboardWasUpdated(), Is.EqualTo(expectedResult));
            Logger.Log($"Assertion for dashboard updateing passed. Expected: {expectedResult}");
        }
    }
}
