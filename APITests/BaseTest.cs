using NUnit.Framework;
using TAF_ReportPortal_Configuration;

namespace TAF_ReportPortal_APITests
{
    public class BaseTest
    {
        protected Logger? Logger { get; private set; }

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