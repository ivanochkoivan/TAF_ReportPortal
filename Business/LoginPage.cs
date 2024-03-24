using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TAF_ReportPortal.Business
{
    public class LoginPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder=\"Login\"]")]
        private IWebElement loginField;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder=\"Password\"]")]
        private IWebElement passwordField;

        [FindsBy(How = How.XPath, Using = "//button[@type=\"submit\"]")]
        private IWebElement loginButton;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void LoginWithData(string? login = null, string? password = null)
        {
            loginField.SendKeys(login);
            passwordField.SendKeys(password);
            loginButton.Click();
        }
    }
}
