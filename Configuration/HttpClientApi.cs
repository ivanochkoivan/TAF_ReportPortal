using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TAF_ReportPortal_Configuration.Models;

namespace TAF_ReportPortal_Configuration
{
    public class HttpClientApi : IApiClient
    {
        private readonly HttpClient _client;
        private readonly Logger _logger;
        public HttpClientApi()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(TestEnvironment.Instance.Config.ApiTestConfig.APIHost);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constatnt.ApiKey);
            _logger = TestEnvironment.Instance.Logger;
        }

        public ApiResponse SendGetRequest(string requestUri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            var response = _client.SendAsync(request).Result;

            LogResponse(response);

            return new ApiResponse
            {
                Content = response.Content.ReadAsStringAsync().Result,
                StatusCode = response.StatusCode,
                RequestUri = response.RequestMessage.RequestUri
            };
        }

        public ApiResponse SendPostRequest(string requestUri, object body)
        {
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var response = _client.PostAsync(requestUri, content).Result;
            LogResponse(response);
            return new ApiResponse
            {
                Content = response.Content.ReadAsStringAsync().Result,
                StatusCode = response.StatusCode,
                RequestUri = response.RequestMessage.RequestUri
            };
        }

        public ApiResponse SendPutRequest(string requestUri, object body)
        {
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var response = _client.PutAsync(requestUri, content).Result;
            LogResponse(response);
            return new ApiResponse
            {
                Content = response.Content.ReadAsStringAsync().Result,
                StatusCode = response.StatusCode,
                RequestUri = response.RequestMessage.RequestUri
            };
        }

        public ApiResponse SendDeleteRequest(string requestUri)
        {
            var response = _client.DeleteAsync(requestUri).Result;
            LogResponse(response);
            return new ApiResponse
            {
                Content = response.Content.ReadAsStringAsync().Result,
                StatusCode = response.StatusCode,
                RequestUri = response.RequestMessage.RequestUri
            };
        }

        private void LogResponse(HttpResponseMessage response)
        {
            _logger.Log("Received response from: " + response.RequestMessage.RequestUri + " with status code: " + response.StatusCode);
            _logger.LogJson(response.Content.ReadAsStringAsync().Result);
        }
    }
}