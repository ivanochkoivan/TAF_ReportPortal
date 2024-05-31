using OpenQA.Selenium;
using TAF_ReportPortal_Configuration.Utilities;

namespace TAF_ReportPortal_Business
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;           
        }

        public IWebElement FindElementByXpath(string xpath)
        {
            IWebElement webElement = driver.FindElement(By.XPath(xpath));
            return webElement;
        }

        public void WaitingWhilePageIsLoading(string xpath)
        {
            Utilities.WaitForElement(driver, By.XPath(xpath), 5);
        }
    }
}
