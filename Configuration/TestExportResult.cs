using TAF_ReportPortal_Configuration.Models;

namespace TAF_ReportPortal_Configuration
{
    public class TestExportResult
    {
        private readonly JiraClient _jiraClient;

        public TestExportResult(JiraClient jiraClient)
        {
            _jiraClient = jiraClient;
        }

        public async Task ExecuteAndImportResultsAsync()
        {
            var testExecution = GenerateTestExecution(); // This method will generate TestExecution object with test results

            TestResultsConverter converter = new TestResultsConverter();
            string jsonContent = converter.ConvertToXrayJson(testExecution);

            var response = await _jiraClient.ImportTestResultsAsync(jsonContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Test results were successfully imported into Xray.");
            }
            else
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Failed to import test results into Xray. Status code: {response.StatusCode}, Response: {responseBody}");
            }
        }

        private TestExecution GenerateTestExecution()
        {
            // Method to generate test execution results
            return new TestExecution
            {
                info = new Info
                {
                    summary = "Test Execution Summary",
                    description = "Detailed description of the test execution",
                    version = "1.0",
                    user = "tester",
                    revision = "r1",
                    startDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    finishDate = DateTime.UtcNow.AddHours(1).ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    testPlanKey = "TP-1",
                    testEnvironments = new List<string> { "Windows 10", "Chrome" }
                },
                tests = new List<Test>
            {
                new Test
                {
                    testKey = "TEST-1",
                    start = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    finish = DateTime.UtcNow.AddMinutes(5).ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    comment = "Test completed successfully",
                    status = "PASS",
                    testVersion = "v1",
                    customFields = new List<CustomField>(),
                    evidences = new List<Evidence>(),
                    examples = new List<string>(),
                    steps = new List<Step>(),
                    defects = new List<string>()
                }
            }
            };
        }
    }
}
