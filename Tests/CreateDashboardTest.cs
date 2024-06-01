using TAF_ReportPortal_Business;
using NUnit.Framework;
using NUnit.Allure.Core;
using TAF_ReportPortal_Configuration;

namespace TAF_ReportPortal_Tests
{
    [AllureNUnit]
    [TestFixture]
    //[Parallelizable(ParallelScope.Fixtures)]
    public class CreateDashboardTest : BaseTest
    {
        [TestCase("785785_Create", "!@#$%^&*()_AASSFFFfdfdf", true)]
        [TestCase("45648FSUJdddasdHJHJK_Create", "ShortDescription", true)]
        [TestCase("F@#$%^&*()_Create", " ", true)]
        [TestCase("Create_Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc nisl justo, tincidunt id pulvinar hendrerit, vehicula in mi libero.", "", true)]
        [TestCase("AA", "ShortDescription", false)]
        public void CreateDashboardFeature(string name, string description, bool expectedResult)
        {

            Login();
            Logger.Log("Successful login");

            Menu menu = new Menu(WebDriver);
            menu.GoToDashboardPage();

            AllDashboards allDashboards = new AllDashboards(WebDriver);
            allDashboards.CreateNewDashboard(name, description);

            Assert.That(allDashboards.CheckIfDashboardWasCreated(), Is.EqualTo(expectedResult));
            Logger.Log($"Assertion for dashboard creation passed. Expected: {expectedResult}");
        }
    } 
}

