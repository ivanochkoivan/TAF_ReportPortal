using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TAF_ReportPortal_Business
{
    public class Menu : BasePage
    { 
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, \"sidebar__top-block\")]/div[1]")]
        private IWebElement DashboardButton;

        private string DashboardButtonXpath = "//div[contains(@class, \"sidebar__top-block\")]/div[1]";

        public Menu(IWebDriver driver) : base(driver)
        {
            WaitingWhilePageIsLoading(DashboardButtonXpath);
            PageFactory.InitElements(driver, this);
        }

        public void GoToDashboardPage() { 
            DashboardButton.Click();
        }
    }
}
