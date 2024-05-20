using TAF_ReportPortal_Configuration;
using TAF_ReportPortal_Configuration.Models;

namespace TAF_ReportPortal_Business
{
    public class APICalls
    {
        private readonly IApiClient _apiClient;
        public APICalls() { 
            _apiClient = TestEnvironment.Instance.ApiClient;
        }

        private string allDashboardPath = $"/dashboard";
        private string createDashboardPath = $"/dashboard";
        private string standardPath = "api/v1/";

        public ApiResponse AllDashboardRequest(string projectName)
        {
            var response = _apiClient.SendGetRequest(standardPath + projectName + allDashboardPath);
            return response;
        }

        public ApiResponse CreateDashboardRequest(string projectName, object body)
        {
            var response = _apiClient.SendPostRequest(standardPath + projectName + createDashboardPath, body);
            return response;
        }

        public ApiResponse UpdateDashboardRequest(string projectName, object body, string dashboardId)
        {
            var response = _apiClient.SendPutRequest(standardPath + projectName + createDashboardPath + $"/{dashboardId}", body);
            return response;
        }

        public ApiResponse DeleteDashboardRequest(string projectName, string dashboardId)
        {
            var response = _apiClient.SendDeleteRequest(standardPath + projectName + allDashboardPath + $"/{dashboardId}");
            return response;
        }
    }
}
