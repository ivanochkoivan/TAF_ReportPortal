using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using TAF_ReportPortal_Business;
using TAF_ReportPortal_Configuration.Models;

namespace TAF_ReportPortal_APITests
{
    [Allure.NUnit.AllureNUnit]
    public class CreateDashboardApiTests : BaseTest
    {      
        //Create a dashboard with valid data - check success status code
        [TestCase]
        public void CreateDashboardsWithValidData()
        {
            //Act
            APICalls client = new APICalls();
            string validProjectName = "superadmin_personal";
            var body = new CreateDashboardRequest
            {
                name = $"create_{Guid.NewGuid()}",
                description = "description",
            };
            var response = client.CreateDashboardRequest(validProjectName, body);

            //Check
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        //Create a dashboard with invalid name (more than 128) - check bad request status code
        [TestCase]
        public void CreateDashboardsWithInvalidData()
        {
            //Act
            APICalls client = new APICalls();
            string validProjectName = "superadmin_personal";
            var body = new CreateDashboardRequest
            {
                name = $"Create_Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc nisl justo, tincidunt id pulvinar hendrerit, vehicula in mi libero.",
                description = "description",
            };
            var response = client.CreateDashboardRequest(validProjectName, body);

            //Check
            var responseContent = JsonConvert.DeserializeObject<ApiError>(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            if (responseContent != null)
            {
                Assert.That(responseContent.message, Is.EqualTo("Incorrect Request. [Field 'name' should have size from '3' to '128'.] "));
            }
            else
            {
                Assert.Fail("Response content is null");
            }
        }

        //Create a dashboard with non-existent project name - check not found status code
        [TestCase]
        public void CreateDashboardsWithNonExistentData()
        {
            //Act
            APICalls client = new APICalls();
            string nonExistentProjectName = "nonExistent";
            var body = new CreateDashboardRequest
            {
                name = $"create_{Guid.NewGuid()}",
                description = "description",
            };
            var response = client.CreateDashboardRequest(nonExistentProjectName, body);

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
