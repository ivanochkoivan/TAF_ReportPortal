using NUnit.Allure.Core;
using NUnit.Framework;
using TAF_ReportPortal_Business;

namespace TAF_ReportPortal_Tests
{
    [AllureNUnit]
    [TestFixture]
    //[Parallelizable(ParallelScope.Fixtures)]
    public class UpdateDashboardTest : BaseTest
    {
        [TestCase("!HKF:LD<", "UpdatedDescription", true)]
        [TestCase("!p;.d,.d", "", true)]
        [TestCase("!Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc nisl justo, tincidunt id pulvinar hendrerit, vehicula in mi libero.", "UpdatedDescription", true)]
        [TestCase("!H", "", false)]
        [TestCase("existingName", "UpdatedDescription", false)]
        public void UpdateDashboardFeature(string name, string description, bool expectedResult)
        {
            Login();
            Logger.Log("Successful login");

            Menu menu = new Menu(WebDriver);
            menu.GoToDashboardPage();

            AllDashboards allDashboards = new AllDashboards(WebDriver);
            allDashboards.UpdateDashboard(name, description);

            Assert.That(allDashboards.CheckIfDashboardWasUpdated(), Is.EqualTo(expectedResult));
            Logger.Log($"Assertion for dashboard filtering passed. Expected: {expectedResult}");
        }
    }
}
