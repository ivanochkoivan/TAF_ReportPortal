using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace TAF_ReportPortal.Configuration
{
    public static class Utilities
    {
        private static readonly Random random = new Random();

        public static int GenerateRandomNumber(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }

        public static void WaitForElement(IWebDriver driver, By by, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(driver => driver.FindElements(by).Count > 0);
        }
    }
}
