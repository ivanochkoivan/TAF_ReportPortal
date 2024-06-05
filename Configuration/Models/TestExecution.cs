using Newtonsoft.Json;

namespace TAF_ReportPortal_Configuration.Models
{
    public class TestExecution
    {
        public Info info { get; set; }
        public List<Test> tests { get; set; }
    }

    public class Info
    {
        public string summary { get; set; }
        public string description { get; set; }
        public string version { get; set; }
        public string user { get; set; }
        public string revision { get; set; }
        public string startDate { get; set; }
        public string finishDate { get; set; }
        public string testPlanKey { get; set; }
        public List<string> testEnvironments { get; set; }
    }

    public class Test
    {
        public string testKey { get; set; }
        public string start { get; set; }
        public string finish { get; set; }
        public string comment { get; set; }
        public string status { get; set; }
        public string testVersion { get; set; }
        public List<CustomField> customFields { get; set; }
        public List<Evidence> evidences { get; set; }
        public List<string> examples { get; set; }
        public List<Step> steps { get; set; }
        public List<string> defects { get; set; }
    }

    public class CustomField
    {
        public int id { get; set; }
        public List<string> value { get; set; }
    }

    public class Evidence
    {
        public string data { get; set; }
        public string filename { get; set; }
        public string contentType { get; set; }
    }

    public class Step
    {
        public string status { get; set; }
        public string comment { get; set; }
        public List<Evidence> evidences { get; set; }
        public string actualResult { get; set; }
    }

    public class TestResultsConverter
    {
        public string ConvertToXrayJson(TestExecution testExecution)
        {
            return JsonConvert.SerializeObject(testExecution);
        }
    }
}
