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
    public class Menu : BasePage
    { 
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, \"sidebar__top-block\")]/div[1]")]
        private IWebElement DashboardButton;

        private string DashboardButtonXpath = "//div[contains(@class, \"sidebar__top-block\")]/div[1]";

        public Menu(IWebDriver driver) : base(driver)
        {
            WaitingWhilePageIsLoading(DashboardButtonXpath);
            PageFactory.InitElements(driver, this);
        }

        public void GoToDashboardPage() { 
            DashboardButton.Click();
        }
    }
}
