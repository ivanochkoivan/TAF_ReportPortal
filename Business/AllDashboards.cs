using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_ReportPortal_Configuration;

namespace TAF_ReportPortal_Business
{
    public class AllDashboards : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Add New Dashboard')]")]
        private IWebElement addNewDashboardButton;

        private string addNewDashboardButtonXpath = "//span[contains(text(), 'Add New Dashboard')]";
        private string nameFieldXpath = "//input[@placeholder='Enter dashboard name']";
        private string descriptionFieldXpath = "//textarea[@placeholder='Enter dashboard description']";
        private string addDashboardButtonXpath = "//button[text()='Add']";
        private string successfullyCreatedDashboardXpath = "//p[text()='Dashboard has been added']";

        public AllDashboards(IWebDriver driver) : base(driver)
        {
            WaitingWhilePageIsLoading(addNewDashboardButtonXpath);
            PageFactory.InitElements(driver, this);
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
    }
}
