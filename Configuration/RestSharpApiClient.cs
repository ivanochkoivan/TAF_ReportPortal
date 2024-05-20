using RestSharp;
using TAF_ReportPortal_Configuration.Models;

namespace TAF_ReportPortal_Configuration
{
    public class RestSharpApiClient : IApiClient
    {
        private readonly IRestClient _client;
        private readonly Logger _logger;

        public RestSharpApiClient()
        {
            _client = new RestClient(TestEnvironment.Instance.Config.ApiTestConfig.APIHost);
            _client.AddDefaultHeader("Authorization", "Bearer " + Constatnt.ApiKey);
            _logger = TestEnvironment.Instance.Logger;
        }

        public ApiResponse SendGetRequest(string requestUri)
        {
            var request = new RestRequest(requestUri);
            return SendRequest(request);
        }

        public ApiResponse SendPostRequest(string requestUri, object body)
        {
            var request = new RestRequest(requestUri, Method.Post);
            request.AddJsonBody(body);
            return SendRequest(request);
        }

        public ApiResponse SendPutRequest(string requestUri, object body)
        {
            var request = new RestRequest(requestUri, Method.Put);
            request.AddJsonBody(body);
            return SendRequest(request);
        }

        public ApiResponse SendDeleteRequest(string requestUri)
        {
            var request = new RestRequest(requestUri, Method.Delete);
            return SendRequest(request);
        }

        private ApiResponse SendRequest(RestRequest request)
        {
            var response = _client.ExecuteAsync(request).Result;
            LogResponse(response);
            return new ApiResponse
            {
                Content = response.Content,
                StatusCode = response.StatusCode,
                RequestUri = response.ResponseUri,
            };
        }

        private void LogResponse(RestResponse response)
        {
            _logger.Log("Received response from: " + response.ResponseUri + " with status code: " + response.StatusCode);
            _logger.LogJson(response.Content);
        }
    }
}