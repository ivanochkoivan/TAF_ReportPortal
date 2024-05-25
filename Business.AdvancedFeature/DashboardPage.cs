using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TAF_ReportPortal_Business.AdvancedFeature
{
    public class DashboardPage
    {
        private IWebDriver _driver;

        public DashboardPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private CustomWebElement _addNewWidgetButton => new CustomWebElement(_driver, By.XPath("//span[text()='Add new widget']"));
        private CustomWebElement _overallStatisticsOption => new CustomWebElement(_driver, By.XPath("//div[text()='Overall statistics']"));
        private CustomWebElement _nextStepButton => new CustomWebElement(_driver, By.XPath("//span[text()='Next step']"));
        private CustomWebElement _demoFilterOption => new CustomWebElement(_driver, By.XPath("//span[text()='DEMO_FILTER']"));
        private CustomWebElement _addButton => new CustomWebElement(_driver, By.XPath("//button[text()='Add']"));
        private CustomWebElement _widgetName => new CustomWebElement(_driver, By.XPath("//input[@placeholder='Enter widget name']"));
        private CustomWebElement _firstWidget => new CustomWebElement(_driver, By.XPath("(//div[contains(@class,'widgetHeader__info')])[1]"));
        private CustomWebElement _secondWidget => new CustomWebElement(_driver, By.XPath("(//div[contains(@class,'widgetHeader__info')])[2]"));

        private CustomWebElement _deleteWidgetButton => new CustomWebElement(_driver, By.XPath("//div[contains(@class, 'widget__common-control')]/div/div[3]"));
        private CustomWebElement _confirmDeleteButton => new CustomWebElement(_driver, By.XPath("//button[text()='Delete']"));

        public void ClickAddNewWidget()
        {
            _addNewWidgetButton.Click();
        }

        public void SelectOverallStatistics()
        {
            _overallStatisticsOption.Click();
        }

        public void ClickNextStep()
        {
            _nextStepButton.Click();
        }

        public void SelectDemoFilter()
        {
            _demoFilterOption.Click();
        }

        public void ConfirmWidgetAddition()
        {
            _addButton.Click();
        }

        public void EnterWidgetName(string name) 
        { 
            _widgetName.ClearField();
            _widgetName.SendKeys(name);
        }

        public bool IsWidgetPresent(string widgetName)
        {
            return _driver.FindElements(By.XPath($"//div[text()='{widgetName}']")).Count > 0;
        }

        public void AddOverallStatisticsWidget(string name)
        {
            ClickAddNewWidget();
            SelectOverallStatistics();
            ClickNextStep();
            SelectDemoFilter();
            ClickNextStep();
            EnterWidgetName(name);
            ConfirmWidgetAddition();
        }

        public void DragAndDropFirstWidgetToSecondWidget()
        {
            _firstWidget.DragAndDropTo(_secondWidget);
        }

        public bool IsFirstWidgetBelowSecondWidget()
        {
            var firstWidgetLocation = _firstWidget.GetYLocation();
            var secondWidgetLocation = _secondWidget.GetYLocation();
            return firstWidgetLocation < secondWidgetLocation;
        }

        public void DeleteWidget(string widgetName)
        {
            _firstWidget.HoverOnElement();
            _deleteWidgetButton.Click();
            _confirmDeleteButton.Click();
            _firstWidget.WaitUntilInvisible(2);
        }
    }
}
