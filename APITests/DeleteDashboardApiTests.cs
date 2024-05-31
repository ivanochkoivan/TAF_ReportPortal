using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using TAF_ReportPortal_Business;
using TAF_ReportPortal_Configuration.Models;

namespace TAF_ReportPortal_APITests
{
    public class DeleteDashboardApiTests : BaseTest
    {      
        //Delete a dashboard with valid data - check success status code
        [TestCase]
        public void DeleteDashboardsWithValidData()
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
            var response = client.DeleteDashboardRequest(validProjectName, dashboardId.ToString());

            //Check
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        //Delete a dashboard with non-existent dashboard id - check not found status code
        [TestCase]
        public void UpdateDashboardsWithNonExistentData()
        {
            //Act
            APICalls client = new APICalls();
            string validProjectName = "superadmin_personal";
            var response = client.DeleteDashboardRequest(validProjectName, "111111111111");

            //Check
            var responseContent = JsonConvert.DeserializeObject<ApiError>(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            if (responseContent != null)
            {
                Assert.That(responseContent.message, Is.EqualTo($"Dashboard with ID '111111111111' not found on project 'superadmin_personal'. Did you use correct Dashboard ID?"));
            }
            else
            {
                Assert.Fail("Response content is null");
            }
        }

    }
}
