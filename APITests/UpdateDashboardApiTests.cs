using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using TAF_ReportPortal_Business;
using TAF_ReportPortal_Configuration.Models;

namespace TAF_ReportPortal_APITests
{
    [Allure.NUnit.AllureNUnit]
    public class UpdateDashboardApiTests : BaseTest
    {      
        //Update a dashboard with valid data - check success status code
        [TestCase]
        public void UpdateDashboardsWithValidData()
        {
            //Before
            APICalls client = new APICalls();
            string validProjectName = "superadmin_personal";
            var bodyBefore = new CreateDashboardRequest
            {
                name = $"create_{Guid.NewGuid()}",
                description = "description",
            };
            var responseBefore = client.CreateDashboardRequest(validProjectName, bodyBefore);
            var responseContentBefore = JsonConvert.DeserializeObject<CreateDashboardResponse>(responseBefore.Content);
            int dashboardId = 0;
            if (responseContentBefore != null)
            {
                dashboardId = responseContentBefore.id;
            }
            else
            {
                Assert.Fail("Response content is null");
            }
            //Act
            var body = new CreateDashboardRequest
            {
                name = $"create_{Guid.NewGuid()}_Updated",
                description = "description_Updated",
            };
            var response = client.UpdateDashboardRequest(validProjectName, body, dashboardId.ToString());

            //Check
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        //Create a dashboard with invalid name (more than 128) - check bad request status code
        [TestCase]
        public void UpdateDashboardsWithInValidData()
        {
            //Act
            APICalls client = new APICalls();
            string validProjectName = "superadmin_personal";
            var body = new CreateDashboardRequest
            {
                name = $"Create_Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc nisl justo, tincidunt id pulvinar hendrerit, vehicula in mi libero.",
                description = "description_Updated",
            };
            var response = client.UpdateDashboardRequest(validProjectName, body, "1");

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
        public void UpdateDashboardsWithNonExistentData()
        {
            //Act
            APICalls client = new APICalls();
            string nonExistentProjectName = "nonExistent";
            var body = new CreateDashboardRequest
            {
                name = $"create_{Guid.NewGuid()}_Updated",
                description = "description_Updated",
            };
            var response = client.UpdateDashboardRequest(nonExistentProjectName, body, "1");

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
