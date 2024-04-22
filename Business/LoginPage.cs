using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TAF_ReportPortal_Configuration;


namespace TAF_ReportPortal_Business
{
    public class LoginPage : BasePage
    {
        private string url = TestEnvironment.Instance.Config.UiTestConfig.UIHost;

        private IWebElement loginField => driver.FindElement(By.XPath("//input[@placeholder='Login']"));

        private IWebElement passwordField => driver.FindElement(By.XPath("//input[@placeholder='Password']"));

        private IWebElement loginButton => driver.FindElement(By.XPath("//button[@type='submit']"));

        private string loginFieldXpath = "//input[@placeholder=\"Login\"]";

        public LoginPage(IWebDriver driver) : base(driver)
        {           
        }

        public void GoToLoginPage()
        {
            driver.Navigate().GoToUrl(url);
            WaitingWhilePageIsLoading(loginFieldXpath);
        }

        public void LoginWithData(string login = null, string password = null)
        {
            loginField.SendKeys(login);
            passwordField.SendKeys(password);
            loginButton.Click();
        }
    }
}
