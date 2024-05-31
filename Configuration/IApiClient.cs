using TAF_ReportPortal_Configuration.Models;

namespace TAF_ReportPortal_Configuration
{
    public interface IApiClient
    {
        ApiResponse SendGetRequest(string requestUri);
        ApiResponse SendPostRequest(string requestUri, object body);
        ApiResponse SendPutRequest(string requestUri, object body);
        ApiResponse SendDeleteRequest(string requestUri);
    }
}