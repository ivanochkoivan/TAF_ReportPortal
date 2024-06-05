using System.Net.Http.Headers;
using System.Text;

public class JiraClient
{
    private readonly HttpClient _httpClient;
    private string token;

    // Constructor to initialize HttpClient with base URL and authorization
    public JiraClient(string baseUrl, string username, string apiToken)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(baseUrl)
        };

        Token(username, apiToken).Wait();

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    public async Task Token(string username, string apiToken)
    {
        var jsonContent = $"{{ \"client_id\": \"{username}\",\"client_secret\": \"{apiToken}\" }}";
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("/api/v2/authenticate", content);
        token = await response.Content.ReadAsStringAsync();
    }

    // Method to post the JSON to Xray
    public async Task<HttpResponseMessage> ImportTestResultsAsync(string jsonContent)
    {
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _httpClient.PostAsync("/api/v2/import/execution", content);
        return response;
    }
}