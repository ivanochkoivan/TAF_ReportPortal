using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TAF_ReportPortal_Configuration;


namespace TAF_ReportPortal_Business
{
    public class LoginPage : BasePage
    {
        private string url = TestEnvironment.Instance.Config.UiTestConfig.UIHost;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder=\"Login\"]")]
        private IWebElement loginField;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder=\"Password\"]")]
        private IWebElement passwordField;

        [FindsBy(How = How.XPath, Using = "//button[@type=\"submit\"]")]
        private IWebElement loginButton;

        private string loginFieldXpath = "//input[@placeholder=\"Login\"]";

        public LoginPage(IWebDriver driver) : base(driver)
        {           
            PageFactory.InitElements(driver, this);
        }

        public void GoToLoginPage()
        {
            driver.Navigate().GoToUrl(url);
            WaitingWhilePageIsLoading(loginFieldXpath);
        }

        public void LoginWithData(string? login = null, string? password = null)
        {
            loginField.SendKeys(login);
            passwordField.SendKeys(password);
            loginButton.Click();
        }
    }
}
