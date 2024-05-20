using System.Net;

namespace TAF_ReportPortal_Configuration.Models
{
    public class ApiResponse
    {
        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public Uri RequestUri { get; set; }
    }
}
