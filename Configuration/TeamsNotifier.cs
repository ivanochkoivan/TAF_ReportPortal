using System.Text;
using System.Text.Json;

namespace TAF_ReportPortal_Configuration
{
    public class TeamsNotifier
    {
        private readonly string _webhookUrl;

        public TeamsNotifier(string webhookUrl)
        {
            _webhookUrl = webhookUrl;
        }

        public void SendTeamsMessage(string message)
        {
            using (var client = new HttpClient())
            {
                var payload = new
                {
                    text = message
                };

                var serializedPayload = JsonSerializer.Serialize(payload);
                var content = new StringContent(serializedPayload, Encoding.UTF8, "application/json");

                var response = client.PostAsync(_webhookUrl, content).Result;

            }
        }
    }
}
