using NUnit.Framework;
using TAF_ReportPortal_Configuration;

namespace TAF_ReportPortal_APITests
{
    public class BaseTest
    {
        protected Logger? Logger { get; private set; }

        [OneTimeSetUp]
        public void SetupBeforeTestRun()
        {
            TestEnvironment.Instance.BeforeTestSuit();
        }

        [OneTimeTearDown]
        public void AfterTestRun()
        {
            TestEnvironment.Instance.AfterTestSuit();
        }

        [SetUp]
        public void BaseSetUp()
        {
            TestEnvironment.Instance.BeforeApiTests();
            Logger = TestEnvironment.Instance.Logger;
            Logger.Log("SetUp");            
        }
        [TearDown]
        public void BaseTearDown()
        {
            Logger?.Log("TearDown");
            TestEnvironment.Instance.After();
        }
    }
}