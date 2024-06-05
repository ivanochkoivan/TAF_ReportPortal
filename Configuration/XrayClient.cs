using System.Net.Http.Headers;

namespace TAF_ReportPortal_Configuration
{
    public class XrayClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly string _apiToken;

        public XrayClient(string baseUrl, string apiToken)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl;
            _apiToken = apiToken;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken);
        }

        public async Task<HttpResponseMessage> ImportTestResultsAsync(string testExecutionId, string resultsJson)
        {
            var content = new StringContent(resultsJson, System.Text.Encoding.UTF8, "application/json");
            var url = $"{_baseUrl}/import/execution/{testExecutionId}";

            return await _httpClient.PostAsync(url, content);
        }
    }
}
