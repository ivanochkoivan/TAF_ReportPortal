using OpenQA.Selenium;
using TAF_ReportPortal_Configuration;

public class ScreenshotTaker
{
    private readonly IWebDriver _driver;
    private readonly string _screenshotsDirectory;

    public ScreenshotTaker(IWebDriver driver, string screenshotsDirectory)
    {
        _driver = driver;
        _screenshotsDirectory = screenshotsDirectory;
    }

    public void TakeScreenshot(string screenshotName)
    {
        ITakesScreenshot takesScreenshot = _driver as ITakesScreenshot;
        Screenshot screenshot = takesScreenshot.GetScreenshot();
        string screenshotFilePath = Path.Combine(_screenshotsDirectory, $"{screenshotName}.png");
        screenshot.SaveAsFile(screenshotFilePath);
        TestEnvironment.Instance.Logger.Log($"Screenshot saved at {screenshotFilePath}");
    }
}