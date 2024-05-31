namespace TAF_ReportPortal_Configuration.Models
{
    public class AllDashboards
    {
        public List<Content> content { get; set; }
        public Page page { get; set; }
    }

    public class Content
    {
        public string description { get; set; }
        public string owner { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public List<Widget> widgets { get; set; }
    }

    public class Widget
    {
        public string widgetName { get; set; }
        public int widgetId { get; set; }
        public string widgetType { get; set; }
        public WidgetSize widgetSize { get; set; }
        public WidgetPosition widgetPosition { get; set; }
        public WidgetOptions widgetOptions { get; set; }
    }

    public class WidgetSize
    {
        public int width { get; set; }
        public int height { get; set; }
    }

    public class WidgetPosition
    {
        public int positionX { get; set; }
        public int positionY { get; set; }
    }

    public class WidgetOptions
    {
        public string viewMode { get; set; }
        public bool? includeSkipped { get; set; }
        public string launchNameFilter { get; set; }
        public bool? latest { get; set; }
    }

    public class Page
    {
        public int number { get; set; }
        public int size { get; set; }
        public int totalElements { get; set; }
        public int totalPages { get; set; }
    }
}