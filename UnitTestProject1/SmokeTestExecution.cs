using System;
using System.Timers;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TCCApplication;
using TCCApplication.Data;
using TCCApplication.Utilities;
using TCCApplication.TestScripts;

namespace SmokeTest
{
    public class SmokeTestExecution
    {
        private IWebDriver _driver;
        private DriverUtilities _utils;

        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new FirefoxDriver();
            _utils = new DriverUtilities(_driver);
            System.IO.Directory.SetCurrentDirectory(TestContext.CurrentContext.WorkDirectory);
        }

        [Test]
        public void LoginLogoutTest()
        {
            UserLoginTestScript test = new UserLoginTestScript(_driver);
            test.UserLoginTestInput();
        }

        [Test]
        public void TestSearchForApplicant()
        {
            Search search = new Search(_driver);
            search.SearchForPerson("applicant", "", "Peter", "Parker", "", "", "");
        }

 
        [Test]
        public void TestSearchForMembers()
        {
            Search appSearch = new Search(_driver);
            appSearch.SearchForSchool("member", "", "Boston College", "", "");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Dispose();
        }
    }
}