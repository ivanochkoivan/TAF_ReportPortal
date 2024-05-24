using OpenQA.Selenium;
using System.Security.Policy;
using TAF_ReportPortal_Configuration;

public class LoginPage
{
    private readonly IWebDriver _driver;

    private string url = TestEnvironment.Instance.Config.UiTestConfig.UIHost;

    private CustomWebElement _usernameInput => new CustomWebElement(_driver, By.XPath("//input[@placeholder='Login']"));
    private CustomWebElement _passwordInput => new CustomWebElement(_driver, By.XPath("//input[@placeholder='Password']"));
    private CustomWebElement _loginButton => new CustomWebElement(_driver, By.XPath("//button[@type='submit']"));

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void GoToLoginPage()
    {
        _driver.Navigate().GoToUrl(url);
        _usernameInput.WaitUntilVisible(10);
    }

    public void EnterUsername(string username)
    {
        _usernameInput.SendKeys(username);
    }

    public void EnterPassword(string password)
    {
        _passwordInput.SendKeys(password);
    }

    public void ClickLoginButton()
    {
        _loginButton.WaitUntilClickable(10);
        _loginButton.Click();
    }
}