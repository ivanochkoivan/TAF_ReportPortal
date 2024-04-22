using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using TAF_ReportPortal_Configuration;

namespace TAF_ReportPortal_Business
{
    public class AllDashboards : BasePage
    {
        private IWebElement addNewDashboardButton => driver.FindElement(By.XPath("//span[contains(text(), 'Add New Dashboard')]"));
        private IWebElement findByNameField => driver.FindElement(By.XPath("//input[@placeholder='Search by name']"));
        private IList<IWebElement> existingDashboards => driver.FindElements(By.XPath("//div[contains(@class, 'grid__grid')]/div[contains(@class, 'gridRow')]"));
        private IWebElement updateFirstElementButton => driver.FindElement(By.XPath("//i[contains(@class, 'pencil')][1]"));

        //private string addNewDashboardButtonXpath = "//span[contains(text(), 'Add New Dashboard')]";
        private string nameFieldXpath = "//input[@placeholder='Enter dashboard name']";
        private string descriptionFieldXpath = "//textarea[@placeholder='Enter dashboard description']";
        private string addDashboardButtonXpath = "//button[text()='Add']";
        private string updateDashboardButtonXpath = "//button[text()='Update']";
        private string successfullyCreatedDashboardXpath = "//p[text()='Dashboard has been added']";
        private string existingDashboardsXpath = "//div[contains(@class, 'grid__grid')]/div[contains(@class, 'gridRow')]";
        private string existingDashboardsNames = "//div[contains(@class, 'grid__grid')]/div[contains(@class, 'gridRow')]//a";

        public AllDashboards(IWebDriver driver) : base(driver)
        {
            WaitingWhilePageIsLoading(existingDashboardsXpath);
        }

        public void CreateNewDashboard(string name, string description)
        {
            addNewDashboardButton.Click();
            IWebElement nameField = FindElementByXpath(nameFieldXpath);
            IWebElement descriptionField = FindElementByXpath(descriptionFieldXpath);
            IWebElement addDashboardButton = FindElementByXpath(addDashboardButtonXpath);

            nameField.SendKeys(name);
            descriptionField.SendKeys(description);
            addDashboardButton.Click();
        }

        public void UpdateDashboard(string name, string description)
        {
            updateFirstElementButton.Click();
            IWebElement nameField = FindElementByXpath(nameFieldXpath);
            IWebElement descriptionField = FindElementByXpath(descriptionFieldXpath);
            IWebElement updateDashboardButton = FindElementByXpath(updateDashboardButtonXpath);

            nameField.Clear();
            descriptionField.Clear();

            nameField.SendKeys(name);
            descriptionField.SendKeys(description);
            updateDashboardButton.Click();
        }

        public void FindDashboardByName(string name)
        {
            findByNameField.SendKeys(name);

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                wait.Until(condition =>
                {
                    var elements = driver.FindElements(By.XPath(existingDashboardsXpath));
                    return elements.Count < existingDashboards.ToList().Count;
                });
            } catch { }
        }

        public bool CheckIfDashboardFilteredCorrectly(string filter)
        {
            List<IWebElement> dashboardsNames = driver.FindElements(By.XPath(existingDashboardsNames)).ToList();

            if(!existingDashboards.Any(x => x.Text.Contains(filter)) & dashboardsNames.Count == 0)
            {
                return true;
            }
            else if (!existingDashboards.Any(x => x.Text.Contains(filter)) & dashboardsNames.Count != 0)
            {
                return false;
            }
            else
            {
                return dashboardsNames.All(e => e.Text.Contains(filter));
            }
        }

        public bool CheckIfDashboardWasCreated()
        {
            try
            {
                Utilities.WaitForElement(driver, By.XPath(successfullyCreatedDashboardXpath), 2);
                FindElementByXpath(successfullyCreatedDashboardXpath);
                return true;
            }
            catch { 
                return false;
            }
        }

        public bool CheckIfDashboardWasUpdated()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                wait.Until(condition =>
                {
                    var element = driver.FindElements(By.XPath(updateDashboardButtonXpath));
                    return !element.Any();
                });
                return true;
            } catch { return false; }
        }
    }
}
