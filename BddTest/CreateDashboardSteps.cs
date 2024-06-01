using NUnit.Framework;
using TAF_ReportPortal_Business;
using TAF_ReportPortal_Configuration;
using TAF_ReportPortal_Configuration.Utilities;
using TechTalk.SpecFlow;

namespace TAF_ReportPortal_BddTest
{
    [Allure.NUnit.AllureNUnit]
    [Binding]
    public class CreateDashboardSteps : BaseStep
    {
        public CreateDashboardSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [Given("an User successful login")]
        public void GivenAnUserSuccessfulLogin()
        {
            Login();
            Logger.Log("Successful login");
        }

        [When("an User create a dashboard with data")]
        public void WhenAnUserCreateADashboardWithData(Table table)
        {
            var dictionary = Utilities.ToDictionary(table);

            Menu menu = new Menu(WebDriver);
            menu.GoToDashboardPage();

            AllDashboards allDashboards = new AllDashboards(WebDriver);
            allDashboards.CreateNewDashboard(dictionary["name"], dictionary["description"]);
            ScenarioContext["allDashboards"] = allDashboards;
        }

        [Then("a dashboard was created")]
        public void ThenADashboardWasCreated()
        {
            var expectedResult = true;
            CheckThatDashboardCreation(expectedResult);
        }

        [Then("a dashboard wasn`t created")]
        public void ThenADashboardWasntCreated()
        {
            var expectedResult = false;
            CheckThatDashboardCreation(expectedResult);
        }

        private void CheckThatDashboardCreation(bool expectedResult)
        {
            AllDashboards allDashboards = ScenarioContext["allDashboards"] as AllDashboards;
            Assert.That(allDashboards.CheckIfDashboardWasCreated(), Is.EqualTo(expectedResult));
            Logger.Log($"Assertion for dashboard creation passed. Expected: {expectedResult}");
        }
    }
}
