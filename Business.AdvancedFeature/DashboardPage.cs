using OpenQA.Selenium;
using OpenQA.Selenium.Support;

public class DashboardPage
{
    private IWebDriver _driver;

    public DashboardPage(IWebDriver driver)
    {
        _driver = driver;
    }


    private CustomWebElement _dashboardMenu => new CustomWebElement(_driver, By.XPath("//div[contains(@class, \"sidebar__top-block\")]/div[1]"));

    private CustomWebElement _addNewDashboardButton => new CustomWebElement(_driver, By.XPath("//span[contains(text(), 'Add New Dashboard')]"));

    private CustomWebElement _nameField => new CustomWebElement(_driver, By.XPath("//input[@placeholder='Enter dashboard name']"));
    private CustomWebElement _descriptionField => new CustomWebElement(_driver, By.XPath("//textarea[@placeholder='Enter dashboard description']"));

    private CustomWebElement _addButton => new CustomWebElement(_driver, By.XPath("//button[text()='Add']"));


    public void GoToDashboards()
    {
        _dashboardMenu.Click();
    }


    public void ClickAddNewDashboard()
    {
        _addNewDashboardButton.Click();
    }


    public void EnterDashboardDetails(string name, string description)
    {
        _nameField.SendKeys(name);
        _descriptionField.SendKeys(description);
    }


    public void ConfirmAddition()
    {
        _addButton.Click();
    }


    public bool IsDashboardPresent(string name)
    {
        return _driver.FindElements(By.XPath($"//a[text() = '{name}']")).Count > 0;
    }

    public void DeleteDashboard(string dashboardName)
    {
        CustomWebElement dashboard = new CustomWebElement(_driver, By.XPath($"(//a[text() = '{dashboardName}'])[2]"));
        var deleteButton = new CustomWebElement(_driver, By.XPath($"//a[text()='{dashboardName}']/following-sibling::div//i[contains(@class, 'delete')]"));
        deleteButton.ScrollToElement();
        deleteButton.Click();

        var confirmDeleteButton = new CustomWebElement(_driver, By.XPath("//button[text()='Delete']"));
        confirmDeleteButton.ClickUsingJs();
        
        dashboard.WaitUntilInvisible(5);
    }

    public void AddNewDashboard(string name, string description)
    {
        ClickAddNewDashboard();
        EnterDashboardDetails(name, description);
        ConfirmAddition();
    }

    public void DeleteDashboardIfPresent(string name)
    {
        if (IsDashboardPresent(name))
        {
            DeleteDashboard(name);
        }
    }
}