using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using TAF_ReportPortal_Business;
using TAF_ReportPortal_Configuration.Models;

namespace TAF_ReportPortal_APITests
{
    [Allure.NUnit.AllureNUnit]
    public class GetAllDashboardApiTests : BaseTest
    {      
        //Get all dashboards with valid Project name - check success status code
        [TestCase]
        public void GetAllDashboardsWithValidData()
        {
            //Act
            APICalls client = new APICalls();
            string validProjectName = "superadmin_personal";
            var response = client.AllDashboardRequest(validProjectName);

            //Check
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        //Get all dashboards with non-existent Project name - check not found status code
        [TestCase]
        public void GetAllDashboardsWithNonExistentData()
        {
            //Act
            APICalls client = new APICalls();
            string nonExistentProjectName = "nonExistent";
            var response = client.AllDashboardRequest(nonExistentProjectName);

            //Check
            var responseContent = JsonConvert.DeserializeObject<ApiError>(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            if (responseContent != null)
            {
                Assert.That(responseContent.message, Is.EqualTo($"Project '{nonExistentProjectName}' not found. Did you use correct project name?"));
            }
            else
            {
                Assert.Fail("Response content is null");
            }
        }
    }
}
