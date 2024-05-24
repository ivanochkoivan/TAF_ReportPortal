using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TAF_ReportPortal_Configuration;

public class CustomWebElement
{
    protected IWebDriver _driver;
    protected IWebElement _element;
    protected By _locator;

    public CustomWebElement(IWebDriver driver, By locator)
    {
        _driver = driver;
        _locator = locator;
        InitializeElement();
    }

    private void InitializeElement()
    {
        _element = _driver.FindElement(_locator);
    }

    public void Click()
    {
        InitializeElement();
        _element.Click();
        Log("Clicking on element.");
    }

    public void SendKeys(string keys)
    {
        InitializeElement();
        _element.SendKeys(keys);
        Log($"Sending keys '{keys}' to element.");
    }

    public string GetText()
    {
        InitializeElement();
        var text = _element.Text;
        Log($"Getting text: {text}");
        return text;
    }
    public void WaitUntilVisible(int timeoutInSeconds)
    {
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
        wait.Until(ExpectedConditions.ElementIsVisible(_locator));
    }

    public void WaitUntilClickable(int timeoutInSeconds)
    {
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
        wait.Until(ExpectedConditions.ElementToBeClickable(_locator));
    }

    public void FluentWaitUntilVisible(int timeoutInSeconds, int pollingIntervalInMilliseconds)
    {
        DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driver)
        {
            Timeout = TimeSpan.FromSeconds(timeoutInSeconds),
            PollingInterval = TimeSpan.FromMilliseconds(pollingIntervalInMilliseconds)
        };

        fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
        fluentWait.Until(ExpectedConditions.ElementIsVisible(_locator));
    }

    private void Log(string message)
    {
        TestEnvironment.Instance.Logger.Log(message);
    }
}