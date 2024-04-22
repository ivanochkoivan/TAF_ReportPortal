using OpenQA.Selenium;

namespace TAF_ReportPortal_Business
{
    public class Menu : BasePage
    {
        private IWebElement DashboardButton => driver.FindElement(By.XPath("//div[contains(@class, \"sidebar__top-block\")]/div[1]"));

        private string DashboardButtonXpath = "//div[contains(@class, \"sidebar__top-block\")]/div[1]";

        public Menu(IWebDriver driver) : base(driver)
        {
            WaitingWhilePageIsLoading(DashboardButtonXpath);
        }

        public void GoToDashboardPage()
        {
            DashboardButton.Click();
        }
    }
}