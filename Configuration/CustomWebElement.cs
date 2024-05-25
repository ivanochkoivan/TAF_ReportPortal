using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        WaitUntilVisible(5);
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

    public void WaitUntilInvisible(int timeoutInSeconds)
    {
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
        wait.Until(ExpectedConditions.InvisibilityOfElementLocated(_locator));
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

    public void DragAndDropTo(CustomWebElement target)
    {
        Actions actions = new Actions(_driver);
        actions.DragAndDrop(_element, target._element).Perform();
    }

    public void ResizeElement(int xOffset, int yOffset)
    {
        Actions actions = new Actions(_driver);
        actions.ClickAndHold(_element)
               .MoveByOffset(xOffset, yOffset)
               .Release()
               .Perform();
    }

    public void ScrollToElement()
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        js.ExecuteScript("arguments[0].scrollIntoView(true);", _element);
    }

    public bool IsElementInView()
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        return (bool)js.ExecuteScript(
            "var rect = arguments[0].getBoundingClientRect();" +
            "return (" +
            "rect.top >= 0 &&" +
            "rect.left >= 0 &&" +
            "rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&" +
            "rect.right <= (window.innerWidth || document.documentElement.clientWidth));",
            _element
        );
    }

    public void ClickUsingJs()
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        js.ExecuteScript("arguments[0].click();", _element);
    }
}