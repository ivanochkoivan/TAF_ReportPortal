﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TAF_ReportPortal_Business;
using NUnit.Framework;
using NUnit.Allure.Core;
using Microsoft.Extensions.Logging;
using TAF_ReportPortal_Configuration;

namespace TAF_ReportPortal_Tests
{
    [AllureNUnit]
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class CreateDashboardTest : BaseTest
    {
        [TestCase("785785_Create", "!@#$%^&*()_AASSFFFfdfdf", true)]
        [TestCase("45648FSUJdddasdHJHJK_Create", "ShortDescription", true)]
        [TestCase("F@#$%^&*()_Create", " ", true)]
        [TestCase("Create_Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc nisl justo, tincidunt id pulvinar hendrerit, vehicula in mi libero.", "", true)]
        [TestCase("AA", "ShortDescription", false)]
        public void CreateDashboardFeature(string name, string description, bool expectedResult)
        {
            try
            {
                Login();
                Logger.Log("Successful login");
            } catch (Exception ex) { Logger.LogError("LoginFailed", ex); }

            Menu menu = new Menu(WebDriver);
            menu.GoToDashboardPage();

            AllDashboards allDashboards = new AllDashboards(WebDriver);
            allDashboards.CreateNewDashboard(name, description);

            Assert.That(allDashboards.CheckIfDashboardWasCreated(), Is.EqualTo(expectedResult));
            Logger.Log($"Assertion for dashboard creation passed. Expected: {expectedResult}");
        }
    }
    [Parallelizable(ParallelScope.Fixtures)]
    public class SearchDasboardTest : BaseTest
    {
        [TestCase("785", true)]
        [TestCase("#$%", true)]
        [TestCase("SUJddda", true)]
        [TestCase("Non-esistent", true)]
        [TestCase("1", false)]
        public void SearchDashboardFeature(string filter, bool expectedResult)
        {
            try
            {
                Login();
                Logger.Log("Successful login");
            }
            catch (Exception ex) { Logger.LogError("LoginFailed", ex); }

            Menu menu = new Menu(WebDriver);
            menu.GoToDashboardPage();

            AllDashboards allDashboards = new AllDashboards(WebDriver);
            allDashboards.FindDashboardByName(filter);

            Assert.That(allDashboards.CheckIfDashboardFilteredCorrectly(filter), Is.EqualTo(expectedResult));
            Logger.Log($"Assertion for dashboard filtering passed. Expected: {expectedResult}");
        }
    }
    [Parallelizable(ParallelScope.Fixtures)]
    public class UpdateDashboardTest: BaseTest
    {
        [TestCase("!HKF:LD<", "UpdatedDescription", true)]
        [TestCase("!p;.d,.d", "", true)]
        [TestCase("!Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc nisl justo, tincidunt id pulvinar hendrerit, vehicula in mi libero.", "UpdatedDescription", true)]
        [TestCase("!H", "", false)]
        [TestCase("existingName", "UpdatedDescription", false)]
        public void UpdateDashboardFeature(string name, string description, bool expectedResult)
        {
            try
            {
                Login();
                Logger.Log("Successful login");
            }
            catch (Exception ex) { Logger.LogError("LoginFailed", ex); }

            Menu menu = new Menu(WebDriver);
            menu.GoToDashboardPage();

            AllDashboards allDashboards = new AllDashboards(WebDriver);
            allDashboards.UpdateDashboard(name, description);

            Assert.That(allDashboards.CheckIfDashboardWasUpdated(), Is.EqualTo(expectedResult));
            Logger.Log($"Assertion for dashboard filtering passed. Expected: {expectedResult}");
        }
    }
}

