using NUnit.Allure.Core;
using NUnit.Framework;
using TAF_ReportPortal_Business;

namespace TAF_ReportPortal_Tests
{
    [AllureNUnit]
    [TestFixture]
    //[Parallelizable(ParallelScope.Fixtures)]
    public class SearchDasboardTest : BaseTest
    {
        [TestCase("785", true)]
        [TestCase("#$%", true)]
        [TestCase("SUJddda", true)]
        [TestCase("Non-esistent", true)]
        [TestCase("1", false)]
        public void SearchDashboardFeature(string filter, bool expectedResult)
        {

            Login();
            Logger.Log("Successful login");

            Menu menu = new Menu(WebDriver);
            menu.GoToDashboardPage();

            AllDashboards allDashboards = new AllDashboards(WebDriver);
            allDashboards.FindDashboardByName(filter);

            Assert.That(allDashboards.CheckIfDashboardFilteredCorrectly(filter), Is.EqualTo(expectedResult));
            Logger.Log($"Assertion for dashboard filtering passed. Expected: {expectedResult}");
        }
    }
}
