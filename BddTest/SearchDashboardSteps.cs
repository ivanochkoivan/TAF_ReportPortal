using NUnit.Framework;
using TAF_ReportPortal_Business;
using TAF_ReportPortal_Configuration;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]
namespace TAF_ReportPortal_BddTest
{
    [Binding]
    public class SearchDashboardSteps : BaseStep
    {
        public SearchDashboardSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [When("an User filtering a dashboard with (.*)")]
        public void WhenAnUserCreateADashboardWithData(string filter)
        {
            Menu menu = new Menu(WebDriver);
            menu.GoToDashboardPage();

            AllDashboards allDashboards = new AllDashboards(WebDriver);
            allDashboards.FindDashboardByName(filter);
            ScenarioContext["allDashboards"] = allDashboards;
            ScenarioContext["filter"] = filter;
        }

        [Then("check a result of filtering with (.*)")]
        public void ThenADashboardWasCreated(string expectedResultString)
        {
            var expectedResult = Convert.ToBoolean(expectedResultString);
            AllDashboards allDashboards = ScenarioContext["allDashboards"] as AllDashboards;

            Assert.That(allDashboards.CheckIfDashboardFilteredCorrectly(ScenarioContext["filter"].ToString()), Is.EqualTo(expectedResult));
            Logger.Log($"Assertion for dashboard filtering passed. Expected: {expectedResult}");
        }
    }
}
